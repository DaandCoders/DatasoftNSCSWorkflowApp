namespace DMS.DesktopApp.Account
{
    partial class frmChangePassword
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
            txtConfirmPassword = new TextBox();
            label3 = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnChangePassword = new Button();
            btnClose = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConfirmPassword);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCurrentPassword);
            groupBox1.Controls.Add(txtNewPassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 16);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(401, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(119, 98);
            txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(260, 23);
            txtConfirmPassword.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 103);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 0;
            label3.Tag = "Confirm Password";
            label3.Text = "Confirm Password";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(122, 32);
            txtCurrentPassword.Margin = new Padding(3, 2, 3, 2);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(260, 23);
            txtCurrentPassword.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(122, 66);
            txtNewPassword.Margin = new Padding(3, 2, 3, 2);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(260, 23);
            txtNewPassword.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 66);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 0;
            label2.Tag = "New Password";
            label2.Text = "New Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 34);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 0;
            label1.Tag = "Current Password";
            label1.Text = "Current Password";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.RoyalBlue;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(130, 181);
            btnChangePassword.Margin = new Padding(4, 3, 4, 3);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(144, 24);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Tag = "Change Password";
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(280, 181);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 24);
            btnClose.TabIndex = 1;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(431, 222);
            Controls.Add(btnClose);
            Controls.Add(btnChangePassword);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "Change Password";
            Text = "Change Password";
            Load += frmChangePassword_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtConfirmPassword;
        private Label label3;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private Label label2;
        private Label label1;
        private Button btnChangePassword;
        private Button btnClose;
    }
}