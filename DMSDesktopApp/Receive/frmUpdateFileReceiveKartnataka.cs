using DMS.Context.Data;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;

namespace DMS.DesktopApp.Receive
{
    public partial class frmUpdateFileReceiveKartnataka : Form
    {
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
       // private CaseTypeHelper CaseTypeHelper;
        private FileDetailHelper CaseDetailHelper;
        private
        int CaseDetailID = 0;
        public frmUpdateFileReceiveKartnataka(ApplicationDbContext dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _db = dbContext;
            _cache = cache;
            _translationService = translationService;
           // CaseTypeHelper = new CaseTypeHelper();
            //CaseDetailHelper = new CaseDetailHelper();
        }
        private bool IsFormValid(out string message)
        {
            message = null;
            if (cobCaseType.SelectedIndex == -1)
            {
                message = "Case Type is required.";
            }
            else if (string.IsNullOrEmpty(txtCaseNo.Text))
            {
                message = "Case Number is required";
            }
            else if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                message = "Barcode is required";
            }
            else if (string.IsNullOrEmpty(txtYear.Text))
            {
                message = "Case Year is required";
            }
            else if (cobFileType.SelectedIndex == -1)
            {
                message = "File Type is required";
            }
            else if (cobFileStatus.SelectedIndex == -1)
            {
                message = "File Status is required";
            }
            if (message != null)
                return false;
            else
                return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //if (!IsFormValid(out string message))
            //{
            //    MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            //var courtEstablishmentID = _db.CourtEstablishmentMasters.Where(x => x.ESTCode == cobCourtEstablishment.SelectedValue).Select(x => x.ID).FirstOrDefault();
            //FileDetail caseDetail = new FileDetail();
            //caseDetail.Barcode = txtBarcode.Text;
            //caseDetail.CaseNumber = txtCaseNo.Text;
            //caseDetail.Status = WorkflowEnums.Status.FileReceive;
            //caseDetail.CourtEstablishmentID = courtEstablishmentID;

            //caseDetail.CaseTypeID = Convert.ToInt32(cobCaseType.SelectedValue);
            //caseDetail.CaseYear = Convert.ToInt32(txtYear.Text);
            //caseDetail.FileTypeID = (CaseFileType)Convert.ToInt32(cobFileType.SelectedIndex);
            //caseDetail.FileStatusID = (CaseFileStatus)Convert.ToInt32(cobFileStatus.SelectedIndex);
            //caseDetail.DistrictID = Convert.ToInt32(cobDistrict.SelectedValue);
            //caseDetail.CINo = txtCINNo.Text;
            //caseDetail.TotalPages = string.IsNullOrEmpty(txtNoOfPage.Text) == true ? null : Convert.ToInt32(txtNoOfPage.Text);
            //caseDetail.CourtID = Convert.ToInt32(cobCourtName.SelectedValue);
            //caseDetail.CollectedDateTime = DateTime.Now;
            //caseDetail.PetitionerName = txtPetitionerName.Text;
            //caseDetail.PetitionerAdvocate = txtPetitionerAdvocate.Text;
            //caseDetail.RespondentName = txtRespondentName.Text;
            //caseDetail.Advocate = txtRespondentAdvocate.Text;
            //caseDetail.DateOfDecision = string.IsNullOrEmpty(txtDateOfDecision.Text) == true ? null : Convert.ToDateTime(txtDateOfDecision.Text);
            //caseDetail.DateOfRegistration = string.IsNullOrEmpty(txtDateOfRegistration.Text) == true ? null : Convert.ToDateTime(txtDateOfRegistration.Text);
            //caseDetail.Act = txtAct.Text;
            //caseDetail.Section = txtSection.Text;
            //caseDetail.NatureOfDisposalID = Convert.ToInt32(cobNatureOfDisposal.SelectedValue);

            //if (cobFileStatus.Text == "Running")
            //{
            //    var fileVersion = CaseDetailHelper.UpdateRunningFileCount(CaseDetailID);
            //    if (fileVersion > 0)
            //    {
            //        caseDetail.FileVersion = fileVersion;
            //    }
            //}
            //var result = await CaseDetailHelper.CaseDetailUpdateRecordAsync(CaseDetailID, caseDetail, AppUser.ID);
            //if (result.Item1)
            //{
            //    MessageBox.Show(this, "Case detail with case number " + caseDetail.CaseNumber + " Updated Successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ClearFields();
            //    return;
            //}
            //else
            //{
            //    MessageBox.Show(this, "Case detail with case number " + caseDetail.CaseNumber + " failed to update.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private async void frmFileReceive_Load(object sender, EventArgs e)
        {
            await LoadCourtEstablishmentAsync();
            await LoadCaseTypeAsync();
            await LoadFileNameAsync();
            await LoadCourtNameAsync();
            await LoadNatureOfDisposalAsync();
            await LoadDistrictNameAsync();
            LoadFileType();
            LoadFileStatus();
        }

        private async Task LoadCourtEstablishmentAsync()
        {
            //try
            //{
            //    var courtEstablishmentList = await new CourtEstablishmentHelper().GetAllCourtEstablishmentAsync();
            //    var caseList = courtEstablishmentList.Select(x => new { x.ESTCode, x.CourtEstablishmentName }).ToList();
            //    cobCourtEstablishment.SelectedIndexChanged -= cobCourtEstablishment_SelectedIndexChanged;
            //    cobCourtEstablishment.DataSource = caseList;
            //    cobCourtEstablishment.DisplayMember = "CourtEstablishmentName";
            //    cobCourtEstablishment.ValueMember = "ESTCode";
            //    cobCourtEstablishment.SelectedIndex = Settings.Default.DefaultCaseTypeIndex;
            //    cobCourtEstablishment.SelectedIndexChanged += cobCourtEstablishment_SelectedIndexChanged;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }

        private void ClearFields()
        {
            txtCaseNo.Clear();
            cobFileName.SelectedIndex = -1;
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void LoadFileType()
        {
            //cobFileType.DataSource = Enum.GetValues(typeof(CaseFileType));
            //cobFileType.SelectedIndex = -1;

        }
        private void LoadFileStatus()
        {
            //cobFileStatus.DataSource = Enum.GetValues(typeof(CaseFileStatus));
            //cobFileStatus.SelectedIndex = -1;

        }
        private async Task LoadCaseTypeAsync()
        {
            try
            {
                //var caseTypeList = await CaseTypeHelper.GetAllCaseTypeAsync();
                //var caseList = caseTypeList.Select(x => new { x.ID, x.Name }).ToList();
                //cobCaseType.SelectedIndexChanged -= cobCaseType_SelectedIndexChanged;
                //cobCaseType.DataSource = caseList;
                //cobCaseType.DisplayMember = "Name";
                //cobCaseType.ValueMember = "ID";
                //cobCaseType.SelectedIndex = Settings.Default.DefaultCaseTypeIndex;
                //cobCaseType.SelectedIndexChanged += cobCaseType_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task LoadFileNameAsync()
        {
            try
            {
                //var fileNameList = await CaseTypeHelper.GetAllFileNameAsync();
                //var fileList = fileNameList.Select(x => new { x.ID, x.Name }).ToList();
                //cobFileName.SelectedIndexChanged -= cobFileName_SelectedIndexChanged;
                //cobFileName.DataSource = fileList;
                //cobFileName.DisplayMember = "Name";
                //cobFileName.ValueMember = "ID";
                //cobFileName.SelectedIndex = -1;
                //cobFileName.SelectedIndexChanged += cobFileName_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task LoadNatureOfDisposalAsync()
        {
            try
            {
                //var natureOfDisposalList = await CaseDetailHelper.GetAllNatureOfDisposalListAsync();
                //cobNatureOfDisposal.SelectedIndexChanged -= cobNatureOfDisposal_SelectedIndexChanged;
                //cobNatureOfDisposal.DataSource = natureOfDisposalList;
                //cobNatureOfDisposal.DisplayMember = "Name";
                //cobNatureOfDisposal.ValueMember = "ID";
                //cobNatureOfDisposal.SelectedIndex = Settings.Default.DefaultCaseTypeIndex;
                //cobNatureOfDisposal.SelectedIndexChanged += cobNatureOfDisposal_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task LoadDistrictNameAsync()
        {
            try
            {
                //var districtNameList = await CaseDetailHelper.GetAllDistrictNameListAsync();
                //cobDistrict.SelectedIndexChanged -= cobDistrict_SelectedIndexChanged;
                //cobDistrict.DataSource = districtNameList;
                //cobDistrict.DisplayMember = "Name";
                //cobDistrict.ValueMember = "ID";
                //cobDistrict.SelectedIndex = -1;
                //cobDistrict.SelectedIndexChanged += cobDistrict_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task LoadCourtNameAsync()
        {
            try
            {
                //var courtNameList = await CaseDetailHelper.GetAllCourtNameAsync();
                //cobCourtName.SelectedIndexChanged -= cobCourtName_SelectedIndexChanged;
                //cobCourtName.DataSource = courtNameList;
                //cobCourtName.DisplayMember = "Name";
                //cobCourtName.ValueMember = "ID";
                //cobCourtName.SelectedIndex = -1;
                //cobCourtName.SelectedIndexChanged += cobCourtName_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void cobCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cobFileName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //FileDetail caseDetails = new FileDetail();

            //caseDetails = await _db.FileDetails.Where(x => x.Barcode == txtBarcode.Text).FirstOrDefaultAsync();
            //try
            //{
            //    CaseDetailID = caseDetails.ID;
            //    if (CaseDetailID == null)
            //    {
            //        MessageBox.Show(this, "Case detail with this barcode " + txtBarcode.Text + " Not Found.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;
            //}
            //if (caseDetails == null)
            //{
            //    MessageBox.Show(this, "Case detail with this barcode " + txtBarcode.Text + " Not Found.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //txtBarcode.Text = caseDetails.Barcode;
            ////caseDetail.Status = DMS.DesktopApp.ENum.WorkflowEnums.Status.FileReceive;
            //cobCaseType.SelectedValue = caseDetails.CaseTypeID;
            //txtYear.Text = caseDetails.CaseYear.ToString();
            //txtCaseNo.Text = caseDetails.CaseNumber;
            //cobFileType.Text = caseDetails.FileTypeID.ToString();
            //cobFileStatus.Text = caseDetails.FileStatusID.ToString();
            //cobDistrict.SelectedValue = caseDetails.DistrictID;
            //txtCINNo.Text = caseDetails.CINo;
            //cobCourtName.SelectedValue = caseDetails.CourtID;
            //txtCourtNo.Text = null;
            //txtCollectedDate.Text = caseDetails.CollectedDateTime.ToString();
            //txtNoOfPage.Text = caseDetails.TotalPages.ToString();
            //txtPetitionerName.Text = caseDetails.PetitionerName;
            //txtPetitionerAdvocate.Text = caseDetails.PetitionerAdvocate;
            //txtRespondentName.Text = caseDetails.RespondentName;
            //txtRespondentAdvocate.Text = caseDetails.Advocate;
            //txtDateOfRegistration.Text = caseDetails.DateOfRegistration.ToString();
            //txtDateOfDecision.Text = caseDetails.DateOfDecision.ToString();
            //cobNatureOfDisposal.SelectedValue = caseDetails.NatureOfDisposalID;
            //txtAct.Text = caseDetails.Act;
            //txtSection.Text = caseDetails.Section;
        }

  

        private async void btnCISData_Click(object sender, EventArgs e)
        {
          
        }

        private void cobNatureOfDisposal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cobCourtName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cobDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cobCourtEstablishment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}