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
            this.components = new System.ComponentModel.Container();
            this.rotaHeaderDataGrid = new System.Windows.Forms.DataGridView();
            this.testDatabaseDataSet = new CSCoursework_Smiley.TestDatabaseDataSet();
            this.testDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblRotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblRotaTableAdapter = new CSCoursework_Smiley.TestDatabaseDataSetTableAdapters.tblRotaTableAdapter();
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
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekDayThrusday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekdayFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rotaHeaderDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // rotaHeaderDataGrid
            // 
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
            this.rotaHeaderDataGrid.Size = new System.Drawing.Size(808, 23);
            this.rotaHeaderDataGrid.TabIndex = 0;
            // 
            // testDatabaseDataSet
            // 
            this.testDatabaseDataSet.DataSetName = "TestDatabaseDataSet";
            this.testDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testDatabaseDataSetBindingSource
            // 
            this.testDatabaseDataSetBindingSource.DataSource = this.testDatabaseDataSet;
            this.testDatabaseDataSetBindingSource.Position = 0;
            // 
            // tblRotaBindingSource
            // 
            this.tblRotaBindingSource.DataMember = "tblRota";
            this.tblRotaBindingSource.DataSource = this.testDatabaseDataSetBindingSource;
            // 
            // tblRotaTableAdapter
            // 
            this.tblRotaTableAdapter.ClearBeforeFill = true;
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
            this.rotaDataGrid.TabIndex = 1;
            // 
            // columnStaffMember
            // 
            this.columnStaffMember.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnStaffMember.HeaderText = "Staff Member";
            this.columnStaffMember.Name = "columnStaffMember";
            this.columnStaffMember.Width = 128;
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
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // weekdayMonday
            // 
            this.weekdayMonday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayMonday.HeaderText = "Monday";
            this.weekdayMonday.Name = "weekdayMonday";
            // 
            // weekdayTuesday
            // 
            this.weekdayTuesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayTuesday.HeaderText = "Tuesday";
            this.weekdayTuesday.Name = "weekdayTuesday";
            // 
            // weekdayWednesday
            // 
            this.weekdayWednesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayWednesday.HeaderText = "Wednesday";
            this.weekdayWednesday.Name = "weekdayWednesday";
            // 
            // weekDayThrusday
            // 
            this.weekDayThrusday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekDayThrusday.HeaderText = "Thursday";
            this.weekDayThrusday.Name = "weekDayThrusday";
            // 
            // weekdayFriday
            // 
            this.weekdayFriday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.weekdayFriday.HeaderText = "Friday";
            this.weekdayFriday.Name = "weekdayFriday";
            // 
            // RotaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rotaDataGrid);
            this.Controls.Add(this.rotaHeaderDataGrid);
            this.Name = "RotaControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.RotaControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rotaHeaderDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rotaHeaderDataGrid;
        private TestDatabaseDataSet testDatabaseDataSet;
        private System.Windows.Forms.BindingSource testDatabaseDataSetBindingSource;
        private System.Windows.Forms.BindingSource tblRotaBindingSource;
        private TestDatabaseDataSetTableAdapters.tblRotaTableAdapter tblRotaTableAdapter;
        private System.Windows.Forms.DataGridView rotaDataGrid;
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
    }
}
