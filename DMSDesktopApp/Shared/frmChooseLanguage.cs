
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;

namespace DMS.DesktopApp.Shared
{
    public partial class frmChooseLanguage : Form
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;

        public frmChooseLanguage(ApplicationDbContext dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
        }
        public void ChangeLanguage(string languageCode)
        {
            var translations = _translationService.LoadTranslations(languageCode);
            _translationService.TranslateControl(this, translations);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string selectedLanguage = comboBox1.SelectedItem.ToString();
            ChangeLanguage(selectedLanguage);
            Cursor = Cursors.Default;
        }
        private void frmChooseLanguage_Load(object sender, EventArgs e)
        {

        }
    }
}
