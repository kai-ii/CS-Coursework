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
            this.btnEmployee1 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlStaffScroll = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlStaffScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmployee1
            // 
            this.btnEmployee1.Location = new System.Drawing.Point(3, 3);
            this.btnEmployee1.Name = "btnEmployee1";
            this.btnEmployee1.Size = new System.Drawing.Size(221, 37);
            this.btnEmployee1.TabIndex = 0;
            this.btnEmployee1.Text = "button1";
            this.btnEmployee1.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlStaffScroll
            // 
            this.pnlStaffScroll.AutoScroll = true;
            this.pnlStaffScroll.Controls.Add(this.button2);
            this.pnlStaffScroll.Controls.Add(this.btnEmployee1);
            this.pnlStaffScroll.Location = new System.Drawing.Point(3, 45);
            this.pnlStaffScroll.Name = "pnlStaffScroll";
            this.pnlStaffScroll.Size = new System.Drawing.Size(245, 591);
            this.pnlStaffScroll.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 629);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(221, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlStaffScroll);
            this.Controls.Add(this.txtSearch);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.StaffControl_Load);
            this.pnlStaffScroll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlStaffScroll;
        private System.Windows.Forms.Button button2;
    }
}
