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
            //Initialize Form
            InitializeUsernameTextbox();
            InitializePasswordTextbox();
            btnSubmit.Image = Properties.Resources.SigninSubmit;
            btnExit.Image = Properties.Resources.Close_Button;
            this.MouseDown += LoginForm_MouseDown;

            //Initialize Database
            InitializeDatabaseConnection();
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
            }
        }
        private void PasswordTextbox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text.Length == 0)
            {
                PasswordTextbox.Text = "Password";
                PasswordTextbox.ForeColor = SystemColors.GrayText;
            }
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
            //Initialize variables
            DataSet LoginInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Check Login Details
            sql = $"SELECT * FROM tblUsers WHERE username='{UsernameTextbox.Text}' AND password='{PasswordTextbox.Text}'";
            da = new OleDbDataAdapter(sql, con);
            LoginInfoDS = new DataSet();
            da.Fill(LoginInfoDS, "LoginInfo");

            if (LoginInfoDS.Tables["LoginInfo"].Rows.Count > 0)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
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
    }
}
