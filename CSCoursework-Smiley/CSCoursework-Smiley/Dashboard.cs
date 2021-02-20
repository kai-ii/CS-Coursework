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
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        //Defines background and highlight colours
        Color backgroundColour; // = Color.FromArgb(245, 208, 226); default
        Color highlightColour; // = Color.FromArgb(221, 165, 182); default

        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        string username;
        int userID;
        string password;
        bool[] permissionArray;
        bool permissionAllStaff = false;
        bool showdateTime;
        public Dashboard(string Username, Color BackgroundColour, Color HighlightColour, int UserID, string Password, bool[] PermissionArray, bool ShowDateTime)
        {
            InitializeComponent();
            username = Username;
            backgroundColour = BackgroundColour;
            highlightColour = HighlightColour;
            userID = UserID;
            password = Password;
            permissionArray = PermissionArray;
            showdateTime = ShowDateTime;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SmileyLogo.Image = Properties.Resources.SmileyLogo;
            btnExitDashboard.Image = Properties.Resources.Close_Button;
            ResetBackgroundColours();
            PassBackgroundHighlightColours();
            InitializeDatabaseConnection();
            InitializePermissions();
            SendDatabaseConnectionToControls();
            PassSettingsControlUserInfo();
            PassAdminControlUserInfo();
            InitializeDashboardControl();
            InitializeParentChildFormRelationships();
            DisplayDateTimeLabel(showdateTime);
            InitializeChildForms();
        }
        private void SendDatabaseConnectionToControls()
        {
            dashboardControl1.SetCon(con);
            rotaControl1.SetCon(con);
            staffControl1.SetCon(con);
            timesheetControl1.SetCon(con);
            payslipControl1.SetCon(con);
            exportControl1.SetCon(con);
            adminControl1.SetCon(con);
        }
        private void InitializeDashboardControl()
        {
            btnDashboard.BackColor = highlightColour;
            dashboardControl1.SetUsername(username);
            dashboardControl1.BringToFront();
        }
        private void InitializeChildForms()
        {
            settingsControl1.UpdateShowDateTimeCheckbox(showdateTime);
        }
        public void DisplayDateTimeLabel(bool dateTimeLabelBool)
        {
            lblDateTime.Visible = dateTimeLabelBool;
        }
        public void SaveSettingsShowDateTimeLabel(bool updateValue)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblUsers] SET [settings_show_date_time]={updateValue} WHERE [user_id]={userID};";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        private void InitializePermissions()
        {
            int buttonPositionCounter = 0;
            Point[] buttonPositionArray = { new Point(0, 74), new Point(0, 127), new Point(0, 180), new Point(0, 233), new Point(0, 286), new Point(0, 339), new Point(0, 392), new Point(0, 445), new Point(0, 498) };
            Button[] buttonArray = { btnDashboard, btnStaff, btnRota, btnTimesheet, btnPayslip, btnExport, btnAdmin };
            for (int permission = 0; permission<permissionArray.Length; permission++)
            {
                if (permission < 2 && permissionArray[permission])
                {
                    buttonArray[permission].Location = buttonPositionArray[permission];
                    buttonArray[permission].Visible = true;
                    buttonPositionCounter++;
                }
                else if (permission == 2 && permissionArray[permission])
                {
                    permissionAllStaff = true;
                }
                else if (permission > 2 && permissionArray[permission])
                {
                    buttonArray[permission - 1].Location = buttonPositionArray[permission - 1];
                    buttonArray[permission - 1].Visible = true;
                    buttonPositionCounter++;
                }
            }
            btnSettings.Location = buttonPositionArray[buttonPositionCounter];
            btnLogout.Location = buttonPositionArray[++buttonPositionCounter];
            if (btnAdmin.Visible) { dashboardControl1.userIsAdmin(true); }
            else { dashboardControl1.userIsAdmin(false); }
        }
        private void PassAdminControlUserInfo()
        {
            adminControl1.userID = userID;
        }
        private void InitializeParentChildFormRelationships()
        {
            settingsControl1.parentForm = this;
            adminControl1.parentForm = this;
            timesheetControl1.SetParentForm(this);
        }
        public void UpdateDashboardControlGraph()
        {
            dashboardControl1.UpdateGraph();
        }
        public void UpdatePayslipJobPositions()
        {
            payslipControl1.UpdatePayslipInfo();
        }

        public void UpdateUserPassword(string Password)
        {
            password = Password;

            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblUsers] SET [password]='{CreateMD5(password)}' WHERE [user_id]={userID};"; // Encrypts password
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        private void PassSettingsControlUserInfo()
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
            Application.Exit();
            //this.Close();
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
            if (!permissionAllStaff)
            {
                staffControl1.displayPersonalStaffInfo(username);
            }
            else
            {
                staffControl1.displayAllStaffInfo();
            }
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

        // Taken from https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=net-5.0
        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss");
            string date = DateTime.Now.Date.ToString("d");
            lblDateTime.Text = $"{date} - {time}";
        }
    }
}
