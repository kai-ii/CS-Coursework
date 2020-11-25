using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace CSCoursework_Smiley
{
    public partial class Dashboard : Form
    {
        //Form Moving
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //Defines background and highlight colours
        System.Drawing.Color backgroundColour = System.Drawing.Color.FromArgb(245, 208, 226);
        System.Drawing.Color highlightColour = System.Drawing.Color.FromArgb(221, 165, 182);

        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        string username;
        public Dashboard(string username1)
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            username = username1;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SmileyLogo.Image = Properties.Resources.SmileyLogo;
            btnExitDashboard.Image = Properties.Resources.Close_Button;
            ResetButtonColours();
            btnDashboard.BackColor = highlightColour;
            dashboardControl1.Username = username;
            dashboardControl1.BringToFront();
        }
        private void ResetButtonColours()
        {
            btnDashboard.BackColor = backgroundColour;
            btnStaff.BackColor = backgroundColour;
            btnRota.BackColor = backgroundColour;
            btnTimesheet.BackColor = backgroundColour;
            btnPayslip.BackColor = backgroundColour;
            btnExport.BackColor = backgroundColour;
            btnSettings.BackColor = backgroundColour;
            btnAdmin.BackColor = backgroundColour;
            btnLogout.BackColor = backgroundColour;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnDashboard.BackColor = highlightColour;
            dashboardControl1.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnStaff.BackColor = highlightColour;
            staffControl1.BringToFront();
        }

        private void btnRota_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnRota.BackColor = highlightColour;
            rotaControl1.BringToFront();
        }

        private void btnTimesheet_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnTimesheet.BackColor = highlightColour;
            timesheetControl1.BringToFront();
        }

        private void btnPayslip_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnPayslip.BackColor = highlightColour;
            payslipControl1.BringToFront();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnExport.BackColor = highlightColour;
            exportControl1.BringToFront();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnSettings.BackColor = highlightColour;
            settingsControl1.BringToFront();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ResetButtonColours();
            btnAdmin.BackColor = highlightColour;
            adminControl1.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Show Login-Form again
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
        private void InitializeDatabaseConnection()
        {
            //Initialize variables
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FormattedDatabasePath;
            string FullDatabasePath;
            string dbSource;

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "/TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                FormattedDatabasePath = CurrentProjectPath.Remove(CurrentProjectPath.Length - 31, 31); //Cuts off the last 31 chars which gives the directory which the database is located
                FullDatabasePath = FormattedDatabasePath + DatabasePath;
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
            }
            catch
            {
                MessageBox.Show("Error establishing database connection.");
            }
        }
    }
}
