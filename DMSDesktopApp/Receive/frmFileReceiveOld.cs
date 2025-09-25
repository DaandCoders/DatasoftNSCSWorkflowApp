
using DC.DMS.Services.Models.Main;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using DC.DMS.Services.Property;
using Highlighter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Data;



namespace DMS.DesktopApp.Receive
{
    public partial class frmFileReceiveOld : Form
    {
        #region Fields
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;

      //  private CaseTypeHelper CaseTypeHelper;
        private FileDetailHelper CaseDetailHelper;
        private MasterHelper MasterHelper;
        private AutoCompleteStringCollection AutoCompleteString;
        //private MasterCaseDetails MasterCaseDetail;
       // private DBHelper dbHelper;
        private string SelectedOptionFieldName = null;
        #endregion

        int caseDetailID = 0;
        int test;
        //int num = 1;
        //int updatedBarCode;
        public frmFileReceiveOld(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;

           // CaseTypeHelper = new CaseTypeHelper();
            CaseDetailHelper = new FileDetailHelper(_dbContext);
            //MasterHelper = new MasterHelper();
           // dbHelper = new DBHelper();
           // MasterCaseDetail = new MasterCaseDetails();
            AutoCompleteString = new AutoCompleteStringCollection();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (!IsFormValid(out string message))
            {
                MessageBox.Show(this, message, Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
           // FileDetail caseDetail = new FileDetail();
            //caseDetail.CaseNumber = txtCaseNo.Text;
            //caseDetail.CaseTypeID = Convert.ToInt32(cobCaseType.SelectedValue);
            //caseDetail.CaseYear = Convert.ToInt32(cobCaseYear.Text + txtYear.Text);
            //caseDetail.CINo = txtCINo.Text;
            //caseDetail.Status = Status.FileReceive;
            //caseDetail.Act = txtAct.Text;
            //caseDetail.Section = txtSection.Text;
            //caseDetail.Advocate = txtAdvocate.Text;
            //caseDetail.DateOfDecision = Convert.ToDateTime(txtDateOfDecision.Text);
            //caseDetail.DateOfRegistration = Convert.ToDateTime(txtDateOfRegistration.Text);
            //caseDetail.PetitionerName = txtPetitionerName.Text;
            //caseDetail.RespondentName = txtRespondentName.Text;
            //caseDetail.NatureOfDisposalID = Convert.ToInt32(cobNatureOfDisposal.SelectedValue);
            //caseDetail.DocumentNumber = null;
            //caseDetail.CourtID = Convert.ToInt32(cobCourtName.SelectedValue);
            //caseDetail.DistrictID = Convert.ToInt32(cobDistrict.SelectedValue);
            //caseDetail.Barcode = txtBarcode.Text;
            //caseDetail.CollectedFrom = txtCollectedFrom.Text;
            ////caseDetail.JudgeName = txtJudgeName.Text;
            //caseDetail.CollectedDateTime = dtCollectedDate.Value;
            //caseDetail.TotalPages = Convert.ToInt32(txtNoOfPages.Text ?? "0");

            //var result = await CaseDetailHelper.InsertUpdateCaseDetail(caseDetail,txtBarcode.Text, AppUser.ID);
            //var result = await CaseDetailHelper.InsertUpdateCaseDetail(caseDetail, txtBarcode.Text, AppUser.ID, test, test);
            //if (result.Item3 == "Duplicate Record or Duplicate Barcode")
            //{
            //    MessageBox.Show(this, "Case detail with case number " + "caseDetail.CaseNumber" + " Is Duplicate or Duplicate Barcode", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
         
            //else if (result.Item1)
            //{
            //    MessageBox.Show(this, "Case detail with case number " + "caseDetail.CaseNumber" + " saved successfully.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ClearFileds();
            //    var barcodeValue = Convert.ToInt32("caseDetail.Barcode");
               
            //    barcodeValue++;
            //    var newBarcodeValue = "00" + barcodeValue;
            //    txtBarcode.Text = newBarcodeValue;
            //    return;
            //}

            else
            {
                MessageBox.Show(this, "Case detail with case number " + "caseDetail.CaseNumber" + " failed to save.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ClearFileds()
        {
            txtCaseNo.Clear();
            txtPetitionerName.Clear();
            txtRespondentName.Clear();
            txtAdvocate.Clear();
            txtDateOfDecision.Clear();
            txtDateOfRegistration.Clear();
            cobNatureOfDisposal.SelectedIndex = -1;
            txtAct.Clear();
            txtSection.Clear();
            txtNoOfPages.Clear();
            txtYear.Focus();
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
          
            else if (string.IsNullOrEmpty(txtRespondentName.Text))
            {
                message = "Respondent Name is required";
            }
            else if (string.IsNullOrEmpty(txtDateOfRegistration.Text))
            {
                message = "Date Of Registration is required";
            }
            else if (string.IsNullOrEmpty(txtDateOfDecision.Text))
            {
                message = "Date Of Decision is required";
            }
            else if (string.IsNullOrEmpty(cobNatureOfDisposal.Text))
            {
                message = "Nature Of Disposal is required";
            }
           
            if (message != null)
                return false;
            else
                return true;
        }

        private async void frmFileReceive_Load(object sender, EventArgs e)
        {
            DefaultSettings();
            await LoadPoliceStation();
            await LoadCaseTypeAsync();
            await LoadNatureOfDisposalAsync();
            await LoadCourtNameAsync();
            await LoadDistrictNameAsync();
            await LoadCourtNameSearchAsync();
            cobCaseYear.SelectedIndexChanged -= cobCaseYear_SelectedIndexChanged;
           // cobCaseYear.SelectedIndex = Settings.Default.DefaultCaseYearIndex;
            cobCaseYear.SelectedIndexChanged += cobCaseYear_SelectedIndexChanged;

        }

        private void DefaultSettings()
        {
            txtSearch1.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch1.AutoCompleteCustomSource = AutoCompleteString;
            //txtBarcode.Enabled = Settings.Default.IsBarcodeEnable;
            txtReceivedBy.Text = AppUser.CurrentUserName;
        }

        private async Task GetCaseNoFromMasterAsync(int caseTypeID, int caseYear)
        {
            //var caseList = await MasterHelper.GetAllCaseNumbersAsync(caseTypeID, caseYear);
            //if (caseList != null)
            //{
            //    AutoCompleteString.AddRange(caseList.ToArray());
            //}

        }
        private async Task LoadPoliceStation()
        {
            try
            {
                //var policerStationList = await MasterHelper.GetAllPoliceStationAsync();
                //cobPoliceStation.SelectedIndexChanged -= cobPoliceStation_SelectedIndexChanged;
                //cobPoliceStation.DataSource = policerStationList;
                //cobPoliceStation.DisplayMember = "Name";
                //cobPoliceStation.ValueMember = "ID";
                //cobPoliceStation.SelectedIndex = Settings.Default.DefaultCaseTypeIndex;
                //cobPoliceStation.SelectedIndexChanged += cobPoliceStation_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

        private async Task LoadNatureOfDisposalAsync()
        {
            try
            {
                //var natureOfDisposalList = await MasterHelper.GetNatureOfDisposalListAsync();
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
        private async Task LoadCourtNameAsync()
        {
            try
            {
                //var courtNameList = await MasterHelper.GetCourtNameListAsync();
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
        private async Task LoadCourtNameSearchAsync()
        {
            try
            {
                //var courtNameList = await MasterHelper.GetCourtNameListAsync();
                //cobCourtNameSearch.SelectedIndexChanged -= cobCourtName_SelectedIndexChanged;
                //cobCourtNameSearch.DataSource = courtNameList;
                //cobCourtNameSearch.DisplayMember = "Name";
                //cobCourtNameSearch.ValueMember = "ID";
                //cobCourtNameSearch.SelectedIndex = -1;
                //cobCourtNameSearch.SelectedIndexChanged += cobCourtName_SelectedIndexChanged;
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
                //var districtNameList = await MasterHelper.GetDistrictNameListAsync();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cobCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobCaseType.SelectedIndex != -1)
            {
              //  Settings.Default.DefaultCaseTypeIndex = cobCaseType.SelectedIndex;
                Settings.Default.Save();
            }
        }

        private void cobCaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobCaseYear.SelectedIndex != -1)
            {
              //  Settings.Default.DefaultCaseYearIndex = cobCaseYear.SelectedIndex;
                Settings.Default.Save();
            }
        }

        private void txtCaseNo_Validating(object sender, CancelEventArgs e)
        {

        }

        private async void GetSetCaseDetails(int caseTypeID, int caseYear, string text)
        {

        }

        //private void FillData(MasterCaseDetails masterCaseDetail)
        //{
        //    if (masterCaseDetail == null)
        //    {
        //        MessageBox.Show(this,
        //            string.Format("No record found with selected value/s"),
        //            Default.Caption,
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning); ;
        //        return;
        //    }
        //    var param = new char[] { ' ' };
        //    txtCaseNo.Text = masterCaseDetail.CaseNumber;
        //    string LastTwoDigit = masterCaseDetail.Year.ToString().Substring(2, 2);
        //    string firstTwoDigit = masterCaseDetail.Year.ToString().Substring(0, 2);
        //    int index = cobCaseYear.FindString(firstTwoDigit);
        //    cobCaseYear.SelectedIndex = index;
        //    txtYear.Text = LastTwoDigit;
        //    txtPetitionerName.Text = masterCaseDetail.PetitionerName;
        //    txtRespondentName.Text = masterCaseDetail.RespondentName;
        //    txtCINo.Text = masterCaseDetail.CINo;
        //    txtAdvocate.Text = masterCaseDetail.Advocate;
        //    txtDateOfRegistration.Text = masterCaseDetail.DateofRegistration.ToString().Split(param).FirstOrDefault();
        //    txtDateOfDecision.Text = masterCaseDetail.DateofDecision.ToString().Split(param).FirstOrDefault();
        //    cobNatureOfDisposal.SelectedValue = masterCaseDetail.GetNatureOFDisposal.ID;
        //    txtAct.Text = masterCaseDetail.Act;
        //    txtSection.Text = masterCaseDetail.Section;
        //    cobCourtName.SelectedValue = masterCaseDetail.GetCourtName.ID;
        //    // txtJudgeName.Text = MasterCaseDetail.JudgeName;
        //}

        private async void txtYear_Validating(object sender, CancelEventArgs e)
        {
            await GetCaseNoFromMasterAsync(Convert.ToInt32(cobCaseType.SelectedValue), Convert.ToInt32(cobCaseYear.Text + txtYear.Text));
        }

        private void cobNatureOfDisposal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void spcMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        #region Private

        #region Highlighter
        private void TextBox_Enter(object sender, EventArgs e)
        {
            AppColor.TextBoxEnter((TextBox)sender);
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            AppColor.TextBoxLeave((TextBox)sender);

        }
        private void ComboBox_Enter(object sender, EventArgs e)
        {
            AppColor.ComboBoxEnter((ComboBox)sender);
        }
        private void ComboBox_Leave(object sender, EventArgs e)
        {
            AppColor.ComboBoxLeave((ComboBox)sender);
        }
        private void DateTimePicker_Enter(object sender, EventArgs e)
        {
            AppColor.DateTimeBoxEnter((DateTimePicker)sender);
        }
        private void DateTimePicker_Leave(object sender, EventArgs e)
        {
            AppColor.DateTimeBoxLeave((DateTimePicker)sender);
        }
        private void MaskTextBox_Enter(object sender, EventArgs e)
        {
            AppColor.MaskTextBoxEnter((MaskedTextBox)sender);
        }
        private void MaskTextBox_Leave(object sender, EventArgs e)
        {
            AppColor.MaskTextBoxLeave((MaskedTextBox)sender);
        }
        #endregion

        #endregion

        private void cobCourtName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cobDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, EventArgs e)
        {
            var rab = (RadioButton)sender;
            SelectedOptionFieldName = rab.Text;
            switch (rab.Name)
            {
                case "rabPartyName":
                    lblSearch1.Text = "Petitioner Name";
                    lblSearch1.Refresh();
                
                    txtSearch2.Enabled = true;
                    lblSearch2.Enabled = true;

                    lblPoliceStation.Enabled = false;
                    cobPoliceStation.Enabled = false;
                    lblCaseYear.Enabled = false;
                    typCaseYear.Enabled = false;
                    lblCaseType.Enabled = false;
                    cobCaseType.Enabled = false;
                    break;
                case "rabCaseNo":
                    lblSearch1.Text = "Case No.";
                    lblSearch1.Refresh();
                    lblCaseYear.Enabled = true;
                    typCaseYear.Enabled = true;
                    lblCaseType.Enabled = true;
                    cobCaseType.Enabled = true;

                    lblPoliceStation.Enabled = false;
                    cobPoliceStation.Enabled = false;
                    txtSearch2.Enabled = false;
                    lblSearch2.Enabled = false;
                    break;
                case "rabFIRNo":
                    lblSearch1.Text = "FIR No.";
                    lblSearch1.Refresh();
                    lblPoliceStation.Enabled = true;
                    cobPoliceStation.Enabled = true;

                    lblCaseYear.Enabled = false;
                    typCaseYear.Enabled = false;
                    lblCaseType.Enabled = false;
                    cobCaseType.Enabled = false;
                    txtSearch2.Enabled = false;
                    lblSearch2.Enabled = false;
                    break;
                case "rabFillingNo":
                    lblSearch1.Text = "FillingNo";
                    lblSearch1.Refresh();
                    lblCaseYear.Enabled = true;
                    typCaseYear.Enabled = true;
                    
                    lblPoliceStation.Enabled = false;
                    cobPoliceStation.Enabled = false;
                    txtSearch2.Enabled = false;
                    lblSearch2.Enabled = false;
                    break;
                default:
                    lblSearch1.Text = rab.Text;
                    lblSearch1.Refresh();
                    txtSearch2.Enabled = false;
                    lblSearch2.Enabled = false;
                    lblCaseYear.Enabled = false;
                    typCaseYear.Enabled = false;
                    lblCaseType.Enabled = false;
                    cobCaseType.Enabled = false;
                    lblPoliceStation.Enabled = false;
                    cobPoliceStation.Enabled = false;
                    break;
            }

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string filedName = SelectedOptionFieldName;
            if (rabCNRNo.Checked && !string.IsNullOrEmpty(txtSearch1.Text))
            {
                filedName = rabCaseNo.Text;
                //MasterCaseDetail = await MasterHelper.GetCaseDetailsByCNRNo(txtSearch1.Text);
                //FillData(MasterCaseDetail);
            }
            else if (rabFillingNo.Checked && !string.IsNullOrEmpty(txtSearch1.Text))
            {
                filedName = rabFillingNo.Text;
                //MasterCaseDetail = await MasterHelper.GetCaseDetailsByFillingNo(Convert.ToInt32(txtSearch1.Text), Convert.ToInt32(cobCaseYear.Text + txtYear.Text), Convert.ToInt32(cobCourtNameSearch.SelectedValue));
                //FillData(MasterCaseDetail);
            }
            else if (rabCaseNo.Checked && !string.IsNullOrEmpty(txtSearch1.Text))
            {
                filedName = rabCaseNo.Text;
                //MasterCaseDetail = await MasterHelper.GetCaseDetails(Convert.ToInt32(cobCaseType.SelectedValue), Convert.ToInt32(cobCaseYear.Text + txtYear.Text), txtSearch1.Text);
                //FillData(MasterCaseDetail);
            }
            else if (rabPartyName.Checked && !string.IsNullOrEmpty(txtSearch1.Text) && !string.IsNullOrEmpty(txtRespondentName.Text))
            {
                filedName = rabCaseNo.Text;
                //MasterCaseDetail = await MasterHelper.GetCaseDetailsByPartyNo(txtSearch1.Text, txtPetitionerName.Text);
                //FillData(MasterCaseDetail);
            }
            else if (rabFIRNo.Checked && !string.IsNullOrEmpty(txtSearch1.Text) && cobPoliceStation.SelectedIndex != -1)
            {
                filedName = rabCaseNo.Text;
                //MasterCaseDetail = await MasterHelper.GetCaseDetailsByFIRNo(Convert.ToInt32(txtSearch1.Text), Convert.ToInt32(cobPoliceStation.SelectedValue));
                //FillData(MasterCaseDetail);
            }
            else if (rabSubordinateCourt.Checked)
            {
                MessageBox.Show(this, "Right now Subordinate Court not implemented.", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            else
            {
                MessageBox.Show(this, filedName + " is required", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
        }

        private void txtSearch1_Validating(object sender, CancelEventArgs e)
        {
        }

        private void cobPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
