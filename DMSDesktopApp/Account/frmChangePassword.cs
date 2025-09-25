using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;

namespace DMS.DesktopApp.Account
{
    public partial class frmChangePassword : Form
    {
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;

        public frmChangePassword(ApplicationDbContext dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent(); 
            _db = dbContext;
            _cache = cache;
            _translationService = translationService;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text == "" || txtNewPassword.Text == "" || txtConfirmPassword.Text == "" || txtCurrentPassword.Text == txtNewPassword.Text || txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("You are Doing Something Wrong \n1) Fill All The Information \n2) Current Password And New Password Can't be same \n3) New Password and Confirm Password not Matched ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //auth.ChangePassword(Properties.Settings.Default.Email, txtCurrentPassword.Text, txtNewPassword.Text, txtConfirmPassword.Text, out result);
                //MessageBox.Show(result);
            }
        }
    }
}
