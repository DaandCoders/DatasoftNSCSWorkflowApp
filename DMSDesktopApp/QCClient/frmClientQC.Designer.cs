namespace DMS.DesktopApp.QCClient
{
    partial class frmClientQC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientQC));
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClose = new Button();
            btnReject = new Button();
            btnBatchComplete = new Button();
            btnQCDone = new Button();
            pdfViwer = new AxAcroPDFLib.AxAcroPDF();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblDepartmentName = new Label();
            label3 = new Label();
            panRejectDetails = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            txtRemark = new TextBox();
            cobReject = new ComboBox();
            cobBatch = new ComboBox();
            panDepartmentDetails = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblLocation = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            lblCurrentUser = new ToolStripStatusLabel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pdfViwer).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panRejectDetails.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(pdfViwer, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.14286F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.857143F));
            tableLayoutPanel1.Size = new Size(1064, 696);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 2);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Controls.Add(btnReject);
            flowLayoutPanel1.Controls.Add(btnBatchComplete);
            flowLayoutPanel1.Controls.Add(btnQCDone);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 651);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1058, 42);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(898, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(157, 39);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.Coral;
            btnReject.Cursor = Cursors.Hand;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(735, 3);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(157, 39);
            btnReject.TabIndex = 2;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnBatchComplete
            // 
            btnBatchComplete.BackColor = Color.SeaGreen;
            btnBatchComplete.Cursor = Cursors.Hand;
            btnBatchComplete.FlatStyle = FlatStyle.Flat;
            btnBatchComplete.ForeColor = Color.White;
            btnBatchComplete.Location = new Point(572, 3);
            btnBatchComplete.Name = "btnBatchComplete";
            btnBatchComplete.Size = new Size(157, 39);
            btnBatchComplete.TabIndex = 1;
            btnBatchComplete.Text = "Batch Done";
            btnBatchComplete.UseVisualStyleBackColor = false;
            btnBatchComplete.Click += btnBatchComplete_Click;
            // 
            // btnQCDone
            // 
            btnQCDone.BackColor = Color.MediumSeaGreen;
            btnQCDone.Cursor = Cursors.Hand;
            btnQCDone.FlatStyle = FlatStyle.Flat;
            btnQCDone.ForeColor = Color.White;
            btnQCDone.Location = new Point(409, 3);
            btnQCDone.Name = "btnQCDone";
            btnQCDone.Size = new Size(157, 39);
            btnQCDone.TabIndex = 0;
            btnQCDone.Text = "Done";
            btnQCDone.UseVisualStyleBackColor = false;
            btnQCDone.Click += btnQCDone_Click;
            // 
            // pdfViwer
            // 
            pdfViwer.Dock = DockStyle.Fill;
            pdfViwer.Enabled = true;
            pdfViwer.Location = new Point(428, 3);
            pdfViwer.Name = "pdfViwer";
            pdfViwer.OcxState = (AxHost.State)resources.GetObject("pdfViwer.OcxState");
            pdfViwer.Size = new Size(633, 642);
            pdfViwer.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.25298F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.74702F));
            tableLayoutPanel2.Controls.Add(lblDepartmentName, 0, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 1);
            tableLayoutPanel2.Controls.Add(panRejectDetails, 0, 3);
            tableLayoutPanel2.Controls.Add(cobBatch, 1, 1);
            tableLayoutPanel2.Controls.Add(panDepartmentDetails, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6838484F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 7.81893F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80.65844F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 159F));
            tableLayoutPanel2.Size = new Size(419, 642);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // lblDepartmentName
            // 
            lblDepartmentName.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(lblDepartmentName, 2);
            lblDepartmentName.Dock = DockStyle.Fill;
            lblDepartmentName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartmentName.Location = new Point(3, 0);
            lblDepartmentName.Name = "lblDepartmentName";
            lblDepartmentName.Size = new Size(413, 56);
            lblDepartmentName.TabIndex = 0;
            lblDepartmentName.Text = "Department Name";
            lblDepartmentName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 56);
            label3.Name = "label3";
            label3.Size = new Size(103, 37);
            label3.TabIndex = 3;
            label3.Text = "Batch";
            // 
            // panRejectDetails
            // 
            panRejectDetails.BackColor = Color.White;
            tableLayoutPanel2.SetColumnSpan(panRejectDetails, 2);
            panRejectDetails.Controls.Add(tableLayoutPanel3);
            panRejectDetails.Dock = DockStyle.Fill;
            panRejectDetails.Location = new Point(3, 484);
            panRejectDetails.Name = "panRejectDetails";
            panRejectDetails.Size = new Size(413, 155);
            panRejectDetails.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1815987F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.8184052F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(txtRemark, 1, 1);
            tableLayoutPanel3.Controls.Add(cobReject, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 26.630434F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 73.36957F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(413, 155);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 41);
            label1.TabIndex = 0;
            label1.Text = "Reject";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 41);
            label2.Name = "label2";
            label2.Size = new Size(98, 114);
            label2.TabIndex = 1;
            label2.Text = "Remark";
            // 
            // txtRemark
            // 
            txtRemark.Dock = DockStyle.Fill;
            txtRemark.Location = new Point(107, 44);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(303, 108);
            txtRemark.TabIndex = 2;
            // 
            // cobReject
            // 
            cobReject.Dock = DockStyle.Fill;
            cobReject.FormattingEnabled = true;
            cobReject.Location = new Point(107, 3);
            cobReject.Name = "cobReject";
            cobReject.Size = new Size(303, 28);
            cobReject.TabIndex = 3;
            cobReject.SelectedIndexChanged += cobReject_SelectedIndexChanged;
            // 
            // cobBatch
            // 
            cobBatch.Dock = DockStyle.Fill;
            cobBatch.FormattingEnabled = true;
            cobBatch.Location = new Point(112, 59);
            cobBatch.Name = "cobBatch";
            cobBatch.Size = new Size(304, 28);
            cobBatch.TabIndex = 4;
            cobBatch.SelectedIndexChanged += cobBatch_SelectedIndexChanged;
            // 
            // panDepartmentDetails
            // 
            tableLayoutPanel2.SetColumnSpan(panDepartmentDetails, 2);
            panDepartmentDetails.Dock = DockStyle.Fill;
            panDepartmentDetails.Location = new Point(3, 96);
            panDepartmentDetails.Name = "panDepartmentDetails";
            panDepartmentDetails.Size = new Size(413, 382);
            panDepartmentDetails.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblLocation, toolStripStatusLabel2, toolStripStatusLabel3, lblCurrentUser });
            statusStrip1.Location = new Point(0, 696);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1064, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(69, 20);
            toolStripStatusLabel1.Text = "Location:";
            // 
            // lblLocation
            // 
            lblLocation.DoubleClickEnabled = true;
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.DoubleClick += lblLocation_DoubleClick;
            lblLocation.TextChanged += lblLocation_TextChanged;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(909, 20);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(41, 20);
            toolStripStatusLabel3.Text = "User:";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(30, 20);
            lblCurrentUser.Text = "xxx";
            // 
            // frmClientQC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1064, 722);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            Name = "frmClientQC";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client QC";
            WindowState = FormWindowState.Maximized;
            Load += frmClientQC_Load;
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pdfViwer).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panRejectDetails.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Button btnQCDone;
        private StatusStrip statusStrip1;
        private AxAcroPDFLib.AxAcroPDF pdfViwer;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblDepartmentName;
        private Panel panDepartmentDetails;
        private Panel panRejectDetails;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Label label2;
        private TextBox txtRemark;
        private ComboBox cobReject;
        private Label label3;
        private ComboBox cobBatch;
        private Button btnBatchComplete;
        private Button btnReject;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblLocation;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel lblCurrentUser;
    }
}