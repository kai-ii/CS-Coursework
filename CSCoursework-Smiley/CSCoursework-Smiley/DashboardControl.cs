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
using System.Globalization;

namespace CSCoursework_Smiley.Properties
{
    public partial class DashboardControl : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        DateTime currentWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        int staffID;
        bool isAdmin;
        string username;
        public void SetUsername(string Username)
        {
            username = Username;
            lblLoggedInAs.Text = $"Logged in as: {username}";
            getStaffID(username);
            InitializeForm();
        }
        private void getStaffID(string username)
        {
            // Initialize variables
            DataSet StaffDS;
            OleDbDataAdapter da;
            DataTable StaffTable;
            string sql;

            // Open Database Connection
            con.Open();

            sql = $"SELECT staff_id, staff_firstname, staff_surname FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffDS = new DataSet();
            da.Fill(StaffDS, "StaffInfo");
            StaffTable = StaffDS.Tables["StaffInfo"];

            foreach (DataRow row in StaffTable.Rows)
            {
                string nameToCheck = $"{row.Field<string>("staff_firstname").ToLower()[0]}{row.Field<string>("staff_surname").ToLower()}";
                if (username == nameToCheck)
                {
                    staffID = row.Field<int>("staff_id");
                }
            }

            // Close Database Connection
            con.Close();
        }
        public void UpdateGraph()
        {
            GetGraphData();
        }
        private void GetGraphData()
        {
            if (!isAdmin)
            {
                DataTable TimesheetData = GetTimesheetHoursWorkedTable(staffID);
                double[] graphData = CalculateStandardHours(TimesheetData);
                SetLineChartValues(graphData);
            }
            else
            {
                DataTable TimesheetData = GetTimesheetHoursWorkedTableAllStaff();
                double[] graphData = CalculateStandardHoursAllStaff(TimesheetData);
                SetLineChartValues(graphData);
            }
        }
        private double[] CalculateStandardHoursAllStaff(DataTable TimesheetTable)
        {
            double[] graphDetails = { 0, 0, 0, 0, 0 }; //mon, tue, wed, thu, fri
            for (int index = 0; index < TimesheetTable.Rows.Count; index++)
            {
                DataRow row = TimesheetTable.Rows[index];
                string startTimeString = row.Field<string>("timesheet_start_time");
                string endTimeString = row.Field<string>("timesheet_end_time");

                if (startTimeString == "Absent" || startTimeString == "Holiday" || startTimeString == null) { continue; } // Dealt with in CalculateHolidayHours
                if (startTimeString.Trim() == "") { continue; }
                if (endTimeString == "Absent" || endTimeString == "Holiday" || endTimeString == null) { continue; } // Dealt with in CalculateStandardHours
                if (endTimeString.Trim() == "") { continue; }

                DateTime startTime = DateTime.ParseExact($"{startTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{endTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                double currentIndexValue = graphDetails[row.Field<int>("day_id") - 1];
                double newValue = Math.Round(currentIndexValue + (endTime - startTime).TotalHours, 2);
                graphDetails[row.Field<int>("day_id") - 1] = newValue;
            }
            return graphDetails;
        }
        private DataTable GetTimesheetHoursWorkedTableAllStaff()
        {
            // Initialize variables
            DataSet TimesheetDS;
            OleDbDataAdapter da;
            DataTable TimesheetTable;
            string sql;

            // Open Database Connection
            con.Open();

            DateTime prevDay = currentWeek.AddDays(-1);
            DateTime nextDay = currentWeek.AddDays(1);
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT day_id, timesheet_start_time, timesheet_end_time FROM tblRota WHERE rota_week >= #{prevDay.ToString("d", USCulture)}# AND rota_week <= #{nextDay.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            TimesheetDS = new DataSet();
            da.Fill(TimesheetDS, "TimesheetInfo");
            TimesheetTable = TimesheetDS.Tables["TimesheetInfo"];

            // Close Database Connection
            con.Close();

            return TimesheetTable;
        }
        private DataTable GetTimesheetHoursWorkedTable(int staffID)
        {
            // Initialize variables
            DataSet TimesheetDS;
            OleDbDataAdapter da;
            DataTable TimesheetTable;
            string sql;

            // Open Database Connection
            con.Open();

            DateTime prevDay = currentWeek.AddDays(-1);
            DateTime nextDay = currentWeek.AddDays(1);
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT timesheet_start_time, timesheet_end_time FROM tblRota WHERE rota_week >= #{prevDay.ToString("d", USCulture)}# AND rota_week <= #{nextDay.ToString("d", USCulture)}# AND staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            TimesheetDS = new DataSet();
            da.Fill(TimesheetDS, "TimesheetInfo");
            TimesheetTable = TimesheetDS.Tables["TimesheetInfo"];

            // Close Database Connection
            con.Close();

            return TimesheetTable;
        }
        private double[] CalculateStandardHours(DataTable TimesheetTable)
        {
            double[] graphDetails = new double[5];
            for (int index = 0; index < TimesheetTable.Rows.Count; index++)
            {
                DataRow row = TimesheetTable.Rows[index];
                string startTimeString = row.Field<string>("timesheet_start_time");
                string endTimeString = row.Field<string>("timesheet_end_time");

                if (startTimeString == "Absent" || startTimeString == "Holiday" || startTimeString == null) { continue; } // Dealt with in CalculateHolidayHours
                if (startTimeString.Trim() == "") { continue; }
                if (endTimeString == "Absent" || endTimeString == "Holiday" || endTimeString == null) { continue; } // Dealt with in CalculateStandardHours
                if (endTimeString.Trim() == "") { continue; }

                DateTime startTime = DateTime.ParseExact($"{startTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{endTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                graphDetails[index] = Math.Round((endTime - startTime).TotalHours, 2);
            }
            return graphDetails;
        }
        public void userIsAdmin(bool IsAdmin)
        {
            isAdmin = IsAdmin;
            if (isAdmin)
            {
                rTxtMondayInfo.ReadOnly = false;
                rTxtTuesdayInfo.ReadOnly = false;
                rTxtWednesdayInfo.ReadOnly = false;
                rTxtThursdayInfo.ReadOnly = false;
                rTxtFridayInfo.ReadOnly = false;
                btnSaveDashboard.Visible = true;
            }
            else
            {
                rTxtMondayInfo.ReadOnly = true;
                rTxtTuesdayInfo.ReadOnly = true;
                rTxtWednesdayInfo.ReadOnly = true;
                rTxtThursdayInfo.ReadOnly = true;
                rTxtFridayInfo.ReadOnly = true;
                btnSaveDashboard.Visible = false;
            }
        }
        public void SetCon(OleDbConnection Con)
        {
            con = Con;
            //InitializeForm();
        }
        public DashboardControl()
        {
            InitializeComponent();
        }
        private void InitializeForm()
        {
            GetCalendarData();
            GetGraphData();
            GetNotesData();
        }
        private void GetNotesData()
        {
            // Initialize variables
            DataSet UserDS;
            OleDbDataAdapter da;
            string sql;

            // Open Database Connection
            con.Open();

            sql = $"SELECT dashboard_notes FROM tblUsers WHERE username='{username}'";
            da = new OleDbDataAdapter(sql, con);
            UserDS = new DataSet();
            da.Fill(UserDS, "UserInfo");

            // Close Database Connection
            con.Close();

            DataTable UserTable = UserDS.Tables["UserInfo"];
            rTxtNotes.Text = UserTable.Rows[0].Field<string>("dashboard_notes");
        }
        private void SetLineChartValues(double[] LineChartValues)
        {
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri" };
            string lineChartLabel = "Hours Worked";

            // Remove default/prev series.
            if (lineChartHoursWorked.Series.Count() == 1)
            {
                lineChartHoursWorked.Series.Remove(lineChartHoursWorked.Series[0]);
            }
            // Add new values
            if (days.Length == LineChartValues.Length)
            {
                lineChartHoursWorked.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(lineChartLabel));
                lineChartHoursWorked.Series[lineChartLabel].IsValueShownAsLabel = true;
                lineChartHoursWorked.Series[lineChartLabel].BorderWidth = 3;
                lineChartHoursWorked.Series[lineChartLabel].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                lineChartHoursWorked.Series[lineChartLabel].Points.DataBindXY(days, LineChartValues);
            }
        }
        private void GetCalendarData()
        {
            //Initialize variables
            DataSet CalendarDS;
            OleDbDataAdapter da;
            string sql;

            //Get calendar
            sql = $"SELECT * FROM tblDashboard"; 
            da = new OleDbDataAdapter(sql, con);
            CalendarDS = new DataSet();
            da.Fill(CalendarDS, "CalendarInfo");

            //Close database connection
            con.Close();

            DataTable CalendarTable = CalendarDS.Tables["CalendarInfo"];

            rTxtMondayInfo.Text = CalendarTable.Rows[0].Field<string>("monday_info");
            rTxtTuesdayInfo.Text = CalendarTable.Rows[0].Field<string>("tuesday_info");
            rTxtWednesdayInfo.Text = CalendarTable.Rows[0].Field<string>("wednesday_info");
            rTxtThursdayInfo.Text = CalendarTable.Rows[0].Field<string>("thursday_info");
            rTxtFridayInfo.Text = CalendarTable.Rows[0].Field<string>("friday_info");
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            //InitializeDatabaseConnection();
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
                MessageBox.Show($"Error establishing database connection");
            }
        }

        private void btnSaveDashboard_Click(object sender, EventArgs e)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblDashboard] SET [monday_info]='{rTxtMondayInfo.Text}', [tuesday_info]='{rTxtTuesdayInfo.Text}', [wednesday_info]='{rTxtWednesdayInfo.Text}', [thursday_info]='{rTxtThursdayInfo.Text}', [friday_info]='{rTxtFridayInfo.Text}' WHERE [dashboard_id]=1;";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Calendar Updated.");
        }

        private void btnSaveNotes_Click(object sender, EventArgs e)
        {
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblUsers] SET [dashboard_notes]='{rTxtNotes.Text}' WHERE [username]='{username}';";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Notes Updated.");
            }
            catch
            {
                MessageBox.Show("There was an error updating notes.");
            }
        }
    }
}
