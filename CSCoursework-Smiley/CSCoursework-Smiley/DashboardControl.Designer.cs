namespace CSCoursework_Smiley.Properties
{
    partial class DashboardControl
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
            this.LoggedInGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoggedInGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoggedInGroupBox
            // 
            this.LoggedInGroupBox.Controls.Add(this.label1);
            this.LoggedInGroupBox.Location = new System.Drawing.Point(20, 19);
            this.LoggedInGroupBox.Name = "LoggedInGroupBox";
            this.LoggedInGroupBox.Size = new System.Drawing.Size(338, 99);
            this.LoggedInGroupBox.TabIndex = 0;
            this.LoggedInGroupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged in as: {username}";
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoggedInGroupBox);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.LoggedInGroupBox.ResumeLayout(false);
            this.LoggedInGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LoggedInGroupBox;
        private System.Windows.Forms.Label label1;
    }
}
