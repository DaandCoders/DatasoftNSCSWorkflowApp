using System.ComponentModel;

namespace DMS.DesktopApp.Reports
{
    partial class frmClientReport
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            dtpDateFrom = new DateTimePicker();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radSingleDate = new RadioButton();
            radBetweenDate = new RadioButton();
            dtpDateTo = new DateTimePicker();
            lblDateTo = new Label();
            btnOK = new Button();
            dataGridView = new DataGridView();
            btnClose = new Button();
            btnExportReport = new Button();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            lblRecordCount = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblElapsed = new ToolStripStatusLabel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)dataGridView).BeginInit();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.1130686F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.4634151F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.439024F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.4878044F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5727081F));
            tableLayoutPanel1.Controls.Add(dtpDateFrom, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dtpDateTo, 3, 1);
            tableLayoutPanel1.Controls.Add(lblDateTo, 2, 1);
            tableLayoutPanel1.Controls.Add(btnOK, 4, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.9459457F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.0540543F));
            tableLayoutPanel1.Size = new Size(1093, 64);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Cursor = Cursors.Hand;
            dtpDateFrom.CustomFormat = "dd-MM-yyyy";
            dtpDateFrom.Dock = DockStyle.Fill;
            dtpDateFrom.Format = DateTimePickerFormat.Custom;
            dtpDateFrom.Location = new Point(136, 32);
            dtpDateFrom.Margin = new Padding(4, 3, 4, 3);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(281, 29);
            dtpDateFrom.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(4, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 35);
            label1.TabIndex = 15;
            label1.Tag = "Date From";
            label1.Text = "Date From";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 2);
            flowLayoutPanel1.Controls.Add(radSingleDate);
            flowLayoutPanel1.Controls.Add(radBetweenDate);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(421, 29);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // radSingleDate
            // 
            radSingleDate.AutoSize = true;
            radSingleDate.Checked = true;
            radSingleDate.Dock = DockStyle.Fill;
            radSingleDate.Location = new Point(4, 3);
            radSingleDate.Margin = new Padding(4, 3, 4, 3);
            radSingleDate.Name = "radSingleDate";
            radSingleDate.Size = new Size(77, 27);
            radSingleDate.TabIndex = 0;
            radSingleDate.TabStop = true;
            radSingleDate.Tag = "Single";
            radSingleDate.Text = "Single";
            radSingleDate.UseVisualStyleBackColor = true;
            radSingleDate.CheckedChanged += radSingleDate_CheckedChanged;
            // 
            // radBetweenDate
            // 
            radBetweenDate.AutoSize = true;
            radBetweenDate.Dock = DockStyle.Fill;
            radBetweenDate.Location = new Point(89, 3);
            radBetweenDate.Margin = new Padding(4, 3, 4, 3);
            radBetweenDate.Name = "radBetweenDate";
            radBetweenDate.Size = new Size(96, 27);
            radBetweenDate.TabIndex = 0;
            radBetweenDate.Tag = "Between";
            radBetweenDate.Text = "Between";
            radBetweenDate.UseVisualStyleBackColor = true;
            radBetweenDate.CheckedChanged += radBetweenDate_CheckedChanged;
            // 
            // dtpDateTo
            // 
            dtpDateTo.Cursor = Cursors.Hand;
            dtpDateTo.CustomFormat = "dd-MM-yyyy";
            dtpDateTo.Dock = DockStyle.Fill;
            dtpDateTo.Format = DateTimePickerFormat.Custom;
            dtpDateTo.Location = new Point(615, 32);
            dtpDateTo.Margin = new Padding(4, 3, 4, 3);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(270, 29);
            dtpDateTo.TabIndex = 16;
            // 
            // lblDateTo
            // 
            lblDateTo.AutoSize = true;
            lblDateTo.Dock = DockStyle.Fill;
            lblDateTo.Location = new Point(425, 29);
            lblDateTo.Margin = new Padding(4, 0, 4, 0);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(182, 35);
            lblDateTo.TabIndex = 17;
            lblDateTo.Tag = "Date To";
            lblDateTo.Text = "Date To";
            lblDateTo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.RoyalBlue;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Dock = DockStyle.Fill;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(889, 29);
            btnOK.Margin = new Padding(0);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(204, 35);
            btnOK.TabIndex = 19;
            btnOK.Tag = "OK";
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(4, 4);
            dataGridView.Margin = new Padding(4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1085, 428);
            dataGridView.TabIndex = 1;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(953, 0);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(132, 34);
            btnClose.TabIndex = 19;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnExportReport
            // 
            btnExportReport.BackColor = Color.SeaGreen;
            btnExportReport.FlatStyle = FlatStyle.Popup;
            btnExportReport.ForeColor = Color.White;
            btnExportReport.Location = new Point(817, 3);
            btnExportReport.Margin = new Padding(4, 3, 4, 3);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(132, 31);
            btnExportReport.TabIndex = 20;
            btnExportReport.Tag = "Export";
            btnExportReport.Text = "Export";
            btnExportReport.UseVisualStyleBackColor = false;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(9, 8);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new Size(1093, 549);
            splitContainer1.SplitterDistance = 64;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(dataGridView, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90.65256F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.347443F));
            tableLayoutPanel2.Size = new Size(1093, 482);
            tableLayoutPanel2.TabIndex = 0;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnClose);
            flowLayoutPanel2.Controls.Add(btnExportReport);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(4, 439);
            flowLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1085, 40);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblRecordCount, toolStripStatusLabel1, lblElapsed });
            statusStrip1.Location = new Point(9, 557);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(1093, 24);
            statusStrip1.TabIndex = 22;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(113, 18);
            lblRecordCount.Tag = "Total Records: 00";
            lblRecordCount.Text = "Total Records: 00";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(11, 18);
            toolStripStatusLabel1.Text = "|";
            // 
            // lblElapsed
            // 
            lblElapsed.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(0, 18);
            // 
            // frmClientReport
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1111, 589);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmClientReport";
            Padding = new Padding(9, 8, 9, 8);
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "Client Report";
            Text = "Client Report";
            Load += frmDaysReport_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((ISupportInitialize)dataGridView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radSingleDate;
        private RadioButton radBetweenDate;
        private ComboBox cobWorkType;
        private Label label1;
        private DateTimePicker dtpDateTo;
        private Label lblDateTo;
        private Button btnOK;
        private DataGridView dataGridView;
        private Button btnClose;
        private Label label2;
        private Button btnExportReport;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblRecordCount;
        private DateTimePicker dtpDateFrom;
        private ToolStripStatusLabel lblElapsed;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}