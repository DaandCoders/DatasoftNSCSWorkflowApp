namespace DMS.DesktopApp.Dispatch
{
    partial class frmDispatch
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
            lblErrorMessage = new Label();
            cobBatch = new ComboBox();
            lblBatch = new Label();
            btnProcess = new Button();
            btnClose = new Button();
            statusStrip = new StatusStrip();
            tssStatus = new ToolStripStatusLabel();
            tsProgressBar = new ToolStripProgressBar();
            lblPercentage = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblTimeTakenLable = new ToolStripStatusLabel();
            lblTimeTaken = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            tssCurrentUser = new ToolStripStatusLabel();
            lblCurrentUser = new ToolStripStatusLabel();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            tlpBatchSelection = new TableLayoutPanel();
            lstFiles = new CheckedListBox();
            label1 = new Label();
            chkAll = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            statusStrip.SuspendLayout();
            tlpBatchSelection.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            tlpBatchSelection.SetColumnSpan(lblErrorMessage, 3);
            lblErrorMessage.Dock = DockStyle.Fill;
            lblErrorMessage.ForeColor = Color.IndianRed;
            lblErrorMessage.Location = new Point(5, 410);
            lblErrorMessage.Margin = new Padding(4, 0, 4, 0);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(602, 33);
            lblErrorMessage.TabIndex = 2;
            lblErrorMessage.Text = "Error:";
            lblErrorMessage.Visible = false;
            // 
            // cobBatch
            // 
            cobBatch.Dock = DockStyle.Fill;
            cobBatch.FormattingEnabled = true;
            cobBatch.Location = new Point(104, 14);
            cobBatch.Margin = new Padding(4, 3, 4, 3);
            cobBatch.Name = "cobBatch";
            cobBatch.Size = new Size(402, 29);
            cobBatch.TabIndex = 1;
            cobBatch.SelectedIndexChanged += cobBatch_SelectedIndexChanged;
            // 
            // lblBatch
            // 
            lblBatch.AutoSize = true;
            lblBatch.Dock = DockStyle.Fill;
            lblBatch.Location = new Point(5, 11);
            lblBatch.Margin = new Padding(4, 0, 4, 0);
            lblBatch.Name = "lblBatch";
            lblBatch.Size = new Size(91, 36);
            lblBatch.TabIndex = 0;
            lblBatch.Text = "Batch";
            // 
            // btnProcess
            // 
            btnProcess.BackColor = Color.RoyalBlue;
            btnProcess.Cursor = Cursors.Hand;
            btnProcess.FlatStyle = FlatStyle.Popup;
            btnProcess.ForeColor = Color.White;
            btnProcess.Location = new Point(392, 3);
            btnProcess.Margin = new Padding(4, 3, 4, 3);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(104, 40);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = false;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(504, 3);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.Transparent;
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tssStatus, tsProgressBar, lblPercentage, toolStripStatusLabel1, lblTimeTakenLable, lblTimeTaken, toolStripStatusLabel3, tssCurrentUser, lblCurrentUser });
            statusStrip.Location = new Point(0, 489);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 12, 0);
            statusStrip.Size = new Size(612, 31);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            tssStatus.Name = "tssStatus";
            tssStatus.Size = new Size(49, 25);
            tssStatus.Text = "Status";
            // 
            // tsProgressBar
            // 
            tsProgressBar.Name = "tsProgressBar";
            tsProgressBar.Size = new Size(175, 23);
            // 
            // lblPercentage
            // 
            lblPercentage.Name = "lblPercentage";
            lblPercentage.Size = new Size(37, 25);
            lblPercentage.Text = "00%";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(52, 25);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblTimeTakenLable
            // 
            lblTimeTakenLable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeTakenLable.Name = "lblTimeTakenLable";
            lblTimeTakenLable.Size = new Size(93, 25);
            lblTimeTakenLable.Text = "Time Taken:";
            // 
            // lblTimeTaken
            // 
            lblTimeTaken.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeTaken.Name = "lblTimeTaken";
            lblTimeTaken.Size = new Size(49, 25);
            lblTimeTaken.Text = "00:00";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(13, 25);
            toolStripStatusLabel3.Text = "|";
            // 
            // tssCurrentUser
            // 
            tssCurrentUser.Name = "tssCurrentUser";
            tssCurrentUser.Size = new Size(93, 25);
            tssCurrentUser.Text = "Current User:";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(36, 25);
            lblCurrentUser.Text = "XXX";
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // tlpBatchSelection
            // 
            tlpBatchSelection.BackColor = Color.White;
            tlpBatchSelection.ColumnCount = 3;
            tlpBatchSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.49541F));
            tlpBatchSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.5045853F));
            tlpBatchSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpBatchSelection.Controls.Add(lstFiles, 1, 2);
            tlpBatchSelection.Controls.Add(lblErrorMessage, 0, 3);
            tlpBatchSelection.Controls.Add(label1, 0, 2);
            tlpBatchSelection.Controls.Add(cobBatch, 1, 0);
            tlpBatchSelection.Controls.Add(lblBatch, 0, 0);
            tlpBatchSelection.Controls.Add(chkAll, 2, 0);
            tlpBatchSelection.Controls.Add(flowLayoutPanel1, 0, 4);
            tlpBatchSelection.Controls.Add(lblSearch, 0, 1);
            tlpBatchSelection.Controls.Add(txtSearch, 1, 1);
            tlpBatchSelection.Controls.Add(btnSearch, 2, 1);
            tlpBatchSelection.Dock = DockStyle.Fill;
            tlpBatchSelection.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpBatchSelection.Location = new Point(0, 0);
            tlpBatchSelection.Margin = new Padding(4, 3, 4, 3);
            tlpBatchSelection.Name = "tlpBatchSelection";
            tlpBatchSelection.Padding = new Padding(1, 11, 1, 3);
            tlpBatchSelection.RowCount = 5;
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 9.219858F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 9.574468F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 81.20567F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tlpBatchSelection.Size = new Size(612, 489);
            tlpBatchSelection.TabIndex = 11;
            // 
            // lstFiles
            // 
            lstFiles.CheckOnClick = true;
            lstFiles.Dock = DockStyle.Fill;
            lstFiles.FormattingEnabled = true;
            lstFiles.Location = new Point(104, 88);
            lstFiles.Margin = new Padding(4, 3, 4, 3);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(402, 319);
            lstFiles.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(5, 85);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 16;
            label1.Text = "File";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Dock = DockStyle.Fill;
            chkAll.Enabled = false;
            chkAll.Location = new Point(514, 14);
            chkAll.Margin = new Padding(4, 3, 4, 3);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(93, 30);
            chkAll.TabIndex = 20;
            chkAll.Text = "Select All";
            chkAll.UseVisualStyleBackColor = true;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            tlpBatchSelection.SetColumnSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Controls.Add(btnProcess);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(1, 443);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(610, 43);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Dock = DockStyle.Fill;
            lblSearch.Location = new Point(5, 47);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(91, 38);
            lblSearch.TabIndex = 21;
            lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(104, 51);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(402, 29);
            txtSearch.TabIndex = 22;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SeaGreen;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(513, 50);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(95, 32);
            btnSearch.TabIndex = 23;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmDispatch
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(612, 520);
            Controls.Add(tlpBatchSelection);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDispatch";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Batch Dispatch";
            Load += frmDispatch_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tlpBatchSelection.ResumeLayout(false);
            tlpBatchSelection.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cobBatch;
        private Label lblBatch;
        private Button btnProcess;
        private Button btnClose;
        private Label lblErrorMessage;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tssStatus;
        private ToolStripProgressBar tsProgressBar;
        private ToolStripStatusLabel lblPercentage;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tssCurrentUser;
        private ToolStripStatusLabel lblCurrentUser;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ComboBox comboBox1;
        private ToolStripStatusLabel lblTimeTakenLable;
        private ToolStripStatusLabel lblTimeTaken;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private TableLayoutPanel tlpBatchSelection;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckedListBox lstFiles;
        private Label label1;
        private CheckBox chkAll;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}