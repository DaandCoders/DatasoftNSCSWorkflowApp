namespace DMS.DesktopApp.Admin
{
    partial class frmChangeFileStatus
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label1 = new Label();
            cobFileType = new ComboBox();
            cobStatus = new ComboBox();
            lblFolderDetails = new Label();
            txtFileName = new TextBox();
            label2 = new Label();
            lblStatus = new Label();
            btnChangeStatus = new Button();
            btnClose = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cobFileType);
            groupBox1.Controls.Add(cobStatus);
            groupBox1.Controls.Add(lblFolderDetails);
            groupBox1.Controls.Add(txtFileName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Location = new Point(10, 19);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(534, 134);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 56);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 5;
            label1.Text = "File Type";
            // 
            // cobFileType
            // 
            cobFileType.FormattingEnabled = true;
            cobFileType.Items.AddRange(new object[] { "NS", "CS" });
            cobFileType.Location = new Point(91, 53);
            cobFileType.Margin = new Padding(3, 2, 3, 2);
            cobFileType.Name = "cobFileType";
            cobFileType.Size = new Size(347, 23);
            cobFileType.TabIndex = 3;
            // 
            // cobStatus
            // 
            cobStatus.FormattingEnabled = true;
            cobStatus.Items.AddRange(new object[] { "Open For Scanning", "Open For Operator QC", "Open For Department QC" });
            cobStatus.Location = new Point(91, 83);
            cobStatus.Margin = new Padding(3, 2, 3, 2);
            cobStatus.Name = "cobStatus";
            cobStatus.Size = new Size(347, 23);
            cobStatus.TabIndex = 3;
            // 
            // lblFolderDetails
            // 
            lblFolderDetails.AutoSize = true;
            lblFolderDetails.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFolderDetails.Location = new Point(20, 65);
            lblFolderDetails.Name = "lblFolderDetails";
            lblFolderDetails.Size = new Size(0, 15);
            lblFolderDetails.TabIndex = 2;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(91, 21);
            txtFileName.Margin = new Padding(3, 2, 3, 2);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(347, 23);
            txtFileName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 21);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 0;
            label2.Text = "File Name";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(34, 86);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status";
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.BackColor = Color.RoyalBlue;
            btnChangeStatus.FlatStyle = FlatStyle.Popup;
            btnChangeStatus.ForeColor = Color.White;
            btnChangeStatus.Location = new Point(342, 157);
            btnChangeStatus.Margin = new Padding(3, 2, 3, 2);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(106, 22);
            btnChangeStatus.TabIndex = 1;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = false;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(454, 157);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(82, 22);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmChangeFileStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(558, 190);
            Controls.Add(btnClose);
            Controls.Add(btnChangeStatus);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmChangeFileStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Batch Load";
            Load += frmChangeFileStatus_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnChangeStatus;
        private Button btnClose;
        private TextBox txtBatchLoad;
        private Label lblStatus;
        private Label lblFolderDetails;
        private FolderBrowserDialog folderBrowserDialog;
        private ComboBox cobStatus;
        private TextBox txtFileName;
        private Label label2;
        private Button btnBrowse;
        private Label label1;
        private ComboBox cobFileType;
    }
}