
using DMS.Context.Data;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;



namespace DMS.DesktopApp.Shared
{
    public partial class frmRemarks : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        DirectoryHelper DirectoryHelper;
        CallingFor CallingFor;
        public frmRemarks(CallingFor callingFor, IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
           
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            DirectoryHelper = new DirectoryHelper(_dbContext,_cache,_translationService);
            CallingFor = callingFor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
        }

        private async void frmMainDirectorySelection_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show(this, "Remark is required.");
                return;
            }
        }
    }
}
