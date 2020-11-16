namespace CSCoursework_Smiley
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
            this.LeftPanelAnchor = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.PictureBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.Sign_in_label = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.LeftPanelAnchor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanelAnchor
            // 
            this.LeftPanelAnchor.BackColor = System.Drawing.Color.White;
            this.LeftPanelAnchor.Controls.Add(this.btnSubmit);
            this.LeftPanelAnchor.Controls.Add(this.PasswordTextbox);
            this.LeftPanelAnchor.Controls.Add(this.UsernameTextbox);
            this.LeftPanelAnchor.Controls.Add(this.Sign_in_label);
            this.LeftPanelAnchor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanelAnchor.Location = new System.Drawing.Point(0, 0);
            this.LeftPanelAnchor.Name = "LeftPanelAnchor";
            this.LeftPanelAnchor.Size = new System.Drawing.Size(300, 710);
            this.LeftPanelAnchor.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.InitialImage = null;
            this.btnSubmit.Location = new System.Drawing.Point(163, 177);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 99);
            this.btnSubmit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(44, 131);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(190, 20);
            this.PasswordTextbox.TabIndex = 2;
            this.PasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextbox_KeyDown);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(44, 105);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(190, 20);
            this.UsernameTextbox.TabIndex = 1;
            this.UsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameTextbox_KeyDown);
            // 
            // Sign_in_label
            // 
            this.Sign_in_label.AutoSize = true;
            this.Sign_in_label.Font = new System.Drawing.Font("Calibri", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sign_in_label.Location = new System.Drawing.Point(12, 38);
            this.Sign_in_label.Name = "Sign_in_label";
            this.Sign_in_label.Size = new System.Drawing.Size(158, 53);
            this.Sign_in_label.TabIndex = 0;
            this.Sign_in_label.Text = "SIGN IN";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1144, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 710);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanelAnchor;
        private System.Windows.Forms.Label Sign_in_label;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.PictureBox btnSubmit;
        private System.Windows.Forms.PictureBox btnExit;
    }
}