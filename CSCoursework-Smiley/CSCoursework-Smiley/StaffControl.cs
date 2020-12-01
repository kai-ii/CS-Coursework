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
using LiveCharts;
using LiveCharts.Wpf;

namespace CSCoursework_Smiley
{
    public partial class StaffControl : UserControl
    {
        // Variables
        OleDbConnection con = new OleDbConnection();
        int primaryKeySelected;

        public StaffControl()
        {
            InitializeComponent();
            InitializeSearchTextbox();
            InitializeDatabaseConnection();
            InitializeStaffMembers();
            rBtnDetails.Checked = true;
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
                con.Close();
            }
            catch
            {
                MessageBox.Show("Error establishing database connection LoginForm.");
            }
        }
        private void InitializeStaffMembers()
        {
            //Open database connection
            con.Open();

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

            //Close database connection
            con.Close();

            //Initialize Details View
            lstBoxEmployees.SelectedIndex = 0;
            UpdateRowStaffDetails(1);
        }

        private void UpdateRowStaffDetails(int primaryKey)
        {
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            //Close database connection
            con.Close();

            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = StaffInfoTable.Columns["staff_id"];
            StaffInfoTable.PrimaryKey = keyColumns;

            DataRow row = StaffInfoDS.Tables["StaffInfo"].Rows.Find(primaryKey);
            staffControlDetails1.Staff_details = row;
        }

        private void UpdateNoteDetails(int primaryKey)
        {
            UpdateGeneralNotesDetails(primaryKey);
            UpdateAbsenceTupleList(primaryKey);
            staffControlNotes1.RefreshMonthCalendar();
        }

        private void UpdateAbsenceTupleList(int primaryKey)
        {
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet AbsenceInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = $"SELECT tblAbsence.absence_date, tblAbsence.absence_notes FROM tblAbsence INNER JOIN tblRota ON tblAbsence.rota_id=tblRota.rota_id WHERE tblRota.staff_id={primaryKey}";
            da = new OleDbDataAdapter(sql, con);
            AbsenceInfoDS = new DataSet();
            da.Fill(AbsenceInfoDS, "AbsenceInfo");

            //Close database connection
            con.Close();

            DataTable AbsenceInfoTable = AbsenceInfoDS.Tables["AbsenceInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = AbsenceInfoTable.Columns["rota_id"];
            AbsenceInfoTable.PrimaryKey = keyColumns;

            List<Tuple<DateTime, string>> absenceTupleList = new List<Tuple<DateTime, string>>();

            for (int row = 0; row < AbsenceInfoTable.Rows.Count; row++)
            {
                DateTime rowDate = AbsenceInfoTable.Rows[row].Field<DateTime>("absence_date");
                string rowString = AbsenceInfoTable.Rows[row].Field<string>("absence_notes");
                Tuple<DateTime, string> rowTuple = new Tuple<DateTime, string>(rowDate, rowString);
                absenceTupleList.Add(rowTuple);
            }

            staffControlNotes1.AbsenceTupleList = absenceTupleList;
        }

        private void UpdateGeneralNotesDetails(int primaryKey)
        {
            staffControlNotes1.GeneralNotes = GetStaffGeneralNotes(primaryKey);
        }

        private void UpdateGraphDetails(int primaryKey)
        {
            UpdatePieChartDetails(primaryKey);
            UpdateLineChartDetails(primaryKey);
        }

        private void UpdateLineChartDetails(int primaryKey)
        {
            Random rnd = new Random();

            int[] hoursWorkedByMonth = new int[12];
            for (int month = 0; month < 12; month++)
            {
                hoursWorkedByMonth[month] = rnd.Next(140, 180);
            }

            staffControlGraphs1.LineChartValues = hoursWorkedByMonth;
        }

        private void UpdatePieChartDetails(int primaryKey)
        {
            Random rnd = new Random();
            int hoursWorked = rnd.Next(730, 810);
            int paidTimeOff = rnd.Next(35, 70);

            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection pieChartValues = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Hours Worked",
                    Values = new ChartValues<int> {hoursWorked},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Paid Time Off",
                    Values = new ChartValues<int> {paidTimeOff},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            staffControlGraphs1.PieChartData = pieChartValues;
        }

        private void lstBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstBoxEmployees.SelectedIndex + 1;

            if (primaryKeySelected != index)
            {
                primaryKeySelected = index;
                if (rBtnDetails.Checked)
                {
                    UpdateRowStaffDetails(primaryKeySelected);
                }
                else if (rBtnGraphs.Checked)
                {
                    UpdateGraphDetails(primaryKeySelected);
                }
                else if (rBtnNotes.Checked)
                {
                    UpdateNoteDetails(primaryKeySelected);
                }                                
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //searching
        }

        private void rBtnGraphs_CheckedChanged(object sender, EventArgs e)
        {
            staffControlGraphs1.BringToFront();
            UpdateGraphDetails(primaryKeySelected);
        }

        private void rBtnNotes_CheckedChanged(object sender, EventArgs e)
        {
            staffControlNotes1.BringToFront();
            staffControlNotes1.parentForm = this;
            UpdateNoteDetails(primaryKeySelected);
        }

        private void rBtnDetails_CheckedChanged(object sender, EventArgs e)
        {
            staffControlDetails1.BringToFront();
            UpdateRowStaffDetails(primaryKeySelected);
        }

        private string GetStaffGeneralNotes(int primaryKey)
        {
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet NoteInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblNotes where staff_id={primaryKey}";
            da = new OleDbDataAdapter(sql, con);
            NoteInfoDS = new DataSet();
            da.Fill(NoteInfoDS, "NoteInfo");

            //Close database connection
            con.Close();

            DataTable NoteInfoTable = NoteInfoDS.Tables["NoteInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = NoteInfoTable.Columns["staff_id"];
            NoteInfoTable.PrimaryKey = keyColumns;

            DataRow row = NoteInfoTable.Rows.Find(primaryKey);
            return Convert.ToString(row.Field<string>("note_contents"));
        }

        private void staffControlNotes1_Load(object sender, EventArgs e)
        {

        }

        public void UpdateGeneralNotes(string updateNotes)
        {
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet NoteInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblNotes where staff_id={primaryKeySelected}";
            da = new OleDbDataAdapter(sql, con);
            NoteInfoDS = new DataSet();
            da.Fill(NoteInfoDS, "NoteInfo");

            //Close database connection
            con.Close();

            DataTable NoteInfoTable = NoteInfoDS.Tables["NoteInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = NoteInfoTable.Columns["staff_id"];
            NoteInfoTable.PrimaryKey = keyColumns;

            //This line of code is needed for the update builder to be autogenerated so the da.Update line works
            _ = new OleDbCommandBuilder(da);

            DataRow row = NoteInfoTable.Rows.Find(primaryKeySelected);
            row["note_contents"] = updateNotes;
            da.Update(NoteInfoDS, "NoteInfo");
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
