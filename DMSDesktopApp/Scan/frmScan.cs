using DC.DMS.Services.Models;
using DC.DMS.Services.Models.Main;
using DC.DMS.Services.WorkflowModels;
using DC.DMS.Services.WorkflowModels.Directories;
using DC.ImagUtility.Q16.Services;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using DC.DMS.Services.Property;
using DC.DMS.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Miscellaneous;
using NTwain;
using NTwain.Data;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Media.Imaging;
using Utilities;
using static DC.DMS.Services.Enum.WorkflowEnums;
using DC.Process;



namespace DMS.DesktopApp.Scan
{
    public partial class frmScan : Form
    {
        #region Fields

        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;


        ImageCodecInfo _tiffCodecInfo;
        TwainSession _twain;
        ImageCodecInfo jpgEncoder;
        bool _stopScan;
        bool _loadingCaps;

        private int Counter = 0;
        private int CaseDetailID = 0;
        private string ScanDate;
        private string extension = ".jpg";
        private FileDetailHelper CaseDetailHelper;
        private ServerDateTimeHelper serverDateTimeHelper;
        private List<FileDetail> FileDetailList;
        private DirectoryHelper DirectoryHelper;
        private FileDirectoryHelper CaseDirectoryHelper;
        private SubDirectoryHelper SubDirectoryHelper;
        private BindingList<ImageListVM> ImageFileList;
        RectangleF FrontRectangle;
        ScanType CurrentScanType;

        private int SelectedFileDetailID = 0;

        #endregion

        public frmScan(string scanDate, IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            ScanDate = scanDate;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            DirectoryHelper = new DirectoryHelper(_dbContext, _cache, _translationService);
            SubDirectoryHelper = new SubDirectoryHelper(_dbContext, _cache, _translationService);
            ImageFileList = new BindingList<ImageListVM>();
            CaseDetailHelper = new FileDetailHelper(_dbContext);
            CaseDirectoryHelper = new FileDirectoryHelper(_dbContext, _cache, _translationService);

            if (PlatformInfo.Current.IsApp64Bit)
            {
                Text = Text + " (64bit)";
            }
            else
            {
                Text = Text + " (32bit)";
            }
            foreach (var enc in ImageCodecInfo.GetImageEncoders())
            {
                if (enc.MimeType == "image/tiff") { _tiffCodecInfo = enc; break; }
            }
            jpgEncoder = GetEncoders(ImageFormat.Jpeg);
            foreach (var enc in ImageCodecInfo.GetImageEncoders())
            {
                if (enc.MimeType == "image/tiff") { _tiffCodecInfo = enc; break; }
            }
        }

        private ImageCodecInfo GetEncoders(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #region setup & cleanup

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetupTwain();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_twain != null)
            {
                if (e.CloseReason == CloseReason.UserClosing && _twain.State > 4)
                {
                    e.Cancel = true;
                }
                else
                {
                    CleanupTwain();
                }
            }
            base.OnFormClosing(e);
        }

        private void SetupTwain()
        {
            var appId = TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetEntryAssembly());
            _twain = new TwainSession(appId);
            _twain.StateChanged += (s, e) =>
            {
                PlatformInfo.Current.Log.Info("State changed to " + _twain.State + " on thread " + Thread.CurrentThread.ManagedThreadId);
            };
            _twain.TransferError += (s, e) =>
            {
                PlatformInfo.Current.Log.Info("Got xfer error on thread " + Thread.CurrentThread.ManagedThreadId);
            };
            _twain.DataTransferred += (s, e) =>
            {
                PlatformInfo.Current.Log.Info("Transferred data event on thread " + Thread.CurrentThread.ManagedThreadId);

                // example on getting ext image info
                var infos = e.GetExtImageInfo(ExtendedImageInfo.Camera).Where(it => it.ReturnCode == ReturnCode.Success);
                foreach (var it in infos)
                {
                    var values = it.ReadValues();
                    PlatformInfo.Current.Log.Info(string.Format("{0} = {1}", it.InfoID, values.FirstOrDefault()));
                    break;
                }

                // handle image data
                Image img = null;
                if (e.NativeData != IntPtr.Zero)
                {
                    var stream = e.GetNativeImageStream();
                    if (stream != null)
                    {
                        img = Image.FromStream(stream);
                    }
                }
                else if (!string.IsNullOrEmpty(e.FileDataPath))
                {
                    img = new Bitmap(e.FileDataPath);
                }
                if (img != null)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        if (imgBox.Image != null)
                        {
                            imgBox.Image.Dispose();
                            imgBox.Image = null;
                        }
                        SaveImage(img);
                        imgBox.Image = img;
                        imgBox.ZoomToFit();
                        DisplayRecordNumbers("");
                        //lstImgBox.SelectedIndex = lstImgBox.Items.Count - 1;

                    }));
                }
            };
            _twain.SourceDisabled += (s, e) =>
            {
                PlatformInfo.Current.Log.Info("Source disabled event on thread " + Thread.CurrentThread.ManagedThreadId);
                this.BeginInvoke(new Action(() =>
                {
                    btnStopScan.Enabled = false;
                    btnStartCapture.Enabled = true;
                    ScanOptionEnable(true);
                    LoadSourceCaps();
                }));
            };
            _twain.TransferReady += (s, e) =>
            {
                PlatformInfo.Current.Log.Info("Transferr ready event on thread " + Thread.CurrentThread.ManagedThreadId);
                e.CancelAll = _stopScan;
            };

            // either set sync context and don't worry about threads during events,
            // or don't and use control.invoke during the events yourself
            PlatformInfo.Current.Log.Info("Setup thread = " + Thread.CurrentThread.ManagedThreadId);
            _twain.SynchronizationContext = SynchronizationContext.Current;
            if (_twain.State < 3)
            {
                // use this for internal msg loop
                _twain.Open();
                // use this to hook into current app loop
                //_twain.Open(new WindowsFormsMessageLoopHook(this.Handle));
            }
        }

        private void CleanupTwain()
        {
            if (_twain.State == 4)
            {
                _twain.CurrentSource.Close();
            }
            if (_twain.State == 3)
            {
                _twain.Close();
            }

            if (_twain.State > 2)
            {
                // normal close down didn't work, do hard kill
                _twain.ForceStepDown(2);
            }
        }

        private void ScanOptionEnable(bool v)
        {
            lblDPI.Enabled = v;
            lblMode.Enabled = v;
            lblSize.Enabled = v;
            lblFormat.Enabled = v;
            // Toggle duplex label too (match decompiled behavior)
            lblDuplex.Enabled = v;
            cobDPI.Enabled = v;
            cobMode.Enabled = v;
            cobSize.Enabled = v;
            chkDuplex.Enabled = v;
            cobOutputFormat.Enabled = v;
        }
        #endregion

        #region toolbar
        private void btnSources_DropDownOpening(object sender, EventArgs e)
        {
            if (btnSources.DropDownItems.Count == 2)
            {
                ReloadSourceList();
            }
        }
        private void ReloadSourceList()
        {
            if (_twain.State >= 3)
            {
                while (btnSources.DropDownItems.IndexOf(sepSourceList) > 0)
                {
                    var first = btnSources.DropDownItems[0];
                    first.Click -= SourceMenuItem_Click;
                    btnSources.DropDownItems.Remove(first);
                }
                foreach (var src in _twain)
                {
                    var srcBtn = new ToolStripMenuItem(src.Name);
                    srcBtn.Tag = src;
                    srcBtn.Click += SourceMenuItem_Click;
                    srcBtn.Checked = _twain.CurrentSource != null && _twain.CurrentSource.Name == src.Name;
                    btnSources.DropDownItems.Insert(0, srcBtn);
                }
            }
        }
        private void reloadSourcesListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ReloadSourceList();
        }
        void SourceMenuItem_Click(object sender, EventArgs e)
        {
            // do nothing if source is enabled
            if (_twain.State > 4) { return; }

            if (_twain.State == 4) { _twain.CurrentSource.Close(); }

            foreach (var btn in btnSources.DropDownItems)
            {
                var srcBtn = btn as ToolStripMenuItem;
                if (srcBtn != null) { srcBtn.Checked = false; }
            }

            var curBtn = (sender as ToolStripMenuItem);
            var src = curBtn.Tag as DataSource;
            if (src.Open() == ReturnCode.Success)
            {
                curBtn.Checked = true;
                btnStartCapture.Enabled = true;
                chkDuplex.Checked = true;
                LoadSourceCaps();
            }
        }

        #endregion

        #region cap control


        private void LoadSourceCaps()
        {
            var src = _twain.CurrentSource;
            _loadingCaps = true;

            //var test = src.SupportedCaps;

            if (cobMode.Enabled = src.Capabilities.ICapPixelType.IsSupported)
            {
                LoadDepth(src.Capabilities.ICapPixelType);
            }
            if (cobDPI.Enabled = src.Capabilities.ICapXResolution.IsSupported && src.Capabilities.ICapYResolution.IsSupported)
            {
                LoadDPI(src.Capabilities.ICapXResolution);
            }
            // TODO: find out if this is how duplex works or also needs the other option
            if (chkDuplex.Enabled = src.Capabilities.CapDuplexEnabled.IsSupported)
            {
                LoadDuplex(src.Capabilities.CapDuplexEnabled);
            }
            if (cobSize.Enabled = src.Capabilities.ICapSupportedSizes.IsSupported)
            {
                LoadPaperSize(src.Capabilities.ICapSupportedSizes);
            }
            btnScannerSettings.Enabled = src.Capabilities.CapEnableDSUIOnly.IsSupported;
            _loadingCaps = false;
        }

        private void LoadPaperSize(ICapWrapper<SupportedSize> cap)
        {
            var list = cap.GetValues().ToList();
            list.ForEach(x => cobSize.Items.Add(x));
            //cobSize.DataSource = list;
            var cur = cap.GetCurrent();
            if (list.Contains(cur))
            {
                cobSize.SelectedItem = cur;
            }
            var labelTest = cap.GetLabel();
            if (!string.IsNullOrEmpty(labelTest))
            {
                lblSize.Text = labelTest;
            }
        }


        private void LoadDuplex(ICapWrapper<BoolType> cap)
        {
            chkDuplex.Checked = cap.GetCurrent() == BoolType.True;
        }


        private void LoadDPI(ICapWrapper<TWFix32> cap)
        {
            // only allow dpi of certain values for those source that lists everything
            var list = cap.GetValues().Where(dpi => (dpi % 50) == 0).ToList();
            list.ForEach(x => cobDPI.Items.Add(x));
            //comboDPI.DataSource = list;
            var cur = cap.GetCurrent();
            if (list.Contains(cur))
            {
                cobDPI.SelectedItem = cur;
            }
        }

        private void LoadDepth(ICapWrapper<PixelType> cap)
        {
            var list = cap.GetValues().ToList();
            list.ForEach(x => cobMode.Items.Add(x));
            //comboDepth.DataSource = list;
            var cur = cap.GetCurrent();
            if (list.Contains(cur))
            {
                cobMode.SelectedItem = cur;
            }
            var labelTest = cap.GetLabel();
            if (!string.IsNullOrEmpty(labelTest))
            {
                lblMode.Text = labelTest;
            }
        }

        private void comboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingCaps && _twain.State == 4)
            {
                var sel = (SupportedSize)cobSize.SelectedItem;
                _twain.CurrentSource.Capabilities.ICapSupportedSizes.SetValue(sel);
            }
        }

        private void comboDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingCaps && _twain.State == 4)
            {
                var sel = (PixelType)cobMode.SelectedItem;
                _twain.CurrentSource.Capabilities.ICapPixelType.SetValue(sel);
            }
        }

        private void comboDPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingCaps && _twain.State == 4)
            {
                var sel = (TWFix32)cobDPI.SelectedItem;
                _twain.CurrentSource.Capabilities.ICapXResolution.SetValue(sel);
                _twain.CurrentSource.Capabilities.ICapYResolution.SetValue(sel);
            }
        }

        private void ckDuplex_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuplex.Checked)
            {
                chkDuplex.Image = Resources.checkboxChecked50x;
            }
            else
            {
                chkDuplex.Image = Resources.checkboxUnchecked50x;
            }
            if (!_loadingCaps && _twain.State == 4)
            {
                _twain.CurrentSource.Capabilities.CapDuplexEnabled.SetValue(chkDuplex.Checked ? BoolType.True : BoolType.False);
            }
        }

        private void btnAllSettings_Click(object sender, EventArgs e)
        {
            _twain.CurrentSource.Enable(SourceEnableMode.ShowUIOnly, true, this.Handle);
        }

        #endregion
        private void FillZoomLevels()
        {
            cobZoomLevel.Items.Clear();

            foreach (int zoom in imgBox.ZoomLevels)
            {
                cobZoomLevel.Items.Add(string.Format("{0}%", zoom));
            }
        }
        private void ZoomLevelChanged()
        {
            int zoom;
            zoom = Convert.ToInt32(cobZoomLevel.Text.Substring(0, cobZoomLevel.Text.Length - 1));
            imgBox.Zoom = zoom;
            imgBox.Refresh();

        }
        private async void frmScan_Load(object sender, EventArgs e)
        {
            cobOutputFormat.SelectedIndex = 1;
            await LoadData();
            LoadBarcodes();
            switch (AppDetails.ID)
            {
                case 1:
                    cobFileName.Visible = true;
                    break;
                case 2:
                    cobFileName.Visible = true;
                    break;
                case 3:
                    cobFileName.Visible = false;
                    break;
                case 4:
                    cobFileName.Visible = false;
                    break;
                default:
                    break;
            }
            FillZoomLevels();
            imgBox.ZoomIn();
            cobZoomLevel.SelectedIndex = cobZoomLevel.FindStringExact("20%");
        }
        private void LoadBarcodes()
        {
            try
            {
                switch (AppDetails.ID)
                {
                    case 1:
                        var userID = AppUser.ID;
                        var barcodesDharwadList = FileDetailList
                            .Where(x => x.CreatedDateTime.Value.ToString("yyyy-MM-dd")
                            .Contains(ScanDate) && x.Status == Status.FileReceive && x.Flag != Flag.Delete)
                            .Select(x => new DropDownHelper { ID = x.ID, Name = x.Barcode }).Distinct().ToList();
                        cobBarcode.SelectedIndexChanged -= cobBarcode_SelectedIndexChanged;
                        cobBarcode.DataSource = null;
                        cobBarcode.DataSource = barcodesDharwadList;
                        cobBarcode.DisplayMember = "Name";
                        cobBarcode.ValueMember = "ID";
                        cobBarcode.SelectedIndex = -1;
                        cobBarcode.SelectedIndexChanged += cobBarcode_SelectedIndexChanged;
                        if (cobBarcode.Items.Count > 0)
                            cobBarcode.SelectedIndex = 0;
                        break;
                    case 3:
                        //var barcodesList = CaseDetailList.Where(x => x.CreateDateTime.Value.ToString("yyyy-MM-dd").Contains(ScanDate) && x.CourtID == CourtID && x.FileStatusID == (CaseFileStatus)FileStatusID).Select(x => new DropDownHelper { ID = x.ID, Name = x.Barcode }).Distinct().ToList();
                        //cobBarcode.SelectedIndexChanged -= cobBarcode_SelectedIndexChanged;
                        //cobBarcode.DataSource = null;
                        //cobBarcode.DataSource = barcodesList;
                        //cobBarcode.DisplayMember = "Name";
                        //cobBarcode.ValueMember = "ID";
                        //cobBarcode.SelectedIndex = -1;
                        //cobBarcode.SelectedIndexChanged += cobBarcode_SelectedIndexChanged;
                        //if (cobBarcode.Items.Count > 0)
                        //    cobBarcode.SelectedIndex = 0;
                        break;
                    default:
                        //var AllbarcodesList = CaseDetailList.Where(x => x.CreateDateTime.Value.ToString("yyyy-MM-dd").Contains(ScanDate) && x.CourtID == CourtID && x.FileStatusID == (CaseFileStatus)FileStatusID).Select(x => new DropDownHelper { ID = x.ID, Name = x.Barcode }).Distinct().ToList();
                        //cobBarcode.SelectedIndexChanged -= cobBarcode_SelectedIndexChanged;
                        //cobBarcode.DataSource = null;
                        //cobBarcode.DataSource = AllbarcodesList;
                        //cobBarcode.DisplayMember = "Name";
                        //cobBarcode.ValueMember = "ID";
                        //cobBarcode.SelectedIndex = -1;
                        //cobBarcode.SelectedIndexChanged += cobBarcode_SelectedIndexChanged;
                        //if (cobBarcode.Items.Count > 0)
                        //    cobBarcode.SelectedIndex = 0;
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadData()
        {
            FileDetailList = await CaseDetailHelper.GetCaseDetailsList(Status.FileReceive);
            txtCaseNo.Text = FileDetailList.Select(x => x.CaseNo).FirstOrDefault();
            txtCaseTitle.Text = FileDetailList.Select(x => x.CaseTitle).FirstOrDefault();
            txtDepartmentName.Text = FileDetailList.Select(x => x.Department.Name).FirstOrDefault();
            txtFileNumber.Text = FileDetailList.Select(x => x.FileNumber).FirstOrDefault();
        }

        private void chkDuplex_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkDuplex.Checked)
            //{
            //    chkDuplex.Image = Resources.checkboxChecked50x;
            //}
            //else
            //{
            //    chkDuplex.Image = Resources.checkboxUnchecked50x;
            //}
            if (!_loadingCaps && _twain.State == 4)
            {
                _twain.CurrentSource.Capabilities.CapDuplexEnabled.SetValue(chkDuplex.Checked ? BoolType.True : BoolType.False);
            }
        }

        private void btnScannerSettings_Click(object sender, EventArgs e)
        {
            _twain.CurrentSource.Enable(SourceEnableMode.ShowUIOnly, true, this.Handle);
        }

        private void cobDPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingCaps && _twain.State == 4)
            {
                var sel = (TWFix32)cobDPI.SelectedItem;
                _twain.CurrentSource.Capabilities.ICapXResolution.SetValue(sel);
                _twain.CurrentSource.Capabilities.ICapYResolution.SetValue(sel);
            }
        }

        private void cobMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingCaps && _twain.State == 4)
            {
                var sel = (PixelType)cobMode.SelectedItem;
                _twain.CurrentSource.Capabilities.ICapPixelType.SetValue(sel);
            }
        }

        private void cobSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingCaps && _twain.State == 4)
            {
                var sel = (SupportedSize)cobSize.SelectedItem;
                _twain.CurrentSource.Capabilities.ICapSupportedSizes.SetValue(sel);
            }
        }

        private void btnStartCapture_Click_1(object sender, EventArgs e)
        {
            StartScanning();
        }

        private void StartScanning()
        {
            if (_twain.State == 4)
            {
                //_twain.CurrentSource.CapXferCount.Set(4);

                _stopScan = false;

                if (_twain.CurrentSource.Capabilities.CapUIControllable.IsSupported)//.SupportedCaps.Contains(CapabilityId.CapUIControllable))
                {
                    // hide scanner ui if possible
                    if (_twain.CurrentSource.Enable(SourceEnableMode.NoUI, false, this.Handle) == ReturnCode.Success)
                    {
                        btnSubmit.Enabled = true;
                        btnStopScan.Enabled = true;
                        btnStartCapture.Enabled = false;
                        ScanOptionEnable(false);
                    }
                }
                else
                {
                    if (_twain.CurrentSource.Enable(SourceEnableMode.ShowUI, true, this.Handle) == ReturnCode.Success)
                    {
                        btnSubmit.Enabled = true;
                        btnStopScan.Enabled = true;
                        btnStartCapture.Enabled = false;
                        ScanOptionEnable(false);
                    }
                }
            }
        }

        private void btnStopScan_Click_1(object sender, EventArgs e)
        {
            _stopScan = true;
        }

        private async Task SaveImage()
        {
            Cursor.Current = Cursors.WaitCursor;
            Compressor imgCompressor = new Compressor();
            try
            {
                string errorMessage = null;
                string fileName = Path.GetFileName(GetCurrentImagePath(lstImgBox.SelectedValue.ToString()));
                //string extension = Path.GetExtension(lblImagePath.Text);
                string path = lblGeneratedPath.Text;
                Directory.CreateDirectory(path);
                string destinationPath = Path.Combine(path, fileName);

                switch (extension)
                {
                    case ".tif":
                    case ".tiff":
                        byte[] imgData = Conversion.BitmapToByte(new Bitmap(imgBox.Image), ImageFormat.Tiff);
                        new Compressor().CustomCompressTiffImage(new Bitmap(imgBox.Image), destinationPath, out errorMessage);
                        break;
                    case ".jpg":
                        byte[] imgJPGData = Conversion.BitmapToByte(new Bitmap(imgBox.Image), ImageFormat.Jpeg);
                        new Compressor().CustomCompressTiffImage(new Bitmap(imgBox.Image), destinationPath, out errorMessage);
                        break;
                    default:
                        break;
                }
                imgBox.Refresh();
                imgBox.SelectNone();
                lblImageCoordinates.Text = "X:0 Y:0 W:0 H:0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error:" + ex.Message, "Error on Front Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor.Current = Cursors.Default;
            //.Enabled = false;
        }

        private void SaveImage(Image img)
        {
            Counter++;
            string fileName = Counter.ToString().PadLeft(4, '0') + extension;
            ImageListVM selectedItem = new ImageListVM();
            switch (CurrentScanType)
            {
                case ScanType.Append:
                    if (Counter == 1)
                        Counter = 1;
                    //else
                    //    Counter++;
                    break;
                case ScanType.Before:
                    int selectedIndexBefor = lstImgBox.SelectedIndex;
                    selectedItem = lstImgBox.SelectedItem as ImageListVM;
                    if (selectedIndexBefor != 0 && !selectedItem.Name.Contains('_'))
                    {
                        lstImgBox.SelectedIndex = lstImgBox.SelectedIndex - 1;
                    }
                    else
                    {

                    }

                    selectedItem = lstImgBox.SelectedItem as ImageListVM;
                    fileName = Path.GetFileName(selectedItem.Path);
                    string newFileNameScanBefore = null;
                    string errorMessageScanBefore = null;

                    //newFileNameScanBefore = ScanImageInQueue(fileName, false, out errorMessageScanBefore);
                    if (selectedIndexBefor != 0)
                    {
                        newFileNameScanBefore = ScanImageInQueue(fileName, true, out errorMessageScanBefore);
                    }
                    else
                    {
                        newFileNameScanBefore = ScanImageInQueue(fileName, false, out errorMessageScanBefore);
                    }
                    if (string.IsNullOrEmpty(newFileNameScanBefore))
                    {
                        MessageBox.Show(this, errorMessageScanBefore, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    string destinationScanBefore = Path.Combine(lblGeneratedPath.Text, newFileNameScanBefore);
                    if (File.Exists(destinationScanBefore))
                    {
                        string message = "Image name mismatching. Kindly rename Next/Previous image first.";
                        MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    fileName = newFileNameScanBefore;
                    break;
                case ScanType.After:
                    selectedItem = lstImgBox.SelectedItem as ImageListVM;
                    fileName = Path.GetFileName(selectedItem.Path);
                    string newFileName = ScanImageInQueue(fileName, true, out string errorMessage);
                    if (string.IsNullOrEmpty(newFileName))
                    {
                        MessageBox.Show(this, errorMessage, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    string destination = Path.Combine(lblGeneratedPath.Text, newFileName);
                    if (File.Exists(destination))
                    {
                        string message = "Image name mismatching. Kindly rename Next/Previous image first or selecte the last series of image";
                        MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    fileName = newFileName;
                    break;
                case ScanType.Replace:
                    selectedItem = lstImgBox.SelectedItem as ImageListVM;
                    fileName = Path.GetFileName(selectedItem.Path);
                    break;
                default:
                    break;
            }

            string destinationPath = Path.Combine(lblGeneratedPath.Text, fileName);
            try
            {
                switch (cobOutputFormat.SelectedIndex)
                {
                    case 0: // jpg
                        SaveJPGImage(img, destinationPath.Replace(".tif", ".jpg"));

                        break;
                    case 1:// tiff
                        SaveTiffImage(img.ToStream(ImageFormat.Tiff), destinationPath.Replace(".jpg", ".tif"));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ImageFileList.Any(x => x.Name == Path.GetFileNameWithoutExtension(fileName)))
            {
                ImageFileList.Add(new ImageListVM
                {
                    Name = Path.GetFileNameWithoutExtension(destinationPath),
                    Path = destinationPath,
                });
            }
            int selectedIndex = lstImgBox.FindString(Path.GetFileNameWithoutExtension(fileName));
            if (selectedIndex == -1)
                lstImgBox.SelectedIndex = lstImgBox.Items.Count - 1;
            else
                lstImgBox.SelectedIndex = selectedIndex;

            lblPageCount.Text = Counter.ToString();
        }

        private string ScanImageInQueue(string fileName, bool IsAfter, out string errorMessage)
        {
            errorMessage = null;
            try
            {
                int series = 0;
                int counter = -1;
                string fileNameWithoutCounter = null;
                bool isNewInsertFile = false;

                if (fileName.Contains('_'))
                    isNewInsertFile = false;
                else
                    isNewInsertFile = true;

                if (!isNewInsertFile)
                {
                    string curentFileName = Path.GetFileNameWithoutExtension(fileName);
                    var array = curentFileName.Split(new char[] { '_' });
                    counter = Convert.ToInt32(array[1]);
                    fileNameWithoutCounter = array[0];
                }
                counter++;
                string newFileName = null;
                if (isNewInsertFile)
                {
                    newFileName = Path.GetFileNameWithoutExtension(fileName) + "_" + counter.ToString() + extension;
                }
                else
                {
                    newFileName = fileNameWithoutCounter + "_" + counter.ToString() + extension;
                }
                return newFileName;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        private void SaveTiffImage(Stream imgStream, string destination)
        {
            var stream = new FileStream(destination, FileMode.Create);
            var encoder = new System.Windows.Media.Imaging.TiffBitmapEncoder();
            encoder.Compression = TiffCompressOption.Ccitt4;
            encoder.Frames.Add(BitmapFrame.Create(imgStream));
            encoder.Save(stream);
            stream.Close();
        }

        private void SaveJPGImage(Image img, string destination)
        {
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters encoderParameters = new EncoderParameters(1);
            EncoderParameter encoderParameter = new EncoderParameter(encoder, 30L);
            encoderParameters.Param[0] = encoderParameter;
            try
            {
                img.Save(destination, jpgEncoder, encoderParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error on Image Saving.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void cobCasNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task<string> GetDestinatioPathAsync()
        {
            string caseType = String.Empty;
            string caseNumber = String.Empty;
            string caseYear = String.Empty;
            string currentDate = String.Empty;
            string departmentName = String.Empty;
            string barcode = String.Empty;
            if (string.IsNullOrEmpty(txtDepartmentName.Text) || string.IsNullOrEmpty(cobBarcode.Text))
            {
                return null;
            }
            switch (AppDetails.ID)
            {
                case 1:
                    {
                        // caseType = (cobCaseType.SelectedItem as DropDownHelper).Name.Replace('.', '-').Replace('/', '_');
                        departmentName = txtDepartmentName.Text;
                        barcode = cobBarcode.Text;
                        // currentDate = dbHelper.GetCurrentDatTime().ToString("dd-MM-yyyy");
                        currentDate = (await serverDateTimeHelper.GetCurrentDateTimeAsync()).ToString("dd-MM-yyyy");
                        return Path.Combine(new string[] {
                Settings.Default.DriveLetter+":\\",
                "Raw",
                currentDate,
                (departmentName+"_"+barcode),
                cobFileName.Text });
                    }
                    break;
                case 2:
                    if (cobFileName.Text != "")
                    {
                        //caseType = (cobCaseType.SelectedItem as DropDownHelper).Name.Replace('.', '-').Replace('/', '_');
                        caseNumber = txtCaseNo.Text;
                        caseYear = cobCaseYear.SelectedValue.ToString();
                        //currentDate = dbHelper.GetCurrentDatTime().ToString("dd-MM-yyyy");
                        return Path.Combine(new string[] {
                Settings.Default.DriveLetter+":\\",
                "Raw",
                currentDate,
                cobBarcode.Text,
                (caseYear+"_"+caseType+"_"+caseNumber),
               cobFileName.Text});
                    }
                    break;
                case 3:
                    //caseType = (cobCaseType.SelectedItem as DropDownHelper).Name.Replace('.', '-').Replace('/', '_');
                    caseNumber = txtCaseNo.Text;
                    caseYear = cobCaseYear.SelectedValue.ToString();
                    // currentDate = dbHelper.GetCurrentDatTime().ToString("dd-MM-yyyy");
                    return Path.Combine(new string[] {
                Settings.Default.DriveLetter+":\\",
                "Raw",
                currentDate,
                (caseYear+"_"+caseType+"_"+caseNumber),
                "CaseFile" });
                    break;
                case 4:
                    {
                        // caseType = (cobCaseType.SelectedItem as DropDownHelper).Name.Replace('.', '-').Replace('/', '_');
                        caseNumber = txtCaseNo.Text;
                        caseYear = cobCaseYear.SelectedValue.ToString();
                        // currentDate = dbHelper.GetCurrentDatTime().ToString("dd-MM-yyyy");
                        return Path.Combine(new string[] {
                Settings.Default.DriveLetter+":\\",
                "Raw",
                currentDate,
                (caseYear+"_"+caseType+"_"+caseNumber),
                "CaseFile" });
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        private int GetPageCount(string path)
        {
            return Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly)
                     .Where(x => x.EndsWith(".tif", StringComparison.OrdinalIgnoreCase)
                     || x.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase)
                     || x.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)).ToList().Count();
        }

        private void cobCaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int selectedCaseYear = Convert.ToInt32(cobCaseYear.SelectedValue);
            Cursor.Current = Cursors.Default;
        }

        private void cobCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int selectedCaseYear = Convert.ToInt32(cobCaseYear.SelectedValue);
            Cursor.Current = Cursors.Default;
        }

        private void lblGeneratedPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblGeneratedPath.Text))
            {
                Process.Start("explorer.exe", lblGeneratedPath.Text);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int selectedcobBarcode = cobBarcode.SelectedIndex;
            string topDirectory = String.Empty;

            if (cobFileName.Text == "")
            {
                MessageBox.Show("File Name not selected");
                return;
            }

            switch (AppDetails.ID)
            {
                case 1:
                    {
                        topDirectory = Path.GetDirectoryName(Path.GetDirectoryName(lblGeneratedPath.Text));
                    }
                    break;
                case 2:
                    {
                        topDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(lblGeneratedPath.Text)));
                    }
                    break;
                case 3:
                    {
                        topDirectory = Path.GetDirectoryName(Path.GetDirectoryName(lblGeneratedPath.Text));
                    }
                    break;
                case 4:
                    {
                        topDirectory = Path.GetDirectoryName(Path.GetDirectoryName(lblGeneratedPath.Text));
                    }
                    break;
                default:
                    break;
            }
            var directories = Directory.GetDirectories(topDirectory).ToList();
            int totalFoldersCount = directories.Count();

            int totalFilesCount = Directory.GetFiles(topDirectory, "*", SearchOption.AllDirectories)
                .Where(x => x.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .Count();

            if (totalFoldersCount == 0 || totalFilesCount == 0)
            {
                MessageBox.Show("There is 0 file count in the folder: " + Path.GetFileName(lblGeneratedPath.Text), Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dirDetails = await GetMainDirectory(topDirectory, totalFoldersCount, totalFilesCount);
            var dirResult = await DirectoryHelper.InsertUpdateDirectory(dirDetails);

            if (!dirResult.Item1)
            {
                MessageBox.Show(this, "'" + dirResult.Item3 + "'", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            #region  File Directory
            
            string fileDirectoryPath = Path.GetDirectoryName(lblGeneratedPath.Text);
            int subDirCount = Directory.GetDirectories(fileDirectoryPath).Count();
            var fileDirectoryObj = await GetCaseDirectory(fileDirectoryPath, dirResult.Item2.ID, subDirCount);
            var fileDirectoryResult = await CaseDirectoryHelper.InsertUpdateDirectory(fileDirectoryObj);
            if (!fileDirectoryResult.Item1)
            {
                MessageBox.Show(this, "Scan submit failed. Please conatct to system admin.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int fileDirID = fileDirectoryResult.Item2.ID;
            #endregion

            #region Sub Directory

            string subDirectoryPath = lblGeneratedPath.Text;
            var getSubDirectory = Directory.GetDirectories(fileDirectoryResult.Item2.Path, "*", SearchOption.TopDirectoryOnly);

            var subDirectoryObj = await GetSubDirectory(dirResult.Item2.ID, fileDirID, subDirectoryPath);
            var subDirectoryResult = await SubDirectoryHelper.InsertUpdateDirectory(subDirectoryObj);
            if (!subDirectoryResult.Item1)
            {
                MessageBox.Show(this, "Scan submit failed. Please conatct to system admin.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Image File Details
            List<ImageFileDetail> fileDetailsList = new List<ImageFileDetail>();

            int serialNo = 0;
            var currentDT = await serverDateTimeHelper.GetCurrentDateTimeAsync();
            var fileList = GetFileList(subDirectoryPath);
            foreach (var file in fileList)
            {
                serialNo++;
                Image img = Image.FromFile(file);
                float dpiX = img.HorizontalResolution;
                float dpiY = img.VerticalResolution;
                int width = img.Width;
                int height = img.Height;
                var imageDPI = Convert.ToInt32(dpiX);
                ImageFileDetail fileDetails = GetFileDetailsData(serialNo, file, dirResult.Item2.ID, fileDirectoryResult.Item2.ID, subDirectoryResult.Item2.ID, currentDT);
                await using var _db = await _dbContext.CreateDbContextAsync();
                _db.ImageFileDetails.Add(fileDetails);
                _db.SaveChanges();
            }


            #endregion

            await CheckBoxAndUpdateFileDetailAsync(fileDirID);

            MessageBox.Show(this, "Case No: " + txtCaseNo.Text + " submitted successfully!", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            //await UpdateCaseDetailsAsync();
           
            await LoadData();
           
            switch (AppDetails.ID)
            {
                case 1:
                    LoadBarcodes();
                    break;
                case 2:
                    break;
                case 3:
                    LoadBarcodes();
                    break;
                case 4:
                    LoadBarcodes();
                    break;
                default:
                    break;
            }
           
            lblGeneratedPath.Text = "";
            
            int selectedCaseYear = Convert.ToInt32(cobCaseYear.SelectedValue);
            
            ClearFields();
            
            btnSubmit.Enabled = false;

            cobBarcode.SelectedIndex = selectedcobBarcode;
            Cursor.Current = Cursors.Default;
            return;
        }

        private async Task<bool> CheckBoxAndUpdateFileDetailAsync(int fileDirID)
        {
            var fileDetailResponse = await new FileDetailHelper(_dbContext).CheckAndUpdateStatus(SelectedFileDetailID, fileDirID, Status.Scanned);
            if (fileDetailResponse.IsSuccess)
                return true;
            else
                return false;
        }

        private void ClearFields()
        {
            txtDepartmentName.Clear();
            txtFileNumber.Clear();
            txtAdvocate.Clear();
            txtDOD.Clear();
            txtDOR.Clear();
            txtNatureOfDisposal.Clear();
            txtAct.Clear();
            txtSection.Clear();
            // Reset selected file name and clear image list (match decompiled behavior)
            cobFileName.SelectedIndex = -1;
            ClearImageList();
        }

        // Add helper to clear image list and reset counters (from decompiled behavior)
        private void ClearImageList()
        {
            ImageFileList.Clear();
            LoadImageFiles(ImageFileList);
            lstImgBox.SelectedIndex = -1;
            Counter = 0;
        }

        private async Task UpdateCaseDetailsAsync()
        {
            //var selectedItem = cobBarcode.SelectedItem as DropDownHelper;
            // await CaseDetailHelper.CaseDetailsStatusUpdate(Status.Scan, Convert.ToInt32(cobBarcode.SelectedValue), AppUser.ID);
        }

        #region Private
        private async Task<DCSDirectory> GetMainDirectory(string path, int totalFoldersCount, int totalFilesCount)
        {
            return new DCSDirectory
            {
                Name = Path.GetFileName(path),
                SubDirectoryCount = totalFoldersCount,
                Path = path,
                CreatedBy = AppUser.ID,
                CreatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync(),
                FileCount = totalFilesCount
            };
        }

        private async Task<FileDirectory> GetCaseDirectory(string caseDirectory, int mainDirectoryID, int subDirectoryCount)
        {
            return new FileDirectory
            {
                DirectoryID = mainDirectoryID,
                FileDetailID = CaseDetailID,
                Name = Path.GetFileName(caseDirectory),
                Path = caseDirectory,
                SubDirectoryCount = subDirectoryCount,
                Status = Status.Scanned,
                Flag = Flag.None,
                ScanCreateBy = AppUser.ID,
                ScanCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync()
            };
        }

        //private ApplicationDbContext GetNewInstance()
        //{
        //    //return new ApplicationDbContext(
        //    //     Properties.Settings.Default.ServerName,
        //    //    Properties.Settings.Default.Database,
        //    //    Properties.Settings.Default.UID,
        //    //    Properties.Settings.Default.Password, false
        //    //     );

        //}

        private async Task<SubDirectory> GetSubDirectory(int mainDirectoryID, int caseDirectoryID, string subDirectory)
        {
            return new SubDirectory
            {
                //DirectoryID = mainDirectoryID,
                FileDirectoryID = caseDirectoryID,
                Name = Path.GetFileName(subDirectory),
                Path = subDirectory,
                FileCount = GetPageCount(subDirectory),
                Status = Status.Scanned,
                Flag = Flag.None,
                ScanCreateBy = AppUser.ID,
                ScanCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync()
            };
        }

        public List<string> GetFileList(string path)
        {
            List<string> files = Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                    .Where(x => x.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                    || x.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase)
                    || x.EndsWith(".tif", StringComparison.OrdinalIgnoreCase)).ToList();
            files.Sort(new DataSort());
            return files;
        }

        private ImageFileDetail GetFileDetailsData(int serialNo, string file, int directoryID, int caseDirectoryID, int subDirectoryID, DateTime currentDT)
        {
            var fileDetails = new ImageFileDetail
            {
                //DirectoryID = directoryID,
                //FileDirectoryID = caseDirectoryID,
                SubDirectoryID = subDirectoryID,
                SerialNo = serialNo,
                Path = file,
                DPI = 0,
                Dimensions = null,
                Size = null,
                PaperSize = null,
                Status = Status.Scanned,
                Flag = Flag.None,
                ScanCreateBy = AppUser.ID,
                ScanCreateDateTime = currentDT
            };
            return fileDetails;
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblGeneratedPath_DoubleClick(object sender, EventArgs e)
        {

        }

        private void spcScanData_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private async void GetSetCaseDetails(string barcode)
        {
            var fileDetail = FileDetailList.Where(x => x.Barcode == barcode).FirstOrDefault();
            if (fileDetail == null)
                return;
            SelectedFileDetailID = fileDetail.ID;
            CaseDetailID = fileDetail.ID;
            txtCaseTitle.Text = fileDetail.CaseTitle;
            txtCaseNo.Text = fileDetail.CaseNo;
            cobCaseYear.Text = fileDetail.CaseYear;
            txtDepartmentName.Text = fileDetail.Department.Name;
            txtFileNumber.Text = fileDetail.FileNumber;

        }

        private void cobBarcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            GetSetCaseDetails(cobBarcode.Text);
        }

        private void spcMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private async void cobFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AppDetails.ID)
            {
                case 1:
                    Cursor.Current = Cursors.WaitCursor;
                    string GeneratedPath = await GetDestinatioPathAsync();
                    //string selectedCaseNumber = (cobCaseNumber.SelectedItem as DropDownHelper).Name;
                    //if (string.IsNullOrEmpty(txtCaseNo.Text))
                    //    return;
                    GetSetCaseDetails(cobBarcode.Text);

                    if (string.IsNullOrEmpty(GeneratedPath))
                    {
                        return;
                    }
                    try
                    {
                        Directory.CreateDirectory(GeneratedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lblGeneratedPath.Text = GeneratedPath;
                    RefreshImageList(lblGeneratedPath.Text);
                    Counter = GetPageCount(GeneratedPath);

                    if (!Directory.Exists(GeneratedPath))
                    {
                        MessageBox.Show(this, "There is issue to create folder in server.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lblPageCount.Text = Counter.ToString();
                    // await LoadFileNameAsync();
                    Cursor.Current = Cursors.Default;
                    break;
                    break;
                case 2:
                    Cursor.Current = Cursors.WaitCursor;
                    //string GeneratedPath = GetDestinatioPath();
                    //string selectedCaseNumber = (cobCaseNumber.SelectedItem as DropDownHelper).Name;
                    //if (string.IsNullOrEmpty(txtCaseNo.Text))
                    //    return;
                    GetSetCaseDetails(cobBarcode.Text);

                    //if (string.IsNullOrEmpty(GeneratedPath))
                    //{
                    //    return;
                    //}
                    //try
                    //{
                    //    Directory.CreateDirectory(GeneratedPath);
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    //lblGeneratedPath.Text = GeneratedPath;
                    //RefreshImageList(lblGeneratedPath.Text);
                    //Counter = GetPageCount(GeneratedPath);

                    //if (!Directory.Exists(GeneratedPath))
                    //{
                    //    MessageBox.Show(this, "There is issue to create folder in server.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    lblPageCount.Text = Counter.ToString();
                    // await LoadFileNameAsync();
                    Cursor.Current = Cursors.Default;
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }

            // Enable submit only if there are images in list
            btnSubmit.Enabled = lstImgBox.Items.Count > 0;
        }

        private void RefreshImageList(string currentPath)
        {
            var existingFiles = Files.GetImageList(currentPath, SearchOption.TopDirectoryOnly);
            if (existingFiles.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                ImageFileList.Clear();
                foreach (var file in existingFiles)
                {
                    ImageFileList.Add(new ImageListVM
                    {
                        Name = Path.GetFileNameWithoutExtension(file),
                        Path = file
                    });
                }
                LoadImageFiles(ImageFileList);
                Counter = existingFiles.Count() + 1;
                lstImgBox.SelectedIndex = existingFiles.Count() - 1;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                ImageFileList.Clear();
                LoadImageFiles(ImageFileList);
                lstImgBox.SelectedIndex = -1;
                Counter = 0;
            }
        }

        private void LoadImageFiles(BindingList<ImageListVM> imagefiles)
        {
            lstImgBox.SelectedIndexChanged -= lstImgBox_SelectedIndexChanged;
            lstImgBox.DataSource = null;
            lstImgBox.DataSource = imagefiles;
            lstImgBox.DisplayMember = "Name";
            lstImgBox.ValueMember = "Path";
            lstImgBox.SelectedIndex = -1;
            lstImgBox.SelectedIndexChanged += lstImgBox_SelectedIndexChanged;
        }

        private void lstImgBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImgBox.SelectedValue == null)
            {
                imgBox.Image = null;
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            DisplayRecordNumbers("");
            DisplayImage(GetCurrentImagePath(lstImgBox.SelectedValue.ToString()));
            lblPageCount.Text = (Files.GetImageCount(lblGeneratedPath.Text, SearchOption.TopDirectoryOnly)).ToString();
            Cursor.Current = Cursors.Default;
        }

        private string GetCurrentImagePath(string path)
        {
            var imgPath = ImageFileList.Where(x => x.Path == path).Select(x => x.Path).FirstOrDefault();
            return imgPath;
        }

        private void DisplayRecordNumbers(string strText)
        {
            int nPos = lstImgBox.SelectedIndex;
            nPos++;
            lblImagePosition.Text = " Page:   " + nPos.ToString() + " of  " + lstImgBox.Items.Count.ToString() + " " + strText;
        }

        private void DisplayImage(string imgPath)
        {
            try
            {
                if (string.IsNullOrEmpty(imgPath))
                {
                    MessageBox.Show(this, "There is no image found in record.", "Image not Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(imgPath)))
                {
                    imgBox.Image = null;
                    imgBox.SelectionColor = Color.RoyalBlue;
                    imgBox.Image = Bitmap.FromStream(ms);
                    imgBox.ZoomToFit();

                    imgBox.Refresh();
                    //ZoomLevelChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error on Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //UndoStack.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        #region Navigation
        private void First()
        {
            lstImgBox.SelectedIndex = 0;
            EnableDisableButtons(btnNext, btnLast, true);
            EnableDisableButtons(btnFirst, btnPrevious, false);
            DisplayRecordNumbers("First Sheet...");
        }

        private void Next()
        {
            if (lstImgBox.SelectedIndex < lstImgBox.Items.Count - 1)
            {
                lstImgBox.SelectedIndex = lstImgBox.SelectedIndex + 1;
                EnableDisableButtons(btnFirst, btnPrevious, true);
                DisplayRecordNumbers("");
            }
            else
            {
                EnableDisableButtons(btnNext, btnLast, true);
                DisplayRecordNumbers("End of record...");
            }
        }

        private void Previous()
        {
            if (lstImgBox.SelectedIndex > 0)
            {
                lstImgBox.SelectedIndex = lstImgBox.SelectedIndex - 1;
                EnableDisableButtons(btnNext, btnLast, true);
                DisplayRecordNumbers("");
            }
            else
            {
                EnableDisableButtons(btnFirst, btnPrevious, false);
                DisplayRecordNumbers("Beginning of Sheet...");
            }
        }

        private void Last()
        {
            lstImgBox.SelectedIndex = lstImgBox.Items.Count - 1;
            EnableDisableButtons(btnNext, btnLast, false);
            EnableDisableButtons(btnFirst, btnPrevious, true);
            DisplayRecordNumbers("Last Sheet...");
        }

        private void EnableDisableButtons(ToolStripButton button1, ToolStripButton button2, bool v)
        {
            button1.Enabled = v;
            button2.Enabled = v;
        }
        #endregion

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            First();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Last();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            imgBox.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            imgBox.ZoomOut();
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            imgBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            imgBox.Refresh();
            SaveImage();
            //SaveImage(imgBox.Image);
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            imgBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            imgBox.Refresh();
            SaveImage();
        }

        private void btnFrontZoomToFit_Click(object sender, EventArgs e)
        {
            imgBox.ZoomToFit();
        }

        private void btnFrontActualSize_Click(object sender, EventArgs e)
        {
            imgBox.ActualSize();
        }

        private void btnDeskew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            imgBox.Image = new ImageDeskew(new Bitmap(imgBox.Image)).Deskew(false);
            imgBox.ZoomToFit();
            imgBox.Refresh();
            SaveImage();
            Cursor.Current = Cursors.Default;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string errorMessage = null;
            if (FrontRectangle != RectangleF.Empty)
            {
                if (!CropFrontImage(out errorMessage))
                {
                    MessageBox.Show(this, "Error:" + errorMessage, "Error on Front Crop Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private bool CropFrontImage(out string errorMessage)
        {
            try
            {
                int width = imgBox.Image.Width;
                int height = imgBox.Image.Height;
                Imaging imaging = new Imaging(Conversion.TiffImageToByteArray(new Bitmap(imgBox.Image), ImageFormat.Jpeg));
                imgBox.Image = null;
                imgBox.Image = Conversion.ByteArrayToImage(imaging.CropImage(FrontRectangle), width, height);
                btnSave.Enabled = true;
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.R:
                    btnRotateRight.PerformClick();
                    return true;

                case Keys.Control | Keys.L:
                    btnRotateLeft.PerformClick();
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            imgBox.Image = null;
            imgBox.Image = Image.FromFile(GetCurrentImagePath(lstImgBox.SelectedValue.ToString()));
            imgBox.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage(new Bitmap(imgBox.Image));
            Next();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            var gotonNo = Convert.ToInt32(txtGoto.Text);
            if (lstImgBox.Items.Count >= gotonNo && gotonNo != 0)
            {
                lstImgBox.SelectedIndex = gotonNo - 1;
            }
            else
            {
                MessageBox.Show(this, "No image found in this position.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void cobZoomLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZoomLevelChanged();
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (imgBox.IsSelecting)
            {
                FrontRectangle = imgBox.SelectionRegion;
                lblImageCoordinates.Text = new FormatHelper().FormatRectangle(FrontRectangle);
                statusStrip1.Refresh();
            }
        }

        private void menDelete_Click(object sender, EventArgs e)
        {
            if (lstImgBox.SelectedIndex == -1)
            {
                return;
            }
            int selectedIndex = lstImgBox.SelectedIndex;
            var selectedItem = lstImgBox.SelectedItem as ImageListVM;
            var result = MessageBox.Show(this, "Are you sure? want to delete the image: " + selectedItem.Name, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == result)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (DeleteFile(selectedItem, selectedIndex))
                {
                    MessageBox.Show(this, "Image: " + Path.GetFileNameWithoutExtension(selectedItem.Path) + " deleted successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Cursor.Current = Cursors.Default;
            }

            //if (lstImgBox.SelectedIndex == -1)
            //{
            //    return;
            //}
            //int selectedIndex = lstImgBox.SelectedIndex;
            //var selectedItem = lstImgBox.SelectedItem as ImageListVM;
            //var result = MessageBox.Show(this, "Are you sure? want to delete the image: " + selectedItem.Name, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (DialogResult.Yes == result)
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    if (File.Exists(selectedItem.Path))
            //    {
            //        try
            //        {
            //            File.Delete(selectedItem.Path);
            //            Cursor.Current = Cursors.Default;
            //        }
            //        catch (Exception ex)
            //        {
            //            Cursor.Current = Cursors.Default;
            //            MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        Cursor.Current = Cursors.Default;
            //        MessageBox.Show(this, "Image: " + Path.GetFileNameWithoutExtension(selectedItem.Path) + " deleted successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        RefreshImageList(lblGeneratedPath.Text);
            //        if (lstImgBox.Items.Count > 0)
            //        {
            //            lstImgBox.SelectedIndex = selectedIndex;
            //        }
            //        else
            //        {
            //            lstImgBox.SelectedIndex = -1;
            //        }
            //    }
            //}
        }

        private void DeleteSelectedFiles()
        {
            if (lstImgBox.CheckedItems.Count < 2)
            {
                MessageBox.Show(this, "Please select atleast more than 1 file.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            List<ImageListVM> CheckedItems = new List<ImageListVM>();
            var selectedItems = lstImgBox.CheckedItems;
            int selectedIndex = lstImgBox.SelectedIndex;

            foreach (var item in selectedItems)
            {
                CheckedItems.Add(item as ImageListVM);
            }
            string fileNames = string.Join(',', CheckedItems.Select(x => x.Name).ToList());

            var result = MessageBox.Show(this, "Are you sure? want to delete the images: " + fileNames, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == result)
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (var item in CheckedItems)
                {
                    DeleteFile(item, selectedIndex);
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, "Images: " + fileNames + " deleted successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool DeleteFile(ImageListVM selectedItem, int selectedIndex)
        {
            if (File.Exists(selectedItem.Path))
            {
                try
                {
                    imgBox.Image = null;
                    File.Delete(selectedItem.Path);
                    ImageFileList.Remove(selectedItem);
                    lstImgBox.Refresh();
                    if (lstImgBox.Items.Count > 0)
                    {
                        if (lstImgBox.Items.Count - 1 >= selectedIndex)
                        {
                            lstImgBox.SelectedIndex = selectedIndex;
                            DisplayImage(GetCurrentImagePath(lstImgBox.SelectedValue.ToString()));
                        }
                    }
                    else
                    {
                        lstImgBox.SelectedIndex = -1;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // Cursor.Current = Cursors.Default;
                    MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //RefreshImageList(lblGeneratedPath.Text);

            }
            else
            {
                return false;
            }
        }

        private void lstImgBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void lstImgBox_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    lstImgBox.SelectedIndex = lstImgBox.IndexFromPoint(e.Location);
            //    if (lstImgBox.SelectedIndex != -1)
            //    {
            //        imgQueueContectMenu.Show();
            //    }
            //}
            if (e.Button == MouseButtons.Right)
            {
                lstImgBox.SelectedIndex = lstImgBox.IndexFromPoint(e.Location);
                if (lstImgBox.SelectedIndex != -1)
                {
                    if (lstImgBox.CheckedItems.Count > 1)
                    {
                        menDeleteSelected.Enabled = true;
                    }
                    else
                    {
                        menDeleteSelected.Enabled = false;
                    }
                    imgQueueContectMenu.Show();
                }
            }
        }

        private void cobOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cobOutputFormat.SelectedIndex)
            {
                case 0:
                    extension = ".jpg";
                    break;
                case 1:
                    extension = ".tif";
                    break;
                default:
                    break;
            }
        }

        private void menScanAfter_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentScanType = ScanType.After;
                if (_twain.CurrentSource == null)
                {
                    btnSources.ShowDropDown();
                    return;
                }
                StartScanning();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void menScanBefore_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentScanType = ScanType.Before;
                if (_twain.CurrentSource == null)
                {
                    btnSources.ShowDropDown();
                    return;
                }
                StartScanning();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void menReplaceScan_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentScanType = ScanType.Replace;
                if (_twain.CurrentSource.Version == null)
                {
                    btnSources.ShowDropDown();
                    return;
                }
                StartScanning();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void menScanNewPage_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentScanType = ScanType.Append;
                if (_twain.CurrentSource == null)
                {
                    btnSources.ShowDropDown();
                    return;
                }

                StartScanning();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void menDeleteSelected_Click(object sender, EventArgs e)
        {
            if (lstImgBox.CheckedItems.Count > 1)
                DeleteSelectedFiles();
            else menDeleteSelected.Enabled = false;
        }

        private void frmScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                btnRotateRight.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                btnRotateLeft.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.Delete)
            {
                DeleteSelectedFiles();
            }
            else if (e.Shift && e.KeyCode == Keys.D)
            {
                btnDeskew.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.C)
            {
                btnCrop.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.S)
            {
                menScanNewPage.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.A)
            {
                menScanAfter.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.B)
            {
                menScanBefore.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.R)
            {
                menReplaceScan.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.Delete)
            {
                DeleteSelectedFiles();
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        btnZoomIn.PerformClick();
                        break;
                    case Keys.Subtract:
                        btnZoomOut.PerformClick();
                        break;
                    case Keys.F5:
                        btnRefresh.PerformClick();
                        break;
                    case Keys.Left:
                        Previous();
                        break;
                    case Keys.Right:
                        Next();
                        break;
                    case Keys.Up:
                        First();
                        break;
                    case Keys.Down:
                        Last();
                        break;
                    case Keys.Delete:
                        menDelete_Click(null, null);
                        break;
                    case Keys.Space:
                        btnStartCapture.PerformClick();
                        break;
                    case Keys.End:
                        btnStopScan.PerformClick();
                        break;
                    default:
                        break;
                }
            }
        }

        private void menCut_Click(object sender, EventArgs e)
        {

        }
    }
    public static class ExtensionMethods
    {
        #region Extension Method
        public static Stream ToStream(this Image image, ImageFormat format)
        {
            try
            {
                var stream = new System.IO.MemoryStream();
                image.Save(stream, format);
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion
    }
}
