
using AForge.Imaging.Filters;
using DC.DMS.Services.Models;
using DC.DMS.Services.Models.Main;
using DC.ImagUtility.Q16.Services;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using EFCore.BulkExtensions;
using DC.DMS.Services.Property;
using ImageMagick;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Miscellaneous;
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
    public partial class frmImageSingleDeleteQC : Form
    {
        #region Fields
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private int MainDirectoryID = 0;
        private int FileStatusID;
        string[] FieldCoordinates;
        int CurrentRecord = 0;
        private int CourtID = 0;
        char[] seprator = { ',' };
        private string insertFileName;
        readonly Stack<Bitmap> UndoStack = new Stack<Bitmap>();

        //DBHelper DBhelper;
        FileDetailHelper CaseDetailHelper;
        RectangleF FrontRectangle;
        //CaseTypeHelper CaseTypeHelper;
       // DocumentTypeHelper DocumentTypeHelper;
        DirectoryHelper DirectoryHelper;
        FileDetailHelper FileDetailsHelper;
       private ServerDateTimeHelper serverDateTimeHelper;

        List<ImageFileVM> CurrentSelectedFileList;
        List<ImageFileVM> FileList;
        List<ImageFileVM> CaseDirectoryList;
        List<SubDirectoryVM> SubDirectoryList;

        bool IsDeleteOperation = false;

        #endregion
        public frmImageSingleDeleteQC(int directoryID, int courtID, int fileStatusID, IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            MainDirectoryID = directoryID;
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            //  DBhelper = new DBHelper();
            // CaseTypeHelper = new CaseTypeHelper();
            DirectoryHelper = new DirectoryHelper(_dbContext,_cache,_translationService);
            CaseDetailHelper = new FileDetailHelper(_dbContext);
            CourtID = courtID;
            FileStatusID = fileStatusID;
            FileList = new List<ImageFileVM>();
           // FileSaveHelper = new MainDataHelper();
            CurrentSelectedFileList = new List<ImageFileVM>();
        }

        private async void frmApplicationForm_LoadAsync(object sender, EventArgs e)
        {
            this.Text = this.Text + " " + String.Format("Version {0}", AssemblyVersion);
            lblCurrentUserName.Text = AppUser.CurrentUserName;
            FillZoomLevels();
            imgBox.ZoomIn();
            cobZoomLevel.SelectedIndex = cobZoomLevel.FindStringExact("20%");

            await DataInitAsync();
            LoadCaseDirectory();
            // db.Update("Update vehicleinfo set status='OSQC' where ID='" + VehicleID + "'");
        }

        private async Task DataInitAsync()
        {
            //if (CaseDirectoryList != null)
            //    CaseDirectoryList.Clear();
            //if (SubDirectoryList != null)
            //    SubDirectoryList.Clear();
            //if (FileList != null)
            //    FileList.Clear();

            //var dataList = await DirectoryHelper.GetFilesDetailsWithDirectoriesAsync(MainDirectoryID, CallingFor.QC, CourtID, FileStatusID);
            //CaseDirectoryList = dataList.Item1.Where(x => x.Status == Status.Scan).ToList();
            //SubDirectoryList = dataList.Item2;
            //FileList = dataList.Item3;
        }

        private void LoadImageList(List<ImageFileVM> fileListVM, int caseDirectoryID, int subDirectoryID)
        {
           // db = DBConfig.GetNewInstance();
            CurrentSelectedFileList = fileListVM.Where(x => x.DirectoryID == MainDirectoryID
            && x.FileDirectoryID == caseDirectoryID && x.SubDirectoryID == subDirectoryID).ToList();
            //var fileUserID = fileListVM.Where(x => x.DirectoryID == MainDirectoryID && x.CaseDirectoryID == caseDirectoryID && x.SubDirectoryID == subDirectoryID).Select(x => x.QCCreateBy).FirstOrDefault();
            //var currentUserID = AppUser.ID;
            //if(fileUserID != null)
            //{
            //    if (fileUserID != currentUserID)
            //    {
            //        var userName = db.Users.Where(x => x.ID == fileUserID).Select(x => x.UserName).FirstOrDefault();
            //        string message = string.Format("'" + userName + "' already working on this file", lstImages.Text);
            //        MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            if (CurrentSelectedFileList.Count > 0)
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.DataSource = CurrentSelectedFileList;
                lstImages.DisplayMember = "Name";
                lstImages.ValueMember = "ID";
                lstImages.SelectedIndex = -1;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
                lstImages.SelectedIndex = 0;
            }
            else
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
            }
            lstImages.Refresh();
        }

        private void LoadSubDirectory(int caseDirectoryID)
        {

            var subDirectories = SubDirectoryList.Where(x => x.CaseDirectoryID == caseDirectoryID).ToList();
            if (subDirectories.Count > 0)
            {
                cobSubDicrectoy.SelectedIndexChanged -= cobSubDicrectoy_SelectedIndexChanged;
                cobSubDicrectoy.DataSource = null;
                cobSubDicrectoy.DataSource = subDirectories;
                cobSubDicrectoy.DisplayMember = "Name";
                cobSubDicrectoy.ValueMember = "ID";
                cobSubDicrectoy.SelectedIndex = -1;
                cobSubDicrectoy.SelectedIndexChanged += cobSubDicrectoy_SelectedIndexChanged;
                cobSubDicrectoy.SelectedIndex = 0;
            }
            else
            {
                cobSubDicrectoy.SelectedIndexChanged -= cobSubDicrectoy_SelectedIndexChanged;
                cobSubDicrectoy.DataSource = null;
                cobSubDicrectoy.SelectedIndex = -1;
                cobSubDicrectoy.SelectedIndexChanged += cobSubDicrectoy_SelectedIndexChanged;

                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;

                imgBox.Image = null;
            }
        }

        private void LoadCaseDirectory()
        {
            var caseDirectories = CaseDirectoryList.ToList();
            if (caseDirectories.Count > 0)
            {
                cobCaseDirectory.SelectedIndexChanged -= cobCaseDirectory_SelectedIndexChanged;
                cobCaseDirectory.DataSource = null;
                cobCaseDirectory.DataSource = caseDirectories;
                cobCaseDirectory.DisplayMember = "Name";
                cobCaseDirectory.ValueMember = "ID";
                cobCaseDirectory.SelectedIndex = -1;
                cobCaseDirectory.SelectedIndexChanged += cobCaseDirectory_SelectedIndexChanged;
                cobCaseDirectory.SelectedIndex = 0;
            }
            else
            {
                cobCaseDirectory.SelectedIndexChanged -= cobCaseDirectory_SelectedIndexChanged;
                cobCaseDirectory.DataSource = null;
                cobCaseDirectory.SelectedIndex = -1;
                cobCaseDirectory.SelectedIndexChanged += cobCaseDirectory_SelectedIndexChanged;

                cobSubDicrectoy.SelectedIndexChanged -= cobSubDicrectoy_SelectedIndexChanged;
                cobSubDicrectoy.DataSource = null;
                cobSubDicrectoy.SelectedIndex = -1;
                cobSubDicrectoy.SelectedIndexChanged += cobSubDicrectoy_SelectedIndexChanged;

                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;

                imgBox.Image = null;

            }
        }

        private string GetCurrentImagePath(int id)
        {
            var imgPath = CurrentSelectedFileList.Where(x => x.ID == id).Select(x => x.Path).FirstOrDefault();
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
            Cursor.Current = Cursors.WaitCursor;
            int currentID = Convert.ToInt32(lstImages.SelectedValue);

            if (Settings.Default.AutoSave)
            {
                await SaveImageAsync(currentID);
                Reset();
            }

            if (lstImages.SelectedValue == null)
                return;
            DisplayRecordNumbers("");
            DisplayImage(GetCurrentImagePath(Convert.ToInt32(lstImages.SelectedValue)));
            Cursor.Current = Cursors.Default;
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
            string message = string.Format("Are sure you want to delete the image {0}?", lstImages.Text);
            if (MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            int selectedFileID = Convert.ToInt32(lstImages.SelectedValue);
            int deleteIndexPosition = lstImages.SelectedIndex;
            string cleanImage = lblImagePath.Text.Replace("Raw", "Clean");
            CurrentSelectedFileList.RemoveAt(deleteIndexPosition);
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            await FileDetailsHelper.OnDeleteUpdateImageListAsync(selectedFileID, CurrentSelectedFileList, AppUser.ID);
            await DataInitAsync();
            LoadImageListWithoutRefresh(FileList, GetCurrentSelectedCaseDirectoryID(), GetCurrentSelectedSubDirectoryID());

            if (deleteIndexPosition + 1 >= lstImages.Items.Count)
            {
                lstImages.SelectedIndex = lstImages.Items.Count - 1;
            }
            else
            {
                lstImages.SelectedIndex = deleteIndexPosition;
            }
            if (File.Exists(cleanImage))
            {
                File.Delete(cleanImage);
            }
            Cursor.Current = Cursors.Default;
        }
        private void LoadImageListWithoutRefresh(List<ImageFileVM> fileListVM, int caseDirectoryID, int subDirectoryID)
        {
            CurrentSelectedFileList = fileListVM.Where(x => x.DirectoryID == MainDirectoryID
            && x.FileDirectoryID == caseDirectoryID && x.SubDirectoryID == subDirectoryID).ToList();
            if (CurrentSelectedFileList.Count > 0)
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.DataSource = CurrentSelectedFileList;
                lstImages.DisplayMember = "Name";
                lstImages.ValueMember = "ID";
                lstImages.SelectedIndex = -1;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
            }
            else
            {
                lstImages.SelectedIndexChanged -= lstImages_SelectedIndexChanged;
                lstImages.DataSource = null;
                lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
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
            await SaveImageAsync(currentID);
        }

        private async void btnFrontRotateRight_ClickAsync(object sender, EventArgs e)
        {
            imgBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            imgBox.Refresh();
            int currentID = Convert.ToInt32(lstImages.SelectedValue);
            await SaveImageAsync(currentID);
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
            Cursor.Current = Cursors.WaitCursor;
            imgBox.Image = new ImageDeskew(new Bitmap(imgBox.Image)).Deskew(false);
            imgBox.ZoomToFit();
            imgBox.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void btnFrontCrop_Click(object sender, EventArgs e)
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
            await SaveImageAsync(currentID);
            Reset();
            Next();
        }
        private async Task SaveImageAsync(int id)
        {
            if (imgBox.Image == null)
                return;
            Cursor.Current = Cursors.WaitCursor;
            //var selectedItem = lstImageQueue.SelectedItem as ImageListVM;
            Compressor imgCompressor = new Compressor();
            try
            {
                string errorMessage = null;
                string fileName = Path.GetFileName(lblImagePath.Text);
                string extension = Path.GetExtension(lblImagePath.Text);
                string path = Path.GetDirectoryName(lblImagePath.Text).Replace("Raw", "Clean");
                Directory.CreateDirectory(path);
                string destinationPath = Path.Combine(path, fileName);
                // int currentID = Convert.ToInt32(lstImages.SelectedValue);

                switch (extension)
                {
                    case ".tif":
                    case ".tiff":
                        //byte[] imgData = Conversion.BitmapToByte(new Bitmap(imgBox.Image), ImageFormat.Tiff);
                        new Compressor().CustomCompressTiffImage(new Bitmap(imgBox.Image), destinationPath, out errorMessage);
                        break;
                    case ".jpg":
                        byte[] imgJPGData = Conversion.BitmapToByte(new Bitmap(imgBox.Image), ImageFormat.Jpeg);
                        imgCompressor.JPEGCompression(imgJPGData, 300, destinationPath.Replace(".tif", ".jpg"), out errorMessage);
                        break;
                    default:
                        break;
                }

                bool result = await SaveFileDetail(id);
                //imgBox.Refresh();
                //imgBox.SelectNone();
                lblImageCoordinates.Text = "X:0 Y:0 W:0 H:0";

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, "Error:" + ex.Message, "Error on Front Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor.Current = Cursors.Default;
         
        }
       

        private void CopyImage(string imgPath)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            Cursor.Current = Cursors.Default;
        }
        private async Task<bool> SaveFileDetail(int id)
        {
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            return await FileDetailsHelper.UpdateImageDT(id, AppUser.ID);
        }
        private async Task<bool> FileComplete()
        {
            try
            {
                return await DirectoryHelper.SubDirectoryQCCompleted(Convert.ToInt32(cobSubDicrectoy.SelectedValue), AppUser.ID);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error:" + ex.Message, "Error on Front Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnFrontRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            imgBox.Image = null;
            imgBox.Image = Image.FromFile(lblImagePath.Text);
            imgBox.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void frmApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
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
            Cursor.Current = Cursors.WaitCursor;
            int maxCount = CurrentSelectedFileList.Count();
            int selectedIndex = lstImages.SelectedIndex + 1;
            string curentDirectoryPath = GetCurrentSelectFolderPath();
            frmMultiImageInsert frmInsert = new frmMultiImageInsert(curentDirectoryPath,_cache,_translationService);
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
                CurrentSelectedFileList.Insert(newIndexPosition, newFileDetails);
                FileDetailsHelper = new FileDetailHelper(_dbContext);

                await FileDetailsHelper.OnInsertUpdateImageListAsync(CurrentSelectedFileList, AppUser.ID);
                await DataInitAsync();
                LoadImageList(FileList, newFileDetails.FileDirectoryID, newFileDetails.SubDirectoryID);
            }
            counter = 0;

            Cursor.Current = Cursors.Default;
        }

        private string GetCurrentSelectFolderPath()
        {
            return Path.GetDirectoryName(lblImagePath.Text);
        }

        private int GetCurrentSelectedSubDirectoryID()
        {
            return Convert.ToInt32(cobSubDicrectoy.SelectedValue);
        }

        private int GetCurrentSelectedCaseDirectoryID()
        {
            return Convert.ToInt32(cobCaseDirectory.SelectedValue);
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
                //undoBitmap.Save("bitmap.tif");
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
           // MetroAppColor.TextBoxEnter((MetroTextBox)sender);
        }

        private void TextLeave(object sender, EventArgs e)
        {
            //MetroAppColor.TextBoxLeave((MetroTextBox)sender);
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
            //MetroAppColor.ComboBoxLeave((MetroComboBox)sender);
        }
        #endregion

        #region Load
        private void LoadFiles()
        {
           
        }

        private void OptionEnable(bool v)
        {
            btnNext.Enabled = v;
            btnPrevious.Enabled = v;
            btnFirst.Enabled = v;
            btnLast.Enabled = v;
            btnInsert.Enabled = v;
            btnBatchComplete.Enabled = v;
            btnDeleteRecord.Enabled = v;
            btnFileComplete.Enabled = v;
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
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(imgPath)))
                {
                    imgBox.Image = null;
                    imgBox.SelectionColor = Color.RoyalBlue;
                    imgBox.Image = Bitmap.FromStream(ms);
                    //imgBoxFront.ZoomToFit();

                    imgBox.Refresh();
                    ZoomLevelChanged();
                }
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
                    btnInsert.PerformClick();
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
                case Keys.Shift | Keys.D:
                    btnDeleteRecord.PerformClick();
                    return true;
                case Keys.Shift | Keys.R:
                    btnFrontRefresh.PerformClick();
                    return true;
                case Keys.Shift | Keys.X:
                    btnClose.PerformClick();
                    return true;


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

        private void cobCaseDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedVaule = Convert.ToInt32(cobCaseDirectory.SelectedValue);
            if (selectedVaule > 0)
            {
                LoadSubDirectory(selectedVaule);
            }
        }

        private void cobSubDicrectoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var caseDirectoryID = Convert.ToInt32(cobCaseDirectory.SelectedValue);
            var selectedVaule = Convert.ToInt32(cobSubDicrectoy.SelectedValue);
            if (selectedVaule >= 0)
            {
                LoadImageList(FileList, caseDirectoryID, selectedVaule);
            }
        }

        private string GetCleanPath(string path)
        {
            string imgPath = path.Replace("Raw", "Clean");
            if (!File.Exists(imgPath))
            {
                imgPath = path;
            }
            lblImagePath.Text = imgPath;
            statusStripBottom.Refresh();
            return imgPath;
        }

        private string GetRawPath(string path)
        {
            lblImagePath.Text = path.Replace("Clean", "Raw");
            statusStripBottom.Refresh();
            return lblImagePath.Text;
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
            if (chkImagesRaw.Checked)
            {
                //chkImagesRaw.Image = Resources.checkboxChecked50x;
            }
            else
            {
                //chkImagesRaw.Image = Resources.checkboxUnchecked50x;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int currentSelectedIndex = lstImages.SelectedIndex;
            int currentID = Convert.ToInt32(lstImages.SelectedValue);
            await SaveImageAsync(currentID);
            Reset();
            bool result = await SaveFileDetail(currentID);
            if (result)
            {
                var fileDetailVM = CurrentSelectedFileList.Where(x => x.ID == currentID).FirstOrDefault();
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
            await using var _db = await _dbContext.CreateDbContextAsync();
            var caseDirectorySelectedItem = cobCaseDirectory.SelectedItem as FileDirectoryVM;
            var subDirectorySelectedItem = cobSubDicrectoy.SelectedItem as SubDirectoryVM;
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            var fileDeatailList = await FileDetailsHelper.GetFileDetails(subDirectorySelectedItem.ID, Status.Scanned);
            if (fileDeatailList != null)
            {
                foreach (var fileDetail in fileDeatailList)
                {
                    fileDetail.Status = Status.QCDone;
                    fileDetail.QCCreateBy = AppUser.ID;
                    fileDetail.QCCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                    CopyImage(fileDetail.Path);
                }
                
                var bulkConfig = new BulkConfig { PropertiesToIncludeOnUpdate = new List<string> { nameof(ImageFileDetail.Status), nameof(ImageFileDetail.QCCreateBy), nameof(ImageFileDetail.QCCreateDateTime) } };
                _db.BulkUpdate(fileDeatailList, bulkConfig);
            }
            await CheckIsFileCompleteAsync();
           
            var dbImageCount = await _db.ImageFileDetails.Where(x => x.SubDirectoryID == subDirectorySelectedItem.ID).Select(x => x.Path).CountAsync();
            var folderPathImageCount = Directory.GetFiles(subDirectorySelectedItem.Path.Replace("Raw", "Clean"))
                .Where(x => x.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)).Count();
            if (dbImageCount != folderPathImageCount)
            {
                string message = string.Format("Database Image Count and Folder Image Count is not Matched! Kindly Contact to Techincal Team.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = await FileComplete();
            if (result)
            {
                int caseID = Convert.ToInt32(cobCaseDirectory.SelectedValue);
                string message = string.Format("The File is Completed Sucessfully.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubDirectoryList.Remove(subDirectorySelectedItem);
                LoadSubDirectory(caseID);
            }
            else
            {
                string message = string.Format("There is something wrong Kindly Contact to System Admin.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CheckIsFileCompleteAsync()
        {
            var caseDirectorySelectedItem = cobCaseDirectory.SelectedItem as FileDirectoryVM;
            var subDirectorySelectedItem = cobSubDicrectoy.SelectedItem as SubDirectoryVM;
            

        }

        private async void btnBatchComplete_Click(object sender, EventArgs e)
        {
            await UpdateCaseDetailsAsync(Status.QCDone);
            await CheckIsBatchCompleteAsync();
        }
        private async Task UpdateCaseDetailsAsync(Status status)
        {
            //var selectedItem = cobBarcode.SelectedItem as DropDownHelper;
            //await CaseDetailHelper.CaseDetailsStatusUpdateOne(status, Convert.ToInt32(cobCaseDirectory.SelectedValue), AppUser.ID);
        }
        private async Task CheckIsBatchCompleteAsync()
        {
            int caseID = Convert.ToInt32(cobCaseDirectory.SelectedValue);
            //var isCaseComplete = await FileSaveHelper.IsCaseDirectoryCompleteInQCAsync(
            //    MainDirectoryID,
            //   caseID);

            //if (!isCaseComplete.Item1)
            //{
            //    string message = string.Format("There is/are {0} file remaining for QC. Kindly complete the remaining files.", isCaseComplete.Item2);
            //    MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            var result = await CaseFileCompleted();
            if (result)
            {
                string message = string.Format("The File is Completed Sucessfully.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CaseDirectoryList.RemoveAt(cobCaseDirectory.SelectedIndex);
                LoadCaseDirectory();
            }
            else
            {
                string message = string.Format("There is something wrong Kindly Contact to System Admin.");
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> CaseFileCompleted()
        {
            try
            {
                return await DirectoryHelper.FileDirectoryQCCompleted(Convert.ToInt32(cobCaseDirectory.SelectedValue), AppUser.ID);
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
            Cursor.Current = Cursors.WaitCursor;
            Point point = lstImages.PointToClient(new Point(e.X, e.Y));
            int index = this.lstImages.IndexFromPoint(point);
            if (index < 0) index = this.lstImages.Items.Count - 1;
            var data = e.Data.GetData(typeof(ImageFileVM)) as ImageFileVM;
            CurrentSelectedFileList.Remove(data);
            CurrentSelectedFileList.Insert(index, data);
            int caseDirectoryID = GetCurrentSelectedCaseDirectoryID();
            int subDirectoryID = GetCurrentSelectedSubDirectoryID();
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            var updateFiles = await FileDetailsHelper.OnReorderUpdateImageListAsync(subDirectoryID, CurrentSelectedFileList, AppUser.ID);
            //await DataInitAsync();
            LoadImageList(updateFiles, caseDirectoryID, subDirectoryID);
            lstImages.SelectedIndex = index;
            Cursor.Current = Cursors.Default;
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
                //menReorderList.Image = Resources.checkboxChecked50x;
            }
            else
            {
                //menReorderList.Image = Resources.checkboxUnchecked50x;
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
            CurrentSelectedFileList.Remove(data);
            CurrentSelectedFileList.Insert(index, data);
            int caseDirectoryID = GetCurrentSelectedCaseDirectoryID();
            int subDirectoryID = GetCurrentSelectedSubDirectoryID();
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            var updateFiles = await FileDetailsHelper.OnReorderUpdateImageListAsync(subDirectoryID, CurrentSelectedFileList, AppUser.ID);
            //DataInitAsync();
            LoadImageList(updateFiles, caseDirectoryID, subDirectoryID);
            lstImages.SelectedIndex = selectedIndex;
        }

        private void lblImagePath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblImagePath.Text))
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(lblImagePath.Text));
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
                Cursor.Current = Cursors.WaitCursor;
                var imgData = new Enhencement().TextEnhencement(lblImagePath.Text, null);
                DisplayBitmap(Conversion.ByteToBitmap(imgData));
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {

        }

        private void btnRemarks_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to Update The Remarks of file No: " + cobCaseDirectory.Text + "", Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            frmRemarks remarks = new frmRemarks(CallingFor.Rescan, _dbContext, _cache,_translationService);
            var remarkResult = remarks.ShowDialog();
            if (remarkResult != DialogResult.OK)
                return;
            var remark = remarks.txtRemark.Text;
            
        }

        private void btnBlankImage_Click(object sender, EventArgs e)
        {



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
                    return image.ToByteArray();
                }
            }

        }

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var imgData = AddWatermark(lblImagePath.Text);
            DisplayBitmap(Conversion.ByteToBitmap(imgData));
            Cursor.Current = Cursors.Default;
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

            Cursor.Current = Cursors.WaitCursor;
            int selectedFileID = Convert.ToInt32(lstImages.SelectedValue);
            int deleteIndexPosition = lstImages.SelectedIndex;
            string cleanImage = lblImagePath.Text.Replace("Raw", "Clean");
            CurrentSelectedFileList.RemoveAt(deleteIndexPosition);
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            await FileDetailsHelper.OnDeleteUpdateImageListAsync(selectedFileID, CurrentSelectedFileList, AppUser.ID);
            await DataInitAsync();
            LoadImageListWithoutRefresh(FileList, GetCurrentSelectedCaseDirectoryID(), GetCurrentSelectedSubDirectoryID());

            if (deleteIndexPosition + 1 >= lstImages.Items.Count)
            {
                lstImages.SelectedIndex = lstImages.Items.Count - 1;
            }
            else
            {
                lstImages.SelectedIndex = deleteIndexPosition;
            }
            if (File.Exists(cleanImage))
            {
                File.Delete(cleanImage);
            }
            Cursor.Current = Cursors.Default;
           
        }
        private bool DeleteFile(ImageFileVM selectedItem, int selectedIndex)
        {
            if (File.Exists(selectedItem.Path))
            {
                try
                {
                  

                    CurrentSelectedFileList.RemoveAt(selectedIndex);
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

        private void menDeleteSelected_Click(object sender, EventArgs e)
        {
            if (lstImages.CheckedItems.Count > 1)
                DeleteSelectedFiles();
            else menDeleteSelected.Enabled = false;
        }
        private async void DeleteSelectedFiles()
        {
            if (lstImages.CheckedItems.Count < 2)
            {
                MessageBox.Show(this, "Please select atleast more than 1 file.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            List<ImageFileVM> CheckedItems = new List<ImageFileVM>();
            var selectedItems = lstImages.CheckedItems;
            //int selectedIndex = lstImages.SelectedIndex;
            int selectedFileID = Convert.ToInt32(lstImages.SelectedValue);
            int deleteIndexPosition = lstImages.SelectedIndex;
            //int deleteIndexPosition = lstImages.SelectedIndex;


            foreach (var item in selectedItems)
            {
                CheckedItems.Add(item as ImageFileVM);
            }
            string fileNames = string.Join(',', CheckedItems.Select(x => x.Name).ToList());

            var result = MessageBox.Show(this, "Are you sure? want to delete the images: " + fileNames, Default.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == result)
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (var item in CheckedItems)
                {
                    var fileDetailId = item.ID;
                    string cleanImage = item.Path.Replace("Raw", "Clean");
                    DeleteFile(item, deleteIndexPosition);
                    await FileDetailsHelper.OnDeleteUpdateImageListAsync(fileDetailId, CurrentSelectedFileList, AppUser.ID);

                    if (deleteIndexPosition + 1 >= lstImages.Items.Count)
                    {
                        lstImages.SelectedIndex = lstImages.Items.Count - 1;
                    }
                    else
                    {
                        lstImages.SelectedIndex = deleteIndexPosition;
                    }
                    if (File.Exists(cleanImage))
                    {
                        File.Delete(cleanImage);
                    }
                }
                FileDetailsHelper = new FileDetailHelper(_dbContext);
                //await FileDetailsHelper.OnDeleteUpdateImageListAsync(selectedFileID, CurrentSelectedFileList, AppUser.ID);
                await DataInitAsync();
                LoadImageListWithoutRefresh(FileList, GetCurrentSelectedCaseDirectoryID(), GetCurrentSelectedSubDirectoryID());
                //lstImages.Refresh();

                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, "Images: " + fileNames + " deleted successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
