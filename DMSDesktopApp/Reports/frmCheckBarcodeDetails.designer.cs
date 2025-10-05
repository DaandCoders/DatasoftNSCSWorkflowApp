namespace DMS.DesktopApp.Reports
{
    partial class frmCheckBarcodeDetails
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
            dgvData = new DataGridView();
            btnClose = new Button();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            btnOk = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnExport = new Button();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblRecordCount = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AllowUserToOrderColumns = true;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Cursor = Cursors.Hand;
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(3, 55);
            dgvData.MultiSelect = false;
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1274, 473);
            dgvData.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = SystemColors.ButtonHighlight;
            btnClose.Location = new Point(1126, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(151, 47);
            btnClose.TabIndex = 5;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(5, 5);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel2);
            splitContainer1.Size = new Size(1280, 592);
            splitContainer1.SplitterDistance = 531;
            splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dgvData, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.792844F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90.20715F));
            tableLayoutPanel1.Size = new Size(1280, 531);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1274, 46);
            panel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.712716F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.33281F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.937888F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.8757763F));
            tableLayoutPanel2.Controls.Add(lblBarcode, 0, 0);
            tableLayoutPanel2.Controls.Add(txtBarcode, 1, 0);
            tableLayoutPanel2.Controls.Add(btnOk, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1274, 46);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Dock = DockStyle.Fill;
            lblBarcode.Location = new Point(3, 0);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(170, 46);
            lblBarcode.TabIndex = 0;
            lblBarcode.Tag = "Barcode";
            lblBarcode.Text = "Barcode";
            lblBarcode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBarcode
            // 
            txtBarcode.BackColor = SystemColors.Info;
            tableLayoutPanel2.SetColumnSpan(txtBarcode, 2);
            txtBarcode.Dock = DockStyle.Fill;
            txtBarcode.Location = new Point(179, 3);
            txtBarcode.Multiline = true;
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(688, 40);
            txtBarcode.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.RoyalBlue;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = SystemColors.ButtonHighlight;
            btnOk.Location = new Point(873, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(277, 40);
            btnOk.TabIndex = 2;
            btnOk.Tag = "OK";
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOK_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnClose);
            flowLayoutPanel2.Controls.Add(btnExport);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1280, 57);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.SeaGreen;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = SystemColors.ButtonHighlight;
            btnExport.Location = new Point(969, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(151, 47);
            btnExport.TabIndex = 5;
            btnExport.Tag = "Export";
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(104, 20);
            toolStripStatusLabel1.Text = "Total Records";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(27, 20);
            lblRecordCount.Text = "00";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblRecordCount });
            statusStrip1.Location = new Point(5, 597);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1280, 26);
            statusStrip1.TabIndex = 7;
            statusStrip1.Tag = "Total Records";
            statusStrip1.Text = "statusStrip1";
            // 
            // frmCheckBarcodeDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1290, 628);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Margin = new Padding(5);
            Name = "frmCheckBarcodeDetails";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search Case File";
            FormClosed += frmDayReport_FormClosed;
            Load += FrmDayReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvData;
        private Button btnClose;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
        private Button btnExport;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblRecordCount;
        private StatusStrip statusStrip1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnOk;
        private Label lblBarcode;
        private TextBox txtBarcode;
    }
}