namespace CoreWorkflow
{
    partial class DrawingLayoutControl
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
            txtLayoutNumber = new TextBox();
            txtRevenueVillage = new TextBox();
            txtKhasraNumber = new TextBox();
            txtReceivedBy = new TextBox();
            txtReceivedDate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSave = new Button();
            btnClear = new Button();
            txtBarcode = new TextBox();
            label7 = new Label();
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
            // txtLayoutNumber
            // 
            txtLayoutNumber.Location = new Point(152, 59);
            txtLayoutNumber.Margin = new Padding(3, 4, 3, 4);
            txtLayoutNumber.Name = "txtLayoutNumber";
            txtLayoutNumber.Size = new Size(301, 27);
            txtLayoutNumber.TabIndex = 0;
            // 
            // txtRevenueVillage
            // 
            txtRevenueVillage.Location = new Point(701, 59);
            txtRevenueVillage.Margin = new Padding(3, 4, 3, 4);
            txtRevenueVillage.Name = "txtRevenueVillage";
            txtRevenueVillage.Size = new Size(274, 27);
            txtRevenueVillage.TabIndex = 1;
            // 
            // txtKhasraNumber
            // 
            txtKhasraNumber.Location = new Point(150, 136);
            txtKhasraNumber.Margin = new Padding(3, 4, 3, 4);
            txtKhasraNumber.Name = "txtKhasraNumber";
            txtKhasraNumber.Size = new Size(301, 27);
            txtKhasraNumber.TabIndex = 2;
            // 
            // txtReceivedBy
            // 
            txtReceivedBy.Location = new Point(150, 325);
            txtReceivedBy.Margin = new Padding(3, 4, 3, 4);
            txtReceivedBy.Name = "txtReceivedBy";
            txtReceivedBy.Size = new Size(301, 27);
            txtReceivedBy.TabIndex = 3;
            // 
            // txtReceivedDate
            // 
            txtReceivedDate.Location = new Point(699, 237);
            txtReceivedDate.Margin = new Padding(3, 4, 3, 4);
            txtReceivedDate.Name = "txtReceivedDate";
            txtReceivedDate.Size = new Size(274, 27);
            txtReceivedDate.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(33, 63);
            label1.Name = "label1";
            label1.Size = new Size(129, 23);
            label1.TabIndex = 5;
            label1.Tag = "Layout Number";
            label1.Text = "Layout Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(580, 60);
            label2.Name = "label2";
            label2.Size = new Size(131, 23);
            label2.TabIndex = 6;
            label2.Tag = "Revenue Village";
            label2.Text = "Revenue Village";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(29, 137);
            label3.Name = "label3";
            label3.Size = new Size(129, 23);
            label3.TabIndex = 7;
            label3.Tag = "Khasra Number";
            label3.Text = "Khasra Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(55, 333);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            label4.Tag = "Received By";
            label4.Text = "Received By";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(588, 245);
            label5.Name = "label5";
            label5.Size = new Size(118, 23);
            label5.TabIndex = 9;
            label5.Tag = "Received Date";
            label5.Text = "Received Date";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonFace;
            btnSave.Font = new Font("Segoe UI", 9.75F);
            btnSave.Location = new Point(580, 483);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 57);
            btnSave.TabIndex = 10;
            btnSave.Tag = "SAVE";
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ButtonFace;
            btnClear.Font = new Font("Segoe UI", 9.75F);
            btnClear.Location = new Point(332, 483);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(129, 57);
            btnClear.TabIndex = 11;
            btnClear.Tag = "CLEAR";
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(699, 136);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(274, 27);
            txtBarcode.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(628, 144);
            label7.Name = "label7";
            label7.Size = new Size(72, 23);
            label7.TabIndex = 9;
            label7.Tag = "Received Date";
            label7.Text = "Barcode";
            // 
            // cobFileType
            // 
            cobFileType.Enabled = false;
            cobFileType.FormattingEnabled = true;
            cobFileType.Items.AddRange(new object[] { "None", "NS", "CS" });
            cobFileType.Location = new Point(150, 237);
            cobFileType.Margin = new Padding(3, 4, 3, 4);
            cobFileType.Name = "cobFileType";
            cobFileType.Size = new Size(301, 28);
            cobFileType.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.Location = new Point(63, 237);
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
            groupBox1.Location = new Point(55, 377);
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
            // DrawingLayoutControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(groupBox1);
            Controls.Add(cobFileType);
            Controls.Add(label8);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBarcode);
            Controls.Add(txtReceivedDate);
            Controls.Add(txtReceivedBy);
            Controls.Add(txtKhasraNumber);
            Controls.Add(txtRevenueVillage);
            Controls.Add(txtLayoutNumber);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DrawingLayoutControl";
            Size = new Size(1082, 645);
            Load += DrawingLayoutControl_Load;
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

        private TextBox txtLayoutNumber;
        private TextBox txtRevenueVillage;
        private TextBox txtKhasraNumber;
        private TextBox txtReceivedBy;
        private TextBox txtReceivedDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSave;
        private Button btnClear;
        private TextBox txtBarcode;
        private Label label7;
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
