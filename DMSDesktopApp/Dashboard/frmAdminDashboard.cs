using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Admin;
using DMS.DesktopApp.Account;
using DMS.DesktopApp.Dispatch;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;
using DMS.DesktopApp.Reports;
using DMS.DesktopApp.Sync;
using Microsoft.EntityFrameworkCore;
using LiveCharts.Wpf;
using LiveCharts;
using DMS.DesktopApp.Helper;
using System.Reflection;


namespace DMS.DesktopApp.Dashboard
{

    public partial class frmAdminDashboard : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private FileDetailHelper FileDetailHelper;
        private int ReceivedFilesCount = 0;
        private int ScannedFilesCount = 0;
        private int QCFilesCount = 0;
        private int ClassifiedFilesCount = 0;
        private int DispatchFilesCount = 0;
        private int ClientQCFilesCount = 0;

        public frmAdminDashboard(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            FileDetailHelper = new FileDetailHelper(_dbContext);
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            switch (AppDetails.ID)
            {
                case 1:
                    break;
                case 2:
                    menChangeFileStatus.Enabled = true;
                    menMaster.Enabled = true;
                    break;
                case 3:
                    menChangeFileStatus.Enabled = false;

                    userRegistrationToolStripMenuItem.Enabled = false;
                    menMaster.Enabled = true;
                    break;
                default:
                    menChangeFileStatus.Enabled = true;
                    menMaster.Enabled = true;
                    break;
            }

            RefreshCount();
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "File Received",
                        Values = new ChartValues<double> {ReceivedFilesCount},
                        PushOut = 15,
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    new PieSeries
                    {
                        Title = "File Scanned",
                        Values = new ChartValues<double> {ScannedFilesCount},
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    new PieSeries
                    {
                        Title = "File QC",
                        Values = new ChartValues<double> {QCFilesCount},
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    //new PieSeries
                    //{
                    //    Title = "File Classification",
                    //    Values = new ChartValues<double> {ClassifiedFilesCount},
                    //    DataLabels = true,
                    //    LabelPoint = labelPoint
                    //},
                    new PieSeries
                    {
                        Title = "File Dispatched",
                        Values = new ChartValues<double> {DispatchFilesCount },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    },
                    new PieSeries
                    {
                        Title = "File QC by Client",
                        Values = new ChartValues<double> {ClientQCFilesCount},
                        DataLabels = true,
                        LabelPoint = labelPoint
                    }
                };
            pieChart1.LegendLocation = LegendLocation.Bottom;
            lblUserName.Text = AppUser.CurrentUserName;
            Text = $"DMS Workflow | Admin Dashboard v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }

        private async void RefreshCount()
        {
            try
            {
                ReceivedFilesCount = (FileDetailHelper.ReceivedFilesCount());
                ScannedFilesCount = (FileDetailHelper.ScannedFilesCount());
                QCFilesCount = (FileDetailHelper.QCFilesCount());
                //ClassifiedFilesCount = FileDetailHelper.ClassifiedFilesCount();
                DispatchFilesCount = FileDetailHelper.DispatchFilesCount();
                ClientQCFilesCount = (FileDetailHelper.ClientQCFilesCount());
            }
            catch (Exception ex)
            {

                throw;
            }



            lblTotalFileReceived.Text = ReceivedFilesCount.ToString().PadLeft(1, '0');
            lblTotalFileReceived.Refresh();

            lblTotalFileScanned.Text = ScannedFilesCount.ToString().PadLeft(1, '0');
            lblTotalFileScanned.Refresh();

            lblTotalFileQC.Text = QCFilesCount.ToString().PadLeft(1, '0');
            lblTotalFileQC.Refresh();

            //lblTotalFileClassified.Text = ClassifiedFilesCount.ToString().PadLeft(1, '0');
            //lblTotalFileClassified.Refresh();

            lblTotalFileDispatched.Text = DispatchFilesCount.ToString().PadLeft(1, '0');
            lblTotalFileDispatched.Refresh();

            lblTotalFileQCByCLient.Text = ClientQCFilesCount.ToString().PadLeft(1, '0');
            lblTotalFileQCByCLient.Refresh();
        }
        private void menLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin(_dbContext, _cache, _translationService);
            login.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmChangePassword changPassword = new frmChangePassword();
            //changPassword.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUser userManagement = new frmManageUser(_dbContext, _cache, _translationService);
            userManagement.ShowDialog();
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistration frmRegistration = new frmRegistration(_dbContext, _cache, _translationService);
            frmRegistration.ShowDialog();
        }

        private void menReport_Click(object sender, EventArgs e)
        {

        }

        private void menAddDocType_Click(object sender, EventArgs e)
        {
            //frmAddDocumentType addDocType = new frmAddDocumentType();
            //addDocType.ShowDialog();
        }

        private void menSearchBarcode_Click(object sender, EventArgs e)
        {
            //frmCheckBarcodeDetails frmCheckCaseDetails = new frmCheckBarcodeDetails();
            //frmCheckCaseDetails.ShowDialog();
        }

        private void menChangeFileStatus_Click(object sender, EventArgs e)
        {
            frmChangeFileStatus frmChangeFileStatus = new frmChangeFileStatus(_dbContext);
            frmChangeFileStatus.ShowDialog();

        }



        private void menDuplicate_Click(object sender, EventArgs e)
        {
            //frmDeleteBarcode frmDeleteBarcode = new frmDeleteBarcode();
            //frmDeleteBarcode.ShowDialog();
        }

        private void menBatchDispatch_Click(object sender, EventArgs e)
        {
            switch (AppDetails.ID)
            {
                case 1:
                    frmDispatch frmDispatch = new frmDispatch(_dbContext, _cache, _translationService);
                    frmDispatch.ShowDialog();
                    break;
                case 2:
                    //frmDispatchKarnataka frmDispatchKarnataka = new frmDispatchKarnataka();
                    //frmDispatchKarnataka.ShowDialog();
                    break;
                case 3:
                    //frmDispatchKarnataka frmDispatchbanglore = new frmDispatchKarnataka();
                    //frmDispatchbanglore.ShowDialog();
                    break;
                case 4:
                    //frmDispatch frmDispatchHCSalem = new frmDispatch();
                    //frmDispatchHCSalem.ShowDialog();
                    break;
            }

        }

        private void menOtherDipatch_Click(object sender, EventArgs e)
        {
            //frmOtherFileDispatch frmOtherFileDispatch = new frmOtherFileDispatch();
            //frmOtherFileDispatch.ShowDialog();
        }

        private void addCaseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAddCaseType addCaseType = new frmAddCaseType();
            //addCaseType.ShowDialog();
        }

        private void menDayReport_Click(object sender, EventArgs e)
        {
            frmDayReport dayReport = new frmDayReport(_dbContext, _cache, _translationService);
            dayReport.ShowDialog();
        }

        private void menMetadataReport_Click(object sender, EventArgs e)
        {
            //frmMetadataReport metaDataReport = new frmMetadataReport();
            //metaDataReport.ShowDialog();
        }

        private void dispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void receivingUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //switch (AppDetails.ID)
            //{
            //    case 1:
            //        frmUpdateFileReceiveBihar updateFileReceiveBihar = new frmUpdateFileReceiveBihar();
            //        updateFileReceiveBihar.ShowDialog();
            //        break;
            //    case 2:
            //        frmUpdateFileReceiveKartnataka updateFileReceiveKartnataka = new frmUpdateFileReceiveKartnataka();
            //        updateFileReceiveKartnataka.ShowDialog();
            //        break;
            //    case 3:
            //        frmUpdateFileReceiveKartnataka updateFileReceiveBanglore = new frmUpdateFileReceiveKartnataka();
            //        updateFileReceiveBanglore.ShowDialog();
            //        break;
            //    case 4:
            //        frmUpdateFileReceiveBihar updateFileReceiveHCSalem = new frmUpdateFileReceiveBihar();
            //        updateFileReceiveHCSalem.ShowDialog();
            //        break;
            //    default:
            //        break;
            //}

        }

        private void menMISReport_Click(object sender, EventArgs e)
        {
            //frmMISReport frmMISReport = new frmMISReport();
            //frmMISReport.ShowDialog();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmExportSite frmMISReport = new frmExportSite();
            //frmMISReport.ShowDialog();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmImportHQ frmMISReport = new frmImportHQ();
            //frmMISReport.ShowDialog();
        }

        private void qAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMainDirectorySelection frmImgClassification = new frmMainDirectorySelection(CallingFor.ImageClassificationQC);
            //frmImgClassification.ShowDialog();
        }

        private void menData_Click(object sender, EventArgs e)
        {

        }

        private void menDataQuality_Click(object sender, EventArgs e)
        {
            //frmDataQuality frmDataQuality = new frmDataQuality();
            //frmDataQuality.ShowDialog();
        }

        private void menAbout_Click(object sender, EventArgs e)
        {
            //frmAboutBox aboutBox = new frmAboutBox();
            //aboutBox.ShowDialog();
        }

        private void menDBBackup_Click(object sender, EventArgs e)
        {
            //frmDatabaseBackup frmDBBackup = new frmDatabaseBackup();
            //frmDBBackup.ShowDialog();
        }

        private void imageCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmImageCount frmImageCount = new frmImageCount();
            //frmImageCount.ShowDialog();
        }

        private void uploadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmUpload frmImageCount = new frmUpload();
            //frmImageCount.ShowDialog();
        }

        private void addDocumentNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAddDocumentNumber frmAddDocumentNumber = new frmAddDocumentNumber();
            //frmAddDocumentNumber.ShowDialog();
        }

        private void reNamePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRenamePDF frmAddDocumentNumber = new frmRenamePDF();
            //frmAddDocumentNumber.ShowDialog();
        }

        private void changeLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmChooseLanguage frmChooseLanguage = new frmChooseLanguage(_dbContext, _cache, _translationService);
            //frmChooseLanguage.ShowDialog();
        }

        private void menSync_Click(object sender, EventArgs e)
        {
            frmDataSync frmDataSync = new frmDataSync(_dbContext, _cache, _translationService);
            frmDataSync.ShowDialog();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
