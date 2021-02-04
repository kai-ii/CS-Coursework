namespace CSCoursework_Smiley
{
    partial class TimesheetAbsenceDataControl
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
            this.lblAbsenceDataTitle = new System.Windows.Forms.Label();
            this.grpBoxSelectEmployee = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectEmployee = new System.Windows.Forms.ComboBox();
            this.grpBoxAbsenceTable = new System.Windows.Forms.GroupBox();
            this.absenceDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMonday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnTuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnWednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnThursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFriday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveAbsenceNotes = new System.Windows.Forms.Button();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.btnPreviousDay = new System.Windows.Forms.Button();
            this.lblCurrentDay = new System.Windows.Forms.Label();
            this.rTxtAbsenceNotes = new System.Windows.Forms.RichTextBox();
            this.grpBoxSelectEmployee.SuspendLayout();
            this.grpBoxAbsenceTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.absenceDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAbsenceDataTitle
            // 
            this.lblAbsenceDataTitle.AutoSize = true;
            this.lblAbsenceDataTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbsenceDataTitle.Location = new System.Drawing.Point(4, 4);
            this.lblAbsenceDataTitle.Name = "lblAbsenceDataTitle";
            this.lblAbsenceDataTitle.Size = new System.Drawing.Size(172, 21);
            this.lblAbsenceDataTitle.TabIndex = 1;
            this.lblAbsenceDataTitle.Text = "Input Absence Data";
            // 
            // grpBoxSelectEmployee
            // 
            this.grpBoxSelectEmployee.Controls.Add(this.comboBoxSelectEmployee);
            this.grpBoxSelectEmployee.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxSelectEmployee.Location = new System.Drawing.Point(8, 28);
            this.grpBoxSelectEmployee.Name = "grpBoxSelectEmployee";
            this.grpBoxSelectEmployee.Size = new System.Drawing.Size(299, 50);
            this.grpBoxSelectEmployee.TabIndex = 3;
            this.grpBoxSelectEmployee.TabStop = false;
            this.grpBoxSelectEmployee.Text = "Select Employee";
            // 
            // comboBoxSelectEmployee
            // 
            this.comboBoxSelectEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectEmployee.FormattingEnabled = true;
            this.comboBoxSelectEmployee.Location = new System.Drawing.Point(6, 20);
            this.comboBoxSelectEmployee.Name = "comboBoxSelectEmployee";
            this.comboBoxSelectEmployee.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSelectEmployee.TabIndex = 1;
            this.comboBoxSelectEmployee.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectEmployee_SelectedIndexChanged);
            this.comboBoxSelectEmployee.Enter += new System.EventHandler(this.comboBoxSelectEmployee_Enter);
            // 
            // grpBoxAbsenceTable
            // 
            this.grpBoxAbsenceTable.Controls.Add(this.absenceDataGridView);
            this.grpBoxAbsenceTable.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxAbsenceTable.Location = new System.Drawing.Point(8, 85);
            this.grpBoxAbsenceTable.Name = "grpBoxAbsenceTable";
            this.grpBoxAbsenceTable.Size = new System.Drawing.Size(299, 73);
            this.grpBoxAbsenceTable.TabIndex = 4;
            this.grpBoxAbsenceTable.TabStop = false;
            this.grpBoxAbsenceTable.Text = "Absence Table";
            // 
            // absenceDataGridView
            // 
            this.absenceDataGridView.AllowUserToAddRows = false;
            this.absenceDataGridView.AllowUserToDeleteRows = false;
            this.absenceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.absenceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMonday,
            this.ColumnTuesday,
            this.ColumnWednesday,
            this.ColumnThursday,
            this.ColumnFriday});
            this.absenceDataGridView.Location = new System.Drawing.Point(12, 20);
            this.absenceDataGridView.Name = "absenceDataGridView";
            this.absenceDataGridView.RowHeadersVisible = false;
            this.absenceDataGridView.Size = new System.Drawing.Size(276, 47);
            this.absenceDataGridView.TabIndex = 0;
            // 
            // ColumnMonday
            // 
            this.ColumnMonday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMonday.HeaderText = "Mon";
            this.ColumnMonday.Name = "ColumnMonday";
            this.ColumnMonday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMonday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnTuesday
            // 
            this.ColumnTuesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTuesday.HeaderText = "Tue";
            this.ColumnTuesday.Name = "ColumnTuesday";
            this.ColumnTuesday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnWednesday
            // 
            this.ColumnWednesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnWednesday.HeaderText = "Wed";
            this.ColumnWednesday.Name = "ColumnWednesday";
            // 
            // ColumnThursday
            // 
            this.ColumnThursday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnThursday.HeaderText = "Thu";
            this.ColumnThursday.Name = "ColumnThursday";
            // 
            // ColumnFriday
            // 
            this.ColumnFriday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFriday.HeaderText = "Fri";
            this.ColumnFriday.Name = "ColumnFriday";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveAbsenceNotes);
            this.groupBox1.Controls.Add(this.btnNextDay);
            this.groupBox1.Controls.Add(this.btnPreviousDay);
            this.groupBox1.Controls.Add(this.lblCurrentDay);
            this.groupBox1.Controls.Add(this.rTxtAbsenceNotes);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 192);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Absence Notes";
            // 
            // btnSaveAbsenceNotes
            // 
            this.btnSaveAbsenceNotes.Location = new System.Drawing.Point(244, 163);
            this.btnSaveAbsenceNotes.Name = "btnSaveAbsenceNotes";
            this.btnSaveAbsenceNotes.Size = new System.Drawing.Size(49, 23);
            this.btnSaveAbsenceNotes.TabIndex = 10;
            this.btnSaveAbsenceNotes.Text = "Save";
            this.btnSaveAbsenceNotes.UseVisualStyleBackColor = true;
            this.btnSaveAbsenceNotes.Click += new System.EventHandler(this.btnSaveAbsenceNotes_Click);
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(224, 17);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(69, 22);
            this.btnNextDay.TabIndex = 9;
            this.btnNextDay.Text = "Next Day";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnPreviousDay
            // 
            this.btnPreviousDay.Location = new System.Drawing.Point(6, 17);
            this.btnPreviousDay.Name = "btnPreviousDay";
            this.btnPreviousDay.Size = new System.Drawing.Size(69, 22);
            this.btnPreviousDay.TabIndex = 8;
            this.btnPreviousDay.Text = "Prev Day";
            this.btnPreviousDay.UseVisualStyleBackColor = true;
            this.btnPreviousDay.Click += new System.EventHandler(this.btnPreviousDay_Click);
            // 
            // lblCurrentDay
            // 
            this.lblCurrentDay.AutoSize = true;
            this.lblCurrentDay.Location = new System.Drawing.Point(96, 20);
            this.lblCurrentDay.Name = "lblCurrentDay";
            this.lblCurrentDay.Size = new System.Drawing.Size(107, 16);
            this.lblCurrentDay.TabIndex = 7;
            this.lblCurrentDay.Text = "Current Day - ddd";
            // 
            // rTxtAbsenceNotes
            // 
            this.rTxtAbsenceNotes.Location = new System.Drawing.Point(6, 41);
            this.rTxtAbsenceNotes.Name = "rTxtAbsenceNotes";
            this.rTxtAbsenceNotes.Size = new System.Drawing.Size(287, 145);
            this.rTxtAbsenceNotes.TabIndex = 6;
            this.rTxtAbsenceNotes.Text = "";
            // 
            // TimesheetAbsenceDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxAbsenceTable);
            this.Controls.Add(this.grpBoxSelectEmployee);
            this.Controls.Add(this.lblAbsenceDataTitle);
            this.Name = "TimesheetAbsenceDataControl";
            this.Size = new System.Drawing.Size(320, 359);
            this.Load += new System.EventHandler(this.TimesheetAbsenceDataControl_Load);
            this.grpBoxSelectEmployee.ResumeLayout(false);
            this.grpBoxAbsenceTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.absenceDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAbsenceDataTitle;
        private System.Windows.Forms.GroupBox grpBoxSelectEmployee;
        private System.Windows.Forms.ComboBox comboBoxSelectEmployee;
        private System.Windows.Forms.GroupBox grpBoxAbsenceTable;
        private System.Windows.Forms.DataGridView absenceDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMonday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTuesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnWednesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnThursday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFriday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rTxtAbsenceNotes;
        private System.Windows.Forms.Label lblCurrentDay;
        private System.Windows.Forms.Button btnPreviousDay;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Button btnSaveAbsenceNotes;
    }
}
