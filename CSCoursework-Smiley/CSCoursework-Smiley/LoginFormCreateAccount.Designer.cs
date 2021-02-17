namespace CSCoursework_Smiley
{
    partial class LoginFormCreateAccount
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
            this.grpBoxAccountCreation = new System.Windows.Forms.GroupBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.grpBoxAccountSecurity = new System.Windows.Forms.GroupBox();
            this.txtSecurityAnswer3 = new System.Windows.Forms.TextBox();
            this.txtSecurityAnswer2 = new System.Windows.Forms.TextBox();
            this.txtSecurityAnswer1 = new System.Windows.Forms.TextBox();
            this.comboBoxSecurityQuestion3 = new System.Windows.Forms.ComboBox();
            this.comboBoxSecurityQuestion2 = new System.Windows.Forms.ComboBox();
            this.comboBoxSecurityQuestion1 = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grpBoxAccountCreation.SuspendLayout();
            this.grpBoxAccountSecurity.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxAccountCreation
            // 
            this.grpBoxAccountCreation.Controls.Add(this.txtStaffName);
            this.grpBoxAccountCreation.Controls.Add(this.txtConfirmPassword);
            this.grpBoxAccountCreation.Controls.Add(this.txtPassword);
            this.grpBoxAccountCreation.Controls.Add(this.lblConfirmPassword);
            this.grpBoxAccountCreation.Controls.Add(this.lblPassword);
            this.grpBoxAccountCreation.Controls.Add(this.lblUsername);
            this.grpBoxAccountCreation.Controls.Add(this.label1);
            this.grpBoxAccountCreation.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxAccountCreation.Location = new System.Drawing.Point(4, 4);
            this.grpBoxAccountCreation.Name = "grpBoxAccountCreation";
            this.grpBoxAccountCreation.Size = new System.Drawing.Size(875, 154);
            this.grpBoxAccountCreation.TabIndex = 0;
            this.grpBoxAccountCreation.TabStop = false;
            this.grpBoxAccountCreation.Text = "Account Creation";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(78, 25);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(210, 27);
            this.txtStaffName.TabIndex = 6;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(183, 114);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(210, 27);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(107, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(210, 27);
            this.txtPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(6, 118);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(171, 22);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 91);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(95, 22);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(270, 22);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username (auto-generated)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(165)))), ((int)(((byte)(182)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(802, 603);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(720, 603);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(76, 29);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // grpBoxAccountSecurity
            // 
            this.grpBoxAccountSecurity.Controls.Add(this.txtSecurityAnswer3);
            this.grpBoxAccountSecurity.Controls.Add(this.txtSecurityAnswer2);
            this.grpBoxAccountSecurity.Controls.Add(this.txtSecurityAnswer1);
            this.grpBoxAccountSecurity.Controls.Add(this.comboBoxSecurityQuestion3);
            this.grpBoxAccountSecurity.Controls.Add(this.comboBoxSecurityQuestion2);
            this.grpBoxAccountSecurity.Controls.Add(this.comboBoxSecurityQuestion1);
            this.grpBoxAccountSecurity.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxAccountSecurity.Location = new System.Drawing.Point(7, 164);
            this.grpBoxAccountSecurity.Name = "grpBoxAccountSecurity";
            this.grpBoxAccountSecurity.Size = new System.Drawing.Size(875, 154);
            this.grpBoxAccountSecurity.TabIndex = 7;
            this.grpBoxAccountSecurity.TabStop = false;
            this.grpBoxAccountSecurity.Text = "Account Security";
            this.grpBoxAccountSecurity.Visible = false;
            // 
            // txtSecurityAnswer3
            // 
            this.txtSecurityAnswer3.Location = new System.Drawing.Point(404, 101);
            this.txtSecurityAnswer3.Name = "txtSecurityAnswer3";
            this.txtSecurityAnswer3.Size = new System.Drawing.Size(465, 31);
            this.txtSecurityAnswer3.TabIndex = 5;
            // 
            // txtSecurityAnswer2
            // 
            this.txtSecurityAnswer2.Location = new System.Drawing.Point(404, 65);
            this.txtSecurityAnswer2.Name = "txtSecurityAnswer2";
            this.txtSecurityAnswer2.Size = new System.Drawing.Size(465, 31);
            this.txtSecurityAnswer2.TabIndex = 4;
            // 
            // txtSecurityAnswer1
            // 
            this.txtSecurityAnswer1.Location = new System.Drawing.Point(404, 30);
            this.txtSecurityAnswer1.Name = "txtSecurityAnswer1";
            this.txtSecurityAnswer1.Size = new System.Drawing.Size(465, 31);
            this.txtSecurityAnswer1.TabIndex = 3;
            // 
            // comboBoxSecurityQuestion3
            // 
            this.comboBoxSecurityQuestion3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecurityQuestion3.FormattingEnabled = true;
            this.comboBoxSecurityQuestion3.Items.AddRange(new object[] {
            "What is your favourite book?",
            "What is your mother\'s maiden name?",
            "What was the name of your first pet?",
            "Which primary school did you attend?",
            "What is your favourite food?",
            "What city were you born in?",
            "Who was your childhood hero?",
            "Who is your favourite fictional character?"});
            this.comboBoxSecurityQuestion3.Location = new System.Drawing.Point(10, 102);
            this.comboBoxSecurityQuestion3.Name = "comboBoxSecurityQuestion3";
            this.comboBoxSecurityQuestion3.Size = new System.Drawing.Size(388, 30);
            this.comboBoxSecurityQuestion3.TabIndex = 2;
            // 
            // comboBoxSecurityQuestion2
            // 
            this.comboBoxSecurityQuestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecurityQuestion2.FormattingEnabled = true;
            this.comboBoxSecurityQuestion2.Items.AddRange(new object[] {
            "What is your favourite book?",
            "What is your mother\'s maiden name?",
            "What was the name of your first pet?",
            "Which primary school did you attend?",
            "What is your favourite food?",
            "What city were you born in?",
            "Who was your childhood hero?",
            "Who is your favourite fictional character?"});
            this.comboBoxSecurityQuestion2.Location = new System.Drawing.Point(10, 66);
            this.comboBoxSecurityQuestion2.Name = "comboBoxSecurityQuestion2";
            this.comboBoxSecurityQuestion2.Size = new System.Drawing.Size(388, 30);
            this.comboBoxSecurityQuestion2.TabIndex = 1;
            // 
            // comboBoxSecurityQuestion1
            // 
            this.comboBoxSecurityQuestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecurityQuestion1.FormattingEnabled = true;
            this.comboBoxSecurityQuestion1.Items.AddRange(new object[] {
            "What is your favourite book?",
            "What is your mother\'s maiden name?",
            "What was the name of your first pet?",
            "Which primary school did you attend?",
            "What is your favourite food?",
            "What city were you born in?",
            "Who was your childhood hero?",
            "Who is your favourite fictional character?"});
            this.comboBoxSecurityQuestion1.Location = new System.Drawing.Point(10, 30);
            this.comboBoxSecurityQuestion1.Name = "comboBoxSecurityQuestion1";
            this.comboBoxSecurityQuestion1.Size = new System.Drawing.Size(388, 30);
            this.comboBoxSecurityQuestion1.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(720, 603);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(76, 29);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // LoginFormCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxAccountSecurity);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBoxAccountCreation);
            this.Name = "LoginFormCreateAccount";
            this.Size = new System.Drawing.Size(882, 636);
            this.Load += new System.EventHandler(this.LoginFormCreateAccount_Load);
            this.grpBoxAccountCreation.ResumeLayout(false);
            this.grpBoxAccountCreation.PerformLayout();
            this.grpBoxAccountSecurity.ResumeLayout(false);
            this.grpBoxAccountSecurity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxAccountCreation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.GroupBox grpBoxAccountSecurity;
        private System.Windows.Forms.ComboBox comboBoxSecurityQuestion3;
        private System.Windows.Forms.ComboBox comboBoxSecurityQuestion2;
        private System.Windows.Forms.ComboBox comboBoxSecurityQuestion1;
        private System.Windows.Forms.TextBox txtSecurityAnswer3;
        private System.Windows.Forms.TextBox txtSecurityAnswer2;
        private System.Windows.Forms.TextBox txtSecurityAnswer1;
        private System.Windows.Forms.Button btnSubmit;
    }
}
