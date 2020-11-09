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
        public LoginForm()
        {
            InitializeComponent();
            InitializeUsernameTextbox();
            InitializePasswordTextbox();
            OleDbConnection public_con = InitializeDatabaseConnection();
            Sign_in_Submit.Image = Properties.Resources.SigninSubmit;
            MessageBox.Show("GUI Hello");
            Console.WriteLine("CI Hello");
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

        private OleDbConnection InitializeDatabaseConnection()
        {
            //Initialize variables
            string dbProvider;
            string DatabasePath;
            string MyDocumentsFolder;
            string FullDatabasePath;
            string dbSource;
            OleDbConnection con = new OleDbConnection();

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "/GitHub/CS-Coursework/TestDatabase.accdb";
                MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                FullDatabasePath = MyDocumentsFolder + DatabasePath;
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                MessageBox.Show("Connection established");
            }
            catch
            {
                MessageBox.Show("Error establishing database connection.");
            }
            return con;
        }

        private void Sign_in_Submit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicked");
            //Initliaze variables
            var ds = new DataSet();
            var da = new OleDbDataAdapter();
            string sql;

            //Check Login Details
            sql = $"SELECT * FROM TestLogin WHERE Username='{UsernameTextbox.Text}' AND Password='{PasswordTextbox.Text}'";
            da = new OleDbDataAdapter(sql, public_con);
            da.Fill(ds, "Login");
            Console.WriteLine(da);

        }
    }
}
