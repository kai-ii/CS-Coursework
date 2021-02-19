namespace CSCoursework_Smiley.Properties
{
    partial class ExportControl
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
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.lblCurrentTaxMonth = new System.Windows.Forms.Label();
            this.exportDataGrid = new System.Windows.Forms.DataGridView();
            this.rBtnFlexible = new System.Windows.Forms.RadioButton();
            this.rBtnSalaried = new System.Windows.Forms.RadioButton();
            this.btnSaveJobPositions = new System.Windows.Forms.Button();
            this.Forename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NILetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorksNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exportDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(735, 3);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(75, 23);
            this.btnNextMonth.TabIndex = 14;
            this.btnNextMonth.Text = "Next Month";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Location = new System.Drawing.Point(3, 3);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(75, 23);
            this.btnPrevMonth.TabIndex = 13;
            this.btnPrevMonth.Text = "Prev Month";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // lblCurrentTaxMonth
            // 
            this.lblCurrentTaxMonth.AutoSize = true;
            this.lblCurrentTaxMonth.Location = new System.Drawing.Point(333, 8);
            this.lblCurrentTaxMonth.Name = "lblCurrentTaxMonth";
            this.lblCurrentTaxMonth.Size = new System.Drawing.Size(74, 13);
            this.lblCurrentTaxMonth.TabIndex = 12;
            this.lblCurrentTaxMonth.Text = "Current Month";
            // 
            // exportDataGrid
            // 
            this.exportDataGrid.AllowUserToAddRows = false;
            this.exportDataGrid.AllowUserToDeleteRows = false;
            this.exportDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exportDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Forename,
            this.Surname,
            this.PayDate,
            this.NINumber,
            this.NILetter,
            this.TaxCode,
            this.WorksNumber,
            this.StdRate,
            this.StdHours,
            this.HolidayRate,
            this.HolidayHours,
            this.TotalPay});
            this.exportDataGrid.Location = new System.Drawing.Point(3, 90);
            this.exportDataGrid.Name = "exportDataGrid";
            this.exportDataGrid.ReadOnly = true;
            this.exportDataGrid.RowHeadersVisible = false;
            this.exportDataGrid.Size = new System.Drawing.Size(807, 449);
            this.exportDataGrid.TabIndex = 15;
            // 
            // rBtnFlexible
            // 
            this.rBtnFlexible.AutoSize = true;
            this.rBtnFlexible.Location = new System.Drawing.Point(3, 67);
            this.rBtnFlexible.Name = "rBtnFlexible";
            this.rBtnFlexible.Size = new System.Drawing.Size(60, 17);
            this.rBtnFlexible.TabIndex = 17;
            this.rBtnFlexible.TabStop = true;
            this.rBtnFlexible.Text = "Flexible";
            this.rBtnFlexible.UseVisualStyleBackColor = true;
            this.rBtnFlexible.CheckedChanged += new System.EventHandler(this.rBtnFlexible_CheckedChanged);
            // 
            // rBtnSalaried
            // 
            this.rBtnSalaried.AutoSize = true;
            this.rBtnSalaried.Location = new System.Drawing.Point(3, 52);
            this.rBtnSalaried.Name = "rBtnSalaried";
            this.rBtnSalaried.Size = new System.Drawing.Size(63, 17);
            this.rBtnSalaried.TabIndex = 16;
            this.rBtnSalaried.TabStop = true;
            this.rBtnSalaried.Text = "Salaried";
            this.rBtnSalaried.UseVisualStyleBackColor = true;
            this.rBtnSalaried.CheckedChanged += new System.EventHandler(this.rBtnSalaried_CheckedChanged);
            // 
            // btnSaveJobPositions
            // 
            this.btnSaveJobPositions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveJobPositions.Location = new System.Drawing.Point(681, 545);
            this.btnSaveJobPositions.Name = "btnSaveJobPositions";
            this.btnSaveJobPositions.Size = new System.Drawing.Size(129, 37);
            this.btnSaveJobPositions.TabIndex = 18;
            this.btnSaveJobPositions.Text = "Export to CSV";
            this.btnSaveJobPositions.UseVisualStyleBackColor = true;
            this.btnSaveJobPositions.Click += new System.EventHandler(this.btnSaveJobPositions_Click);
            // 
            // Forename
            // 
            this.Forename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Forename.HeaderText = "Forename";
            this.Forename.Name = "Forename";
            this.Forename.ReadOnly = true;
            // 
            // Surname
            // 
            this.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            // 
            // PayDate
            // 
            this.PayDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PayDate.HeaderText = "Pay Date";
            this.PayDate.Name = "PayDate";
            this.PayDate.ReadOnly = true;
            // 
            // NINumber
            // 
            this.NINumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NINumber.HeaderText = "NI Number";
            this.NINumber.Name = "NINumber";
            this.NINumber.ReadOnly = true;
            // 
            // NILetter
            // 
            this.NILetter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NILetter.HeaderText = "NI Letter";
            this.NILetter.Name = "NILetter";
            this.NILetter.ReadOnly = true;
            // 
            // TaxCode
            // 
            this.TaxCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TaxCode.HeaderText = "Tax Code";
            this.TaxCode.Name = "TaxCode";
            this.TaxCode.ReadOnly = true;
            // 
            // WorksNumber
            // 
            this.WorksNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorksNumber.HeaderText = "Works Number";
            this.WorksNumber.Name = "WorksNumber";
            this.WorksNumber.ReadOnly = true;
            // 
            // StdRate
            // 
            this.StdRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StdRate.HeaderText = "Std Rate";
            this.StdRate.Name = "StdRate";
            this.StdRate.ReadOnly = true;
            // 
            // StdHours
            // 
            this.StdHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StdHours.HeaderText = "Std Hours";
            this.StdHours.Name = "StdHours";
            this.StdHours.ReadOnly = true;
            // 
            // HolidayRate
            // 
            this.HolidayRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HolidayRate.HeaderText = "Holiday Rate";
            this.HolidayRate.Name = "HolidayRate";
            this.HolidayRate.ReadOnly = true;
            // 
            // HolidayHours
            // 
            this.HolidayHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HolidayHours.HeaderText = "Holiday Hours";
            this.HolidayHours.Name = "HolidayHours";
            this.HolidayHours.ReadOnly = true;
            // 
            // TotalPay
            // 
            this.TotalPay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalPay.HeaderText = "Total Pay";
            this.TotalPay.Name = "TotalPay";
            this.TotalPay.ReadOnly = true;
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveJobPositions);
            this.Controls.Add(this.rBtnFlexible);
            this.Controls.Add(this.rBtnSalaried);
            this.Controls.Add(this.exportDataGrid);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.lblCurrentTaxMonth);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.ExportControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exportDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Label lblCurrentTaxMonth;
        private System.Windows.Forms.DataGridView exportDataGrid;
        private System.Windows.Forms.RadioButton rBtnFlexible;
        private System.Windows.Forms.RadioButton rBtnSalaried;
        private System.Windows.Forms.Button btnSaveJobPositions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Forename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NILetter;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorksNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StdRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StdHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn HolidayRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HolidayHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPay;
    }
}
