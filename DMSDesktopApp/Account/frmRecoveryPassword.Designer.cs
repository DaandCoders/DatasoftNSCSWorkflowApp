namespace DMS.DesktopApp.Account
{
    partial class frmRecoveryPassword
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
            btnRecover = new Button();
            txtEmail = new TextBox();
            label1 = new Label();
            grbSecurityQandA = new GroupBox();
            btnSubmit = new Button();
            txtAnswer = new TextBox();
            txtQuestion = new TextBox();
            label3 = new Label();
            label2 = new Label();
            grbChangePassword = new GroupBox();
            btnChangePassword = new Button();
            txtConfirmNewPassword = new TextBox();
            txtNewPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            grbSecurityQandA.SuspendLayout();
            grbChangePassword.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRecover);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 17);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(669, 89);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Tag = "Recover Password";
            groupBox1.Text = "Recover Password";
            // 
            // btnRecover
            // 
            btnRecover.BackColor = Color.RoyalBlue;
            btnRecover.Cursor = Cursors.Hand;
            btnRecover.FlatStyle = FlatStyle.Flat;
            btnRecover.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecover.ForeColor = Color.White;
            btnRecover.Location = new Point(491, 46);
            btnRecover.Margin = new Padding(3, 2, 3, 2);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(141, 28);
            btnRecover.TabIndex = 2;
            btnRecover.Tag = "Recover";
            btnRecover.Text = "Recover";
            btnRecover.UseVisualStyleBackColor = false;
            btnRecover.Click += btnRecover_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(159, 25);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(312, 23);
            txtEmail.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 28);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Tag = "Email ID";
            label1.Text = "Email ID";
            // 
            // grbSecurityQandA
            // 
            grbSecurityQandA.Controls.Add(btnSubmit);
            grbSecurityQandA.Controls.Add(txtAnswer);
            grbSecurityQandA.Controls.Add(txtQuestion);
            grbSecurityQandA.Controls.Add(label3);
            grbSecurityQandA.Controls.Add(label2);
            grbSecurityQandA.Location = new Point(10, 111);
            grbSecurityQandA.Margin = new Padding(3, 2, 3, 2);
            grbSecurityQandA.Name = "grbSecurityQandA";
            grbSecurityQandA.Padding = new Padding(3, 2, 3, 2);
            grbSecurityQandA.Size = new Size(669, 131);
            grbSecurityQandA.TabIndex = 0;
            grbSecurityQandA.TabStop = false;
            grbSecurityQandA.Tag = "Security Question And Answer";
            grbSecurityQandA.Text = "Security Question And Answer";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.RoyalBlue;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(491, 90);
            btnSubmit.Margin = new Padding(3, 2, 3, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(141, 28);
            btnSubmit.TabIndex = 2;
            btnSubmit.Tag = "Submit";
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(159, 66);
            txtAnswer.Margin = new Padding(3, 2, 3, 2);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(312, 23);
            txtAnswer.TabIndex = 1;
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(159, 25);
            txtQuestion.Margin = new Padding(3, 2, 3, 2);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(312, 23);
            txtQuestion.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 66);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 0;
            label3.Tag = "Answer";
            label3.Text = "Answer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 28);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 0;
            label2.Tag = "Question";
            label2.Text = "Question";
            // 
            // grbChangePassword
            // 
            grbChangePassword.Controls.Add(btnChangePassword);
            grbChangePassword.Controls.Add(txtConfirmNewPassword);
            grbChangePassword.Controls.Add(txtNewPassword);
            grbChangePassword.Controls.Add(label4);
            grbChangePassword.Controls.Add(label5);
            grbChangePassword.Location = new Point(10, 247);
            grbChangePassword.Margin = new Padding(3, 2, 3, 2);
            grbChangePassword.Name = "grbChangePassword";
            grbChangePassword.Padding = new Padding(3, 2, 3, 2);
            grbChangePassword.Size = new Size(669, 131);
            grbChangePassword.TabIndex = 0;
            grbChangePassword.TabStop = false;
            grbChangePassword.Tag = "Change Password";
            grbChangePassword.Text = "Change Password";
            grbChangePassword.Enter += grbChangePassword_Enter;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.RoyalBlue;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(491, 90);
            btnChangePassword.Margin = new Padding(3, 2, 3, 2);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(141, 28);
            btnChangePassword.TabIndex = 2;
            btnChangePassword.Tag = "Change Password";
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Location = new Point(159, 66);
            txtConfirmNewPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.Size = new Size(312, 23);
            txtConfirmNewPassword.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(159, 25);
            txtNewPassword.Margin = new Padding(3, 2, 3, 2);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(312, 23);
            txtNewPassword.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 66);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 0;
            label4.Tag = "Confirm New Password";
            label4.Text = "Confirm New Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 28);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 0;
            label5.Tag = "New Password";
            label5.Text = "New Password";
            // 
            // frmRecoveryPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 396);
            Controls.Add(grbChangePassword);
            Controls.Add(grbSecurityQandA);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmRecoveryPassword";
            Tag = "Recovery Password";
            Text = "Recovery Password";
            Load += frmRecoveryPassword_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grbSecurityQandA.ResumeLayout(false);
            grbSecurityQandA.PerformLayout();
            grbChangePassword.ResumeLayout(false);
            grbChangePassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnRecover;
        private TextBox txtEmail;
        private Label label1;
        private GroupBox grbSecurityQandA;
        private Button btnSubmit;
        private TextBox txtAnswer;
        private TextBox txtQuestion;
        private Label label3;
        private Label label2;
        private GroupBox grbChangePassword;
        private Button btnChangePassword;
        private TextBox txtConfirmNewPassword;
        private TextBox txtNewPassword;
        private Label label4;
        private Label label5;
    }
}