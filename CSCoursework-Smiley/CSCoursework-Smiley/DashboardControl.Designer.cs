namespace CSCoursework_Smiley.Properties
{
    partial class DashboardControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LoggedInGroupBox = new System.Windows.Forms.GroupBox();
            this.lblLoggedInAs = new System.Windows.Forms.Label();
            this.rTxtNotes = new System.Windows.Forms.RichTextBox();
            this.lineChartHoursWorked = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMondayInfo = new System.Windows.Forms.Label();
            this.lblTuesdayInfo = new System.Windows.Forms.Label();
            this.lblWednesdayInfo = new System.Windows.Forms.Label();
            this.lblThursdayInfo = new System.Windows.Forms.Label();
            this.lblFridayInfo = new System.Windows.Forms.Label();
            this.rTxtMondayInfo = new System.Windows.Forms.RichTextBox();
            this.rTxtTuesdayInfo = new System.Windows.Forms.RichTextBox();
            this.rTxtWednesdayInfo = new System.Windows.Forms.RichTextBox();
            this.rTxtThursdayInfo = new System.Windows.Forms.RichTextBox();
            this.rTxtFridayInfo = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveDashboard = new System.Windows.Forms.Button();
            this.btnSaveNotes = new System.Windows.Forms.Button();
            this.LoggedInGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineChartHoursWorked)).BeginInit();
            this.SuspendLayout();
            // 
            // LoggedInGroupBox
            // 
            this.LoggedInGroupBox.Controls.Add(this.lblLoggedInAs);
            this.LoggedInGroupBox.Location = new System.Drawing.Point(20, 15);
            this.LoggedInGroupBox.Name = "LoggedInGroupBox";
            this.LoggedInGroupBox.Size = new System.Drawing.Size(338, 118);
            this.LoggedInGroupBox.TabIndex = 0;
            this.LoggedInGroupBox.TabStop = false;
            // 
            // lblLoggedInAs
            // 
            this.lblLoggedInAs.AutoSize = true;
            this.lblLoggedInAs.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInAs.Location = new System.Drawing.Point(16, 27);
            this.lblLoggedInAs.Name = "lblLoggedInAs";
            this.lblLoggedInAs.Size = new System.Drawing.Size(266, 24);
            this.lblLoggedInAs.TabIndex = 0;
            this.lblLoggedInAs.Text = "Logged in as: {username}";
            // 
            // rTxtNotes
            // 
            this.rTxtNotes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtNotes.Location = new System.Drawing.Point(585, 155);
            this.rTxtNotes.Name = "rTxtNotes";
            this.rTxtNotes.Size = new System.Drawing.Size(199, 459);
            this.rTxtNotes.TabIndex = 1;
            this.rTxtNotes.Text = "";
            // 
            // lineChartHoursWorked
            // 
            chartArea5.Name = "ChartArea1";
            this.lineChartHoursWorked.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.lineChartHoursWorked.Legends.Add(legend5);
            this.lineChartHoursWorked.Location = new System.Drawing.Point(20, 139);
            this.lineChartHoursWorked.Name = "lineChartHoursWorked";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.lineChartHoursWorked.Series.Add(series5);
            this.lineChartHoursWorked.Size = new System.Drawing.Size(536, 475);
            this.lineChartHoursWorked.TabIndex = 2;
            this.lineChartHoursWorked.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(499, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Weekly Calendar";
            // 
            // lblMondayInfo
            // 
            this.lblMondayInfo.AutoSize = true;
            this.lblMondayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMondayInfo.Location = new System.Drawing.Point(388, 42);
            this.lblMondayInfo.Name = "lblMondayInfo";
            this.lblMondayInfo.Size = new System.Drawing.Size(33, 16);
            this.lblMondayInfo.TabIndex = 4;
            this.lblMondayInfo.Text = "Mon";
            // 
            // lblTuesdayInfo
            // 
            this.lblTuesdayInfo.AutoSize = true;
            this.lblTuesdayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesdayInfo.Location = new System.Drawing.Point(470, 42);
            this.lblTuesdayInfo.Name = "lblTuesdayInfo";
            this.lblTuesdayInfo.Size = new System.Drawing.Size(27, 16);
            this.lblTuesdayInfo.TabIndex = 5;
            this.lblTuesdayInfo.Text = "Tue";
            // 
            // lblWednesdayInfo
            // 
            this.lblWednesdayInfo.AutoSize = true;
            this.lblWednesdayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesdayInfo.Location = new System.Drawing.Point(552, 42);
            this.lblWednesdayInfo.Name = "lblWednesdayInfo";
            this.lblWednesdayInfo.Size = new System.Drawing.Size(34, 16);
            this.lblWednesdayInfo.TabIndex = 6;
            this.lblWednesdayInfo.Text = "Wed";
            // 
            // lblThursdayInfo
            // 
            this.lblThursdayInfo.AutoSize = true;
            this.lblThursdayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursdayInfo.Location = new System.Drawing.Point(636, 42);
            this.lblThursdayInfo.Name = "lblThursdayInfo";
            this.lblThursdayInfo.Size = new System.Drawing.Size(27, 16);
            this.lblThursdayInfo.TabIndex = 7;
            this.lblThursdayInfo.Text = "Thu";
            // 
            // lblFridayInfo
            // 
            this.lblFridayInfo.AutoSize = true;
            this.lblFridayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFridayInfo.Location = new System.Drawing.Point(723, 42);
            this.lblFridayInfo.Name = "lblFridayInfo";
            this.lblFridayInfo.Size = new System.Drawing.Size(18, 16);
            this.lblFridayInfo.TabIndex = 8;
            this.lblFridayInfo.Text = "Fri";
            // 
            // rTxtMondayInfo
            // 
            this.rTxtMondayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtMondayInfo.Location = new System.Drawing.Point(364, 58);
            this.rTxtMondayInfo.Name = "rTxtMondayInfo";
            this.rTxtMondayInfo.ReadOnly = true;
            this.rTxtMondayInfo.Size = new System.Drawing.Size(78, 75);
            this.rTxtMondayInfo.TabIndex = 9;
            this.rTxtMondayInfo.Text = "";
            // 
            // rTxtTuesdayInfo
            // 
            this.rTxtTuesdayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtTuesdayInfo.Location = new System.Drawing.Point(448, 58);
            this.rTxtTuesdayInfo.Name = "rTxtTuesdayInfo";
            this.rTxtTuesdayInfo.ReadOnly = true;
            this.rTxtTuesdayInfo.Size = new System.Drawing.Size(78, 75);
            this.rTxtTuesdayInfo.TabIndex = 10;
            this.rTxtTuesdayInfo.Text = "";
            // 
            // rTxtWednesdayInfo
            // 
            this.rTxtWednesdayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtWednesdayInfo.Location = new System.Drawing.Point(532, 58);
            this.rTxtWednesdayInfo.Name = "rTxtWednesdayInfo";
            this.rTxtWednesdayInfo.ReadOnly = true;
            this.rTxtWednesdayInfo.Size = new System.Drawing.Size(78, 75);
            this.rTxtWednesdayInfo.TabIndex = 11;
            this.rTxtWednesdayInfo.Text = "";
            // 
            // rTxtThursdayInfo
            // 
            this.rTxtThursdayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtThursdayInfo.Location = new System.Drawing.Point(616, 58);
            this.rTxtThursdayInfo.Name = "rTxtThursdayInfo";
            this.rTxtThursdayInfo.ReadOnly = true;
            this.rTxtThursdayInfo.Size = new System.Drawing.Size(78, 75);
            this.rTxtThursdayInfo.TabIndex = 12;
            this.rTxtThursdayInfo.Text = "";
            // 
            // rTxtFridayInfo
            // 
            this.rTxtFridayInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtFridayInfo.Location = new System.Drawing.Point(700, 58);
            this.rTxtFridayInfo.Name = "rTxtFridayInfo";
            this.rTxtFridayInfo.ReadOnly = true;
            this.rTxtFridayInfo.Size = new System.Drawing.Size(78, 75);
            this.rTxtFridayInfo.TabIndex = 13;
            this.rTxtFridayInfo.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(583, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Notes";
            // 
            // btnSaveDashboard
            // 
            this.btnSaveDashboard.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDashboard.Location = new System.Drawing.Point(700, 19);
            this.btnSaveDashboard.Name = "btnSaveDashboard";
            this.btnSaveDashboard.Size = new System.Drawing.Size(78, 23);
            this.btnSaveDashboard.TabIndex = 15;
            this.btnSaveDashboard.Text = "Save";
            this.btnSaveDashboard.UseVisualStyleBackColor = true;
            this.btnSaveDashboard.Visible = false;
            this.btnSaveDashboard.Click += new System.EventHandler(this.btnSaveDashboard_Click);
            // 
            // btnSaveNotes
            // 
            this.btnSaveNotes.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNotes.Location = new System.Drawing.Point(706, 591);
            this.btnSaveNotes.Name = "btnSaveNotes";
            this.btnSaveNotes.Size = new System.Drawing.Size(78, 23);
            this.btnSaveNotes.TabIndex = 16;
            this.btnSaveNotes.Text = "Save";
            this.btnSaveNotes.UseVisualStyleBackColor = true;
            this.btnSaveNotes.Click += new System.EventHandler(this.btnSaveNotes_Click);
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveNotes);
            this.Controls.Add(this.btnSaveDashboard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rTxtFridayInfo);
            this.Controls.Add(this.rTxtThursdayInfo);
            this.Controls.Add(this.rTxtWednesdayInfo);
            this.Controls.Add(this.rTxtTuesdayInfo);
            this.Controls.Add(this.rTxtMondayInfo);
            this.Controls.Add(this.lblFridayInfo);
            this.Controls.Add(this.lblThursdayInfo);
            this.Controls.Add(this.lblWednesdayInfo);
            this.Controls.Add(this.lblTuesdayInfo);
            this.Controls.Add(this.lblMondayInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineChartHoursWorked);
            this.Controls.Add(this.rTxtNotes);
            this.Controls.Add(this.LoggedInGroupBox);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.LoggedInGroupBox.ResumeLayout(false);
            this.LoggedInGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineChartHoursWorked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox LoggedInGroupBox;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.RichTextBox rTxtNotes;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChartHoursWorked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMondayInfo;
        private System.Windows.Forms.Label lblTuesdayInfo;
        private System.Windows.Forms.Label lblWednesdayInfo;
        private System.Windows.Forms.Label lblThursdayInfo;
        private System.Windows.Forms.Label lblFridayInfo;
        private System.Windows.Forms.RichTextBox rTxtMondayInfo;
        private System.Windows.Forms.RichTextBox rTxtTuesdayInfo;
        private System.Windows.Forms.RichTextBox rTxtWednesdayInfo;
        private System.Windows.Forms.RichTextBox rTxtThursdayInfo;
        private System.Windows.Forms.RichTextBox rTxtFridayInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveDashboard;
        private System.Windows.Forms.Button btnSaveNotes;
    }
}
