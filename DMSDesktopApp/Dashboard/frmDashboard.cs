using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Receive;
using DMS.DesktopApp.Shared;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Dashboard
{
    public partial class frmDashboard : Form
    {
        private FileDetailHelper FileDetailHelper;

        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private DashboardHelper DashboardHelper;
        private int ReceivedFilesCount = 0;
        private int ScannedFilesCount = 0;
        private int QCFilesCount = 0;
        private int ClassifiedFilesCount = 0;
        private int DispatchFilesCount = 0;
        private int ClientQCFilesCount = 0;

        public frmDashboard(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            //dbHelper = new DBHelper();
            FileDetailHelper = new FileDetailHelper(_dbContext);

        }

        private void btnBatchLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnImageQC_Click(object sender, EventArgs e)
        {

        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnClassification_Click(object sender, EventArgs e)
        {
            //frmMainDirectorySelection imageQC = new frmMainDirectorySelection(CallingFor.Classification);
            //imageQC.ShowDialog();
        }

        private void btnAddCaseFile_Click(object sender, EventArgs e)
        {

        }

        private void btnDispatch_Click(object sender, EventArgs e)
        {

        }

        private void btnOtherFileDispatch_Click(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {

        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {

        }

        private void menFileRecevie_Click(object sender, EventArgs e)
        {
            switch (AppDetails.ID)
            {
                case 1:
                    frmFileReceieve frmFileReceive = new frmFileReceieve(_dbContext, _cache, _translationService);
                    frmFileReceive.ShowDialog();
                    break;
                case 2:
                case 3:
                    //frmFileReceiveKartnataka frmFileReceiveKartnataka = new frmFileReceiveKartnataka();
                    //frmFileReceiveKartnataka.ShowDialog();
                    break;
                case 4:
                    //frmFileReceiveJammu frmFileReceiveJammu = new frmFileReceiveJammu();
                    //frmFileReceiveJammu.ShowDialog();
                    break;
                default:
                    break;
            }

        }

        private void menScan_Click(object sender, EventArgs e)
        {
            frmMainDirectorySelection frmScan = new frmMainDirectorySelection(CallingFor.Scanning, _dbContext, _cache, _translationService);
            frmScan.ShowDialog();
            //  frmScan scan = new frmScan();
            //scan.ShowDialog();
        }

        private void menDispatch_Click(object sender, EventArgs e)
        {

        }

        private void batchLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmLoad frmLoad = new frmLoad();
            //frmLoad.ShowDialog();
        }

        private void addCaseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAddCaseFile addCaseFile = new frmAddCaseFile();
            //addCaseFile.ShowDialog();
        }

        private void otherDispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void batchDispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void frmDashboard_LoadAsync(object sender, EventArgs e)
        {
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
            lblUserName.Text=AppUser.CurrentUserName;
            Text = $"DMS Workflow | User Dashboard v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }

        private void menAbout_Click(object sender, EventArgs e)
        {
            frmAboutBox aboutBox = new frmAboutBox();
            aboutBox.ShowDialog();
        }

        private void menImageClassification_Click(object sender, EventArgs e)
        {
            frmMainDirectorySelection frmImgClassification = new frmMainDirectorySelection(CallingFor.Classification, _dbContext, _cache, _translationService);
            frmImgClassification.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCount();
        }

        private async void RefreshCount()
        {
            try
            {
                ReceivedFilesCount = (FileDetailHelper.ReceivedFilesCount(AppUser.ID, Status.FileReceive));
                ScannedFilesCount = (FileDetailHelper.ScannedFilesCount(AppUser.ID));
                QCFilesCount = (FileDetailHelper.QCFilesCount(AppUser.ID));
                //ClassifiedFilesCount = FileDetailHelper.ClassifiedFilesCount();
                DispatchFilesCount = FileDetailHelper.DispatchFilesCount(AppUser.ID);
                //ClientQCFilesCount = ( FileDetailHelper.ClientQCFilesCount(AppUser.ID));
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

        private void menDispatch_Click_1(object sender, EventArgs e)
        {

        }

        private void menBatchQC_Click(object sender, EventArgs e)
        {
        }

        private void menQC_Click(object sender, EventArgs e)
        {
            frmMainDirectorySelection imageQC = new frmMainDirectorySelection(CallingFor.QC, _dbContext, _cache, _translationService);
            imageQC.ShowDialog();
        }

        private void menReports_Click(object sender, EventArgs e)
        {

        }

        private void menAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}
