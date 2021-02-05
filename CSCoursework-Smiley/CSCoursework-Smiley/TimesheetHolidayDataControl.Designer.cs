namespace CSCoursework_Smiley
{
    partial class TimesheetHolidayDataControl
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
            this.lblHolidayDataTitle = new System.Windows.Forms.Label();
            this.comboBoxSelectEmployee = new System.Windows.Forms.ComboBox();
            this.grpBoxSelectEmployee = new System.Windows.Forms.GroupBox();
            this.grpBoxHolidayTable = new System.Windows.Forms.GroupBox();
            this.holidayDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMonday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnTuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnWednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnThursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFriday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpBoxSelectEmployee.SuspendLayout();
            this.grpBoxHolidayTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHolidayDataTitle
            // 
            this.lblHolidayDataTitle.AutoSize = true;
            this.lblHolidayDataTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHolidayDataTitle.Location = new System.Drawing.Point(4, 4);
            this.lblHolidayDataTitle.Name = "lblHolidayDataTitle";
            this.lblHolidayDataTitle.Size = new System.Drawing.Size(159, 21);
            this.lblHolidayDataTitle.TabIndex = 0;
            this.lblHolidayDataTitle.Text = "Input Holiday Data";
            // 
            // comboBoxSelectEmployee
            // 
            this.comboBoxSelectEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectEmployee.FormattingEnabled = true;
            this.comboBoxSelectEmployee.Location = new System.Drawing.Point(6, 20);
            this.comboBoxSelectEmployee.Name = "comboBoxSelectEmployee";
            this.comboBoxSelectEmployee.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSelectEmployee.TabIndex = 1;
            this.comboBoxSelectEmployee.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectEmployee_SelectedIndexChanged_1);
            this.comboBoxSelectEmployee.Enter += new System.EventHandler(this.comboBoxSelectEmployee_Enter);
            this.comboBoxSelectEmployee.Leave += new System.EventHandler(this.comboBoxSelectEmployee_Leave);
            // 
            // grpBoxSelectEmployee
            // 
            this.grpBoxSelectEmployee.Controls.Add(this.comboBoxSelectEmployee);
            this.grpBoxSelectEmployee.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxSelectEmployee.Location = new System.Drawing.Point(8, 28);
            this.grpBoxSelectEmployee.Name = "grpBoxSelectEmployee";
            this.grpBoxSelectEmployee.Size = new System.Drawing.Size(299, 50);
            this.grpBoxSelectEmployee.TabIndex = 2;
            this.grpBoxSelectEmployee.TabStop = false;
            this.grpBoxSelectEmployee.Text = "Select Employee";
            // 
            // grpBoxHolidayTable
            // 
            this.grpBoxHolidayTable.Controls.Add(this.holidayDataGridView);
            this.grpBoxHolidayTable.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxHolidayTable.Location = new System.Drawing.Point(8, 85);
            this.grpBoxHolidayTable.Name = "grpBoxHolidayTable";
            this.grpBoxHolidayTable.Size = new System.Drawing.Size(299, 73);
            this.grpBoxHolidayTable.TabIndex = 3;
            this.grpBoxHolidayTable.TabStop = false;
            this.grpBoxHolidayTable.Text = "Holiday Table";
            // 
            // holidayDataGridView
            // 
            this.holidayDataGridView.AllowUserToAddRows = false;
            this.holidayDataGridView.AllowUserToDeleteRows = false;
            this.holidayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.holidayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMonday,
            this.ColumnTuesday,
            this.ColumnWednesday,
            this.ColumnThursday,
            this.ColumnFriday});
            this.holidayDataGridView.Location = new System.Drawing.Point(12, 20);
            this.holidayDataGridView.Name = "holidayDataGridView";
            this.holidayDataGridView.RowHeadersVisible = false;
            this.holidayDataGridView.Size = new System.Drawing.Size(276, 47);
            this.holidayDataGridView.TabIndex = 0;
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
            // TimesheetHolidayDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxHolidayTable);
            this.Controls.Add(this.grpBoxSelectEmployee);
            this.Controls.Add(this.lblHolidayDataTitle);
            this.Name = "TimesheetHolidayDataControl";
            this.Size = new System.Drawing.Size(320, 161);
            this.Load += new System.EventHandler(this.TimesheetHolidayDataControl_Load);
            this.grpBoxSelectEmployee.ResumeLayout(false);
            this.grpBoxHolidayTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHolidayDataTitle;
        private System.Windows.Forms.ComboBox comboBoxSelectEmployee;
        private System.Windows.Forms.GroupBox grpBoxSelectEmployee;
        private System.Windows.Forms.GroupBox grpBoxHolidayTable;
        private System.Windows.Forms.DataGridView holidayDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMonday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTuesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnWednesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnThursday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFriday;
    }
}
