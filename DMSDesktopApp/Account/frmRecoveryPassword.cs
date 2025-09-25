
using DC.DMS.Services.AuthHandler;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Data;

namespace DMS.DesktopApp.Account
{
    public partial class frmRecoveryPassword : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        IUserHandling auth;
        IUtils utils = new IronConversion();

        public frmRecoveryPassword(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
        }

        private void frmRecoveryPassword_Load(object sender, EventArgs e)
        {
            grbChangePassword.Hide();
            grbSecurityQandA.Hide();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            //auth.CheckEmail(txtEmail.Text, "CheckEmail", out result, out question, txtAnswer.Text, txtConfirmNewPassword.Text);
            //MessageBox.Show(result);
            //if (result == "Please answer the security Question.")
            //{
            //    txtQuestion.Text = question;
            //    grbChangePassword.Hide();
            //    grbSecurityQandA.Show();
            //    var questionID = _db.Users.FirstOrDefault(x => x.Email.Equals(txtEmail.Text)).SecrateQuestion;
            //    txtQuestion.Text = _db.Questions.FirstOrDefault(x => x.ID.Equals(questionID)).question.ToString();
            //}
            //else
            //{
            //    txtQuestion.Text = "";
            //    grbChangePassword.Hide();
            //    grbSecurityQandA.Hide();
            //}
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //auth.CheckEmail(txtEmail.Text, "CheckSecurity", out result, out question, txtAnswer.Text, txtConfirmNewPassword.Text);
            //MessageBox.Show(result);
            //if (result == "Enter new password!")
            //{
            //    txtQuestion.Text = question;
            //    grbSecurityQandA.Show();
            //    grbChangePassword.Show();
            //}
            //else
            //{
            //    txtQuestion.Text = "";
            //    grbSecurityQandA.Hide();
            //}
        }

        private void grbChangePassword_Enter(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //if (txtNewPassword.Text == txtConfirmNewPassword.Text)
            //{
            //    auth.CheckEmail(txtEmail.Text, "ChangePassword", out result, out question, txtAnswer.Text, txtConfirmNewPassword.Text);
            //    MessageBox.Show(result);
            //    txtEmail.Text = "";
            //    txtAnswer.Text = "";
            //    txtNewPassword.Text = "";
            //    txtConfirmNewPassword.Text = "";
            //    txtQuestion.Text = "";
            //    grbChangePassword.Show();
            //    grbSecurityQandA.Show();
            //    //frmLogin login = new frmLogin();
            //   // login.ShowDialog();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Password does not matching");
            //}
        }
    }
}
