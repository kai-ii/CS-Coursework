namespace CSCoursework_Smiley.Properties
{
    partial class SettingsControl
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.grpBoxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpBoxColourScheme = new System.Windows.Forms.GroupBox();
            this.btnResetColourToDefault = new System.Windows.Forms.Button();
            this.btnSaveNewColour = new System.Windows.Forms.Button();
            this.btnEditHighlightColour = new System.Windows.Forms.Button();
            this.btnEditBackgroundColour = new System.Windows.Forms.Button();
            this.txtHighlightColour = new System.Windows.Forms.TextBox();
            this.txtBackgroundColour = new System.Windows.Forms.TextBox();
            this.btnHighlightColour = new System.Windows.Forms.Button();
            this.btnBackgroundColour = new System.Windows.Forms.Button();
            this.checkBoxShowDateAndTime = new System.Windows.Forms.CheckBox();
            this.grpBoxPersonalInfo.SuspendLayout();
            this.grpBoxColourScheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(10, 78);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(143, 29);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // grpBoxPersonalInfo
            // 
            this.grpBoxPersonalInfo.Controls.Add(this.txtUsername);
            this.grpBoxPersonalInfo.Controls.Add(this.txtPassword);
            this.grpBoxPersonalInfo.Controls.Add(this.chkBoxShowPassword);
            this.grpBoxPersonalInfo.Controls.Add(this.btnChangePassword);
            this.grpBoxPersonalInfo.Controls.Add(this.label1);
            this.grpBoxPersonalInfo.Controls.Add(this.lblUsername);
            this.grpBoxPersonalInfo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxPersonalInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBoxPersonalInfo.Name = "grpBoxPersonalInfo";
            this.grpBoxPersonalInfo.Size = new System.Drawing.Size(394, 121);
            this.grpBoxPersonalInfo.TabIndex = 1;
            this.grpBoxPersonalInfo.TabStop = false;
            this.grpBoxPersonalInfo.Text = "Personal Information";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(82, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(176, 23);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(82, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(176, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Password";
            // 
            // chkBoxShowPassword
            // 
            this.chkBoxShowPassword.AutoSize = true;
            this.chkBoxShowPassword.Location = new System.Drawing.Point(264, 50);
            this.chkBoxShowPassword.Name = "chkBoxShowPassword";
            this.chkBoxShowPassword.Size = new System.Drawing.Size(127, 21);
            this.chkBoxShowPassword.TabIndex = 2;
            this.chkBoxShowPassword.Text = "Show Password";
            this.chkBoxShowPassword.UseVisualStyleBackColor = true;
            this.chkBoxShowPassword.CheckedChanged += new System.EventHandler(this.chkBoxShowPassword_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // grpBoxColourScheme
            // 
            this.grpBoxColourScheme.Controls.Add(this.btnResetColourToDefault);
            this.grpBoxColourScheme.Controls.Add(this.btnSaveNewColour);
            this.grpBoxColourScheme.Controls.Add(this.btnEditHighlightColour);
            this.grpBoxColourScheme.Controls.Add(this.btnEditBackgroundColour);
            this.grpBoxColourScheme.Controls.Add(this.txtHighlightColour);
            this.grpBoxColourScheme.Controls.Add(this.txtBackgroundColour);
            this.grpBoxColourScheme.Controls.Add(this.btnHighlightColour);
            this.grpBoxColourScheme.Controls.Add(this.btnBackgroundColour);
            this.grpBoxColourScheme.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxColourScheme.Location = new System.Drawing.Point(3, 130);
            this.grpBoxColourScheme.Name = "grpBoxColourScheme";
            this.grpBoxColourScheme.Size = new System.Drawing.Size(394, 121);
            this.grpBoxColourScheme.TabIndex = 3;
            this.grpBoxColourScheme.TabStop = false;
            this.grpBoxColourScheme.Text = "Colour Scheme";
            // 
            // btnResetColourToDefault
            // 
            this.btnResetColourToDefault.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetColourToDefault.Location = new System.Drawing.Point(6, 85);
            this.btnResetColourToDefault.Name = "btnResetColourToDefault";
            this.btnResetColourToDefault.Size = new System.Drawing.Size(79, 28);
            this.btnResetColourToDefault.TabIndex = 12;
            this.btnResetColourToDefault.Text = "Default";
            this.btnResetColourToDefault.UseVisualStyleBackColor = true;
            this.btnResetColourToDefault.Click += new System.EventHandler(this.btnResetColourToDefault_Click);
            // 
            // btnSaveNewColour
            // 
            this.btnSaveNewColour.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewColour.Location = new System.Drawing.Point(309, 85);
            this.btnSaveNewColour.Name = "btnSaveNewColour";
            this.btnSaveNewColour.Size = new System.Drawing.Size(79, 28);
            this.btnSaveNewColour.TabIndex = 11;
            this.btnSaveNewColour.Text = "Save";
            this.btnSaveNewColour.UseVisualStyleBackColor = true;
            this.btnSaveNewColour.Click += new System.EventHandler(this.btnSaveNewColour_Click);
            // 
            // btnEditHighlightColour
            // 
            this.btnEditHighlightColour.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditHighlightColour.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditHighlightColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditHighlightColour.Location = new System.Drawing.Point(329, 56);
            this.btnEditHighlightColour.Name = "btnEditHighlightColour";
            this.btnEditHighlightColour.Size = new System.Drawing.Size(59, 23);
            this.btnEditHighlightColour.TabIndex = 5;
            this.btnEditHighlightColour.Text = "Edit";
            this.btnEditHighlightColour.UseVisualStyleBackColor = false;
            this.btnEditHighlightColour.Click += new System.EventHandler(this.btnEditHighlightColour_Click);
            // 
            // btnEditBackgroundColour
            // 
            this.btnEditBackgroundColour.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditBackgroundColour.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditBackgroundColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBackgroundColour.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditBackgroundColour.Location = new System.Drawing.Point(329, 24);
            this.btnEditBackgroundColour.Name = "btnEditBackgroundColour";
            this.btnEditBackgroundColour.Size = new System.Drawing.Size(59, 23);
            this.btnEditBackgroundColour.TabIndex = 4;
            this.btnEditBackgroundColour.Text = "Edit";
            this.btnEditBackgroundColour.UseVisualStyleBackColor = false;
            this.btnEditBackgroundColour.Click += new System.EventHandler(this.btnEditBackgroundColour_Click);
            // 
            // txtHighlightColour
            // 
            this.txtHighlightColour.Location = new System.Drawing.Point(42, 56);
            this.txtHighlightColour.Name = "txtHighlightColour";
            this.txtHighlightColour.ReadOnly = true;
            this.txtHighlightColour.Size = new System.Drawing.Size(100, 23);
            this.txtHighlightColour.TabIndex = 3;
            this.txtHighlightColour.Text = "Highlight";
            this.txtHighlightColour.TextChanged += new System.EventHandler(this.txtHighlightColour_TextChanged);
            // 
            // txtBackgroundColour
            // 
            this.txtBackgroundColour.Location = new System.Drawing.Point(42, 24);
            this.txtBackgroundColour.Name = "txtBackgroundColour";
            this.txtBackgroundColour.ReadOnly = true;
            this.txtBackgroundColour.Size = new System.Drawing.Size(100, 23);
            this.txtBackgroundColour.TabIndex = 2;
            this.txtBackgroundColour.Text = "Background";
            this.txtBackgroundColour.TextChanged += new System.EventHandler(this.txtBackgroundColour_TextChanged);
            // 
            // btnHighlightColour
            // 
            this.btnHighlightColour.FlatAppearance.BorderSize = 0;
            this.btnHighlightColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighlightColour.Location = new System.Drawing.Point(10, 54);
            this.btnHighlightColour.Name = "btnHighlightColour";
            this.btnHighlightColour.Size = new System.Drawing.Size(26, 26);
            this.btnHighlightColour.TabIndex = 1;
            this.btnHighlightColour.UseVisualStyleBackColor = true;
            // 
            // btnBackgroundColour
            // 
            this.btnBackgroundColour.FlatAppearance.BorderSize = 0;
            this.btnBackgroundColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackgroundColour.Location = new System.Drawing.Point(10, 22);
            this.btnBackgroundColour.Name = "btnBackgroundColour";
            this.btnBackgroundColour.Size = new System.Drawing.Size(26, 26);
            this.btnBackgroundColour.TabIndex = 0;
            this.btnBackgroundColour.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowDateAndTime
            // 
            this.checkBoxShowDateAndTime.AutoSize = true;
            this.checkBoxShowDateAndTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowDateAndTime.Location = new System.Drawing.Point(9, 258);
            this.checkBoxShowDateAndTime.Name = "checkBoxShowDateAndTime";
            this.checkBoxShowDateAndTime.Size = new System.Drawing.Size(161, 21);
            this.checkBoxShowDateAndTime.TabIndex = 4;
            this.checkBoxShowDateAndTime.Text = "Show Date and Time";
            this.checkBoxShowDateAndTime.UseVisualStyleBackColor = true;
            this.checkBoxShowDateAndTime.CheckedChanged += new System.EventHandler(this.checkBoxShowDateAndTime_CheckedChanged);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxShowDateAndTime);
            this.Controls.Add(this.grpBoxColourScheme);
            this.Controls.Add(this.grpBoxPersonalInfo);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.SettingsControl_Load);
            this.grpBoxPersonalInfo.ResumeLayout(false);
            this.grpBoxPersonalInfo.PerformLayout();
            this.grpBoxColourScheme.ResumeLayout(false);
            this.grpBoxColourScheme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.GroupBox grpBoxPersonalInfo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBoxShowPassword;
        private System.Windows.Forms.GroupBox grpBoxColourScheme;
        private System.Windows.Forms.Button btnBackgroundColour;
        private System.Windows.Forms.Button btnHighlightColour;
        private System.Windows.Forms.TextBox txtHighlightColour;
        private System.Windows.Forms.TextBox txtBackgroundColour;
        private System.Windows.Forms.Button btnEditHighlightColour;
        private System.Windows.Forms.Button btnEditBackgroundColour;
        private System.Windows.Forms.Button btnSaveNewColour;
        private System.Windows.Forms.Button btnResetColourToDefault;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox checkBoxShowDateAndTime;
    }
}
