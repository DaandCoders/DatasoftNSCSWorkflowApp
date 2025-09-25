
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
    public partial class DrawingLayoutControl : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;
        private readonly string _loggedInUsername;
        private readonly int _departmentId;
        private readonly int _sectionId;
        private readonly int _subSectionId;
        public DrawingLayoutControl(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, string loggedInUsername, int departmentId, int sectionId, int subSectionId)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _loggedInUsername = loggedInUsername;
            _departmentId = departmentId;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            _sectionId = sectionId;
            _subSectionId = subSectionId;
            //txtReceivedBy.Text = _loggedInUsername;
        }
        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string layoutnumber = txtLayoutNumber.Text.Trim();
            string revenuevillage = txtRevenueVillage.Text.Trim();
            string khasranumber = txtKhasraNumber.Text.Trim();
            var isBarCodeExists = _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).Count();
            if (isBarCodeExists > 0)
            {
                MessageBox.Show("Kindly enter the unique barcode this barcode is already exists", "Error", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(layoutnumber) || string.IsNullOrWhiteSpace(revenuevillage) || string.IsNullOrWhiteSpace(khasranumber))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var fileDetail = new FileDetail
            {
                DepartmentID = _departmentId,
                SectionID = _sectionId,
                Barcode=txtBarcode.Text,
                SubSectionID = _subSectionId,
                LayoutNumber = txtLayoutNumber.Text,
                RevenueVillage = revenuevillage,
                KhasraNo = khasranumber,
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
                _db.FileDetails.Add(fileDetail);
                _db.SaveChanges();
                MessageBox.Show("Record Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtLayoutNumber.Text = string.Empty;
            txtRevenueVillage.Text = string.Empty;
            txtKhasraNumber.Text = string.Empty;
            txtBarcode.Clear();
        }

        private async void DrawingLayoutControl_Load(object sender, EventArgs e)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var username = _db.ApplicationUsers.Where(x => x.ID == AppUser.ID).Select(x => x.UserName).FirstOrDefault();
            txtReceivedBy.Text = username;
        }
    }
}

