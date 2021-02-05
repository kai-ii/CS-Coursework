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
            this.chkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpBoxColourScheme = new System.Windows.Forms.GroupBox();
            this.btnBackgroundColour = new System.Windows.Forms.Button();
            this.btnHighlightColour = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtHighlightColour = new System.Windows.Forms.TextBox();
            this.btnEditBackgroundColour = new System.Windows.Forms.Button();
            this.btnEditHighlightColour = new System.Windows.Forms.Button();
            this.grpBoxPersonalInfo.SuspendLayout();
            this.grpBoxColourScheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(9, 63);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(143, 29);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // grpBoxPersonalInfo
            // 
            this.grpBoxPersonalInfo.Controls.Add(this.chkBoxShowPassword);
            this.grpBoxPersonalInfo.Controls.Add(this.btnChangePassword);
            this.grpBoxPersonalInfo.Controls.Add(this.label1);
            this.grpBoxPersonalInfo.Controls.Add(this.lblUsername);
            this.grpBoxPersonalInfo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxPersonalInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBoxPersonalInfo.Name = "grpBoxPersonalInfo";
            this.grpBoxPersonalInfo.Size = new System.Drawing.Size(322, 102);
            this.grpBoxPersonalInfo.TabIndex = 1;
            this.grpBoxPersonalInfo.TabStop = false;
            this.grpBoxPersonalInfo.Text = "Personal Information";
            // 
            // chkBoxShowPassword
            // 
            this.chkBoxShowPassword.AutoSize = true;
            this.chkBoxShowPassword.Location = new System.Drawing.Point(194, 40);
            this.chkBoxShowPassword.Name = "chkBoxShowPassword";
            this.chkBoxShowPassword.Size = new System.Drawing.Size(127, 21);
            this.chkBoxShowPassword.TabIndex = 2;
            this.chkBoxShowPassword.Text = "Show Password";
            this.chkBoxShowPassword.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password - ********";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(146, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username - username";
            // 
            // grpBoxColourScheme
            // 
            this.grpBoxColourScheme.Controls.Add(this.btnEditHighlightColour);
            this.grpBoxColourScheme.Controls.Add(this.btnEditBackgroundColour);
            this.grpBoxColourScheme.Controls.Add(this.txtHighlightColour);
            this.grpBoxColourScheme.Controls.Add(this.textBox1);
            this.grpBoxColourScheme.Controls.Add(this.btnHighlightColour);
            this.grpBoxColourScheme.Controls.Add(this.btnBackgroundColour);
            this.grpBoxColourScheme.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxColourScheme.Location = new System.Drawing.Point(3, 111);
            this.grpBoxColourScheme.Name = "grpBoxColourScheme";
            this.grpBoxColourScheme.Size = new System.Drawing.Size(322, 90);
            this.grpBoxColourScheme.TabIndex = 3;
            this.grpBoxColourScheme.TabStop = false;
            this.grpBoxColourScheme.Text = "Colour Scheme";
            // 
            // btnBackgroundColour
            // 
            this.btnBackgroundColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackgroundColour.Location = new System.Drawing.Point(10, 22);
            this.btnBackgroundColour.Name = "btnBackgroundColour";
            this.btnBackgroundColour.Size = new System.Drawing.Size(26, 26);
            this.btnBackgroundColour.TabIndex = 0;
            this.btnBackgroundColour.UseVisualStyleBackColor = true;
            // 
            // btnHighlightColour
            // 
            this.btnHighlightColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighlightColour.Location = new System.Drawing.Point(10, 54);
            this.btnHighlightColour.Name = "btnHighlightColour";
            this.btnHighlightColour.Size = new System.Drawing.Size(26, 26);
            this.btnHighlightColour.TabIndex = 1;
            this.btnHighlightColour.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Background";
            // 
            // txtHighlightColour
            // 
            this.txtHighlightColour.Location = new System.Drawing.Point(42, 56);
            this.txtHighlightColour.Name = "txtHighlightColour";
            this.txtHighlightColour.ReadOnly = true;
            this.txtHighlightColour.Size = new System.Drawing.Size(100, 23);
            this.txtHighlightColour.TabIndex = 3;
            this.txtHighlightColour.Text = "Highlight";
            // 
            // btnEditBackgroundColour
            // 
            this.btnEditBackgroundColour.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditBackgroundColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBackgroundColour.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditBackgroundColour.Location = new System.Drawing.Point(257, 24);
            this.btnEditBackgroundColour.Name = "btnEditBackgroundColour";
            this.btnEditBackgroundColour.Size = new System.Drawing.Size(59, 23);
            this.btnEditBackgroundColour.TabIndex = 4;
            this.btnEditBackgroundColour.Text = "Edit";
            this.btnEditBackgroundColour.UseVisualStyleBackColor = false;
            // 
            // btnEditHighlightColour
            // 
            this.btnEditHighlightColour.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditHighlightColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditHighlightColour.Location = new System.Drawing.Point(257, 56);
            this.btnEditHighlightColour.Name = "btnEditHighlightColour";
            this.btnEditHighlightColour.Size = new System.Drawing.Size(59, 23);
            this.btnEditHighlightColour.TabIndex = 5;
            this.btnEditHighlightColour.Text = "Edit";
            this.btnEditHighlightColour.UseVisualStyleBackColor = false;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxColourScheme);
            this.Controls.Add(this.grpBoxPersonalInfo);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.grpBoxPersonalInfo.ResumeLayout(false);
            this.grpBoxPersonalInfo.PerformLayout();
            this.grpBoxColourScheme.ResumeLayout(false);
            this.grpBoxColourScheme.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEditHighlightColour;
        private System.Windows.Forms.Button btnEditBackgroundColour;
    }
}
