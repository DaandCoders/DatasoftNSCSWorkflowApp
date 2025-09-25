using UKA.Windows.Forms;

namespace DMS.DesktopApp.Shared
{
    partial class frmImageSingleDeleteQC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageSingleDeleteQC));
            lblStatus = new ToolStripStatusLabel();
            splitContainerMain = new SplitContainer();
            splitContainerLeft3 = new SplitContainer();
            tlpBatchSelection = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            cobCaseDirectory = new ComboBox();
            cobSubDicrectoy = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnFirst = new ToolStripButton();
            btnPrevious = new ToolStripButton();
            btnNext = new ToolStripButton();
            btnLast = new ToolStripButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnClose = new Button();
            btnDeleteRecord = new Button();
            btnFileComplete = new Button();
            btnBatchComplete = new Button();
            btnSave = new Button();
            btnInsert = new Button();
            btnRemarks = new Button();
            lstImages = new CheckedListBox();
            contextMenuStrip = new ContextMenuStrip(components);
            menReorderList = new ToolStripMenuItem();
            menMoveFile = new ToolStripMenuItem();
            menDeleted = new ToolStripMenuItem();
            menDeleteSelected = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            imgBox = new ImageBox();
            toolStrip2 = new ToolStrip();
            btnArrow = new ToolStripButton();
            btnRectangle = new ToolStripButton();
            btnErase = new ToolStripButton();
            btnImageCleanWithSelection = new ToolStripButton();
            btnTextEnhencement = new ToolStripButton();
            btnAddMark = new ToolStripButton();
            tspFrontImage = new ToolStrip();
            btnFrontZoomIn = new ToolStripButton();
            btnFrontZommOut = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnFrontRotateLeft = new ToolStripButton();
            btnFrontRotateRight = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            btnFrontZoomToFit = new ToolStripButton();
            btnFrontActualSize = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            btnFronDeskew = new ToolStripButton();
            btnFrontCrop = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            btnFrontRefresh = new ToolStripButton();
            btnFrontSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            txtGoto = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            btnGoto = new ToolStripButton();
            cobZoomLevel = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            chkImagesRaw = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnSetting = new ToolStripButton();
            statusStripBottom = new StatusStrip();
            lblImagePosition = new ToolStripStatusLabel();
            Seprator2 = new ToolStripStatusLabel();
            tssCoordinates = new ToolStripStatusLabel();
            lblImageCoordinates = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            lblImagePath = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            lblCurrentUserName = new ToolStripStatusLabel();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft3).BeginInit();
            splitContainerLeft3.Panel1.SuspendLayout();
            splitContainerLeft3.Panel2.SuspendLayout();
            splitContainerLeft3.SuspendLayout();
            tlpBatchSelection.SuspendLayout();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            toolStrip2.SuspendLayout();
            tspFrontImage.SuspendLayout();
            statusStripBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = SystemColors.ControlDark;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 24);
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.FixedPanel = FixedPanel.Panel1;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Margin = new Padding(0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(splitContainerLeft3);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(toolStripContainer1);
            splitContainerMain.Panel2.Controls.Add(tspFrontImage);
            splitContainerMain.Size = new Size(1277, 719);
            splitContainerMain.SplitterDistance = 296;
            splitContainerMain.SplitterWidth = 7;
            splitContainerMain.TabIndex = 5;
            splitContainerMain.SplitterMoved += splitContainerMain_SplitterMoved;
            // 
            // splitContainerLeft3
            // 
            splitContainerLeft3.Dock = DockStyle.Fill;
            splitContainerLeft3.Location = new Point(0, 0);
            splitContainerLeft3.Margin = new Padding(3, 4, 3, 4);
            splitContainerLeft3.Name = "splitContainerLeft3";
            splitContainerLeft3.Orientation = Orientation.Horizontal;
            // 
            // splitContainerLeft3.Panel1
            // 
            splitContainerLeft3.Panel1.Controls.Add(tlpBatchSelection);
            splitContainerLeft3.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainerLeft3.Panel2
            // 
            splitContainerLeft3.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainerLeft3.Size = new Size(296, 719);
            splitContainerLeft3.SplitterDistance = 171;
            splitContainerLeft3.SplitterWidth = 5;
            splitContainerLeft3.TabIndex = 2;
            // 
            // tlpBatchSelection
            // 
            tlpBatchSelection.ColumnCount = 2;
            tlpBatchSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBatchSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBatchSelection.Controls.Add(label1, 0, 0);
            tlpBatchSelection.Controls.Add(label2, 0, 2);
            tlpBatchSelection.Controls.Add(cobCaseDirectory, 0, 1);
            tlpBatchSelection.Controls.Add(cobSubDicrectoy, 0, 3);
            tlpBatchSelection.Dock = DockStyle.Fill;
            tlpBatchSelection.Location = new Point(0, 31);
            tlpBatchSelection.Margin = new Padding(5, 5, 5, 5);
            tlpBatchSelection.Name = "tlpBatchSelection";
            tlpBatchSelection.Padding = new Padding(1, 3, 1, 3);
            tlpBatchSelection.RowCount = 4;
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 28.333334F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 22.5F));
            tlpBatchSelection.RowStyles.Add(new RowStyle(SizeType.Percent, 25.833334F));
            tlpBatchSelection.Size = new Size(296, 140);
            tlpBatchSelection.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tlpBatchSelection.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(4, 3);
            label1.Name = "label1";
            label1.Size = new Size(288, 32);
            label1.TabIndex = 9;
            label1.Tag = "Case Directory";
            label1.Text = "Case Directory";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tlpBatchSelection.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(4, 72);
            label2.Name = "label2";
            label2.Size = new Size(288, 29);
            label2.TabIndex = 9;
            label2.Tag = "Case File";
            label2.Text = "Case File";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cobCaseDirectory
            // 
            tlpBatchSelection.SetColumnSpan(cobCaseDirectory, 2);
            cobCaseDirectory.Dock = DockStyle.Fill;
            cobCaseDirectory.FormattingEnabled = true;
            cobCaseDirectory.Location = new Point(4, 38);
            cobCaseDirectory.Name = "cobCaseDirectory";
            cobCaseDirectory.Size = new Size(288, 28);
            cobCaseDirectory.TabIndex = 10;
            cobCaseDirectory.SelectedIndexChanged += cobCaseDirectory_SelectedIndexChanged;
            // 
            // cobSubDicrectoy
            // 
            tlpBatchSelection.SetColumnSpan(cobSubDicrectoy, 2);
            cobSubDicrectoy.Dock = DockStyle.Fill;
            cobSubDicrectoy.FormattingEnabled = true;
            cobSubDicrectoy.Location = new Point(4, 104);
            cobSubDicrectoy.Name = "cobSubDicrectoy";
            cobSubDicrectoy.Size = new Size(288, 28);
            cobSubDicrectoy.TabIndex = 11;
            cobSubDicrectoy.SelectedIndexChanged += cobSubDicrectoy_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnFirst, btnPrevious, btnNext, btnLast });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(296, 31);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnFirst
            // 
            btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFirst.Image = Properties.Resources.First;
            btnFirst.ImageTransparentColor = Color.Magenta;
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(29, 28);
            btnFirst.Text = "First (Key Left)";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrevious.Image = Properties.Resources.Previous;
            btnPrevious.ImageTransparentColor = Color.Magenta;
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(29, 28);
            btnPrevious.Text = "Previous (Key Previous)";
            btnPrevious.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = Properties.Resources.Next;
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(29, 28);
            btnNext.Text = "Next (Key Down)";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = Properties.Resources.Last;
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(29, 28);
            btnLast.Text = "Last (Key Right)";
            btnLast.Click += btnLast_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tableLayoutPanel1.Controls.Add(btnClose, 2, 3);
            tableLayoutPanel1.Controls.Add(btnDeleteRecord, 1, 3);
            tableLayoutPanel1.Controls.Add(btnFileComplete, 1, 2);
            tableLayoutPanel1.Controls.Add(btnBatchComplete, 2, 2);
            tableLayoutPanel1.Controls.Add(btnSave, 0, 2);
            tableLayoutPanel1.Controls.Add(btnInsert, 0, 3);
            tableLayoutPanel1.Controls.Add(btnRemarks, 0, 1);
            tableLayoutPanel1.Controls.Add(lstImages, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75.92593F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.9341564F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1399174F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(296, 543);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Fill;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(199, 484);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 56);
            btnClose.TabIndex = 11;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnDeleteRecord
            // 
            btnDeleteRecord.BackColor = Color.IndianRed;
            btnDeleteRecord.Cursor = Cursors.Hand;
            btnDeleteRecord.Dock = DockStyle.Fill;
            btnDeleteRecord.FlatStyle = FlatStyle.Popup;
            btnDeleteRecord.ForeColor = Color.White;
            btnDeleteRecord.Location = new Point(101, 484);
            btnDeleteRecord.Name = "btnDeleteRecord";
            btnDeleteRecord.Size = new Size(92, 56);
            btnDeleteRecord.TabIndex = 7;
            btnDeleteRecord.Tag = "Delete";
            btnDeleteRecord.Text = "Delete";
            btnDeleteRecord.UseVisualStyleBackColor = false;
            btnDeleteRecord.Click += btnDelete_ClickAsync;
            // 
            // btnFileComplete
            // 
            btnFileComplete.Cursor = Cursors.Hand;
            btnFileComplete.Dock = DockStyle.Fill;
            btnFileComplete.FlatStyle = FlatStyle.Popup;
            btnFileComplete.Location = new Point(100, 426);
            btnFileComplete.Margin = new Padding(2, 3, 2, 3);
            btnFileComplete.Name = "btnFileComplete";
            btnFileComplete.Size = new Size(94, 52);
            btnFileComplete.TabIndex = 12;
            btnFileComplete.Tag = "File Complete";
            btnFileComplete.Text = "File Complete";
            btnFileComplete.UseVisualStyleBackColor = true;
            btnFileComplete.Click += btnFileComplete_Click;
            // 
            // btnBatchComplete
            // 
            btnBatchComplete.Cursor = Cursors.Hand;
            btnBatchComplete.Dock = DockStyle.Fill;
            btnBatchComplete.FlatStyle = FlatStyle.Popup;
            btnBatchComplete.Location = new Point(198, 426);
            btnBatchComplete.Margin = new Padding(2, 3, 2, 3);
            btnBatchComplete.Name = "btnBatchComplete";
            btnBatchComplete.Size = new Size(96, 52);
            btnBatchComplete.TabIndex = 12;
            btnBatchComplete.Tag = "Batch Complete";
            btnBatchComplete.Text = "Batch Complete";
            btnBatchComplete.UseVisualStyleBackColor = true;
            btnBatchComplete.Click += btnBatchComplete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Dock = DockStyle.Fill;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(3, 426);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 52);
            btnSave.TabIndex = 10;
            btnSave.Tag = "Save";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.RoyalBlue;
            btnInsert.Cursor = Cursors.Hand;
            btnInsert.Dock = DockStyle.Fill;
            btnInsert.FlatStyle = FlatStyle.Popup;
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(3, 484);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(92, 56);
            btnInsert.TabIndex = 6;
            btnInsert.Tag = "Insert";
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_ClickAsync;
            // 
            // btnRemarks
            // 
            btnRemarks.Dock = DockStyle.Fill;
            btnRemarks.Location = new Point(3, 369);
            btnRemarks.Name = "btnRemarks";
            btnRemarks.Size = new Size(92, 51);
            btnRemarks.TabIndex = 13;
            btnRemarks.Tag = "Remarks";
            btnRemarks.Text = "Remarks";
            btnRemarks.UseVisualStyleBackColor = true;
            btnRemarks.Click += btnRemarks_Click;
            // 
            // lstImages
            // 
            tableLayoutPanel1.SetColumnSpan(lstImages, 3);
            lstImages.ContextMenuStrip = contextMenuStrip;
            lstImages.Dock = DockStyle.Fill;
            lstImages.FormattingEnabled = true;
            lstImages.Location = new Point(3, 3);
            lstImages.Name = "lstImages";
            lstImages.Size = new Size(290, 360);
            lstImages.TabIndex = 14;
            lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged;
            lstImages.KeyDown += lstImages_KeyDown;
            lstImages.MouseDown += lstImages_MouseDown;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { menReorderList, menMoveFile, menDeleted, menDeleteSelected });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(188, 108);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // menReorderList
            // 
            menReorderList.CheckOnClick = true;
            menReorderList.Image = Properties.Resources.checkboxUnchecked50x;
            menReorderList.Name = "menReorderList";
            menReorderList.Size = new Size(187, 26);
            menReorderList.Text = "Reorder List";
            menReorderList.Click += menReorderList_Click;
            // 
            // menMoveFile
            // 
            menMoveFile.Name = "menMoveFile";
            menMoveFile.Size = new Size(187, 26);
            menMoveFile.Text = "Move File";
            menMoveFile.Click += menMoveFile_Click;
            // 
            // menDeleted
            // 
            menDeleted.Name = "menDeleted";
            menDeleted.Size = new Size(187, 26);
            menDeleted.Text = "Delete";
            menDeleted.Click += menDeleted_Click;
            // 
            // menDeleteSelected
            // 
            menDeleteSelected.Enabled = false;
            menDeleteSelected.Name = "menDeleteSelected";
            menDeleteSelected.Size = new Size(187, 26);
            menDeleteSelected.Text = "Delete Selected";
            menDeleteSelected.Click += menDeleteSelected_Click;
            // 
            // toolStripContainer1
            // 
            toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(imgBox);
            toolStripContainer1.ContentPanel.Margin = new Padding(3, 4, 3, 4);
            toolStripContainer1.ContentPanel.Size = new Size(943, 688);
            toolStripContainer1.Dock = DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            toolStripContainer1.LeftToolStripPanel.Controls.Add(toolStrip2);
            toolStripContainer1.Location = new Point(0, 31);
            toolStripContainer1.Margin = new Padding(3, 4, 3, 4);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            toolStripContainer1.Size = new Size(974, 688);
            toolStripContainer1.TabIndex = 3;
            toolStripContainer1.Text = "toolStripContainer1";
            toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // imgBox
            // 
            imgBox.BackColor = Color.LightGray;
            imgBox.Dock = DockStyle.Fill;
            imgBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            imgBox.ForeColor = Color.Black;
            imgBox.GridDisplayMode = ImageBoxGridDisplayMode.None;
            imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            imgBox.Location = new Point(0, 0);
            imgBox.Margin = new Padding(5, 5, 5, 5);
            imgBox.Name = "imgBox";
            imgBox.SelectionMode = ImageBoxSelectionMode.Rectangle;
            imgBox.Size = new Size(943, 688);
            imgBox.SizeMode = ImageBoxSizeMode.Fit;
            imgBox.TabIndex = 0;
            imgBox.Text = "DCS Imaging";
            imgBox.TextAlign = ContentAlignment.BottomRight;
            imgBox.MouseUp += imgBoxFront_MouseUp;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.ImageScalingSize = new Size(26, 26);
            toolStrip2.Items.AddRange(new ToolStripItem[] { btnArrow, btnRectangle, btnErase, btnImageCleanWithSelection, btnTextEnhencement, btnAddMark });
            toolStrip2.Location = new Point(0, 4);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(31, 210);
            toolStrip2.TabIndex = 0;
            // 
            // btnArrow
            // 
            btnArrow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnArrow.Image = Properties.Resources.mouse_arrow;
            btnArrow.ImageTransparentColor = Color.Magenta;
            btnArrow.Name = "btnArrow";
            btnArrow.Size = new Size(29, 30);
            btnArrow.Text = "Default";
            // 
            // btnRectangle
            // 
            btnRectangle.CheckOnClick = true;
            btnRectangle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRectangle.Image = Properties.Resources.rectangle;
            btnRectangle.ImageTransparentColor = Color.Magenta;
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(29, 30);
            btnRectangle.Text = "toolStripButton2";
            btnRectangle.CheckedChanged += btnRectangle_CheckedChanged;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnErase
            // 
            btnErase.CheckOnClick = true;
            btnErase.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnErase.Image = Properties.Resources.Erase;
            btnErase.ImageTransparentColor = Color.Magenta;
            btnErase.Name = "btnErase";
            btnErase.Size = new Size(29, 30);
            btnErase.Text = "Eraser";
            btnErase.Click += btnErase_Click;
            // 
            // btnImageCleanWithSelection
            // 
            btnImageCleanWithSelection.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnImageCleanWithSelection.Image = (Image)resources.GetObject("btnImageCleanWithSelection.Image");
            btnImageCleanWithSelection.ImageTransparentColor = Color.Magenta;
            btnImageCleanWithSelection.Name = "btnImageCleanWithSelection";
            btnImageCleanWithSelection.Size = new Size(29, 30);
            btnImageCleanWithSelection.Text = "Image Clean ";
            btnImageCleanWithSelection.Click += btnImageCleanWithSelection_Click;
            // 
            // btnTextEnhencement
            // 
            btnTextEnhencement.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnTextEnhencement.Image = (Image)resources.GetObject("btnTextEnhencement.Image");
            btnTextEnhencement.ImageTransparentColor = Color.Magenta;
            btnTextEnhencement.Name = "btnTextEnhencement";
            btnTextEnhencement.Size = new Size(29, 30);
            btnTextEnhencement.Text = "Text Enhancement";
            btnTextEnhencement.Click += btnTextEnhencement_Click;
            // 
            // btnAddMark
            // 
            btnAddMark.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddMark.Image = Properties.Resources.BlankPage;
            btnAddMark.ImageTransparentColor = Color.Magenta;
            btnAddMark.Name = "btnAddMark";
            btnAddMark.Size = new Size(29, 30);
            btnAddMark.Text = "Add Mark";
            btnAddMark.Click += btnAddMark_Click;
            // 
            // tspFrontImage
            // 
            tspFrontImage.ImageScalingSize = new Size(24, 24);
            tspFrontImage.Items.AddRange(new ToolStripItem[] { btnFrontZoomIn, btnFrontZommOut, toolStripSeparator5, btnFrontRotateLeft, btnFrontRotateRight, toolStripSeparator6, btnFrontZoomToFit, btnFrontActualSize, toolStripSeparator7, btnFronDeskew, btnFrontCrop, toolStripSeparator8, btnFrontRefresh, btnFrontSave, toolStripSeparator1, txtGoto, toolStripSeparator3, btnGoto, cobZoomLevel, toolStripSeparator2, chkImagesRaw, toolStripSeparator4, btnSetting });
            tspFrontImage.Location = new Point(0, 0);
            tspFrontImage.Name = "tspFrontImage";
            tspFrontImage.Padding = new Padding(0, 0, 3, 0);
            tspFrontImage.Size = new Size(974, 31);
            tspFrontImage.TabIndex = 2;
            tspFrontImage.Text = "toolStrip2";
            // 
            // btnFrontZoomIn
            // 
            btnFrontZoomIn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontZoomIn.Image = Properties.Resources.zoom_in_24px;
            btnFrontZoomIn.ImageTransparentColor = Color.Magenta;
            btnFrontZoomIn.Name = "btnFrontZoomIn";
            btnFrontZoomIn.Size = new Size(29, 28);
            btnFrontZoomIn.Tag = "Zoom In (Key Add)";
            btnFrontZoomIn.Text = "Zoom In (Key Add)";
            btnFrontZoomIn.ToolTipText = "Zoom In, Ctrl+Add";
            btnFrontZoomIn.Click += btnFrontZoomIn_Click;
            // 
            // btnFrontZommOut
            // 
            btnFrontZommOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontZommOut.Image = Properties.Resources.zoom_out_24px;
            btnFrontZommOut.ImageTransparentColor = Color.Magenta;
            btnFrontZommOut.Name = "btnFrontZommOut";
            btnFrontZommOut.Size = new Size(29, 28);
            btnFrontZommOut.Tag = "Zoom Out (Key Subtract)";
            btnFrontZommOut.Text = "Zoom Out (Key Subtract)";
            btnFrontZommOut.ToolTipText = "Zoom Out, Ctrl+minus";
            btnFrontZommOut.Click += btnFrontZommOut_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 31);
            // 
            // btnFrontRotateLeft
            // 
            btnFrontRotateLeft.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontRotateLeft.Image = Properties.Resources.RotateLeft;
            btnFrontRotateLeft.ImageTransparentColor = Color.Magenta;
            btnFrontRotateLeft.Name = "btnFrontRotateLeft";
            btnFrontRotateLeft.Size = new Size(29, 28);
            btnFrontRotateLeft.Tag = "Zoom Out (Key Subtract)";
            btnFrontRotateLeft.Text = "Rotate Left (Key L)";
            btnFrontRotateLeft.ToolTipText = "Rotate Left, Ctrl+L";
            btnFrontRotateLeft.Click += btnFrontRotateLeft_ClickAsync;
            // 
            // btnFrontRotateRight
            // 
            btnFrontRotateRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontRotateRight.Image = Properties.Resources.RotateRight;
            btnFrontRotateRight.ImageTransparentColor = Color.Magenta;
            btnFrontRotateRight.Name = "btnFrontRotateRight";
            btnFrontRotateRight.Size = new Size(29, 28);
            btnFrontRotateRight.Tag = "Rotate Right (Key R)";
            btnFrontRotateRight.Text = "Rotate Right (Key R)";
            btnFrontRotateRight.ToolTipText = "Rotate Right, Ctrl+R";
            btnFrontRotateRight.Click += btnFrontRotateRight_ClickAsync;
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
            btnFrontZoomToFit.Size = new Size(29, 28);
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
            btnFrontActualSize.Size = new Size(29, 28);
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
            // btnFronDeskew
            // 
            btnFronDeskew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFronDeskew.Image = Properties.Resources.deskew;
            btnFronDeskew.ImageTransparentColor = Color.Magenta;
            btnFronDeskew.Name = "btnFronDeskew";
            btnFronDeskew.Size = new Size(29, 28);
            btnFronDeskew.Tag = "Deskew (Key D)";
            btnFronDeskew.Text = "Deskew (Key D)";
            btnFronDeskew.Click += btnFronDeskew_Click;
            // 
            // btnFrontCrop
            // 
            btnFrontCrop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontCrop.Image = Properties.Resources.crop;
            btnFrontCrop.ImageTransparentColor = Color.Magenta;
            btnFrontCrop.Name = "btnFrontCrop";
            btnFrontCrop.Size = new Size(29, 28);
            btnFrontCrop.Tag = "Front Crop";
            btnFrontCrop.Text = "Front Crop";
            btnFrontCrop.ToolTipText = "ImageCrop (Key C)";
            btnFrontCrop.CheckedChanged += btnFrontCrop_CheckedChanged;
            btnFrontCrop.Click += btnFrontCrop_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 31);
            // 
            // btnFrontRefresh
            // 
            btnFrontRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontRefresh.Image = Properties.Resources.refresh;
            btnFrontRefresh.ImageTransparentColor = Color.Magenta;
            btnFrontRefresh.Name = "btnFrontRefresh";
            btnFrontRefresh.Size = new Size(29, 28);
            btnFrontRefresh.Tag = "Front Refresh (Shift+R)";
            btnFrontRefresh.Text = "Front Refresh (Shift+R)";
            btnFrontRefresh.Click += btnFrontRefresh_Click;
            // 
            // btnFrontSave
            // 
            btnFrontSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFrontSave.Enabled = false;
            btnFrontSave.Image = Properties.Resources.save1;
            btnFrontSave.ImageTransparentColor = Color.Magenta;
            btnFrontSave.Name = "btnFrontSave";
            btnFrontSave.Size = new Size(29, 28);
            btnFrontSave.Tag = "Save Image (Ctrl+S)";
            btnFrontSave.Text = "Save Image (Ctrl+S)";
            btnFrontSave.Click += btnFrontSave_ClickAsync;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // txtGoto
            // 
            txtGoto.Name = "txtGoto";
            txtGoto.Size = new Size(132, 31);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // btnGoto
            // 
            btnGoto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGoto.Image = Properties.Resources.goto_16px;
            btnGoto.ImageTransparentColor = Color.Magenta;
            btnGoto.Name = "btnGoto";
            btnGoto.Size = new Size(29, 28);
            btnGoto.Tag = "Goto";
            btnGoto.Text = "Goto";
            btnGoto.Click += btnGoto_Click;
            // 
            // cobZoomLevel
            // 
            cobZoomLevel.Name = "cobZoomLevel";
            cobZoomLevel.Size = new Size(121, 31);
            cobZoomLevel.SelectedIndexChanged += cobZoomLevel_SelectedIndexChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // chkImagesRaw
            // 
            chkImagesRaw.CheckOnClick = true;
            chkImagesRaw.DisplayStyle = ToolStripItemDisplayStyle.Image;
            chkImagesRaw.Image = Properties.Resources.checkboxUnchecked50x;
            chkImagesRaw.ImageTransparentColor = Color.Magenta;
            chkImagesRaw.Name = "chkImagesRaw";
            chkImagesRaw.Size = new Size(29, 28);
            chkImagesRaw.Tag = "Image from Raw";
            chkImagesRaw.Text = "Image from Raw";
            chkImagesRaw.Click += chkImagesRaw_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 31);
            // 
            // btnSetting
            // 
            btnSetting.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSetting.Image = (Image)resources.GetObject("btnSetting.Image");
            btnSetting.ImageTransparentColor = Color.Magenta;
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(29, 28);
            btnSetting.Tag = "toolStripButton1";
            btnSetting.Text = "toolStripButton1";
            btnSetting.Click += btnSetting_Click;
            // 
            // statusStripBottom
            // 
            statusStripBottom.BackColor = Color.Transparent;
            statusStripBottom.ImageScalingSize = new Size(24, 24);
            statusStripBottom.Items.AddRange(new ToolStripItem[] { lblImagePosition, lblStatus, Seprator2, tssCoordinates, lblImageCoordinates, toolStripStatusLabel4, toolStripStatusLabel2, lblImagePath, toolStripStatusLabel1, toolStripStatusLabel3, lblCurrentUserName });
            statusStripBottom.Location = new Point(0, 719);
            statusStripBottom.Name = "statusStripBottom";
            statusStripBottom.Padding = new Padding(1, 0, 24, 0);
            statusStripBottom.Size = new Size(1277, 30);
            statusStripBottom.TabIndex = 4;
            statusStripBottom.Text = "statusStrip1";
            // 
            // lblImagePosition
            // 
            lblImagePosition.Name = "lblImagePosition";
            lblImagePosition.Size = new Size(25, 24);
            lblImagePosition.Text = "00";
            // 
            // Seprator2
            // 
            Seprator2.Name = "Seprator2";
            Seprator2.Size = new Size(13, 24);
            Seprator2.Text = "|";
            Seprator2.Visible = false;
            // 
            // tssCoordinates
            // 
            tssCoordinates.Name = "tssCoordinates";
            tssCoordinates.Size = new Size(92, 24);
            tssCoordinates.Tag = "Coordinates:";
            tssCoordinates.Text = "Coordinates:";
            // 
            // lblImageCoordinates
            // 
            lblImageCoordinates.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblImageCoordinates.BorderStyle = Border3DStyle.SunkenOuter;
            lblImageCoordinates.Name = "lblImageCoordinates";
            lblImageCoordinates.Size = new Size(111, 24);
            lblImageCoordinates.Tag = "X:0 Y:0 W:0 H:0";
            lblImageCoordinates.Text = "X:0 Y:0 W:0 H:0";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(13, 24);
            toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(66, 24);
            toolStripStatusLabel2.Tag = "Location";
            toolStripStatusLabel2.Text = "Location";
            // 
            // lblImagePath
            // 
            lblImagePath.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblImagePath.BorderStyle = Border3DStyle.SunkenOuter;
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(34, 24);
            lblImagePath.Text = "xxx";
            lblImagePath.Click += lblImagePath_Click;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(786, 24);
            toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(85, 24);
            toolStripStatusLabel3.Tag = "User Name:";
            toolStripStatusLabel3.Text = "User Name:";
            // 
            // lblCurrentUserName
            // 
            lblCurrentUserName.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblCurrentUserName.BorderStyle = Border3DStyle.SunkenOuter;
            lblCurrentUserName.Name = "lblCurrentUserName";
            lblCurrentUserName.Size = new Size(40, 24);
            lblCurrentUserName.Text = "XXX";
            // 
            // ofd
            // 
            ofd.FileName = "file";
            // 
            // frmImageSingleDeleteQC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1277, 749);
            Controls.Add(splitContainerMain);
            Controls.Add(statusStripBottom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmImageSingleDeleteQC";
            Text = "Image Quality Check";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmApplicationForm_FormClosing;
            Load += frmApplicationForm_LoadAsync;
            KeyDown += frmQCandUpdateRecord_KeyDown;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerLeft3.Panel1.ResumeLayout(false);
            splitContainerLeft3.Panel1.PerformLayout();
            splitContainerLeft3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft3).EndInit();
            splitContainerLeft3.ResumeLayout(false);
            tlpBatchSelection.ResumeLayout(false);
            tlpBatchSelection.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            contextMenuStrip.ResumeLayout(false);
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            toolStripContainer1.LeftToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tspFrontImage.ResumeLayout(false);
            tspFrontImage.PerformLayout();
            statusStripBottom.ResumeLayout(false);
            statusStripBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripStatusLabel lblStatus;
        private SplitContainer splitContainerMain;
  
        private StatusStrip statusStripBottom;
        private OpenFileDialog ofd;
        private ToolStrip tspFrontImage;
        private ToolStripButton btnFrontZoomIn;
        private ToolStripButton btnFrontZommOut;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnFrontRotateLeft;
        private ToolStripButton btnFrontRotateRight;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnFrontZoomToFit;
        private ToolStripButton btnFrontActualSize;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton btnFronDeskew;
        private ToolStripButton btnFrontCrop;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton btnFrontSave;
        private ToolStripButton btnFrontRefresh;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel lblCurrentUserName;
        private ToolStripStatusLabel lblImagePosition;
        private ToolStripStatusLabel Seprator2;
          private TableLayoutPanel tlpBatchSelection;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox txtGoto;
        private ToolStripButton btnGoto;
        private ToolStripStatusLabel tssCoordinates;
        private ToolStripStatusLabel lblImageCoordinates;
        private ToolStripComboBox cobZoomLevel;
      
        private SplitContainer splitContainerLeft3;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrevious;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton chkImagesRaw;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel lblImagePath;
        private Label label1;
        private Label label2;
        private ComboBox cobCaseDirectory;
        private ComboBox cobSubDicrectoy;
        private Button btnInsert;
        private Button btnDeleteRecord;
        private Button btnSave;
        private Button btnClose;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip2;
        private ToolStripButton btnArrow;
        private ToolStripButton btnRectangle;
        private ToolStripButton btnErase;
        private Button btnFileComplete;
        private Button btnBatchComplete;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem menReorderList;
        private ToolStripMenuItem menMoveFile;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripButton btnImageCleanWithSelection;
        private ToolStripButton btnTextEnhencement;
        private Button btnRemarks;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnAddMark;
        private ToolStripButton btnSetting;
        private CheckedListBox lstImages;
        private ToolStripMenuItem menDeleted;
        private ToolStripMenuItem menDeleteSelected;
        private ImageBox imgBox;
    }
}