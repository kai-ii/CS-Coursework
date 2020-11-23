namespace CSCoursework_Smiley
{
    partial class StaffControl
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
            this.StaffControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StaffControlButton
            // 
            this.StaffControlButton.Location = new System.Drawing.Point(191, 191);
            this.StaffControlButton.Name = "StaffControlButton";
            this.StaffControlButton.Size = new System.Drawing.Size(75, 23);
            this.StaffControlButton.TabIndex = 0;
            this.StaffControlButton.Text = "Staff";
            this.StaffControlButton.UseVisualStyleBackColor = true;
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StaffControlButton);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StaffControlButton;
    }
}
