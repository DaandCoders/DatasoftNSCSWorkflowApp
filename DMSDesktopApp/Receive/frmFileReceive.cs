
using CoreWorkflow;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DMS.DesktopApp.Receive
{
    public partial class frmFileReceieve : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private readonly int _loggedInUserId;
        public frmFileReceieve(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _loggedInUserId = 1;
            LoadDepartmentsAsync();
        }
        private async void LoadDepartmentsAsync()
        {
            cmbDepartments.Items.Clear();
            cmbDepartments.Items.Add("---Choose Department---");
            try
            {
                await using var _db = await _dbContext.CreateDbContextAsync();
                var departments = _db.MasterDepartments.Select(d => d.Name).ToList();
                cmbDepartments.Items.AddRange(departments.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
            cmbDepartments.SelectedIndex = 0;
            cmbDepartments.SelectedIndexChanged += cmbDepartments_SelectedIndexChanged;
        }
        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartments.SelectedIndex > 0)
            {
                LoadFileReceivePage(cmbDepartments.SelectedItem.ToString());
            }
        }
        private async void LoadFileReceivePage(string department)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            panelContainer.Controls.Clear();
            UserControl fileReceivePage = null;
            int selectedDepartmentId = _db.MasterDepartments
        .Where(d => d.Name == department)
        .Select(d => d.ID)
        .FirstOrDefault();

            switch (department)
            {
                case "Technical":
                    fileReceivePage = new FileReceiveTechnical(_dbContext,_cache,_translationService, department);
                    break;
                case "Regularization":
                    fileReceivePage = new FileReceiveRegularization(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                case "Land Aquisition":
                    fileReceivePage = new FileReceiveLandAcquisition(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                case "Plot":
                    fileReceivePage = new FileReceivePlot(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                case "Housing":
                    fileReceivePage = new FileReceiveHousing(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                case "Planning":
                    fileReceivePage = new FileReceivePlanning(_dbContext, _cache, _translationService, department);
                    break;
                case "Legal":
                    fileReceivePage = new FileReceiveLegal(_dbContext, _cache, _translationService,department);
                    break;
            }
            if (fileReceivePage != null)
            {
                fileReceivePage.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(fileReceivePage);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
