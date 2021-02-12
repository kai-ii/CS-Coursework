namespace CSCoursework_Smiley
{
    partial class StaffControl
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlStaffScroll = new System.Windows.Forms.Panel();
            this.lstBoxDummy = new System.Windows.Forms.ListBox();
            this.lstBoxEmployees = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rBtnDetails = new System.Windows.Forms.RadioButton();
            this.rBtnGraphs = new System.Windows.Forms.RadioButton();
            this.rBtnNotes = new System.Windows.Forms.RadioButton();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.staffControlNotes1 = new CSCoursework_Smiley.StaffControlNotes();
            this.staffControlGraphs1 = new CSCoursework_Smiley.StaffControlGraphs();
            this.staffControlDetails1 = new CSCoursework_Smiley.StaffControlDetails();
            this.pnlStaffScroll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(7, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlStaffScroll
            // 
            this.pnlStaffScroll.AutoScroll = true;
            this.pnlStaffScroll.Controls.Add(this.lstBoxDummy);
            this.pnlStaffScroll.Controls.Add(this.lstBoxEmployees);
            this.pnlStaffScroll.Location = new System.Drawing.Point(3, 45);
            this.pnlStaffScroll.Name = "pnlStaffScroll";
            this.pnlStaffScroll.Size = new System.Drawing.Size(245, 591);
            this.pnlStaffScroll.TabIndex = 2;
            // 
            // lstBoxDummy
            // 
            this.lstBoxDummy.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxDummy.FormattingEnabled = true;
            this.lstBoxDummy.ItemHeight = 17;
            this.lstBoxDummy.Location = new System.Drawing.Point(0, 0);
            this.lstBoxDummy.Name = "lstBoxDummy";
            this.lstBoxDummy.ScrollAlwaysVisible = true;
            this.lstBoxDummy.Size = new System.Drawing.Size(245, 599);
            this.lstBoxDummy.TabIndex = 5;
            this.lstBoxDummy.Visible = false;
            this.lstBoxDummy.SelectedIndexChanged += new System.EventHandler(this.lstBoxDummy_SelectedIndexChanged);
            // 
            // lstBoxEmployees
            // 
            this.lstBoxEmployees.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxEmployees.FormattingEnabled = true;
            this.lstBoxEmployees.ItemHeight = 17;
            this.lstBoxEmployees.Location = new System.Drawing.Point(0, 0);
            this.lstBoxEmployees.Name = "lstBoxEmployees";
            this.lstBoxEmployees.Size = new System.Drawing.Size(227, 599);
            this.lstBoxEmployees.TabIndex = 4;
            this.lstBoxEmployees.Visible = false;
            this.lstBoxEmployees.SelectedIndexChanged += new System.EventHandler(this.lstBoxEmployees_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.staffControlNotes1);
            this.panel1.Controls.Add(this.staffControlGraphs1);
            this.panel1.Controls.Add(this.staffControlDetails1);
            this.panel1.Location = new System.Drawing.Point(255, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 585);
            this.panel1.TabIndex = 3;
            // 
            // rBtnDetails
            // 
            this.rBtnDetails.AutoSize = true;
            this.rBtnDetails.Location = new System.Drawing.Point(751, -1);
            this.rBtnDetails.Name = "rBtnDetails";
            this.rBtnDetails.Size = new System.Drawing.Size(57, 17);
            this.rBtnDetails.TabIndex = 4;
            this.rBtnDetails.TabStop = true;
            this.rBtnDetails.Text = "Details";
            this.rBtnDetails.UseVisualStyleBackColor = true;
            this.rBtnDetails.CheckedChanged += new System.EventHandler(this.rBtnDetails_CheckedChanged);
            // 
            // rBtnGraphs
            // 
            this.rBtnGraphs.AutoSize = true;
            this.rBtnGraphs.Location = new System.Drawing.Point(751, 14);
            this.rBtnGraphs.Name = "rBtnGraphs";
            this.rBtnGraphs.Size = new System.Drawing.Size(59, 17);
            this.rBtnGraphs.TabIndex = 5;
            this.rBtnGraphs.TabStop = true;
            this.rBtnGraphs.Text = "Graphs";
            this.rBtnGraphs.UseVisualStyleBackColor = true;
            this.rBtnGraphs.CheckedChanged += new System.EventHandler(this.rBtnGraphs_CheckedChanged);
            // 
            // rBtnNotes
            // 
            this.rBtnNotes.AutoSize = true;
            this.rBtnNotes.Location = new System.Drawing.Point(751, 29);
            this.rBtnNotes.Name = "rBtnNotes";
            this.rBtnNotes.Size = new System.Drawing.Size(53, 17);
            this.rBtnNotes.TabIndex = 6;
            this.rBtnNotes.TabStop = true;
            this.rBtnNotes.Text = "Notes";
            this.rBtnNotes.UseVisualStyleBackColor = true;
            this.rBtnNotes.CheckedChanged += new System.EventHandler(this.rBtnNotes_CheckedChanged);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "A-Z",
            "Z-A"});
            this.comboBoxSort.Location = new System.Drawing.Point(203, 12);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(45, 21);
            this.comboBoxSort.TabIndex = 7;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // staffControlNotes1
            // 
            this.staffControlNotes1.AbsenceTupleList = null;
            this.staffControlNotes1.GeneralNotes = "temp";
            this.staffControlNotes1.Location = new System.Drawing.Point(0, 0);
            this.staffControlNotes1.Name = "staffControlNotes1";
            this.staffControlNotes1.parentForm = null;
            this.staffControlNotes1.Size = new System.Drawing.Size(556, 585);
            this.staffControlNotes1.TabIndex = 2;
            this.staffControlNotes1.Load += new System.EventHandler(this.staffControlNotes1_Load);
            // 
            // staffControlGraphs1
            // 
            this.staffControlGraphs1.LineChartValues = new int[] {
        0};
            this.staffControlGraphs1.Location = new System.Drawing.Point(0, 0);
            this.staffControlGraphs1.Name = "staffControlGraphs1";
            this.staffControlGraphs1.PieChartData = null;
            this.staffControlGraphs1.Size = new System.Drawing.Size(556, 585);
            this.staffControlGraphs1.TabIndex = 1;
            // 
            // staffControlDetails1
            // 
            this.staffControlDetails1.Location = new System.Drawing.Point(0, 0);
            this.staffControlDetails1.Name = "staffControlDetails1";
            this.staffControlDetails1.Size = new System.Drawing.Size(556, 585);
            this.staffControlDetails1.Staff_details = null;
            this.staffControlDetails1.TabIndex = 0;
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.rBtnNotes);
            this.Controls.Add(this.rBtnGraphs);
            this.Controls.Add(this.rBtnDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlStaffScroll);
            this.Controls.Add(this.txtSearch);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.StaffControl_Load);
            this.pnlStaffScroll.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlStaffScroll;
        private System.Windows.Forms.Panel panel1;
        private StaffControlDetails staffControlDetails1;
        private System.Windows.Forms.ListBox lstBoxEmployees;
        private System.Windows.Forms.RadioButton rBtnDetails;
        private System.Windows.Forms.RadioButton rBtnGraphs;
        private System.Windows.Forms.RadioButton rBtnNotes;
        private StaffControlNotes staffControlNotes1;
        private StaffControlGraphs staffControlGraphs1;
        private System.Windows.Forms.ListBox lstBoxDummy;
        private System.Windows.Forms.ComboBox comboBoxSort;
    }
}
