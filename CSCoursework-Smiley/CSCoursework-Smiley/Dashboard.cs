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
        Color backgroundColour; // = Color.FromArgb(245, 208, 226); default
        Color highlightColour; // = Color.FromArgb(221, 165, 182); default

        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        string username;
        int userID;
        string password;
        public Dashboard(string Username, Color BackgroundColour, Color HighlightColour, int UserID, string Password)
        {
            InitializeComponent();
            username = Username;
            backgroundColour = BackgroundColour;
            highlightColour = HighlightColour;
            userID = UserID;
            password = Password;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SmileyLogo.Image = Properties.Resources.SmileyLogo;
            btnExitDashboard.Image = Properties.Resources.Close_Button;
            ResetBackgroundColours();
            btnDashboard.BackColor = highlightColour;
            dashboardControl1.Username = username;
            dashboardControl1.BringToFront();
            PassBackgroundHighlightColours();
            SetParentChildForms();
            InitializeDatabaseConnection();
            PassSettingsUserInfo();
            InitializeParentChildFormRelationships();
        }

        private void InitializeParentChildFormRelationships()
        {
            adminControl1.parentForm = this;
        }

        public void UpdateUserPassword(string Password)
        {
            password = Password;

            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblUsers] SET [password]='{password}' WHERE [user_id]={userID};"; //square brackets? :)
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        private void PassSettingsUserInfo()
        {
            settingsControl1.userUsername = username;
            settingsControl1.userPassword = password;
            settingsControl1.UpdateUsernamePasswordTextboxes();
        }
        private void InitializeDatabaseConnection()
        {
            //Initialize variables
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FullDatabasePath;
            string dbSource;

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                FullDatabasePath = CurrentProjectPath + DatabasePath;
                //MessageBox.Show(FullDatabasePath);
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
                con.Close();
            }
            catch
            {
                MessageBox.Show($"Error establishing database connection");
            }
        }

        private void SetParentChildForms()
        {
            settingsControl1.parentForm = this;
        }

        public void UpdateUserColours(Color BackgroundColour, Color HighlightColour)
        {
            backgroundColour = BackgroundColour;
            highlightColour = HighlightColour;
            ResetBackgroundColours();
            PassBackgroundHighlightColours();

            //Open database connection
            con.Open();

            //Initialize variables
            DataSet UserColourInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblUsers where user_id={userID}"; //settings_base_colour, settings_highlight_colour
            da = new OleDbDataAdapter(sql, con);
            UserColourInfoDS = new DataSet();
            da.Fill(UserColourInfoDS, "UserColourInfo");

            //Close database connection
            con.Close();

            DataTable UserColourInfoTable = UserColourInfoDS.Tables["UserColourInfo"];

            
            //This line of code is needed for the update builder to be autogenerated so the da.Update line works
            _ = new OleDbCommandBuilder(da);

            DataRow row = UserColourInfoTable.Rows[0];
            row["settings_base_colour"] = $"{backgroundColour.R.ToString()}, {backgroundColour.G.ToString()}, {backgroundColour.B.ToString()}";
            row["settings_highlight_colour"] = $"{highlightColour.R.ToString()}, {highlightColour.G.ToString()}, {highlightColour.B.ToString()}";
            da.Update(UserColourInfoDS, "UserColourInfo");
        }
        private void PassBackgroundHighlightColours()
        {
            timesheetControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
            rotaControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
            settingsControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
        }
        private void ResetBackgroundColours()
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
            LeftPanel.BackColor = backgroundColour;
            LeftBottomPanel.BackColor = backgroundColour;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnDashboard.BackColor = highlightColour;
            dashboardControl1.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnStaff.BackColor = highlightColour;
            staffControl1.BringToFront();
        }

        private void btnRota_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnRota.BackColor = highlightColour;
            rotaControl1.BringToFront();
        }

        private void btnTimesheet_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnTimesheet.BackColor = highlightColour;
            timesheetControl1.BringToFront();
        }

        private void btnPayslip_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnPayslip.BackColor = highlightColour;
            payslipControl1.BringToFront();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnExport.BackColor = highlightColour;
            exportControl1.BringToFront();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
            btnSettings.BackColor = highlightColour;
            settingsControl1.BringToFront();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ResetBackgroundColours();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ResetControls()
        {
            staffControl1.UpdateStaffControl();
            rotaControl1.UpdateRotaControl();
            timesheetControl1.UpdateTimesheetControl();
        }
    }
}
