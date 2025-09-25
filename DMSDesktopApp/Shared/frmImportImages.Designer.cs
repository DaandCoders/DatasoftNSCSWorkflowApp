namespace DMSDesktopApp.Shared
{
    partial class frmImportImages
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
            label1 = new Label();
            txtLocation = new TextBox();
            btnBrowse = new Button();
            gpbOptions = new GroupBox();
            robASQ = new RadioButton();
            robBSQ = new RadioButton();
            robBQ = new RadioButton();
            robEQ = new RadioButton();
            label2 = new Label();
            lblSelectedFile = new Label();
            label4 = new Label();
            lblSerialNo = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblTotalFiles = new ToolStripStatusLabel();
            panHeader = new Panel();
            groupBox1 = new GroupBox();
            rabMultipleIMage = new RadioButton();
            rabSingleImage = new RadioButton();
            openFileDialog = new OpenFileDialog();
            gpbOptions.SuspendLayout();
            statusStrip1.SuspendLayout();
            panHeader.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 231);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Location ";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(100, 228);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(404, 27);
            txtLocation.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.MediumSeaGreen;
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatStyle = FlatStyle.Popup;
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(510, 226);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(124, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // gpbOptions
            // 
            gpbOptions.Controls.Add(robASQ);
            gpbOptions.Controls.Add(robBSQ);
            gpbOptions.Controls.Add(robBQ);
            gpbOptions.Controls.Add(robEQ);
            gpbOptions.Location = new Point(6, 277);
            gpbOptions.Name = "gpbOptions";
            gpbOptions.Size = new Size(628, 138);
            gpbOptions.TabIndex = 3;
            gpbOptions.TabStop = false;
            gpbOptions.Text = "select one for import";
            // 
            // robASQ
            // 
            robASQ.AutoSize = true;
            robASQ.Enabled = false;
            robASQ.Location = new Point(25, 85);
            robASQ.Name = "robASQ";
            robASQ.Size = new Size(233, 24);
            robASQ.TabIndex = 3;
            robASQ.TabStop = true;
            robASQ.Tag = "ASQ";
            robASQ.Text = "After selected file in the queue";
            robASQ.UseVisualStyleBackColor = true;
            // 
            // robBSQ
            // 
            robBSQ.AutoSize = true;
            robBSQ.Enabled = false;
            robBSQ.Location = new Point(281, 85);
            robBSQ.Name = "robBSQ";
            robBSQ.Size = new Size(277, 24);
            robBSQ.TabIndex = 2;
            robBSQ.TabStop = true;
            robBSQ.Tag = "BSQ";
            robBSQ.Text = "Before start selected file in the queue";
            robBSQ.UseVisualStyleBackColor = true;
            // 
            // robBQ
            // 
            robBQ.AutoSize = true;
            robBQ.Location = new Point(281, 36);
            robBQ.Name = "robBQ";
            robBQ.Size = new Size(177, 24);
            robBQ.TabIndex = 1;
            robBQ.TabStop = true;
            robBQ.Tag = "BQ";
            robBQ.Text = "Begining of the queue";
            robBQ.UseVisualStyleBackColor = true;
            // 
            // robEQ
            // 
            robEQ.AutoSize = true;
            robEQ.Enabled = false;
            robEQ.Location = new Point(25, 36);
            robEQ.Name = "robEQ";
            robEQ.Size = new Size(143, 24);
            robEQ.TabIndex = 0;
            robEQ.TabStop = true;
            robEQ.Tag = "EQ";
            robEQ.Text = "End of the queue";
            robEQ.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(19, 16);
            label2.Name = "label2";
            label2.Size = new Size(134, 28);
            label2.TabIndex = 4;
            label2.Text = "Selected file:";
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Font = new Font("Segoe UI", 12F);
            lblSelectedFile.Location = new Point(159, 16);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(187, 28);
            lblSelectedFile.TabIndex = 5;
            lblSelectedFile.Text = "xxxxxxxxxxxxxxxxx.tif";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(19, 63);
            label4.Name = "label4";
            label4.Size = new Size(190, 28);
            label4.TabIndex = 6;
            label4.Text = "Selected Serial No:";
            // 
            // lblSerialNo
            // 
            lblSerialNo.AutoSize = true;
            lblSerialNo.Font = new Font("Segoe UI", 12F);
            lblSerialNo.Location = new Point(211, 63);
            lblSerialNo.Name = "lblSerialNo";
            lblSerialNo.Size = new Size(23, 28);
            lblSerialNo.TabIndex = 7;
            lblSerialNo.Text = "2";
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.RoyalBlue;
            btnOK.Cursor = Cursors.Hand;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(380, 454);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(124, 29);
            btnOK.TabIndex = 8;
            btnOK.Text = "Ok";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += button2_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(510, 454);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(124, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblTotalFiles });
            statusStrip1.Location = new Point(0, 482);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(655, 26);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(75, 20);
            toolStripStatusLabel1.Text = "Total Files";
            // 
            // lblTotalFiles
            // 
            lblTotalFiles.Name = "lblTotalFiles";
            lblTotalFiles.Size = new Size(25, 20);
            lblTotalFiles.Text = "00";
            // 
            // panHeader
            // 
            panHeader.Controls.Add(label4);
            panHeader.Controls.Add(lblSerialNo);
            panHeader.Controls.Add(lblSelectedFile);
            panHeader.Controls.Add(label2);
            panHeader.Location = new Point(6, 7);
            panHeader.Name = "panHeader";
            panHeader.Size = new Size(628, 110);
            panHeader.TabIndex = 11;
            panHeader.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rabMultipleIMage);
            groupBox1.Controls.Add(rabSingleImage);
            groupBox1.Location = new Point(6, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(628, 58);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Option";
            // 
            // rabMultipleIMage
            // 
            rabMultipleIMage.AutoSize = true;
            rabMultipleIMage.Location = new Point(259, 22);
            rabMultipleIMage.Name = "rabMultipleIMage";
            rabMultipleIMage.Size = new Size(131, 24);
            rabMultipleIMage.TabIndex = 1;
            rabMultipleIMage.TabStop = true;
            rabMultipleIMage.Text = "Multiple Image";
            rabMultipleIMage.UseVisualStyleBackColor = true;
            // 
            // rabSingleImage
            // 
            rabSingleImage.AutoSize = true;
            rabSingleImage.Location = new Point(63, 22);
            rabSingleImage.Name = "rabSingleImage";
            rabSingleImage.Size = new Size(117, 24);
            rabSingleImage.TabIndex = 0;
            rabSingleImage.TabStop = true;
            rabSingleImage.Text = "Single Image";
            rabSingleImage.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            openFileDialog.Title = "Select  single image";
            // 
            // frmImportImages
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(655, 508);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(gpbOptions);
            Controls.Add(btnBrowse);
            Controls.Add(txtLocation);
            Controls.Add(label1);
            Controls.Add(panHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmImportImages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Import";
            Load += frmImport_Load;
            gpbOptions.ResumeLayout(false);
            gpbOptions.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panHeader.ResumeLayout(false);
            panHeader.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnBrowse;
        private Label label2;
        private Label lblSelectedFile;
        private Label label4;
        private Label lblSerialNo;
        private Button btnOK;
        private Button btnCancel;
        public TextBox txtLocation;
        public RadioButton robBQ;
        public RadioButton robEQ;
        public RadioButton robASQ;
        public RadioButton robBSQ;
        private FolderBrowserDialog folderBrowserDialog;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblTotalFiles;
        private Panel panHeader;
        public GroupBox gpbOptions;
        private GroupBox groupBox1;
        public RadioButton rabMultipleIMage;
        public RadioButton rabSingleImage;
        private OpenFileDialog openFileDialog;
    }
}