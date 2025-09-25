namespace DMS.DesktopApp.Shared
{
    partial class frmColorSetting
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
            btnApply = new Button();
            btnClose = new Button();
            txtColorCode = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            panColor = new Panel();
            btnSysytemColor = new Button();
            btnColorPicker = new Button();
            colorDialog = new ColorDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Location = new Point(179, 170);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 0;
            btnApply.Tag = "Apply";
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(274, 170);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtColorCode
            // 
            txtColorCode.Location = new Point(74, 29);
            txtColorCode.Name = "txtColorCode";
            txtColorCode.Size = new Size(100, 23);
            txtColorCode.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtColorCode);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(242, 80);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 34);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Tag = "Color";
            label1.Text = "Color";
            // 
            // panColor
            // 
            panColor.Location = new Point(264, 18);
            panColor.Name = "panColor";
            panColor.Size = new Size(85, 74);
            panColor.TabIndex = 4;
            // 
            // btnSysytemColor
            // 
            btnSysytemColor.Image = Properties.Resources.SystemColor32x;
            btnSysytemColor.Location = new Point(12, 101);
            btnSysytemColor.Name = "btnSysytemColor";
            btnSysytemColor.Size = new Size(49, 46);
            btnSysytemColor.TabIndex = 5;
            btnSysytemColor.UseVisualStyleBackColor = true;
            btnSysytemColor.Click += btnSysytemColor_Click;
            // 
            // btnColorPicker
            // 
            btnColorPicker.Image = Properties.Resources.colorPicker32x;
            btnColorPicker.Location = new Point(67, 101);
            btnColorPicker.Name = "btnColorPicker";
            btnColorPicker.Size = new Size(49, 46);
            btnColorPicker.TabIndex = 6;
            btnColorPicker.UseVisualStyleBackColor = true;
            btnColorPicker.Click += btnColorPicker_Click;
            btnColorPicker.MouseDown += btnColorPicker_MouseDown;
            btnColorPicker.MouseUp += btnColorPicker_MouseUp;
            // 
            // frmColorSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(361, 209);
            Controls.Add(btnColorPicker);
            Controls.Add(btnSysytemColor);
            Controls.Add(panColor);
            Controls.Add(groupBox1);
            Controls.Add(btnClose);
            Controls.Add(btnApply);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmColorSetting";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Color Setting";
            FormClosing += frmColorSetting_FormClosing;
            Load += frmSetting_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnApply;
        private Button btnClose;
        private TextBox txtColorCode;
        private GroupBox groupBox1;
        private Label label1;
        private Panel panColor;
        private Button btnSysytemColor;
        private Button btnColorPicker;
        private ColorDialog colorDialog;
    }
}