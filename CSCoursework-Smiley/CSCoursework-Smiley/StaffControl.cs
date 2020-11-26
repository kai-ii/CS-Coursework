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
    public partial class StaffControl : UserControl
    {
        // Variables
        OleDbConnection con = new OleDbConnection();
        List<string> staffButtonOrderList = new List<string>();
        List<Button> buttonList = new List<Button>();

        public StaffControl()
        {
            //Add buttons to buttonList
            buttonList.Add(btnEmployee1);
            buttonList.Add(btnEmployee2);
            foreach (Button button in buttonList)
            {
                Console.WriteLine(button);
            }
            //Initalize things
            InitializeComponent();
            InitializeSearchTextbox();
            InitializeDatabaseConnection();
            GetStaffMembers();
            
        }

        private void StaffControl_Load(object sender, EventArgs e)
        {

        }
        void InitializeSearchTextbox()
        {
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.Text = "search";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "search";
                txtSearch.ForeColor = SystemColors.GrayText;
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
        private void GetStaffMembers()
        {
            //Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            for (int employee = 0; employee<StaffInfoDS.Tables["StaffInfo"].Rows.Count; employee++)
            {
                string staff_firstname = StaffInfoDS.Tables["StaffInfo"].Rows[employee].Field<string>("staff_firstname");
                string staff_surname = StaffInfoDS.Tables["StaffInfo"].Rows[employee].Field<string>("staff_surname");
                staffButtonOrderList.Add($"{staff_firstname},{staff_surname}");
            }

            InitalizeButtonNames();
        }

        private void InitalizeButtonNames()
        {
            //Fix auto button names


            //string staff_firstname;
            //string staff_surname;
            //for (int employee = 0; employee < buttonList.Count; employee += 1)
            //{
            //    staff_firstname = staffButtonOrderList[employee].Split(',')[0];
            //    staff_surname = staffButtonOrderList[employee].Split(',')[1];

            //    buttonList[employee].Text = $"{staff_firstname}. {staff_surname[0]}";
            //    MessageBox.Show($"{staff_firstname}. {staff_surname[0]}");
            //    MessageBox.Show(buttonList[employee].Text);
            //}

            string staff_firstname;
            string staff_surname;
            for (int employee = 0; employee < staffButtonOrderList.Count; employee += 1)
            {
                staff_firstname = staffButtonOrderList[employee].Split(',')[0];
                staff_surname = staffButtonOrderList[employee].Split(',')[1];
                btnEmployee1.Text = $"{staff_firstname}. {staff_surname[0]}";
            }
        }

        private void UpdateButton(ref Button button, string message)
        {
            button.Text = message;
        }

        private void btnEmployee1_Click(object sender, EventArgs e)
        {
            //Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = StaffInfoTable.Columns["staff_id"];
            StaffInfoTable.PrimaryKey = keyColumns;

            DataRow row = StaffInfoDS.Tables["StaffInfo"].Rows.Find(1);
            staffControlDetails1.staff_details = row;
        }
    }
}
