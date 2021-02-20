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

        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        string username;
        int userID;
        string password;
        bool[] permissionArray;
        bool permissionAllStaff = false;
        bool showdateTime;
        public Dashboard(string Username, Color BackgroundColour, Color HighlightColour, int UserID, string Password, bool[] PermissionArray, bool ShowDateTime)
        {
            // Standard form initialize component call.
            InitializeComponent();
            // Initialize form variables with the values given by the loginForm when creating the Dashboard.
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
            // Initialize this form.
            SmileyLogo.Image = Properties.Resources.SmileyLogo;
            btnExitDashboard.Image = Properties.Resources.Close_Button;
            ResetBackgroundColours();

            // Initialize the database connection string, to be passed to all other forms.
            InitializeDatabaseConnection();

            // Initialize controls, self documenting.
            PassBackgroundHighlightColours();
            InitializePermissions();
            SendDatabaseConnectionToControls();
            PassSettingsControlUserInfo();
            InitializeDashboardControl();
            InitializeParentChildFormRelationships();
            DisplayDateTimeLabel(showdateTime);
            InitializeChildForms();
        }
        private void SendDatabaseConnectionToControls()
        {
            // Send the connection string established in the dashboard load to all other forms.
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
            // Send the username to be displayed to the dashboard control as a welcome message.
            btnDashboard.BackColor = highlightColour; // UI effect to give feedback to the user that they have clicked the dashboard control button.
            dashboardControl1.SetUsername(username);
            dashboardControl1.BringToFront();
        }
        private void InitializeChildForms()
        {
            // Set up the settings control with the data from the login form.
            settingsControl1.UpdateShowDateTimeCheckbox(showdateTime);
        }
        public void DisplayDateTimeLabel(bool dateTimeLabelBool)
        {
            // Display the datetime label which shows the date and the current time if the user has this option set as true in their database record.
            lblDateTime.Visible = dateTimeLabelBool;
        }
        public void SaveSettingsShowDateTimeLabel(bool updateValue)
        {
            // A function accessed by the settings control to set the datetime settings in the current users record to save the settings for the next time they load the application.
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
            // Initialize the array of possible button positions as well as the buttons being placed
            int buttonPositionCounter = 0;
            Point[] buttonPositionArray = { new Point(0, 74), new Point(0, 127), new Point(0, 180), new Point(0, 233), new Point(0, 286), new Point(0, 339), new Point(0, 392), new Point(0, 445), new Point(0, 498) };
            Button[] buttonArray = { btnDashboard, btnStaff, btnRota, btnTimesheet, btnPayslip, btnExport, btnAdmin };
            for (int permission = 0; permission<permissionArray.Length; permission++)
            {
                // For each permission that was set using the login form permissionArray
                if (permission < 2 && permissionArray[permission])
                {
                    // If the permission is less than 2 then the permissions and buttonArray buttons line up so if the permission is true just set that button to the next point and increment the point for the next button
                    buttonArray[permission].Location = buttonPositionArray[permission];
                    buttonArray[permission].Visible = true;
                    buttonPositionCounter++;
                }
                else if (permission == 2 && permissionArray[permission])
                {
                    // The permission in index 2 is the allstaff permission, this means that if this is true, the admin view of the staff section should be shown and not the personal view (the default view).
                    permissionAllStaff = true;
                }
                else if (permission > 2 && permissionArray[permission])
                {
                    // If the permission is greater than 2 then the buttonArray buttons are mismatched with the permissionArray by 1 since permissionArray 2 is just an option for the staff section and not an entirely new section. The indexes are adjusted accordingly below.
                    buttonArray[permission - 1].Location = buttonPositionArray[permission - 1];
                    buttonArray[permission - 1].Visible = true;
                    buttonPositionCounter++;
                }
            }
            // The settings button and the logout button are always displayed.
            btnSettings.Location = buttonPositionArray[buttonPositionCounter];
            btnLogout.Location = buttonPositionArray[++buttonPositionCounter];
            // If the admin button is visible then the user must be the admin, therefore show the admin version of the dashboard control by calling the function userIsAdmin with true rather than false. With this data the dashboard control displays slightly different data with slightly differing options.
            if (btnAdmin.Visible) { dashboardControl1.userIsAdmin(true); }
            else { dashboardControl1.userIsAdmin(false); }
        }
        private void InitializeParentChildFormRelationships()
        {
            // Set this form to be the parent form for the settings, admin and timesheet controls to allow them to use the public functions of this form.[
            settingsControl1.SetParentForm(this);
            adminControl1.SetParentForm(this);
            timesheetControl1.SetParentForm(this);
        }
        public void UpdateDashboardControlGraph()
        {
            // When this is called update the graph on the dashboard control, this is called when the timesheet is updated.
            dashboardControl1.UpdateGraph();
        }
        public void UpdatePayslipJobPositions()
        {
            // When this is called update the job positions on the payslip section, this is called when manage job positions is updated.
            payslipControl1.UpdatePayslipInfo();
        }

        public void UpdateUserPassword(string Password)
        {
            /*Updates the password when a user goes through the account recovery process*/
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
            // Sets the username and password in the settings control.
            settingsControl1.SetUserUsername(username);
            settingsControl1.SetUserPassword(password);
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

            // Try catch is used to ensure the connection string has been established. If it hasn't a message is shown to the user.
            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                FullDatabasePath = CurrentProjectPath + DatabasePath;
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
            // Initialize variables.
            backgroundColour = BackgroundColour;
            highlightColour = HighlightColour;
            ResetBackgroundColours();
            PassBackgroundHighlightColours();

            // Open database connection.
            con.Open();

            // Initialize database variables.
            DataSet UserColourInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get user base and highlight colours.
            sql = $"SELECT settings_base_colour, settings_highlight_colour FROM tblUsers where user_id={userID}";
            da = new OleDbDataAdapter(sql, con);
            UserColourInfoDS = new DataSet();
            da.Fill(UserColourInfoDS, "UserColourInfo");

            // Close database connection.
            con.Close();

            // Establish user colour info data table.
            DataTable UserColourInfoTable = UserColourInfoDS.Tables["UserColourInfo"];

            
            // This line of code is needed for the command builder to be generated for the data adapter so the da.Update line works.
            _ = new OleDbCommandBuilder(da);

            // Update the database.
            DataRow row = UserColourInfoTable.Rows[0];
            row["settings_base_colour"] = $"{backgroundColour.R}, {backgroundColour.G}, {backgroundColour.B}";
            row["settings_highlight_colour"] = $"{highlightColour.R}, {highlightColour.G}, {highlightColour.B}";
            da.Update(UserColourInfoDS, "UserColourInfo");
        }
        private void PassBackgroundHighlightColours()
        {
            // Set the background and highlight colours in the corresponding forms.
            timesheetControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
            rotaControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
            settingsControl1.setBackgroundHighlightColours(backgroundColour, highlightColour);
        }
        private void ResetBackgroundColours()
        {
            // Resets all of the buttons and panels in the dashboard form to their default background colours so it doesn't look like multiple buttons have been pressed at the same time.
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
            // Calls the Application.Exit() function to properly close the program, as opposed to "this.hide()" for example which would only make the program appear to have been closed.
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
            ResetBackgroundColours();
            btnDashboard.BackColor = highlightColour;
            dashboardControl1.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
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
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
            ResetBackgroundColours();
            btnRota.BackColor = highlightColour;
            rotaControl1.BringToFront();
        }

        private void btnTimesheet_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
            ResetBackgroundColours();
            btnTimesheet.BackColor = highlightColour;
            timesheetControl1.BringToFront();
        }

        private void btnPayslip_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
            ResetBackgroundColours();
            btnPayslip.BackColor = highlightColour;
            payslipControl1.BringToFront();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
            ResetBackgroundColours();
            btnExport.BackColor = highlightColour;
            exportControl1.BringToFront();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
            ResetBackgroundColours();
            btnSettings.BackColor = highlightColour;
            settingsControl1.BringToFront();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // When this button has been clicked, reset all of the button colours and then set this button to the highlight colour. Afterwards bring the corresponding control to the front. Therefore there is no need to hide or show forms since they are all the same size, once one is brought to the front it appears as if the others become invisible.
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
            // Each time the timer ticks (set to once a second) get the current date and time and set the dateTime label to this value whether it is visible or not. This ensures if it is toggled on and off, the time will always be correct and there is no delay.
            string time = DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss");
            string date = DateTime.Now.Date.ToString("d");
            lblDateTime.Text = $"{date} - {time}";
        }
    }
}
