using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;

namespace DMS.DesktopApp.Shared
{
    public partial class frmMultiImageInsert : Form
    {
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        string destinationPath = null;
        private string path;
        string[] imgPath = null;
        List<string> imgPathList;

        public frmMultiImageInsert(string directoryPath, IMemoryCache cache, ITranslationService translationService)
        {
            this.destinationPath = directoryPath;
            InitializeComponent();
            _cache = cache;
            _translationService = translationService;
            imgPathList = new List<string>();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "tif files (*.tif)|*.tif| jpg file (*.jpg)|*.jpg";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();


            foreach (var filePath in openFileDialog1.FileNames)
            {
                txtNewImagePath.Text = filePath;
                var fileName = Path.GetFileName(txtNewImagePath.Text);
                string finalDestinationPath = Path.Combine(destinationPath, fileName);
                try
                {
                    File.Copy(txtNewImagePath.Text, finalDestinationPath, true);
                    imgPathList.Add(finalDestinationPath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            //return imgPathList;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void frmMultiImageInsert_Load(object sender, EventArgs e)
        {

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<string> ImagePath
        {
            get { return imgPathList; }
            set { imgPathList = value; }
        }
    }
}
