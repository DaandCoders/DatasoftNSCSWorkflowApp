
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
    public partial class FileReceiveLandAcquisition : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;
        private readonly int _loggedInUserId; // Store logged-in user's ID
        private readonly string _loggedInUserName; // Store logged-in username
        private readonly string _selectedDepartment; // Store selected department
        public FileReceiveLandAcquisition(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, int loggedInUserId, string selectedDepartment)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _loggedInUserId = AppUser.ID;
            _selectedDepartment = selectedDepartment; // Store selected department
            // Fetch username based on the logged-in user ID
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
          
            txtReceivedBy.Text = _loggedInUserName; // Display username in the textbox
            txtReceivedBy.ReadOnly = true; // Prevent manual editing
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string fileNumber = txtFileNumber.Text.Trim();
            int year = int.TryParse(mtbYear.Text.Trim(), out int parsedYear) ? parsedYear : 0;
            await using var _db = await _dbContext.CreateDbContextAsync();
            var isBarCodeExists = _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).Count();
            if (isBarCodeExists > 0)
            {
                MessageBox.Show("Kindly enter the unique barcode this barcode is already exists", "Error", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(fileNumber) || year == 0)
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
                Year = year,
                Barcode = txtBarcode.Text,
                Department = departmentEntity,
                CreatedBy = AppUser.ID, // Store the logged-in user's ID
                UpdatedBy = _loggedInUserId, // Store the logged-in user's ID
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
            txtFileNumber.Clear();
            mtbYear.Clear();
            txtBarcode.Clear();
        }

        private void FileReceiveLandAcquisition_Load(object sender, EventArgs e)
        {

        }
    }
}
