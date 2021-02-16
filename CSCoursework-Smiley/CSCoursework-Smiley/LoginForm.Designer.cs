﻿namespace CSCoursework_Smiley
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LeftPanelAnchor = new System.Windows.Forms.Panel();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.PictureBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.Sign_in_label = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.lblCreateAccount = new System.Windows.Forms.Label();
            this.SmileyLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxAnnouncement = new System.Windows.Forms.GroupBox();
            this.rTxtAnnouncementDetails = new System.Windows.Forms.RichTextBox();
            this.rTxtAnnouncementTitle = new System.Windows.Forms.RichTextBox();
            this.loginFormCreateAccount1 = new CSCoursework_Smiley.LoginFormCreateAccount();
            this.LeftPanelAnchor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmileyLogo)).BeginInit();
            this.groupBoxAnnouncement.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanelAnchor
            // 
            this.LeftPanelAnchor.BackColor = System.Drawing.Color.White;
            this.LeftPanelAnchor.Controls.Add(this.checkBoxShowPassword);
            this.LeftPanelAnchor.Controls.Add(this.button2);
            this.LeftPanelAnchor.Controls.Add(this.btnCreateAccount);
            this.LeftPanelAnchor.Controls.Add(this.btnSubmit);
            this.LeftPanelAnchor.Controls.Add(this.PasswordTextbox);
            this.LeftPanelAnchor.Controls.Add(this.UsernameTextbox);
            this.LeftPanelAnchor.Controls.Add(this.Sign_in_label);
            this.LeftPanelAnchor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanelAnchor.Location = new System.Drawing.Point(0, 0);
            this.LeftPanelAnchor.Name = "LeftPanelAnchor";
            this.LeftPanelAnchor.Size = new System.Drawing.Size(300, 710);
            this.LeftPanelAnchor.TabIndex = 0;
            this.LeftPanelAnchor.Paint += new System.Windows.Forms.PaintEventHandler(this.LeftPanelAnchor_Paint);
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(44, 158);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(117, 21);
            this.checkBoxShowPassword.TabIndex = 13;
            this.checkBoxShowPassword.Text = "Show Password";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(165)))), ((int)(((byte)(182)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(21, 591);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "Can\'t sign in?";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(165)))), ((int)(((byte)(182)))));
            this.btnCreateAccount.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.Location = new System.Drawing.Point(21, 556);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(142, 29);
            this.btnCreateAccount.TabIndex = 11;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Image = global::CSCoursework_Smiley.Properties.Resources.SigninSubmit;
            this.btnSubmit.InitialImage = null;
            this.btnSubmit.Location = new System.Drawing.Point(163, 177);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 114);
            this.btnSubmit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.Location = new System.Drawing.Point(44, 131);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(190, 23);
            this.PasswordTextbox.TabIndex = 2;
            this.PasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextbox_KeyDown);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextbox.Location = new System.Drawing.Point(44, 105);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(190, 23);
            this.UsernameTextbox.TabIndex = 1;
            this.UsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameTextbox_KeyDown);
            // 
            // Sign_in_label
            // 
            this.Sign_in_label.AutoSize = true;
            this.Sign_in_label.Font = new System.Drawing.Font("Century Gothic", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sign_in_label.Location = new System.Drawing.Point(12, 38);
            this.Sign_in_label.Name = "Sign_in_label";
            this.Sign_in_label.Size = new System.Drawing.Size(180, 49);
            this.Sign_in_label.TabIndex = 0;
            this.Sign_in_label.Text = "SIGN IN";
            // 
            // btnExit
            // 
            this.btnExit.Image = global::CSCoursework_Smiley.Properties.Resources.Close_Button;
            this.btnExit.Location = new System.Drawing.Point(1144, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // lblCreateAccount
            // 
            this.lblCreateAccount.AutoSize = true;
            this.lblCreateAccount.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateAccount.Location = new System.Drawing.Point(314, 13);
            this.lblCreateAccount.Name = "lblCreateAccount";
            this.lblCreateAccount.Size = new System.Drawing.Size(248, 36);
            this.lblCreateAccount.TabIndex = 3;
            this.lblCreateAccount.Text = "Create Account";
            this.lblCreateAccount.Visible = false;
            // 
            // SmileyLogo
            // 
            this.SmileyLogo.Image = ((System.Drawing.Image)(resources.GetObject("SmileyLogo.Image")));
            this.SmileyLogo.Location = new System.Drawing.Point(300, 635);
            this.SmileyLogo.Name = "SmileyLogo";
            this.SmileyLogo.Size = new System.Drawing.Size(366, 75);
            this.SmileyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SmileyLogo.TabIndex = 5;
            this.SmileyLogo.TabStop = false;
            // 
            // groupBoxAnnouncement
            // 
            this.groupBoxAnnouncement.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxAnnouncement.Controls.Add(this.rTxtAnnouncementTitle);
            this.groupBoxAnnouncement.Controls.Add(this.rTxtAnnouncementDetails);
            this.groupBoxAnnouncement.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAnnouncement.Location = new System.Drawing.Point(458, 177);
            this.groupBoxAnnouncement.Name = "groupBoxAnnouncement";
            this.groupBoxAnnouncement.Size = new System.Drawing.Size(552, 252);
            this.groupBoxAnnouncement.TabIndex = 6;
            this.groupBoxAnnouncement.TabStop = false;
            this.groupBoxAnnouncement.Text = "Announcement";
            // 
            // rTxtAnnouncementDetails
            // 
            this.rTxtAnnouncementDetails.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rTxtAnnouncementDetails.Location = new System.Drawing.Point(7, 59);
            this.rTxtAnnouncementDetails.Name = "rTxtAnnouncementDetails";
            this.rTxtAnnouncementDetails.ReadOnly = true;
            this.rTxtAnnouncementDetails.Size = new System.Drawing.Size(539, 187);
            this.rTxtAnnouncementDetails.TabIndex = 1;
            this.rTxtAnnouncementDetails.Text = "Announcement Contents";
            // 
            // rTxtAnnouncementTitle
            // 
            this.rTxtAnnouncementTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rTxtAnnouncementTitle.Location = new System.Drawing.Point(7, 25);
            this.rTxtAnnouncementTitle.Name = "rTxtAnnouncementTitle";
            this.rTxtAnnouncementTitle.ReadOnly = true;
            this.rTxtAnnouncementTitle.Size = new System.Drawing.Size(539, 32);
            this.rTxtAnnouncementTitle.TabIndex = 2;
            this.rTxtAnnouncementTitle.Text = "Announcement Title";
            // 
            // loginFormCreateAccount1
            // 
            this.loginFormCreateAccount1.Location = new System.Drawing.Point(299, 62);
            this.loginFormCreateAccount1.Name = "loginFormCreateAccount1";
            this.loginFormCreateAccount1.parentForm = null;
            this.loginFormCreateAccount1.Size = new System.Drawing.Size(882, 636);
            this.loginFormCreateAccount1.TabIndex = 4;
            this.loginFormCreateAccount1.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 710);
            this.Controls.Add(this.groupBoxAnnouncement);
            this.Controls.Add(this.SmileyLogo);
            this.Controls.Add(this.loginFormCreateAccount1);
            this.Controls.Add(this.lblCreateAccount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.LeftPanelAnchor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.LeftPanelAnchor.ResumeLayout(false);
            this.LeftPanelAnchor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmileyLogo)).EndInit();
            this.groupBoxAnnouncement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanelAnchor;
        private System.Windows.Forms.Label Sign_in_label;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.PictureBox btnSubmit;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Button button2;
        private LoginFormCreateAccount loginFormCreateAccount1;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.PictureBox SmileyLogo;
        private System.Windows.Forms.GroupBox groupBoxAnnouncement;
        private System.Windows.Forms.RichTextBox rTxtAnnouncementTitle;
        private System.Windows.Forms.RichTextBox rTxtAnnouncementDetails;
    }
}