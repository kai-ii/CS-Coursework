namespace CSCoursework_Smiley
{
    partial class StaffControlNotes
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
            this.grpGeneralNotes = new System.Windows.Forms.GroupBox();
            this.rTxtGeneralNotes = new System.Windows.Forms.RichTextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.grpAbsentNotes = new System.Windows.Forms.GroupBox();
            this.rTextBoxAbsentNotes = new System.Windows.Forms.RichTextBox();
            this.grpGeneralNotes.SuspendLayout();
            this.grpAbsentNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneralNotes
            // 
            this.grpGeneralNotes.Controls.Add(this.rTxtGeneralNotes);
            this.grpGeneralNotes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGeneralNotes.Location = new System.Drawing.Point(3, 0);
            this.grpGeneralNotes.Name = "grpGeneralNotes";
            this.grpGeneralNotes.Size = new System.Drawing.Size(550, 385);
            this.grpGeneralNotes.TabIndex = 0;
            this.grpGeneralNotes.TabStop = false;
            this.grpGeneralNotes.Text = "General Notes";
            // 
            // rTxtGeneralNotes
            // 
            this.rTxtGeneralNotes.Location = new System.Drawing.Point(6, 22);
            this.rTxtGeneralNotes.Name = "rTxtGeneralNotes";
            this.rTxtGeneralNotes.Size = new System.Drawing.Size(541, 357);
            this.rTxtGeneralNotes.TabIndex = 0;
            this.rTxtGeneralNotes.Text = "";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(314, 19);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // grpAbsentNotes
            // 
            this.grpAbsentNotes.Controls.Add(this.rTextBoxAbsentNotes);
            this.grpAbsentNotes.Controls.Add(this.monthCalendar1);
            this.grpAbsentNotes.Location = new System.Drawing.Point(3, 391);
            this.grpAbsentNotes.Name = "grpAbsentNotes";
            this.grpAbsentNotes.Size = new System.Drawing.Size(553, 194);
            this.grpAbsentNotes.TabIndex = 1;
            this.grpAbsentNotes.TabStop = false;
            this.grpAbsentNotes.Text = "Absent Notes";
            // 
            // rTextBoxAbsentNotes
            // 
            this.rTextBoxAbsentNotes.Location = new System.Drawing.Point(7, 19);
            this.rTextBoxAbsentNotes.Name = "rTextBoxAbsentNotes";
            this.rTextBoxAbsentNotes.Size = new System.Drawing.Size(295, 163);
            this.rTextBoxAbsentNotes.TabIndex = 2;
            this.rTextBoxAbsentNotes.Text = "";
            // 
            // StaffControlNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpAbsentNotes);
            this.Controls.Add(this.grpGeneralNotes);
            this.Name = "StaffControlNotes";
            this.Size = new System.Drawing.Size(556, 585);
            this.Load += new System.EventHandler(this.StaffControlNotes_Load);
            this.grpGeneralNotes.ResumeLayout(false);
            this.grpAbsentNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneralNotes;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox grpAbsentNotes;
        private System.Windows.Forms.RichTextBox rTxtGeneralNotes;
        private System.Windows.Forms.RichTextBox rTextBoxAbsentNotes;
    }
}
