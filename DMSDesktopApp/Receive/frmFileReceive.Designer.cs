namespace DMS.DesktopApp.Receive
{
    partial class frmFileReceieve
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContainer = new Panel();
            cmbDepartments = new ComboBox();
            lblDepartments = new Label();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Margin = new Padding(3, 4, 3, 4);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1142, 674);
            panelContainer.TabIndex = 0;
            // 
            // cmbDepartments
            // 
            cmbDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartments.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbDepartments.FormattingEnabled = true;
            cmbDepartments.Location = new Point(151, 14);
            cmbDepartments.Margin = new Padding(3, 4, 3, 4);
            cmbDepartments.Name = "cmbDepartments";
            cmbDepartments.Size = new Size(377, 29);
            cmbDepartments.TabIndex = 1;
            cmbDepartments.SelectedIndexChanged += cmbDepartments_SelectedIndexChanged;
            // 
            // lblDepartments
            // 
            lblDepartments.AutoSize = true;
            lblDepartments.Dock = DockStyle.Fill;
            lblDepartments.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartments.Location = new Point(13, 10);
            lblDepartments.Name = "lblDepartments";
            lblDepartments.Size = new Size(132, 38);
            lblDepartments.TabIndex = 2;
            lblDepartments.Tag = "DEPARTMENTS";
            lblDepartments.Text = "Departments";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelContainer);
            splitContainer1.Size = new Size(1142, 736);
            splitContainer1.SplitterDistance = 58;
            splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.34676F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.65324F));
            tableLayoutPanel1.Controls.Add(cmbDepartments, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDepartments, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1142, 58);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // frmFileReceieve
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1142, 736);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(1160, 783);
            MinimumSize = new Size(1160, 783);
            Name = "frmFileReceieve";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Workflow";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
        private ComboBox cmbDepartments;
        private Label lblDepartments;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
