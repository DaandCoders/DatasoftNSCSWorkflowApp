namespace DMS.DesktopApp.Shared
{
    partial class frmSplashScreen
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
            components = new System.ComponentModel.Container();
            timer = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            lblCompanyName = new Label();
            lblCompanyAddress = new Label();
            label1 = new Label();
            lblVersion = new Label();
            progressBar1 = new ProgressBar();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 4000;
            timer.Tick += Timer_TickAsync;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.DCSLogo;
            pictureBox1.Location = new Point(510, 4);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(234, 123);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.BackColor = Color.White;
            lblCompanyName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblCompanyName.Location = new Point(486, 151);
            lblCompanyName.Margin = new Padding(4, 0, 4, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(282, 25);
            lblCompanyName.TabIndex = 2;
            lblCompanyName.Text = "Datasoft Computer Services";
            lblCompanyName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCompanyAddress
            // 
            lblCompanyAddress.AutoSize = true;
            lblCompanyAddress.BackColor = Color.White;
            lblCompanyAddress.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblCompanyAddress.Location = new Point(481, 180);
            lblCompanyAddress.Margin = new Padding(4, 0, 4, 0);
            lblCompanyAddress.Name = "lblCompanyAddress";
            lblCompanyAddress.Size = new Size(292, 48);
            lblCompanyAddress.TabIndex = 3;
            lblCompanyAddress.Text = "DDA Market, Hargobind Enclave, \r\nDelhi, 110092, India";
            lblCompanyAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F);
            label1.Location = new Point(498, 227);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(259, 24);
            label1.TabIndex = 4;
            label1.Text = "website : www.datasoftindia.in";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.White;
            lblVersion.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblVersion.Location = new Point(430, 271);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(40, 17);
            lblVersion.TabIndex = 6;
            lblVersion.Text = "0.0.0";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(434, 302);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(387, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.splash_screen_image_;
            pictureBox2.Location = new Point(-8, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(395, 361);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // frmSplashScreen
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(829, 359);
            ControlBox = false;
            Controls.Add(pictureBox2);
            Controls.Add(progressBar1);
            Controls.Add(lblVersion);
            Controls.Add(label1);
            Controls.Add(lblCompanyAddress);
            Controls.Add(lblCompanyName);
            Controls.Add(pictureBox1);
            Font = new Font("Microsoft Sans Serif", 9F);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSplashScreen";
            Padding = new Padding(23, 69, 23, 23);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += FrmSplashScreen_FormClosing;
            Load += FrmSplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private PictureBox pictureBox1;
        private Label lblCompanyName;
        private Label lblCompanyAddress;
        private Label label1;
        private Label lblVersion;
        private ProgressBar progressBar;
        private ProgressBar progressBar1;
        private PictureBox pictureBox2;
    }
}