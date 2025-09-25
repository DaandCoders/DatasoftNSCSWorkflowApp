namespace DMS.DesktopApp.QC
{
    partial class frmBlankMageProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            lblTotalSelectedImage = new ToolStripStatusLabel();
            lblTotalImages = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cobBlankType = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDisplayAll = new ToolStripButton();
            btnDeleteImage = new ToolStripButton();
            imgBox = new UKA.Windows.Forms.ImageBox();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTotalSelectedImage, lblTotalImages });
            statusStrip1.Location = new Point(0, 689);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1265, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalSelectedImage
            // 
            lblTotalSelectedImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalSelectedImage.Name = "lblTotalSelectedImage";
            lblTotalSelectedImage.Size = new Size(180, 20);
            lblTotalSelectedImage.Text = "Total Selected Image: 00";
            // 
            // lblTotalImages
            // 
            lblTotalImages.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalImages.Name = "lblTotalImages";
            lblTotalImages.Size = new Size(125, 20);
            lblTotalImages.Text = "Total Images: 00";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(imgBox);
            splitContainer1.Size = new Size(1265, 689);
            splitContainer1.SplitterDistance = 724;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 35);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(724, 654);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.WhiteSmoke;
            toolStrip1.ImageScalingSize = new Size(28, 28);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cobBlankType, toolStripSeparator1, btnDisplayAll, btnDeleteImage });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(724, 35);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(91, 32);
            toolStripLabel1.Text = "Blank Image";
            // 
            // cobBlankType
            // 
            cobBlankType.Items.AddRange(new object[] { "None", "On Size", "On Content", "On Both" });
            cobBlankType.Name = "cobBlankType";
            cobBlankType.Size = new Size(121, 35);
            cobBlankType.SelectedIndexChanged += cobBlankType_SelectedIndexChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 35);
            // 
            // btnDisplayAll
            // 
            btnDisplayAll.CheckOnClick = true;
            btnDisplayAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDisplayAll.Image = Properties.Resources.checkboxChecked50x;
            btnDisplayAll.ImageTransparentColor = Color.Magenta;
            btnDisplayAll.Name = "btnDisplayAll";
            btnDisplayAll.Size = new Size(32, 32);
            btnDisplayAll.Text = "Display All";
            btnDisplayAll.CheckedChanged += btnDisplayAll_CheckedChanged;
            btnDisplayAll.Click += btnDisplayAll_Click;
            // 
            // btnDeleteImage
            // 
            btnDeleteImage.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDeleteImage.Image = Properties.Resources.Delete;
            btnDeleteImage.ImageTransparentColor = Color.Magenta;
            btnDeleteImage.Name = "btnDeleteImage";
            btnDeleteImage.Size = new Size(32, 32);
            btnDeleteImage.Text = "Delete selected image";
            btnDeleteImage.Click += btnDeleteImage_Click;
            // 
            // imgBox
            // 
            imgBox.BackColor = Color.LightGray;
            imgBox.Dock = DockStyle.Fill;
            imgBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            imgBox.ForeColor = Color.Black;
            imgBox.GridDisplayMode = UKA.Windows.Forms.ImageBoxGridDisplayMode.None;
            imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            imgBox.Location = new Point(0, 0);
            imgBox.Margin = new Padding(5, 5, 5, 5);
            imgBox.Name = "imgBox";
            imgBox.SelectionMode = UKA.Windows.Forms.ImageBoxSelectionMode.Rectangle;
            imgBox.Size = new Size(536, 689);
            imgBox.SizeMode = UKA.Windows.Forms.ImageBoxSizeMode.Fit;
            imgBox.TabIndex = 1;
            imgBox.Text = "DCS Imaging";
            imgBox.TextAlign = ContentAlignment.BottomRight;
            // 
            // frmBlankMageProcess
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1265, 715);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmBlankMageProcess";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Delete images";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmBlankMageProcess_FormClosing;
            Load += frmImageBox_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTotalSelectedImage;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private UKA.Windows.Forms.ImageBox imgBox;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cobBlankType;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDisplayAll;
        private ToolStripButton btnDeleteImage;
        private ToolStripStatusLabel lblTotalImages;
    }
}