namespace DMS.DesktopApp.Scan
{
    partial class frmScan
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScan));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            lblPageCount = new ToolStripStatusLabel();
            seprator1 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblGeneratedPath = new ToolStripStatusLabel();
            lblImagePosition = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            lblImageCoordinates = new ToolStripStatusLabel();
            spcMain = new SplitContainer();
            splitContainer2 = new SplitContainer();
            tlpScanBatch = new TableLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            label15 = new Label();
            label4 = new Label();
            cobCaseYear = new ComboBox();
            label14 = new Label();
            txtSection = new TextBox();
            label13 = new Label();
            txtAct = new TextBox();
            label12 = new Label();
            txtNatureOfDisposal = new TextBox();
            label11 = new Label();
            txtDOD = new TextBox();
            label10 = new Label();
            txtDOR = new TextBox();
            label9 = new Label();
            txtAdvocate = new TextBox();
            label8 = new Label();
            txtFileNumber = new TextBox();
            label6 = new Label();
            txtDepartmentName = new TextBox();
            txtCaseNo = new TextBox();
            cobBarcode = new ComboBox();
            lblFileName = new Label();
            cobFileName = new ComboBox();
            txtCaseTitle = new TextBox();
            spcScanData = new SplitContainer();
            lstImgBox = new CheckedListBox();
            imgQueueContectMenu = new ContextMenuStrip(components);
            menCut = new ToolStripMenuItem();
            menRename = new ToolStripMenuItem();
            menDelete = new ToolStripMenuItem();
            menDeleteSelected = new ToolStripMenuItem();
            menCancelCut = new ToolStripMenuItem();
            menInsertBefore = new ToolStripMenuItem();
            cmenInsertAfter = new ToolStripMenuItem();
            imgBox = new UKA.Windows.Forms.ImageBox();
            tspFrontImage = new ToolStrip();
            btnZoomIn = new ToolStripButton();
            btnZoomOut = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnRotateLeft = new ToolStripButton();
            btnRotateRight = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            btnFrontZoomToFit = new ToolStripButton();
            btnFrontActualSize = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            btnDeskew = new ToolStripButton();
            btnCrop = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            btnRefresh = new ToolStripButton();
            btnSave = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            txtGoto = new ToolStripTextBox();
            toolStripSeparator4 = new ToolStripSeparator();
            btnGoto = new ToolStripButton();
            cobZoomLevel = new ToolStripComboBox();
            toolStripSeparator9 = new ToolStripSeparator();
            chkImagesRaw = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            btnFirst = new ToolStripButton();
            btnPrevious = new ToolStripButton();
            btnNext = new ToolStripButton();
            btnLast = new ToolStripButton();
            tspScanningTool = new ToolStrip();
            btnSources = new ToolStripDropDownButton();
            sepSourceList = new ToolStripSeparator();
            reloadSourcesListToolStripMenuItem = new ToolStripMenuItem();
            btnStartCapture = new ToolStripButton();
            btnStopScan = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            lblDPI = new ToolStripLabel();
            cobDPI = new ToolStripComboBox();
            lblMode = new ToolStripLabel();
            cobMode = new ToolStripComboBox();
            lblSize = new ToolStripLabel();
            cobSize = new ToolStripComboBox();
            lblFormat = new ToolStripLabel();
            cobOutputFormat = new ToolStripComboBox();
            lblDuplex = new ToolStripLabel();
            chkDuplex = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnScannerSettings = new ToolStripButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClose = new Button();
            btnSubmit = new Button();
            menTop = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menScanNewPage = new ToolStripMenuItem();
            menScanBefore = new ToolStripMenuItem();
            menScanAfter = new ToolStripMenuItem();
            menReplaceScan = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcMain).BeginInit();
            spcMain.Panel1.SuspendLayout();
            spcMain.Panel2.SuspendLayout();
            spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tlpScanBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcScanData).BeginInit();
            spcScanData.Panel1.SuspendLayout();
            spcScanData.Panel2.SuspendLayout();
            spcScanData.SuspendLayout();
            imgQueueContectMenu.SuspendLayout();
            tspFrontImage.SuspendLayout();
            toolStrip1.SuspendLayout();
            tspScanningTool.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            menTop.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, lblPageCount, seprator1, toolStripStatusLabel1, lblGeneratedPath, lblImagePosition, toolStripStatusLabel3, lblImageCoordinates });
            statusStrip1.Location = new Point(0, 538);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(1199, 24);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(69, 19);
            toolStripStatusLabel2.Tag = "Page Count";
            toolStripStatusLabel2.Text = "Page Count";
            // 
            // lblPageCount
            // 
            lblPageCount.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblPageCount.BorderStyle = Border3DStyle.SunkenOuter;
            lblPageCount.Name = "lblPageCount";
            lblPageCount.Size = new Size(23, 19);
            lblPageCount.Text = "00";
            // 
            // seprator1
            // 
            seprator1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            seprator1.ForeColor = SystemColors.ControlDarkDark;
            seprator1.Name = "seprator1";
            seprator1.Size = new Size(11, 19);
            seprator1.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(53, 19);
            toolStripStatusLabel1.Tag = "Location";
            toolStripStatusLabel1.Text = "Location";
            // 
            // lblGeneratedPath
            // 
            lblGeneratedPath.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblGeneratedPath.BorderStyle = Border3DStyle.SunkenOuter;
            lblGeneratedPath.DoubleClickEnabled = true;
            lblGeneratedPath.Name = "lblGeneratedPath";
            lblGeneratedPath.Size = new Size(29, 19);
            lblGeneratedPath.Text = "000";
            lblGeneratedPath.Click += lblGeneratedPath_Click;
            // 
            // lblImagePosition
            // 
            lblImagePosition.Name = "lblImagePosition";
            lblImagePosition.Size = new Size(19, 19);
            lblImagePosition.Text = "00";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(71, 19);
            toolStripStatusLabel3.Tag = "Coordinates";
            toolStripStatusLabel3.Text = "Coordinates";
            // 
            // lblImageCoordinates
            // 
            lblImageCoordinates.Name = "lblImageCoordinates";
            lblImageCoordinates.Size = new Size(86, 19);
            lblImageCoordinates.Tag = "X:0 Y:0 W:0 H:0";
            lblImageCoordinates.Text = "X:0 Y:0 W:0 H:0";
            // 
            // spcMain
            // 
            spcMain.Dock = DockStyle.Fill;
            spcMain.FixedPanel = FixedPanel.Panel2;
            spcMain.IsSplitterFixed = true;
            spcMain.Location = new Point(0, 24);
            spcMain.Margin = new Padding(3, 2, 3, 2);
            spcMain.Name = "spcMain";
            spcMain.Orientation = Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            spcMain.Panel1.Controls.Add(splitContainer2);
            spcMain.Panel1.Controls.Add(tspScanningTool);
            // 
            // spcMain.Panel2
            // 
            spcMain.Panel2.Controls.Add(flowLayoutPanel1);
            spcMain.Size = new Size(1199, 514);
            spcMain.SplitterDistance = 486;
            spcMain.SplitterWidth = 3;
            spcMain.TabIndex = 1;
            spcMain.SplitterMoved += spcMain_SplitterMoved;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 27);
            splitContainer2.Margin = new Padding(3, 2, 3, 2);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tlpScanBatch);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(spcScanData);
            splitContainer2.Size = new Size(1199, 459);
            splitContainer2.SplitterDistance = 316;
            splitContainer2.TabIndex = 2;
            // 
            // tlpScanBatch
            // 
            tlpScanBatch.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            tlpScanBatch.ColumnCount = 2;
            tlpScanBatch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.852459F));
            tlpScanBatch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.14754F));
            tlpScanBatch.Controls.Add(label2, 0, 3);
            tlpScanBatch.Controls.Add(label1, 0, 2);
            tlpScanBatch.Controls.Add(label15, 0, 0);
            tlpScanBatch.Controls.Add(label4, 0, 1);
            tlpScanBatch.Controls.Add(cobCaseYear, 1, 1);
            tlpScanBatch.Controls.Add(label14, 0, 11);
            tlpScanBatch.Controls.Add(txtSection, 1, 11);
            tlpScanBatch.Controls.Add(label13, 0, 10);
            tlpScanBatch.Controls.Add(txtAct, 1, 10);
            tlpScanBatch.Controls.Add(label12, 0, 9);
            tlpScanBatch.Controls.Add(txtNatureOfDisposal, 1, 9);
            tlpScanBatch.Controls.Add(label11, 0, 8);
            tlpScanBatch.Controls.Add(txtDOD, 1, 8);
            tlpScanBatch.Controls.Add(label10, 0, 7);
            tlpScanBatch.Controls.Add(txtDOR, 1, 7);
            tlpScanBatch.Controls.Add(label9, 0, 6);
            tlpScanBatch.Controls.Add(txtAdvocate, 1, 6);
            tlpScanBatch.Controls.Add(label8, 0, 5);
            tlpScanBatch.Controls.Add(txtFileNumber, 1, 5);
            tlpScanBatch.Controls.Add(label6, 0, 4);
            tlpScanBatch.Controls.Add(txtDepartmentName, 1, 4);
            tlpScanBatch.Controls.Add(txtCaseNo, 1, 3);
            tlpScanBatch.Controls.Add(cobBarcode, 1, 0);
            tlpScanBatch.Controls.Add(lblFileName, 0, 12);
            tlpScanBatch.Controls.Add(cobFileName, 1, 12);
            tlpScanBatch.Controls.Add(txtCaseTitle, 1, 2);
            tlpScanBatch.Dock = DockStyle.Fill;
            tlpScanBatch.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpScanBatch.Location = new Point(0, 0);
            tlpScanBatch.Margin = new Padding(4);
            tlpScanBatch.Name = "tlpScanBatch";
            tlpScanBatch.Padding = new Padding(4);
            tlpScanBatch.RowCount = 13;
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tlpScanBatch.Size = new Size(316, 459);
            tlpScanBatch.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(10, 109);
            label2.Name = "label2";
            label2.Size = new Size(80, 31);
            label2.TabIndex = 1;
            label2.Tag = "Case Number";
            label2.Text = "Case Number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(10, 75);
            label1.Name = "label1";
            label1.Size = new Size(80, 31);
            label1.TabIndex = 0;
            label1.Tag = "Case Type";
            label1.Text = "Case Type";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Dock = DockStyle.Fill;
            label15.Location = new Point(10, 7);
            label15.Name = "label15";
            label15.Size = new Size(80, 31);
            label15.TabIndex = 6;
            label15.Tag = "Barcode";
            label15.Text = "Barcode";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(10, 41);
            label4.Name = "label4";
            label4.Size = new Size(80, 31);
            label4.TabIndex = 3;
            label4.Tag = "Case Year";
            label4.Text = "Case Year";
            // 
            // cobCaseYear
            // 
            cobCaseYear.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cobCaseYear.AutoCompleteSource = AutoCompleteSource.ListItems;
            cobCaseYear.Dock = DockStyle.Fill;
            cobCaseYear.Enabled = false;
            cobCaseYear.FormattingEnabled = true;
            cobCaseYear.Location = new Point(99, 43);
            cobCaseYear.Margin = new Padding(3, 2, 3, 2);
            cobCaseYear.Name = "cobCaseYear";
            cobCaseYear.Size = new Size(207, 23);
            cobCaseYear.TabIndex = 4;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(10, 381);
            label14.Name = "label14";
            label14.Size = new Size(80, 31);
            label14.TabIndex = 13;
            label14.Tag = "Section";
            label14.Text = "Section";
            label14.Visible = false;
            // 
            // txtSection
            // 
            txtSection.Dock = DockStyle.Fill;
            txtSection.Enabled = false;
            txtSection.Location = new Point(99, 383);
            txtSection.Margin = new Padding(3, 2, 3, 2);
            txtSection.Multiline = true;
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(207, 27);
            txtSection.TabIndex = 21;
            txtSection.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Location = new Point(10, 347);
            label13.Name = "label13";
            label13.Size = new Size(80, 31);
            label13.TabIndex = 12;
            label13.Tag = "Act";
            label13.Text = "Act";
            label13.Visible = false;
            // 
            // txtAct
            // 
            txtAct.Dock = DockStyle.Fill;
            txtAct.Enabled = false;
            txtAct.Location = new Point(99, 349);
            txtAct.Margin = new Padding(3, 2, 3, 2);
            txtAct.Multiline = true;
            txtAct.Name = "txtAct";
            txtAct.Size = new Size(207, 27);
            txtAct.TabIndex = 20;
            txtAct.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(10, 313);
            label12.Name = "label12";
            label12.Size = new Size(80, 31);
            label12.TabIndex = 11;
            label12.Tag = "Nature of Disposal";
            label12.Text = "Nature of Disposal";
            label12.Visible = false;
            // 
            // txtNatureOfDisposal
            // 
            txtNatureOfDisposal.Dock = DockStyle.Fill;
            txtNatureOfDisposal.Enabled = false;
            txtNatureOfDisposal.Location = new Point(99, 315);
            txtNatureOfDisposal.Margin = new Padding(3, 2, 3, 2);
            txtNatureOfDisposal.Multiline = true;
            txtNatureOfDisposal.Name = "txtNatureOfDisposal";
            txtNatureOfDisposal.Size = new Size(207, 27);
            txtNatureOfDisposal.TabIndex = 19;
            txtNatureOfDisposal.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(10, 279);
            label11.Name = "label11";
            label11.Size = new Size(80, 31);
            label11.TabIndex = 10;
            label11.Tag = "Date of Decision";
            label11.Text = "Date of Decision";
            label11.Visible = false;
            // 
            // txtDOD
            // 
            txtDOD.Dock = DockStyle.Fill;
            txtDOD.Enabled = false;
            txtDOD.Location = new Point(99, 281);
            txtDOD.Margin = new Padding(3, 2, 3, 2);
            txtDOD.Multiline = true;
            txtDOD.Name = "txtDOD";
            txtDOD.Size = new Size(207, 27);
            txtDOD.TabIndex = 18;
            txtDOD.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(10, 245);
            label10.Name = "label10";
            label10.Size = new Size(80, 31);
            label10.TabIndex = 9;
            label10.Tag = "Date of Registration";
            label10.Text = "Date of Registration";
            label10.Visible = false;
            // 
            // txtDOR
            // 
            txtDOR.Dock = DockStyle.Fill;
            txtDOR.Enabled = false;
            txtDOR.Location = new Point(99, 247);
            txtDOR.Margin = new Padding(3, 2, 3, 2);
            txtDOR.Multiline = true;
            txtDOR.Name = "txtDOR";
            txtDOR.Size = new Size(207, 27);
            txtDOR.TabIndex = 17;
            txtDOR.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(10, 211);
            label9.Name = "label9";
            label9.Size = new Size(80, 31);
            label9.TabIndex = 8;
            label9.Tag = "Advocate";
            label9.Text = "Advocate";
            label9.Visible = false;
            // 
            // txtAdvocate
            // 
            txtAdvocate.Dock = DockStyle.Fill;
            txtAdvocate.Enabled = false;
            txtAdvocate.Location = new Point(99, 213);
            txtAdvocate.Margin = new Padding(3, 2, 3, 2);
            txtAdvocate.Multiline = true;
            txtAdvocate.Name = "txtAdvocate";
            txtAdvocate.Size = new Size(207, 27);
            txtAdvocate.TabIndex = 16;
            txtAdvocate.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(10, 177);
            label8.Name = "label8";
            label8.Size = new Size(80, 31);
            label8.TabIndex = 7;
            label8.Tag = "File Number";
            label8.Text = "File Number";
            // 
            // txtFileNumber
            // 
            txtFileNumber.Dock = DockStyle.Fill;
            txtFileNumber.Enabled = false;
            txtFileNumber.Location = new Point(99, 179);
            txtFileNumber.Margin = new Padding(3, 2, 3, 2);
            txtFileNumber.Multiline = true;
            txtFileNumber.Name = "txtFileNumber";
            txtFileNumber.Size = new Size(207, 27);
            txtFileNumber.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 143);
            label6.Name = "label6";
            label6.Size = new Size(73, 30);
            label6.TabIndex = 6;
            label6.Tag = "Department Name";
            label6.Text = "Department Name";
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Dock = DockStyle.Fill;
            txtDepartmentName.Enabled = false;
            txtDepartmentName.Location = new Point(99, 145);
            txtDepartmentName.Margin = new Padding(3, 2, 3, 2);
            txtDepartmentName.Multiline = true;
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(207, 27);
            txtDepartmentName.TabIndex = 14;
            // 
            // txtCaseNo
            // 
            txtCaseNo.Dock = DockStyle.Fill;
            txtCaseNo.Enabled = false;
            txtCaseNo.Location = new Point(99, 111);
            txtCaseNo.Margin = new Padding(3, 2, 3, 2);
            txtCaseNo.Name = "txtCaseNo";
            txtCaseNo.Size = new Size(207, 23);
            txtCaseNo.TabIndex = 22;
            // 
            // cobBarcode
            // 
            cobBarcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cobBarcode.AutoCompleteSource = AutoCompleteSource.ListItems;
            cobBarcode.Dock = DockStyle.Fill;
            cobBarcode.FormattingEnabled = true;
            cobBarcode.Location = new Point(99, 9);
            cobBarcode.Margin = new Padding(3, 2, 3, 2);
            cobBarcode.Name = "cobBarcode";
            cobBarcode.Size = new Size(207, 23);
            cobBarcode.TabIndex = 23;
            cobBarcode.SelectedIndexChanged += cobBarcode_SelectedIndexChanged;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(10, 415);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(60, 15);
            lblFileName.TabIndex = 24;
            lblFileName.Tag = "File Name";
            lblFileName.Text = "File Name";
            // 
            // cobFileName
            // 
            cobFileName.Dock = DockStyle.Fill;
            cobFileName.FormattingEnabled = true;
            cobFileName.Items.AddRange(new object[] { "NS", "CS" });
            cobFileName.Location = new Point(99, 417);
            cobFileName.Margin = new Padding(3, 2, 3, 2);
            cobFileName.Name = "cobFileName";
            cobFileName.Size = new Size(207, 23);
            cobFileName.TabIndex = 25;
            cobFileName.SelectedIndexChanged += cobFileName_SelectedIndexChanged;
            // 
            // txtCaseTitle
            // 
            txtCaseTitle.BackColor = SystemColors.Window;
            txtCaseTitle.Dock = DockStyle.Fill;
            txtCaseTitle.Location = new Point(99, 78);
            txtCaseTitle.Name = "txtCaseTitle";
            txtCaseTitle.ReadOnly = true;
            txtCaseTitle.Size = new Size(207, 23);
            txtCaseTitle.TabIndex = 26;
            // 
            // spcScanData
            // 
            spcScanData.Dock = DockStyle.Fill;
            spcScanData.FixedPanel = FixedPanel.Panel1;
            spcScanData.Location = new Point(0, 0);
            spcScanData.Margin = new Padding(3, 2, 3, 2);
            spcScanData.Name = "spcScanData";
            // 
            // spcScanData.Panel1
            // 
            spcScanData.Panel1.Controls.Add(lstImgBox);
            // 
            // spcScanData.Panel2
            // 
            spcScanData.Panel2.Controls.Add(imgBox);
            spcScanData.Panel2.Controls.Add(tspFrontImage);
            spcScanData.Panel2.Controls.Add(toolStrip1);
            spcScanData.Size = new Size(879, 459);
            spcScanData.SplitterDistance = 169;
            spcScanData.TabIndex = 0;
            spcScanData.SplitterMoved += spcScanData_SplitterMoved;
            // 
            // lstImgBox
            // 
            lstImgBox.ContextMenuStrip = imgQueueContectMenu;
            lstImgBox.Dock = DockStyle.Fill;
            lstImgBox.FormattingEnabled = true;
            lstImgBox.Location = new Point(0, 0);
            lstImgBox.Name = "lstImgBox";
            lstImgBox.Size = new Size(169, 459);
            lstImgBox.Sorted = true;
            lstImgBox.TabIndex = 0;
            lstImgBox.KeyDown += lstImgBox_KeyDown;
            lstImgBox.MouseDown += lstImgBox_MouseDown;
            lstImgBox.SystemColorsChanged += lstImgBox_SelectedIndexChanged;
            // 
            // imgQueueContectMenu
            // 
            imgQueueContectMenu.ImageScalingSize = new Size(20, 20);
            imgQueueContectMenu.Items.AddRange(new ToolStripItem[] { menCut, menRename, menDelete, menDeleteSelected, menCancelCut, menInsertBefore, cmenInsertAfter });
            imgQueueContectMenu.Name = "imgQueueContectMenu";
            imgQueueContectMenu.Size = new Size(211, 158);
            // 
            // menCut
            // 
            menCut.Name = "menCut";
            menCut.Size = new Size(210, 22);
            menCut.Text = "Cut";
            menCut.Click += menCut_Click;
            // 
            // menRename
            // 
            menRename.Enabled = false;
            menRename.Name = "menRename";
            menRename.Size = new Size(210, 22);
            menRename.Text = "Rename";
            // 
            // menDelete
            // 
            menDelete.Name = "menDelete";
            menDelete.ShortcutKeyDisplayString = "Del";
            menDelete.Size = new Size(210, 22);
            menDelete.Text = "Delete";
            menDelete.Click += menDelete_Click;
            // 
            // menDeleteSelected
            // 
            menDeleteSelected.Enabled = false;
            menDeleteSelected.Name = "menDeleteSelected";
            menDeleteSelected.ShortcutKeyDisplayString = "Shift+Del";
            menDeleteSelected.Size = new Size(210, 22);
            menDeleteSelected.Text = "Delete Selected";
            menDeleteSelected.Click += menDeleteSelected_Click;
            // 
            // menCancelCut
            // 
            menCancelCut.Enabled = false;
            menCancelCut.Name = "menCancelCut";
            menCancelCut.Size = new Size(210, 22);
            menCancelCut.Text = "Cancel Cut";
            // 
            // menInsertBefore
            // 
            menInsertBefore.Enabled = false;
            menInsertBefore.Name = "menInsertBefore";
            menInsertBefore.Size = new Size(210, 22);
            menInsertBefore.Text = "Paste Before";
            // 
            // cmenInsertAfter
            // 
            cmenInsertAfter.Enabled = false;
            cmenInsertAfter.Name = "cmenInsertAfter";
            cmenInsertAfter.Size = new Size(210, 22);
            cmenInsertAfter.Text = "Paste After";
            // 
            // imgBox
            // 
            imgBox.BackColor = Color.LightGray;
            imgBox.Dock = DockStyle.Fill;
            imgBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            imgBox.ForeColor = Color.Black;
            imgBox.GridDisplayMode = UKA.Windows.Forms.ImageBoxGridDisplayMode.None;
            imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            imgBox.Location = new Point(0, 31);
            imgBox.Margin = new Padding(4);
            imgBox.Name = "imgBox";
            imgBox.SelectionMode = UKA.Windows.Forms.ImageBoxSelectionMode.Rectangle;
            imgBox.Size = new Size(706, 397);
            imgBox.SizeMode = UKA.Windows.Forms.ImageBoxSizeMode.Fit;
            imgBox.TabIndex = 5;
            imgBox.Text = "DCS Imaging";
            imgBox.TextAlign = ContentAlignment.BottomRight;
            // 
            // tspFrontImage
            // 
            tspFrontImage.ImageScalingSize = new Size(24, 24);
            tspFrontImage.Items.AddRange(new ToolStripItem[] { btnZoomIn, btnZoomOut, toolStripSeparator5, btnRotateLeft, btnRotateRight, toolStripSeparator6, btnFrontZoomToFit, btnFrontActualSize, toolStripSeparator7, btnDeskew, btnCrop, toolStripSeparator8, btnRefresh, btnSave, toolStripSeparator3, txtGoto, toolStripSeparator4, btnGoto, cobZoomLevel, toolStripSeparator9, chkImagesRaw });
            tspFrontImage.Location = new Point(0, 0);
            tspFrontImage.Name = "tspFrontImage";
            tspFrontImage.Padding = new Padding(0, 0, 3, 0);
            tspFrontImage.Size = new Size(706, 31);
            tspFrontImage.TabIndex = 4;
            tspFrontImage.Text = "toolStrip2";
            // 
            // btnZoomIn
            // 
            btnZoomIn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnZoomIn.Image = Properties.Resources.zoom_in_24px;
            btnZoomIn.ImageTransparentColor = Color.Magenta;
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(28, 28);
            btnZoomIn.Tag = "Zoom In (Key Add)";
            btnZoomIn.Text = "Zoom In (Key Add)";
            btnZoomIn.ToolTipText = "Zoom In,  (Key Add)";
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // btnZoomOut
            // 
            btnZoomOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnZoomOut.Image = Properties.Resources.zoom_out_24px;
            btnZoomOut.ImageTransparentColor = Color.Magenta;
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(28, 28);
            btnZoomOut.Tag = "Zoom Out (Key Subtract)";
            btnZoomOut.Text = "Zoom Out (Key Subtract)";
            btnZoomOut.ToolTipText = "Zoom Out, (Key Subtract)";
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 31);
            // 
            // btnRotateLeft
            // 
            btnRotateLeft.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRotateLeft.Image = Properties.Resources.RotateLeft;
            btnRotateLeft.ImageTransparentColor = Color.Magenta;
            btnRotateLeft.Name = "btnRotateLeft";
            btnRotateLeft.Size = new Size(28, 28);
            btnRotateLeft.Tag = "Rotate Left";
            btnRotateLeft.Text = "Rotate Left";
            btnRotateLeft.ToolTipText = "Rotate Left,  (Ctrl+L)";
            btnRotateLeft.Click += btnRotateLeft_Click;
            // 
            // btnRotateRight
            // 
            btnRotateRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRotateRight.Image = Properties.Resources.RotateRight;
            btnRotateRight.ImageTransparentColor = Color.Magenta;
            btnRotateRight.Name = "btnRotateRight";
            btnRotateRight.Size = new Size(28, 28);
            btnRotateRight.Tag = "Rotate Right";
            btnRotateRight.Text = "Rotate Right";
            btnRotateRight.ToolTipText = "Rotate Right, ( Ctrl+R)";
            btnRotateRight.Click += btnRotateRight_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 31);
            // 
            // btnFrontZoomToFit
            // 
            btnFrontZoomToFit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontZoomToFit.Image = Properties.Resources.fitTo;
            btnFrontZoomToFit.ImageTransparentColor = Color.Magenta;
            btnFrontZoomToFit.Name = "btnFrontZoomToFit";
            btnFrontZoomToFit.Size = new Size(28, 28);
            btnFrontZoomToFit.Tag = "Fit To Zoom";
            btnFrontZoomToFit.Text = "Fit To Zoom";
            btnFrontZoomToFit.ToolTipText = "Fit To Zoom (Key F)";
            btnFrontZoomToFit.Click += btnFrontZoomToFit_Click;
            // 
            // btnFrontActualSize
            // 
            btnFrontActualSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontActualSize.Image = Properties.Resources.actualSize;
            btnFrontActualSize.ImageTransparentColor = Color.Magenta;
            btnFrontActualSize.Name = "btnFrontActualSize";
            btnFrontActualSize.Size = new Size(28, 28);
            btnFrontActualSize.Tag = "Actual Size";
            btnFrontActualSize.Text = "Actual Size";
            btnFrontActualSize.ToolTipText = "Actual Size (Key A)";
            btnFrontActualSize.Click += btnFrontActualSize_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 31);
            // 
            // btnDeskew
            // 
            btnDeskew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDeskew.Image = Properties.Resources.deskew;
            btnDeskew.ImageTransparentColor = Color.Magenta;
            btnDeskew.Name = "btnDeskew";
            btnDeskew.Size = new Size(28, 28);
            btnDeskew.Tag = "Deskew";
            btnDeskew.Text = "Deskew";
            btnDeskew.ToolTipText = "Deskew, (Ctrl+ D)";
            btnDeskew.Click += btnDeskew_Click;
            // 
            // btnCrop
            // 
            btnCrop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCrop.Image = Properties.Resources.crop;
            btnCrop.ImageTransparentColor = Color.Magenta;
            btnCrop.Name = "btnCrop";
            btnCrop.Size = new Size(28, 28);
            btnCrop.Tag = "Front Crop";
            btnCrop.Text = "Front Crop";
            btnCrop.ToolTipText = "ImageCrop, (Ctrl+ C)";
            btnCrop.Visible = false;
            btnCrop.Click += btnCrop_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 31);
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(28, 28);
            btnRefresh.Tag = "Refresh Image";
            btnRefresh.Text = "Refresh Image";
            btnRefresh.ToolTipText = " Refresh Image, (Key F5)";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSave.Enabled = false;
            btnSave.Image = Properties.Resources.save1;
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(28, 28);
            btnSave.Tag = "Save Image (Ctrl+S)";
            btnSave.Text = "Save Image (Ctrl+S)";
            btnSave.Click += btnSave_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // txtGoto
            // 
            txtGoto.BackColor = SystemColors.Info;
            txtGoto.Name = "txtGoto";
            txtGoto.Size = new Size(116, 31);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 31);
            // 
            // btnGoto
            // 
            btnGoto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGoto.Image = Properties.Resources.goto_16px;
            btnGoto.ImageTransparentColor = Color.Magenta;
            btnGoto.Name = "btnGoto";
            btnGoto.Size = new Size(28, 28);
            btnGoto.Text = "Goto";
            btnGoto.Click += btnGoto_Click;
            // 
            // cobZoomLevel
            // 
            cobZoomLevel.BackColor = SystemColors.Info;
            cobZoomLevel.Name = "cobZoomLevel";
            cobZoomLevel.Size = new Size(106, 31);
            cobZoomLevel.SelectedIndexChanged += cobZoomLevel_SelectedIndexChanged;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(6, 31);
            // 
            // chkImagesRaw
            // 
            chkImagesRaw.CheckOnClick = true;
            chkImagesRaw.DisplayStyle = ToolStripItemDisplayStyle.Image;
            chkImagesRaw.Image = Properties.Resources.checkboxUnchecked50x;
            chkImagesRaw.ImageTransparentColor = Color.Magenta;
            chkImagesRaw.Name = "chkImagesRaw";
            chkImagesRaw.Size = new Size(28, 28);
            chkImagesRaw.Text = "Image from Raw";
            chkImagesRaw.Visible = false;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnFirst, btnPrevious, btnNext, btnLast });
            toolStrip1.Location = new Point(0, 428);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(706, 31);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnFirst
            // 
            btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFirst.Image = Properties.Resources.First;
            btnFirst.ImageTransparentColor = Color.Magenta;
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(28, 28);
            btnFirst.Text = "First (Key Left)";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrevious.Image = Properties.Resources.Previous;
            btnPrevious.ImageTransparentColor = Color.Magenta;
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(28, 28);
            btnPrevious.Text = "Previous (Key Previous)";
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = Properties.Resources.Next;
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(28, 28);
            btnNext.Text = "Next (Key Down)";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = Properties.Resources.Last;
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(28, 28);
            btnLast.Text = "Last (Key Right)";
            btnLast.Click += btnLast_Click;
            // 
            // tspScanningTool
            // 
            tspScanningTool.BackColor = Color.Transparent;
            tspScanningTool.ImageScalingSize = new Size(20, 20);
            tspScanningTool.Items.AddRange(new ToolStripItem[] { btnSources, btnStartCapture, btnStopScan, toolStripSeparator1, lblDPI, cobDPI, lblMode, cobMode, lblSize, cobSize, lblFormat, cobOutputFormat, lblDuplex, chkDuplex, toolStripSeparator2, btnScannerSettings });
            tspScanningTool.Location = new Point(0, 0);
            tspScanningTool.Name = "tspScanningTool";
            tspScanningTool.Size = new Size(1199, 27);
            tspScanningTool.TabIndex = 1;
            tspScanningTool.Text = "toolStrip1";
            // 
            // btnSources
            // 
            btnSources.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSources.DropDownItems.AddRange(new ToolStripItem[] { sepSourceList, reloadSourcesListToolStripMenuItem });
            btnSources.Image = (Image)resources.GetObject("btnSources.Image");
            btnSources.ImageTransparentColor = Color.Magenta;
            btnSources.Name = "btnSources";
            btnSources.Size = new Size(93, 24);
            btnSources.Tag = "Select Source";
            btnSources.Text = "Select Source ";
            btnSources.DropDownOpening += btnSources_DropDownOpening;
            // 
            // sepSourceList
            // 
            sepSourceList.Name = "sepSourceList";
            sepSourceList.Size = new Size(168, 6);
            // 
            // reloadSourcesListToolStripMenuItem
            // 
            reloadSourcesListToolStripMenuItem.Name = "reloadSourcesListToolStripMenuItem";
            reloadSourcesListToolStripMenuItem.Size = new Size(171, 22);
            reloadSourcesListToolStripMenuItem.Tag = "&Reload sources list";
            reloadSourcesListToolStripMenuItem.Text = "&Reload sources list";
            reloadSourcesListToolStripMenuItem.Click += reloadSourcesListToolStripMenuItem_Click_1;
            // 
            // btnStartCapture
            // 
            btnStartCapture.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStartCapture.Enabled = false;
            btnStartCapture.Image = Properties.Resources.Start50x3;
            btnStartCapture.ImageTransparentColor = Color.Magenta;
            btnStartCapture.Name = "btnStartCapture";
            btnStartCapture.Size = new Size(24, 24);
            btnStartCapture.Tag = "Start Scan";
            btnStartCapture.Text = "Start Scan";
            btnStartCapture.ToolTipText = "Start Scan,  Key Space";
            btnStartCapture.Click += btnStartCapture_Click_1;
            // 
            // btnStopScan
            // 
            btnStopScan.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStopScan.Enabled = false;
            btnStopScan.Image = Properties.Resources.Stop50x2;
            btnStopScan.ImageTransparentColor = Color.Magenta;
            btnStopScan.Name = "btnStopScan";
            btnStopScan.Size = new Size(24, 24);
            btnStopScan.Tag = "Stop Scan";
            btnStopScan.Text = "Stop Scan";
            btnStopScan.ToolTipText = "Stop Scan, Key End";
            btnStopScan.Click += btnStopScan_Click_1;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // lblDPI
            // 
            lblDPI.Name = "lblDPI";
            lblDPI.Size = new Size(25, 24);
            lblDPI.Tag = "DPI";
            lblDPI.Text = "DPI";
            // 
            // cobDPI
            // 
            cobDPI.BackColor = SystemColors.Info;
            cobDPI.Name = "cobDPI";
            cobDPI.Size = new Size(106, 27);
            cobDPI.SelectedIndexChanged += cobDPI_SelectedIndexChanged;
            // 
            // lblMode
            // 
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(38, 24);
            lblMode.Tag = "Mode";
            lblMode.Text = "Mode";
            // 
            // cobMode
            // 
            cobMode.BackColor = SystemColors.Info;
            cobMode.Name = "cobMode";
            cobMode.Size = new Size(106, 27);
            cobMode.SelectedIndexChanged += cobMode_SelectedIndexChanged;
            // 
            // lblSize
            // 
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(27, 24);
            lblSize.Tag = "Size";
            lblSize.Text = "Size";
            // 
            // cobSize
            // 
            cobSize.BackColor = SystemColors.Info;
            cobSize.Name = "cobSize";
            cobSize.Size = new Size(106, 27);
            cobSize.SelectedIndexChanged += comboSize_SelectedIndexChanged;
            // 
            // lblFormat
            // 
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(45, 24);
            lblFormat.Tag = "Format";
            lblFormat.Text = "Format";
            // 
            // cobOutputFormat
            // 
            cobOutputFormat.BackColor = SystemColors.Info;
            cobOutputFormat.Items.AddRange(new object[] { "JPG", "TIFF" });
            cobOutputFormat.Name = "cobOutputFormat";
            cobOutputFormat.Size = new Size(106, 27);
            cobOutputFormat.SelectedIndexChanged += cobOutputFormat_SelectedIndexChanged;
            // 
            // lblDuplex
            // 
            lblDuplex.Name = "lblDuplex";
            lblDuplex.Size = new Size(43, 24);
            lblDuplex.Tag = "Duplex";
            lblDuplex.Text = "Duplex";
            // 
            // chkDuplex
            // 
            chkDuplex.CheckOnClick = true;
            chkDuplex.DisplayStyle = ToolStripItemDisplayStyle.Image;
            chkDuplex.Image = Properties.Resources.checkboxUnchecked50x;
            chkDuplex.ImageTransparentColor = Color.Magenta;
            chkDuplex.Name = "chkDuplex";
            chkDuplex.Size = new Size(24, 24);
            chkDuplex.Text = "toolStripButton1";
            chkDuplex.CheckedChanged += ckDuplex_CheckedChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // btnScannerSettings
            // 
            btnScannerSettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnScannerSettings.Image = Properties.Resources.Settings50x3;
            btnScannerSettings.ImageTransparentColor = Color.Magenta;
            btnScannerSettings.Name = "btnScannerSettings";
            btnScannerSettings.Size = new Size(24, 24);
            btnScannerSettings.Text = "Scanner Settings";
            btnScannerSettings.Click += btnScannerSettings_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Controls.Add(btnSubmit);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1199, 25);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1092, 2);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 28);
            btnClose.TabIndex = 0;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.RoyalBlue;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatStyle = FlatStyle.Popup;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(982, 2);
            btnSubmit.Margin = new Padding(3, 2, 3, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(104, 28);
            btnSubmit.TabIndex = 0;
            btnSubmit.Tag = "Submit";
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // menTop
            // 
            menTop.BackColor = Color.Transparent;
            menTop.ImageScalingSize = new Size(20, 20);
            menTop.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menTop.Location = new Point(0, 0);
            menTop.Name = "menTop";
            menTop.Size = new Size(1199, 24);
            menTop.TabIndex = 2;
            menTop.Text = "Scan";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { menScanNewPage, menScanBefore, menScanAfter, menReplaceScan });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(44, 20);
            toolStripMenuItem1.Tag = "Scan";
            toolStripMenuItem1.Text = "Scan";
            // 
            // menScanNewPage
            // 
            menScanNewPage.Name = "menScanNewPage";
            menScanNewPage.ShortcutKeyDisplayString = "Shift+S";
            menScanNewPage.Size = new Size(186, 22);
            menScanNewPage.Tag = "New Page";
            menScanNewPage.Text = "New Page";
            menScanNewPage.Click += menScanNewPage_Click;
            // 
            // menScanBefore
            // 
            menScanBefore.Name = "menScanBefore";
            menScanBefore.ShortcutKeyDisplayString = "Shift+B";
            menScanBefore.Size = new Size(186, 22);
            menScanBefore.Tag = "Insert Before";
            menScanBefore.Text = "Insert Before";
            menScanBefore.Click += menScanBefore_Click;
            // 
            // menScanAfter
            // 
            menScanAfter.Name = "menScanAfter";
            menScanAfter.ShortcutKeyDisplayString = "Shift+A";
            menScanAfter.Size = new Size(186, 22);
            menScanAfter.Tag = "Insert After";
            menScanAfter.Text = "Insert After";
            menScanAfter.Click += menScanAfter_Click;
            // 
            // menReplaceScan
            // 
            menReplaceScan.Name = "menReplaceScan";
            menReplaceScan.ShortcutKeyDisplayString = "Shift+R";
            menReplaceScan.Size = new Size(186, 22);
            menReplaceScan.Tag = "Replace";
            menReplaceScan.Text = "Replace";
            menReplaceScan.Click += menReplaceScan_Click;
            // 
            // frmScan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1199, 562);
            Controls.Add(spcMain);
            Controls.Add(statusStrip1);
            Controls.Add(menTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menTop;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmScan";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "Scan";
            Text = "Scan";
            WindowState = FormWindowState.Maximized;
            Load += frmScan_Load;
            KeyDown += frmScan_KeyDown;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            spcMain.Panel1.ResumeLayout(false);
            spcMain.Panel1.PerformLayout();
            spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcMain).EndInit();
            spcMain.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tlpScanBatch.ResumeLayout(false);
            tlpScanBatch.PerformLayout();
            spcScanData.Panel1.ResumeLayout(false);
            spcScanData.Panel2.ResumeLayout(false);
            spcScanData.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spcScanData).EndInit();
            spcScanData.ResumeLayout(false);
            imgQueueContectMenu.ResumeLayout(false);
            tspFrontImage.ResumeLayout(false);
            tspFrontImage.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tspScanningTool.ResumeLayout(false);
            tspScanningTool.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            menTop.ResumeLayout(false);
            menTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private SplitContainer spcMain;
        private SplitContainer spcScanData;

        private TableLayoutPanel tlpScanBatch;
        private ToolStrip tspScanningTool;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Button btnSubmit;
        private Label label1;
        private Label label4;
        private ComboBox cobCaseYear;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblGeneratedPath;
        private ToolStripStatusLabel seprator1;
        private ToolStripButton btnStartCapture;
        private ToolStripButton btnStopScan;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnScannerSettings;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblPageCount;
        private ToolStripDropDownButton btnSources;
        private ToolStripSeparator sepSourceList;
        private ToolStripMenuItem reloadSourcesListToolStripMenuItem;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtDepartmentName;
        private TextBox txtFileNumber;
        private TextBox txtAdvocate;
        private TextBox txtDOR;
        private TextBox txtDOD;
        private TextBox txtNatureOfDisposal;
        private TextBox txtAct;
        private TextBox txtSection;
        private Label label15;
        private TextBox txtCaseNo;
        private ComboBox cobBarcode;
        private Label lblFileName;
        private ComboBox cobFileName;
        private SplitContainer splitContainer2;
        private ToolStripLabel lblDPI;
        private ToolStripComboBox cobDPI;
        private ToolStripLabel lblMode;
        private ToolStripLabel lblSize;
        private ToolStripLabel lblFormat;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripComboBox cobMode;
        private ToolStripComboBox cobSize;
        private ToolStripComboBox cobOutputFormat;
        private ToolStripButton chkDuplex;
        private ToolStripStatusLabel lblImagePosition;
        private ToolStrip toolStrip1;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrevious;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStrip tspFrontImage;
        private ToolStripButton btnZoomIn;
        private ToolStripButton btnZoomOut;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnRotateLeft;
        private ToolStripButton btnRotateRight;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnFrontZoomToFit;
        private ToolStripButton btnFrontActualSize;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton btnDeskew;
        private ToolStripButton btnCrop;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton btnRefresh;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox txtGoto;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnGoto;
        private ToolStripComboBox cobZoomLevel;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton chkImagesRaw;
        private ToolStripLabel lblDuplex;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel lblImageCoordinates;
        private ContextMenuStrip imgQueueContectMenu;
        private ToolStripMenuItem menCut;
        private ToolStripMenuItem menRename;
        private ToolStripMenuItem menDelete;
        private ToolStripMenuItem menCancelCut;
        private ToolStripMenuItem menInsertBefore;
        private ToolStripMenuItem cmenInsertAfter;
        private MenuStrip menTop;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem menScanNewPage;
        private ToolStripMenuItem menScanBefore;
        private ToolStripMenuItem menScanAfter;
        private ToolStripMenuItem menReplaceScan;
        private CheckedListBox lstImgBox;
        private ToolStripMenuItem menDeleteSelected;
        private UKA.Windows.Forms.ImageBox imgBox;
        private Label label2;
        private TextBox txtCaseTitle;
        //private DCS.WorkflowApp.Controls.ImageBoxAdvance imgBox;
        //private DCS.WorkflowApp.Controls.ImageBoxAdvance imgBox;
    }
}