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
            lblErrorMessage.Location = new Point(4, 364);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(605, 33);
            lblErrorMessage.TabIndex = 2;
            lblErrorMessage.Text = "Error:";
            lblErrorMessage.Visible = false;
            // 
            // cobBatch
            // 
            cobBatch.Dock = DockStyle.Fill;
            cobBatch.FormattingEnabled = true;
            cobBatch.Location = new Point(104, 13);
            cobBatch.Name = "cobBatch";
            cobBatch.Size = new Size(406, 23);
            cobBatch.TabIndex = 1;
            cobBatch.SelectedIndexChanged += cobBatch_SelectedIndexChanged;
            // 
            // lblBatch
            // 
            lblBatch.AutoSize = true;
            lblBatch.Location = new Point(4, 10);
            lblBatch.Name = "lblBatch";
            lblBatch.Size = new Size(37, 15);
            lblBatch.TabIndex = 0;
            lblBatch.Text = "Batch";
            // 
            // btnProcess
            // 
            btnProcess.BackColor = Color.RoyalBlue;
            btnProcess.Cursor = Cursors.Hand;
            btnProcess.FlatStyle = FlatStyle.Popup;
            btnProcess.ForeColor = Color.White;
            btnProcess.Location = new Point(397, 3);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(104, 23);
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
            btnClose.Location = new Point(507, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(101, 23);
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
            statusStrip.Location = new Point(0, 437);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 12, 0);
            statusStrip.Size = new Size(613, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            tssStatus.Name = "tssStatus";
            tssStatus.Size = new Size(39, 17);
            tssStatus.Text = "Status";
            // 
            // tsProgressBar
            // 
            tsProgressBar.Name = "tsProgressBar";
            tsProgressBar.Size = new Size(175, 16);
            // 
            // lblPercentage
            // 
            lblPercentage.Name = "lblPercentage";
            lblPercentage.Size = new Size(29, 17);
            lblPercentage.Text = "00%";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(129, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblTimeTakenLable
            // 
            lblTimeTakenLable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeTakenLable.Name = "lblTimeTakenLable";
            lblTimeTakenLable.Size = new Size(74, 17);
            lblTimeTakenLable.Text = "Time Taken:";
            // 
            // lblTimeTaken
            // 
            lblTimeTaken.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeTaken.Name = "lblTimeTaken";
            lblTimeTaken.Size = new Size(38, 17);
            lblTimeTaken.Text = "00:00";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(10, 17);
            toolStripStatusLabel3.Text = "|";
            // 
            // tssCurrentUser
            // 
            tssCurrentUser.Name = "tssCurrentUser";
            tssCurrentUser.Size = new Size(76, 17);
            tssCurrentUser.Text = "Current User:";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(28, 17);
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
            tlpBatchSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            tlpBatchSelection.Controls.Add(lstFiles, 1, 1);
            tlpBatchSelection.Controls.Add(lblErrorMessage, 0, 2);
            tlpBatchSelection.Controls.Add(label1, 0, 1);
            tlpBatchSelection.Controls.Add(cobBatch, 1, 0);
            tlpBatchSelection.Controls.Add(lblBatch, 0, 0);
            tlpBatchSelection.Controls.Add(chkAll, 2, 0);
            tlpBatchSelection.Controls.Add(flowLayoutPanel1, 0, 3);
            tlpBatchSelection.Dock = DockStyle.Fill;
            tlpBatchSelection.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpBatchSelection.Location = new Point(0, 0);
            tlpBatchSelection.Name = "tlpBatchSelection";
            tlpBatchSelection.Padding = new Padding(1, 10, 1, 2);
            tlpBatchSelection.RowCount = 4;
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 6.923077F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 84.42308F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 8.695652F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBatchSelection.Size = new Size(613, 437);
            tlpBatchSelection.TabIndex = 11;
            // 
            // lstFiles
            // 
            lstFiles.CheckOnClick = true;
            lstFiles.Dock = DockStyle.Fill;
            lstFiles.FormattingEnabled = true;
            lstFiles.Location = new Point(104, 39);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(406, 322);
            lstFiles.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(4, 36);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 16;
            label1.Text = "File";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Dock = DockStyle.Fill;
            chkAll.Enabled = false;
            chkAll.Location = new Point(516, 13);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(93, 20);
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
            flowLayoutPanel1.Location = new Point(1, 397);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(611, 38);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // frmDispatch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(613, 459);
            Controls.Add(tlpBatchSelection);
            Controls.Add(statusStrip);
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
    }
}