namespace CSCoursework_Smiley
{
    partial class AdminControlAddNewStaff
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
            this.btnBack = new System.Windows.Forms.Button();
            this.grpBoxAddNewStaff = new System.Windows.Forms.GroupBox();
            this.lblPersonalDetails = new System.Windows.Forms.Label();
            this.lblForename = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblNINumber = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblEmploymentDetails = new System.Windows.Forms.Label();
            this.lblContractType = new System.Windows.Forms.Label();
            this.lblContractedWeeklyHours = new System.Windows.Forms.Label();
            this.grpBoxAddNewStaff.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpBoxAddNewStaff
            // 
            this.grpBoxAddNewStaff.Controls.Add(this.lblContractedWeeklyHours);
            this.grpBoxAddNewStaff.Controls.Add(this.lblContractType);
            this.grpBoxAddNewStaff.Controls.Add(this.lblEmploymentDetails);
            this.grpBoxAddNewStaff.Controls.Add(this.lblGender);
            this.grpBoxAddNewStaff.Controls.Add(this.lblDateOfBirth);
            this.grpBoxAddNewStaff.Controls.Add(this.lblNINumber);
            this.grpBoxAddNewStaff.Controls.Add(this.lblSurname);
            this.grpBoxAddNewStaff.Controls.Add(this.lblForename);
            this.grpBoxAddNewStaff.Controls.Add(this.lblPersonalDetails);
            this.grpBoxAddNewStaff.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxAddNewStaff.Location = new System.Drawing.Point(4, 34);
            this.grpBoxAddNewStaff.Name = "grpBoxAddNewStaff";
            this.grpBoxAddNewStaff.Size = new System.Drawing.Size(807, 554);
            this.grpBoxAddNewStaff.TabIndex = 1;
            this.grpBoxAddNewStaff.TabStop = false;
            this.grpBoxAddNewStaff.Text = "Add new staff";
            // 
            // lblPersonalDetails
            // 
            this.lblPersonalDetails.AutoSize = true;
            this.lblPersonalDetails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalDetails.Location = new System.Drawing.Point(7, 26);
            this.lblPersonalDetails.Name = "lblPersonalDetails";
            this.lblPersonalDetails.Size = new System.Drawing.Size(222, 21);
            this.lblPersonalDetails.TabIndex = 0;
            this.lblPersonalDetails.Text = "Personal Details (*Required)";
            // 
            // lblForename
            // 
            this.lblForename.AutoSize = true;
            this.lblForename.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForename.Location = new System.Drawing.Point(7, 47);
            this.lblForename.Name = "lblForename";
            this.lblForename.Size = new System.Drawing.Size(89, 20);
            this.lblForename.TabIndex = 1;
            this.lblForename.Text = "Forename*";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(7, 67);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(78, 20);
            this.lblSurname.TabIndex = 2;
            this.lblSurname.Text = "Surname*";
            // 
            // lblNINumber
            // 
            this.lblNINumber.AutoSize = true;
            this.lblNINumber.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNINumber.Location = new System.Drawing.Point(7, 87);
            this.lblNINumber.Name = "lblNINumber";
            this.lblNINumber.Size = new System.Drawing.Size(87, 20);
            this.lblNINumber.TabIndex = 3;
            this.lblNINumber.Text = "NI Number";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.Location = new System.Drawing.Point(7, 107);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(151, 20);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "DoB (dd/mm/yyyy)*";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(7, 127);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(72, 20);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender*";
            // 
            // lblEmploymentDetails
            // 
            this.lblEmploymentDetails.AutoSize = true;
            this.lblEmploymentDetails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmploymentDetails.Location = new System.Drawing.Point(7, 164);
            this.lblEmploymentDetails.Name = "lblEmploymentDetails";
            this.lblEmploymentDetails.Size = new System.Drawing.Size(164, 21);
            this.lblEmploymentDetails.TabIndex = 6;
            this.lblEmploymentDetails.Text = "Employment Details";
            // 
            // lblContractType
            // 
            this.lblContractType.AutoSize = true;
            this.lblContractType.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContractType.Location = new System.Drawing.Point(7, 185);
            this.lblContractType.Name = "lblContractType";
            this.lblContractType.Size = new System.Drawing.Size(112, 20);
            this.lblContractType.TabIndex = 7;
            this.lblContractType.Text = "Contract Type";
            // 
            // lblContractedWeeklyHours
            // 
            this.lblContractedWeeklyHours.AutoSize = true;
            this.lblContractedWeeklyHours.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContractedWeeklyHours.Location = new System.Drawing.Point(7, 205);
            this.lblContractedWeeklyHours.Name = "lblContractedWeeklyHours";
            this.lblContractedWeeklyHours.Size = new System.Drawing.Size(171, 20);
            this.lblContractedWeeklyHours.TabIndex = 8;
            this.lblContractedWeeklyHours.Text = "[Select Contract Type]";
            // 
            // AdminControlAddNewStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxAddNewStaff);
            this.Controls.Add(this.btnBack);
            this.Name = "AdminControlAddNewStaff";
            this.Size = new System.Drawing.Size(814, 636);
            this.grpBoxAddNewStaff.ResumeLayout(false);
            this.grpBoxAddNewStaff.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grpBoxAddNewStaff;
        private System.Windows.Forms.Label lblPersonalDetails;
        private System.Windows.Forms.Label lblForename;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblNINumber;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblEmploymentDetails;
        private System.Windows.Forms.Label lblContractType;
        private System.Windows.Forms.Label lblContractedWeeklyHours;
    }
}
