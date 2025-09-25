namespace DMS.DesktopApp.Shared
{
    partial class frmMultiImageInsert
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            numPosition = new NumericUpDown();
            btnBrowse = new Button();
            txtNewImagePath = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            btnOk = new Button();
            btnClose = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPosition).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numPosition);
            groupBox1.Controls.Add(btnBrowse);
            groupBox1.Controls.Add(txtNewImagePath);
            groupBox1.Location = new Point(17, 14);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(427, 95);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 62);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Tag = "Position";
            label1.Text = "Position";
            label1.Visible = false;
            // 
            // numPosition
            // 
            numPosition.Location = new Point(81, 59);
            numPosition.Margin = new Padding(3, 2, 3, 2);
            numPosition.Name = "numPosition";
            numPosition.Size = new Size(63, 23);
            numPosition.TabIndex = 2;
            numPosition.Visible = false;
            // 
            // btnBrowse
            // 
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.Location = new Point(323, 27);
            btnBrowse.Margin = new Padding(3, 2, 3, 2);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(82, 22);
            btnBrowse.TabIndex = 1;
            btnBrowse.Tag = "Browse";
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtNewImagePath
            // 
            txtNewImagePath.Location = new Point(19, 28);
            txtNewImagePath.Margin = new Padding(3, 2, 3, 2);
            txtNewImagePath.Name = "txtNewImagePath";
            txtNewImagePath.ReadOnly = true;
            txtNewImagePath.Size = new Size(299, 23);
            txtNewImagePath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog";
            openFileDialog1.Title = "Select file";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.RoyalBlue;
            btnOk.Cursor = Cursors.Hand;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.FlatStyle = FlatStyle.Popup;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(252, 118);
            btnOk.Margin = new Padding(3, 2, 3, 2);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(82, 22);
            btnOk.TabIndex = 1;
            btnOk.Tag = "OK";
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(340, 118);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(82, 22);
            btnClose.TabIndex = 1;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // frmMultiImageInsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(454, 146);
            Controls.Add(btnClose);
            Controls.Add(btnOk);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmMultiImageInsert";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "Insert Images";
            Text = "Insert Images";
            Load += frmMultiImageInsert_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPosition).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnBrowse;
        private OpenFileDialog openFileDialog1;
        private Button btnOk;
        private Button btnClose;
        public NumericUpDown numPosition;
        private TextBox txtNewImagePath;
    }
}