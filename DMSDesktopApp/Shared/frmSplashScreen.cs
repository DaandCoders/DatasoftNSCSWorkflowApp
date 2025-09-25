
using DMS.DesktopApp.Account;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using DMS.Context.Data;
using DMS.ContextData;
using DC.DMS.Services.Property;
using DMS.API.WindowsServices;
using Microsoft.EntityFrameworkCore;

namespace DMS.DesktopApp.Shared
{
    public partial class frmSplashScreen : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        public frmSplashScreen(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {

            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            LoadDetails();
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("Temp");
            lblVersion.Text = String.Format("Version {0}", AssemblyVersion);

            ClientAPI.BaseUrl = Settings.Default.BaseUrl;
            ClientAPI.DataSyncUrl = Settings.Default.GetSyncDataUrl;
        }

        private async void Timer_TickAsync(object sender, EventArgs e)
        {
            timer.Stop();
            await using var _db = await _dbContext.CreateDbContextAsync();
            frmLogin login = new frmLogin(_dbContext, _cache, _translationService);
            Hide();
            login.Show();
        }
        private async void LoadDetails()
        {
            try
            {
                await using var _db = await _dbContext.CreateDbContextAsync();
                var siteDetail = _db.DCSClient.Where(x => x.IsActive).FirstOrDefault();
                AppDetails.SiteName = siteDetail.Name;
                AppDetails.ID = siteDetail.ID;
                Default.Caption = Settings.Default.Title;
            }
            catch (Exception ex)
            {

            }
        }
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private void FrmSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}
