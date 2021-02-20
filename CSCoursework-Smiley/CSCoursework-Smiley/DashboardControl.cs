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
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        DateTime currentWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        int staffID;
        bool isAdmin;
        string username;
        public void SetUsername(string Username)
        {
            // Sets the username in the form to the given username as a welcome message to the user. (This is the first control that is visible.)
            username = Username;
            lblLoggedInAs.Text = $"Logged in as: {username}";
            // Get the staffID corresponding to the given username for user later on in the form, in particular, this is used when grabbing the hours worked information from the database.
            getStaffID(username);
            // Initialize the form once the users username has been passed in.
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

            // Establish the staff data table
            StaffTable = StaffDS.Tables["StaffInfo"];

            // foreach row if the username matches the stored one then set the staffID to that. This always has a value since the user must have already used a login and so has a record in tblUsers.
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
            // Called from the dashboard to update the graph when the timesheet data for the week changes. This keeps the data consistent throughout the program.
            GetGraphData();
        }
        private void GetGraphData()
        {
            if (!isAdmin)
            {
                // If the user isn't the admin, get the timesheet hours for the staff member logged in and display it.
                DataTable TimesheetData = GetTimesheetHoursWorkedTable(staffID);
                double[] graphData = CalculateStandardHours(TimesheetData);
                SetLineChartValues(graphData);
            }
            else
            {
                // If the user is the admin, get the timesheet hours for all staff members and display it.
                DataTable TimesheetData = GetTimesheetHoursWorkedTableAllStaff();
                double[] graphData = CalculateStandardHoursAllStaff(TimesheetData);
                SetLineChartValues(graphData);
            }
        }
        private double[] CalculateStandardHoursAllStaff(DataTable TimesheetTable)
        {
            double[] graphDetails = { 0, 0, 0, 0, 0 }; //[mon, tue, wed, thu, fri]

            // Foreach row add the rows hours worked to the specified day_id of the row corresponding with the hours in the graphDetails double array (the day_ids stored in the database are 1 for monday 2 for tuesday etc so in the array they match up as being day-1)
            for (int index = 0; index < TimesheetTable.Rows.Count; index++)
            {
                DataRow row = TimesheetTable.Rows[index];
                string startTimeString = row.Field<string>("timesheet_start_time");
                string endTimeString = row.Field<string>("timesheet_end_time");

                // -------Exception handling----------
                // If the timesheet data for this row is absence, holiday, or there is no data then continue on to the next row.
                if (startTimeString == "Absent" || startTimeString == "Holiday" || startTimeString == null) { continue; } 
                if (startTimeString.Trim() == "") { continue; }
                if (endTimeString == "Absent" || endTimeString == "Holiday" || endTimeString == null) { continue; } 
                if (endTimeString.Trim() == "") { continue; }

                // ParseExact is used to convert a string time into a DateTime time, this will always match due to the exceptions being dealt with above.
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
            // Initialize database variables.
            DataSet TimesheetDS;
            OleDbDataAdapter da;
            DataTable TimesheetTable;
            string sql;

            // Open Database Connection.
            con.Open();

            // Initialize the timesheet dataset with the timesheet data where the rota_week stored is between the day before the start of the week and the day after the start of the week. This is done due to the way dates are stored in access.
            DateTime prevDay = currentWeek.AddDays(-1);
            DateTime nextDay = currentWeek.AddDays(1);
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT day_id, timesheet_start_time, timesheet_end_time FROM tblRota WHERE rota_week >= #{prevDay.ToString("d", USCulture)}# AND rota_week <= #{nextDay.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            TimesheetDS = new DataSet();
            da.Fill(TimesheetDS, "TimesheetInfo");

            // Establish the timesheet data table.
            TimesheetTable = TimesheetDS.Tables["TimesheetInfo"];

            // Close Database Connection.
            con.Close();

            return TimesheetTable;
        }
        private DataTable GetTimesheetHoursWorkedTable(int staffID)
        {
            // Initialize database variables.
            DataSet TimesheetDS;
            OleDbDataAdapter da;
            DataTable TimesheetTable;
            string sql;

            // Open Database Connection.
            con.Open();

            // Initialize the timesheet dataset with the timesheet data where the rota_week stored is between the day before the start of the week and the day after the start of the week. This is done due to the way dates are stored in access.
            DateTime prevDay = currentWeek.AddDays(-1);
            DateTime nextDay = currentWeek.AddDays(1);
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT timesheet_start_time, timesheet_end_time FROM tblRota WHERE rota_week >= #{prevDay.ToString("d", USCulture)}# AND rota_week <= #{nextDay.ToString("d", USCulture)}# AND staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            TimesheetDS = new DataSet();
            da.Fill(TimesheetDS, "TimesheetInfo");

            // Establish the timesheet data table.
            TimesheetTable = TimesheetDS.Tables["TimesheetInfo"];

            // Close Database Connection
            con.Close();

            return TimesheetTable;
        }
        private double[] CalculateStandardHours(DataTable TimesheetTable)
        {
            double[] graphDetails = new double[5];

            // For every row in the timesheet datatable (this has 5 rows, one for each day since it is for a single employee for the week.)
            for (int index = 0; index < TimesheetTable.Rows.Count; index++)
            {
                DataRow row = TimesheetTable.Rows[index];
                string startTimeString = row.Field<string>("timesheet_start_time");
                string endTimeString = row.Field<string>("timesheet_end_time");

                // -------Exception handling----------
                // If the timesheet data for this row is absence, holiday, or there is no data then continue on to the next row. If the linegraph is passed null values it will just display 0 so there is no issue with skipping rows.
                if (startTimeString == "Absent" || startTimeString == "Holiday" || startTimeString == null) { continue; } // Dealt with in CalculateHolidayHours
                if (startTimeString.Trim() == "") { continue; }
                if (endTimeString == "Absent" || endTimeString == "Holiday" || endTimeString == null) { continue; } // Dealt with in CalculateStandardHours
                if (endTimeString.Trim() == "") { continue; }

                // ParseExact is used to convert a string time into a DateTime time, this will always match due to the exceptions being dealt with above.
                DateTime startTime = DateTime.ParseExact($"{startTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{endTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                graphDetails[index] = Math.Round((endTime - startTime).TotalHours, 2);
            }
            return graphDetails;
        }
        public void userIsAdmin(bool IsAdmin)
        {
            /*Configures the functionality of the form based on if the user has admin permissions/is the admin*/
            isAdmin = IsAdmin;

            
            if (isAdmin)
            {
                // If the user is the admin (passed from the dashboard background form), allow the calendar textboxes to be updated and display the calendar save button (named btnSaveDashboard since the calendar is saved in the table called 'tblDashboard')
                rTxtMondayInfo.ReadOnly = false;
                rTxtTuesdayInfo.ReadOnly = false;
                rTxtWednesdayInfo.ReadOnly = false;
                rTxtThursdayInfo.ReadOnly = false;
                rTxtFridayInfo.ReadOnly = false;
                btnSaveDashboard.Visible = true;
            }
            else
            {
                // If the user is not the admin (passed from the dashboard background form), do not allow the calendar textboxes to be updated and do not display the calendar save button (named btnSaveDashboard since the calendar is saved in the table called 'tblDashboard')
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
            // Assign the local connection string value to the already generated one, saving on processing since otherwise the database location would have to be grabbed multiple times.
            con = Con;
            // Initialize form is not called here in this control since the username needs to be passed in before the form can be set up. Therefore the form is initialized there.
        }
        public DashboardControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        private void InitializeForm()
        {
            // Initialize the calendar, graph and notes. This will display the weekly calendar, user hours worked for the week as well as user notes stored.
            GetCalendarData();
            GetGraphData();
            GetNotesData();
        }
        private void GetNotesData()
        {
            // Initialize variables.
            DataSet UserDS;
            OleDbDataAdapter da;
            string sql;

            // Open Database Connection.
            con.Open();

            // Initialize the user dataset with the specified users dashboard_notes, its fine to search using the username since this is also a unique field. This is because multiple users with the same name cannot be added so the autogenerated usernames are always unique.
            sql = $"SELECT dashboard_notes FROM tblUsers WHERE username='{username}'";
            da = new OleDbDataAdapter(sql, con);
            UserDS = new DataSet();
            da.Fill(UserDS, "UserInfo");

            // Close Database Connection.
            con.Close();

            // Establish the user data table
            DataTable UserTable = UserDS.Tables["UserInfo"];

            // Set the usernotes rich textbox text to the users personal notes.
            rTxtNotes.Text = UserTable.Rows[0].Field<string>("dashboard_notes");
        }
        private void SetLineChartValues(double[] LineChartValues)
        {
            // Initialize variables
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri" };
            string lineChartLabel = "Hours Worked";

            // Remove default/prev series.
            if (lineChartHoursWorked.Series.Count() == 1)
            {
                lineChartHoursWorked.Series.Remove(lineChartHoursWorked.Series[0]);
            }
            // Add new values.
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
            // Initialize database variables.
            DataSet CalendarDS;
            OleDbDataAdapter da;
            string sql;

            // Initialize calendar dataset.
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
            // Nothing is done when the form is loaded since we must wait for the username to be passed to begin initializing the form properly.
        }
        private void btnSaveDashboard_Click(object sender, EventArgs e)
        {
            // User a manual sql update command to update the dashboard a try catch is used to catch an exception if the sql string format doesn't compile correctly, e.g. an apostrophe.
            try
            {
                // Update all calendar fields with the new values and let the user know once it has been updated.
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblDashboard] SET [monday_info]='{rTxtMondayInfo.Text}', [tuesday_info]='{rTxtTuesdayInfo.Text}', [wednesday_info]='{rTxtWednesdayInfo.Text}', [thursday_info]='{rTxtThursdayInfo.Text}', [friday_info]='{rTxtFridayInfo.Text}' WHERE [dashboard_id]=1;";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Calendar Updated.");
            }
            catch
            {
                //----------sql error exception handling-----------
                MessageBox.Show("There was an error updating the calendar. Try removing any apostrophes.");
            }
        }

        private void btnSaveNotes_Click(object sender, EventArgs e)
        {
            // User a manual sql update command to update the dashboard a try catch is used to catch an exception if the sql string format doesn't compile correctly, e.g. an apostrophe.
            try
            {
                // Update all calendar fields with the new values and let the user know once it has been updated.
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
                //----------sql error exception handling-----------
                MessageBox.Show("There was an error updating notes. Try removing any apostrophes.");
            }
        }
    }
}
