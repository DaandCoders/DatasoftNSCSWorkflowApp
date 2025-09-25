using DC.Process;
using NTwain.Triplets;

namespace DMSDesktopApp.Shared
{
    public partial class frmImportImages : Form
    {
        string SelectedFileName = null;
        int SelectedIndex = -1;
        public frmImportImages(string fileName, int selectedIndex)
        {
            InitializeComponent();
            this.SelectedFileName = fileName;
            this.SelectedIndex = selectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (rabSingleImage.Checked)
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtLocation.Text = openFileDialog.FileName;
                    lblTotalFiles.Text = "1";
                    statusStrip1.Refresh();
                }
            }
            else
            {
                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtLocation.Text = folderBrowserDialog.SelectedPath;
                    lblTotalFiles.Text = (Files.GetImageList(txtLocation.Text, SearchOption.TopDirectoryOnly)).Count().ToString();
                    statusStrip1.Refresh();
                }
            }

        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files (*.tif;*.jpg)|*.tif;*.jpg";
            if (SelectedIndex == -1)
            {
                panHeader.Visible = false;
                gpbOptions.Visible = false;
                robBQ.Checked = true;
                robEQ.Enabled = false;
                robASQ.Enabled = false;
                robBSQ.Enabled = false;
            }
            else
            {
                panHeader.Visible = true;
                gpbOptions.Visible = true;

                lblSelectedFile.Text = SelectedFileName;
                lblSelectedFile.Refresh();
                lblSerialNo.Text = (SelectedIndex + 1).ToString();
                lblSerialNo.Refresh();

                robBQ.Checked = true;
                robEQ.Enabled = true;
                robASQ.Enabled = true;
                robBSQ.Enabled = true;

            }
            rabSingleImage.Checked = true;
        }
    }
}
