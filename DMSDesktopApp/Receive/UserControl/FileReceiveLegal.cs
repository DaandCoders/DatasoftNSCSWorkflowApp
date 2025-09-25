
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
    public partial class FileReceiveLegal : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private readonly ServerDateTimeHelper serverDateTimeHelper;
        private readonly int _loggedInUserId; // Store logged-in user's ID
        private readonly string _loggedInUserName; // Store logged-in username
        private readonly string _selectedDepartment; // Store selected department
        public FileReceiveLegal(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, string selectedDepartment)
        {
            InitializeComponent();
            _dbContext = dbContext;
            LoadCourtNames();
            _loggedInUserId = AppUser.ID;
            _selectedDepartment = selectedDepartment; // Store selected department
            // Fetch username based on the logged-in user ID
         
            txtReceivedBy.Text = _loggedInUserName; // Display username in the textbox
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            txtReceivedBy.ReadOnly = true;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            _selectedDepartment = selectedDepartment;
        }
        private async void LoadCourtNames()
        {
            cmbCourtName.DataSource = null;
            cmbCourtName.Items.Clear();
            await using var _db = await _dbContext.CreateDbContextAsync();
            var courts = _db.MasterCourts.ToList(); // Fetch courts from the database

            if (courts == null || courts.Count == 0)
            {
                MessageBox.Show("No courts found in the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            List<KeyValuePair<int, string>> courtList = new List<KeyValuePair<int, string>>();
            courtList.Add(new KeyValuePair<int, string>(0, "---Select Court---"));

            foreach (var court in courts)
            {
                courtList.Add(new KeyValuePair<int, string>(court.ID, court.Name));
            }

            // Bind to ComboBox
            cmbCourtName.DataSource = new BindingSource(courtList, null);
            cmbCourtName.DisplayMember = "Value";
            cmbCourtName.ValueMember = "Key";
            cmbCourtName.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCourtName.SelectedIndex == 0 || cmbCourtName.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid Court.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await using var _db = await _dbContext.CreateDbContextAsync();
            var isBarCodeExists = _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).Count();
            if (isBarCodeExists > 0)
            {
                MessageBox.Show("Kindly enter the unique barcode this barcode is already exists", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!int.TryParse(cmbCourtName.SelectedValue.ToString(), out int selectedCourtId))
            {
                MessageBox.Show("Invalid Court selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string caseNumber = txtCaseNumber.Text.Trim();
            var caseYear = mtbYear.Text;
            string caseTitle = txtCaseTitle.Text.Trim();
            //int barCode = int.TryParse(txtBarcode.Text.Trim(), out int parsedBarcode) ? parsedBarcode : 0;

            //if (caseYear == 0 || string.IsNullOrWhiteSpace(caseTitle))
            //{
            //    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            var departmentEntity = _db.MasterDepartments.FirstOrDefault(d => d.Name == _selectedDepartment);
            if (departmentEntity == null)
            {
                MessageBox.Show("Selected department not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            FileDetail newFile = new FileDetail
            {
                CaseNo =txtCaseNumber.Text,
                CaseYear = caseYear,
                CaseTitle = caseTitle,
                CourtID = selectedCourtId,
                Barcode = txtBarcode.Text.ToString(),
                Department = departmentEntity,
                CreatedBy = AppUser.ID,
                UpdatedBy = AppUser.ID,
                A1Count = (int)numA1.Value,
                A2Count = (int)numA2.Value,
                A3Count = (int)numA3.Value,
                A4Count = (int)numA4.Value,
                CreatedDateTime =await serverDateTimeHelper.GetCurrentDateTimeAsync(),
                Status = DC.DMS.Services.Enum.WorkflowEnums.Status.FileReceive
            };

            try
            {
                _db.FileDetails.Add(newFile);
                _db.SaveChanges();
                MessageBox.Show("Record Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtCaseNumber.Clear();
            mtbYear.Clear();
            txtCaseTitle.Clear();
            txtBarcode.Clear();
        }

        private void FileReceiveLegal_Load(object sender, EventArgs e)
        {

        }
    }
}

