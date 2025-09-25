
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
    public partial class FileReceiveRegularization : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;
        private readonly int _loggedInUserId; // Store logged-in user's ID
        private readonly string _loggedInUserName; // Store logged-in username
        private readonly string _selectedDepartment; // Store selected department
        public FileReceiveRegularization(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, int loggedInUserId, string selectedDepartment)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _loggedInUserId = loggedInUserId;
            _selectedDepartment = selectedDepartment; // Store selected department
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            // Fetch username based on the logged-in user ID
          

            txtReceivedBy.Text = _loggedInUserName; // Display username in the textbox
            txtReceivedBy.ReadOnly = true; // Prevent manual editing
            _selectedDepartment = selectedDepartment;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string fileNumber = txtFileNumber.Text.Trim();
            string revenueVillage = txtRevenueVillage.Text.Trim();
            string khasraNumber = txtKhasraNumber.Text.Trim();
            string plotNumber = txtPlotNumber.Text.Trim();
            string applicantName = txtApplicantName.Text.Trim();
            var isBarCodeExists = _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).Count();
            if (isBarCodeExists > 0)
            {
                MessageBox.Show("Kindly enter the unique barcode this barcode is already exists", "Error", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(fileNumber) || string.IsNullOrWhiteSpace(revenueVillage) || string.IsNullOrWhiteSpace(khasraNumber) || string.IsNullOrWhiteSpace(plotNumber) || string.IsNullOrWhiteSpace(applicantName))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var departmentEntity = _db.MasterDepartments.FirstOrDefault(d => d.Name == _selectedDepartment);
            if (departmentEntity == null)
            {
                MessageBox.Show("Selected department not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FileDetail newFile = new FileDetail
            {
                FileNumber = fileNumber,
                RevenueVillage = revenueVillage,
                Barcode = txtBarcode.Text,
                KhasraNo = khasraNumber,
                PlotNumber = plotNumber,
                NameOfApplicant = applicantName,
                Department = departmentEntity,
                A1Count = (int)numA1.Value,
                A2Count = (int)numA2.Value,
                A3Count = (int)numA3.Value,
                A4Count = (int)numA4.Value,
                CreatedBy = AppUser.ID, // Store the logged-in user's ID
                UpdatedBy = _loggedInUserId, // Store the logged-in user's ID
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
            txtFileNumber.Clear();
            txtRevenueVillage.Clear();
            txtKhasraNumber.Clear();
            txtPlotNumber.Clear();
            txtApplicantName.Clear();
            txtBarcode.Clear(); 
        }

        private void FileReceiveRegularization_Load(object sender, EventArgs e)
        {

        }
    }
}

