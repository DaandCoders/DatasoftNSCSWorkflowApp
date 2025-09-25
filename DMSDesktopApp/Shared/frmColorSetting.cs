using DMS.DesktopApp.Properties;
using System.Threading;

namespace DMS.DesktopApp.Shared
{
    public partial class frmColorSetting : Form
    {
        bool buttonPressed = false;
        Thread thread;
        CancellationTokenSource cancellationTokenSource;

        public frmColorSetting()
        {
            InitializeComponent();
        }

        private void BackgroundThread(object cancellationTokenObj)
        {
            var cancellationToken = (CancellationToken)cancellationTokenObj;

            while (!cancellationToken.IsCancellationRequested)
            {
                if (buttonPressed)
                {
                    Point cursorPosition = Cursor.Position;
                    Color selectedColor = GetColorAt(cursorPosition);
                    panColor.BackColor = selectedColor;
                    string hexValue = ColorTranslator.ToHtml(selectedColor);
                    txtColorCode.Text = hexValue;
                    //Thread.Sleep(100);
                }
            }
        }

        private Color GetColorAt(Point location)
        {
            using (Bitmap pixcelContainer = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(pixcelContainer))
                {
                    g.CopyFromScreen(location, Point.Empty, pixcelContainer.Size);
                }
                return pixcelContainer.GetPixel(0, 0);
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            cancellationTokenSource = new CancellationTokenSource();
            thread = new Thread(BackgroundThread) { IsBackground = true };
            thread.Start(cancellationTokenSource.Token);
            //Thread.Sleep(5000);
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {

        }

        private void btnColorPicker_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressed = true;
            Cursor = Cursors.Cross;
        }

        private void btnColorPicker_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressed = false;
            Cursor = Cursors.Default;
        }

        private void btnSysytemColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtColorCode.Text = ColorTranslator.ToHtml(colorDialog.Color);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Settings.Default.CleanColor = txtColorCode.Text;
            Settings.Default.Save();
            MessageBox.Show(this, "Setting saved successfully.", "Color Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            thread.Join();
            Close();
        }

        private void frmColorSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
            thread.Join();
        }
    }
}
