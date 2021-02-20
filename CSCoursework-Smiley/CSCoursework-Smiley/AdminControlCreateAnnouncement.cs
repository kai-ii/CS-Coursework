using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CSCoursework_Smiley
{
    public partial class AdminControlCreateAnnouncement : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        public AdminControlCreateAnnouncement()
        {
            InitializeComponent();
        }

        public void SetCon(OleDbConnection Con)
        {
            con = Con;
            InitializeForm();
        }
        private void InitializeForm()
        {
            // Initialize Form
            InitializeAnnouncement();
        }

        private void AdminControlCreateAnnouncement_Load(object sender, EventArgs e)
        {
            //InitializeDatabaseConnection();
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
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
                con.Close();
            }
            catch
            {
                MessageBox.Show($"Error establishing database connection AdminControlCreateAnnouncement. FullDatabasePath = {FullDatabasePath}");
            }
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

            txtAnnouncementTitle.Text = AnnouncementTable.Rows[0].Field<string>("announcement_title");
            rTxtAnnouncementDetails.Text = AnnouncementTable.Rows[0].Field<string>("announcement_details");
        }

        private void btnSubmitAnnouncement_Click(object sender, EventArgs e)
        {
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblAnnouncement] SET [announcement_title]='{txtAnnouncementTitle.Text}', [announcement_details]='{rTxtAnnouncementDetails.Text}' WHERE [announcement_id]=1;"; // In the future a dedicated annoucement ID allows for multiple announcements simultaneously, perhaps being able to be scrolled through by a user on the login form.
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Announcement Successfully Submitted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create announcement. Exception: {ex.ToString()}");
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
