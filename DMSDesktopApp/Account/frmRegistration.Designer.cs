namespace DMS.DesktopApp.Account
{
    partial class frmRegistration
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
            chkDatasoftEmployee = new CheckBox();
            cobQuestion = new ComboBox();
            label5 = new Label();
            cobRole = new ComboBox();
            label4 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAnswer = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnRegister = new Button();
            btnClose = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkDatasoftEmployee);
            groupBox1.Controls.Add(cobQuestion);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cobRole);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtAnswer);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Location = new Point(23, 11);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(356, 279);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // chkDatasoftEmployee
            // 
            chkDatasoftEmployee.AutoSize = true;
            chkDatasoftEmployee.Location = new Point(100, 244);
            chkDatasoftEmployee.Name = "chkDatasoftEmployee";
            chkDatasoftEmployee.Size = new Size(163, 19);
            chkDatasoftEmployee.TabIndex = 3;
            chkDatasoftEmployee.Tag = "Is this Datasoft Employee?";
            chkDatasoftEmployee.Text = "Is this Datasoft Employee?";
            chkDatasoftEmployee.UseVisualStyleBackColor = true;
            chkDatasoftEmployee.Visible = false;
            // 
            // cobQuestion
            // 
            cobQuestion.FormattingEnabled = true;
            cobQuestion.Location = new Point(99, 170);
            cobQuestion.Margin = new Padding(3, 2, 3, 2);
            cobQuestion.Name = "cobQuestion";
            cobQuestion.Size = new Size(238, 23);
            cobQuestion.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 170);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 1;
            label5.Tag = "Question";
            label5.Text = "Question";
            // 
            // cobRole
            // 
            cobRole.FormattingEnabled = true;
            cobRole.Location = new Point(99, 135);
            cobRole.Margin = new Padding(3, 2, 3, 2);
            cobRole.Name = "cobRole";
            cobRole.Size = new Size(238, 23);
            cobRole.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 138);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 1;
            label4.Tag = "Role";
            label4.Text = "Role";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 207);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 1;
            label6.Tag = "Answer";
            label6.Text = "Answer";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 100);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 1;
            label3.Tag = "Email";
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 68);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Tag = "Password";
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 34);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Tag = "Username";
            label1.Text = "Username";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(100, 205);
            txtAnswer.Margin = new Padding(3, 2, 3, 2);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(237, 23);
            txtAnswer.TabIndex = 0;
            txtAnswer.TextChanged += txtAnswer_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 98);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(237, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(100, 65);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(237, 23);
            txtPassword.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(100, 32);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(237, 23);
            txtUsername.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.RoyalBlue;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(158, 294);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(102, 30);
            btnRegister.TabIndex = 1;
            btnRegister.Tag = "Register";
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.IndianRed;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(276, 294);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 30);
            btnClose.TabIndex = 1;
            btnClose.Tag = "Close";
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(402, 331);
            Controls.Add(btnClose);
            Controls.Add(btnRegister);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmRegistration";
            Tag = "User Registration Form";
            Text = "User Registration Form";
            Load += frmRegistration_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtUsername;
        private ComboBox cobQuestion;
        private Label label5;
        private ComboBox cobRole;
        private Label label4;
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtAnswer;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnRegister;
        private Button btnClose;
        private CheckBox chkDatasoftEmployee;
    }
}