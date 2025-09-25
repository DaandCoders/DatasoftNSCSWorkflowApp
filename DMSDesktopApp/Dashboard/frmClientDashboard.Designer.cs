namespace DMS.DesktopApp.Dashboard
{
    partial class frmClientDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientDashboard));
            btnExist = new Button();
            menuStrip1 = new MenuStrip();
            menQC = new ToolStripMenuItem();
            menReports = new ToolStripMenuItem();
            menAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            seprator1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            lblUserName = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            spcAside = new SplitContainer();
            tlpCounts = new TableLayoutPanel();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            lblTotalFileReceived = new Label();
            lblTotalFileScanned = new Label();
            lblTotalFileQC = new Label();
            lblTotalFileClassified = new Label();
            btnRefresh = new Button();
            linkLabel5 = new LinkLabel();
            linkLabel6 = new LinkLabel();
            lblTotalFileDispatched = new Label();
            lblTotalFileQCByCLient = new Label();
            pieChart1 = new LiveCharts.WinForms.PieChart();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcAside).BeginInit();
            spcAside.Panel1.SuspendLayout();
            spcAside.SuspendLayout();
            tlpCounts.SuspendLayout();
            SuspendLayout();
            // 
            // btnExist
            // 
            btnExist.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExist.BackColor = Color.IndianRed;
            btnExist.FlatStyle = FlatStyle.Popup;
            btnExist.ForeColor = Color.White;
            btnExist.Location = new Point(696, 498);
            btnExist.Margin = new Padding(3, 5, 3, 5);
            btnExist.Name = "btnExist";
            btnExist.Size = new Size(97, 36);
            btnExist.TabIndex = 2;
            btnExist.Text = "Exit";
            btnExist.UseVisualStyleBackColor = false;
            btnExist.Click += btnExist_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menQC, menReports, menAbout });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1070, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menQC
            // 
            menQC.Name = "menQC";
            menQC.Size = new Size(43, 24);
            menQC.Text = "QC";
            menQC.Click += menQC_Click;
            // 
            // menReports
            // 
            menReports.Enabled = false;
            menReports.Name = "menReports";
            menReports.Size = new Size(74, 24);
            menReports.Text = "Reports";
            // 
            // menAbout
            // 
            menAbout.Name = "menAbout";
            menAbout.Size = new Size(64, 24);
            menAbout.Text = "About";
            menAbout.Click += menAbout_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, seprator1, toolStripStatusLabel2, lblUserName });
            statusStrip1.Location = new Point(0, 584);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1070, 30);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(921, 24);
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 28);
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
            splitContainer1.Panel2.Controls.Add(pieChart1);
            splitContainer1.Panel2.Controls.Add(btnExist);
            splitContainer1.Panel2.Padding = new Padding(5);
            splitContainer1.Size = new Size(1070, 556);
            splitContainer1.SplitterDistance = 255;
            splitContainer1.TabIndex = 3;
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
            spcAside.Size = new Size(245, 546);
            spcAside.SplitterDistance = 255;
            spcAside.TabIndex = 1;
            // 
            // tlpCounts
            // 
            tlpCounts.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tlpCounts.ColumnCount = 2;
            tlpCounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.28839F));
            tlpCounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.71161F));
            tlpCounts.Controls.Add(linkLabel1, 0, 0);
            tlpCounts.Controls.Add(linkLabel2, 0, 1);
            tlpCounts.Controls.Add(linkLabel3, 0, 2);
            tlpCounts.Controls.Add(linkLabel4, 0, 3);
            tlpCounts.Controls.Add(lblTotalFileReceived, 1, 0);
            tlpCounts.Controls.Add(lblTotalFileScanned, 1, 1);
            tlpCounts.Controls.Add(lblTotalFileQC, 1, 2);
            tlpCounts.Controls.Add(lblTotalFileClassified, 1, 3);
            tlpCounts.Controls.Add(btnRefresh, 0, 6);
            tlpCounts.Controls.Add(linkLabel5, 0, 5);
            tlpCounts.Controls.Add(linkLabel6, 0, 4);
            tlpCounts.Controls.Add(lblTotalFileDispatched, 1, 5);
            tlpCounts.Controls.Add(lblTotalFileQCByCLient, 1, 4);
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
            tlpCounts.Size = new Size(245, 255);
            tlpCounts.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Dock = DockStyle.Fill;
            linkLabel1.Location = new Point(5, 2);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(159, 34);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Total File Received";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Dock = DockStyle.Fill;
            linkLabel2.Location = new Point(5, 38);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(159, 34);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Total File Scanned";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Dock = DockStyle.Fill;
            linkLabel3.Location = new Point(5, 74);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(159, 34);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Total File QC";
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Dock = DockStyle.Fill;
            linkLabel4.Location = new Point(5, 110);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(159, 34);
            linkLabel4.TabIndex = 3;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Total File Classified";
            // 
            // lblTotalFileReceived
            // 
            lblTotalFileReceived.AutoSize = true;
            lblTotalFileReceived.Dock = DockStyle.Fill;
            lblTotalFileReceived.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileReceived.Location = new Point(172, 2);
            lblTotalFileReceived.Name = "lblTotalFileReceived";
            lblTotalFileReceived.Size = new Size(68, 34);
            lblTotalFileReceived.TabIndex = 7;
            lblTotalFileReceived.Text = "00";
            // 
            // lblTotalFileScanned
            // 
            lblTotalFileScanned.AutoSize = true;
            lblTotalFileScanned.Dock = DockStyle.Fill;
            lblTotalFileScanned.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileScanned.Location = new Point(172, 38);
            lblTotalFileScanned.Name = "lblTotalFileScanned";
            lblTotalFileScanned.Size = new Size(68, 34);
            lblTotalFileScanned.TabIndex = 8;
            lblTotalFileScanned.Text = "00";
            // 
            // lblTotalFileQC
            // 
            lblTotalFileQC.AutoSize = true;
            lblTotalFileQC.Dock = DockStyle.Fill;
            lblTotalFileQC.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileQC.Location = new Point(172, 74);
            lblTotalFileQC.Name = "lblTotalFileQC";
            lblTotalFileQC.Size = new Size(68, 34);
            lblTotalFileQC.TabIndex = 9;
            lblTotalFileQC.Text = "00";
            // 
            // lblTotalFileClassified
            // 
            lblTotalFileClassified.AutoSize = true;
            lblTotalFileClassified.Dock = DockStyle.Fill;
            lblTotalFileClassified.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileClassified.Location = new Point(172, 110);
            lblTotalFileClassified.Name = "lblTotalFileClassified";
            lblTotalFileClassified.Size = new Size(68, 34);
            lblTotalFileClassified.TabIndex = 10;
            lblTotalFileClassified.Text = "00";
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.Location = new Point(5, 221);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(159, 29);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Dock = DockStyle.Fill;
            linkLabel5.Location = new Point(5, 182);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(159, 34);
            linkLabel5.TabIndex = 4;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Total File Dispatched";
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Dock = DockStyle.Fill;
            linkLabel6.Location = new Point(5, 146);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(159, 34);
            linkLabel6.TabIndex = 5;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "Total File QC By Client";
            // 
            // lblTotalFileDispatched
            // 
            lblTotalFileDispatched.AutoSize = true;
            lblTotalFileDispatched.Dock = DockStyle.Fill;
            lblTotalFileDispatched.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileDispatched.Location = new Point(172, 182);
            lblTotalFileDispatched.Name = "lblTotalFileDispatched";
            lblTotalFileDispatched.Size = new Size(68, 34);
            lblTotalFileDispatched.TabIndex = 11;
            lblTotalFileDispatched.Text = "00";
            // 
            // lblTotalFileQCByCLient
            // 
            lblTotalFileQCByCLient.AutoSize = true;
            lblTotalFileQCByCLient.Dock = DockStyle.Fill;
            lblTotalFileQCByCLient.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileQCByCLient.Location = new Point(172, 146);
            lblTotalFileQCByCLient.Name = "lblTotalFileQCByCLient";
            lblTotalFileQCByCLient.Size = new Size(68, 34);
            lblTotalFileQCByCLient.TabIndex = 12;
            lblTotalFileQCByCLient.Text = "00";
            // 
            // pieChart1
            // 
            pieChart1.Dock = DockStyle.Fill;
            pieChart1.Location = new Point(5, 5);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(801, 546);
            pieChart1.TabIndex = 3;
            pieChart1.Text = "pieChart1";
            pieChart1.Visible = false;
            // 
            // frmDeptDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1070, 614);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10.2F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 5, 3, 5);
            Name = "frmDeptDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmDashboard_FormClosing;
            Load += frmDashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            spcAside.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcAside).EndInit();
            spcAside.ResumeLayout(false);
            tlpCounts.ResumeLayout(false);
            tlpCounts.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnExist;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menQC;
        private ToolStripMenuItem menReports;
        private ToolStripMenuItem menAbout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel seprator1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblUserName;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tlpCounts;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel6;
        private Label lblTotalFileReceived;
        private Label lblTotalFileScanned;
        private Label lblTotalFileQC;
        private Label lblTotalFileClassified;
        private Label lblTotalFileDispatched;
        private Label lblTotalFileQCByCLient;
        private SplitContainer spcAside;
        private LiveCharts.WinForms.PieChart pieChart1;
        private Button btnRefresh;
    }
}