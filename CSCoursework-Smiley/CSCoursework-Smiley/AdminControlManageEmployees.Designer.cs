namespace CSCoursework_Smiley
{
    partial class AdminControlManageEmployees
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
            this.lstBoxEmployees = new System.Windows.Forms.ListBox();
            this.lstBoxDummy = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.lblAccountManagement = new System.Windows.Forms.Label();
            this.adminControlManageEmployeesDetails1 = new CSCoursework_Smiley.AdminControlManageEmployeesDetails();
            this.SuspendLayout();
            // 
            // lstBoxEmployees
            // 
            this.lstBoxEmployees.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxEmployees.FormattingEnabled = true;
            this.lstBoxEmployees.ItemHeight = 17;
            this.lstBoxEmployees.Location = new System.Drawing.Point(3, 54);
            this.lstBoxEmployees.Name = "lstBoxEmployees";
            this.lstBoxEmployees.Size = new System.Drawing.Size(244, 599);
            this.lstBoxEmployees.TabIndex = 5;
            this.lstBoxEmployees.Visible = false;
            // 
            // lstBoxDummy
            // 
            this.lstBoxDummy.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxDummy.FormattingEnabled = true;
            this.lstBoxDummy.ItemHeight = 17;
            this.lstBoxDummy.Location = new System.Drawing.Point(3, 54);
            this.lstBoxDummy.Name = "lstBoxDummy";
            this.lstBoxDummy.ScrollAlwaysVisible = true;
            this.lstBoxDummy.Size = new System.Drawing.Size(245, 599);
            this.lstBoxDummy.TabIndex = 6;
            this.lstBoxDummy.Visible = false;
            this.lstBoxDummy.SelectedIndexChanged += new System.EventHandler(this.lstBoxDummy_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(5, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 21);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(5, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "A-Z",
            "Z-A"});
            this.comboBoxSort.Location = new System.Drawing.Point(202, 29);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(45, 21);
            this.comboBoxSort.TabIndex = 9;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // lblAccountManagement
            // 
            this.lblAccountManagement.AutoSize = true;
            this.lblAccountManagement.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountManagement.Location = new System.Drawing.Point(62, 4);
            this.lblAccountManagement.Name = "lblAccountManagement";
            this.lblAccountManagement.Size = new System.Drawing.Size(178, 20);
            this.lblAccountManagement.TabIndex = 10;
            this.lblAccountManagement.Text = "Account Management";
            // 
            // adminControlManageEmployeesDetails1
            // 
            this.adminControlManageEmployeesDetails1.Location = new System.Drawing.Point(258, 0);
            this.adminControlManageEmployeesDetails1.Name = "adminControlManageEmployeesDetails1";
            this.adminControlManageEmployeesDetails1.Size = new System.Drawing.Size(556, 636);
            this.adminControlManageEmployeesDetails1.TabIndex = 11;
            // 
            // AdminControlManageEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adminControlManageEmployeesDetails1);
            this.Controls.Add(this.lblAccountManagement);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lstBoxDummy);
            this.Controls.Add(this.lstBoxEmployees);
            this.Name = "AdminControlManageEmployees";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.AdminControlManageEmployees_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxEmployees;
        private System.Windows.Forms.ListBox lstBoxDummy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label lblAccountManagement;
        private AdminControlManageEmployeesDetails adminControlManageEmployeesDetails1;
    }
}
