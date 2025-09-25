namespace DMS.DesktopApp.Shared
{
    partial class frmMoveFile
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
            numNewPosition = new NumericUpDown();
            label1 = new Label();
            btnMove = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNewPosition).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numNewPosition);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 16);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(308, 62);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // numNewPosition
            // 
            numNewPosition.Location = new Point(155, 26);
            numNewPosition.Margin = new Padding(3, 2, 3, 2);
            numNewPosition.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numNewPosition.Name = "numNewPosition";
            numNewPosition.Size = new Size(82, 23);
            numNewPosition.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 27);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Tag = "Move To Position";
            label1.Text = "Move To Position";
            // 
            // btnMove
            // 
            btnMove.BackColor = Color.RoyalBlue;
            btnMove.Cursor = Cursors.Hand;
            btnMove.DialogResult = DialogResult.OK;
            btnMove.FlatStyle = FlatStyle.Popup;
            btnMove.ForeColor = Color.White;
            btnMove.Location = new Point(138, 90);
            btnMove.Margin = new Padding(3, 2, 3, 2);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(82, 22);
            btnMove.TabIndex = 1;
            btnMove.Tag = "Move";
            btnMove.Text = "Move";
            btnMove.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(236, 90);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 1;
            btnCancel.Tag = "Cancel";
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmMoveFile
            // 
            AcceptButton = btnMove;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(338, 120);
            Controls.Add(btnCancel);
            Controls.Add(btnMove);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMoveFile";
            Tag = "Move File";
            Text = "Move File";
            Load += frmMoveFile_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNewPosition).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnMove;
        private Button btnCancel;
        public NumericUpDown numNewPosition;
    }
}