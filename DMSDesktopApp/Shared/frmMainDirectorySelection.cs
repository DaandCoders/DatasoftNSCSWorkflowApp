
using DMS.Context.Data;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Scan;
using DC.DMS.Services.Property;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;
using Microsoft.EntityFrameworkCore;



namespace DMS.DesktopApp.Shared
{
    public partial class frmMainDirectorySelection : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        DirectoryHelper DirectoryHelper;
        CallingFor CallingFor;
        int MainDirectoryID = 0;
        FileDetailHelper CaseDetailHelper;
        public frmMainDirectorySelection(CallingFor callingFor, IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {


            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            DirectoryHelper = new DirectoryHelper(_dbContext, _cache, _translationService);
            CaseDetailHelper = new FileDetailHelper(_dbContext);
            CallingFor = callingFor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool IsFormValid(out string message)
        {
            message = null;
            if (message != null)
                return false;
            else
                return true;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!IsFormValid(out string message))
            {
                Cursor = Cursors.Default;
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int selectedValue = Convert.ToInt32(cobScanDate.SelectedValue);
            string fileName = String.Empty;
            switch (CallingFor)
            {
                case CallingFor.Scanning:
                    string scanDate = Convert.ToDateTime(cobScanDate.Text).ToString("yyyy-MM-dd");
                    frmScan frmScan = new frmScan(scanDate, _dbContext, _cache, _translationService);
                    frmScan.ShowDialog();
                    break;
                case CallingFor.QC:
                    frmImageQC imageQC = new frmImageQC(selectedValue, _dbContext, _cache, _translationService);
                    imageQC.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private async void frmMainDirectorySelection_Load(object sender, EventArgs e)
        {
            if (CallingFor == CallingFor.Scanning)
            {
                var recivingList = await CaseDetailHelper.GetRecivingDateForSelection();
                cobScanDate.DataSource = recivingList;
                cobScanDate.DisplayMember = "CreateDate";
                cobScanDate.ValueMember = "ID";
            }
            else
            {
                var directoryList = await DirectoryHelper.GetDirectoriesForSelection();
                cobScanDate.DataSource = directoryList;
                cobScanDate.DisplayMember = "Name";
                cobScanDate.ValueMember = "ID";
            }
            //LoadCourtNameAsync();
            LoadFileStatus();
        }
        private async Task LoadCourtNameAsync()
        {
            try
            {
                // var courtNameList = await CaseDetailHelper.GetAllCourtNameAsync();
                //var courtList = courtNameList.Select(x => new { x.ID, x.Name }).ToList();
                // cobCourtName.DataSource = courtList;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void LoadFileStatus()
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void cobScanDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int scanDateValue = Convert.ToInt32(cobScanDate.SelectedValue);
                if (CallingFor == CallingFor.Scanning)
                {
                    MainDirectoryID = scanDateValue;
                    lblTotalFileRemaining.Text = $"Total files are remaining for Scan: {await DirectoryHelper.GetRemainingFilesCount(MainDirectoryID, CallingFor.Scanning)}";
                }
                else
                {
                    
                    if (scanDateValue != 0)
                    {
                        MainDirectoryID = scanDateValue;
                        lblTotalFileRemaining.Text = $"Total files are remaining for QC: {await DirectoryHelper.GetRemainingFilesCount(MainDirectoryID, CallingFor.QC)}"; 
                    }
                }
                lblTotalFileRemaining.Refresh();
            }
            catch (Exception ex)
            {
            }
        }

        private void cobScanDate_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void cobScanDate_Click(object sender, EventArgs e)
        {

        }
    }
}
