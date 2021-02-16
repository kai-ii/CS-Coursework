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
        //Initialise variables
        OleDbConnection con = new OleDbConnection();

        //Form Moving
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Initialize Database
            InitializeDatabaseConnection();

            //Initialize Form
            InitializeUsernameTextbox();
            InitializePasswordTextbox();
            btnSubmit.Image = Properties.Resources.SigninSubmit;
            btnExit.Image = Properties.Resources.Close_Button;
            this.MouseDown += LoginForm_MouseDown;
            InitializeAnnouncement();

            //Initialize Relationships
            InitializeParentChildRelationships();

            //Initialize Child Form
            GetTextboxAutocompleteData();
        }
        private void InitializeAnnouncement()
        {
            // Initialize variables
            DataSet AnnouncementDS;
            OleDbDataAdapter da;
            DataTable AnnouncementTable;
            string sql;

            // Open database connection
            con.Open();

            sql = $"SELECT announcement_title, announcement_details FROM tblAnnouncement";
            da = new OleDbDataAdapter(sql, con);
            AnnouncementDS = new DataSet();
            da.Fill(AnnouncementDS, "AnnouncementInfo");
            AnnouncementTable = AnnouncementDS.Tables["AnnouncementInfo"];

            con.Close();

            rTxtAnnouncementTitle.Text = AnnouncementTable.Rows[0].Field<string>("announcement_title");
            rTxtAnnouncementDetails.Text = AnnouncementTable.Rows[0].Field<string>("announcement_details");
        }
        private void InitializeParentChildRelationships()
        {
            loginFormCreateAccount1.parentForm = this;
        }
        private void LoginForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Allows the user to move the form around without the titlebar
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        void InitializeUsernameTextbox()
        {
            UsernameTextbox.ForeColor = SystemColors.GrayText;
            UsernameTextbox.Text = "Username";
            this.UsernameTextbox.Leave += new System.EventHandler(this.UsernameTextbox_Leave);
            this.UsernameTextbox.Enter += new System.EventHandler(this.UsernameTextbox_Enter);
        }
        private void UsernameTextbox_Enter(object sender, EventArgs e)
        {
            if (UsernameTextbox.Text == "Username")
            {
                UsernameTextbox.Text = "";
                UsernameTextbox.ForeColor = SystemColors.WindowText;
            }
        }
        private void UsernameTextbox_Leave(object sender, EventArgs e)
        {
            if (UsernameTextbox.Text.Length == 0)
            {
                UsernameTextbox.Text = "Username";
                UsernameTextbox.ForeColor = SystemColors.GrayText;
            }
        }

        void InitializePasswordTextbox()
        {
            PasswordTextbox.ForeColor = SystemColors.GrayText;
            PasswordTextbox.Text = "Password";
            this.PasswordTextbox.Leave += new System.EventHandler(this.PasswordTextbox_Leave);
            this.PasswordTextbox.Enter += new System.EventHandler(this.PasswordTextbox_Enter);
        }
        private void PasswordTextbox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text == "Password")
            {
                PasswordTextbox.Text = "";
                PasswordTextbox.ForeColor = SystemColors.WindowText;
                if (!checkBoxShowPassword.Checked) { PasswordTextbox.PasswordChar = '*'; }
            }
        }
        private void PasswordTextbox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text.Length == 0)
            {
                PasswordTextbox.Text = "Password";
                PasswordTextbox.ForeColor = SystemColors.GrayText;
                if (!checkBoxShowPassword.Checked) { PasswordTextbox.PasswordChar = '\0'; }
            }
        }

        private void InitializeDatabaseConnection()
        {
            //Initialize variables
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
                Console.WriteLine($"Error establishing database connection LoginForm. FullDatabasePath = {FullDatabasePath}");
                MessageBox.Show($"Error establishing database connection LoginForm. FullDatabasePath = {FullDatabasePath}");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitUsernamePassword();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitUsernamePassword()
        {
            //Validation
            //Presence Check
            if (UsernameTextbox.Text.Length == 0 || UsernameTextbox.Text == "Username") //When clicked out of username textbox it contains 'Username'.
            {
                MessageBox.Show("Username must not be empty.");
                return;
            }
            else if (PasswordTextbox.Text.Length == 0 || PasswordTextbox.Text == "Password") //When clicked out of password textbox it contains 'Password'.
            {
                MessageBox.Show("Password must not be empty");
                return;
            }

            //Initialize variables
            DataSet LoginInfoDS;
            OleDbDataAdapter da;
            DataTable LoginInfoTable;
            string sql;

            //Check Login Details
            con.Open();

            //sql = $"SELECT * FROM tblUsers WHERE username='{UsernameTextbox.Text}' AND password='{PasswordTextbox.Text}'";
            sql = $"SELECT * FROM tblUsers WHERE StrComp(username, '{UsernameTextbox.Text}', 0)=0 AND StrComp(password, '{CreateMD5(PasswordTextbox.Text)}', 0)=0";
            da = new OleDbDataAdapter(sql, con);
            LoginInfoDS = new DataSet();
            da.Fill(LoginInfoDS, "LoginInfo");
            LoginInfoTable = LoginInfoDS.Tables["LoginInfo"];

            con.Close();

            if (LoginInfoTable.Rows.Count > 0)
            {
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
                Dashboard dashboard = new Dashboard(UsernameTextbox.Text, backgroundColourRGB, highlightColourRGB, userID, PasswordTextbox.Text, staffPermissionArray, showDateTime);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect login details, please try again.");
                return;
            }
        }
        private bool[] GetPermissions(int permissionID)
        {
            // Initialize variables
            DataSet PermissionDS;
            OleDbDataAdapter da;
            DataTable PermissionTable;
            string sql;

            // Open Con
            con.Open();

            sql = $"SELECT * FROM tblPermissions WHERE permission_id={permissionID}";
            da = new OleDbDataAdapter(sql, con);
            PermissionDS = new DataSet();
            da.Fill(PermissionDS, "PermissionInfo");
            PermissionTable = PermissionDS.Tables["PermissionInfo"];

            con.Close();

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
            CheckEnter(e);
        }

        private void UsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEnter(e);
        }

        private void CheckEnter(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitUsernamePassword();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!loginFormCreateAccount1.Visible)
            {
                loginFormCreateAccount1.Visible = true;
                lblCreateAccount.Visible = true;
                groupBoxAnnouncement.Visible = false;
            }
            //GetTextboxAutocompleteData();
        }
        private void GetTextboxAutocompleteData()
        {
            //Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            DataTable StaffInfoTable;
            string sql;

            //Open Con
            con.Open();

            sql = $"SELECT staff_firstname, staff_surname FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");
            con.Close();

            StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            string[] autocompleteArray = new string[StaffInfoTable.Rows.Count];
            for (int staffPair = 0; staffPair<StaffInfoTable.Rows.Count; staffPair++)
            {
                autocompleteArray[staffPair] = $"{StaffInfoTable.Rows[staffPair].Field<string>("staff_firstname")} {StaffInfoTable.Rows[staffPair].Field<string>("staff_surname")}";
            }
            loginFormCreateAccount1.UpdateTextboxAutocomplete(autocompleteArray);
        }
        public void CancelAccountCreation()
        {
            loginFormCreateAccount1.Visible = false;
            lblCreateAccount.Visible = false;
            groupBoxAnnouncement.Visible = true;
        }
        public void SaveAccount(string username, string password, string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2, string securityQuestion3, string securityAnswer3)
        {
            //Encrypt password
            string encryptedPassword = CreateMD5(password);

            //Initialize variables
            OleDbDataAdapter da;
            DataSet UserDS;
            DataTable UserTable;
            string sql;

            //Initialize UserDS
            con.Open();

            sql = $"SELECT * FROM tblUsers";
            da = new OleDbDataAdapter(sql, con);
            UserDS = new DataSet();
            da.Fill(UserDS, "UserInfo");
            con.Close();

            UserTable = UserDS.Tables["UserInfo"];

            // Command Builder
            var builder = new OleDbCommandBuilder(da);
            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";
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

        private void LeftPanelAnchor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxShowPassword.Checked)
            {
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
                PasswordTextbox.PasswordChar = '\0';
            }
        }
    }
}
