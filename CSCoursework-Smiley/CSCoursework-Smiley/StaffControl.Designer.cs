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
            this.btnEmployee2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.staffControlDetails1 = new CSCoursework_Smiley.StaffControlDetails();
            this.pnlStaffScroll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmployee1
            // 
            this.btnEmployee1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee1.Location = new System.Drawing.Point(3, 3);
            this.btnEmployee1.Name = "btnEmployee1";
            this.btnEmployee1.Size = new System.Drawing.Size(221, 37);
            this.btnEmployee1.TabIndex = 0;
            this.btnEmployee1.Text = "employee1";
            this.btnEmployee1.UseVisualStyleBackColor = true;
            this.btnEmployee1.Click += new System.EventHandler(this.btnEmployee1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(7, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 21);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlStaffScroll
            // 
            this.pnlStaffScroll.AutoScroll = true;
            this.pnlStaffScroll.Controls.Add(this.btnEmployee2);
            this.pnlStaffScroll.Controls.Add(this.btnEmployee1);
            this.pnlStaffScroll.Location = new System.Drawing.Point(3, 45);
            this.pnlStaffScroll.Name = "pnlStaffScroll";
            this.pnlStaffScroll.Size = new System.Drawing.Size(245, 591);
            this.pnlStaffScroll.TabIndex = 2;
            // 
            // btnEmployee2
            // 
            this.btnEmployee2.Location = new System.Drawing.Point(3, 629);
            this.btnEmployee2.Name = "btnEmployee2";
            this.btnEmployee2.Size = new System.Drawing.Size(221, 37);
            this.btnEmployee2.TabIndex = 1;
            this.btnEmployee2.Text = "employee2";
            this.btnEmployee2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.staffControlDetails1);
            this.panel1.Location = new System.Drawing.Point(255, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 585);
            this.panel1.TabIndex = 3;
            // 
            // staffControlDetails1
            // 
            this.staffControlDetails1.Location = new System.Drawing.Point(0, 0);
            this.staffControlDetails1.Name = "staffControlDetails1";
            this.staffControlDetails1.Size = new System.Drawing.Size(556, 585);
            this.staffControlDetails1.TabIndex = 0;
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlStaffScroll);
            this.Controls.Add(this.txtSearch);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.StaffControl_Load);
            this.pnlStaffScroll.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlStaffScroll;
        private System.Windows.Forms.Button btnEmployee2;
        private System.Windows.Forms.Panel panel1;
        private StaffControlDetails staffControlDetails1;
    }
}
