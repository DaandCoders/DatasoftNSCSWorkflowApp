using AForge.Imaging.Filters;
using DC.ImagUtility.Q16.Services;
using DC.Process;
using DMS.DesktopApp.Properties;
using System.Drawing.Imaging;
using UKA.Windows.Forms;

namespace DMS.DesktopApp.QC
{

    public partial class frmBlankMageProcess : Form
    {
        private string SourcePath;
        private string DeletedSourcePath;
        public List<string> SelectedPictures;
        bool IsDIsplayAll = true;

        public frmBlankMageProcess(string path)
        {
            InitializeComponent();
            SelectedPictures = new List<string>();
            SourcePath = path;
        }

        private void PictureBox_Click(object sender, EventArgs e, ImageBox pic)
        {
            if (SelectedPictures.Contains(pic.Tag.ToString()!))
            {
                SelectedPictures.Remove(pic.Tag.ToString()!);
                pic.BorderStyle = BorderStyle.FixedSingle;
                RemoveSelectionOverlay(pic);
            }
            else
            {
                SelectedPictures.Add(pic.Tag.ToString()!);
                pic.BorderStyle = BorderStyle.Fixed3D;
                ApplySelectionOverlay(pic);
            }
            UpdateSelectedImageCount();
        }

        private void UpdateSelectedImageCount()
        {
            lblTotalSelectedImage.Text = $"Selected Images: {SelectedPictures.Count}";
        }

        private async void ApplySelectionOverlay(ImageBox pic)
        {
            try
            {
                pic.BorderStyle = BorderStyle.Fixed3D;

                Bitmap originalImage = new Bitmap(pic.Image);

                Bitmap processedImage = await Task.Run(() =>
                {
                    Bitmap blurredImage = ApplyBlurEffectAsync(originalImage);
                    return ApplyDarkOverlay(blurredImage, 80);
                });

                pic.Invoke((MethodInvoker)(() => pic.Image = processedImage));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying selection overlay: " + ex.Message);
            }
        }

        private Bitmap ApplyDarkOverlay(Bitmap image, int darknessLevel)
        {
            Bitmap newBitmap = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));

                using (Brush darkBrush = new SolidBrush(Color.FromArgb(darknessLevel, 0, 0, 0))) // Alpha, R, G, B
                {
                    g.FillRectangle(darkBrush, new Rectangle(0, 0, image.Width, image.Height));
                }
            }
            return newBitmap;
        }

        private Bitmap ApplyOpacity(Bitmap image, int alpha)
        {
            Bitmap newBitmap = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix
                {
                    Matrix33 = alpha / 255f // Set opacity (0-255)
                };

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }

        private void RemoveSelectionOverlay(ImageBox pic)
        {
            string originalImagePath = pic.Tag.ToString();
            var ms = GetImageStream(originalImagePath);
            pic.Image = Bitmap.FromStream(ms).GetThumbnailImage(100, 100, null, IntPtr.Zero);
            if (pic.Controls.Count > 0)
            {
                pic.Controls.Clear();
            }
        }

        private Bitmap ApplyBlurEffectAsync(Bitmap image)
        {
            GaussianBlur blurFilter = new GaussianBlur(4.0);
            return blurFilter.Apply(image);
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e, ImageBox originalPic)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(originalPic.Tag.ToString())))
                {
                    imgBox.Image = null;
                    imgBox.SelectionColor = Color.RoyalBlue;
                    imgBox.Image = Bitmap.FromStream(ms);
                    imgBox.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error on Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
        }

        private void frmImageBox_Load(object sender, EventArgs e)
        {
            cobBlankType.SelectedIndex = 0;
        }

        private void LoadFiles()
        {
            Cursor = Cursors.WaitCursor;
            imgBox.Image = null;
            int imageSize = 100;
            int spacing = 10;
            var fileList = Files.GetImageList(SourcePath,SearchOption.TopDirectoryOnly);
            if (fileList == null)
            {
                MessageBox.Show(this, "No image file found for process.", "Process Blank Image", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            ClearDisplay();
            
            if (IsDIsplayAll)
            {
                LoadAllImages(fileList, imageSize, spacing);
            }
            else
            {
                LoadBlankImages(fileList, imageSize, spacing);
            }
            lblTotalImages.Text = $"Total Images: {fileList.Count}";
            UpdateSelectedImageCount();
            Cursor = Cursors.Default;
        }

        private void LoadAllImages(List<string> fileList, int imageSize, int spacing)
        {

            foreach (var file in fileList)
            {
                try
                {

                    ImageBox picBox = new ImageBox();
                    var ms = GetImageStream(file);
                    picBox.Image = Bitmap.FromStream(ms).GetThumbnailImage(100, 100, null, IntPtr.Zero);
                    picBox.SizeMode = ImageBoxSizeMode.Stretch;
                    picBox.Width = imageSize;
                    picBox.Height = imageSize;
                    picBox.Tag = file;
                    picBox.Margin = new Padding(spacing);
                    picBox.BorderStyle = BorderStyle.FixedSingle;
                    picBox.Click += (s, e) => PictureBox_Click(s, e, picBox);
                    picBox.MouseEnter += (s, e) => PictureBox_MouseEnter(s, e, picBox);
                    picBox.MouseLeave += PictureBox_MouseLeave;
                    flowLayoutPanel1.Controls.Add(picBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Image GetThumnailImage(string file)
        {
            Image originalImage = Image.FromFile(file);

            int thumbnailWidth = 100;
            int thumbnailHeight = 100;

            return originalImage.GetThumbnailImage(thumbnailWidth, thumbnailHeight, null, IntPtr.Zero);
        }

        private Stream GetImageStream(string file)
        {
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            return ms;
        }

        private void LoadBlankImages(List<string> fileList, int imageSize, int spacing)
        {

            foreach (var file in fileList)
            {

                bool isBlankImage = false;

                switch (cobBlankType.SelectedIndex)
                {
                    case 1:
                        isBlankImage = new ImageProcess(file).IsBlankImage(file, BlankImageType.Size, Settings.Default.BlankPageSize);
                        break;
                    case 2:
                        isBlankImage = new ImageProcess(file).IsBlankImage(file, BlankImageType.Content, Settings.Default.BlankPageSize);
                        break;
                    case 3:
                        isBlankImage = new ImageProcess(file).IsBlankImage(file, BlankImageType.Both, Settings.Default.BlankPageSize);
                        break;
                    default:
                        isBlankImage = false;
                        break;
                }
                if (isBlankImage)
                {
                    try
                    {
                        ImageBox picBox = new ImageBox();
                        var ms = GetImageStream(file);
                        picBox.Image = Bitmap.FromStream(ms).GetThumbnailImage(100, 100, null, IntPtr.Zero);
                        picBox.SizeMode = ImageBoxSizeMode.Stretch;
                        picBox.Width = imageSize;
                        picBox.Height = imageSize;
                        picBox.Tag = file;
                        picBox.Margin = new Padding(spacing);
                        picBox.BorderStyle = BorderStyle.FixedSingle;
                        picBox.Click += (s, e) => PictureBox_Click(s, e, picBox);
                        picBox.MouseEnter += (s, e) => PictureBox_MouseEnter(s, e, picBox);
                        picBox.MouseLeave += PictureBox_MouseLeave;
                        flowLayoutPanel1.Controls.Add(picBox);
                        ApplySelectionOverlay(picBox);
                        SelectedPictures.Add(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    UpdateSelectedImageCount();
                }
            }
        }

        private void btnDisplayAll_CheckedChanged(object sender, EventArgs e)
        {
            btnDisplayAll.Image = btnDisplayAll.Checked ? Resources.checkboxChecked50x : Resources.checkboxUnchecked50x;
            if (btnDisplayAll.Checked)
                IsDIsplayAll = true;
            else
                IsDIsplayAll = false;
            ClearDisplay();
            LoadFiles();
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {

        }

        private void cobBlankType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobBlankType.SelectedIndex == 0)
                btnDisplayAll.Checked = true;
            else
                btnDisplayAll.Checked = false;
        }

        private void ClearDisplay()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Refresh();
            imgBox.Image = null;
        }

        private void frmBlankMageProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelectedPictures.Clear();
            if (!string.IsNullOrEmpty(DeletedSourcePath))
            {
                SelectedPictures = Files.GetImageList(DeletedSourcePath, SearchOption.TopDirectoryOnly);
            }
            
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var result = MessageBox.Show("Are you to want delete all the selected images?", "Delete Image", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeletedSourcePath = Path.Combine(SourcePath, "Delete");
                string destination = DeletedSourcePath;
                Directory.CreateDirectory(destination);
                foreach (var file in SelectedPictures)
                {
                    try
                    {
                        File.Move(file, Path.Combine(destination, Path.GetFileName(file)), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                SelectedPictures.Clear();
                MessageBox.Show("All selected blank images deleted successfully.", "Delete Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                LoadFiles();
                return;
            }
            Cursor = Cursors.Default;
        }

        private void ClearAll()
        {
            ClearDisplay();
            lblTotalImages.Text = $"Total Images: {00}";
            lblTotalSelectedImage.Text = $"Selected Images: {00}";
        }
    }
}
