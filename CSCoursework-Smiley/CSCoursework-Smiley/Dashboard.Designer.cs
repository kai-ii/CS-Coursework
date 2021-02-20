namespace CSCoursework_Smiley
{
    partial class Dashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPayslip = new System.Windows.Forms.Button();
            this.btnTimesheet = new System.Windows.Forms.Button();
            this.btnRota = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.LeftBottomPanel = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.SmileyLogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.btnExitDashboard = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.dashboardControl1 = new CSCoursework_Smiley.Properties.DashboardControl();
            this.rotaControl1 = new CSCoursework_Smiley.RotaControl();
            this.timesheetControl1 = new CSCoursework_Smiley.TimesheetControl();
            this.payslipControl1 = new CSCoursework_Smiley.Properties.PayslipControl();
            this.exportControl1 = new CSCoursework_Smiley.Properties.ExportControl();
            this.settingsControl1 = new CSCoursework_Smiley.Properties.SettingsControl();
            this.adminControl1 = new CSCoursework_Smiley.Properties.AdminControl();
            this.staffControl1 = new CSCoursework_Smiley.StaffControl();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmileyLogo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.LeftPanel.Controls.Add(this.btnLogout);
            this.LeftPanel.Controls.Add(this.btnAdmin);
            this.LeftPanel.Controls.Add(this.btnSettings);
            this.LeftPanel.Controls.Add(this.btnExport);
            this.LeftPanel.Controls.Add(this.btnPayslip);
            this.LeftPanel.Controls.Add(this.btnTimesheet);
            this.LeftPanel.Controls.Add(this.btnRota);
            this.LeftPanel.Controls.Add(this.btnStaff);
            this.LeftPanel.Controls.Add(this.LeftBottomPanel);
            this.LeftPanel.Controls.Add(this.btnDashboard);
            this.LeftPanel.Controls.Add(this.SmileyLogo);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(366, 710);
            this.LeftPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(0, 493);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(366, 53);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "   Log-Out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.Location = new System.Drawing.Point(0, 441);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(366, 53);
            this.btnAdmin.TabIndex = 9;
            this.btnAdmin.Text = "   Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Visible = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(0, 389);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(366, 53);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "   Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(0, 336);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(366, 53);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "   Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPayslip
            // 
            this.btnPayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnPayslip.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPayslip.FlatAppearance.BorderSize = 0;
            this.btnPayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayslip.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayslip.Location = new System.Drawing.Point(0, 285);
            this.btnPayslip.Name = "btnPayslip";
            this.btnPayslip.Size = new System.Drawing.Size(366, 53);
            this.btnPayslip.TabIndex = 6;
            this.btnPayslip.Text = "   Payslip";
            this.btnPayslip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayslip.UseVisualStyleBackColor = false;
            this.btnPayslip.Visible = false;
            this.btnPayslip.Click += new System.EventHandler(this.btnPayslip_Click);
            // 
            // btnTimesheet
            // 
            this.btnTimesheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnTimesheet.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTimesheet.FlatAppearance.BorderSize = 0;
            this.btnTimesheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimesheet.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimesheet.Location = new System.Drawing.Point(0, 233);
            this.btnTimesheet.Name = "btnTimesheet";
            this.btnTimesheet.Size = new System.Drawing.Size(366, 53);
            this.btnTimesheet.TabIndex = 5;
            this.btnTimesheet.Text = "   Timesheet";
            this.btnTimesheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimesheet.UseVisualStyleBackColor = false;
            this.btnTimesheet.Visible = false;
            this.btnTimesheet.Click += new System.EventHandler(this.btnTimesheet_Click);
            // 
            // btnRota
            // 
            this.btnRota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnRota.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRota.FlatAppearance.BorderSize = 0;
            this.btnRota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRota.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRota.Location = new System.Drawing.Point(0, 180);
            this.btnRota.Name = "btnRota";
            this.btnRota.Size = new System.Drawing.Size(366, 53);
            this.btnRota.TabIndex = 4;
            this.btnRota.Text = "   Rota";
            this.btnRota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRota.UseVisualStyleBackColor = false;
            this.btnRota.Visible = false;
            this.btnRota.Click += new System.EventHandler(this.btnRota_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.Location = new System.Drawing.Point(0, 127);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(366, 53);
            this.btnStaff.TabIndex = 3;
            this.btnStaff.Text = "   Staff";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Visible = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // LeftBottomPanel
            // 
            this.LeftBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(165)))), ((int)(((byte)(182)))));
            this.LeftBottomPanel.Location = new System.Drawing.Point(0, 582);
            this.LeftBottomPanel.Name = "LeftBottomPanel";
            this.LeftBottomPanel.Size = new System.Drawing.Size(366, 128);
            this.LeftBottomPanel.TabIndex = 2;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(165)))), ((int)(((byte)(182)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(0, 74);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(366, 53);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Visible = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // SmileyLogo
            // 
            this.SmileyLogo.Image = ((System.Drawing.Image)(resources.GetObject("SmileyLogo.Image")));
            this.SmileyLogo.Location = new System.Drawing.Point(0, 0);
            this.SmileyLogo.Name = "SmileyLogo";
            this.SmileyLogo.Size = new System.Drawing.Size(366, 75);
            this.SmileyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SmileyLogo.TabIndex = 0;
            this.SmileyLogo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.lblDateTime);
            this.panel2.Controls.Add(this.ExitButton);
            this.panel2.Controls.Add(this.btnExitDashboard);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(366, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 75);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(515, 5);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(299, 30);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "dd/mm/yyyy - hh:mm:ss";
            this.lblDateTime.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::CSCoursework_Smiley.Properties.Resources.Close_Button;
            this.ExitButton.Location = new System.Drawing.Point(777, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(37, 35);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // btnExitDashboard
            // 
            this.btnExitDashboard.Location = new System.Drawing.Point(840, 0);
            this.btnExitDashboard.Name = "btnExitDashboard";
            this.btnExitDashboard.Size = new System.Drawing.Size(37, 35);
            this.btnExitDashboard.TabIndex = 2;
            this.btnExitDashboard.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(879, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 35);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            // 
            // dashboardControl1
            // 
            this.dashboardControl1.Location = new System.Drawing.Point(366, 74);
            this.dashboardControl1.Name = "dashboardControl1";
            this.dashboardControl1.Size = new System.Drawing.Size(814, 636);
            this.dashboardControl1.TabIndex = 2;
            // 
            // rotaControl1
            // 
            this.rotaControl1.Location = new System.Drawing.Point(366, 74);
            this.rotaControl1.Name = "rotaControl1";
            this.rotaControl1.Size = new System.Drawing.Size(814, 636);
            this.rotaControl1.TabIndex = 4;
            // 
            // timesheetControl1
            // 
            this.timesheetControl1.Location = new System.Drawing.Point(366, 74);
            this.timesheetControl1.Name = "timesheetControl1";
            this.timesheetControl1.Size = new System.Drawing.Size(814, 636);
            this.timesheetControl1.TabIndex = 5;
            // 
            // payslipControl1
            // 
            this.payslipControl1.Location = new System.Drawing.Point(366, 74);
            this.payslipControl1.Name = "payslipControl1";
            this.payslipControl1.Size = new System.Drawing.Size(814, 636);
            this.payslipControl1.TabIndex = 6;
            // 
            // exportControl1
            // 
            this.exportControl1.Location = new System.Drawing.Point(366, 74);
            this.exportControl1.Name = "exportControl1";
            this.exportControl1.Size = new System.Drawing.Size(814, 636);
            this.exportControl1.TabIndex = 7;
            // 
            // settingsControl1
            // 
            this.settingsControl1.Location = new System.Drawing.Point(366, 74);
            this.settingsControl1.Name = "settingsControl1";
            this.settingsControl1.parentForm = null;
            this.settingsControl1.Size = new System.Drawing.Size(814, 636);
            this.settingsControl1.TabIndex = 8;
            this.settingsControl1.userPassword = null;
            this.settingsControl1.userUsername = null;
            // 
            // adminControl1
            // 
            this.adminControl1.Location = new System.Drawing.Point(366, 74);
            this.adminControl1.Name = "adminControl1";
            this.adminControl1.parentForm = null;
            this.adminControl1.Size = new System.Drawing.Size(814, 636);
            this.adminControl1.TabIndex = 9;
            this.adminControl1.userID = 0;
            // 
            // staffControl1
            // 
            this.staffControl1.Location = new System.Drawing.Point(366, 74);
            this.staffControl1.Name = "staffControl1";
            this.staffControl1.Size = new System.Drawing.Size(814, 636);
            this.staffControl1.TabIndex = 10;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 710);
            this.Controls.Add(this.staffControl1);
            this.Controls.Add(this.adminControl1);
            this.Controls.Add(this.settingsControl1);
            this.Controls.Add(this.exportControl1);
            this.Controls.Add(this.payslipControl1);
            this.Controls.Add(this.timesheetControl1);
            this.Controls.Add(this.rotaControl1);
            this.Controls.Add(this.dashboardControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LeftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SmileyLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox SmileyLogo;
        private System.Windows.Forms.PictureBox btnExitDashboard;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel LeftBottomPanel;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPayslip;
        private System.Windows.Forms.Button btnTimesheet;
        private System.Windows.Forms.Button btnRota;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.PictureBox ExitButton;
        private Properties.DashboardControl dashboardControl1;
        private RotaControl rotaControl1;
        private TimesheetControl timesheetControl1;
        private Properties.PayslipControl payslipControl1;
        private Properties.ExportControl exportControl1;
        private Properties.SettingsControl settingsControl1;
        private Properties.AdminControl adminControl1;
        private StaffControl staffControl1;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label lblDateTime;
    }
}