namespace DMS.DesktopApp.Sync
{
    partial class frmDataSync
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
            btnSync = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView = new DataGridView();
            dtSyncDate = new DateTimePicker();
            label1 = new Label();
            btnClose = new Button();
            lblErrorMessage = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            chkApplicationUsers = new CheckBox();
            chkFileDetails = new CheckBox();
            chkDirectories = new CheckBox();
            chkFileDirectories = new CheckBox();
            chkSubDirectories = new CheckBox();
            chkImageFileDetails = new CheckBox();
            chkDispatchedData = new CheckBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsProgressBar = new ToolStripProgressBar();
            lblResult = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            lblCurrentUser = new ToolStripStatusLabel();
            lblTotalTimeTaken = new ToolStripStatusLabel();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // btnSync
            // 
            btnSync.BackColor = Color.SeaGreen;
            btnSync.Cursor = Cursors.Hand;
            btnSync.FlatStyle = FlatStyle.Popup;
            btnSync.ForeColor = Color.White;
            btnSync.Location = new Point(676, 3);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(144, 32);
            btnSync.TabIndex = 0;
            btnSync.Text = "Sync";
            btnSync.UseVisualStyleBackColor = false;
            btnSync.Click += btnSync_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4756355F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.6196022F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.86995F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0348072F));
            tableLayoutPanel1.Controls.Add(dataGridView, 0, 3);
            tableLayoutPanel1.Controls.Add(dtSyncDate, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSync, 3, 0);
            tableLayoutPanel1.Controls.Add(btnClose, 3, 1);
            tableLayoutPanel1.Controls.Add(lblErrorMessage, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.62251663F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.11920547F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.2317877F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.02649F));
            tableLayoutPanel1.Size = new Size(899, 604);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dataGridView, 4);
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 178);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(893, 423);
            dataGridView.TabIndex = 1;
            // 
            // dtSyncDate
            // 
            dtSyncDate.CustomFormat = "dd-MM-yyyy";
            dtSyncDate.Format = DateTimePickerFormat.Custom;
            dtSyncDate.Location = new Point(115, 3);
            dtSyncDate.Name = "dtSyncDate";
            dtSyncDate.Size = new Size(218, 30);
            dtSyncDate.TabIndex = 2;
            dtSyncDate.ValueChanged += dtSyncDate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 40);
            label1.TabIndex = 3;
            label1.Text = "Sync Date";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(676, 43);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(144, 32);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblErrorMessage, 3);
            lblErrorMessage.Dock = DockStyle.Fill;
            lblErrorMessage.ForeColor = Color.DarkRed;
            lblErrorMessage.Location = new Point(3, 40);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(667, 43);
            lblErrorMessage.TabIndex = 5;
            lblErrorMessage.Text = "Error";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 4);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(chkApplicationUsers, 0, 0);
            tableLayoutPanel2.Controls.Add(chkFileDetails, 1, 0);
            tableLayoutPanel2.Controls.Add(chkDirectories, 2, 0);
            tableLayoutPanel2.Controls.Add(chkFileDirectories, 3, 0);
            tableLayoutPanel2.Controls.Add(chkSubDirectories, 0, 1);
            tableLayoutPanel2.Controls.Add(chkImageFileDetails, 1, 1);
            tableLayoutPanel2.Controls.Add(chkDispatchedData, 2, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 86);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(893, 86);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // chkApplicationUsers
            // 
            chkApplicationUsers.AutoSize = true;
            chkApplicationUsers.Checked = true;
            chkApplicationUsers.CheckState = CheckState.Checked;
            chkApplicationUsers.Dock = DockStyle.Fill;
            chkApplicationUsers.Location = new Point(3, 3);
            chkApplicationUsers.Name = "chkApplicationUsers";
            chkApplicationUsers.Size = new Size(217, 37);
            chkApplicationUsers.TabIndex = 0;
            chkApplicationUsers.Tag = "ApplicationUsers";
            chkApplicationUsers.Text = "Application Users";
            chkApplicationUsers.UseVisualStyleBackColor = true;
            chkApplicationUsers.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // chkFileDetails
            // 
            chkFileDetails.AutoSize = true;
            chkFileDetails.Checked = true;
            chkFileDetails.CheckState = CheckState.Checked;
            chkFileDetails.Dock = DockStyle.Fill;
            chkFileDetails.Location = new Point(226, 3);
            chkFileDetails.Name = "chkFileDetails";
            chkFileDetails.Size = new Size(217, 37);
            chkFileDetails.TabIndex = 0;
            chkFileDetails.Tag = "FileDetails";
            chkFileDetails.Text = "File Details";
            chkFileDetails.UseVisualStyleBackColor = true;
            chkFileDetails.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // chkDirectories
            // 
            chkDirectories.AutoSize = true;
            chkDirectories.Checked = true;
            chkDirectories.CheckState = CheckState.Checked;
            chkDirectories.Dock = DockStyle.Fill;
            chkDirectories.Location = new Point(449, 3);
            chkDirectories.Name = "chkDirectories";
            chkDirectories.Size = new Size(217, 37);
            chkDirectories.TabIndex = 0;
            chkDirectories.Tag = "Directories";
            chkDirectories.Text = "Directories";
            chkDirectories.UseVisualStyleBackColor = true;
            chkDirectories.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // chkFileDirectories
            // 
            chkFileDirectories.AutoSize = true;
            chkFileDirectories.Checked = true;
            chkFileDirectories.CheckState = CheckState.Checked;
            chkFileDirectories.Dock = DockStyle.Fill;
            chkFileDirectories.Location = new Point(672, 3);
            chkFileDirectories.Name = "chkFileDirectories";
            chkFileDirectories.Size = new Size(218, 37);
            chkFileDirectories.TabIndex = 0;
            chkFileDirectories.Tag = "FileDirectories";
            chkFileDirectories.Text = "File Directories";
            chkFileDirectories.UseVisualStyleBackColor = true;
            chkFileDirectories.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // chkSubDirectories
            // 
            chkSubDirectories.AutoSize = true;
            chkSubDirectories.Checked = true;
            chkSubDirectories.CheckState = CheckState.Checked;
            chkSubDirectories.Dock = DockStyle.Fill;
            chkSubDirectories.Location = new Point(3, 46);
            chkSubDirectories.Name = "chkSubDirectories";
            chkSubDirectories.Size = new Size(217, 37);
            chkSubDirectories.TabIndex = 0;
            chkSubDirectories.Tag = "SubDirectories";
            chkSubDirectories.Text = "Sub Directories";
            chkSubDirectories.UseVisualStyleBackColor = true;
            chkSubDirectories.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // chkImageFileDetails
            // 
            chkImageFileDetails.AutoSize = true;
            chkImageFileDetails.Checked = true;
            chkImageFileDetails.CheckState = CheckState.Checked;
            chkImageFileDetails.Dock = DockStyle.Fill;
            chkImageFileDetails.Location = new Point(226, 46);
            chkImageFileDetails.Name = "chkImageFileDetails";
            chkImageFileDetails.Size = new Size(217, 37);
            chkImageFileDetails.TabIndex = 0;
            chkImageFileDetails.Tag = "ImageFileDetails";
            chkImageFileDetails.Text = "Image File Details";
            chkImageFileDetails.UseVisualStyleBackColor = true;
            chkImageFileDetails.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // chkDispatchedData
            // 
            chkDispatchedData.AutoSize = true;
            chkDispatchedData.Checked = true;
            chkDispatchedData.CheckState = CheckState.Checked;
            chkDispatchedData.Dock = DockStyle.Fill;
            chkDispatchedData.Location = new Point(449, 46);
            chkDispatchedData.Name = "chkDispatchedData";
            chkDispatchedData.Size = new Size(217, 37);
            chkDispatchedData.TabIndex = 1;
            chkDispatchedData.Tag = "DispatchedData";
            chkDispatchedData.Text = "Dispatched Data";
            chkDispatchedData.UseVisualStyleBackColor = true;
            chkDispatchedData.CheckedChanged += chkBoxCheckUncheck_CheckedChanged;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tsProgressBar, lblResult, toolStripStatusLabel2, toolStripStatusLabel3, lblCurrentUser, lblTotalTimeTaken });
            statusStrip.Location = new Point(0, 604);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(899, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(52, 20);
            toolStripStatusLabel1.Text = "Status:";
            // 
            // tsProgressBar
            // 
            tsProgressBar.Name = "tsProgressBar";
            tsProgressBar.Size = new Size(100, 18);
            // 
            // lblResult
            // 
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(37, 20);
            lblResult.Text = "00%";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(505, 20);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(93, 20);
            toolStripStatusLabel3.Text = "Current User:";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(30, 20);
            lblCurrentUser.Text = "xxx";
            // 
            // lblTotalTimeTaken
            // 
            lblTotalTimeTaken.Name = "lblTotalTimeTaken";
            lblTotalTimeTaken.Size = new Size(63, 20);
            lblTotalTimeTaken.Text = "00:00:00";
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // frmDataSync
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(899, 630);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmDataSync";
            Text = "Sync";
            Load += frmDataSync_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSync;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView;
        private StatusStrip statusStrip;
        private DateTimePicker dtSyncDate;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar tsProgressBar;
        private ToolStripStatusLabel lblResult;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel lblCurrentUser;
        private Button btnClose;
        private Label lblErrorMessage;
        private ToolStripStatusLabel lblTotalTimeTaken;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox chkApplicationUsers;
        private CheckBox chkFileDetails;
        private CheckBox chkDirectories;
        private CheckBox chkFileDirectories;
        private CheckBox chkSubDirectories;
        private CheckBox chkImageFileDetails;
        private CheckBox chkDispatchedData;
    }
}