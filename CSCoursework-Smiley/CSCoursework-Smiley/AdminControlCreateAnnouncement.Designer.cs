namespace CSCoursework_Smiley
{
    partial class AdminControlCreateAnnouncement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblAnnouncementTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnnouncementTitle = new System.Windows.Forms.TextBox();
            this.rTxtAnnouncementDetails = new System.Windows.Forms.RichTextBox();
            this.btnSubmitAnnouncement = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rTxtAnnouncementDetails);
            this.groupBox1.Controls.Add(this.txtAnnouncementTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblAnnouncementTitle);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 522);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Announcement";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(9, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblAnnouncementTitle
            // 
            this.lblAnnouncementTitle.AutoSize = true;
            this.lblAnnouncementTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementTitle.Location = new System.Drawing.Point(2, 27);
            this.lblAnnouncementTitle.Name = "lblAnnouncementTitle";
            this.lblAnnouncementTitle.Size = new System.Drawing.Size(170, 21);
            this.lblAnnouncementTitle.TabIndex = 0;
            this.lblAnnouncementTitle.Text = "Announcement Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Announcement Details";
            // 
            // txtAnnouncementTitle
            // 
            this.txtAnnouncementTitle.Location = new System.Drawing.Point(178, 23);
            this.txtAnnouncementTitle.Name = "txtAnnouncementTitle";
            this.txtAnnouncementTitle.Size = new System.Drawing.Size(624, 31);
            this.txtAnnouncementTitle.TabIndex = 2;
            // 
            // rTxtAnnouncementDetails
            // 
            this.rTxtAnnouncementDetails.Location = new System.Drawing.Point(6, 81);
            this.rTxtAnnouncementDetails.Name = "rTxtAnnouncementDetails";
            this.rTxtAnnouncementDetails.Size = new System.Drawing.Size(796, 435);
            this.rTxtAnnouncementDetails.TabIndex = 3;
            this.rTxtAnnouncementDetails.Text = "";
            // 
            // btnSubmitAnnouncement
            // 
            this.btnSubmitAnnouncement.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitAnnouncement.Location = new System.Drawing.Point(691, 561);
            this.btnSubmitAnnouncement.Name = "btnSubmitAnnouncement";
            this.btnSubmitAnnouncement.Size = new System.Drawing.Size(114, 37);
            this.btnSubmitAnnouncement.TabIndex = 13;
            this.btnSubmitAnnouncement.Text = "Submit";
            this.btnSubmitAnnouncement.UseVisualStyleBackColor = true;
            this.btnSubmitAnnouncement.Click += new System.EventHandler(this.btnSubmitAnnouncement_Click);
            // 
            // AdminControlCreateAnnouncement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmitAnnouncement);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminControlCreateAnnouncement";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.AdminControlCreateAnnouncement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAnnouncementTitle;
        private System.Windows.Forms.TextBox txtAnnouncementTitle;
        private System.Windows.Forms.RichTextBox rTxtAnnouncementDetails;
        private System.Windows.Forms.Button btnSubmitAnnouncement;
    }
}
