
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.QCClient;
using DMS.DesktopApp.Shared;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;


namespace DMS.DesktopApp.Dashboard
{
    public partial class frmClientDashboard : Form
    {
        private FileDetailHelper FileDetailHelper;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private readonly string serverName;
        private readonly string database;
        private readonly string userID;
        private readonly string password;
        private DashboardHelper DashboardHelper;

        private int ReceivedFilesCount = 0;
        private int ScannedFilesCount = 0;
        private int QCFilesCount = 0;
        private int ClassifiedFilesCount = 0;
        private int DispatchFilesCount = 0;
        private int ClientQCFilesCount = 0;
        public frmClientDashboard(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            FileDetailHelper = new FileDetailHelper(_dbContext);

        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void menQC_Click(object sender, EventArgs e)
        {
            frmDepartmentSelection frmDepartmentSelection = new frmDepartmentSelection(_dbContext, _cache, _translationService);
            frmDepartmentSelection.ShowDialog();

        }

        private void frmDashboard_Load(object sender, EventArgs e)
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
            lblUserName.Text = AppUser.CurrentUserName;
            Text = $"DMS Workflow | Client Dashboard v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }

        private void menAbout_Click(object sender, EventArgs e)
        {
            //frmAboutBox aboutBox = new frmAboutBox();
            //aboutBox.ShowDialog();
        }

        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCount();
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
    }
}
