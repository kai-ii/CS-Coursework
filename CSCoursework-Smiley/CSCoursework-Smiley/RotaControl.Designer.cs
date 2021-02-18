namespace CSCoursework_Smiley
{
    partial class RotaControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rotaHeaderDataGrid = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekDayThrusday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotaDataGrid = new System.Windows.Forms.DataGridView();
            this.columnStaffMember = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.checkBoxClockInput = new System.Windows.Forms.CheckBox();
            this.btnSaveClockSelection = new System.Windows.Forms.Button();
            this.lblCurrentWeek = new System.Windows.Forms.Label();
            this.btnPrevWeek = new System.Windows.Forms.Button();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.btnPrintRota = new System.Windows.Forms.Button();
            this.btnSaveRota = new System.Windows.Forms.Button();
            this.btnClearRota = new System.Windows.Forms.Button();
            this.clockMinuteSelectControl1 = new CSCoursework_Smiley.ClockMinuteSelectControl();
            this.clockHourSelectControl1 = new CSCoursework_Smiley.ClockHourSelectControl();
            ((System.ComponentModel.ISupportInitialize)(this.rotaHeaderDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaDataGrid)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rotaHeaderDataGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.rotaHeaderDataGrid.Location = new System.Drawing.Point(3, 77);
            this.rotaHeaderDataGrid.Name = "rotaHeaderDataGrid";
            this.rotaHeaderDataGrid.ReadOnly = true;
            this.rotaHeaderDataGrid.Size = new System.Drawing.Size(808, 23);
            this.rotaHeaderDataGrid.TabIndex = 0;
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
            // rotaDataGrid
            // 
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rotaDataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.rotaDataGrid.Location = new System.Drawing.Point(3, 98);
            this.rotaDataGrid.Name = "rotaDataGrid";
            this.rotaDataGrid.Size = new System.Drawing.Size(808, 382);
            this.rotaDataGrid.TabIndex = 1;
            // 
            // columnStaffMember
            // 
            this.columnStaffMember.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnStaffMember.HeaderText = "Staff Member";
            this.columnStaffMember.Name = "columnStaffMember";
            this.columnStaffMember.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnStaffMember.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnStaffMember.Width = 60;
            // 
            // MondayRotaIn
            // 
            this.MondayRotaIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MondayRotaIn.HeaderText = "In";
            this.MondayRotaIn.Name = "MondayRotaIn";
            this.MondayRotaIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.MondayTimesheetIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // checkBoxClockInput
            // 
            this.checkBoxClockInput.AutoSize = true;
            this.checkBoxClockInput.Location = new System.Drawing.Point(4, 54);
            this.checkBoxClockInput.Name = "checkBoxClockInput";
            this.checkBoxClockInput.Size = new System.Drawing.Size(80, 17);
            this.checkBoxClockInput.TabIndex = 2;
            this.checkBoxClockInput.Text = "Clock Input";
            this.checkBoxClockInput.UseVisualStyleBackColor = true;
            this.checkBoxClockInput.CheckedChanged += new System.EventHandler(this.checkBoxClockInput_CheckedChanged);
            // 
            // btnSaveClockSelection
            // 
            this.btnSaveClockSelection.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveClockSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveClockSelection.Location = new System.Drawing.Point(138, 367);
            this.btnSaveClockSelection.Name = "btnSaveClockSelection";
            this.btnSaveClockSelection.Size = new System.Drawing.Size(150, 23);
            this.btnSaveClockSelection.TabIndex = 4;
            this.btnSaveClockSelection.Text = "Save";
            this.btnSaveClockSelection.UseVisualStyleBackColor = false;
            this.btnSaveClockSelection.Visible = false;
            this.btnSaveClockSelection.Click += new System.EventHandler(this.btnSaveClockSelection_Click);
            // 
            // lblCurrentWeek
            // 
            this.lblCurrentWeek.AutoSize = true;
            this.lblCurrentWeek.Location = new System.Drawing.Point(330, 8);
            this.lblCurrentWeek.Name = "lblCurrentWeek";
            this.lblCurrentWeek.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentWeek.TabIndex = 6;
            this.lblCurrentWeek.Text = "Current Week";
            // 
            // btnPrevWeek
            // 
            this.btnPrevWeek.Location = new System.Drawing.Point(4, 3);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(75, 23);
            this.btnPrevWeek.TabIndex = 7;
            this.btnPrevWeek.Text = "Prev Week";
            this.btnPrevWeek.UseVisualStyleBackColor = true;
            this.btnPrevWeek.Click += new System.EventHandler(this.btnPrevWeek_Click);
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Location = new System.Drawing.Point(736, 3);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(75, 23);
            this.btnNextWeek.TabIndex = 8;
            this.btnNextWeek.Text = "Next Week";
            this.btnNextWeek.UseVisualStyleBackColor = true;
            this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click);
            // 
            // btnPrintRota
            // 
            this.btnPrintRota.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRota.Location = new System.Drawing.Point(669, 537);
            this.btnPrintRota.Name = "btnPrintRota";
            this.btnPrintRota.Size = new System.Drawing.Size(142, 45);
            this.btnPrintRota.TabIndex = 9;
            this.btnPrintRota.Text = "Print Rota";
            this.btnPrintRota.UseVisualStyleBackColor = true;
            this.btnPrintRota.Click += new System.EventHandler(this.btnPrintRota_Click);
            // 
            // btnSaveRota
            // 
            this.btnSaveRota.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRota.Location = new System.Drawing.Point(669, 588);
            this.btnSaveRota.Name = "btnSaveRota";
            this.btnSaveRota.Size = new System.Drawing.Size(142, 45);
            this.btnSaveRota.TabIndex = 10;
            this.btnSaveRota.Text = "Save";
            this.btnSaveRota.UseVisualStyleBackColor = true;
            this.btnSaveRota.Click += new System.EventHandler(this.btnSaveRota_Click);
            // 
            // btnClearRota
            // 
            this.btnClearRota.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearRota.Location = new System.Drawing.Point(669, 486);
            this.btnClearRota.Name = "btnClearRota";
            this.btnClearRota.Size = new System.Drawing.Size(142, 45);
            this.btnClearRota.TabIndex = 11;
            this.btnClearRota.Text = "Clear Rota";
            this.btnClearRota.UseVisualStyleBackColor = true;
            this.btnClearRota.Click += new System.EventHandler(this.btnClearRota_Click);
            // 
            // clockMinuteSelectControl1
            // 
            this.clockMinuteSelectControl1.BackColor = System.Drawing.Color.White;
            this.clockMinuteSelectControl1.Location = new System.Drawing.Point(330, 220);
            this.clockMinuteSelectControl1.Name = "clockMinuteSelectControl1";
            this.clockMinuteSelectControl1.Size = new System.Drawing.Size(150, 148);
            this.clockMinuteSelectControl1.TabIndex = 5;
            this.clockMinuteSelectControl1.Visible = false;
            // 
            // clockHourSelectControl1
            // 
            this.clockHourSelectControl1.BackColor = System.Drawing.Color.White;
            this.clockHourSelectControl1.Location = new System.Drawing.Point(138, 219);
            this.clockHourSelectControl1.Name = "clockHourSelectControl1";
            this.clockHourSelectControl1.Size = new System.Drawing.Size(150, 149);
            this.clockHourSelectControl1.TabIndex = 3;
            this.clockHourSelectControl1.Visible = false;
            // 
            // RotaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearRota);
            this.Controls.Add(this.btnSaveRota);
            this.Controls.Add(this.btnPrintRota);
            this.Controls.Add(this.btnNextWeek);
            this.Controls.Add(this.btnPrevWeek);
            this.Controls.Add(this.lblCurrentWeek);
            this.Controls.Add(this.clockMinuteSelectControl1);
            this.Controls.Add(this.btnSaveClockSelection);
            this.Controls.Add(this.clockHourSelectControl1);
            this.Controls.Add(this.checkBoxClockInput);
            this.Controls.Add(this.rotaDataGrid);
            this.Controls.Add(this.rotaHeaderDataGrid);
            this.Name = "RotaControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.RotaControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rotaHeaderDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rotaHeaderDataGrid;
        private System.Windows.Forms.DataGridView rotaDataGrid;
        private System.Windows.Forms.CheckBox checkBoxClockInput;
        private ClockHourSelectControl clockHourSelectControl1;
        private System.Windows.Forms.Button btnSaveClockSelection;
        private ClockMinuteSelectControl clockMinuteSelectControl1;
        private System.Windows.Forms.Label lblCurrentWeek;
        private System.Windows.Forms.Button btnPrevWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Button btnPrintRota;
        private System.Windows.Forms.Button btnSaveRota;
        private System.Windows.Forms.Button btnClearRota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekDayThrusday;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekdayFriday;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnStaffMember;
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
    }
}
