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
        Color backgroundColour = Color.FromArgb(245, 208, 226);
        Color highlightColour = Color.FromArgb(221, 165, 182);

        //Initialise variables
        string username;
        public Dashboard(string username1)
        {
            InitializeComponent();
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
            PassBackgroundHighlightColours();
        }

        private void PassBackgroundHighlightColours()
        {
            timesheetControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
            rotaControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
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
    }
}
