//using DC.Services.AuthHandler;
using DC.DMS.Services.AuthHandler;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Dashboard;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DMS.DesktopApp.Account
{
    public partial class frmLogin : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        IUserHandling auth;

        public frmLogin(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;

            //txtEmail.Text = "scanadmin@admin.com";
           // txtPassword.Text = "admin123";

            //txtEmail.Text = "admin@admin.com";
            // txtPassword.Text = "admin123";

            //txtEmail.Text = "admin@admin.com";
            //txtPassword.Text = "admin@1234";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                await using var _db = await _dbContext.CreateDbContextAsync();
                var result = _db.ApplicationUsers.Where(x => x.Email == txtEmail.Text && x.Password == txtPassword.Text).Select(x => new
                {
                    x.Roles.RoleName,
                    x.UserName,
                    x.ID,
                    x.Email
                }).FirstOrDefault();
                if (result != null)
                {
                    AppUser.CurrentRole = result.RoleName;
                    AppUser.CurrentUserName = result.UserName;
                    AppUser.ID = result.ID;
                    Properties.Settings.Default.Email = txtEmail.Text;
                    if (AppUser.CurrentRole == "Admin")
                    {
                        frmAdminDashboard dashboard = new frmAdminDashboard(_dbContext, _cache, _translationService);
                        dashboard.Show();
                    }
                    else if (AppUser.CurrentRole == "Scanning")
                    {
                        frmDashboard formLoad = new frmDashboard(_dbContext, _cache, _translationService);
                        formLoad.Show();
                    }
                    else if (AppUser.CurrentRole == "DepartmentStaff")
                    {
                        frmClientDashboard dashboardScan = new frmClientDashboard(_dbContext, _cache, _translationService);
                        dashboardScan.Show();
                    }
                    else if (AppUser.CurrentRole == "Super Admin")
                    {
                        //frmSuperAdminDashboard dashboardScan = new frmSuperAdminDashboard();
                        //dashboardScan.Show();
                    }
                    //else if (AppUser.CurrentRole == "RegistrarStaff")
                    //{
                    //    frmDashboardRegistrar dashboardScan = new frmDashboardRegistrar();
                    //    dashboardScan.Show();
                    //}
                    Hide();
                }
                else
                {
                    MessageBox.Show(this, "Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtEmail.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)
                {
                    MessageBox.Show(this, "Network not found. While establishing a connection to SQL Server.", "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(this, ex.Message, "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmRecoveryPassword frmRecoverPassword = new frmRecoveryPassword(_dbContext, _cache, _translationService);
            frmRecoverPassword.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
