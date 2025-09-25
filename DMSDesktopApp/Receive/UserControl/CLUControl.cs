
using DC.DMS.Services.Models.Main;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWorkflow
{
    public partial class CLUControl : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;
        private readonly string _loggedInUsername;
        private readonly int _departmentId;
        private readonly int _sectionId;
        private readonly int _subSectionId;
        public CLUControl(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, string loggedInUsername, int departmentId, int sectionId, int subSectionId)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _loggedInUsername = loggedInUsername;
            _departmentId = departmentId;
            _sectionId = sectionId;
            _subSectionId = subSectionId;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            txtReceivedBy.Text = _loggedInUsername;

            // Initialize Scheme Type Dropdown
            cmbSchemeType.Items.Add("--Choose Scheme Type--");
            cmbSchemeType.Items.Add("Scheme");
            cmbSchemeType.Items.Add("Non-Scheme");
            cmbSchemeType.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string cluNumber = txtCLUNumber.Text.Trim();
            string applicantName = txtApplicantName.Text.Trim();
            string plotNumber = txtPlotNumber.Text.Trim();
            string schemeType = cmbSchemeType.SelectedItem?.ToString() ?? "";
            var isBarCodeExists = _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).Count();
            if (isBarCodeExists > 0)
            {
                MessageBox.Show("Kindly enter the unique barcode this barcode is already exists", "Error", MessageBoxButtons.OK);
                return;
            }
            // Validation
            if (string.IsNullOrWhiteSpace(cluNumber) ||
                string.IsNullOrWhiteSpace(applicantName) ||
                string.IsNullOrWhiteSpace(plotNumber) ||
                schemeType == "--Choose Scheme Type--")
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Convert Scheme Type to Boolean (0 = Scheme, 1 = Non-Scheme)
            bool isScheme = schemeType == "Scheme" ? false : true;

            // Get the user ID of the logged-in user
            int? createdByUserId = _db.ApplicationUsers
                .Where(u => u.UserName == _loggedInUsername)
                .Select(u => u.ID)
                .FirstOrDefault();

            if (createdByUserId == null)
            {
                MessageBox.Show("Logged-in user not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Save record to the database
            var fileDetail = new FileDetail
            {
                DepartmentID = _departmentId,
                SectionID = _sectionId,
                Barcode = txtBarcode.Text,
                SubSectionID = _subSectionId == 0 ? null : _subSectionId,
                CLUNumber = txtCLUNumber.Text,
                NameOfApplicant = applicantName,
                PlotNumber = plotNumber,
                IsScheme = isScheme,

                A1Count = (int)numA1.Value,
                A2Count = (int)numA2.Value,
                A3Count = (int)numA3.Value,
                A4Count = (int)numA4.Value,

                CreatedBy = AppUser.ID,
                UpdatedBy = AppUser.ID,
                CreatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync(),
                Status = DC.DMS.Services.Enum.WorkflowEnums.Status.FileReceive
            };

            try
            {
                _db.FileDetails.Add(fileDetail);
                _db.SaveChanges();
                MessageBox.Show("CLU Record Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after saving
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtCLUNumber.Clear();
            txtApplicantName.Clear();
            txtBarcode.Clear();
            txtPlotNumber.Clear();
            cmbSchemeType.SelectedIndex = -1;
        }

        private async void CLUControl_Load(object sender, EventArgs e)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var username = _db.ApplicationUsers.Where(x => x.ID == AppUser.ID).Select(x => x.UserName).FirstOrDefault();
            txtReceivedBy.Text = username;
        }
    }
}
