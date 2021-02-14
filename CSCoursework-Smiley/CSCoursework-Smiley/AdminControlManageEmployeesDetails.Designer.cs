namespace CSCoursework_Smiley
{
    partial class AdminControlManageEmployeesDetails
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
            this.lblStaffMemberDetailsTitle = new System.Windows.Forms.Label();
            this.grpBoxAccountInfo = new System.Windows.Forms.GroupBox();
            this.lblForename = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblJobPosition = new System.Windows.Forms.Label();
            this.grpBoxAccountPermissions = new System.Windows.Forms.GroupBox();
            this.checkBoxDashboardPermission = new System.Windows.Forms.CheckBox();
            this.checkBoxStaffPersonalPermission = new System.Windows.Forms.CheckBox();
            this.checkBoxStaffAllPermission = new System.Windows.Forms.CheckBox();
            this.checkBoxRotaPermission = new System.Windows.Forms.CheckBox();
            this.checkBoxTimesheetPermission = new System.Windows.Forms.CheckBox();
            this.checkBoxPayslipPermission = new System.Windows.Forms.CheckBox();
            this.checkBoxExportPermission = new System.Windows.Forms.CheckBox();
            this.lblAccountNotCreatedWarning = new System.Windows.Forms.Label();
            this.grpBoxAccountInfo.SuspendLayout();
            this.grpBoxAccountPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStaffMemberDetailsTitle
            // 
            this.lblStaffMemberDetailsTitle.AutoSize = true;
            this.lblStaffMemberDetailsTitle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffMemberDetailsTitle.Location = new System.Drawing.Point(3, 4);
            this.lblStaffMemberDetailsTitle.Name = "lblStaffMemberDetailsTitle";
            this.lblStaffMemberDetailsTitle.Size = new System.Drawing.Size(164, 20);
            this.lblStaffMemberDetailsTitle.TabIndex = 0;
            this.lblStaffMemberDetailsTitle.Text = "staffMember - Details";
            // 
            // grpBoxAccountInfo
            // 
            this.grpBoxAccountInfo.Controls.Add(this.lblJobPosition);
            this.grpBoxAccountInfo.Controls.Add(this.lblSurname);
            this.grpBoxAccountInfo.Controls.Add(this.lblForename);
            this.grpBoxAccountInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxAccountInfo.Location = new System.Drawing.Point(7, 27);
            this.grpBoxAccountInfo.Name = "grpBoxAccountInfo";
            this.grpBoxAccountInfo.Size = new System.Drawing.Size(307, 85);
            this.grpBoxAccountInfo.TabIndex = 1;
            this.grpBoxAccountInfo.TabStop = false;
            this.grpBoxAccountInfo.Text = "Account Info";
            // 
            // lblForename
            // 
            this.lblForename.AutoSize = true;
            this.lblForename.Location = new System.Drawing.Point(6, 19);
            this.lblForename.Name = "lblForename";
            this.lblForename.Size = new System.Drawing.Size(168, 20);
            this.lblForename.TabIndex = 0;
            this.lblForename.Text = "Forename - forename";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(6, 39);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(147, 20);
            this.lblSurname.TabIndex = 1;
            this.lblSurname.Text = "Surname - surname";
            // 
            // lblJobPosition
            // 
            this.lblJobPosition.AutoSize = true;
            this.lblJobPosition.Location = new System.Drawing.Point(6, 59);
            this.lblJobPosition.Name = "lblJobPosition";
            this.lblJobPosition.Size = new System.Drawing.Size(187, 20);
            this.lblJobPosition.TabIndex = 2;
            this.lblJobPosition.Text = "Job Position - jobposition";
            // 
            // grpBoxAccountPermissions
            // 
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxExportPermission);
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxPayslipPermission);
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxTimesheetPermission);
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxRotaPermission);
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxStaffAllPermission);
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxStaffPersonalPermission);
            this.grpBoxAccountPermissions.Controls.Add(this.checkBoxDashboardPermission);
            this.grpBoxAccountPermissions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxAccountPermissions.Location = new System.Drawing.Point(7, 118);
            this.grpBoxAccountPermissions.Name = "grpBoxAccountPermissions";
            this.grpBoxAccountPermissions.Size = new System.Drawing.Size(307, 178);
            this.grpBoxAccountPermissions.TabIndex = 3;
            this.grpBoxAccountPermissions.TabStop = false;
            this.grpBoxAccountPermissions.Text = "Account Permissions";
            // 
            // checkBoxDashboardPermission
            // 
            this.checkBoxDashboardPermission.AutoSize = true;
            this.checkBoxDashboardPermission.Location = new System.Drawing.Point(10, 22);
            this.checkBoxDashboardPermission.Name = "checkBoxDashboardPermission";
            this.checkBoxDashboardPermission.Size = new System.Drawing.Size(109, 24);
            this.checkBoxDashboardPermission.TabIndex = 7;
            this.checkBoxDashboardPermission.Text = "Dashboard";
            this.checkBoxDashboardPermission.UseVisualStyleBackColor = true;
            // 
            // checkBoxStaffPersonalPermission
            // 
            this.checkBoxStaffPersonalPermission.AutoSize = true;
            this.checkBoxStaffPersonalPermission.Location = new System.Drawing.Point(10, 43);
            this.checkBoxStaffPersonalPermission.Name = "checkBoxStaffPersonalPermission";
            this.checkBoxStaffPersonalPermission.Size = new System.Drawing.Size(136, 24);
            this.checkBoxStaffPersonalPermission.TabIndex = 8;
            this.checkBoxStaffPersonalPermission.Text = "Staff (Personal)";
            this.checkBoxStaffPersonalPermission.UseVisualStyleBackColor = true;
            // 
            // checkBoxStaffAllPermission
            // 
            this.checkBoxStaffAllPermission.AutoSize = true;
            this.checkBoxStaffAllPermission.Location = new System.Drawing.Point(10, 64);
            this.checkBoxStaffAllPermission.Name = "checkBoxStaffAllPermission";
            this.checkBoxStaffAllPermission.Size = new System.Drawing.Size(91, 24);
            this.checkBoxStaffAllPermission.TabIndex = 9;
            this.checkBoxStaffAllPermission.Text = "Staff (All)";
            this.checkBoxStaffAllPermission.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotaPermission
            // 
            this.checkBoxRotaPermission.AutoSize = true;
            this.checkBoxRotaPermission.Location = new System.Drawing.Point(10, 85);
            this.checkBoxRotaPermission.Name = "checkBoxRotaPermission";
            this.checkBoxRotaPermission.Size = new System.Drawing.Size(62, 24);
            this.checkBoxRotaPermission.TabIndex = 10;
            this.checkBoxRotaPermission.Text = "Rota";
            this.checkBoxRotaPermission.UseVisualStyleBackColor = true;
            // 
            // checkBoxTimesheetPermission
            // 
            this.checkBoxTimesheetPermission.AutoSize = true;
            this.checkBoxTimesheetPermission.Location = new System.Drawing.Point(10, 105);
            this.checkBoxTimesheetPermission.Name = "checkBoxTimesheetPermission";
            this.checkBoxTimesheetPermission.Size = new System.Drawing.Size(99, 24);
            this.checkBoxTimesheetPermission.TabIndex = 11;
            this.checkBoxTimesheetPermission.Text = "Timesheet";
            this.checkBoxTimesheetPermission.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayslipPermission
            // 
            this.checkBoxPayslipPermission.AutoSize = true;
            this.checkBoxPayslipPermission.Location = new System.Drawing.Point(10, 125);
            this.checkBoxPayslipPermission.Name = "checkBoxPayslipPermission";
            this.checkBoxPayslipPermission.Size = new System.Drawing.Size(77, 24);
            this.checkBoxPayslipPermission.TabIndex = 12;
            this.checkBoxPayslipPermission.Text = "Payslip";
            this.checkBoxPayslipPermission.UseVisualStyleBackColor = true;
            // 
            // checkBoxExportPermission
            // 
            this.checkBoxExportPermission.AutoSize = true;
            this.checkBoxExportPermission.Location = new System.Drawing.Point(10, 145);
            this.checkBoxExportPermission.Name = "checkBoxExportPermission";
            this.checkBoxExportPermission.Size = new System.Drawing.Size(73, 24);
            this.checkBoxExportPermission.TabIndex = 13;
            this.checkBoxExportPermission.Text = "Export";
            this.checkBoxExportPermission.UseVisualStyleBackColor = true;
            // 
            // lblAccountNotCreatedWarning
            // 
            this.lblAccountNotCreatedWarning.AutoSize = true;
            this.lblAccountNotCreatedWarning.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNotCreatedWarning.ForeColor = System.Drawing.Color.Maroon;
            this.lblAccountNotCreatedWarning.Location = new System.Drawing.Point(3, 299);
            this.lblAccountNotCreatedWarning.Name = "lblAccountNotCreatedWarning";
            this.lblAccountNotCreatedWarning.Size = new System.Drawing.Size(332, 21);
            this.lblAccountNotCreatedWarning.TabIndex = 4;
            this.lblAccountNotCreatedWarning.Text = "Warning: Account has not been created.";
            this.lblAccountNotCreatedWarning.Visible = false;
            // 
            // AdminControlManageEmployeesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAccountNotCreatedWarning);
            this.Controls.Add(this.grpBoxAccountPermissions);
            this.Controls.Add(this.grpBoxAccountInfo);
            this.Controls.Add(this.lblStaffMemberDetailsTitle);
            this.Name = "AdminControlManageEmployeesDetails";
            this.Size = new System.Drawing.Size(556, 636);
            this.Load += new System.EventHandler(this.AdminControlManageEmployeesDetails_Load);
            this.grpBoxAccountInfo.ResumeLayout(false);
            this.grpBoxAccountInfo.PerformLayout();
            this.grpBoxAccountPermissions.ResumeLayout(false);
            this.grpBoxAccountPermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffMemberDetailsTitle;
        private System.Windows.Forms.GroupBox grpBoxAccountInfo;
        private System.Windows.Forms.Label lblJobPosition;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblForename;
        private System.Windows.Forms.GroupBox grpBoxAccountPermissions;
        private System.Windows.Forms.CheckBox checkBoxStaffPersonalPermission;
        private System.Windows.Forms.CheckBox checkBoxDashboardPermission;
        private System.Windows.Forms.CheckBox checkBoxStaffAllPermission;
        private System.Windows.Forms.CheckBox checkBoxRotaPermission;
        private System.Windows.Forms.CheckBox checkBoxTimesheetPermission;
        private System.Windows.Forms.CheckBox checkBoxPayslipPermission;
        private System.Windows.Forms.CheckBox checkBoxExportPermission;
        private System.Windows.Forms.Label lblAccountNotCreatedWarning;
    }
}
