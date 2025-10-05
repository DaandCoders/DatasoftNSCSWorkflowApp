namespace DMS.DesktopApp.Dashboard
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            btnExist = new Button();
            menuStrip1 = new MenuStrip();
            menFileRecevie = new ToolStripMenuItem();
            menScan = new ToolStripMenuItem();
            menQC = new ToolStripMenuItem();
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
            lblTotalFileReceived = new Label();
            lblTotalFileScanned = new Label();
            lblTotalFileQC = new Label();
            linkLabel5 = new LinkLabel();
            linkLabel6 = new LinkLabel();
            lblTotalFileDispatched = new Label();
            lblTotalFileQCByCLient = new Label();
            btnRefresh = new Button();
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
            btnExist.Location = new Point(617, 522);
            btnExist.Margin = new Padding(3, 5, 3, 5);
            btnExist.Name = "btnExist";
            btnExist.Size = new Size(97, 36);
            btnExist.TabIndex = 2;
            btnExist.Tag = "Exit";
            btnExist.Text = "Exit";
            btnExist.UseVisualStyleBackColor = false;
            btnExist.Click += btnExist_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menFileRecevie, menScan, menQC, menAbout });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1070, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menFileRecevie
            // 
            menFileRecevie.Name = "menFileRecevie";
            menFileRecevie.Size = new Size(67, 20);
            menFileRecevie.Tag = "File Receive";
            menFileRecevie.Text = "File Receive";
            menFileRecevie.Click += menFileRecevie_Click;
            // 
            // menScan
            // 
            menScan.Name = "menScan";
            menScan.Size = new Size(38, 20);
            menScan.Tag = "Scan";
            menScan.Text = "Scan";
            menScan.Click += menScan_Click;
            // 
            // menQC
            // 
            menQC.Name = "menQC";
            menQC.Size = new Size(31, 20);
            menQC.Tag = "QC";
            menQC.Text = "QC";
            menQC.Click += menQC_Click;
            // 
            // menAbout
            // 
            menAbout.Name = "menAbout";
            menAbout.Size = new Size(44, 20);
            menAbout.Tag = "About";
            menAbout.Text = "About";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, seprator1, toolStripStatusLabel2, lblUserName });
            statusStrip1.Location = new Point(0, 592);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1070, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(967, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // seprator1
            // 
            seprator1.ForeColor = SystemColors.ControlDarkDark;
            seprator1.Name = "seprator1";
            seprator1.Size = new Size(7, 17);
            seprator1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(55, 17);
            toolStripStatusLabel2.Tag = "User Name:";
            toolStripStatusLabel2.Text = "User Name:";
            // 
            // lblUserName
            // 
            lblUserName.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblUserName.BorderStyle = Border3DStyle.SunkenInner;
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(24, 17);
            lblUserName.Text = "xxx";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
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
            splitContainer1.Size = new Size(1070, 568);
            splitContainer1.SplitterDistance = 340;
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
            spcAside.Size = new Size(330, 558);
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
            tlpCounts.Size = new Size(330, 255);
            tlpCounts.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Dock = DockStyle.Fill;
            linkLabel1.Location = new Point(5, 2);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(224, 34);
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
            linkLabel2.Size = new Size(224, 34);
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
            linkLabel3.Size = new Size(224, 34);
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
            lblTotalFileReceived.Location = new Point(237, 2);
            lblTotalFileReceived.Name = "lblTotalFileReceived";
            lblTotalFileReceived.Size = new Size(88, 34);
            lblTotalFileReceived.TabIndex = 7;
            lblTotalFileReceived.Text = "00";
            // 
            // lblTotalFileScanned
            // 
            lblTotalFileScanned.AutoSize = true;
            lblTotalFileScanned.Dock = DockStyle.Fill;
            lblTotalFileScanned.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileScanned.Location = new Point(237, 38);
            lblTotalFileScanned.Name = "lblTotalFileScanned";
            lblTotalFileScanned.Size = new Size(88, 34);
            lblTotalFileScanned.TabIndex = 8;
            lblTotalFileScanned.Text = "00";
            // 
            // lblTotalFileQC
            // 
            lblTotalFileQC.AutoSize = true;
            lblTotalFileQC.Dock = DockStyle.Fill;
            lblTotalFileQC.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileQC.Location = new Point(237, 74);
            lblTotalFileQC.Name = "lblTotalFileQC";
            lblTotalFileQC.Size = new Size(88, 34);
            lblTotalFileQC.TabIndex = 9;
            lblTotalFileQC.Text = "00";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Dock = DockStyle.Fill;
            linkLabel5.Location = new Point(5, 146);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(224, 34);
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
            linkLabel6.Size = new Size(224, 34);
            linkLabel6.TabIndex = 5;
            linkLabel6.TabStop = true;
            linkLabel6.Tag = "Total File QC By Client";
            linkLabel6.Text = "Current Files QC By Client Status";
            linkLabel6.Visible = false;
            // 
            // lblTotalFileDispatched
            // 
            lblTotalFileDispatched.AutoSize = true;
            lblTotalFileDispatched.Dock = DockStyle.Fill;
            lblTotalFileDispatched.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileDispatched.Location = new Point(237, 146);
            lblTotalFileDispatched.Name = "lblTotalFileDispatched";
            lblTotalFileDispatched.Size = new Size(88, 34);
            lblTotalFileDispatched.TabIndex = 11;
            lblTotalFileDispatched.Text = "00";
            // 
            // lblTotalFileQCByCLient
            // 
            lblTotalFileQCByCLient.AutoSize = true;
            lblTotalFileQCByCLient.Dock = DockStyle.Fill;
            lblTotalFileQCByCLient.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            lblTotalFileQCByCLient.Location = new Point(237, 110);
            lblTotalFileQCByCLient.Name = "lblTotalFileQCByCLient";
            lblTotalFileQCByCLient.Size = new Size(88, 34);
            lblTotalFileQCByCLient.TabIndex = 12;
            lblTotalFileQCByCLient.Text = "00";
            lblTotalFileQCByCLient.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.Location = new Point(237, 221);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 29);
            btnRefresh.TabIndex = 13;
            btnRefresh.Tag = "Refresh";
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pieChart1
            // 
            pieChart1.Dock = DockStyle.Fill;
            pieChart1.Location = new Point(5, 5);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(716, 558);
            pieChart1.TabIndex = 0;
            pieChart1.Text = "pieChart1";
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1070, 614);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10.2F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 5, 3, 5);
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmDashboard_FormClosing;
            Load += frmDashboard_LoadAsync;
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
        private ToolStripMenuItem menFileRecevie;
        private ToolStripMenuItem menScan;
        private ToolStripMenuItem menQC;
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
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel6;
        private Label lblTotalFileReceived;
        private Label lblTotalFileScanned;
        private Label lblTotalFileQC;
        private Label lblTotalFileDispatched;
        private Label lblTotalFileQCByCLient;
        private SplitContainer spcAside;
        private Button btnRefresh;
       private LiveCharts.WinForms.PieChart pieChart1;
    }
}