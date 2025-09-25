namespace CoreWorkflow
{
    partial class FileReceiveTechnical
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
            label1 = new Label();
            cmbSchemeType = new ComboBox();
            mtbYear = new MaskedTextBox();
            txtNameOfWork = new TextBox();
            txtContractorName = new TextBox();
            txtReceivedby = new TextBox();
            txtReceivedDate = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnSave = new Button();
            btnClear = new Button();
            txtBarcode = new TextBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            numA1 = new NumericUpDown();
            numA2 = new NumericUpDown();
            numA3 = new NumericUpDown();
            numA4 = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label13 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numA1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA4).BeginInit();
            SuspendLayout();
            // 
            // txtFileNumber
            // 
            txtFileNumber.Font = new Font("Segoe UI", 9.75F);
            txtFileNumber.Location = new Point(152, 161);
            txtFileNumber.Margin = new Padding(3, 4, 3, 4);
            txtFileNumber.Name = "txtFileNumber";
            txtFileNumber.Size = new Size(249, 29);
            txtFileNumber.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(46, 165);
            label1.Name = "label1";
            label1.Size = new Size(103, 23);
            label1.TabIndex = 2;
            label1.Tag = "File Number";
            label1.Text = "File Number";
            // 
            // cmbSchemeType
            // 
            cmbSchemeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSchemeType.Font = new Font("Segoe UI", 9.75F);
            cmbSchemeType.FormattingEnabled = true;
            cmbSchemeType.Location = new Point(153, 81);
            cmbSchemeType.Margin = new Padding(3, 4, 3, 4);
            cmbSchemeType.Name = "cmbSchemeType";
            cmbSchemeType.Size = new Size(247, 29);
            cmbSchemeType.TabIndex = 3;
            // 
            // mtbYear
            // 
            mtbYear.Font = new Font("Segoe UI", 9.75F);
            mtbYear.Location = new Point(635, 165);
            mtbYear.Margin = new Padding(3, 4, 3, 4);
            mtbYear.Mask = "0000";
            mtbYear.Name = "mtbYear";
            mtbYear.Size = new Size(147, 29);
            mtbYear.TabIndex = 4;
            mtbYear.ValidatingType = typeof(int);
            // 
            // txtNameOfWork
            // 
            txtNameOfWork.Font = new Font("Segoe UI", 9.75F);
            txtNameOfWork.Location = new Point(152, 248);
            txtNameOfWork.Margin = new Padding(3, 4, 3, 4);
            txtNameOfWork.Name = "txtNameOfWork";
            txtNameOfWork.Size = new Size(249, 29);
            txtNameOfWork.TabIndex = 5;
            // 
            // txtContractorName
            // 
            txtContractorName.Font = new Font("Segoe UI", 9.75F);
            txtContractorName.Location = new Point(635, 248);
            txtContractorName.Margin = new Padding(3, 4, 3, 4);
            txtContractorName.Name = "txtContractorName";
            txtContractorName.Size = new Size(293, 29);
            txtContractorName.TabIndex = 6;
            // 
            // txtReceivedby
            // 
            txtReceivedby.Font = new Font("Segoe UI", 9.75F);
            txtReceivedby.Location = new Point(153, 336);
            txtReceivedby.Margin = new Padding(3, 4, 3, 4);
            txtReceivedby.Name = "txtReceivedby";
            txtReceivedby.Size = new Size(247, 29);
            txtReceivedby.TabIndex = 7;
            // 
            // txtReceivedDate
            // 
            txtReceivedDate.Font = new Font("Segoe UI", 9.75F);
            txtReceivedDate.Location = new Point(635, 336);
            txtReceivedDate.Margin = new Padding(3, 4, 3, 4);
            txtReceivedDate.Name = "txtReceivedDate";
            txtReceivedDate.Size = new Size(293, 29);
            txtReceivedDate.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(54, 85);
            label2.Name = "label2";
            label2.Size = new Size(110, 23);
            label2.TabIndex = 9;
            label2.Tag = "Scheme Type";
            label2.Text = "Scheme Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(588, 169);
            label3.Name = "label3";
            label3.Size = new Size(42, 23);
            label3.TabIndex = 10;
            label3.Tag = "Year";
            label3.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(43, 253);
            label4.Name = "label4";
            label4.Size = new Size(120, 23);
            label4.TabIndex = 11;
            label4.Tag = "Name of Work";
            label4.Text = "Name of Work";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(505, 252);
            label5.Name = "label5";
            label5.Size = new Size(143, 23);
            label5.TabIndex = 12;
            label5.Tag = "Contractor Name";
            label5.Text = "Contractor Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(58, 340);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 13;
            label6.Tag = "Received By";
            label6.Text = "Received By";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(524, 340);
            label7.Name = "label7";
            label7.Size = new Size(118, 23);
            label7.TabIndex = 14;
            label7.Tag = "Received Date";
            label7.Text = "Received Date";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ControlLight;
            btnSave.Font = new Font("Segoe UI", 9.75F);
            btnSave.Location = new Point(567, 522);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 61);
            btnSave.TabIndex = 15;
            btnSave.Tag = "SAVE";
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ControlLight;
            btnClear.Font = new Font("Segoe UI", 9.75F);
            btnClear.Location = new Point(356, 525);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 59);
            btnClear.TabIndex = 16;
            btnClear.Tag = "CLEAR";
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBarcode.Location = new Point(635, 81);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(147, 29);
            txtBarcode.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(567, 88);
            label8.Name = "label8";
            label8.Size = new Size(72, 23);
            label8.TabIndex = 18;
            label8.Tag = "Barcode";
            label8.Text = "Barcode";
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
            groupBox1.Controls.Add(label13);
            groupBox1.Location = new Point(68, 389);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(941, 89);
            groupBox1.TabIndex = 19;
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
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(55, 42);
            label13.Name = "label13";
            label13.Size = new Size(101, 20);
            label13.TabIndex = 0;
            label13.Text = "A4 Size Count";
            // 
            // FileReceiveTechnical
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(groupBox1);
            Controls.Add(label8);
            Controls.Add(txtBarcode);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtReceivedDate);
            Controls.Add(txtReceivedby);
            Controls.Add(txtContractorName);
            Controls.Add(txtNameOfWork);
            Controls.Add(mtbYear);
            Controls.Add(cmbSchemeType);
            Controls.Add(label1);
            Controls.Add(txtFileNumber);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FileReceiveTechnical";
            Size = new Size(1117, 676);
            Load += FileReceiveTechnical_Load;
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

        private Label lblTehnical;
        private TextBox txtFileNumber;
        private Label label1;
        private ComboBox cmbSchemeType;
        private MaskedTextBox mtbYear;
        private TextBox txtNameOfWork;
        private TextBox txtContractorName;
        private TextBox txtReceivedby;
        private TextBox txtReceivedDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnSave;
        private Button btnClear;
        private TextBox txtBarcode;
        private Label label8;
        private GroupBox groupBox1;
        private NumericUpDown numA1;
        private NumericUpDown numA2;
        private NumericUpDown numA3;
        private NumericUpDown numA4;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label13;
    }
}
