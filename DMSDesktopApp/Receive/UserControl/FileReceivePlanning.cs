using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace CoreWorkflow
{
    public partial class FileReceivePlanning : UserControl
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private readonly string _selectedDepartment;
        private readonly string _loggedInUsername;
        public FileReceivePlanning(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService, string selectedDepartment)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            _selectedDepartment = selectedDepartment;
            
            LoadSections();
        }
        private async void LoadSections()
        {
            cmbSection.Items.Clear();
            cmbSection.Items.Add("--Choose Section--");

            try
            {
                await using var _db = await _dbContext.CreateDbContextAsync();
                // Get the DepartmentId using _selectedDepartment
                int departmentId = _db.MasterDepartments
                    .Where(d => d.Name == _selectedDepartment)
                    .Select(d => d.ID)
                    .FirstOrDefault();

                if (departmentId == 0)
                {
                    MessageBox.Show($"Department '{_selectedDepartment}' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Fetch sections based on department
                var sections = _db.MasterSections
                    .Where(s => s.DepartmentID == departmentId)
                    .Select(s => s.Name)
                    .ToList();

                if (sections.Any())
                {
                    cmbSection.Items.AddRange(sections.ToArray());
                }
                else
                {
                    MessageBox.Show($"No sections found for Department '{_selectedDepartment}' (ID: {departmentId})", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSection.Items.Add("No Sections Available");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sections: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbSection.SelectedIndex = 0;
            cmbSubsection.Visible = false;
            lblSubSection.Visible = false;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged;
        }

        private async void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            cmbSubsection.Visible = false;
            lblSubSection.Visible = false;
            cmbSubsection.Items.Clear();
            cmbSubsection.Items.Add("--Choose Subsection--");

            string selectedSection = cmbSection.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedSection) || selectedSection == "--Choose Section--" || selectedSection == "No Sections Available")
            {
                return;
            }

            UserControl userControl = null;

            await using var _db = await _dbContext.CreateDbContextAsync();
            int departmentId = _db.MasterDepartments
                .Where(d => d.Name == _selectedDepartment)
                .Select(d => d.ID)
                .FirstOrDefault();

            if (departmentId == 0)
            {
                MessageBox.Show($"Error: Department '{_selectedDepartment}' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedSection == "Drawing")
            {
                var section = _db.MasterSections
                    .FirstOrDefault(s => s.Name == selectedSection && s.DepartmentID == departmentId);

                if (section == null)
                {
                    MessageBox.Show($"Error: Section '{selectedSection}' not found in department '{_selectedDepartment}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var subsections = _db.MasterSubSections
                    .Where(ss => ss.DepartmentID == departmentId && ss.SectionID == section.ID)
                    .Select(ss => ss.Name)
                    .ToList();

                if (subsections.Any())
                {
                    lblSubSection.Visible = true;
                    cmbSubsection.Visible = true;
                    cmbSubsection.Items.AddRange(subsections.ToArray());
                }

                cmbSubsection.SelectedIndex = 0;
                cmbSubsection.SelectedIndexChanged += cmbSubsection_SelectedIndexChanged;
            }
            else
            {
                // Get the sectionId for the selected section
                int sectionId = _db.MasterSections
                    .Where(s => s.Name == selectedSection && s.DepartmentID == departmentId)
                    .Select(s => s.ID)
                    .FirstOrDefault();

                if (sectionId == 0)
                {
                    MessageBox.Show($"Error: Section '{selectedSection}' not found in department '{_selectedDepartment}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                userControl = selectedSection switch
                {
                    "CLU" => new CLUControl(_dbContext,_cache,_translationService, _loggedInUsername, departmentId, sectionId, 0), // Pass all required parameters
                    "Allotment" => new AllotmentControl(_dbContext, _cache, _translationService, _loggedInUsername, departmentId, sectionId, 0),
                    _ => null
                };
            }

            if (userControl != null)
            {
                LoadUserControl(userControl);
            }
        }

        private async void cmbSubsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            string selectedSubsection = cmbSubsection.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedSubsection) || selectedSubsection == "--Choose Subsection--") return;

            await using var _db = await _dbContext.CreateDbContextAsync();
            int departmentId = _db.MasterDepartments
                .Where(d => d.Name == _selectedDepartment)
                .Select(d => d.ID)
                .FirstOrDefault();

            int sectionId = _db.MasterSections
                .Where(s => s.Name == "Drawing" && s.DepartmentID == departmentId)
                .Select(s => s.ID)
                .FirstOrDefault();

            int subSectionId = _db.MasterSubSections
                .Where(ss => ss.Name == selectedSubsection && ss.DepartmentID == departmentId && ss.SectionID == sectionId)
                .Select(ss => ss.ID)
                .FirstOrDefault();

            if (subSectionId == 0)
            {
                MessageBox.Show($"Error: Subsection '{selectedSubsection}' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserControl userControl = selectedSubsection switch
            {
                "Layout" => new DrawingLayoutControl(_dbContext,_cache,_translationService, _loggedInUsername, departmentId, sectionId, subSectionId),
                "Scheme Approval" => new DrawingSchemeApprovalControl(_dbContext,_cache,_translationService, _loggedInUsername, departmentId, sectionId, subSectionId),
                _ => null
            };

            if (userControl != null)
            {
                LoadUserControl(userControl);
            }
        }

        private void LoadUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(userControl);
        }

        private void FileReceivePlanning_Load(object sender, EventArgs e)
        {

        }
    }
}
