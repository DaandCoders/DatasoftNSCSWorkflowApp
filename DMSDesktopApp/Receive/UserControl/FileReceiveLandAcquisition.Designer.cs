namespace CoreWorkflow
{
    partial class FileReceiveLandAcquisition
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
            label1 = new Label();
            txtFileNumber = new TextBox();
            mtbYear = new MaskedTextBox();
            txtReceivedBy = new TextBox();
            txtReceivedDate = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSave = new Button();
            btnClear = new Button();
            label6 = new Label();
            txtBarcode = new TextBox();
            cobFileType = new ComboBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            numA1 = new NumericUpDown();
            numA2 = new NumericUpDown();
            numA3 = new NumericUpDown();
            numA4 = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numA1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 15);
            label1.Name = "label1";
            label1.Size = new Size(264, 23);
            label1.TabIndex = 0;
            label1.Tag = "LAND AQUISITION DEPARTMENT";
            label1.Text = "LAND AQUISITION DEPARTMENT";
            // 
            // txtFileNumber
            // 
            txtFileNumber.Font = new Font("Segoe UI", 9.75F);
            txtFileNumber.Location = new Point(185, 58);
            txtFileNumber.Margin = new Padding(3, 4, 3, 4);
            txtFileNumber.Name = "txtFileNumber";
            txtFileNumber.Size = new Size(229, 29);
            txtFileNumber.TabIndex = 1;
            // 
            // mtbYear
            // 
            mtbYear.Font = new Font("Segoe UI", 9.75F);
            mtbYear.Location = new Point(579, 58);
            mtbYear.Margin = new Padding(3, 4, 3, 4);
            mtbYear.Mask = "0000";
            mtbYear.Name = "mtbYear";
            mtbYear.Size = new Size(114, 29);
            mtbYear.TabIndex = 2;
            mtbYear.ValidatingType = typeof(int);
            // 
            // txtReceivedBy
            // 
            txtReceivedBy.Font = new Font("Segoe UI", 9.75F);
            txtReceivedBy.Location = new Point(168, 129);
            txtReceivedBy.Margin = new Padding(3, 4, 3, 4);
            txtReceivedBy.Name = "txtReceivedBy";
            txtReceivedBy.Size = new Size(229, 29);
            txtReceivedBy.TabIndex = 3;
            // 
            // txtReceivedDate
            // 
            txtReceivedDate.Font = new Font("Segoe UI", 9.75F);
            txtReceivedDate.Location = new Point(562, 129);
            txtReceivedDate.Margin = new Padding(3, 4, 3, 4);
            txtReceivedDate.Name = "txtReceivedDate";
            txtReceivedDate.Size = new Size(297, 29);
            txtReceivedDate.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(88, 66);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 5;
            label2.Tag = "File Number";
            label2.Text = "File Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(535, 66);
            label3.Name = "label3";
            label3.Size = new Size(42, 23);
            label3.TabIndex = 6;
            label3.Tag = "Year";
            label3.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(73, 137);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 7;
            label4.Tag = "Received By";
            label4.Text = "Received By";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(451, 137);
            label5.Name = "label5";
            label5.Size = new Size(118, 23);
            label5.TabIndex = 8;
            label5.Tag = "Received Date";
            label5.Text = "Received Date";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonFace;
            btnSave.Font = new Font("Segoe UI", 9.75F);
            btnSave.Location = new Point(535, 466);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 57);
            btnSave.TabIndex = 9;
            btnSave.Tag = "SAVE";
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ButtonFace;
            btnClear.Font = new Font("Segoe UI", 9.75F);
            btnClear.Location = new Point(267, 466);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(129, 57);
            btnClear.TabIndex = 10;
            btnClear.Tag = "CLEAR";
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(491, 228);
            label6.Name = "label6";
            label6.Size = new Size(72, 23);
            label6.TabIndex = 13;
            label6.Tag = "Received Date";
            label6.Text = "Barcode";
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 9.75F);
            txtBarcode.Location = new Point(562, 224);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(297, 29);
            txtBarcode.TabIndex = 12;
            // 
            // cobFileType
            // 
            cobFileType.Enabled = false;
            cobFileType.FormattingEnabled = true;
            cobFileType.Items.AddRange(new object[] { "None", "NS", "CS" });
            cobFileType.Location = new Point(168, 228);
            cobFileType.Margin = new Padding(3, 4, 3, 4);
            cobFileType.Name = "cobFileType";
            cobFileType.Size = new Size(229, 28);
            cobFileType.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.Location = new Point(81, 228);
            label8.Name = "label8";
            label8.Size = new Size(75, 23);
            label8.TabIndex = 15;
            label8.Tag = "Received By";
            label8.Text = "File Type";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numA1);
            groupBox1.Controls.Add(numA2);
            groupBox1.Controls.Add(numA3);
            groupBox1.Controls.Add(numA4);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Location = new Point(38, 340);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(941, 89);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Paper Size";
            // 
            // numA1
            // 
            numA1.Location = new Point(772, 37);
            numA1.Name = "numA1";
            numA1.Size = new Size(74, 27);
            numA1.TabIndex = 10;
            // 
            // numA2
            // 
            numA2.Location = new Point(575, 37);
            numA2.Name = "numA2";
            numA2.Size = new Size(74, 27);
            numA2.TabIndex = 9;
            // 
            // numA3
            // 
            numA3.Location = new Point(374, 37);
            numA3.Name = "numA3";
            numA3.Size = new Size(74, 27);
            numA3.TabIndex = 8;
            // 
            // numA4
            // 
            numA4.Location = new Point(162, 37);
            numA4.Name = "numA4";
            numA4.Size = new Size(74, 27);
            numA4.TabIndex = 7;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(665, 42);
            label12.Name = "label12";
            label12.Size = new Size(101, 20);
            label12.TabIndex = 6;
            label12.Text = "A1 Size Count";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(468, 42);
            label11.Name = "label11";
            label11.Size = new Size(101, 20);
            label11.TabIndex = 4;
            label11.Text = "A2 Size Count";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(267, 42);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 2;
            label10.Text = "A3 Size Count";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(55, 42);
            label9.Name = "label9";
            label9.Size = new Size(101, 20);
            label9.TabIndex = 0;
            label9.Text = "A4 Size Count";
            // 
            // FileReceiveLandAcquisition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(groupBox1);
            Controls.Add(cobFileType);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(txtBarcode);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtReceivedDate);
            Controls.Add(txtReceivedBy);
            Controls.Add(mtbYear);
            Controls.Add(txtFileNumber);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FileReceiveLandAcquisition";
            Size = new Size(1091, 693);
            Load += FileReceiveLandAcquisition_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numA1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFileNumber;
        private MaskedTextBox mtbYear;
        private TextBox txtReceivedBy;
        private TextBox txtReceivedDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSave;
        private Button btnClear;
        private Label label6;
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
    }
}
