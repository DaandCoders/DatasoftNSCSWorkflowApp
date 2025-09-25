namespace CoreWorkflow
{
    partial class FileReceiveHousing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFileNumber = new TextBox();
            mtbYear = new MaskedTextBox();
            txtAllotteeName = new TextBox();
            txtReceivedBy = new TextBox();
            txtReceivedDate = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnSave = new Button();
            btnClear = new Button();
            label7 = new Label();
            txtBarcode = new TextBox();
            cobFileType = new ComboBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label9 = new Label();
            numA1 = new NumericUpDown();
            label10 = new Label();
            label12 = new Label();
            numA2 = new NumericUpDown();
            numA4 = new NumericUpDown();
            numA3 = new NumericUpDown();
            label11 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numA1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA3).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtFileNumber
            // 
            txtFileNumber.Dock = DockStyle.Fill;
            txtFileNumber.Font = new Font("Segoe UI", 9.75F);
            txtFileNumber.Location = new Point(142, 14);
            txtFileNumber.Margin = new Padding(3, 4, 3, 4);
            txtFileNumber.Name = "txtFileNumber";
            txtFileNumber.Size = new Size(327, 29);
            txtFileNumber.TabIndex = 1;
            // 
            // mtbYear
            // 
            mtbYear.Dock = DockStyle.Fill;
            mtbYear.Font = new Font("Segoe UI", 9.75F);
            mtbYear.Location = new Point(645, 14);
            mtbYear.Margin = new Padding(3, 4, 3, 4);
            mtbYear.Mask = "0000";
            mtbYear.Name = "mtbYear";
            mtbYear.Size = new Size(148, 29);
            mtbYear.TabIndex = 2;
            mtbYear.ValidatingType = typeof(int);
            // 
            // txtAllotteeName
            // 
            txtAllotteeName.Dock = DockStyle.Fill;
            txtAllotteeName.Font = new Font("Segoe UI", 9.75F);
            txtAllotteeName.Location = new Point(142, 63);
            txtAllotteeName.Margin = new Padding(3, 4, 3, 4);
            txtAllotteeName.Name = "txtAllotteeName";
            txtAllotteeName.Size = new Size(327, 29);
            txtAllotteeName.TabIndex = 3;
            // 
            // txtReceivedBy
            // 
            txtReceivedBy.Dock = DockStyle.Fill;
            txtReceivedBy.Font = new Font("Segoe UI", 9.75F);
            txtReceivedBy.Location = new Point(142, 109);
            txtReceivedBy.Margin = new Padding(3, 4, 3, 4);
            txtReceivedBy.Name = "txtReceivedBy";
            txtReceivedBy.Size = new Size(327, 29);
            txtReceivedBy.TabIndex = 4;
            // 
            // txtReceivedDate
            // 
            txtReceivedDate.Dock = DockStyle.Fill;
            txtReceivedDate.Font = new Font("Segoe UI", 9.75F);
            txtReceivedDate.Location = new Point(645, 109);
            txtReceivedDate.Margin = new Padding(3, 4, 3, 4);
            txtReceivedDate.Name = "txtReceivedDate";
            txtReceivedDate.Size = new Size(148, 29);
            txtReceivedDate.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(13, 10);
            label2.Name = "label2";
            label2.Size = new Size(123, 49);
            label2.TabIndex = 6;
            label2.Tag = "File Number";
            label2.Text = "File Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(475, 10);
            label3.Name = "label3";
            label3.Size = new Size(164, 49);
            label3.TabIndex = 7;
            label3.Tag = "Year";
            label3.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(13, 59);
            label4.Name = "label4";
            label4.Size = new Size(123, 46);
            label4.TabIndex = 8;
            label4.Tag = "Allottee Name";
            label4.Text = "Allottee Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(13, 105);
            label5.Name = "label5";
            label5.Size = new Size(123, 42);
            label5.TabIndex = 9;
            label5.Tag = "Received By";
            label5.Text = "Received By";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(475, 105);
            label6.Name = "label6";
            label6.Size = new Size(164, 42);
            label6.TabIndex = 10;
            label6.Tag = "Received Date";
            label6.Text = "Received Date";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.75F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(513, 4);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 36);
            btnSave.TabIndex = 11;
            btnSave.Tag = "Save";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.IndianRed;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.75F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(648, 4);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(129, 36);
            btnClear.TabIndex = 12;
            btnClear.Tag = "Clear";
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(475, 59);
            label7.Name = "label7";
            label7.Size = new Size(164, 46);
            label7.TabIndex = 14;
            label7.Tag = "Received Date";
            label7.Text = "Barcode";
            // 
            // txtBarcode
            // 
            txtBarcode.Dock = DockStyle.Fill;
            txtBarcode.Font = new Font("Segoe UI", 9.75F);
            txtBarcode.Location = new Point(645, 63);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(148, 29);
            txtBarcode.TabIndex = 13;
            // 
            // cobFileType
            // 
            cobFileType.Dock = DockStyle.Fill;
            cobFileType.Enabled = false;
            cobFileType.FormattingEnabled = true;
            cobFileType.Items.AddRange(new object[] { "None", "NS", "CS" });
            cobFileType.Location = new Point(142, 151);
            cobFileType.Margin = new Padding(3, 4, 3, 4);
            cobFileType.Name = "cobFileType";
            cobFileType.Size = new Size(327, 28);
            cobFileType.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.Location = new Point(13, 147);
            label8.Name = "label8";
            label8.Size = new Size(123, 42);
            label8.TabIndex = 15;
            label8.Tag = "Received By";
            label8.Text = "File Type";
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 4);
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Location = new Point(13, 192);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(780, 76);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Paper Size";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.Controls.Add(label9, 0, 0);
            tableLayoutPanel2.Controls.Add(numA1, 7, 0);
            tableLayoutPanel2.Controls.Add(label10, 2, 0);
            tableLayoutPanel2.Controls.Add(label12, 6, 0);
            tableLayoutPanel2.Controls.Add(numA2, 5, 0);
            tableLayoutPanel2.Controls.Add(numA4, 1, 0);
            tableLayoutPanel2.Controls.Add(numA3, 3, 0);
            tableLayoutPanel2.Controls.Add(label11, 4, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(774, 50);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(90, 50);
            label9.TabIndex = 0;
            label9.Text = "A4 Size Count";
            // 
            // numA1
            // 
            numA1.Dock = DockStyle.Fill;
            numA1.Location = new Point(675, 3);
            numA1.Name = "numA1";
            numA1.Size = new Size(96, 27);
            numA1.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(195, 0);
            label10.Name = "label10";
            label10.Size = new Size(90, 50);
            label10.TabIndex = 2;
            label10.Text = "A3 Size Count";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(579, 0);
            label12.Name = "label12";
            label12.Size = new Size(90, 50);
            label12.TabIndex = 6;
            label12.Text = "A1 Size Count";
            // 
            // numA2
            // 
            numA2.Dock = DockStyle.Fill;
            numA2.Location = new Point(483, 3);
            numA2.Name = "numA2";
            numA2.Size = new Size(90, 27);
            numA2.TabIndex = 9;
            // 
            // numA4
            // 
            numA4.Dock = DockStyle.Fill;
            numA4.Location = new Point(99, 3);
            numA4.Name = "numA4";
            numA4.Size = new Size(90, 27);
            numA4.TabIndex = 7;
            // 
            // numA3
            // 
            numA3.Dock = DockStyle.Fill;
            numA3.Location = new Point(291, 3);
            numA3.Name = "numA3";
            numA3.Size = new Size(90, 27);
            numA3.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(387, 0);
            label11.Name = "label11";
            label11.Size = new Size(90, 50);
            label11.TabIndex = 4;
            label11.Text = "A2 Size Count";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.50124F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.4317627F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.6687431F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.5516815F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 4);
            tableLayoutPanel1.Controls.Add(txtFileNumber, 1, 0);
            tableLayoutPanel1.Controls.Add(cobFileType, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label8, 0, 3);
            tableLayoutPanel1.Controls.Add(mtbYear, 3, 0);
            tableLayoutPanel1.Controls.Add(txtBarcode, 3, 1);
            tableLayoutPanel1.Controls.Add(label7, 2, 1);
            tableLayoutPanel1.Controls.Add(txtReceivedDate, 3, 2);
            tableLayoutPanel1.Controls.Add(label6, 2, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(txtAllotteeName, 1, 1);
            tableLayoutPanel1.Controls.Add(txtReceivedBy, 1, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.5555553F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.8148146F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26.072607F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.8217831F));
            tableLayoutPanel1.Size = new Size(806, 340);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 4);
            flowLayoutPanel1.Controls.Add(btnClear);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(13, 274);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(780, 53);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // FileReceiveHousing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FileReceiveHousing";
            Size = new Size(806, 340);
            Load += FileReceiveHousing_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numA1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA3).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtFileNumber;
        private MaskedTextBox mtbYear;
        private TextBox txtAllotteeName;
        private TextBox txtReceivedBy;
        private TextBox txtReceivedDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnSave;
        private Button btnClear;
        private Label label7;
        private TextBox txtBarcode;
        private ComboBox cobFileType;
        private Label label8;
        private GroupBox groupBox1;
        private NumericUpDown numA1;
        private NumericUpDown numA2;
        private NumericUpDown numA3;
        private NumericUpDown numA4;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
