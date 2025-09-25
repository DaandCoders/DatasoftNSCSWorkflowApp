namespace DMS.DesktopApp.Dashboard
{
    partial class frmAdminDashboard
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
            menuStrip1 = new MenuStrip();
            menMaster = new ToolStripMenuItem();
            userRegistrationToolStripMenuItem = new ToolStripMenuItem();
            userManagementToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            menReport = new ToolStripMenuItem();
            menDayReport = new ToolStripMenuItem();
            menMetadataReport = new ToolStripMenuItem();
            menMISReport = new ToolStripMenuItem();
            exportDataToolStripMenuItem = new ToolStripMenuItem();
            importDataToolStripMenuItem = new ToolStripMenuItem();
            menChangeFileStatus = new ToolStripMenuItem();
            menSearchBarcode = new ToolStripMenuItem();
            dispatchToolStripMenuItem = new ToolStripMenuItem();
            menOtherDipatch = new ToolStripMenuItem();
            menBatchDispatch = new ToolStripMenuItem();
            backupRestoreToolStripMenuItem = new ToolStripMenuItem();
            menDBBackup = new ToolStripMenuItem();
            imageCountToolStripMenuItem = new ToolStripMenuItem();
            uploadDataToolStripMenuItem = new ToolStripMenuItem();
            changeLanguageToolStripMenuItem = new ToolStripMenuItem();
            menLogout = new ToolStripMenuItem();
            menAbout = new ToolStripMenuItem();
            menSync = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            spcAside = new SplitContainer();
            tlpCounts = new TableLayoutPanel();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            lblTotalFileReceived = new Label();
            lblTotalFileScanned = new Label();
            lblTotalFileQC = new Label();
            linkLabel5 = new LinkLabel();
            linkLabel6 = new LinkLabel();
            lblTotalFileDispatched = new Label();
            lblTotalFileQCByCLient = new Label();
            btnRefresh = new Button();
            pieChart1 = new LiveCharts.WinForms.PieChart();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            seprator1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            lblUserName = new ToolStripStatusLabel();
            btnExist = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcAside).BeginInit();
            spcAside.Panel1.SuspendLayout();
            spcAside.SuspendLayout();
            tlpCounts.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menMaster, menReport, menChangeFileStatus, menSearchBarcode, dispatchToolStripMenuItem, backupRestoreToolStripMenuItem, changeLanguageToolStripMenuItem, menLogout, menAbout, menSync });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1003, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menMaster
            // 
            menMaster.DropDownItems.AddRange(new ToolStripItem[] { userRegistrationToolStripMenuItem, userManagementToolStripMenuItem, changePasswordToolStripMenuItem });
            menMaster.Name = "menMaster";
            menMaster.Size = new Size(68, 24);
            menMaster.Tag = "Master";
            menMaster.Text = "Master";
            // 
            // userRegistrationToolStripMenuItem
            // 
            userRegistrationToolStripMenuItem.Name = "userRegistrationToolStripMenuItem";
            userRegistrationToolStripMenuItem.Size = new Size(213, 26);
            userRegistrationToolStripMenuItem.Tag = "User Registration";
            userRegistrationToolStripMenuItem.Text = "User Registration";
            userRegistrationToolStripMenuItem.Click += userRegistrationToolStripMenuItem_Click;
            // 
            // userManagementToolStripMenuItem
            // 
            userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            userManagementToolStripMenuItem.Size = new Size(213, 26);
            userManagementToolStripMenuItem.Tag = "User Management";
            userManagementToolStripMenuItem.Text = "User Management";
            userManagementToolStripMenuItem.Click += userManagementToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(213, 26);
            changePasswordToolStripMenuItem.Tag = "Change Password";
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // menReport
            // 
            menReport.DropDownItems.AddRange(new ToolStripItem[] { menDayReport, menMetadataReport, menMISReport, exportDataToolStripMenuItem, importDataToolStripMenuItem });
            menReport.Name = "menReport";
            menReport.Size = new Size(68, 24);
            menReport.Tag = "Report";
            menReport.Text = "Report";
            menReport.Click += menReport_Click;
            // 
            // menDayReport
            // 
            menDayReport.Name = "menDayReport";
            menDayReport.Size = new Size(205, 26);
            menDayReport.Tag = "Day Report";
            menDayReport.Text = "Day Report";
            menDayReport.Click += menDayReport_Click;
            // 
            // menMetadataReport
            // 
            menMetadataReport.Name = "menMetadataReport";
            menMetadataReport.Size = new Size(205, 26);
            menMetadataReport.Tag = "Metadata Report";
            menMetadataReport.Text = "Metadata Report";
            menMetadataReport.Visible = false;
            menMetadataReport.Click += menMetadataReport_Click;
            // 
            // menMISReport
            // 
            menMISReport.Name = "menMISReport";
            menMISReport.Size = new Size(205, 26);
            menMISReport.Tag = "MIS Report";
            menMISReport.Text = "MIS Report";
            menMISReport.Visible = false;
            menMISReport.Click += menMISReport_Click;
            // 
            // exportDataToolStripMenuItem
            // 
            exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            exportDataToolStripMenuItem.Size = new Size(205, 26);
            exportDataToolStripMenuItem.Tag = "Export Data";
            exportDataToolStripMenuItem.Text = "Export Data";
            exportDataToolStripMenuItem.Visible = false;
            exportDataToolStripMenuItem.Click += exportDataToolStripMenuItem_Click;
            // 
            // importDataToolStripMenuItem
            // 
            importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            importDataToolStripMenuItem.Size = new Size(205, 26);
            importDataToolStripMenuItem.Tag = "Import Data";
            importDataToolStripMenuItem.Text = "Import Data";
            importDataToolStripMenuItem.Visible = false;
            importDataToolStripMenuItem.Click += importDataToolStripMenuItem_Click;
            // 
            // menChangeFileStatus
            // 
            menChangeFileStatus.Name = "menChangeFileStatus";
            menChangeFileStatus.Size = new Size(144, 24);
            menChangeFileStatus.Tag = "Change File Status";
            menChangeFileStatus.Text = "Change File Status";
            menChangeFileStatus.Click += menChangeFileStatus_Click;
            // 
            // menSearchBarcode
            // 
            menSearchBarcode.Enabled = false;
            menSearchBarcode.Name = "menSearchBarcode";
            menSearchBarcode.Size = new Size(67, 24);
            menSearchBarcode.Tag = "Search";
            menSearchBarcode.Text = "Search";
            menSearchBarcode.Click += menSearchBarcode_Click;
            // 
            // dispatchToolStripMenuItem
            // 
            dispatchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menOtherDipatch, menBatchDispatch });
            dispatchToolStripMenuItem.Name = "dispatchToolStripMenuItem";
            dispatchToolStripMenuItem.Size = new Size(81, 24);
            dispatchToolStripMenuItem.Tag = "Dispatch";
            dispatchToolStripMenuItem.Text = "Dispatch";
            dispatchToolStripMenuItem.Click += dispatchToolStripMenuItem_Click;
            // 
            // menOtherDipatch
            // 
            menOtherDipatch.Name = "menOtherDipatch";
            menOtherDipatch.Size = new Size(129, 26);
            menOtherDipatch.Tag = "Other";
            menOtherDipatch.Text = "Other";
            menOtherDipatch.Visible = false;
            menOtherDipatch.Click += menOtherDipatch_Click;
            // 
            // menBatchDispatch
            // 
            menBatchDispatch.Name = "menBatchDispatch";
            menBatchDispatch.Size = new Size(129, 26);
            menBatchDispatch.Tag = "Batch";
            menBatchDispatch.Text = "Batch";
            menBatchDispatch.Click += menBatchDispatch_Click;
            // 
            // backupRestoreToolStripMenuItem
            // 
            backupRestoreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menDBBackup, imageCountToolStripMenuItem, uploadDataToolStripMenuItem });
            backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            backupRestoreToolStripMenuItem.Size = new Size(141, 24);
            backupRestoreToolStripMenuItem.Tag = "Backup && Restore";
            backupRestoreToolStripMenuItem.Text = "Backup && Restore";
            backupRestoreToolStripMenuItem.Click += backupRestoreToolStripMenuItem_Click;
            // 
            // menDBBackup
            // 
            menDBBackup.Name = "menDBBackup";
            menDBBackup.Size = new Size(207, 26);
            menDBBackup.Tag = "Database Backup";
            menDBBackup.Text = "Database Backup";
            menDBBackup.Click += menDBBackup_Click;
            // 
            // imageCountToolStripMenuItem
            // 
            imageCountToolStripMenuItem.Name = "imageCountToolStripMenuItem";
            imageCountToolStripMenuItem.Size = new Size(207, 26);
            imageCountToolStripMenuItem.Tag = "ImageCount";
            imageCountToolStripMenuItem.Text = "ImageCount";
            imageCountToolStripMenuItem.Visible = false;
            imageCountToolStripMenuItem.Click += imageCountToolStripMenuItem_Click;
            // 
            // uploadDataToolStripMenuItem
            // 
            uploadDataToolStripMenuItem.Name = "uploadDataToolStripMenuItem";
            uploadDataToolStripMenuItem.Size = new Size(207, 26);
            uploadDataToolStripMenuItem.Tag = "Upload Data";
            uploadDataToolStripMenuItem.Text = "Upload Data";
            uploadDataToolStripMenuItem.Click += uploadDataToolStripMenuItem_Click;
            // 
            // changeLanguageToolStripMenuItem
            // 
            changeLanguageToolStripMenuItem.Name = "changeLanguageToolStripMenuItem";
            changeLanguageToolStripMenuItem.Size = new Size(142, 24);
            changeLanguageToolStripMenuItem.Text = "Change Language";
            changeLanguageToolStripMenuItem.Click += changeLanguageToolStripMenuItem_Click;
            // 
            // menLogout
            // 
            menLogout.Name = "menLogout";
            menLogout.Size = new Size(70, 24);
            menLogout.Tag = "Logout";
            menLogout.Text = "Logout";
            menLogout.Click += menLogout_Click;
            // 
            // menAbout
            // 
            menAbout.Name = "menAbout";
            menAbout.Size = new Size(64, 24);
            menAbout.Tag = "About";
            menAbout.Text = "About";
            menAbout.Click += menAbout_Click;
            // 
            // menSync
            // 
            menSync.Name = "menSync";
            menSync.Size = new Size(53, 24);
            menSync.Text = "Sync";
            menSync.Click += menSync_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 30);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(spcAside);
            splitContainer1.Panel1.Padding = new Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(btnExist);
            splitContainer1.Panel2.Controls.Add(pieChart1);
            splitContainer1.Panel2.Padding = new Padding(5);
            splitContainer1.Size = new Size(1003, 639);
            splitContainer1.SplitterDistance = 318;
            splitContainer1.TabIndex = 4;
            // 
            // spcAside
            // 
            spcAside.Dock = DockStyle.Fill;
            spcAside.FixedPanel = FixedPanel.Panel1;
            spcAside.IsSplitterFixed = true;
            spcAside.Location = new Point(5, 5);
            spcAside.Name = "spcAside";
            spcAside.Orientation = Orientation.Horizontal;
            // 
            // spcAside.Panel1
            // 
            spcAside.Panel1.Controls.Add(tlpCounts);
            spcAside.Size = new Size(308, 629);
            spcAside.SplitterDistance = 255;
            spcAside.TabIndex = 1;
            // 
            // tlpCounts
            // 
            tlpCounts.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tlpCounts.ColumnCount = 2;
            tlpCounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.03658F));
            tlpCounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.9634151F));
            tlpCounts.Controls.Add(linkLabel1, 0, 0);
            tlpCounts.Controls.Add(linkLabel2, 0, 1);
            tlpCounts.Controls.Add(linkLabel3, 0, 2);
            tlpCounts.Controls.Add(lblTotalFileReceived, 1, 0);
            tlpCounts.Controls.Add(lblTotalFileScanned, 1, 1);
            tlpCounts.Controls.Add(lblTotalFileQC, 1, 2);
            tlpCounts.Controls.Add(linkLabel5, 0, 4);
            tlpCounts.Controls.Add(linkLabel6, 0, 3);
            tlpCounts.Controls.Add(lblTotalFileDispatched, 1, 4);
            tlpCounts.Controls.Add(lblTotalFileQCByCLient, 1, 3);
            tlpCounts.Controls.Add(btnRefresh, 1, 6);
            tlpCounts.Dock = DockStyle.Fill;
            tlpCounts.Location = new Point(0, 0);
            tlpCounts.Name = "tlpCounts";
            tlpCounts.RowCount = 7;
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.25F));
            tlpCounts.Size = new Size(308, 255);
            tlpCounts.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Dock = DockStyle.Fill;
            linkLabel1.Location = new Point(5, 2);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(208, 34);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Tag = "Total File Received";
            linkLabel1.Text = "Current Files Received Status";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Dock = DockStyle.Fill;
            linkLabel2.Location = new Point(5, 38);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(208, 34);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Tag = "Total File Scanned";
            linkLabel2.Text = "Current Files Scanned Status";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Dock = DockStyle.Fill;
            linkLabel3.Location = new Point(5, 74);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(208, 34);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Tag = "Total File QC";
            linkLabel3.Text = "Current Files  QC Status";
            // 
            // lblTotalFileReceived
            // 
            lblTotalFileReceived.AutoSize = true;
            lblTotalFileReceived.Dock = DockStyle.Fill;
            lblTotalFileReceived.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileReceived.Location = new Point(221, 2);
            lblTotalFileReceived.Name = "lblTotalFileReceived";
            lblTotalFileReceived.Size = new Size(82, 34);
            lblTotalFileReceived.TabIndex = 7;
            lblTotalFileReceived.Text = "00";
            // 
            // lblTotalFileScanned
            // 
            lblTotalFileScanned.AutoSize = true;
            lblTotalFileScanned.Dock = DockStyle.Fill;
            lblTotalFileScanned.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileScanned.Location = new Point(221, 38);
            lblTotalFileScanned.Name = "lblTotalFileScanned";
            lblTotalFileScanned.Size = new Size(82, 34);
            lblTotalFileScanned.TabIndex = 8;
            lblTotalFileScanned.Text = "00";
            // 
            // lblTotalFileQC
            // 
            lblTotalFileQC.AutoSize = true;
            lblTotalFileQC.Dock = DockStyle.Fill;
            lblTotalFileQC.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileQC.Location = new Point(221, 74);
            lblTotalFileQC.Name = "lblTotalFileQC";
            lblTotalFileQC.Size = new Size(82, 34);
            lblTotalFileQC.TabIndex = 9;
            lblTotalFileQC.Text = "00";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Dock = DockStyle.Fill;
            linkLabel5.Location = new Point(5, 146);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(208, 34);
            linkLabel5.TabIndex = 4;
            linkLabel5.TabStop = true;
            linkLabel5.Tag = "Total File Dispatched";
            linkLabel5.Text = "Current Files Dispatched Status";
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Dock = DockStyle.Fill;
            linkLabel6.Location = new Point(5, 110);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(208, 34);
            linkLabel6.TabIndex = 5;
            linkLabel6.TabStop = true;
            linkLabel6.Tag = "Total File QC By Client";
            linkLabel6.Text = "Current Files QC By Client Status";
            // 
            // lblTotalFileDispatched
            // 
            lblTotalFileDispatched.AutoSize = true;
            lblTotalFileDispatched.Dock = DockStyle.Fill;
            lblTotalFileDispatched.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileDispatched.Location = new Point(221, 146);
            lblTotalFileDispatched.Name = "lblTotalFileDispatched";
            lblTotalFileDispatched.Size = new Size(82, 34);
            lblTotalFileDispatched.TabIndex = 11;
            lblTotalFileDispatched.Text = "00";
            // 
            // lblTotalFileQCByCLient
            // 
            lblTotalFileQCByCLient.AutoSize = true;
            lblTotalFileQCByCLient.Dock = DockStyle.Fill;
            lblTotalFileQCByCLient.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileQCByCLient.Location = new Point(221, 110);
            lblTotalFileQCByCLient.Name = "lblTotalFileQCByCLient";
            lblTotalFileQCByCLient.Size = new Size(82, 34);
            lblTotalFileQCByCLient.TabIndex = 12;
            lblTotalFileQCByCLient.Text = "00";
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.Location = new Point(221, 221);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(82, 29);
            btnRefresh.TabIndex = 13;
            btnRefresh.Tag = "Refresh";
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // pieChart1
            // 
            pieChart1.Dock = DockStyle.Fill;
            pieChart1.Location = new Point(5, 5);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(671, 629);
            pieChart1.TabIndex = 0;
            pieChart1.Text = "pieChart1";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.White;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, seprator1, toolStripStatusLabel2, lblUserName });
            statusStrip1.Location = new Point(0, 669);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1003, 30);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(854, 24);
            toolStripStatusLabel1.Spring = true;
            // 
            // seprator1
            // 
            seprator1.ForeColor = SystemColors.ControlDarkDark;
            seprator1.Name = "seprator1";
            seprator1.Size = new Size(13, 24);
            seprator1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(85, 24);
            toolStripStatusLabel2.Tag = "User Name:";
            toolStripStatusLabel2.Text = "User Name:";
            // 
            // lblUserName
            // 
            lblUserName.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblUserName.BorderStyle = Border3DStyle.SunkenInner;
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(34, 24);
            lblUserName.Text = "xxx";
            // 
            // btnExist
            // 
            btnExist.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExist.BackColor = Color.IndianRed;
            btnExist.FlatStyle = FlatStyle.Popup;
            btnExist.ForeColor = Color.White;
            btnExist.Location = new Point(576, 593);
            btnExist.Margin = new Padding(3, 5, 3, 5);
            btnExist.Name = "btnExist";
            btnExist.Size = new Size(97, 36);
            btnExist.TabIndex = 3;
            btnExist.Tag = "Exit";
            btnExist.Text = "Exit";
            btnExist.UseVisualStyleBackColor = false;
            btnExist.Click += btnExist_Click;
            // 
            // frmAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1003, 699);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmAdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            WindowState = FormWindowState.Maximized;
            Load += frmAdminDashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            spcAside.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcAside).EndInit();
            spcAside.ResumeLayout(false);
            tlpCounts.ResumeLayout(false);
            tlpCounts.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage pageHome;
        private TabPage pageUser;
        private Button button3;
        private Button button2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menMaster;
        private ToolStripMenuItem userRegistrationToolStripMenuItem;
        private ToolStripMenuItem userManagementToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem menReport;
        private ToolStripMenuItem menAbout;
        private ToolStripMenuItem menLogout;
        private ToolStripMenuItem menSearchBarcode;
        private ToolStripMenuItem menChangeFileStatus;
        private ToolStripMenuItem dispatchToolStripMenuItem;
        private ToolStripMenuItem menOtherDipatch;
        private ToolStripMenuItem menBatchDispatch;
        private ToolStripMenuItem menDayReport;
        private ToolStripMenuItem menMetadataReport;
        private ToolStripMenuItem menMISReport;
        private ToolStripMenuItem backupRestoreToolStripMenuItem;
        private ToolStripMenuItem exportDataToolStripMenuItem;
        private ToolStripMenuItem importDataToolStripMenuItem;
        private ToolStripMenuItem menDBBackup;
        private ToolStripMenuItem imageCountToolStripMenuItem;
        private ToolStripMenuItem uploadDataToolStripMenuItem;
        private ToolStripMenuItem changeLanguageToolStripMenuItem;
        private ToolStripMenuItem menSync;
        private SplitContainer splitContainer1;
        private SplitContainer spcAside;
        private TableLayoutPanel tlpCounts;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private Label lblTotalFileReceived;
        private Label lblTotalFileScanned;
        private Label lblTotalFileQC;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel6;
        private Label lblTotalFileDispatched;
        private Label lblTotalFileQCByCLient;
        private Button btnRefresh;
        private LiveCharts.WinForms.PieChart pieChart1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel seprator1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblUserName;
        private Button btnExist;
    }
}