using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DC.DMS.Services.AuthHandler;
using DMS.Context.Data;

using DMS.ContextAuthHandler;

using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Account
{
    public partial class frmRegistration : Form
    {
        public string result;
        IUserHandling auth;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        IUtils utils = new IronConversion();
        public frmRegistration(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            InitializeComponent();
            auth = new AuthImpersination(_dbContext);
        }

        private async void frmRegistration_Load(object sender, EventArgs e)
        {
            LoadQuestions();
            cobRole.Items.Clear();
            await using var _db = await _dbContext.CreateDbContextAsync();
            cobRole.DataSource = utils.ToDataTable(_db.Roles.Where(x => x.ID > 0).ToList());
            cobRole.DisplayMember = "RoleName";
            cobRole.ValueMember = "ID";
            cobRole.SelectedIndex = -1;
        }
        private async void LoadQuestions()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = utils.ToDataTable(_db.Questions.Where(x => x.ID > 0).ToList());
            cobQuestion.DataSource = dt;
            cobQuestion.DisplayMember = "Question";
            cobQuestion.ValueMember = "ID";
            cobQuestion.SelectedIndex = -1;
        }
        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidEmail(string email, string customDomain)
        {
            // Basic email format validation using Regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(email, emailPattern))
            {
                // Extract domain and validate against custom domain
                string domain = email.Split('@')[1];
                return domain.Equals(customDomain, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
        private async Task button1_Click(object sender, EventArgs e)
        {
            // Insert Registration details in database
            /// Validating Input values
            Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!rEmail.IsMatch(txtEmail.Text.Trim()) ||
                txtUsername.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                cobRole.SelectedValue.ToString() == "")
            //cobQuestion.Text.Trim() == "" ||
            //txtAnswer.Text.Trim() == "")
            {
                MessageBox.Show("Fill all the information or Check Email address");
            }
            else
            {
                try
                {
                   await auth.RegisterAsync(txtUsername.Text, txtPassword.Text, txtEmail.Text, cobRole.SelectedValue.ToString(), (cobQuestion.SelectedIndex + 1).ToString(), txtAnswer.Text,DcsUsers.No);
                    MessageBox.Show(result, "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    Close();
                }
                catch (Exception ex)
                {
                    // Returns if any error 
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string customDomain = "dcs.com";
            Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!rEmail.IsMatch(txtEmail.Text.Trim()) ||
                txtUsername.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                cobRole.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Fill all the information or Check Email address");
            }
            else
            {
                try
                {
                    if (chkDatasoftEmployee.Checked) {

                        string email = txtEmail.Text;
                        if (IsValidEmail(email, customDomain))
                        {
                           await auth.RegisterAsync(txtUsername.Text, txtPassword.Text, txtEmail.Text, cobRole.SelectedValue.ToString(), (cobQuestion.SelectedIndex + 1).ToString(), txtAnswer.Text,DcsUsers.Yes);

                            // Result shown in Meassage Box
                            MessageBox.Show(result, "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email.");
                            return;
                        }
                    }
                    else
                    {
                       await auth.RegisterAsync(txtUsername.Text, txtPassword.Text, txtEmail.Text, cobRole.SelectedValue.ToString(), (cobQuestion.SelectedIndex + 1).ToString(), txtAnswer.Text,DcsUsers.No);
                        MessageBox.Show(result, "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                        Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    // Returns if any error 
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
