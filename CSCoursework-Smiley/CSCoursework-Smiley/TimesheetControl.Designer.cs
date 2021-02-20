namespace CSCoursework_Smiley
{
    partial class TimesheetControl
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
            this.rotaDataGrid = new System.Windows.Forms.DataGridView();
            this.columnStaffMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondayRotaIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondayRotaOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondayTimesheetIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondayTimesheetOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayRotaIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayRotaOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayTimesheetIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayTimesheetOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayRotaIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayRotaOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayTimesheetIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayTimesheetOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayRotaIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayRotaOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayTimesheetIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayTimesheetOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayRotaIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayRotaOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayTimesheetIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayTimesheetOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotaHeaderDataGrid = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekDayThrusday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxClockInput = new System.Windows.Forms.CheckBox();
            this.btnSaveRota = new System.Windows.Forms.Button();
            this.btnInputAbsenceData = new System.Windows.Forms.Button();
            this.btnInputHolidayData = new System.Windows.Forms.Button();
            this.lblCurrentWeek = new System.Windows.Forms.Label();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.btnPrevWeek = new System.Windows.Forms.Button();
            this.btnSaveClockSelection = new System.Windows.Forms.Button();
            this.timesheetAbsenceDataControl1 = new CSCoursework_Smiley.TimesheetAbsenceDataControl();
            this.timesheetHolidayDataControl1 = new CSCoursework_Smiley.TimesheetHolidayDataControl();
            this.clockMinuteSelectControl1 = new CSCoursework_Smiley.ClockMinuteSelectControl();
            this.clockHourSelectControl1 = new CSCoursework_Smiley.ClockHourSelectControl();
            ((System.ComponentModel.ISupportInitialize)(this.rotaDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaHeaderDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // rotaDataGrid
            // 
            this.rotaDataGrid.AllowUserToAddRows = false;
            this.rotaDataGrid.AllowUserToDeleteRows = false;
            this.rotaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rotaDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnStaffMember,
            this.MondayRotaIn,
            this.MondayRotaOut,
            this.MondayTimesheetIn,
            this.MondayTimesheetOut,
            this.TuesdayRotaIn,
            this.TuesdayRotaOut,
            this.TuesdayTimesheetIn,
            this.TuesdayTimesheetOut,
            this.WednesdayRotaIn,
            this.WednesdayRotaOut,
            this.WednesdayTimesheetIn,
            this.WednesdayTimesheetOut,
            this.ThursdayRotaIn,
            this.ThursdayRotaOut,
            this.ThursdayTimesheetIn,
            this.ThursdayTimesheetOut,
            this.FridayRotaIn,
            this.FridayRotaOut,
            this.FridayTimesheetIn,
            this.FridayTimesheetOut});
            this.rotaDataGrid.Location = new System.Drawing.Point(3, 98);
            this.rotaDataGrid.Name = "rotaDataGrid";
            this.rotaDataGrid.Size = new System.Drawing.Size(808, 378);
            this.rotaDataGrid.TabIndex = 3;
            // 
            // columnStaffMember
            // 
            this.columnStaffMember.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnStaffMember.HeaderText = "Staff Member";
            this.columnStaffMember.Name = "columnStaffMember";
            this.columnStaffMember.Width = 60;
            // 
            // MondayRotaIn
            // 
            this.MondayRotaIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MondayRotaIn.HeaderText = "In";
            this.MondayRotaIn.Name = "MondayRotaIn";
            // 
            // MondayRotaOut
            // 
            this.MondayRotaOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MondayRotaOut.HeaderText = "Out";
            this.MondayRotaOut.Name = "MondayRotaOut";
            // 
            // MondayTimesheetIn
            // 
            this.MondayTimesheetIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MondayTimesheetIn.HeaderText = "In";
            this.MondayTimesheetIn.Name = "MondayTimesheetIn";
            // 
            // MondayTimesheetOut
            // 
            this.MondayTimesheetOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MondayTimesheetOut.HeaderText = "Out";
            this.MondayTimesheetOut.Name = "MondayTimesheetOut";
            // 
            // TuesdayRotaIn
            // 
            this.TuesdayRotaIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TuesdayRotaIn.HeaderText = "In";
            this.TuesdayRotaIn.Name = "TuesdayRotaIn";
            // 
            // TuesdayRotaOut
            // 
            this.TuesdayRotaOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TuesdayRotaOut.HeaderText = "Out";
            this.TuesdayRotaOut.Name = "TuesdayRotaOut";
            // 
            // TuesdayTimesheetIn
            // 
            this.TuesdayTimesheetIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TuesdayTimesheetIn.HeaderText = "In";
            this.TuesdayTimesheetIn.Name = "TuesdayTimesheetIn";
            // 
            // TuesdayTimesheetOut
            // 
            this.TuesdayTimesheetOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TuesdayTimesheetOut.HeaderText = "Out";
            this.TuesdayTimesheetOut.Name = "TuesdayTimesheetOut";
            // 
            // WednesdayRotaIn
            // 
            this.WednesdayRotaIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WednesdayRotaIn.HeaderText = "In";
            this.WednesdayRotaIn.Name = "WednesdayRotaIn";
            // 
            // WednesdayRotaOut
            // 
            this.WednesdayRotaOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WednesdayRotaOut.HeaderText = "Out";
            this.WednesdayRotaOut.Name = "WednesdayRotaOut";
            // 
            // WednesdayTimesheetIn
            // 
            this.WednesdayTimesheetIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WednesdayTimesheetIn.HeaderText = "In";
            this.WednesdayTimesheetIn.Name = "WednesdayTimesheetIn";
            // 
            // WednesdayTimesheetOut
            // 
            this.WednesdayTimesheetOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WednesdayTimesheetOut.HeaderText = "Out";
            this.WednesdayTimesheetOut.Name = "WednesdayTimesheetOut";
            // 
            // ThursdayRotaIn
            // 
            this.ThursdayRotaIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThursdayRotaIn.HeaderText = "In";
            this.ThursdayRotaIn.Name = "ThursdayRotaIn";
            // 
            // ThursdayRotaOut
            // 
            this.ThursdayRotaOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThursdayRotaOut.HeaderText = "Out";
            this.ThursdayRotaOut.Name = "ThursdayRotaOut";
            // 
            // ThursdayTimesheetIn
            // 
            this.ThursdayTimesheetIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThursdayTimesheetIn.HeaderText = "In";
            this.ThursdayTimesheetIn.Name = "ThursdayTimesheetIn";
            // 
            // ThursdayTimesheetOut
            // 
            this.ThursdayTimesheetOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThursdayTimesheetOut.HeaderText = "Out";
            this.ThursdayTimesheetOut.Name = "ThursdayTimesheetOut";
            // 
            // FridayRotaIn
            // 
            this.FridayRotaIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FridayRotaIn.HeaderText = "In";
            this.FridayRotaIn.Name = "FridayRotaIn";
            // 
            // FridayRotaOut
            // 
            this.FridayRotaOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FridayRotaOut.HeaderText = "Out";
            this.FridayRotaOut.Name = "FridayRotaOut";
            // 
            // FridayTimesheetIn
            // 
            this.FridayTimesheetIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FridayTimesheetIn.HeaderText = "In";
            this.FridayTimesheetIn.Name = "FridayTimesheetIn";
            // 
            // FridayTimesheetOut
            // 
            this.FridayTimesheetOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FridayTimesheetOut.HeaderText = "Out";
            this.FridayTimesheetOut.Name = "FridayTimesheetOut";
            // 
            // rotaHeaderDataGrid
            // 
            this.rotaHeaderDataGrid.AllowUserToAddRows = false;
            this.rotaHeaderDataGrid.AllowUserToDeleteRows = false;
            this.rotaHeaderDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rotaHeaderDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.weekdayMonday,
            this.weekdayTuesday,
            this.weekdayWednesday,
            this.weekDayThrusday,
            this.weekdayFriday});
            this.rotaHeaderDataGrid.Location = new System.Drawing.Point(3, 77);
            this.rotaHeaderDataGrid.Name = "rotaHeaderDataGrid";
            this.rotaHeaderDataGrid.ReadOnly = true;
            this.rotaHeaderDataGrid.Size = new System.Drawing.Size(808, 23);
            this.rotaHeaderDataGrid.TabIndex = 2;
            this.rotaHeaderDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rotaHeaderDataGrid_CellContentClick);
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Date.FillWeight = 304.5685F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 60;
            // 
            // weekdayMonday
            // 
            this.weekdayMonday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayMonday.FillWeight = 59.08629F;
            this.weekdayMonday.HeaderText = "Monday";
            this.weekdayMonday.Name = "weekdayMonday";
            this.weekdayMonday.ReadOnly = true;
            // 
            // weekdayTuesday
            // 
            this.weekdayTuesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayTuesday.FillWeight = 59.08629F;
            this.weekdayTuesday.HeaderText = "Tuesday";
            this.weekdayTuesday.Name = "weekdayTuesday";
            this.weekdayTuesday.ReadOnly = true;
            // 
            // weekdayWednesday
            // 
            this.weekdayWednesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayWednesday.FillWeight = 59.08629F;
            this.weekdayWednesday.HeaderText = "Wednesday";
            this.weekdayWednesday.Name = "weekdayWednesday";
            this.weekdayWednesday.ReadOnly = true;
            // 
            // weekDayThrusday
            // 
            this.weekDayThrusday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekDayThrusday.FillWeight = 59.08629F;
            this.weekDayThrusday.HeaderText = "Thursday";
            this.weekDayThrusday.Name = "weekDayThrusday";
            this.weekDayThrusday.ReadOnly = true;
            // 
            // weekdayFriday
            // 
            this.weekdayFriday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayFriday.FillWeight = 59.08629F;
            this.weekdayFriday.HeaderText = "Friday";
            this.weekdayFriday.Name = "weekdayFriday";
            this.weekdayFriday.ReadOnly = true;
            // 
            // checkBoxClockInput
            // 
            this.checkBoxClockInput.AutoSize = true;
            this.checkBoxClockInput.Location = new System.Drawing.Point(3, 54);
            this.checkBoxClockInput.Name = "checkBoxClockInput";
            this.checkBoxClockInput.Size = new System.Drawing.Size(80, 17);
            this.checkBoxClockInput.TabIndex = 4;
            this.checkBoxClockInput.Text = "Clock Input";
            this.checkBoxClockInput.UseVisualStyleBackColor = true;
            this.checkBoxClockInput.CheckedChanged += new System.EventHandler(this.checkBoxClockInput_CheckedChanged);
            // 
            // btnSaveRota
            // 
            this.btnSaveRota.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRota.Location = new System.Drawing.Point(669, 588);
            this.btnSaveRota.Name = "btnSaveRota";
            this.btnSaveRota.Size = new System.Drawing.Size(142, 45);
            this.btnSaveRota.TabIndex = 11;
            this.btnSaveRota.Text = "Save";
            this.btnSaveRota.UseVisualStyleBackColor = true;
            this.btnSaveRota.Click += new System.EventHandler(this.btnSaveRota_Click);
            // 
            // btnInputAbsenceData
            // 
            this.btnInputAbsenceData.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInputAbsenceData.Location = new System.Drawing.Point(669, 536);
            this.btnInputAbsenceData.Name = "btnInputAbsenceData";
            this.btnInputAbsenceData.Size = new System.Drawing.Size(142, 45);
            this.btnInputAbsenceData.TabIndex = 12;
            this.btnInputAbsenceData.Text = "Input Absence";
            this.btnInputAbsenceData.UseVisualStyleBackColor = true;
            this.btnInputAbsenceData.Click += new System.EventHandler(this.btnInputAbsenceData_Click);
            // 
            // btnInputHolidayData
            // 
            this.btnInputHolidayData.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInputHolidayData.Location = new System.Drawing.Point(669, 484);
            this.btnInputHolidayData.Name = "btnInputHolidayData";
            this.btnInputHolidayData.Size = new System.Drawing.Size(142, 45);
            this.btnInputHolidayData.TabIndex = 13;
            this.btnInputHolidayData.Text = "Input Holiday";
            this.btnInputHolidayData.UseVisualStyleBackColor = true;
            this.btnInputHolidayData.Click += new System.EventHandler(this.btnInputHolidayData_Click);
            // 
            // lblCurrentWeek
            // 
            this.lblCurrentWeek.AutoSize = true;
            this.lblCurrentWeek.Location = new System.Drawing.Point(338, 8);
            this.lblCurrentWeek.Name = "lblCurrentWeek";
            this.lblCurrentWeek.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentWeek.TabIndex = 14;
            this.lblCurrentWeek.Text = "Current Week";
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Location = new System.Drawing.Point(736, 4);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(75, 23);
            this.btnNextWeek.TabIndex = 15;
            this.btnNextWeek.Text = "Next Week";
            this.btnNextWeek.UseVisualStyleBackColor = true;
            this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click_1);
            // 
            // btnPrevWeek
            // 
            this.btnPrevWeek.Location = new System.Drawing.Point(3, 3);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(75, 23);
            this.btnPrevWeek.TabIndex = 16;
            this.btnPrevWeek.Text = "Prev Week";
            this.btnPrevWeek.UseVisualStyleBackColor = true;
            this.btnPrevWeek.Click += new System.EventHandler(this.btnPrevWeek_Click);
            // 
            // btnSaveClockSelection
            // 
            this.btnSaveClockSelection.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveClockSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveClockSelection.Location = new System.Drawing.Point(246, 348);
            this.btnSaveClockSelection.Name = "btnSaveClockSelection";
            this.btnSaveClockSelection.Size = new System.Drawing.Size(150, 23);
            this.btnSaveClockSelection.TabIndex = 19;
            this.btnSaveClockSelection.Text = "Save";
            this.btnSaveClockSelection.UseVisualStyleBackColor = false;
            this.btnSaveClockSelection.Visible = false;
            this.btnSaveClockSelection.Click += new System.EventHandler(this.btnSaveClockSelection_Click);
            // 
            // timesheetAbsenceDataControl1
            // 
            this.timesheetAbsenceDataControl1.Location = new System.Drawing.Point(491, 119);
            this.timesheetAbsenceDataControl1.Name = "timesheetAbsenceDataControl1";
            this.timesheetAbsenceDataControl1.Size = new System.Drawing.Size(320, 359);
            this.timesheetAbsenceDataControl1.TabIndex = 22;
            this.timesheetAbsenceDataControl1.Visible = false;
            // 
            // timesheetHolidayDataControl1
            // 
            this.timesheetHolidayDataControl1.Location = new System.Drawing.Point(491, 317);
            this.timesheetHolidayDataControl1.Name = "timesheetHolidayDataControl1";
            this.timesheetHolidayDataControl1.Size = new System.Drawing.Size(320, 161);
            this.timesheetHolidayDataControl1.TabIndex = 21;
            this.timesheetHolidayDataControl1.Visible = false;
            // 
            // clockMinuteSelectControl1
            // 
            this.clockMinuteSelectControl1.BackColor = System.Drawing.Color.White;
            this.clockMinuteSelectControl1.Location = new System.Drawing.Point(452, 200);
            this.clockMinuteSelectControl1.Name = "clockMinuteSelectControl1";
            this.clockMinuteSelectControl1.Size = new System.Drawing.Size(150, 148);
            this.clockMinuteSelectControl1.TabIndex = 18;
            this.clockMinuteSelectControl1.Visible = false;
            // 
            // clockHourSelectControl1
            // 
            this.clockHourSelectControl1.BackColor = System.Drawing.Color.White;
            this.clockHourSelectControl1.Location = new System.Drawing.Point(246, 201);
            this.clockHourSelectControl1.Name = "clockHourSelectControl1";
            this.clockHourSelectControl1.Size = new System.Drawing.Size(150, 147);
            this.clockHourSelectControl1.TabIndex = 17;
            this.clockHourSelectControl1.Visible = false;
            // 
            // TimesheetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timesheetAbsenceDataControl1);
            this.Controls.Add(this.timesheetHolidayDataControl1);
            this.Controls.Add(this.btnSaveClockSelection);
            this.Controls.Add(this.clockMinuteSelectControl1);
            this.Controls.Add(this.clockHourSelectControl1);
            this.Controls.Add(this.btnPrevWeek);
            this.Controls.Add(this.btnNextWeek);
            this.Controls.Add(this.lblCurrentWeek);
            this.Controls.Add(this.btnInputHolidayData);
            this.Controls.Add(this.btnInputAbsenceData);
            this.Controls.Add(this.btnSaveRota);
            this.Controls.Add(this.checkBoxClockInput);
            this.Controls.Add(this.rotaDataGrid);
            this.Controls.Add(this.rotaHeaderDataGrid);
            this.Name = "TimesheetControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.TimesheetControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rotaDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaHeaderDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rotaDataGrid;
        private System.Windows.Forms.DataGridView rotaHeaderDataGrid;
        private System.Windows.Forms.CheckBox checkBoxClockInput;
        private System.Windows.Forms.Button btnSaveRota;
        private System.Windows.Forms.Button btnInputAbsenceData;
        private System.Windows.Forms.Button btnInputHolidayData;
        private System.Windows.Forms.Label lblCurrentWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Button btnPrevWeek;
        private ClockHourSelectControl clockHourSelectControl1;
        private ClockMinuteSelectControl clockMinuteSelectControl1;
        private System.Windows.Forms.Button btnSaveClockSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStaffMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn MondayRotaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MondayRotaOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn MondayTimesheetIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MondayTimesheetOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesdayRotaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesdayRotaOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesdayTimesheetIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesdayTimesheetOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn WednesdayRotaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WednesdayRotaOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn WednesdayTimesheetIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WednesdayTimesheetOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursdayRotaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursdayRotaOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursdayTimesheetIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursdayTimesheetOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn FridayRotaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FridayRotaOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn FridayTimesheetIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FridayTimesheetOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekDayThrusday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayFriday;
        private TimesheetHolidayDataControl timesheetHolidayDataControl1;
        private TimesheetAbsenceDataControl timesheetAbsenceDataControl1;
    }
}
