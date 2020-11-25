namespace CSCoursework_Smiley
{
    partial class StaffControlDetails
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
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.grpEmployment = new System.Windows.Forms.GroupBox();
            this.grpContactInfo = new System.Windows.Forms.GroupBox();
            this.grpEmploymentInfo = new System.Windows.Forms.GroupBox();
            this.grpPaymentDetails = new System.Windows.Forms.GroupBox();
            this.lblAddressStreet = new System.Windows.Forms.Label();
            this.lblAddressCity = new System.Windows.Forms.Label();
            this.lblAddressCounty = new System.Windows.Forms.Label();
            this.lblAddressPostcode = new System.Windows.Forms.Label();
            this.grpAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.lblAddressPostcode);
            this.grpAddress.Controls.Add(this.lblAddressCounty);
            this.grpAddress.Controls.Add(this.lblAddressCity);
            this.grpAddress.Controls.Add(this.lblAddressStreet);
            this.grpAddress.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddress.Location = new System.Drawing.Point(3, 3);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(549, 111);
            this.grpAddress.TabIndex = 0;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "Address";
            // 
            // grpEmployment
            // 
            this.grpEmployment.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmployment.Location = new System.Drawing.Point(3, 120);
            this.grpEmployment.Name = "grpEmployment";
            this.grpEmployment.Size = new System.Drawing.Size(549, 111);
            this.grpEmployment.TabIndex = 1;
            this.grpEmployment.TabStop = false;
            this.grpEmployment.Text = "Employment";
            // 
            // grpContactInfo
            // 
            this.grpContactInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpContactInfo.Location = new System.Drawing.Point(4, 237);
            this.grpContactInfo.Name = "grpContactInfo";
            this.grpContactInfo.Size = new System.Drawing.Size(549, 111);
            this.grpContactInfo.TabIndex = 1;
            this.grpContactInfo.TabStop = false;
            this.grpContactInfo.Text = "Contact Info";
            // 
            // grpEmploymentInfo
            // 
            this.grpEmploymentInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmploymentInfo.Location = new System.Drawing.Point(3, 354);
            this.grpEmploymentInfo.Name = "grpEmploymentInfo";
            this.grpEmploymentInfo.Size = new System.Drawing.Size(549, 111);
            this.grpEmploymentInfo.TabIndex = 1;
            this.grpEmploymentInfo.TabStop = false;
            this.grpEmploymentInfo.Text = "Employment Info";
            // 
            // grpPaymentDetails
            // 
            this.grpPaymentDetails.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaymentDetails.Location = new System.Drawing.Point(4, 471);
            this.grpPaymentDetails.Name = "grpPaymentDetails";
            this.grpPaymentDetails.Size = new System.Drawing.Size(549, 111);
            this.grpPaymentDetails.TabIndex = 1;
            this.grpPaymentDetails.TabStop = false;
            this.grpPaymentDetails.Text = "Payment Details";
            // 
            // lblAddressStreet
            // 
            this.lblAddressStreet.AutoSize = true;
            this.lblAddressStreet.Location = new System.Drawing.Point(7, 26);
            this.lblAddressStreet.Name = "lblAddressStreet";
            this.lblAddressStreet.Size = new System.Drawing.Size(50, 20);
            this.lblAddressStreet.TabIndex = 0;
            this.lblAddressStreet.Text = "street";
            // 
            // lblAddressCity
            // 
            this.lblAddressCity.AutoSize = true;
            this.lblAddressCity.Location = new System.Drawing.Point(7, 46);
            this.lblAddressCity.Name = "lblAddressCity";
            this.lblAddressCity.Size = new System.Drawing.Size(35, 20);
            this.lblAddressCity.TabIndex = 1;
            this.lblAddressCity.Text = "city";
            // 
            // lblAddressCounty
            // 
            this.lblAddressCounty.AutoSize = true;
            this.lblAddressCounty.Location = new System.Drawing.Point(7, 66);
            this.lblAddressCounty.Name = "lblAddressCounty";
            this.lblAddressCounty.Size = new System.Drawing.Size(60, 20);
            this.lblAddressCounty.TabIndex = 2;
            this.lblAddressCounty.Text = "county";
            // 
            // lblAddressPostcode
            // 
            this.lblAddressPostcode.AutoSize = true;
            this.lblAddressPostcode.Location = new System.Drawing.Point(7, 86);
            this.lblAddressPostcode.Name = "lblAddressPostcode";
            this.lblAddressPostcode.Size = new System.Drawing.Size(80, 20);
            this.lblAddressPostcode.TabIndex = 3;
            this.lblAddressPostcode.Text = "postcode";
            // 
            // StaffControlDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPaymentDetails);
            this.Controls.Add(this.grpEmploymentInfo);
            this.Controls.Add(this.grpContactInfo);
            this.Controls.Add(this.grpEmployment);
            this.Controls.Add(this.grpAddress);
            this.Name = "StaffControlDetails";
            this.Size = new System.Drawing.Size(556, 585);
            this.Load += new System.EventHandler(this.StaffControlDetails_Load);
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.GroupBox grpEmployment;
        private System.Windows.Forms.GroupBox grpContactInfo;
        private System.Windows.Forms.GroupBox grpEmploymentInfo;
        private System.Windows.Forms.GroupBox grpPaymentDetails;
        private System.Windows.Forms.Label lblAddressPostcode;
        private System.Windows.Forms.Label lblAddressCounty;
        private System.Windows.Forms.Label lblAddressCity;
        private System.Windows.Forms.Label lblAddressStreet;
    }
}
