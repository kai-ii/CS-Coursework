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
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        public AdminControlCreateAnnouncement()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        public void SetCon(OleDbConnection Con)
        {
            // Assign the local connection string value to the already generated one, saving on processing since otherwise the database location would have to be grabbed multiple times.
            con = Con;
            // Initialize the form once the connection string has been assigned.
            InitializeForm();
        }
        private void InitializeForm()
        {
            // Initialize the announcement that is already present into the forms textboxes for editing.
            InitializeAnnouncement();
        }

        private void AdminControlCreateAnnouncement_Load(object sender, EventArgs e)
        {
            // Do nothing when the form loads since we are waiting for the connection string to be assigned.
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

            // Initialize announcement dataset and datatable
            sql = $"SELECT announcement_title, announcement_details FROM tblAnnouncement";
            da = new OleDbDataAdapter(sql, con);
            AnnouncementDS = new DataSet();
            da.Fill(AnnouncementDS, "AnnouncementInfo");
            AnnouncementTable = AnnouncementDS.Tables["AnnouncementInfo"];

            // Close the database connection
            con.Close();

            // Set the announcement textboxes to the corresponding values from the database
            txtAnnouncementTitle.Text = AnnouncementTable.Rows[0].Field<string>("announcement_title");
            rTxtAnnouncementDetails.Text = AnnouncementTable.Rows[0].Field<string>("announcement_details");
        }

        private void btnSubmitAnnouncement_Click(object sender, EventArgs e)
        {
            /*Submits the updated announcement to the database*/
            try
            {
                // Generate an update command to manually update the database using the following sql command
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
                // This exception could be an error where the user tried to use a ' in their announcement and it broke the string interpolation.
                MessageBox.Show($"Failed to create announcement. Exception: {ex}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // If the user clicks the back button then hide this form.
            this.Visible = false;
        }
    }
}
