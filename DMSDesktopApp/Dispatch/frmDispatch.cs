using DC.DMS.Services.Models;
using DC.DMS.Services.Property;
using DC.DMS.Services.ViewModels;
using DC.DMS.Services.WorkflowModels;
using DC.OCR;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using DMS.Migrations.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static DC.DMS.Services.Enum.WorkflowEnums;
using System.Linq; // added for filtering
using System.IO; // for File.Exists


namespace DMS.DesktopApp.Dispatch
{
    public partial class frmDispatch : Form
    {
        #region Fields
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        string MergedPDFName;
        //string scanDate;
        string FolderName;
        private DirectoryHelper DirectoryHelper;
        private FileDetailHelper FileDetailsHelper;
        string ProcessDirectory;
        BackgroundWorker worker;
        DataTable processDT;
        Stopwatch watch;
        int totalRecords = 0;
        int count = 0;
        DateTime scanDate;
        private int DirectoryID = 0;

        private List<int> SelectedFileIDList = new List<int>();
        #endregion
        string DigitalSignature;
        public frmDispatch(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            _translationService = translationService;
            DirectoryHelper = new DirectoryHelper(_dbContext, _cache, _translationService);
            FileDetailsHelper = new FileDetailHelper(_dbContext);
            watch = new Stopwatch();

            ProcessDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HC", "Temp");
        }

        private async void frmDispatch_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = AppUser.CurrentUserName;

            await LoadDirectoryAsync();
            if (cobBatch.Items.Count > 0)
            {
                cobBatch.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "No btach found.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private async Task LoadDirectoryAsync()
        {
            var directoryList = await DirectoryHelper.GetClassificationDoneDirectories();
            if (directoryList.Count > 0)
            {
                cobBatch.SelectedIndexChanged -= cobBatch_SelectedIndexChanged;
                // Bind the list directly; DisplayMember/ValueMember are not needed for a string list
                cobBatch.DataSource = directoryList;
                cobBatch.SelectedIndex = -1;
                cobBatch.SelectedIndexChanged += cobBatch_SelectedIndexChanged;
            }
            else
            {
                cobBatch.SelectedIndexChanged -= cobBatch_SelectedIndexChanged;
                cobBatch.DataSource = null;
                cobBatch.SelectedIndexChanged += cobBatch_SelectedIndexChanged;
                cobBatch.SelectedIndex = -1;
            }

        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblErrorMessage.Visible = false;
            watch.Start();
            if (lstFiles.CheckedItems.Count == 0)
            {
                MessageBox.Show(this, "Please select alteast one file.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedFileIDList.Clear();

            foreach (var item in lstFiles.CheckedItems)
            {
                var currentFile = item as DropDownHelper;
                SelectedFileIDList.Add(currentFile.ID);
            }

            if (backgroundWorker.IsBusy != true)
            {
                backgroundWorker.RunWorkerAsync();
            }

            btnClose.Text = "&Cancel";
            lblPercentage.Visible = true;
            lblTimeTakenLable.Visible = false;
            lblTimeTaken.Visible = false;
            btnProcess.Enabled = false;
            lblTimeTaken.Text = "00";
            lblPercentage.Text = "Process Start...";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Task ProcessStartAsync(List<int> fileIDList, DoWorkEventArgs e)
        {
            return BatchMode(e, fileIDList);
        }

        private async Task BatchMode(DoWorkEventArgs e, List<int> fileIDList)
        {
            int percentage = 0;
            totalRecords = fileIDList.Count;
            count = 0;

            foreach (var fileDirectoryID in fileIDList)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    worker.ReportProgress(0);
                    break;
                }

                await using var _db = await _dbContext.CreateDbContextAsync();

                var subDirectoryList = _db.SubDirectories
                    .Where(x => x.FileDirectoryID == fileDirectoryID)
                    .ToList();

                foreach (var subDirectoryDetail in subDirectoryList)
                {
                    var allImagePaths = _db.ImageFileDetails
                        .Where(x => x.SubDirectoryID == subDirectoryDetail.ID && x.Flag != Flag.Delete)
                        .OrderBy(x => x.SerialNo)
                        .Select(x => x.Path.Replace("Raw", "Clean"))
                        .ToList();

                    // If no images at all, log and skip this subdirectory
                    if (allImagePaths.Count == 0)
                    {
                        Log.WriteLog.Create("ErrorLog", $"Log DateTime: {DateTime.Now}, SubDir:{subDirectoryDetail.Name}, Error: No images found.", out _);
                        continue; // skip to next subdirectory
                    }

                    // Check every image exists; if ANY missing => log and skip this subdirectory entirely
                    var missing = allImagePaths.Where(p => !File.Exists(p)).ToList();
                    if (missing.Count > 0)
                    {
                        string missingSample = string.Join(", ", missing.Take(10));
                        Log.WriteLog.Create("ErrorLog", $"Log DateTime: {DateTime.Now}, SubDir:{subDirectoryDetail.Name}, Missing {missing.Count} image(s). Sample: {missingSample}. Skipped.", out _);
                        continue; // skip processing this subdirectory
                    }

                    // All images present
                    var imageList = allImagePaths; // safe to pass original order

                    var subDirectoryName = subDirectoryDetail.Name;
                    var pdfFileName = subDirectoryName;

                    string currentScanDate;
                    string pattern = @"\d{2}-\d{2}-\d{4}";
                    Match match = Regex.Match(subDirectoryDetail.Path, pattern);
                    currentScanDate = match.Success ? match.Value : scanDate.ToString("dd-MM-yyyy");

                    string departmentFileName = Path.GetFileName(Path.GetDirectoryName(subDirectoryDetail.Path)).Replace(" ", "");

                    var destinationPath = Path.Combine(
                        Properties.Settings.Default.DriveLetter + ":\\",
                        "PDF",
                        currentScanDate,
                        departmentFileName,
                        subDirectoryName);

                    Directory.CreateDirectory(destinationPath);
                    string destinationFilePath = Path.Combine(destinationPath, pdfFileName);

                    var pdfResult = new ImagesToSearchablePdf().CreateSearchablePdf(
                        imageList,
                        "Devanagari",
                        destinationPath,
                        pdfFileName,
                        Application.StartupPath);

                    if (pdfResult.pageCount > 0)
                    {
                        await FileDetailsHelper.FilesStatusChangeAfterDispatchAsync(subDirectoryDetail.ID, fileDirectoryID, Status.Dispatched);

                        bool exists = _db.DispatchedData.Any(x => x.SubDirectoryID == subDirectoryDetail.ID && x.FilePath == destinationFilePath + ".pdf");
                        if (!exists)
                        {
                            try
                            {
                                var currentDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                                DispatchData dispatchData = new DispatchData
                                {
                                    SubDirectoryID = subDirectoryDetail.ID,
                                    FileName = departmentFileName,
                                    FilePath = destinationFilePath + ".pdf",
                                    PageCount = pdfResult.pageCount,
                                    CreateBy = AppUser.ID,
                                    UpdateBy = AppUser.ID,
                                    UpdateDateTime = currentDateTime,
                                    CreateDateTime = currentDateTime
                                };
                                _db.DispatchedData.Add(dispatchData);
                                _db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Log.WriteLog.Create("ErrorLog", $"Error:{ex.Message} Inner:{ex.InnerException?.Message}", out _);
                                continue; // skip to next subdirectory
                            }
                        }

                        await FileDetailsHelper.SubDirectoryDispatchDoneAsync(subDirectoryDetail.ID);
                    }
                    else
                    {
                        try
                        {
                            ErrorLog errorLogs = new ErrorLog
                            {
                                DirectoryID = DirectoryID,
                                CaseDirectoryID = fileDirectoryID,
                                SubDirectoryID = subDirectoryDetail.ID,
                                CreatedBy = AppUser.ID,
                                CreatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync(),
                                FileName = pdfFileName,
                                FilePath = destinationPath
                            };
                            _db.Add(errorLogs);
                            _db.SaveChanges();

                            Log.WriteLog.Create("ErrorLog", $"Log DateTime: {DateTime.Now}, File Name:{pdfFileName}, Error Message:{pdfResult.ErrorMessage}", out _);
                        }
                        catch (Exception ex)
                        {
                            Log.WriteLog.Create("ErrorLog", $"Log DateTime: {DateTime.Now}, File Name:{pdfFileName}, Error Message:{ex.Message}", out _);
                        }
                    }
                }

                await FileDetailsHelper.FileDirectoryDispatchDoneAsync(fileDirectoryID);

                count++;
                double value = ((double)count / totalRecords) * 100;
                percentage = Convert.ToInt32(Math.Round(value, 0));
                Thread.Sleep(50);
                if (!worker.CancellationPending)
                {
                    worker.ReportProgress(percentage);
                }
            }
            await FileDetailsHelper.DirectoriesDispatchDoneAsync(DirectoryID);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker = sender as BackgroundWorker;
            // Ensure async pipeline completes before DoWork returns
            ProcessStartAsync(SelectedFileIDList, e).GetAwaiter().GetResult();
            worker.ReportProgress(0);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
            {
                tsProgressBar.Visible = true;
                lblPercentage.Visible = true;
            }

            tsProgressBar.Value = e.ProgressPercentage;
            lblPercentage.Text = (e.ProgressPercentage.ToString()) + " %";
        }

        private async void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblPercentage.Visible = true;
            if (e.Cancelled == true)
            {
                lblPercentage.Text = "Canceled!";
                statusStrip.Refresh();
            }
            else if (e.Error != null)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Error: " + e.Error.Message;
                statusStrip.Refresh();
            }
            else
            {
                lblPercentage.Text = "Please Wait...";
                lblPercentage.Text = "Done!";
                statusStrip.Refresh();
                tsProgressBar.Visible = false;
                MessageBox.Show("Data Dispatched sucessfully!", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblPercentage.Text = "";
                lblErrorMessage.Visible = false;
            }
            btnClose.Text = "&Close";
            btnProcess.Enabled = true;
            totalRecords = 0;
            count = 0;
            processDT = null;


            watch.Stop();
            TimeSpan timeTaken = watch.Elapsed;
            lblTimeTaken.Visible = true;
            lblTimeTakenLable.Visible = true;
            lblTimeTaken.Text = timeTaken.ToString(@"hh\:mm\:ss");
            await LoadDirectoryAsync();
            if (cobBatch.Items.Count > 0)
            {
                cobBatch.SelectedIndex = 0;
            }
        }

        private async void cobBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobBatch.SelectedValue == null || string.IsNullOrEmpty(cobBatch.SelectedValue.ToString()))
            {
                MessageBox.Show(this, "Please select batch first.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime scanDate;
            if (DateTime.TryParse(cobBatch.SelectedValue.ToString(), out scanDate))
            {
                LoadFiles(scanDate);
            }
            else
            {
                MessageBox.Show(this, "Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Trigger filtering manually when user clicks Search
            if (cobBatch.SelectedValue == null || string.IsNullOrEmpty(cobBatch.SelectedValue.ToString()))
            {
                MessageBox.Show(this, "Please select batch first.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DateTime.TryParse(cobBatch.SelectedValue.ToString(), out var scanDate))
            {
                LoadFiles(scanDate); // LoadFiles already applies txtSearch filter
            }
        }

        private async void LoadFiles(DateTime scanDate)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            int directoryID = await _db.Directories.AsNoTracking().Where(x => x.Name == cobBatch.SelectedValue)
                .Select(x => x.ID).FirstOrDefaultAsync();
            DirectoryID = directoryID;
            var fileList = await new FileDirectoryHelper(_dbContext, _cache, _translationService).GetFileDirectories(directoryID, CallingFor.Dipatch);

            // Apply search filter if any text entered
            var searchText = txtSearch?.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                fileList = fileList
                    .Where(f => !string.IsNullOrEmpty(f.Name) && f.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (fileList.Count > 0)
            {
                lstFiles.DataSource = null;
                lstFiles.DataSource = fileList;
                lstFiles.DisplayMember = "Name";
                lstFiles.ValueMember = "ID";
                chkAll.Enabled = true;
            }
            else
            {
                chkAll.Enabled = false;
                lstFiles.DataSource = null;
            }
        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (chkAll.Checked)
            {
                for (int i = 0; i < lstFiles.Items.Count; i++)
                {
                    lstFiles.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < lstFiles.Items.Count; i++)
                {
                    lstFiles.SetItemChecked(i, false);
                }
            }
            Cursor = Cursors.Default;
        }
    }

    internal class CaseDirectoryShortDetailsVM
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public int CaseDetailsID { get; set; }
        public int? UpdateByClientID { get; set; }
    }
}









































