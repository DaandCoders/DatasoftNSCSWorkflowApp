using DC.DMS.Services.Models.Main;
using DC.DMS.Services.ViewModels;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Controls
{
    public partial class DepartmentHousing : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private readonly ServerDateTimeHelper serverDateTimeHelper;
        private readonly FileDetailHelper FileDetailsHelper;
        private readonly int SelectedDepartmentID;
        private readonly int SelectedBatchID;

        private int SelectedFileID = 0;
        private string? SelectedFileName = null;
        private int SelectedSubFileID = 0;
        private string? SelectedSubFileName = null;

        MasterHelper MasterHelper;
        ClientRejectHelper ClientRejectHelper;
        public event EventHandler SubFilesSelectedIndexChanged;


        public DepartmentHousing(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, int departmentID, int batchID)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            SelectedDepartmentID = departmentID;
            SelectedBatchID = batchID;
            MasterHelper = new MasterHelper(_dbContext);
            ClientRejectHelper = new ClientRejectHelper(_dbContext);
            FileDetailsHelper = new FileDetailHelper(_dbContext);
        }

        private async void FileReceiveHousing_Load(object sender, EventArgs e)
        {
            lblReceivedBy.Text = AppUser.CurrentUserName;
            await LoadFiles();
        }

        private async Task<bool> LoadFiles()
        {
            var departmentAllSections = await MasterHelper.GetDepartmentAllFiles(SelectedDepartmentID, SelectedBatchID);
            if (departmentAllSections != null && departmentAllSections.Count > 0)
            {
                EnableFiles(true);
                cobFiles.SelectedIndexChanged -= cobFiles_SelectedIndexChanged;
                cobFiles.DataSource = departmentAllSections;
                cobFiles.DisplayMember = "Name";
                cobFiles.ValueMember = "ID";
                cobFiles.SelectedIndex = -1;
                cobFiles.SelectedIndexChanged += cobFiles_SelectedIndexChanged;
                cobFiles.SelectedIndex = 0;
                return true;
            }
            else
            {
                cobFiles.DataSource = null;
                cobSubFiles.DataSource = null;
                EnableFiles(false);
                return false;
            }
        }

        private void EnableFiles(bool v)
        {
            if (cobFiles.InvokeRequired)
            {
                cobFiles.Invoke(new Action(() => cobFiles.Enabled = v));
            }
            else
            {
                cobFiles.Enabled = v;
            }
        }

        private async void cobFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobFiles.SelectedItem is DropDownHelper selectedSection)
            {
                SelectedFileID = selectedSection.ID;
                SelectedFileName = selectedSection.Name;

                await SubDirectories();
            }
            else
            {
                SelectedFileID = 0;
                SelectedFileName = null;
                return;
            }
        }

        private async Task<bool> SubDirectories()
        {
            var subfiles = await MasterHelper.GetDepartmentAllSubFiles(SelectedFileID);
            if (subfiles != null && subfiles.Count > 0)
            {
                EnableFiles(true);
                cobSubFiles.SelectedIndexChanged -= cobSubFiles_SelectedIndexChanged;
                cobSubFiles.DataSource = subfiles;
                cobSubFiles.DisplayMember = "Name";
                cobSubFiles.ValueMember = "ID";
                cobSubFiles.SelectedIndex = -1;
                cobSubFiles.SelectedIndexChanged += cobSubFiles_SelectedIndexChanged;
                cobSubFiles.SelectedIndex = 0;
                return true;
            }
            else
            {
                cobSubFiles.DataSource = null;
                EnableFiles(false);
                return false;
            }
        }

        private async Task<bool> LoadData()
        {
            var file = await FileDetailsHelper.GetFileDetailsByFileDirectoryAsync(SelectedFileID);
            if (file != null)
            {
                lblFileNumber.Text = file.FileNumber;
                lblAllotteName.Text = file.AllotteeName;
                lblYear.Text = file.Year?.ToString() ?? string.Empty;
                lblBarcode.Text = file.Barcode;
                lblReceivedBy.Text = file.CreateByUser?.UserName ?? string.Empty;
                lblA4Size.Text = file.A1Count.ToString();
                lblA3Size.Text = file.A2Count.ToString();
                lblA4Size.Text = file.A3Count.ToString();
                lblA2Size.Text = file.A4Count.ToString();
                lblA1Size.Text = file.A1Count.ToString();
                lblReceivedDate.Text = file.CreatedDateTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? string.Empty;
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void cobSubFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cobSubFiles.SelectedItem is DropDownHelper selectedSection)
            {
                SelectedSubFileID = selectedSection.ID;
                SelectedSubFileName = selectedSection.Name;

                await LoadData();
                SubFilesSelectedIndexChanged?.Invoke(this, e);
            }
            else
            {
                SelectedSubFileID = 0;
                SelectedSubFileName = null;
                return;
            }
        }
        public async Task<string?> GetFilePath()
        {
            if (SelectedSubFileID <= 0)
            {
                MessageBox.Show("Please select a valid sub-file.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            var filePathResult = await new DispatchPDF(_dbContext).GetFilePath(SelectedSubFileID);

            if (!filePathResult.isSuccess)
            {
                return null;
            }

            if (!File.Exists(filePathResult.Path))
            {
                MessageBox.Show("File path not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return filePathResult.Path;
        }

        public async Task<bool> RejectFileAsync(int rejectID, string rejectReason)
        {
            if (SelectedSubFileID <= 0)
            {
                MessageBox.Show("Please select a valid sub-file.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Status rejectionOn = Status.None;
            switch (rejectID)
            {
                case 1:// Rejected in QC 
                    rejectionOn = Status.RejectedInQC;
                    break;
                case 2:// Rejected in Metadata
                    rejectionOn = Status.RejectedInMetadata;
                    break;
                case 3: // Rejected in Scanning
                    rejectionOn = Status.RejectedInScanning;
                    break;
                case 4: // Rejected in Disptch
                    rejectionOn = Status.RejectedInDispatch;
                    break;
                default:
                    break;
            }

            ClientReject clientReject = new ClientReject();
            clientReject.SubDirectoryID = SelectedSubFileID;
            clientReject.RejectID = rejectID;
            clientReject.FileDetailID =  (await new FileDetailHelper(_dbContext).GetFileDetailsByFileDirectoryAsync(SelectedFileID)).ID;
            clientReject.Remark = rejectReason;
            clientReject.Status = rejectionOn;
            clientReject.Flag = Flag.Active;
            clientReject.CreateBy = AppUser.ID;


            var result = await ClientRejectHelper.SaveClientRejectAsync(clientReject);
            if (result.IsSuccess)
            {

                var statusResult = await new DataHelper(_dbContext).ChangesStatusByClient(SelectedFileID, SelectedSubFileID, rejectionOn);
                if (statusResult.IsSuccess)
                {
                    await LoadFiles();
                }
                else
                {
                    MessageBox.Show(statusResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                MessageBox.Show("File rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to reject the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public async Task<bool> MarkQCDoneAsync()
        {
            if (SelectedSubFileID <= 0)
            {
                MessageBox.Show("Please select a valid sub-file.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var statusResult = await new DataHelper(_dbContext).ChangesStatusByClient(SelectedFileID, SelectedSubFileID, Status.QCDoneByClient);
            if (statusResult.IsSuccess)
            {
                await LoadFiles();
                MessageBox.Show("QC done successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(statusResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> MarkBatchCompleteAsync()
        {
            if (SelectedBatchID <= 0)
            {
                MessageBox.Show("Please select a valid batch.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var statusResult = await new DataHelper(_dbContext).ChangesStatusByClient(SelectedFileID, SelectedSubFileID, Status.QCDoneByClient, SelectedBatchID);
            if (statusResult.IsSuccess)
            {
                await LoadFiles();
                MessageBox.Show("Batch marked as complete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(statusResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
