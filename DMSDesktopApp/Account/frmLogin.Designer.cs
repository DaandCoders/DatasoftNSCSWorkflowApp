namespace DMS.DesktopApp.Account
{
    partial class frmLogin
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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblEmailID = new Label();
            lblPassword = new Label();
            lblForgotPassword = new Label();
            groupBox1 = new GroupBox();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(115, 45);
            txtEmail.Margin = new Padding(4, 0, 4, 0);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(274, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(115, 77);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(274, 23);
            txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.RoyalBlue;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(194, 147);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 26);
            btnLogin.TabIndex = 3;
            btnLogin.Tag = "Login";
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.IndianRed;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(295, 147);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 26);
            btnExit.TabIndex = 4;
            btnExit.Tag = "Exit";
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblEmailID
            // 
            lblEmailID.AutoSize = true;
            lblEmailID.Location = new Point(52, 47);
            lblEmailID.Name = "lblEmailID";
            lblEmailID.Size = new Size(50, 15);
            lblEmailID.TabIndex = 4;
            lblEmailID.Tag = "Email ID";
            lblEmailID.Text = "Email ID";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(47, 81);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Tag = "Password";
            lblPassword.Text = "Password";
            // 
            // lblForgotPassword
            // 
            lblForgotPassword.AutoSize = true;
            lblForgotPassword.Location = new Point(47, 152);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(103, 15);
            lblForgotPassword.TabIndex = 5;
            lblForgotPassword.Tag = "Forgot Password ?";
            lblForgotPassword.Text = "Forgot Password ?";
            lblForgotPassword.Click += lblForgotPassword_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Location = new Point(13, 23);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(408, 100);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnExit;
            ClientSize = new Size(431, 197);
            Controls.Add(lblForgotPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblEmailID);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "Login";
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblEmailID;
        private Label lblPassword;
        private Label lblForgotPassword;
        private GroupBox groupBox1;
    }
}