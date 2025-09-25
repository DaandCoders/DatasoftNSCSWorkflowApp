namespace CoreWorkflow
{
    partial class FileReceivePlanning
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
            cmbSection = new ComboBox();
            cmbSubsection = new ComboBox();
            pnlContainer = new Panel();
            label1 = new Label();
            lblSubSection = new Label();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbSection
            // 
            cmbSection.Dock = DockStyle.Fill;
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(86, 14);
            cmbSection.Margin = new Padding(3, 4, 3, 4);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(215, 28);
            cmbSection.TabIndex = 0;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged;
            // 
            // cmbSubsection
            // 
            cmbSubsection.Dock = DockStyle.Fill;
            cmbSubsection.FormattingEnabled = true;
            cmbSubsection.Location = new Point(423, 14);
            cmbSubsection.Margin = new Padding(3, 4, 3, 4);
            cmbSubsection.Name = "cmbSubsection";
            cmbSubsection.Size = new Size(293, 28);
            cmbSubsection.TabIndex = 1;
            cmbSubsection.SelectedIndexChanged += cmbSubsection_SelectedIndexChanged;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Margin = new Padding(3, 4, 3, 4);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1094, 645);
            pnlContainer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(67, 31);
            label1.TabIndex = 3;
            label1.Tag = "Section";
            label1.Text = "Section";
            // 
            // lblSubSection
            // 
            lblSubSection.AutoSize = true;
            lblSubSection.Dock = DockStyle.Fill;
            lblSubSection.Font = new Font("Segoe UI", 9.75F);
            lblSubSection.Location = new Point(307, 10);
            lblSubSection.Name = "lblSubSection";
            lblSubSection.Size = new Size(110, 31);
            lblSubSection.TabIndex = 4;
            lblSubSection.Tag = "Sub-Section";
            lblSubSection.Text = "Sub-Section";
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
            splitContainer1.Panel2.Controls.Add(pnlContainer);
            splitContainer1.Size = new Size(1094, 700);
            splitContainer1.SplitterDistance = 51;
            splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.2961922F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.1706638F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.3610725F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.1720734F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 364F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbSection, 1, 0);
            tableLayoutPanel1.Controls.Add(cmbSubsection, 3, 0);
            tableLayoutPanel1.Controls.Add(lblSubSection, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1094, 51);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // FileReceivePlanning
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FileReceivePlanning";
            Size = new Size(1094, 700);
            Load += FileReceivePlanning_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbSection;
        private ComboBox cmbSubsection;
        private Panel pnlContainer;
        private Label label1;
        private Label lblSubSection;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
