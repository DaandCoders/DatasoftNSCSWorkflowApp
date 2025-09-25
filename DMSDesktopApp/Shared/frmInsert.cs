using System.ComponentModel;

namespace DMS.DesktopApp.Shared
{
    public partial class frmInsert : Form
    {
        string destinationPath = null;
        private string path;
        public frmInsert(string directoryPath)
        {
            this.destinationPath = directoryPath;
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "tif files (*.tif)|*.tif| jpg file (*.jpg)|*.jpg";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
            txtNewImagePath.Text = openFileDialog1.FileName;
            string fileName = Path.GetFileName(txtNewImagePath.Text);
            string finalDestinationPath = Path.Combine(destinationPath, fileName);
            try
            {
                File.Copy(txtNewImagePath.Text, finalDestinationPath, true);
                ImagePath = finalDestinationPath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void frmInsert_Load(object sender, EventArgs e)
        {

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImagePath
        {
            get { return path; }
            set { path = value; }
        }
    }
}
