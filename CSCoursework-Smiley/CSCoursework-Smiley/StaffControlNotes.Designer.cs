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
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnSaveGeneralNotes = new System.Windows.Forms.Button();
            this.rTxtGeneralNotes = new System.Windows.Forms.RichTextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.grpAbsenceNotes = new System.Windows.Forms.GroupBox();
            this.rTxtAbsentNotes = new System.Windows.Forms.RichTextBox();
            this.grpGeneralNotes.SuspendLayout();
            this.grpAbsenceNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneralNotes
            // 
            this.grpGeneralNotes.Controls.Add(this.btnSaveToFile);
            this.grpGeneralNotes.Controls.Add(this.btnSaveGeneralNotes);
            this.grpGeneralNotes.Controls.Add(this.rTxtGeneralNotes);
            this.grpGeneralNotes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGeneralNotes.Location = new System.Drawing.Point(3, 0);
            this.grpGeneralNotes.Name = "grpGeneralNotes";
            this.grpGeneralNotes.Size = new System.Drawing.Size(550, 385);
            this.grpGeneralNotes.TabIndex = 0;
            this.grpGeneralNotes.TabStop = false;
            this.grpGeneralNotes.Text = "General Notes";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(7, 356);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(93, 23);
            this.btnSaveToFile.TabIndex = 2;
            this.btnSaveToFile.Text = "Save To File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnSaveGeneralNotes
            // 
            this.btnSaveGeneralNotes.Location = new System.Drawing.Point(485, 356);
            this.btnSaveGeneralNotes.Name = "btnSaveGeneralNotes";
            this.btnSaveGeneralNotes.Size = new System.Drawing.Size(62, 23);
            this.btnSaveGeneralNotes.TabIndex = 1;
            this.btnSaveGeneralNotes.Text = "Save";
            this.btnSaveGeneralNotes.UseVisualStyleBackColor = true;
            this.btnSaveGeneralNotes.Click += new System.EventHandler(this.btnSaveGeneralNotes_Click);
            // 
            // rTxtGeneralNotes
            // 
            this.rTxtGeneralNotes.Location = new System.Drawing.Point(6, 22);
            this.rTxtGeneralNotes.Name = "rTxtGeneralNotes";
            this.rTxtGeneralNotes.Size = new System.Drawing.Size(541, 357);
            this.rTxtGeneralNotes.TabIndex = 0;
            this.rTxtGeneralNotes.Text = "";
            this.rTxtGeneralNotes.TextChanged += new System.EventHandler(this.rTxtGeneralNotes_TextChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(314, 19);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // grpAbsenceNotes
            // 
            this.grpAbsenceNotes.Controls.Add(this.rTxtAbsentNotes);
            this.grpAbsenceNotes.Controls.Add(this.monthCalendar1);
            this.grpAbsenceNotes.Location = new System.Drawing.Point(3, 391);
            this.grpAbsenceNotes.Name = "grpAbsenceNotes";
            this.grpAbsenceNotes.Size = new System.Drawing.Size(553, 194);
            this.grpAbsenceNotes.TabIndex = 1;
            this.grpAbsenceNotes.TabStop = false;
            this.grpAbsenceNotes.Text = "Absence Notes";
            // 
            // rTxtAbsentNotes
            // 
            this.rTxtAbsentNotes.Location = new System.Drawing.Point(7, 19);
            this.rTxtAbsentNotes.Name = "rTxtAbsentNotes";
            this.rTxtAbsentNotes.Size = new System.Drawing.Size(295, 163);
            this.rTxtAbsentNotes.TabIndex = 2;
            this.rTxtAbsentNotes.Text = "";
            // 
            // StaffControlNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpAbsenceNotes);
            this.Controls.Add(this.grpGeneralNotes);
            this.Name = "StaffControlNotes";
            this.Size = new System.Drawing.Size(556, 585);
            this.Load += new System.EventHandler(this.StaffControlNotes_Load);
            this.grpGeneralNotes.ResumeLayout(false);
            this.grpAbsenceNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneralNotes;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox grpAbsenceNotes;
        private System.Windows.Forms.RichTextBox rTxtGeneralNotes;
        private System.Windows.Forms.RichTextBox rTxtAbsentNotes;
        private System.Windows.Forms.Button btnSaveGeneralNotes;
        private System.Windows.Forms.Button btnSaveToFile;
    }
}
