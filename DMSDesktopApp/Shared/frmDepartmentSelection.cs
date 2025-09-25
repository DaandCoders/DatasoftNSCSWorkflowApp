
using DMS.Context.Data;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Scan;
using DC.DMS.Services.Property;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;
using Microsoft.EntityFrameworkCore;
using DC.DMS.Services.ViewModels;
using DMS.DesktopApp.QCClient;



namespace DMS.DesktopApp.Shared
{
    public partial class frmDepartmentSelection : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;

        DirectoryHelper DirectoryHelper;
        MasterHelper MasterHelper;
        private int SelectedDepartmentID = 0;
        private string? SelectedDepartmentName = null;

        public frmDepartmentSelection(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            DirectoryHelper = new DirectoryHelper(_dbContext, _cache, _translationService);
            MasterHelper = new MasterHelper(_dbContext);
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

            frmClientQC frmClientQC = new frmClientQC(SelectedDepartmentID,SelectedDepartmentName,_dbContext, _cache, _translationService);
            frmClientQC.ShowDialog();
        }

        private async void frmMainDirectorySelection_Load(object sender, EventArgs e)
        {
            var directoryList = await MasterHelper.GetAllDepartments();
            cobSelectDepartment.DataSource = directoryList;
            cobSelectDepartment.DisplayMember = "Name";
            cobSelectDepartment.ValueMember = "ID";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void cobSelectedDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = cobSelectDepartment.SelectedItem as DropDownHelper;
                if (selectedItem != null)
                {
                    SelectedDepartmentID = selectedItem.ID;
                    SelectedDepartmentName = selectedItem.Name;
                }
                else
                {
                    SelectedDepartmentID = 0;
                    SelectedDepartmentName = null;
                }
                lblTotalFileRemaining.Text = $"Total files are remaining for Client QC: {await MasterHelper.GetDepartmentRemainingFileCount(SelectedDepartmentID)}";
                lblTotalFileRemaining.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
