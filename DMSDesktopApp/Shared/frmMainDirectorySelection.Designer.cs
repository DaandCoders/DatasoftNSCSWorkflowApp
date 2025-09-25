namespace DMS.DesktopApp.Shared
{
    partial class frmMainDirectorySelection
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
            groupBox1 = new GroupBox();
            cobScanDate = new ComboBox();
            label1 = new Label();
            btnLoad = new Button();
            btnClose = new Button();
            lblTotalFileRemaining = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cobScanDate);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(550, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cobScanDate
            // 
            cobScanDate.FormattingEnabled = true;
            cobScanDate.Location = new Point(130, 39);
            cobScanDate.Name = "cobScanDate";
            cobScanDate.Size = new Size(377, 28);
            cobScanDate.TabIndex = 1;
            cobScanDate.SelectedIndexChanged += cobScanDate_SelectedIndexChanged;
            cobScanDate.Click += cobScanDate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 44);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Tag = "Select Date";
            label1.Text = "Select Date";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.RoyalBlue;
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatStyle = FlatStyle.Popup;
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(314, 140);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Tag = "Load";
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(429, 140);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTotalFileRemaining
            // 
            lblTotalFileRemaining.AutoSize = true;
            lblTotalFileRemaining.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalFileRemaining.Location = new Point(16, 140);
            lblTotalFileRemaining.Name = "lblTotalFileRemaining";
            lblTotalFileRemaining.Size = new Size(160, 20);
            lblTotalFileRemaining.TabIndex = 3;
            lblTotalFileRemaining.Text = "Total files remaining: ";
            // 
            // frmMainDirectorySelection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(579, 192);
            Controls.Add(lblTotalFileRemaining);
            Controls.Add(btnClose);
            Controls.Add(btnLoad);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMainDirectorySelection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Main Directory";
            Load += frmMainDirectorySelection_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cobScanDate;
        private Label label1;
        private Button btnLoad;
        private Button btnClose;
        private Label lblTotalFileRemaining;
    }
}