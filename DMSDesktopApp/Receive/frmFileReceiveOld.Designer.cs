namespace DMS.DesktopApp.Receive
{
    partial class frmFileReceiveOld
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileReceiveOld));
            spcMain = new SplitContainer();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            rabCNRNo = new RadioButton();
            rabFillingNo = new RadioButton();
            rabFIRNo = new RadioButton();
            rabPartyName = new RadioButton();
            rabSubordinateCourt = new RadioButton();
            lblSearch1 = new Label();
            txtSearch1 = new TextBox();
            lblSearch2 = new Label();
            txtSearch2 = new TextBox();
            btnSearch = new Button();
            rabCaseNo = new RadioButton();
            cobPoliceStation = new ComboBox();
            typCaseYear = new TableLayoutPanel();
            cobCaseYear = new ComboBox();
            txtYear = new MaskedTextBox();
            lblCaseYear = new Label();
            lblPoliceStation = new Label();
            lblCaseType = new Label();
            cobCaseType = new ComboBox();
            label3 = new Label();
            cobCourtNameSearch = new ComboBox();
            tlpMain = new TableLayoutPanel();
            txtBarcode = new TextBox();
            label11 = new Label();
            label13 = new Label();
            label14 = new Label();
            txtCollectedFrom = new TextBox();
            label18 = new Label();
            dtCollectedDate = new DateTimePicker();
            txtNoOfPages = new TextBox();
            label15 = new Label();
            label4 = new Label();
            txtPetitionerName = new TextBox();
            txtRespondentName = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtAdvocate = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            cobNatureOfDisposal = new ComboBox();
            label10 = new Label();
            txtAct = new TextBox();
            label12 = new Label();
            txtSection = new TextBox();
            label16 = new Label();
            txtReceivedBy = new TextBox();
            label17 = new Label();
            dtReceivedDate = new DateTimePicker();
            cobCourtName = new ComboBox();
            label19 = new Label();
            cobDistrict = new ComboBox();
            label2 = new Label();
            txtCaseNo = new TextBox();
            label1 = new Label();
            txtCINo = new TextBox();
            txtDateOfDecision = new MaskedTextBox();
            txtDateOfRegistration = new MaskedTextBox();
            flpButtons = new FlowLayoutPanel();
            btnClose = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)spcMain).BeginInit();
            spcMain.Panel1.SuspendLayout();
            spcMain.Panel2.SuspendLayout();
            spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            typCaseYear.SuspendLayout();
            tlpMain.SuspendLayout();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // spcMain
            // 
            spcMain.Dock = DockStyle.Fill;
            spcMain.Location = new Point(0, 0);
            spcMain.Name = "spcMain";
            spcMain.Orientation = Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            spcMain.Panel1.Controls.Add(splitContainer1);
            // 
            // spcMain.Panel2
            // 
            spcMain.Panel2.Controls.Add(flpButtons);
            spcMain.Size = new Size(1370, 749);
            spcMain.SplitterDistance = 673;
            spcMain.SplitterWidth = 5;
            spcMain.TabIndex = 0;
            spcMain.SplitterMoved += spcMain_SplitterMoved;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Padding = new Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tlpMain);
            splitContainer1.Size = new Size(1370, 673);
            splitContainer1.SplitterDistance = 195;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1350, 175);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.0561056F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.442606F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.3040333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.7095718F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.1188116F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.3795376F));
            tableLayoutPanel1.Controls.Add(rabCNRNo, 0, 0);
            tableLayoutPanel1.Controls.Add(rabFillingNo, 1, 0);
            tableLayoutPanel1.Controls.Add(rabFIRNo, 3, 0);
            tableLayoutPanel1.Controls.Add(rabPartyName, 4, 0);
            tableLayoutPanel1.Controls.Add(rabSubordinateCourt, 5, 0);
            tableLayoutPanel1.Controls.Add(lblSearch1, 0, 2);
            tableLayoutPanel1.Controls.Add(txtSearch1, 1, 2);
            tableLayoutPanel1.Controls.Add(lblSearch2, 2, 2);
            tableLayoutPanel1.Controls.Add(txtSearch2, 3, 2);
            tableLayoutPanel1.Controls.Add(btnSearch, 3, 4);
            tableLayoutPanel1.Controls.Add(rabCaseNo, 2, 0);
            tableLayoutPanel1.Controls.Add(cobPoliceStation, 5, 1);
            tableLayoutPanel1.Controls.Add(typCaseYear, 3, 1);
            tableLayoutPanel1.Controls.Add(lblCaseYear, 2, 1);
            tableLayoutPanel1.Controls.Add(lblPoliceStation, 4, 1);
            tableLayoutPanel1.Controls.Add(lblCaseType, 0, 1);
            tableLayoutPanel1.Controls.Add(cobCaseType, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(cobCourtNameSearch, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(3);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(1344, 150);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // rabCNRNo
            // 
            rabCNRNo.AutoSize = true;
            rabCNRNo.Dock = DockStyle.Fill;
            rabCNRNo.Enabled = false;
            rabCNRNo.Location = new Point(6, 6);
            rabCNRNo.Name = "rabCNRNo";
            rabCNRNo.Size = new Size(141, 21);
            rabCNRNo.TabIndex = 0;
            rabCNRNo.TabStop = true;
            rabCNRNo.Tag = "CNR No.";
            rabCNRNo.Text = "CNR No.";
            rabCNRNo.UseVisualStyleBackColor = true;
            rabCNRNo.Click += RadioButton_Checked;
            // 
            // rabFillingNo
            // 
            rabFillingNo.AutoSize = true;
            rabFillingNo.Dock = DockStyle.Fill;
            rabFillingNo.Location = new Point(153, 6);
            rabFillingNo.Name = "rabFillingNo";
            rabFillingNo.Size = new Size(213, 21);
            rabFillingNo.TabIndex = 1;
            rabFillingNo.TabStop = true;
            rabFillingNo.Tag = "Filling No.";
            rabFillingNo.Text = "Filling No.";
            rabFillingNo.UseVisualStyleBackColor = true;
            rabFillingNo.Click += RadioButton_Checked;
            // 
            // rabFIRNo
            // 
            rabFIRNo.AutoSize = true;
            rabFIRNo.Dock = DockStyle.Fill;
            rabFIRNo.Enabled = false;
            rabFIRNo.Location = new Point(616, 6);
            rabFIRNo.Name = "rabFIRNo";
            rabFIRNo.Size = new Size(271, 21);
            rabFIRNo.TabIndex = 3;
            rabFIRNo.TabStop = true;
            rabFIRNo.Tag = "FIR No.";
            rabFIRNo.Text = "FIR No.";
            rabFIRNo.UseVisualStyleBackColor = true;
            rabFIRNo.Click += RadioButton_Checked;
            // 
            // rabPartyName
            // 
            rabPartyName.AutoSize = true;
            rabPartyName.Dock = DockStyle.Fill;
            rabPartyName.Enabled = false;
            rabPartyName.Location = new Point(893, 6);
            rabPartyName.Name = "rabPartyName";
            rabPartyName.Size = new Size(169, 21);
            rabPartyName.TabIndex = 4;
            rabPartyName.TabStop = true;
            rabPartyName.Tag = "Party Name";
            rabPartyName.Text = "Party Name";
            rabPartyName.UseVisualStyleBackColor = true;
            rabPartyName.Click += RadioButton_Checked;
            // 
            // rabSubordinateCourt
            // 
            rabSubordinateCourt.AutoSize = true;
            rabSubordinateCourt.Dock = DockStyle.Fill;
            rabSubordinateCourt.Enabled = false;
            rabSubordinateCourt.Location = new Point(1068, 6);
            rabSubordinateCourt.Name = "rabSubordinateCourt";
            rabSubordinateCourt.Size = new Size(270, 21);
            rabSubordinateCourt.TabIndex = 5;
            rabSubordinateCourt.TabStop = true;
            rabSubordinateCourt.Tag = "Subordinate Court";
            rabSubordinateCourt.Text = "Subordinate Court";
            rabSubordinateCourt.UseVisualStyleBackColor = true;
            rabSubordinateCourt.Click += RadioButton_Checked;
            // 
            // lblSearch1
            // 
            lblSearch1.AutoSize = true;
            lblSearch1.Dock = DockStyle.Fill;
            lblSearch1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSearch1.Location = new Point(6, 57);
            lblSearch1.Name = "lblSearch1";
            lblSearch1.Size = new Size(141, 27);
            lblSearch1.TabIndex = 6;
            lblSearch1.Tag = "Search 1";
            lblSearch1.Text = "Search 1";
            // 
            // txtSearch1
            // 
            txtSearch1.BackColor = Color.LightYellow;
            txtSearch1.Dock = DockStyle.Fill;
            txtSearch1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSearch1.Location = new Point(153, 60);
            txtSearch1.Name = "txtSearch1";
            txtSearch1.Size = new Size(213, 26);
            txtSearch1.TabIndex = 7;
            txtSearch1.Validating += txtSearch1_Validating;
            // 
            // lblSearch2
            // 
            lblSearch2.AutoSize = true;
            lblSearch2.Dock = DockStyle.Fill;
            lblSearch2.Enabled = false;
            lblSearch2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSearch2.Location = new Point(372, 57);
            lblSearch2.Name = "lblSearch2";
            lblSearch2.Size = new Size(238, 27);
            lblSearch2.TabIndex = 8;
            lblSearch2.Tag = "Respondent Name";
            lblSearch2.Text = "Respondent Name";
            // 
            // txtSearch2
            // 
            txtSearch2.BackColor = Color.LightYellow;
            txtSearch2.Dock = DockStyle.Fill;
            txtSearch2.Enabled = false;
            txtSearch2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSearch2.Location = new Point(616, 60);
            txtSearch2.Name = "txtSearch2";
            txtSearch2.Size = new Size(271, 26);
            txtSearch2.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.MediumSeaGreen;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(616, 116);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(271, 28);
            btnSearch.TabIndex = 10;
            btnSearch.Tag = "Search";
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // rabCaseNo
            // 
            rabCaseNo.AutoSize = true;
            rabCaseNo.Dock = DockStyle.Fill;
            rabCaseNo.Location = new Point(372, 6);
            rabCaseNo.Name = "rabCaseNo";
            rabCaseNo.Size = new Size(238, 21);
            rabCaseNo.TabIndex = 11;
            rabCaseNo.TabStop = true;
            rabCaseNo.Tag = "Case No.";
            rabCaseNo.Text = "Case No.";
            rabCaseNo.UseVisualStyleBackColor = true;
            rabCaseNo.Click += RadioButton_Checked;
            // 
            // cobPoliceStation
            // 
            cobPoliceStation.BackColor = Color.LightYellow;
            cobPoliceStation.Dock = DockStyle.Fill;
            cobPoliceStation.Enabled = false;
            cobPoliceStation.FormattingEnabled = true;
            cobPoliceStation.Location = new Point(1068, 33);
            cobPoliceStation.Name = "cobPoliceStation";
            cobPoliceStation.Size = new Size(270, 27);
            cobPoliceStation.TabIndex = 13;
            cobPoliceStation.SelectedIndexChanged += cobPoliceStation_SelectedIndexChanged;
            // 
            // typCaseYear
            // 
            typCaseYear.ColumnCount = 2;
            typCaseYear.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            typCaseYear.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            typCaseYear.Controls.Add(cobCaseYear, 0, 0);
            typCaseYear.Controls.Add(txtYear, 1, 0);
            typCaseYear.Dock = DockStyle.Fill;
            typCaseYear.Enabled = false;
            typCaseYear.Location = new Point(616, 33);
            typCaseYear.Name = "typCaseYear";
            typCaseYear.RowCount = 1;
            typCaseYear.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            typCaseYear.Size = new Size(271, 21);
            typCaseYear.TabIndex = 12;
            // 
            // cobCaseYear
            // 
            cobCaseYear.BackColor = Color.LightYellow;
            cobCaseYear.Dock = DockStyle.Fill;
            cobCaseYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cobCaseYear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cobCaseYear.FormattingEnabled = true;
            cobCaseYear.Items.AddRange(new object[] { "19", "20" });
            cobCaseYear.Location = new Point(3, 3);
            cobCaseYear.Name = "cobCaseYear";
            cobCaseYear.Size = new Size(129, 27);
            cobCaseYear.TabIndex = 5;
            cobCaseYear.SelectedIndexChanged += cobCaseYear_SelectedIndexChanged;
            // 
            // txtYear
            // 
            txtYear.BackColor = Color.LightYellow;
            txtYear.Dock = DockStyle.Fill;
            txtYear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtYear.Location = new Point(138, 3);
            txtYear.Mask = "##";
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(130, 26);
            txtYear.TabIndex = 6;
            txtYear.Enter += MaskTextBox_Enter;
            txtYear.Leave += MaskTextBox_Leave;
            txtYear.Validating += txtYear_Validating;
            // 
            // lblCaseYear
            // 
            lblCaseYear.AutoSize = true;
            lblCaseYear.Dock = DockStyle.Fill;
            lblCaseYear.Enabled = false;
            lblCaseYear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblCaseYear.Location = new Point(372, 30);
            lblCaseYear.Name = "lblCaseYear";
            lblCaseYear.Size = new Size(238, 27);
            lblCaseYear.TabIndex = 4;
            lblCaseYear.Tag = "Case Year";
            lblCaseYear.Text = "Case Year";
            lblCaseYear.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPoliceStation
            // 
            lblPoliceStation.AutoSize = true;
            lblPoliceStation.Dock = DockStyle.Fill;
            lblPoliceStation.Enabled = false;
            lblPoliceStation.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblPoliceStation.Location = new Point(893, 30);
            lblPoliceStation.Name = "lblPoliceStation";
            lblPoliceStation.Size = new Size(169, 27);
            lblPoliceStation.TabIndex = 14;
            lblPoliceStation.Tag = "Police Station";
            lblPoliceStation.Text = "Police Station";
            // 
            // lblCaseType
            // 
            lblCaseType.AutoSize = true;
            lblCaseType.Dock = DockStyle.Fill;
            lblCaseType.Enabled = false;
            lblCaseType.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblCaseType.Location = new Point(6, 30);
            lblCaseType.Name = "lblCaseType";
            lblCaseType.Size = new Size(141, 27);
            lblCaseType.TabIndex = 2;
            lblCaseType.Tag = "Case Type";
            lblCaseType.Text = "Case Type";
            lblCaseType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cobCaseType
            // 
            cobCaseType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cobCaseType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cobCaseType.BackColor = Color.LightYellow;
            cobCaseType.Dock = DockStyle.Fill;
            cobCaseType.Enabled = false;
            cobCaseType.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cobCaseType.FormattingEnabled = true;
            cobCaseType.Location = new Point(153, 33);
            cobCaseType.Name = "cobCaseType";
            cobCaseType.Size = new Size(213, 27);
            cobCaseType.TabIndex = 3;
            cobCaseType.SelectedIndexChanged += cobCaseType_SelectedIndexChanged;
            cobCaseType.Enter += ComboBox_Enter;
            cobCaseType.Leave += ComboBox_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(6, 84);
            label3.Name = "label3";
            label3.Size = new Size(141, 29);
            label3.TabIndex = 9;
            label3.Tag = "Court Name";
            label3.Text = "Court Name";
            label3.Visible = false;
            // 
            // cobCourtNameSearch
            // 
            cobCourtNameSearch.BackColor = Color.LightYellow;
            cobCourtNameSearch.Dock = DockStyle.Fill;
            cobCourtNameSearch.FormattingEnabled = true;
            cobCourtNameSearch.Location = new Point(153, 87);
            cobCourtNameSearch.Name = "cobCourtNameSearch";
            cobCourtNameSearch.Size = new Size(213, 27);
            cobCourtNameSearch.TabIndex = 10;
            cobCourtNameSearch.Visible = false;
            cobCourtNameSearch.SelectedIndexChanged += cobCourtName_SelectedIndexChanged;
            cobCourtNameSearch.Enter += ComboBox_Enter;
            cobCourtNameSearch.Leave += ComboBox_Leave;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 6;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.8557529F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.36953F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.5316048F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7747154F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpMain.Controls.Add(txtBarcode, 1, 0);
            tlpMain.Controls.Add(label11, 0, 0);
            tlpMain.Controls.Add(label13, 0, 2);
            tlpMain.Controls.Add(label14, 3, 2);
            tlpMain.Controls.Add(txtCollectedFrom, 4, 2);
            tlpMain.Controls.Add(label18, 0, 3);
            tlpMain.Controls.Add(dtCollectedDate, 1, 3);
            tlpMain.Controls.Add(txtNoOfPages, 4, 3);
            tlpMain.Controls.Add(label15, 3, 3);
            tlpMain.Controls.Add(label4, 0, 4);
            tlpMain.Controls.Add(txtPetitionerName, 1, 4);
            tlpMain.Controls.Add(txtRespondentName, 4, 4);
            tlpMain.Controls.Add(label5, 3, 4);
            tlpMain.Controls.Add(label6, 0, 5);
            tlpMain.Controls.Add(txtAdvocate, 1, 5);
            tlpMain.Controls.Add(label7, 3, 5);
            tlpMain.Controls.Add(label8, 0, 6);
            tlpMain.Controls.Add(label9, 3, 6);
            tlpMain.Controls.Add(cobNatureOfDisposal, 4, 6);
            tlpMain.Controls.Add(label10, 0, 7);
            tlpMain.Controls.Add(txtAct, 1, 7);
            tlpMain.Controls.Add(label12, 3, 7);
            tlpMain.Controls.Add(txtSection, 4, 7);
            tlpMain.Controls.Add(label16, 0, 9);
            tlpMain.Controls.Add(txtReceivedBy, 1, 9);
            tlpMain.Controls.Add(label17, 3, 9);
            tlpMain.Controls.Add(dtReceivedDate, 4, 9);
            tlpMain.Controls.Add(cobCourtName, 1, 2);
            tlpMain.Controls.Add(label19, 0, 10);
            tlpMain.Controls.Add(cobDistrict, 1, 10);
            tlpMain.Controls.Add(label2, 0, 1);
            tlpMain.Controls.Add(txtCaseNo, 1, 1);
            tlpMain.Controls.Add(label1, 3, 1);
            tlpMain.Controls.Add(txtCINo, 4, 1);
            tlpMain.Controls.Add(txtDateOfDecision, 1, 6);
            tlpMain.Controls.Add(txtDateOfRegistration, 4, 5);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Margin = new Padding(5);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(5);
            tlpMain.RowCount = 11;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090908F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMain.Size = new Size(1370, 474);
            tlpMain.TabIndex = 0;
            // 
            // txtBarcode
            // 
            tlpMain.SetColumnSpan(txtBarcode, 2);
            txtBarcode.Dock = DockStyle.Fill;
            txtBarcode.Location = new Point(237, 8);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(442, 26);
            txtBarcode.TabIndex = 1;
            txtBarcode.Enter += TextBox_Enter;
            txtBarcode.Leave += TextBox_Leave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(8, 5);
            label11.Name = "label11";
            label11.Size = new Size(223, 42);
            label11.TabIndex = 0;
            label11.Tag = "Barcode";
            label11.Text = "Barcode";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(8, 89);
            label13.Name = "label13";
            label13.Size = new Size(90, 19);
            label13.TabIndex = 9;
            label13.Tag = "Court Name";
            label13.Text = "Court Name*";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(685, 89);
            label14.Name = "label14";
            label14.Size = new Size(219, 42);
            label14.TabIndex = 11;
            label14.Tag = "Collected Form";
            label14.Text = "Collected Form*";
            // 
            // txtCollectedFrom
            // 
            tlpMain.SetColumnSpan(txtCollectedFrom, 2);
            txtCollectedFrom.Dock = DockStyle.Fill;
            txtCollectedFrom.Location = new Point(910, 92);
            txtCollectedFrom.Name = "txtCollectedFrom";
            txtCollectedFrom.Size = new Size(452, 26);
            txtCollectedFrom.TabIndex = 0;
            txtCollectedFrom.Enter += TextBox_Enter;
            txtCollectedFrom.Leave += TextBox_Leave;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Dock = DockStyle.Fill;
            label18.Location = new Point(8, 131);
            label18.Name = "label18";
            label18.Size = new Size(223, 42);
            label18.TabIndex = 13;
            label18.Tag = "Collected Date";
            label18.Text = "Collected Date";
            // 
            // dtCollectedDate
            // 
            tlpMain.SetColumnSpan(dtCollectedDate, 2);
            dtCollectedDate.CustomFormat = "dd-MM-yyyy";
            dtCollectedDate.Dock = DockStyle.Fill;
            dtCollectedDate.Format = DateTimePickerFormat.Custom;
            dtCollectedDate.Location = new Point(237, 134);
            dtCollectedDate.Name = "dtCollectedDate";
            dtCollectedDate.Size = new Size(442, 26);
            dtCollectedDate.TabIndex = 13;
            dtCollectedDate.Enter += TextBox_Enter;
            dtCollectedDate.Leave += DateTimePicker_Leave;
            // 
            // txtNoOfPages
            // 
            tlpMain.SetColumnSpan(txtNoOfPages, 2);
            txtNoOfPages.Dock = DockStyle.Fill;
            txtNoOfPages.Location = new Point(910, 134);
            txtNoOfPages.Name = "txtNoOfPages";
            txtNoOfPages.Size = new Size(452, 26);
            txtNoOfPages.TabIndex = 16;
            txtNoOfPages.Enter += TextBox_Enter;
            txtNoOfPages.Leave += TextBox_Leave;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Dock = DockStyle.Fill;
            label15.Location = new Point(685, 131);
            label15.Name = "label15";
            label15.Size = new Size(219, 42);
            label15.TabIndex = 15;
            label15.Tag = "No. Of Pages";
            label15.Text = "No. Of Pages*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(8, 173);
            label4.Name = "label4";
            label4.Size = new Size(223, 42);
            label4.TabIndex = 17;
            label4.Tag = "Petitioner Name";
            label4.Text = "Petitioner Name*";
            // 
            // txtPetitionerName
            // 
            tlpMain.SetColumnSpan(txtPetitionerName, 2);
            txtPetitionerName.Dock = DockStyle.Fill;
            txtPetitionerName.Location = new Point(237, 176);
            txtPetitionerName.Name = "txtPetitionerName";
            txtPetitionerName.Size = new Size(442, 26);
            txtPetitionerName.TabIndex = 18;
            txtPetitionerName.Enter += TextBox_Enter;
            txtPetitionerName.Leave += TextBox_Leave;
            // 
            // txtRespondentName
            // 
            tlpMain.SetColumnSpan(txtRespondentName, 2);
            txtRespondentName.Dock = DockStyle.Fill;
            txtRespondentName.Location = new Point(910, 176);
            txtRespondentName.Name = "txtRespondentName";
            txtRespondentName.Size = new Size(452, 26);
            txtRespondentName.TabIndex = 20;
            txtRespondentName.Enter += TextBox_Enter;
            txtRespondentName.Leave += TextBox_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(685, 173);
            label5.Name = "label5";
            label5.Size = new Size(219, 42);
            label5.TabIndex = 19;
            label5.Tag = "Respondent Name";
            label5.Text = "Respondent Name*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(8, 215);
            label6.Name = "label6";
            label6.Size = new Size(223, 42);
            label6.TabIndex = 21;
            label6.Tag = "Advocate";
            label6.Text = "Advocate";
            // 
            // txtAdvocate
            // 
            tlpMain.SetColumnSpan(txtAdvocate, 2);
            txtAdvocate.Dock = DockStyle.Fill;
            txtAdvocate.Location = new Point(237, 218);
            txtAdvocate.Name = "txtAdvocate";
            txtAdvocate.Size = new Size(442, 26);
            txtAdvocate.TabIndex = 22;
            txtAdvocate.Enter += TextBox_Enter;
            txtAdvocate.Leave += TextBox_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(685, 215);
            label7.Name = "label7";
            label7.Size = new Size(219, 42);
            label7.TabIndex = 23;
            label7.Tag = "Date of Registration";
            label7.Text = "Date of Registration*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(8, 257);
            label8.Name = "label8";
            label8.Size = new Size(223, 42);
            label8.TabIndex = 25;
            label8.Tag = "Date of Decision";
            label8.Text = "Date of Decision*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(685, 257);
            label9.Name = "label9";
            label9.Size = new Size(219, 42);
            label9.TabIndex = 27;
            label9.Tag = "Nature of Disposal";
            label9.Text = "Nature of Disposal*";
            // 
            // cobNatureOfDisposal
            // 
            tlpMain.SetColumnSpan(cobNatureOfDisposal, 2);
            cobNatureOfDisposal.Dock = DockStyle.Fill;
            cobNatureOfDisposal.FormattingEnabled = true;
            cobNatureOfDisposal.Location = new Point(910, 260);
            cobNatureOfDisposal.Name = "cobNatureOfDisposal";
            cobNatureOfDisposal.Size = new Size(452, 27);
            cobNatureOfDisposal.TabIndex = 28;
            cobNatureOfDisposal.SelectedIndexChanged += cobNatureOfDisposal_SelectedIndexChanged;
            cobNatureOfDisposal.Enter += ComboBox_Enter;
            cobNatureOfDisposal.Leave += ComboBox_Leave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(8, 299);
            label10.Name = "label10";
            tlpMain.SetRowSpan(label10, 2);
            label10.Size = new Size(223, 84);
            label10.TabIndex = 29;
            label10.Tag = "Act";
            label10.Text = "Act";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAct
            // 
            tlpMain.SetColumnSpan(txtAct, 2);
            txtAct.Dock = DockStyle.Fill;
            txtAct.Location = new Point(237, 302);
            txtAct.Multiline = true;
            txtAct.Name = "txtAct";
            tlpMain.SetRowSpan(txtAct, 2);
            txtAct.Size = new Size(442, 78);
            txtAct.TabIndex = 30;
            txtAct.Enter += TextBox_Enter;
            txtAct.Leave += TextBox_Leave;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(685, 299);
            label12.Name = "label12";
            tlpMain.SetRowSpan(label12, 2);
            label12.Size = new Size(219, 84);
            label12.TabIndex = 31;
            label12.Tag = "Section";
            label12.Text = "Section";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSection
            // 
            tlpMain.SetColumnSpan(txtSection, 2);
            txtSection.Dock = DockStyle.Fill;
            txtSection.Location = new Point(910, 302);
            txtSection.Multiline = true;
            txtSection.Name = "txtSection";
            tlpMain.SetRowSpan(txtSection, 2);
            txtSection.Size = new Size(452, 78);
            txtSection.TabIndex = 32;
            txtSection.Enter += TextBox_Enter;
            txtSection.Leave += TextBox_Leave;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Dock = DockStyle.Fill;
            label16.Location = new Point(8, 383);
            label16.Name = "label16";
            label16.Size = new Size(223, 42);
            label16.TabIndex = 33;
            label16.Tag = "Received By";
            label16.Text = "Received By*";
            // 
            // txtReceivedBy
            // 
            tlpMain.SetColumnSpan(txtReceivedBy, 2);
            txtReceivedBy.Dock = DockStyle.Fill;
            txtReceivedBy.Enabled = false;
            txtReceivedBy.Location = new Point(237, 386);
            txtReceivedBy.Name = "txtReceivedBy";
            txtReceivedBy.Size = new Size(442, 26);
            txtReceivedBy.TabIndex = 34;
            txtReceivedBy.Enter += TextBox_Enter;
            txtReceivedBy.Leave += TextBox_Leave;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Dock = DockStyle.Fill;
            label17.Location = new Point(685, 383);
            label17.Name = "label17";
            label17.Size = new Size(219, 42);
            label17.TabIndex = 35;
            label17.Tag = "Received Date";
            label17.Text = "Received Date*";
            // 
            // dtReceivedDate
            // 
            tlpMain.SetColumnSpan(dtReceivedDate, 2);
            dtReceivedDate.CustomFormat = "dd-MM-yyyy";
            dtReceivedDate.Dock = DockStyle.Fill;
            dtReceivedDate.Enabled = false;
            dtReceivedDate.Format = DateTimePickerFormat.Custom;
            dtReceivedDate.Location = new Point(910, 386);
            dtReceivedDate.Name = "dtReceivedDate";
            dtReceivedDate.Size = new Size(452, 26);
            dtReceivedDate.TabIndex = 36;
            dtReceivedDate.Enter += TextBox_Enter;
            dtReceivedDate.Leave += DateTimePicker_Leave;
            // 
            // cobCourtName
            // 
            tlpMain.SetColumnSpan(cobCourtName, 2);
            cobCourtName.Dock = DockStyle.Fill;
            cobCourtName.FormattingEnabled = true;
            cobCourtName.Location = new Point(237, 92);
            cobCourtName.Name = "cobCourtName";
            cobCourtName.Size = new Size(442, 27);
            cobCourtName.TabIndex = 10;
            cobCourtName.SelectedIndexChanged += cobCourtName_SelectedIndexChanged;
            cobCourtName.Enter += ComboBox_Enter;
            cobCourtName.Leave += ComboBox_Leave;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Dock = DockStyle.Fill;
            label19.Location = new Point(8, 425);
            label19.Name = "label19";
            label19.Size = new Size(223, 44);
            label19.TabIndex = 37;
            label19.Tag = "District";
            label19.Text = "District*";
            // 
            // cobDistrict
            // 
            tlpMain.SetColumnSpan(cobDistrict, 2);
            cobDistrict.Dock = DockStyle.Fill;
            cobDistrict.FormattingEnabled = true;
            cobDistrict.Location = new Point(237, 428);
            cobDistrict.Name = "cobDistrict";
            cobDistrict.Size = new Size(442, 27);
            cobDistrict.TabIndex = 10;
            cobDistrict.SelectedIndexChanged += cobDistrict_SelectedIndexChanged;
            cobDistrict.Enter += ComboBox_Enter;
            cobDistrict.Leave += ComboBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(8, 47);
            label2.Name = "label2";
            label2.Size = new Size(223, 42);
            label2.TabIndex = 39;
            label2.Tag = "Case No.";
            label2.Text = "Case No.*";
            // 
            // txtCaseNo
            // 
            tlpMain.SetColumnSpan(txtCaseNo, 2);
            txtCaseNo.Dock = DockStyle.Fill;
            txtCaseNo.Location = new Point(237, 50);
            txtCaseNo.Name = "txtCaseNo";
            txtCaseNo.Size = new Size(442, 26);
            txtCaseNo.TabIndex = 38;
            txtCaseNo.Enter += TextBox_Enter;
            txtCaseNo.Leave += TextBox_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(685, 47);
            label1.Name = "label1";
            label1.Size = new Size(219, 42);
            label1.TabIndex = 40;
            label1.Tag = "CIN No.";
            label1.Text = "CIN No.";
            // 
            // txtCINo
            // 
            tlpMain.SetColumnSpan(txtCINo, 2);
            txtCINo.Dock = DockStyle.Fill;
            txtCINo.Location = new Point(910, 50);
            txtCINo.Name = "txtCINo";
            txtCINo.Size = new Size(452, 26);
            txtCINo.TabIndex = 41;
            txtCINo.Enter += TextBox_Enter;
            txtCINo.Leave += TextBox_Leave;
            // 
            // txtDateOfDecision
            // 
            tlpMain.SetColumnSpan(txtDateOfDecision, 2);
            txtDateOfDecision.Dock = DockStyle.Fill;
            txtDateOfDecision.Location = new Point(237, 260);
            txtDateOfDecision.Mask = "##/##/####";
            txtDateOfDecision.Name = "txtDateOfDecision";
            txtDateOfDecision.Size = new Size(442, 26);
            txtDateOfDecision.TabIndex = 42;
            // 
            // txtDateOfRegistration
            // 
            tlpMain.SetColumnSpan(txtDateOfRegistration, 2);
            txtDateOfRegistration.Dock = DockStyle.Fill;
            txtDateOfRegistration.Location = new Point(910, 218);
            txtDateOfRegistration.Mask = "##/##/####";
            txtDateOfRegistration.Name = "txtDateOfRegistration";
            txtDateOfRegistration.Size = new Size(452, 26);
            txtDateOfRegistration.TabIndex = 43;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnClose);
            flpButtons.Controls.Add(btnSave);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(0, 0);
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(5);
            flpButtons.Size = new Size(1370, 71);
            flpButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1263, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 35);
            btnClose.TabIndex = 1;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1163, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 35);
            btnSave.TabIndex = 0;
            btnSave.Tag = "Save";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // frmFileReceive
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1370, 749);
            Controls.Add(spcMain);
            Font = new Font("Segoe UI", 10.2F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFileReceive";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Receive";
            Load += frmFileReceive_Load;
            spcMain.Panel1.ResumeLayout(false);
            spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcMain).EndInit();
            spcMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            typCaseYear.ResumeLayout(false);
            typCaseYear.PerformLayout();
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer spcMain;
        private Label lblCaseType;
        private Label lblCaseYear;
        private FlowLayoutPanel flpButtons;
        private ComboBox cobCaseYear;
        private ComboBox cobCaseType;
        private MaskedTextBox txtYear;
        private Button btnClose;
        private Button btnSave;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private RadioButton rabCNRNo;
        private RadioButton rabFillingNo;
        private RadioButton rabFIRNo;
        private RadioButton rabPartyName;
        private RadioButton rabSubordinateCourt;
        private Label lblSearch1;
        private TextBox txtSearch1;
        private Label lblSearch2;
        private TextBox txtSearch2;
        private Button btnSearch;
        private RadioButton rabCaseNo;
        private TableLayoutPanel typCaseYear;
        private TableLayoutPanel tlpMain;
        private TextBox txtBarcode;
        private Label label11;
        private Label label13;
        private Label label14;
        private TextBox txtCollectedFrom;
        private Label label18;
        private DateTimePicker dtCollectedDate;
        private TextBox txtNoOfPages;
        private Label label15;
        private Label label4;
        private TextBox txtPetitionerName;
        private TextBox txtRespondentName;
        private Label label5;
        private Label label6;
        private TextBox txtAdvocate;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cobNatureOfDisposal;
        private Label label10;
        private TextBox txtAct;
        private Label label12;
        private TextBox txtSection;
        private Label label16;
        private TextBox txtReceivedBy;
        private Label label17;
        private DateTimePicker dtReceivedDate;
        private ComboBox cobCourtName;
        private Label label19;
        private ComboBox cobDistrict;
        private TextBox txtCaseNo;
        private Label label2;
        private Label label1;
        private TextBox txtCINo;
        private ComboBox cobPoliceStation;
        private Label lblPoliceStation;
        private MaskedTextBox txtDateOfDecision;
        private MaskedTextBox txtDateOfRegistration;
        private Label label3;
        private ComboBox cobCourtNameSearch;
    }
}