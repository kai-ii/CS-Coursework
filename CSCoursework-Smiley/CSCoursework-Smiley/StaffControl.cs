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

        int primaryKeySelected;

        public StaffControl()
        {
            InitializeComponent();
            rBtnDetails.Checked = true;
            InitializeSearchTextbox();
            InitializeDatabaseConnection();
            InitializeStaffMembers();
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
            string FullDatabasePath;
            string dbSource;

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "/TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory; 
                FullDatabasePath = CurrentProjectPath + DatabasePath;
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
            }
            catch
            {
                MessageBox.Show("Error establishing database connection LoginForm.");
            }
        }
        private void InitializeStaffMembers()
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
                lstBoxEmployees.Items.Add($"{staff_firstname}. {staff_surname[0]}");
            }

            lstBoxEmployees.SelectedIndex = 0;
            UpdateRow(1);
        }

        private void UpdateRow(int primaryKey)
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

            DataRow row = StaffInfoDS.Tables["StaffInfo"].Rows.Find(primaryKey);
            staffControlDetails1.Staff_details = row;
        }

        private void lstBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstBoxEmployees.SelectedIndex + 1;

            if (primaryKeySelected != index)
            {
                primaryKeySelected = index;
                UpdateRow(primaryKeySelected);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //searching
        }

        private void rBtnGraphs_CheckedChanged(object sender, EventArgs e)
        {
            staffControlGraphs1.BringToFront();
        }

        private void rBtnNotes_CheckedChanged(object sender, EventArgs e)
        {
            staffControlNotes1.BringToFront();
            staffControlNotes1.generalNotes = GetStaffGeneralNotes(primaryKeySelected);
        }

        private void rBtnDetails_CheckedChanged(object sender, EventArgs e)
        {
            staffControlDetails1.BringToFront();
        }

        private string GetStaffGeneralNotes(int primary_key)
        {
            con.Open();
            //Initialize variables
            DataSet NoteInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            NoteInfoDS = new DataSet();
            da.Fill(NoteInfoDS, "StaffInfo");

            DataTable StaffInfoTable = NoteInfoDS.Tables["StaffInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = StaffInfoTable.Columns["staff_id"];
            StaffInfoTable.PrimaryKey = keyColumns;

            DataRow row = NoteInfoDS.Tables["StaffInfo"].Rows.Find(primaryKey);
            staffControlDetails1.Staff_details = row;
        }
    }
}
