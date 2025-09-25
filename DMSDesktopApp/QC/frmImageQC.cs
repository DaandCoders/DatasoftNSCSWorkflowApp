using AForge.Imaging.Filters;
using DC.DMS.Services.Property;
using DC.DMS.Services.ViewModels;
using DC.ImagUtility.Q16.Services;
using DC.Process;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using DMS.DesktopApp.QC;
using DMSDesktopApp.Shared;
using ImageMagick;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Miscellaneous;
using OpenCvSharp;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Drawing.Imaging;
using System.Reflection;
using UKA.Windows.Forms;
using Validation;
using static DC.DMS.Services.Enum.WorkflowEnums;
using Point = System.Drawing.Point;

namespace DMS.DesktopApp.Shared
{
    public partial class frmImageQC : Form
    {
        #region Fields
        private int MainDirectoryID = 0;
        private int FileStatusID;
        private int CourtID = 0;
        char[] seprator = { ',' };
        private int counter = 0;
        readonly Stack<Bitmap> UndoStack = new Stack<Bitmap>();

        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;

        RectangleF FrontRectangle;
        ServerDateTimeHelper serverDateTimeHelper;
        DirectoryHelper DirectoryHelper;
        FileDetailHelper FileDetailsHelper;
        MainDataHelper FileSaveHelper;

        BindingList<ImageFileVM> ImageFileList;
        //List<ImageFileVM> FileList;
        //List<FileDirectoryVM> FileDirectoryList;
        //List<SubDirectoryVM> SubDirectoryList;

        //List<DropDownHelper> AllFiles;

        DropDownHelper SelectedFileDirectoryItem;
        DropDownHelper SelectedSubDirectoryItem;
        private int? SelectedIndex = null;

        #endregion
        public frmImageQC(int directoryID, IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            MainDirectoryID = directoryID;
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            DirectoryHelper = new DirectoryHelper(_dbContext, _cache, _translationService);

            CourtID = 0;
            FileStatusID = 0;
            FileSaveHelper = new MainDataHelper(_dbContext, _cache, _translationService);
            ImageFileList = new BindingList<ImageFileVM>();
        }

        private async void frmApplicationForm_LoadAsync(object sender, EventArgs e)
        {
            this.Text = this.Text + " " + String.Format("Version {0}", AssemblyVersion);
            lblCurrentUserName.Text = AppUser.CurrentUserName;
            FillZoomLevels();
            imgBox.ZoomIn();
            cobZoomLevel.SelectedIndex = cobZoomLevel.FindStringExact("20%");
            await LoadFiles();

        }

        private async Task<bool> LoadImageList(int fileDirectoryID, int subDirectoryID)
        {
            var imageFileList = await new ImageFileDetailHelper(_dbContext, _cache, _translationService).GetImageFiles(subDirectoryID, CallingFor.QC);

            ImageFileList = imageFileList.ToBindingList();
            if (ImageFileList.Count > 0)
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.DataSource = ImageFileList;
                lstImages.DisplayMember = "Name";
                lstImages.ValueMember = "ID";
                lstImages.SelectedIndex = -1;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
                lstImages.SelectedIndex = 0;

            }
            else
            {
                ClearImageList();
            }
            lstImages.Refresh();
            return true;
        }

        private async void RefreshImageList(List<ImageFileVM> imageFiles)
        {
            ImageFileList.Clear();
            ImageFileList = imageFiles.ToBindingList();

            if (ImageFileList.Count > 0)
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.DataSource = ImageFileList;
                lstImages.DisplayMember = "Name";
                lstImages.ValueMember = "ID";
                lstImages.SelectedIndex = -1;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
                lstImages.SelectedIndex = 0;
            }
            else
            {
                ClearImageList();
            }

            lstImages.Refresh();
        }
        private async Task<bool> LoadSubFiles(int subDirectoryID)
        {
            var subDirectories = await new SubDirectoryHelper(_dbContext, _cache, _translationService).GetSubDirectoriesList(SelectedFileDirectoryItem.ID, CallingFor.QC);
            if (subDirectories.Count > 0)
            {
                cobSubFiles.SelectedIndexChanged -= cobSubDicrectoy_SelectedIndexChanged;
                cobSubFiles.DataSource = null;
                cobSubFiles.DataSource = subDirectories;
                cobSubFiles.DisplayMember = "Name";
                cobSubFiles.ValueMember = "ID";
                cobSubFiles.SelectedIndex = -1;
                cobSubFiles.SelectedIndexChanged += cobSubDicrectoy_SelectedIndexChanged;
                cobSubFiles.SelectedIndex = 0;

            }
            else
            {
                ClearSubDirectoryList();
                ClearImageList();
            }
            return true;
        }

        private async Task<bool> LoadFiles()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            List<DropDownHelper> allFiles = await new FileDirectoryHelper(_dbContext, _cache, _translationService)
                .GetFileDirectories(MainDirectoryID, CallingFor.QC);
            if (allFiles.Count > 0)
            {
                cobFiles.SelectedIndexChanged -= cobFile_SelectedIndexChanged;
                cobFiles.DataSource = null;
                cobFiles.DataSource = allFiles;
                cobFiles.DisplayMember = "Name";
                cobFiles.ValueMember = "ID";
                cobFiles.SelectedIndex = -1;
                cobFiles.SelectedIndexChanged += cobFile_SelectedIndexChanged;
                cobFiles.SelectedIndex = 0;
            }
            else
            {
                cobFiles.SelectedIndexChanged -= cobFile_SelectedIndexChanged;
                cobFiles.DataSource = null;
                cobFiles.SelectedIndex = -1;
                cobFiles.SelectedIndexChanged += cobFile_SelectedIndexChanged;

                ClearSubDirectoryList();
                ClearImageList();
            }
            return true;
        }

        private void ClearSubDirectoryList()
        {
            cobSubFiles.SelectedIndexChanged -= cobSubDicrectoy_SelectedIndexChanged;
            cobSubFiles.DataSource = null;
            cobSubFiles.SelectedIndex = -1;
            cobSubFiles.SelectedIndexChanged += cobSubDicrectoy_SelectedIndexChanged;
        }

        private void ClearImageList()
        {
            lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
            lstImages.DataSource = null;
            lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;

            imgBox.Image = null;
        }

        private string GetCurrentImagePath(int id)
        {
            var imgPath = ImageFileList.Where(x => x.ID == id).Select(x => x.Path).FirstOrDefault();
            if (chkImagesRaw.Checked == true)
            {
                imgPath = GetRawPath(imgPath);
            }
            else
            {
                imgPath = GetCleanPath(imgPath);

            }
            return imgPath;
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private async void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int currentID = Convert.ToInt32(lstImages.SelectedValue);

            if (lstImages.SelectedValue == null)
                return;
            DisplayRecordNumbers("");
            DisplayImage(GetCurrentImagePath(Convert.ToInt32(lstImages.SelectedValue)));
            Cursor = Cursors.Default;
        }

        private void Reset()
        {
            imgBox.Refresh();
            imgBox.SelectNone();
            lblImageCoordinates.Text = "X:0 Y:0 W:0 H:0";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            //string message = string.Format("Are sure you want to delete the image {0}?", lstImages.Text);
            //if (MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //{
            //    return;
            //}

            //Cursor = Cursors.WaitCursor;

            //int selectedFileID = Convert.ToInt32(lstImages.SelectedValue);
            //int deleteIndexPosition = lstImages.SelectedIndex;
            //string cleanImage = lblCurrentImagePath.Text.Replace("Raw", "Clean");

            //using (var waitForm = new PleaseWaitForm())
            //{
            //    waitForm.Show(this);
            //    Application.DoEvents();
            //    try
            //    {
            //        ImageFileList.RemoveAt(deleteIndexPosition);
            //        await new FileDetailsHelper(_dbContext).OnDeleteUpdateImageListAsync(selectedFileID, ImageFileList.ToList(), AppUser.ID);
            //        await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            //    }
            //    finally
            //    {
            //        waitForm.Close();
            //    }
            //}

            //if (File.Exists(cleanImage))
            //{
            //    File.Delete(cleanImage);
            //}
            //Cursor = Cursors.Default;

            //if (deleteIndexPosition + 1 >= lstImages.Items.Count)
            //{
            //    lstImages.SelectedIndex = lstImages.Items.Count - 1;
            //}
            //else
            //{
            //    lstImages.SelectedIndex = deleteIndexPosition;
            //}
        }

        private async Task RunWithWaitForm(Func<Task> action)
        {
            using (var waitForm = new PleaseWaitForm())
            {
                var showTask = Task.Run(() => waitForm.Show(this));
                await action();
                waitForm.Invoke(new Action(() => waitForm.Close()));
                await showTask;
            }
        }

        private void btnFrontZoomIn_Click(object sender, EventArgs e)
        {
            imgBox.ZoomIn();
        }

        private void btnFrontZommOut_Click(object sender, EventArgs e)
        {
            imgBox.ZoomOut();
        }

        private async void btnFrontRotateLeft_ClickAsync(object sender, EventArgs e)
        {
            imgBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            imgBox.Refresh();
            int currentID = Convert.ToInt32(lstImages.SelectedValue);
            SaveImageAsync();
        }

        private async void btnFrontRotateRight_ClickAsync(object sender, EventArgs e)
        {
            imgBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            imgBox.Refresh();
            int currentID = Convert.ToInt32(lstImages.SelectedValue);
            SaveImageAsync();
        }

        private void btnFrontZoomToFit_Click(object sender, EventArgs e)
        {
            imgBox.ZoomToFit();
        }

        private void btnFrontActualSize_Click(object sender, EventArgs e)
        {
            imgBox.ActualSize();
        }

        private void btnFronDeskew_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            imgBox.Image = new ImageDeskew(new Bitmap(imgBox.Image)).Deskew(false);
            imgBox.ZoomToFit();
            imgBox.Refresh();
            Cursor = Cursors.Default;
        }

        private void btnFrontCrop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string errorMessage = null;
            if (FrontRectangle != RectangleF.Empty)
            {
                if (!CropFrontImage(out errorMessage))
                {
                    MessageBox.Show(this, "Error:" + errorMessage, "Error on Front Crop Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Cursor = Cursors.Default;
        }

        private bool CropFrontImage(out string errorMessage)
        {
            try
            {
                int width = imgBox.Image.Width;
                int height = imgBox.Image.Height;
                Imaging imaging = new Imaging(Conversion.TiffImageToByteArray(new Bitmap(imgBox.Image), System.Drawing.Imaging.ImageFormat.Jpeg));
                imgBox.Image = null;
                imgBox.Image = Conversion.ByteArrayToImage(imaging.CropImage(FrontRectangle), width, height);
                btnFrontSave.Enabled = true;
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private async void btnFrontSave_ClickAsync(object sender, EventArgs e)
        {
            int currentID = Convert.ToInt32(lstImages.SelectedValue);
            SaveImageAsync();
            Reset();
            Next();
        }
        private async void SaveImageAsync()
        {
            if (imgBox.Image == null)
                return;
            Cursor = Cursors.WaitCursor;
            Compressor imgCompressor = new Compressor();
            try
            {
                string errorMessage = null;
                string fileName = Path.GetFileName(lblCurrentImagePath.Text);
                string extension = Path.GetExtension(lblCurrentImagePath.Text);
                string path = Path.GetDirectoryName(lblCurrentImagePath.Text).Replace("Raw", "Clean");
                Directory.CreateDirectory(path);
                string destinationPath = Path.Combine(path, fileName);

                switch (extension)
                {
                    case ".tif":
                    case ".tiff":
                        new Compressor().CustomCompressTiffImage(new Bitmap(imgBox.Image), destinationPath, out errorMessage);
                        break;
                    case ".jpg":
                        imgCompressor.JPEGCompression(Conversion.ImageToByteArray(new Bitmap(imgBox.Image)), 300, destinationPath.Replace(".tif", ".jpg"), out errorMessage);
                        break;
                    default:
                        break;
                }
                lblImageCoordinates.Text = "X:0 Y:0 W:0 H:0";
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(this, "Error:" + ex.Message, "Error on Front Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor = Cursors.Default;
        }


        private void CopyImage(string imgPath)
        {
            Cursor = Cursors.WaitCursor;
            string destination = Path.GetDirectoryName(imgPath).Replace("Raw", "Clean");
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            string destinationPath = imgPath.Replace("Raw", "Clean");
            if (!File.Exists(destinationPath))
            {
                File.Copy(imgPath, destinationPath, true);
            }
            Cursor = Cursors.Default;
        }
        private async Task<bool> SaveFileDetail(int id)
        {

            return await new FileDetailHelper(_dbContext).UpdateImageDT(id, AppUser.ID);
        }
        private async Task<bool> FileComplete()
        {
            try
            {
                if (SelectedSubDirectoryItem == null)
                    return false;
                return await DirectoryHelper.SubDirectoryQCCompleted(SelectedSubDirectoryItem.ID, AppUser.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error:" + ex.Message, "Error on Front Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnFrontRefresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            imgBox.Image = null;
            imgBox.Image = Image.FromFile(lblCurrentImagePath.Text);
            imgBox.Refresh();
            Cursor = Cursors.Default;
        }

        private void frmApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (cobFiles.Items.Count != 0)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Are you sure? you want to close the QC form.", "Application Form Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        if (!IsBatchComplete())
            //        {
            //            db.Update("Update vehicleinfo set status='BL' where ID='" + VehicleID + "'");
            //        }
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private async void btnInsert_ClickAsync(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int maxCount = ImageFileList.Count();
            int selectedIndex = lstImages.SelectedIndex + 1;
            string curentDirectoryPath = GetCurrentSelectFolderPath();
            frmMultiImageInsert frmInsert = new frmMultiImageInsert(curentDirectoryPath, _cache, _translationService);
            frmInsert.numPosition.Minimum = 1;
            frmInsert.numPosition.Maximum = maxCount + 1;

            var result = frmInsert.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            int counter = 0;
            foreach (var imgPath in frmInsert.ImagePath)
            {
                string newImagePath = imgPath;
                int newIndexPosition = selectedIndex;
                counter++;
                var newFileDetails = new ImageFileVM
                {
                    //ID = 0,
                    DirectoryID = MainDirectoryID,
                    FileDirectoryID = GetCurrentSelectedCaseDirectoryID(),
                    SubDirectoryID = GetCurrentSelectedSubDirectoryID(),
                    Name = Path.GetFileNameWithoutExtension(newImagePath),
                    Path = newImagePath
                };
                ImageFileList.Insert(newIndexPosition, newFileDetails);


                await new FileDetailHelper(_dbContext).UpdateImageListAsync(SelectedSubDirectoryItem.ID, ImageFileList.ToList(), AppUser.ID);

                await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            }
            counter = 0;

            Cursor = Cursors.Default;
        }

        private string GetCurrentSelectFolderPath()
        {
            return Path.GetDirectoryName(lblCurrentImagePath.Text);
        }

        private int GetCurrentSelectedSubDirectoryID()
        {
            return Convert.ToInt32(cobSubFiles.SelectedValue);
        }

        private int GetCurrentSelectedCaseDirectoryID()
        {
            return Convert.ToInt32(cobFiles.SelectedValue);
        }

        private void InsertRawData(string path, int serialNo)
        {

        }
        private void ReSerialize(int newSerialNo, int oldSerialNo, string rawID)
        {


        }
        private void CheckAndReSerialize(int serialNo)
        {

        }

        private void DeleteImageCheckAndReSerialize(int rawID, int serialno)
        {

        }

        private void lstImages_Click(object sender, EventArgs e)
        {

        }


        private void btnQCDone_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            First();
        }

        private void EnableDisableButtons(ToolStripButton button1, ToolStripButton button2, bool v)
        {
            button1.Enabled = v;
            button2.Enabled = v;
        }

        private async void imgBoxFront_MouseUp(object sender, MouseEventArgs e)
        {
            if (btnErase.Checked)
            {
                var Rectangle = imgBox.SelectionRegion;
                Cursor = Cursors.WaitCursor;
                var bitmap = new Bitmap(imgBox.Image);
                UndoStack.Push(new Bitmap(imgBox.Image));
                var rect = new Rectangle((int)Rectangle.X, (int)Rectangle.Y, (int)Rectangle.Width, (int)Rectangle.Height);
                var color = ColorTranslator.FromHtml(Settings.Default.CleanColor);

                CanvasFill filter = new CanvasFill(rect, color);
                filter.ApplyInPlace(bitmap);
                DisplayBitmap(bitmap);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Cursor = Cursors.Default;
            }

            if (imgBox.IsSelecting)
            {
                FrontRectangle = imgBox.SelectionRegion;
                lblImageCoordinates.Text = new FormatHelper().FormatRectangle(FrontRectangle);
                statusStripBottom.Refresh();
            }
        }

        private void Undo()
        {
            if (UndoStack.Count > 0)
            {
                var undoBitmap = new Bitmap(UndoStack.Pop());
                DisplayBitmap(undoBitmap);
            }
            else
            {
                MessageBox.Show("Nothing for undo", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #region Event Functions

        private void TextEnter(object sender, EventArgs e)
        {
            //MetroAppColor.TextBoxEnter((MetroTextBox)sender);
        }

        private void TextLeave(object sender, EventArgs e)
        {
            // MetroAppColor.TextBoxLeave((MetroTextBox)sender);
            //sender = MetroFramework.MetroTextBoxWeight.Regular;
        }

        #endregion

        #region Navigation
        private void First()
        {
            lstImages.SelectedIndex = 0;
            EnableDisableButtons(btnNext, btnLast, true);
            EnableDisableButtons(btnFirst, btnPrevious, false);
            DisplayRecordNumbers("First Sheet...");
        }

        private void Next()
        {
            if (lstImages.SelectedIndex < lstImages.Items.Count - 1)
            {
                lstImages.SelectedIndex = lstImages.SelectedIndex + 1;
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
            if (lstImages.SelectedIndex > 0)
            {
                lstImages.SelectedIndex = lstImages.SelectedIndex - 1;
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
            lstImages.SelectedIndex = lstImages.Items.Count - 1;
            EnableDisableButtons(btnNext, btnLast, false);
            EnableDisableButtons(btnFirst, btnPrevious, true);
            DisplayRecordNumbers("Last Sheet...");
        }
        #endregion

        #region Highlighter
        private void ComboBox_Enter(object sender, EventArgs e)
        {
            // MetroAppColor.ComboBoxEnter((MetroComboBox)sender);
        }

        private void ComboBox_Leave(object sender, EventArgs e)
        {
            // MetroAppColor.ComboBoxLeave((MetroComboBox)sender);
        }
        #endregion

        #region Load

        private void OptionEnable(bool v)
        {
            btnNext.Enabled = v;
            btnPrevious.Enabled = v;
            btnFirst.Enabled = v;
            btnLast.Enabled = v;
            //btnInsert.Enabled = v;
            btnFilesComplete.Enabled = v;
            //btnDeleteRecord.Enabled = v;
            btnSubFileComplete.Enabled = v;
            tspFrontImage.Enabled = v;
        }

        private void LoadSerialNo()
        {

        }

        private void LoadDocumentType()
        {
        }

        private void LoadLocation()
        {
        }

        private void LoadBookmarks()
        {

        }
        #endregion

        #region Validations
        protected void NumericOnly(KeyPressEventArgs e)
        {
            FromValidations.IsAlphabetNumeric(e);
        }
        private bool IsBatchComplete()
        {
            //int count = db.Count("select  distinct  count(*) FROM vehicleinfo a inner Join scan b on a.ID=b.VehicleInfoID where a.Status='BL';");
            //if (count > 0)
            //    return false;
            //else
            //    return true;
            return false;
        }
        #endregion

        #region ImageFunctions 
        private void DisplayRecordNumbers(string strText)
        {
            int nPos = lstImages.SelectedIndex;
            nPos++;
            lblImagePosition.Text = " Page:   " + nPos.ToString() + " of  " + lstImages.Items.Count.ToString() + " " + strText;
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
                imgBox.Image = null;
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(imgPath)))
                {
                    imgBox.Image = null;
                    imgBox.Refresh();
                    imgBox.SelectionColor = Color.RoyalBlue;
                    imgBox.Image = Bitmap.FromStream(ms);
                    //imgBoxFront.ZoomToFit();
                    ZoomLevelChanged();
                }
                imgBox.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error on Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UndoStack.Clear();
        }
        protected void DisplaySelectionWithZoom(string coordinates)
        {
            int x; int y; int width; int height;
            var arry = coordinates.Split(seprator);
            x = Convert.ToInt32(arry[0].ToString());
            y = Convert.ToInt32(arry[1].ToString());
            width = Convert.ToInt32(arry[2].ToString());
            height = Convert.ToInt32(arry[3].ToString());
            Selection(new RectangleF(x, y, width, height));
            Zoom(new RectangleF(x, y, width, height));
        }
        protected void Zoom(RectangleF rectangleF)
        {
            imgBox.AllowZoom = true;
            imgBox.ZoomIn();
            imgBox.ZoomToRegion(rectangleF);
        }
        protected void Selection(RectangleF rectangleF)
        {
            imgBox.SelectionRegion = rectangleF;
        }
        private bool CheckDPI(string img)
        {
            //Imaging imageProperties;
            //imageProperties = new Imaging(img);
            //double imgDPI = imageProperties.GetDPI();
            //if (imgDPI != FileSettings.NormalImageDPI)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return false;
        }
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
        #endregion

        #region Insert Data
        private bool InsertNewRecord()
        {
            return true;
        }

        #endregion

        #region Properties
        #endregion

        private void cobZoomLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZoomLevelChanged();
        }

        private void frmQCandUpdateRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
            }
            if (e.Alt && e.KeyCode == Keys.G)
            {
                // Call your desired function here
                btnGrayscale.PerformClick();
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {
                // Call your desired function here
                btnColor.PerformClick();
            }
            if (e.Alt && e.KeyCode == Keys.B)
            {
                // Call your desired function here
                btnBlackAndWhite.PerformClick();
            }
            switch (e.KeyCode)
            {
                case Keys.Add:
                    btnFrontZoomIn.PerformClick();
                    break;
                case Keys.Subtract:
                    btnFrontZommOut.PerformClick();
                    break;
                case Keys.Down:
                    btnNext.PerformClick();
                    break;
                case Keys.Up:
                    btnPrevious.PerformClick();
                    break;
                case Keys.Right:
                    btnLast.PerformClick();
                    break;
                case Keys.Left:
                    btnFirst.PerformClick();
                    break;
                //case Keys.RControlKey:
                //    btnFrontRotateRight.PerformClick();
                //    break;
                //case Keys.LControlKey:
                //    btnFrontRotateLeft.PerformClick();
                //    break;
                case Keys.D:
                    btnFronDeskew.PerformClick();
                    break;
                case Keys.S:
                    btnSave.PerformClick();
                    break;
                case Keys.C:
                    btnFrontCrop.PerformClick();
                    break;
                case Keys.A:
                    btnFrontZoomToFit.PerformClick();
                    break;
                case Keys.F:
                    btnFrontActualSize.PerformClick();
                    break;
                case Keys.I:
                    btnImport.PerformClick();
                    break;
                case Keys.R:
                    btnFrontRotateRight.PerformClick();
                    break;
                case Keys.L:
                    btnFrontRotateLeft.PerformClick();
                    break;
                default:
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                //case Keys.Shift | Keys.D:
                //    btnDeleteRecord.PerformClick();
                //  return true;
                case Keys.Shift | Keys.R:
                    btnRefresh.PerformClick();
                    return true;
                case Keys.Shift | Keys.X:
                    btnClose.PerformClick();
                    return true;

                    //case Keys.Control | Keys.R:
                    //    btnFrontRotateRight.PerformClick();
                    //    return true;

                    //case Keys.Control | Keys.L:
                    //    btnFrontRotateLeft.PerformClick();
                    //    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            var gotonNo = Convert.ToInt32(txtGoto.Text);
            if (lstImages.Items.Count >= gotonNo && gotonNo != 0)
            {
                lstImages.SelectedIndex = gotonNo - 1;
            }
            else
            {
                MessageBox.Show(this, "No image found in this position.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private async void cobFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFileDirectoryItem = cobFiles.SelectedItem as DropDownHelper;
            if (SelectedFileDirectoryItem.ID != 0)
            {
                await LoadSubFiles(SelectedFileDirectoryItem.ID);
            }
        }

        private async void cobSubDicrectoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSubDirectoryItem = cobSubFiles.SelectedItem as DropDownHelper;

            if (SelectedSubDirectoryItem != null && SelectedSubDirectoryItem.ID != 0)
            {
                await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            }
        }

        private string GetCleanPath(string path)
        {
            string imgPath = path.Replace("Raw", "Clean");
            if (!File.Exists(imgPath))
            {
                imgPath = path;
            }
            lblCurrentImagePath.Text = imgPath;
            lblCurrentPath.Text = Path.GetDirectoryName(imgPath);
            statusStripBottom.Refresh();
            return imgPath;
        }

        private string GetRawPath(string path)
        {
            lblCurrentImagePath.Text = path.Replace("Clean", "Raw");
            statusStripBottom.Refresh();
            return lblCurrentImagePath.Text;
        }

        private void DisplayBitmap(Bitmap bitmap)
        {
            try
            {
                imgBox.Image = null;
                imgBox.Image = bitmap;
                imgBox.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error on Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void chkImagesRaw_Click(object sender, EventArgs e)
        {
            string path = null;
            if (chkImagesRaw.Checked)
            {
                path = lblCurrentImagePath.Text.Replace("Clean", "Raw");
                chkImagesRaw.Image = Resources.checkboxChecked50x;
                DisplayImage(path);
            }
            else
            {
                path = lblCurrentImagePath.Text.Replace("Raw", "Clean");
                if (File.Exists(path))
                    DisplayImage(path);
                chkImagesRaw.Image = Resources.checkboxUnchecked50x;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int currentSelectedIndex = lstImages.SelectedIndex;
            int currentID = Convert.ToInt32(lstImages.SelectedValue);
            SaveImageAsync();
            Reset();
            bool result = await SaveFileDetail(currentID);
            if (result)
            {
                var fileDetailVM = ImageFileList.Where(x => x.ID == currentID).FirstOrDefault();
                fileDetailVM.Status = Status.QCDone;
                lstImages.SelectedIndex = currentSelectedIndex;
                Next();
            }
            UndoStack.Clear();
        }

        private void btnRectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRectangle.Checked)
            {
                btnFrontCrop.Enabled = true;
                imgBox.SelectionMode = ImageBoxSelectionMode.Rectangle;
            }
            else
            {
                btnFrontCrop.Enabled = false;
                imgBox.SelectionMode = ImageBoxSelectionMode.None;
                imgBox.SelectNone();
            }
        }

        private void btnFrontCrop_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRectangle.Checked)
            {
                btnFrontCrop.Enabled = true;
                imgBox.SelectionMode = ImageBoxSelectionMode.Rectangle;
            }
            else
            {
                btnFrontCrop.Enabled = false;
                imgBox.SelectionMode = ImageBoxSelectionMode.None;
                imgBox.SelectNone();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Last();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFileComplete_Click(object sender, EventArgs e)
        {
            int selectedFileIndex = cobFiles.SelectedIndex;
            await using var _db = await _dbContext.CreateDbContextAsync();
            var fileDirectorySelectedItem = SelectedFileDirectoryItem;
            var subDirectorySelectedItem = SelectedSubDirectoryItem;
            bool result = false;
            using (var waitForm = new PleaseWaitForm())
            {
                waitForm.Show(this);
                Application.DoEvents();

                try
                {
                    var fileDeatailList = await new FileDetailHelper(_dbContext).UpdateImageFilesStatus(SelectedSubDirectoryItem.ID, Status.QCDone);
                    if (fileDeatailList != null)
                    {
                        foreach (var fileDetail in fileDeatailList)
                        {
                            CopyImage(fileDetail.Path);
                        }
                    }

                    var checkFileCompelete = await CheckIsFileCompleteAsync();
                    if (!checkFileCompelete.isFileComplete)
                    {
                        Cursor = Cursors.Default;
                        string message = string.Format("There is/are {0} image file remaining for QC. Kindly complete the remaining files.", checkFileCompelete.Item2);
                        MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var dbImageCount = await new FileDetailHelper(_dbContext).GetImageCountOfFiles(SelectedSubDirectoryItem.ID);

                    var folderPathImageCount = Files.GetImageCount(lblCurrentPath.Text.Replace("Raw", "Clean"), SearchOption.TopDirectoryOnly);

                    if (dbImageCount != folderPathImageCount)
                    {
                        Cursor = Cursors.Default;
                        string message = string.Format("Database Image Count and Folder Image Count is not Matched! Kindly Contact to Techincal Team.");
                        MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    result = await FileComplete();
                }
                finally
                {
                    waitForm.Close();
                }
            }

            if (result)
            {
                Cursor = Cursors.Default;
                int caseID = Convert.ToInt32(cobFiles.SelectedValue);
                string message = string.Format("The File is Completed Sucessfully.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //LoadFiles();

                await LoadSubFiles(caseID);

                if (selectedFileIndex >= 0 && selectedFileIndex < cobFiles.Items.Count)
                {
                    //cobFiles.SelectedIndexChanged -= cobFile_SelectedIndexChanged;
                    cobFiles.SelectedIndex = selectedFileIndex;
                    //cobFiles.SelectedIndexChanged += cobFile_SelectedIndexChanged;
                }
                else if (cobFiles.Items.Count > 0)
                {
                    // cobFiles.SelectedIndexChanged -= cobFile_SelectedIndexChanged;
                    cobFiles.SelectedIndex = 0; // fallback to first item if available
                                                // cobFiles.SelectedIndexChanged += cobFile_SelectedIndexChanged;
                }
                else
                {
                    //cobFiles.SelectedIndexChanged -= cobFile_SelectedIndexChanged;
                    cobFiles.SelectedIndex = -1; // no items
                    //cobFiles.SelectedIndexChanged += cobFile_SelectedIndexChanged;
                }
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.Default;
                string message = string.Format("There is something wrong Kindly Contact to System Admin.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<(bool isFileComplete, int)> CheckIsFileCompleteAsync()
        {
            var caseDirectorySelectedItem = SelectedFileDirectoryItem;
            var subDirectorySelectedItem = SelectedSubDirectoryItem;
            return await FileSaveHelper.IsFileCompleteInQCAsync(
                MainDirectoryID,
               caseDirectorySelectedItem.ID,
               subDirectorySelectedItem.ID);

        }

        private async void btnBatchComplete_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var currentSelectedFileName = SelectedFileDirectoryItem?.Name ?? "Unknown Batch";
            bool result = await CheckIsBatchCompleteAsync();
            if (result)
            {
                var fileDirectoryResponse = await FileDirectoryCompleted();
                if (fileDirectoryResponse)
                {
                    await UpdateBatchAsync(Status.QCDone);
                    await LoadFiles();
                    string message = string.Format($"The Batch {currentSelectedFileName} is Completed Sucessfully.");
                    MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string message = string.Format("There is something wrong Kindly Contact to System Admin.");
                    MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cursor = Cursors.Default;
        }

        private async Task<bool> UpdateBatchAsync(Status status)
        {
            if (SelectedFileDirectoryItem == null)
                return false;

            var statusResult = await new FileDetailHelper(_dbContext).StatusUpdate(status, SelectedFileDirectoryItem.ID);

            if (statusResult.IsSuccess)
                return true;
            else
                return false;
        }

        private async Task<bool> CheckIsBatchCompleteAsync()
        {
            if (SelectedFileDirectoryItem == null)
                return false;
            int fileID = SelectedFileDirectoryItem.ID;
            var isCaseComplete = await FileSaveHelper.IsCaseDirectoryCompleteInQCAsync(
                MainDirectoryID,
               fileID);

            if (!isCaseComplete.Item1)
            {
                string message = string.Format("There is/are {0} file remaining for QC. Kindly complete the remaining files.", isCaseComplete.Item2);
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private async Task<bool> FileDirectoryCompleted()
        {
            try
            {
                return await DirectoryHelper.FileDirectoryQCCompleted(Convert.ToInt32(cobFiles.SelectedValue), AppUser.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error:" + ex.Message, "Error on Front Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void lstImages_MouseDown(object sender, MouseEventArgs e)
        {
            var selectedItem = lstImages.SelectedItem as ImageFileVM;
            if (e.Button == MouseButtons.Right && selectedItem != null)
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.SelectedIndex = lstImages.IndexFromPoint(e.Location);
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
                if (lstImages.SelectedIndex != -1)
                {
                    if (lstImages.CheckedItems.Count > 1)
                    {
                        menDeleteSelected.Enabled = true;
                    }
                    else
                    {
                        menDeleteSelected.Enabled = false;
                    }
                    contextMenuStrip.Show();
                }
            }
            else
            {
                if (selectedItem != null && menReorderList.Checked)
                {
                    //int index = lstImages.FindStringExact(selectedItem.Name);
                    lstImages.DoDragDrop(selectedItem, DragDropEffects.Move);
                    //lstImages.SelectedIndex = index;
                }
            }

        }

        private void lstImages_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private async void lstImages_DragDrop(object sender, DragEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Point point = lstImages.PointToClient(new Point(e.X, e.Y));
            int index = this.lstImages.IndexFromPoint(point);
            if (index < 0) index = this.lstImages.Items.Count - 1;
            var data = e.Data.GetData(typeof(ImageFileVM)) as ImageFileVM;
            ImageFileList.Remove(data);
            ImageFileList.Insert(index, data);
            int caseDirectoryID = GetCurrentSelectedCaseDirectoryID();
            int subDirectoryID = GetCurrentSelectedSubDirectoryID();
            //CaseDetailHelper = new FileDetailsHelper(_db);
            var updateFiles = await new FileDetailHelper(_dbContext).UpdateImageListAsync(subDirectoryID, ImageFileList.ToList(), AppUser.ID);
            //await DataInitAsync();
            await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            lstImages.SelectedIndex = index;
            Cursor = Cursors.Default;
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var item = lstImages.SelectedItem as ImageFileVM;
            if (item != null)
            {
                contextMenuStrip.Items[1].Visible = true;
                contextMenuStrip.Items[1].Text = string.Format("Movie File - {0}", item.Name.ToString());
            }
            else
            {
                contextMenuStrip.Items[1].Visible = false;
            }
        }

        private void menReorderList_Click(object sender, EventArgs e)
        {
            if (menReorderList.Checked)
            {
                menReorderList.Image = Resources.checkboxChecked50x;
            }
            else
            {
                menReorderList.Image = Resources.checkboxUnchecked50x;
            }
        }

        private async void menMoveFile_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstImages.SelectedIndex;
            if (selectedIndex < 0) return;
            frmMoveFile moveFile = new frmMoveFile();
            var result = moveFile.ShowDialog();
            if (result != DialogResult.OK)
                return;
            int index = Convert.ToInt32(moveFile.numNewPosition.Value - 1);
            if (index < 0) index = this.lstImages.Items.Count - 1;

            var data = lstImages.Items[selectedIndex] as ImageFileVM;
            ImageFileList.Remove(data);
            ImageFileList.Insert(index, data);
            int caseDirectoryID = GetCurrentSelectedCaseDirectoryID();
            int subDirectoryID = GetCurrentSelectedSubDirectoryID();
            //FileDetailsHelper = new FileDetailsHelper(_db);
            var updateFiles = await new FileDetailHelper(_dbContext).UpdateImageListAsync(subDirectoryID, ImageFileList.ToList(), AppUser.ID);
            //DataInitAsync();
            await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            lstImages.SelectedIndex = selectedIndex;
        }

        private void lblImagePath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCurrentImagePath.Text))
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(lblCurrentImagePath.Text));
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {

        }

        private void lstImages_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private async void btnImageCleanWithSelection_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var bitmap = new Bitmap(imgBox.Image);
            var convertedBitmap = new MaskedImage().ConvertToFormat(bitmap, PixelFormat.Format24bppRgb);
            var rect = new Rectangle((int)FrontRectangle.X, (int)FrontRectangle.Y, (int)FrontRectangle.Width, (int)FrontRectangle.Height);
            if (rect.Width == 0 && rect.Height == 0)
                return;
            var resultBitmap = new MaskedImage().ConvertToWhite(convertedBitmap, rect);
            DisplayBitmap(resultBitmap);
            //await SaveImage();
            Cursor = Cursors.Default;
        }

        private void lstImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                e.DrawBackground();
                Brush myBrush = Brushes.Black;
                Font itemFont = e.Font;
                var selectedItem = lstImages.Items[e.Index] as ImageFileVM;
                // findNode = trvClassifiedDocument.Nodes.Find(selectedItem.ID.ToString(), true).FirstOrDefault();

                if (selectedItem.Status == Status.QCDone)
                {
                    myBrush = Brushes.Black;
                    itemFont = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                e.Graphics.DrawString(selectedItem.Name, itemFont, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        private void btnTextEnhencement_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedIndex != -1)
            {
                Cursor = Cursors.WaitCursor;
                var imgData = new Enhencement().TextEnhencement(lblCurrentImagePath.Text, null);
                DisplayBitmap(Conversion.ByteToBitmap(imgData));
                Cursor = Cursors.Default;
            }
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {

        }

        private void btnRemarks_Click(object sender, EventArgs e)
        {
            //// db = DBConfig.GetNewInstance();
            // DialogResult result = MessageBox.Show(this, "Are you sure you want to Update The Remarks of file No: " + cobCaseDirectory.Text + "", Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // if (result != DialogResult.Yes)
            //     return;
            // frmRemarks remarks = new frmRemarks(CallingFor.Rescan);
            // var remarkResult = remarks.ShowDialog();
            // if (remarkResult != DialogResult.OK)
            //     return;
            // var remark = remarks.txtRemark.Text;
            // OperatorRemarks operatorRemarks = new OperatorRemarks();
            // operatorRemarks.CaseDirectoryID = GetCurrentSelectedCaseDirectoryID();
            // operatorRemarks.DirectoryID = MainDirectoryID;
            // operatorRemarks.SubDirectoryID = GetCurrentSelectedSubDirectoryID();
            // operatorRemarks.CreatedBy = AppUser.ID;
            // operatorRemarks.CreatedDateTime = DBhelper.GetCurrentDatTime();
            // operatorRemarks.FileDetailID = Convert.ToInt32(lstImages.SelectedValue);
            // operatorRemarks.Remarks = remark;
            // db.Add(operatorRemarks);
            // db.SaveChanges();
        }

        private void btnBlankImage_Click(object sender, EventArgs e)
        {


            //imgCompressor.JPEGCompression(imgData, 300, destinationPath.Replace(".tif", ".jpg"), out errorMessage);

        }
        private byte[] AddWatermark(string file)
        {

            using (var image = new MagickImage(file))
            {
                var readSettings = new MagickReadSettings
                {
                    FillColor = MagickColors.Black,
                    BackgroundColor = MagickColors.Transparent,
                    TextGravity = Gravity.Center,

                    Width = 2000,//image.Width,
                    Height = 300, //image.Height,
                    StrokeColor = MagickColors.Black,
                    FontPointsize = 190
                };
                using (var label = new MagickImage("label:Blank Page in Original", readSettings))
                {
                    label.Rotate(-45);
                    image.Composite(label, 500, 1000, CompositeOperator.Over);
                    //image.Write(destination);
                    return image.ToByteArray();
                }
            }

        }

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var imgData = AddWatermark(lblCurrentImagePath.Text);
            DisplayBitmap(Conversion.ByteToBitmap(imgData));
            Cursor = Cursors.Default;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmColorSetting colorSetting = new frmColorSetting();
            colorSetting.ShowDialog();
        }
        private Color GetColorAt(Point location)
        {
            using (Bitmap pixcelContainer = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(pixcelContainer))
                {
                    g.CopyFromScreen(location, Point.Empty, pixcelContainer.Size);
                }
                return pixcelContainer.GetPixel(0, 0);
            }
        }

        private async void menDeleted_Click(object sender, EventArgs e)
        {

            string message = string.Format("Are sure you want to delete the image {0}?", lstImages.Text);
            if (MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            List<ImageFileVM> checkedItems = new List<ImageFileVM>();
            int deleteIndexPosition = lstImages.SelectedIndex;
            var selectedItems = lstImages.SelectedItem as ImageFileVM;
            checkedItems.Add(selectedItems);

            await DeleteSelectedFiles(checkedItems);
            if (deleteIndexPosition >= 0 && deleteIndexPosition < lstImages.Items.Count)
            {
                lstImages.SelectedIndex = deleteIndexPosition;
            }
            else if (lstImages.Items.Count > 0)
            {
                lstImages.SelectedIndex = 0; // fallback to first item if available
            }
            else
            {
                lstImages.SelectedIndex = -1; // no items
            }
        }
        private bool RemoveFileFromList(ImageFileVM selectedItem, int selectedIndex)
        {
            if (File.Exists(selectedItem.Path))
            {
                try
                {
                    ImageFileList.RemoveAt(selectedIndex);
                    lstImages.Refresh();
                    if (lstImages.Items.Count > 0)
                    {
                        if (lstImages.Items.Count - 1 >= selectedIndex)
                        {
                            lstImages.SelectedIndex = selectedIndex;
                            DisplayImage(GetCurrentImagePath(Convert.ToInt32(lstImages.SelectedValue)));
                        }
                    }
                    else
                    {
                        lstImages.SelectedIndex = -1;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private async void menDeleteSelected_Click(object sender, EventArgs e)
        {
            if (lstImages.CheckedItems.Count > 1)
            {
                if (lstImages.CheckedItems.Count < 2)
                {
                    MessageBox.Show(this, "Please select atleast more than 1 file.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                int deleteIndexPosition = lstImages.SelectedIndex;
                List<ImageFileVM> checkedItems = new List<ImageFileVM>();
                var selectedItems = lstImages.CheckedItems;
                foreach (var item in selectedItems)
                {
                    checkedItems.Add(item as ImageFileVM);
                }

                await DeleteSelectedFiles(checkedItems);
                if (deleteIndexPosition >= 0 && deleteIndexPosition < lstImages.Items.Count)
                {
                    lstImages.SelectedIndex = deleteIndexPosition;
                }
                else if (lstImages.Items.Count > 0)
                {
                    lstImages.SelectedIndex = 0; // fallback to first item if available
                }
                else
                {
                    lstImages.SelectedIndex = -1; // no items
                }
            }
            else
            {
                menDeleteSelected.Enabled = false;
            }
        }
        private async Task<bool> DeleteSelectedFiles(List<ImageFileVM> checkedItems)
        {
            int deleteIndexPosition = lstImages.SelectedIndex;
            string fileNames = string.Join(',', checkedItems.Select(x => x.Name).ToList());

            var result = MessageBox.Show(this, "Are you sure? want to delete the images: " + fileNames, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == result)
            {
                using (var waitForm = new PleaseWaitForm())
                {
                    waitForm.Show(this);
                    Application.DoEvents();
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        foreach (var item in checkedItems)
                        {
                            var fileDetailId = item.ID;
                            string cleanImage = item.Path.Replace("Raw", "Clean");

                            RemoveFileFromList(item, deleteIndexPosition);

                            await new FileDetailHelper(_dbContext).OnDeleteUpdateImageListAsync(fileDetailId, ImageFileList.ToList(), AppUser.ID);
                            await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);

                            if (File.Exists(cleanImage))
                            {
                                File.Delete(cleanImage);
                            }

                        }



                        //if (deleteIndexPosition + 1 >= lstImages.Items.Count)
                        //{
                        //    lstImages.SelectedIndex = lstImages.Items.Count - 1;
                        //}
                        //else
                        //{
                        //    lstImages.SelectedIndex = deleteIndexPosition;
                        //}
                        Cursor = Cursors.Default;
                        MessageBox.Show(this, "Images: " + fileNames + " deleted successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        waitForm.Close();
                    }
                }
            }
            return true;
        }

        private void btnBlackAndWhite_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var bwImage = new Conversion().JpgToBlackAndWhiteJpg(GetRawPath(lblCurrentImagePath.Text));
                DisplayBitmap(bwImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;
        }


        public static Bitmap MatToBitmap(Mat image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var bitmap = new Bitmap(imgBox.Image);
                Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap grayImage = filter.Apply(bitmap);
                DisplayBitmap(grayImage);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnRefresh.PerformClick();
            Cursor = Cursors.Default;
        }

        private void btnMultiInsert_Click(object sender, EventArgs e)
        {

        }

        private async void btnImport_ClickAsync(object sender, EventArgs e)
        {
            int selectedIndex = lstImages.SelectedIndex;
            int currentSelectedIndex = selectedIndex;
            string selectedFile = null;

            if (currentSelectedIndex != -1)
            {
                selectedFile = (lstImages.Items[currentSelectedIndex] as ImageFileVM).Name;
            }

            frmImportImages frmImport = new frmImportImages(selectedFile, currentSelectedIndex);

            if (frmImport.ShowDialog() != DialogResult.OK)
                return;



            string selectedPath = frmImport.txtLocation.Text;

            RadioButton selectedRadioButton = null;

            foreach (Control control in frmImport.gpbOptions.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    selectedRadioButton = radioButton;
                    break;
                }
            }

            if (selectedRadioButton == null)
            {
                return;
            }

            string? selectedFileName = null;
            int currentIndex = 0;
            List<ImageFileVM> updatedFiles = new List<ImageFileVM>();

            Cursor = Cursors.WaitCursor;
            using (var waitForm = new PleaseWaitForm())
            {
                waitForm.Show(this);
                Application.DoEvents();

                try
                {
                    List<string> existingFiles = new List<string>();
                    if (frmImport.rabSingleImage.Checked)
                    {
                        existingFiles.Add(selectedPath);
                    }
                    else
                    {
                        existingFiles = Files.GetImageList(selectedPath, SearchOption.TopDirectoryOnly);
                    }

                    switch (selectedRadioButton.Tag)
                    {
                        case "EQ":
                            selectedFileName = ((ImageFileVM)lstImages.Items[lstImages.Items.Count - 1]).Name;
                            foreach (var file in existingFiles)
                            {
                                var selectFileVM = ImageFileList.Where(x => x.Name == Path.GetFileNameWithoutExtension(selectedFileName)).FirstOrDefault();
                                currentIndex = ImageFileList.IndexOf(selectFileVM);
                                var result = InsertImageInQueue(false, file, currentIndex, out string? errorMessage);
                                if (result.Item1)
                                {
                                    selectedFileName = result.Item2;
                                }
                                else
                                {
                                    MessageBox.Show(this, result.Item2, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    SetDefaultSelectedImage(selectedIndex);
                                    Cursor = Cursors.Default;
                                    return;
                                }
                            }
                            updatedFiles = await UpdateImageFileList();
                            break;
                        case "BQ":
                            if (lstImages.Items.Count > 0)
                            {
                                selectedFileName = ((ImageFileVM)lstImages.Items[currentSelectedIndex]).Name;
                                existingFiles = existingFiles.OrderByDescending(x => x).ToList();
                                foreach (var file in existingFiles)
                                {
                                    var selectFileVM = ImageFileList.Where(x => x.Name == Path.GetFileNameWithoutExtension(selectedFileName)).FirstOrDefault();
                                    currentIndex = ImageFileList.IndexOf(selectFileVM);
                                    var result = InsertImageInQueue(true, file, currentIndex, out string errorMessage);
                                    if (result.Item1)
                                    {
                                        selectedFileName = result.Item2;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, result.Item2, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        SetDefaultSelectedImage(selectedIndex);
                                        Cursor = Cursors.Default;
                                        return;
                                    }
                                }
                                updatedFiles = await UpdateImageFileList();
                            }
                            else
                            {
                                // When list is empty, insert using queue logic in descending order like decompiled code
                                existingFiles = existingFiles.OrderByDescending(x => x).ToList();
                                selectedFileName = null; // start fresh
                                foreach (var file in existingFiles)
                                {
                                    // if nothing selected yet, insert at 0, else next to last inserted
                                    if (string.IsNullOrEmpty(selectedFileName))
                                    {
                                        currentIndex = 0;
                                    }
                                    else
                                    {
                                        var selectFileVM = ImageFileList.Where(x => x.Name == Path.GetFileNameWithoutExtension(selectedFileName)).FirstOrDefault();
                                        currentIndex = ImageFileList.IndexOf(selectFileVM);
                                        if (currentIndex < 0) currentIndex = 0;
                                    }

                                    var result = InsertImageInQueue(true, file, currentIndex, out string errorMessage);
                                    if (result.Item1)
                                    {
                                        selectedFileName = result.Item2;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, result.Item2, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        SetDefaultSelectedImage(selectedIndex);
                                        Cursor = Cursors.Default;
                                        return;
                                    }
                                }
                                updatedFiles = await UpdateImageFileList();
                            }
                            lstImages.SelectedIndex = 0;
                            break;
                        case "BSQ":
                            selectedFileName = ((ImageFileVM)lstImages.Items[currentSelectedIndex]).Name;
                            existingFiles = existingFiles.OrderByDescending(x => x).ToList();
                            foreach (var file in existingFiles)
                            {
                                var selectFileVM = ImageFileList.Where(x => x.Name == Path.GetFileNameWithoutExtension(selectedFileName)).FirstOrDefault();
                                currentIndex = ImageFileList.IndexOf(selectFileVM);
                                var result = InsertImageInQueue(true, file, currentIndex, out string errorMessage);
                                if (result.Item1)
                                {
                                    selectedFileName = result.Item2;
                                }
                                else
                                {
                                    MessageBox.Show(this, result.Item2, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    SetDefaultSelectedImage(selectedIndex);
                                    Cursor = Cursors.Default;
                                    return;
                                }
                            }
                            updatedFiles = await UpdateImageFileList();
                            break;
                        case "ASQ":
                            selectedFileName = ((ImageFileVM)lstImages.Items[currentSelectedIndex]).Name;

                            foreach (var file in existingFiles)
                            {

                                var selectFileVM = ImageFileList.Where(x => x.Name == Path.GetFileNameWithoutExtension(selectedFileName)).FirstOrDefault();
                                currentIndex = ImageFileList.IndexOf(selectFileVM);
                                var result = InsertImageInQueue(false, file, currentIndex, out string? errorMessage);
                                if (result.Item1)
                                {
                                    selectedFileName = result.Item2;
                                }
                                else
                                {
                                    MessageBox.Show(this, result.Item2, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    SetDefaultSelectedImage(selectedIndex);
                                    Cursor = Cursors.Default;
                                    return;
                                }
                            }
                            updatedFiles = await UpdateImageFileList();
                            SelectedIndex = currentSelectedIndex;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }
                finally
                {
                    waitForm.Close();
                }
            }

            await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            lstImages.Refresh();
            SetDefaultSelectedImage(selectedIndex);
            MessageBox.Show(this, "All images imported successfully", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cursor = Cursors.Default;
        }

        private void SetDefaultSelectedImage(int selectedIndex)
        {
            if (lstImages.Items.Count > 0)
            {
                selectedIndex = selectedIndex == -1 ? 0 : selectedIndex;
                lstImages.SelectedIndex = selectedIndex;
            }
            else
            {
                lstImages.SelectedIndex = -1;
            }

            //Cursor = Cursors.Default;
        }

        private async Task<List<ImageFileVM>> UpdateImageFileList()
        {
            for (int i = 0; i < ImageFileList.Count; i++)
            {
                ImageFileList[i].SerialNo = i + 1; // Serial numbers start from 1
            }

            return await new FileDetailHelper(_dbContext).UpdateImageListAsync(
                 SelectedSubDirectoryItem.ID, ImageFileList.ToList(), AppUser.ID);
        }

        private async void AddImageExistingList(string selectedPath)
        {

            var existingFiles = Files.GetImageList(selectedPath, SearchOption.TopDirectoryOnly);
            if (existingFiles.Count > 0)
            {
                string imgDate = DateTime.Now.ToString("ddHHmmss");
                string? newFileName = null;
                string? destination = null;
                if (lstImages.Items.Count > 0)
                {
                    counter = counter + 1;
                }
                else
                {
                    counter = 1;
                    imgDate = DateTime.Now.ToString("ddHHmmss");
                }
                Cursor = Cursors.WaitCursor;
                foreach (var file in existingFiles)
                {
                    imgDate = DateTime.Now.ToString("ddHHmmss");
                    newFileName = imgDate + counter.ToString().PadLeft(4, '0') + "000.tif";
                    destination = Path.Combine(lblCurrentImagePath.Text, newFileName);

                    File.Copy(file, destination, true);
                    // SaveCompressImage(file, destination);
                    ImageFileList.Add(new ImageFileVM
                    {
                        Name = Path.GetFileNameWithoutExtension(destination),
                        Path = destination
                    });
                    counter++;
                }


                //LoadImageFiles(ImageFileList);
                counter = existingFiles.Count() + 1;
                lstImages.SelectedIndex = existingFiles.Count() - 1;
                Cursor = Cursors.Default;
            }
        }

        private (bool, string?) InsertImageInQueue(bool IsBegining, string source, int selectedIndex, out string? errorMessage)
        {
            try
            {
                int series = 0;
                int counter = -1;
                string fileNameWithoutCounter = null;
                bool isNewInsertFile = false;
                string newSelectedImagePath = ImageFileList[selectedIndex].Path;
                string sourceSelectedImagePath = source;
                string extension = Path.GetExtension(sourceSelectedImagePath).ToLower();
                string fileName = Path.GetFileName(newSelectedImagePath);

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
                    series = Convert.ToInt32(curentFileName.Substring(curentFileName.IndexOf("_") - 4, curentFileName.Length - curentFileName.IndexOf("_")));
                }
                else
                {
                    series = Convert.ToInt32(fileName.Substring(fileName.IndexOf(".") - 4, fileName.Length - fileName.IndexOf(".")));
                }

                if (series == 0)
                {
                    series = 1000;
                }

                if (IsBegining)
                    series--;
                else
                    series++;


                counter++;
                string newFileName = null;

                if (isNewInsertFile)
                {
                    newFileName = fileName.Substring(0, fileName.IndexOf(".") - 4) + series.ToString().PadLeft(4, '0') + "_" + counter.ToString() + extension;
                }
                else
                {
                    newFileName = fileNameWithoutCounter + "_" + counter.ToString() + extension;
                }

                string destinationPath = Path.Combine(Path.GetDirectoryName(newSelectedImagePath), newFileName);

                if (File.Exists(destinationPath))
                {
                    errorMessage = "File exist with same name " + Path.GetFileNameWithoutExtension(newFileName) + ". Kindly rename Next/Previous image first.";
                    return (false, errorMessage);
                }
                try
                {
                    File.Copy(source, destinationPath, false);
                    //SaveCompressImage(source, destinationPath);
                    errorMessage = null;
                }
                catch (Exception ex)
                {
                    //Cursor = Cursors.Default;
                    errorMessage = ex.Message;
                    return (false, errorMessage);
                }

                if (IsBegining)
                {
                    ImageFileList.Insert(selectedIndex, new ImageFileVM
                    {
                        Name = Path.GetFileNameWithoutExtension(destinationPath),
                        Path = destinationPath
                    });
                }
                else
                {
                    ImageFileList.Insert(selectedIndex + 1, new ImageFileVM
                    {
                        Name = Path.GetFileNameWithoutExtension(destinationPath),
                        Path = destinationPath
                    });

                }


                errorMessage = null;
                return (true, newFileName);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return (false, null);
            }
        }

        private void lblCurrentPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCurrentPath.Text))
            {
                Directory.CreateDirectory(lblCurrentPath.Text);
                Process.Start("explorer.exe", Path.GetDirectoryName(lblCurrentPath.Text));
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnDeleteBlankImages_Click(object sender, EventArgs e)
        {
            string rawPath = Path.GetDirectoryName(this.lblCurrentImagePath.Text.Replace("Clean", "Raw"));
            frmBlankMageProcess blankMageProcess = new frmBlankMageProcess(rawPath);
            DialogResult result = blankMageProcess.ShowDialog();
            if (blankMageProcess.SelectedPictures.Count <= 0)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
            (bool, string) valueTuple1 = await new FileDetailHelper(_dbContext).DeleteBlankFilesAsync(blankMageProcess.SelectedPictures);
            await LoadImageList(SelectedFileDirectoryItem.ID, SelectedSubDirectoryItem.ID);
            Cursor = Cursors.Default;
        }
    }

    // Add this extension method to convert a List<T> to a BindingList<T>.  
    public static class BindingListExtensions
    {
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> source)
        {
            return new BindingList<T>(source.ToList());
        }
    }
}
