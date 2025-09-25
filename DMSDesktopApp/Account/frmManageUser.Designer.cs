namespace DMS.DesktopApp.Account
{
    partial class frmManageUser
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
            btnSave = new Button();
            cbActive = new CheckBox();
            cobRole = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            label5 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvUserData = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserData).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(cbActive);
            groupBox1.Controls.Add(cobRole);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 16);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(679, 182);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(510, 142);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 24);
            btnSave.TabIndex = 4;
            btnSave.Tag = "Save";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cbActive
            // 
            cbActive.AutoSize = true;
            cbActive.Location = new Point(150, 142);
            cbActive.Margin = new Padding(3, 2, 3, 2);
            cbActive.Name = "cbActive";
            cbActive.Size = new Size(15, 14);
            cbActive.TabIndex = 3;
            cbActive.UseVisualStyleBackColor = true;
            // 
            // cobRole
            // 
            cobRole.FormattingEnabled = true;
            cobRole.Location = new Point(148, 100);
            cobRole.Margin = new Padding(3, 2, 3, 2);
            cobRole.Name = "cobRole";
            cobRole.Size = new Size(327, 23);
            cobRole.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 140);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 0;
            label4.Tag = "Active";
            label4.Text = "Active";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 104);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 0;
            label3.Tag = "Role";
            label3.Text = "Role";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(148, 66);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 23);
            txtEmail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 68);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 0;
            label2.Tag = "Email";
            label2.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(148, 35);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 23);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 38);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Tag = "Username";
            label1.Text = "Username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 222);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 0;
            label5.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(133, 220);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(374, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.RoyalBlue;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(521, 218);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(141, 24);
            btnSearch.TabIndex = 4;
            btnSearch.Tag = "Search";
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvUserData
            // 
            dgvUserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserData.Location = new Point(10, 254);
            dgvUserData.Margin = new Padding(4, 3, 4, 3);
            dgvUserData.Name = "dgvUserData";
            dgvUserData.RowHeadersWidth = 51;
            dgvUserData.RowTemplate.Height = 29;
            dgvUserData.Size = new Size(683, 215);
            dgvUserData.TabIndex = 5;
            dgvUserData.SelectionChanged += dgvUserData_SelectionChanged;
            // 
            // frmManageUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 482);
            Controls.Add(dgvUserData);
            Controls.Add(btnSearch);
            Controls.Add(groupBox1);
            Controls.Add(txtSearch);
            Controls.Add(label5);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmManageUser";
            Tag = "Manage User";
            Text = "Manage User";
            Load += frmManageUser_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox cbActive;
        private ComboBox cobRole;
        private Label label4;
        private Label label3;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtUsername;
        private Label label1;
        private Button btnSave;
        private Label label5;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvUserData;
    }
}