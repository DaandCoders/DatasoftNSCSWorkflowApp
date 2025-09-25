

using DC.DMS.Services.AuthHandler;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Threading.Tasks;

namespace DMS.DesktopApp.Account
{
    public partial class frmManageUser : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        DataTable dt;
        public string UserName, Email;
        public string Role;
        public string temp;
        public string result;
        public String isActive;
        IUserHandling auth;
        IUtils utils = new IronConversion();
        public frmManageUser(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {

            InitializeComponent();
            // auth = new AuthImpersination(db);
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
        }
        public async Task RefreshDataGridView()
        {

            dgvUserData.DataSource =await auth.SearchViewUsersAsync(txtSearch.Text);
            dgvUserData.Refresh();


        }
        private async void frmManageUser_Load(object sender, EventArgs e)
        {
            dgvUserData.SelectionChanged += new EventHandler(dgvUserData_SelectionChanged);
            await using var _db = await _dbContext.CreateDbContextAsync();
            cobRole.Items.Clear();
            cobRole.DataSource = utils.ToDataTable(_db.Roles.Where(x => x.ID > 0).ToList());
            cobRole.DisplayMember = "Name";
            cobRole.ValueMember = "Id";


            RefreshDataGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == "" || txtUsername.Text == "" || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Fill all the information first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await using var _db = await _dbContext.CreateDbContextAsync();
                    if (cbActive.Checked == true)
                    {

                        dt = utils.ToDataTable(_db.ApplicationUsers.Where(x => x.Email.Equals(txtEmail.Text) && x.UserName.Equals(txtUsername.Text)).ToList());
                        int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                        await auth.ManageUsersAsync(id, Convert.ToInt32(cobRole.SelectedValue.ToString()), true);
                        MessageBox.Show(result);
                        RefreshDataGridView();

                    }
                    else
                    {

                        dt = utils.ToDataTable(_db.ApplicationUsers.Where(x => x.Email.Equals(txtEmail.Text) && x.UserName.Equals(txtUsername.Text)).ToList());
                        int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                        await auth.ManageUsersAsync(id, Convert.ToInt32(cobRole.SelectedValue.ToString()), false);
                        MessageBox.Show(result);
                        RefreshDataGridView();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data Found For the Related Query", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUserData_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
