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
    public partial class LoginForm : Form
    {
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();

        // Form Moving
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public LoginForm()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Initialize Database.
            InitializeDatabaseConnection();

            // Initialize Form.
            InitializeUsernameTextbox();
            InitializePasswordTextbox();
            btnSubmit.Image = Properties.Resources.SigninSubmit;
            btnExit.Image = Properties.Resources.Close_Button;
            this.MouseDown += LoginForm_MouseDown;
            InitializeAnnouncement();
            SmileyLogo.BringToFront();

            // Initialize Relationships.
            InitializeParentChildRelationships();

            // Initialize Child Forms.
            GetTextboxAutocompleteData();
            GetUserData();
        }
        private void GetUserData()
        {
            // Initialize database variables.
            DataSet UserInfoDS;
            OleDbDataAdapter da;
            DataTable UserInfoTable;
            string sql;

            // Open the database connection.
            con.Open();

            // Initialize user dataset.
            sql = $"SELECT username, security_question_1, security_answer_1, security_question_2, security_answer_2, security_question_3, security_answer_3, user_id, password FROM tblUsers";
            da = new OleDbDataAdapter(sql, con);
            UserInfoDS = new DataSet();
            da.Fill(UserInfoDS, "UserInfo");

            // Close the database connection.
            con.Close();

            // Initialize the user data table.
            UserInfoTable = UserInfoDS.Tables["UserInfo"];

            // Add the user info to the userInfoArray for use in the account recovery form.
            string[] userInfoArray = new string[UserInfoTable.Rows.Count];
            for (int staffPair = 0; staffPair < UserInfoTable.Rows.Count; staffPair++)
            {
                userInfoArray[staffPair] = $"{UserInfoTable.Rows[staffPair].Field<string>("username")},{UserInfoTable.Rows[staffPair].Field<string>("security_question_1")},{UserInfoTable.Rows[staffPair].Field<string>("security_answer_1")},{UserInfoTable.Rows[staffPair].Field<string>("security_question_2")},{UserInfoTable.Rows[staffPair].Field<string>("security_answer_2")},{UserInfoTable.Rows[staffPair].Field<string>("security_question_3")},{UserInfoTable.Rows[staffPair].Field<string>("security_answer_3")},{UserInfoTable.Rows[staffPair].Field<int>("user_id").ToString()},{UserInfoTable.Rows[staffPair].Field<string>("password")}";
            }
            // Update the user info in the account recovery form.
            loginFormRecoverAccount1.UpdateUserData(userInfoArray);
        }
        private void InitializeAnnouncement()
        {
            // Initialize database variables.
            DataSet AnnouncementDS;
            OleDbDataAdapter da;
            DataTable AnnouncementTable;
            string sql;

            // Open database connection.
            con.Open();

            // Initialize the announcement dataset.
            sql = $"SELECT announcement_title, announcement_details FROM tblAnnouncement";
            da = new OleDbDataAdapter(sql, con);
            AnnouncementDS = new DataSet();
            da.Fill(AnnouncementDS, "AnnouncementInfo");

            // Initialize the announcement datatable.
            AnnouncementTable = AnnouncementDS.Tables["AnnouncementInfo"];

            // Close the database connection.
            con.Close();

            // Update the announcement labels with the announcement data grabbed from the database.
            rTxtAnnouncementTitle.Text = AnnouncementTable.Rows[0].Field<string>("announcement_title");
            rTxtAnnouncementDetails.Text = AnnouncementTable.Rows[0].Field<string>("announcement_details");
        }
        private void InitializeParentChildRelationships()
        {
            // Set this form to be the parent form to the create account and account recovery forms so they can access this forms/classes public functions.
            loginFormCreateAccount1.SetParentForm(this);
            loginFormRecoverAccount1.SetParentForm(this);
        }
        private void LoginForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Allows the user to move the form around without the titlebar, required when using a flat format and wanting to allow the user to move the window around.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        void InitializeUsernameTextbox()
        {
            // Set up the username text box events, this sets the text to be 'Username' when the user is not clicked into it for UI modern flat style/intuition.
            UsernameTextbox.ForeColor = SystemColors.GrayText;
            UsernameTextbox.Text = "Username";
            this.UsernameTextbox.Leave += new System.EventHandler(this.UsernameTextbox_Leave);
            this.UsernameTextbox.Enter += new System.EventHandler(this.UsernameTextbox_Enter);
        }
        private void UsernameTextbox_Enter(object sender, EventArgs e)
        {
            // Set up the username text box events, this sets the text to be 'Username' when the user is not clicked into it for UI modern flat style/intuition.
            if (UsernameTextbox.Text == "Username")
            {
                UsernameTextbox.Text = "";
                UsernameTextbox.ForeColor = SystemColors.WindowText;
            }
        }
        private void UsernameTextbox_Leave(object sender, EventArgs e)
        {
            // Set up the username text box events, this sets the text to be 'Username' when the user is not clicked into it for UI modern flat style/intuition.
            if (UsernameTextbox.Text.Length == 0)
            {
                UsernameTextbox.Text = "Username";
                UsernameTextbox.ForeColor = SystemColors.GrayText;
            }
        }

        void InitializePasswordTextbox()
        {
            // Set up the password text box events, this sets the text to be 'Password' when the user is not clicked into it for UI modern flat style/intuition.
            PasswordTextbox.ForeColor = SystemColors.GrayText;
            PasswordTextbox.Text = "Password";
            this.PasswordTextbox.Leave += new System.EventHandler(this.PasswordTextbox_Leave);
            this.PasswordTextbox.Enter += new System.EventHandler(this.PasswordTextbox_Enter);
        }
        private void PasswordTextbox_Enter(object sender, EventArgs e)
        {
            // Set up the password text box events, this sets the text to be 'Password' when the user is not clicked into it for UI modern flat style/intuition.
            if (PasswordTextbox.Text == "Password")
            {
                PasswordTextbox.Text = "";
                PasswordTextbox.ForeColor = SystemColors.WindowText;
                if (!checkBoxShowPassword.Checked) { PasswordTextbox.PasswordChar = '*'; }
            }
        }
        private void PasswordTextbox_Leave(object sender, EventArgs e)
        {
            // Set up the password text box events, this sets the text to be 'Password' when the user is not clicked into it for UI modern flat style/intuition.
            if (PasswordTextbox.Text.Length == 0)
            {
                PasswordTextbox.Text = "Password";
                PasswordTextbox.ForeColor = SystemColors.GrayText;
                if (!checkBoxShowPassword.Checked) { PasswordTextbox.PasswordChar = '\0'; }
            }
        }

        private void InitializeDatabaseConnection()
        {
            // Initialize database variables.
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FullDatabasePath = "";
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
                //-----exception handling-----
                // Displays the database path that is trying to be accessed, this helps the user to place the database in the correct directory.
                Console.WriteLine($"Error establishing database connection LoginForm. FullDatabasePath = {FullDatabasePath}");
                MessageBox.Show($"Error establishing database connection LoginForm. FullDatabasePath = {FullDatabasePath}. Try putting the database in this location.");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // When the submit button is clicked, call the respective function.
            SubmitUsernamePassword();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Calls the Application.Exit() function to properly close the program, as opposed to "this.hide()" for example which would only make the program appear to have been closed.
            Application.Exit();
        }

        private void SubmitUsernamePassword()
        {
            // Validation.
            // Presence Check.
            if (UsernameTextbox.Text.Length == 0 || UsernameTextbox.Text == "Username") // When clicked out of username textbox it contains 'Username'.
            {
                MessageBox.Show("Username must not be empty.");
                return;
            }
            else if (PasswordTextbox.Text.Length == 0 || PasswordTextbox.Text == "Password") // When clicked out of password textbox it contains 'Password'.
            {
                MessageBox.Show("Password must not be empty");
                return;
            }

            // Initialize variables.
            DataSet LoginInfoDS;
            OleDbDataAdapter da;
            DataTable LoginInfoTable;
            string sql;

            // Check Login Details.

            // Open the database connection.
            con.Open();

            // Initialize the login dataset. This sql uses 'StrComp' to check for capitalisation since a normal sql query isn't case sensitive.
            sql = $"SELECT * FROM tblUsers WHERE StrComp(username, '{UsernameTextbox.Text}', 0)=0 AND StrComp(password, '{CreateMD5(PasswordTextbox.Text)}', 0)=0";
            da = new OleDbDataAdapter(sql, con);
            LoginInfoDS = new DataSet();
            da.Fill(LoginInfoDS, "LoginInfo");

            // Initialize the login datatable.
            LoginInfoTable = LoginInfoDS.Tables["LoginInfo"];

            // Close the database connection.
            con.Close();

            // Check if a row exists for the given username password combo
            if (LoginInfoTable.Rows.Count > 0)
            {
                // If there is a row associated with the given username and password then initialize the userID, permissionID, highlight colour, background colour, permissions and showdatetime variables and pass them into the dashboard for use there.
                int userID = LoginInfoTable.Rows[0].Field<int>("user_id");
                int permissionID = LoginInfoTable.Rows[0].Field<int>("permission_id");
                string highlightColourRGBString = LoginInfoTable.Rows[0].Field<string>("settings_highlight_colour");
                string backgroundColourRGBString = LoginInfoTable.Rows[0].Field<string>("settings_base_colour");
                string[] highlightColourRBGStringArray = highlightColourRGBString.Split(',');
                string[] backgroundColourRBGStringArray = backgroundColourRGBString.Split(',');
                int[] highlightColourRGBIntArray = highlightColourRBGStringArray.Select(item => int.Parse(item)).ToArray();
                int[] backgroundColourRGBIntArray = backgroundColourRBGStringArray.Select(item => int.Parse(item)).ToArray();
                Color highlightColourRGB = Color.FromArgb(highlightColourRGBIntArray[0], highlightColourRGBIntArray[1], highlightColourRGBIntArray[2]);
                Color backgroundColourRGB = Color.FromArgb(backgroundColourRGBIntArray[0], backgroundColourRGBIntArray[1], backgroundColourRGBIntArray[2]);
                bool[] staffPermissionArray = GetPermissions(permissionID);
                bool showDateTime = LoginInfoTable.Rows[0].Field<bool>("settings_show_date_time");
                // Generate a new dashboard with these parameters, show this user catered dashboard and then hide the loginform. The loginform cannot be closed here because the dashboard is created in it, so closing the loginform would close the entire program.
                Dashboard dashboard = new Dashboard(UsernameTextbox.Text, backgroundColourRGB, highlightColourRGB, userID, PasswordTextbox.Text, staffPermissionArray, showDateTime);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                //----------Exception handling----------
                // If there is not a row for the submitted username and password send the user a message and stop processing by returning out of the void function.
                MessageBox.Show("Incorrect login details, please try again.");
                return;
            }
        }
        private bool[] GetPermissions(int permissionID)
        {
            // Initialize database variables.
            DataSet PermissionDS;
            OleDbDataAdapter da;
            DataTable PermissionTable;
            string sql;

            // Open the database connection.
            con.Open();

            // Initialize the permision dataset.
            sql = $"SELECT * FROM tblPermissions WHERE permission_id={permissionID}";
            da = new OleDbDataAdapter(sql, con);
            PermissionDS = new DataSet();
            da.Fill(PermissionDS, "PermissionInfo");
            // Initialize the permission datatable.
            PermissionTable = PermissionDS.Tables["PermissionInfo"];

            // Close the database connection.
            con.Close();

            // Create a new permission array of length 8 and then assign it with each permission grabbed from the database.
            bool[] permissionArray = new bool[8];
            for (int permission = 1; permission<=8; permission++)
            {
                permissionArray[permission - 1] = Convert.ToBoolean(PermissionTable.Rows[0].ItemArray[permission]);
            }
            //foreach (bool permission in permissionArray)
            //{
            //    MessageBox.Show(permission.ToString());
            //}
            return permissionArray;
        }
        private void PasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            // If enter is pressed when in the password textbox, treat it as if the user has clicked on the submit button and check if the username password combo is valid.
            CheckEnter(e);
        }

        private void UsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            // If enter is pressed when in the password textbox, treat it as if the user has clicked on the submit button and check if the username password combo is valid.
            CheckEnter(e);
        }

        private void CheckEnter(KeyEventArgs e)
        {
            // If the key typed was enter then check the username and password to see if the user has typed in a valid username password combination.
            if (e.KeyCode == Keys.Enter)
            {
                SubmitUsernamePassword();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            // If the create account button has been clicked and the account recovery form isn't visible then show the account recovery form.
            if (!loginFormCreateAccount1.Visible && !loginFormRecoverAccount1.Visible)
            {
                loginFormCreateAccount1.Visible = true;
                lblCreateAccount.Visible = true;
                groupBoxAnnouncement.Visible = false;
            }
        }
        private void GetTextboxAutocompleteData()
        {
            // Initialize database variables.
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            DataTable StaffInfoTable;
            string sql;

            // Open the database connection.
            con.Open();

            // Initialize the staff dataset.
            sql = $"SELECT staff_firstname, staff_surname FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            // Close the database connection.
            con.Close();

            // Initialize the staff data table.
            StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            // For every staff member, add them to the autocomplete textbox in the create account form.
            string[] autocompleteArray = new string[StaffInfoTable.Rows.Count];
            for (int staffPair = 0; staffPair<StaffInfoTable.Rows.Count; staffPair++)
            {
                autocompleteArray[staffPair] = $"{StaffInfoTable.Rows[staffPair].Field<string>("staff_firstname")} {StaffInfoTable.Rows[staffPair].Field<string>("staff_surname")}";
            }
            loginFormCreateAccount1.UpdateTextboxAutocomplete(autocompleteArray);
        }
        public void CancelAccountCreation()
        {
            // If the account creation process is cancelled using the cancel button them set its visibility to be false and show the announcement again.
            loginFormCreateAccount1.Visible = false;
            lblCreateAccount.Visible = false;
            groupBoxAnnouncement.Visible = true;
        }
        public void CancelAccountRecovery()
        {
            // If the account recovery process is cancelled using the cancel button them set its visibility to be false and show the announcement again.
            loginFormRecoverAccount1.Visible = false;
            lblAccountRecovery.Visible = false;
            groupBoxAnnouncement.Visible = true;
        }
        public void SaveAccount(string username, string password, string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2, string securityQuestion3, string securityAnswer3)
        {
            // Encrypt password.
            string encryptedPassword = CreateMD5(password);

            // Initialize database variables.
            OleDbDataAdapter da;
            DataSet UserDS;
            DataSet DuplicateUserDS;
            DataTable DuplicateUserTable;
            DataTable UserTable;
            string sql;

            // Open the database connection.
            con.Open();

            // Initialize Duplicate user dataset.
            sql = $"SELECT * FROM tblUsers WHERE username={username}";
            da = new OleDbDataAdapter(sql, con);
            DuplicateUserDS = new DataSet();
            da.Fill(DuplicateUserDS, "UserInfo");

            // Initialize duplicate user datatable
            DuplicateUserTable = DuplicateUserDS.Tables["UserTable"];
            if (DuplicateUserTable.Rows.Count > 0)
            {
                // -----------Exception handling----------
                // if account exists, don't try to add a duplicate of it. This will cause many aspects of the program to crash to the point of the program becoming unusable without manually editing the database or wiping it.
                MessageBox.Show("Account already exists, aborting account creation.");
                return;
            }

            // Initialize the user dataset.
            sql = $"SELECT * FROM tblUsers";
            da = new OleDbDataAdapter(sql, con);
            UserDS = new DataSet();
            da.Fill(UserDS, "UserInfo");

            // Close the database connection.
            con.Close();

            // Initialize the user datatable.
            UserTable = UserDS.Tables["UserInfo"];

            // Command Builder, the quote prefix and suffix is required since the fields use underscores.
            var builder = new OleDbCommandBuilder(da);
            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";

            // Initialize the userID
            int userID = UserTable.Rows[UserTable.Rows.Count - 1].Field<int>("user_id") + 1;

            // Staff Table Row Addition
            DataRow newRow = UserTable.NewRow();
            newRow["user_id"] = userID;
            newRow["dashboard_id"] = 1; // Default dashboard
            newRow["permission_id"] = 2; // Default permissions
            newRow["username"] = username;
            newRow["password"] = encryptedPassword;
            newRow["settings_base_colour"] = "245, 208, 226"; //Default background colour
            newRow["settings_highlight_colour"] = "221, 165, 182"; //Default highlight colour
            newRow["settings_show_date_time"] = false;
            newRow["dashboard_notes"] = "";
            newRow["security_question_1"] = securityQuestion1;
            newRow["security_answer_1"] = securityAnswer1;
            newRow["security_question_2"] = securityQuestion2;
            newRow["security_answer_2"] = securityAnswer2;
            newRow["security_question_3"] = securityQuestion3;
            newRow["security_answer_3"] = securityAnswer3;

            // Update the database with the new users information.
            UserTable.Rows.Add(newRow);
            da.Update(UserDS, "UserInfo");
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // When the show password checkbox is changed, change the password character of the textbox accordingly.
            if (!checkBoxShowPassword.Checked)
            {
                // If the text is password then have no password character since this should say password and not have stars. Otherwise, show a password character.
                if (PasswordTextbox.Text != "Password")
                {
                    PasswordTextbox.PasswordChar = '*';
                }
                else
                {
                    PasswordTextbox.PasswordChar = '\0';
                }
            }
            else
            {
                // If it is checked then always show the password.
                PasswordTextbox.PasswordChar = '\0';
            }
        }
        private void btnCantSignIn_Click(object sender, EventArgs e)
        {
            // If the create account button has been clicked and the account recovery form isn't visible then show the account recovery form.
            if (!loginFormRecoverAccount1.Visible && !loginFormCreateAccount1.Visible)
            {
                loginFormRecoverAccount1.Visible = true;
                lblAccountRecovery.Visible = true;
                groupBoxAnnouncement.Visible = false;
            }
        }
        public void UpdatePassword(string userID, string password)
        {
            // this try catch catches any exceptions when creating a password to ensure that the program doesn't crash.
            try
            {
                // Use a manual sql command to update the password since it is a simple sql process and has less overhead than using command builders, allowing the program to run faster.
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblUsers] SET [password]='{CreateMD5(password)}' WHERE [user_id]={int.Parse(userID)};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
                // Feedback to the user to ensure they know that the password was successfully updated. This means if they put it in wrong they aren't confused as to whether or not it was them typing it in wrong or the application not updating it properly.
                MessageBox.Show("Successfully Updated Password.");
            }
            catch
            {
                // Catches an exception where the password potentially has an apostophe that isn't hashed, this is extremely unlikely but is the only possibility of an exception.
                MessageBox.Show("Failed to update password, try removing any apostrophes.");
            }
        }
    }
}
