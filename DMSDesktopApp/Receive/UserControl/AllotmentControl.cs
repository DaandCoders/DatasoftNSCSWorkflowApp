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
using System.Web;
using System.Windows.Forms;

namespace CoreWorkflow
{
    public partial class AllotmentControl : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;
        private readonly string _loggedInUsername;
        private readonly int _departmentId;
        private readonly int _sectionId;
        private readonly int _subSectionId;
        public AllotmentControl(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, string loggedInUsername, int departmentId, int sectionId, int subSectionId)
        {
            InitializeComponent();
            //_dbContext = dbContext;
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _loggedInUsername = loggedInUsername;
            _departmentId = departmentId;
            _sectionId = sectionId;
            _subSectionId = subSectionId;
            txtReceivedBy.Text = _loggedInUsername;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string applicantName = txtApplicantName.Text.Trim();
            string schemename = txtSchemeName.Text.Trim();
            string sectornumber = txtSectorNumber.Text.Trim();
            string plotNumber = txtPlotNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(applicantName) || string.IsNullOrWhiteSpace(schemename) ||
        string.IsNullOrWhiteSpace(sectornumber) || string.IsNullOrWhiteSpace(plotNumber))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await using var _db = await _dbContext.CreateDbContextAsync();
            int? createdByUserId = _db.ApplicationUsers
                .Where(u => u.UserName == _loggedInUsername)
                .Select(u => u.ID)
                .FirstOrDefault();
            if (createdByUserId == null)
            {
                MessageBox.Show("Logged-in user not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var isBarCodeExists = _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).Count();
            if (isBarCodeExists > 0)
            {
                MessageBox.Show("Kindly enter the unique barcode this barcode is already exists", "Error", MessageBoxButtons.OK);
                return;
            }
            var fileDetail = new FileDetail
            {

                DepartmentID = _departmentId,
                SectionID = _sectionId,
                Barcode = txtBarcode.Text,
                SubSectionID = _subSectionId == 0 ? null : _subSectionId,
                NameOfApplicant = applicantName,
                SchemeName = schemename,
                SectorNumber = txtSectorNumber.Text,
                PlotNumber = plotNumber,

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
                MessageBox.Show("Record Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            txtApplicantName.Clear();
            txtSchemeName.Clear();
            txtSectorNumber.Clear();
            txtPlotNumber.Clear();
            txtBarcode.Clear();
        }

        private async void AllotmentControl_Load(object sender, EventArgs e)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var username = _db.ApplicationUsers.Where(x => x.ID == AppUser.ID).Select(x => x.UserName).FirstOrDefault();
            txtReceivedBy.Text = username;
        }
    }
}
