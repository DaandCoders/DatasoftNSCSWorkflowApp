using AxAcroPDFLib;
using DC.DMS.Services.ViewModels;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Controls;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS.DesktopApp.QCClient
{
    public partial class frmClientQC : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private int SelectedDepartmentID = 0;
        private string? SelectedDepartmentName = null;
        private int SelectedBatchID = 0;
        private string? SelectedBatchName = null;

        UserControl fileReceivePage = null;
        MasterHelper MasterHelpers;
        RejectsHelper ReamrkHelpers;

        public frmClientQC(int departmentID, string departmentName, IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            SelectedDepartmentID = departmentID;
            SelectedDepartmentName = departmentName;
            MasterHelpers = new MasterHelper(_dbContext);
            ReamrkHelpers = new RejectsHelper(_dbContext);
            InitializeComponent();

            lblDepartmentName.Text = $"{SelectedDepartmentName} Department";
        }

        private async void frmClientQC_Load(object sender, EventArgs e)
        {
            await LoadAllRemarks();
            await LoadBatches();
            lblCurrentUser.Text = AppUser.CurrentUserName;
        }

        private async Task<bool> LoadAllRemarks()
        {
            var remarks = await ReamrkHelpers.GetAllRemarksAsync();
            if (remarks != null && remarks.Count > 0)
            {
                cobReject.SelectedIndexChanged -= cobReject_SelectedIndexChanged;
                cobReject.DataSource = remarks;
                cobReject.DisplayMember = "Name";
                cobReject.ValueMember = "ID";
                cobReject.SelectedIndex = -1;
                cobReject.SelectedIndexChanged += cobReject_SelectedIndexChanged;
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> LoadBatches()
        {
            var departmentAllSections = await MasterHelpers.GetDepartmentAllBatches(SelectedDepartmentID);
            if (departmentAllSections != null && departmentAllSections.Count > 0)
            {
                EnableBatches(true);
                cobBatch.SelectedIndexChanged -= cobBatch_SelectedIndexChanged;
                cobBatch.DataSource = departmentAllSections;
                cobBatch.DisplayMember = "Name";
                cobBatch.ValueMember = "ID";
                cobBatch.SelectedIndex = -1;
                cobBatch.SelectedIndexChanged += cobBatch_SelectedIndexChanged;
                return true;
            }
            else
            {
                EnableBatches(false);
                return false;
            }
        }

        private void EnableBatches(bool v)
        {
            if (cobBatch.InvokeRequired)
            {
                cobBatch.Invoke(new Action(() => cobBatch.Enabled = v));
            }
            else
            {
                cobBatch.Enabled = v;
            }
        }

        private void LoadDefault()
        {
            switch (SelectedDepartmentID)
            {
                //"Technical"
                case 1:
                    //fileReceivePage = new FileReceiveTechnical(_dbContext, _cache, _translationService, department);
                    break;
                //"Regularization"
                case 2:
                    //fileReceivePage = new FileReceiveRegularization(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                //"Land Aquisition"
                case 3:
                    //fileReceivePage = new FileReceiveLandAcquisition(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                //"Plot"
                case 4:
                    //fileReceivePage = new FileReceivePlot(_dbContext, _cache, _translationService, _loggedInUserId, department);
                    break;
                //"Housing"
                case 5:
                    fileReceivePage = new DepartmentHousing(_dbContext, _cache, _translationService, SelectedDepartmentID, SelectedBatchID);
                    break;
                //"Planning"
                case 6:
                    //fileReceivePage = new FileReceivePlanning(_dbContext, _cache, _translationService, department);
                    break;
                //"Legal"
                case 7:
                    //fileReceivePage = new FileReceiveLegal(_dbContext, _cache, _translationService, department);
                    break;
            }

            if (fileReceivePage != null)
            {
                if (fileReceivePage is DepartmentHousing housingPage)
                {
                    housingPage.SubFilesSelectedIndexChanged += HousingPage_SubFilesSelectedIndexChanged;
                    fileReceivePage.Dock = DockStyle.Fill;
                    panDepartmentDetails.Controls.Add(fileReceivePage);
                }

            }
            else
            {
                MessageBox.Show("Error: Unable to load the file receive page for the selected department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void HousingPage_SubFilesSelectedIndexChanged(object sender, EventArgs e)
        {
            var housingPage = sender as DepartmentHousing;
            string? pdfFile = await housingPage.GetFilePath();
            if (!string.IsNullOrEmpty(pdfFile))
                lblLocation.Text = pdfFile;
        }

        private void cobBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobBatch.SelectedItem is DropDownHelper selectedSection)
            {
                SelectedBatchID = selectedSection.ID;
                SelectedBatchName = selectedSection.Name;
                LoadDefault();
            }
            else
            {
                SelectedBatchID = 0;
                SelectedBatchName = null;
                return;
            }
        }

        private void cobReject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reject the file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (fileReceivePage == null)
            {
                MessageBox.Show("Please select a valid batch first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            if (cobReject.SelectedItem is DropDownHelper selectedReject)
            {
                if (fileReceivePage is DepartmentHousing housingPage)
                {
                    await housingPage.RejectFileAsync(selectedReject.ID, txtRemark.Text);
                    
                }
                else
                {
                    MessageBox.Show("Please select a valid file receive page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a reject reason.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor = Cursors.Hand;
        }

        private async void btnQCDone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to mark the QC as done?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                if (fileReceivePage is DepartmentHousing housingPage)
                {
                    await housingPage.MarkQCDoneAsync();
                }
                else
                {
                    MessageBox.Show("Please select a valid file receive page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Hand;
            }
        }

        private async void btnBatchComplete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to mark the batch as complete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                if (fileReceivePage is DepartmentHousing housingPage)
                {
                    await housingPage.MarkBatchCompleteAsync();
                    ClearPdfViewer();

                }
                else
                {
                    MessageBox.Show("Please select a valid file receive page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Hand;
            }

        }
        private void ClearPdfViewer()
        {
            pdfViwer.LoadFile(""); // Unload any loaded PDF
            pdfViwer.Visible = false; // Optionally hide the control
            lblLocation.Text = "";
        }

        private void lblLocation_TextChanged(object sender, EventArgs e)
        {
            string pdfPath = lblLocation.Text;
            if (!string.IsNullOrWhiteSpace(pdfPath) && File.Exists(pdfPath))
            {
                try
                {
                    pdfViwer.Visible = true;
                    pdfViwer.LoadFile(pdfPath);
                    pdfViwer.setView("Fit");
                    pdfViwer.setShowToolbar(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pdfViwer.Visible = false;
            }
        }

        private void lblLocation_DoubleClick(object sender, EventArgs e)
        {
            string dir = Path.GetDirectoryName(lblLocation.Text);
            Directory.CreateDirectory(dir);
            if (!string.IsNullOrEmpty(lblLocation.Text))
            {
                Process.Start("explorer.exe", dir);
            }
        }
    }
}
