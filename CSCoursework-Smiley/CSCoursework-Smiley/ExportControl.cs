﻿using System;
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
    public partial class ExportControl : UserControl
    {
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        DateTime currentTaxMonth;
        public ExportControl()
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
            // Initialize the current month and then set the current month label.
            SetCurrentMonth();
            UpdateCurrentMonthLabel();
            // Initialize default values and fill the datagrid once default values are in place (in this case there is a neccesity for either the salaried or flexible buttons to be checked so this is set by default before the initial datagrid fill function is called.)
            rBtnSalaried.Checked = true;
            FillDatagrid();
        }
        private void ExportControl_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database.
        }
        private void FillDatagrid()
        {
            // Initialize a data grid data variable, fill that variable by settings it to the GetExportData function call (which returns the export data for the current month) and finally update the datagrid with these values.
            List<string[]> dataGridData;
            dataGridData = GetExportData();
            UpdateDataGrid(dataGridData);
        }
        private void UpdateDataGrid(List<string[]> dataGridData)
        {
            // Update the datagrid with the values from the data passed into the function, generated in the GetExportData function.
            exportDataGrid.Rows.Clear();
            for (int row = 0; row < dataGridData.Count; row++)
            {
                string[] rowArray = dataGridData[row];
                exportDataGrid.Rows.Add(rowArray[0], rowArray[1], rowArray[2], rowArray[3], rowArray[4], rowArray[5], rowArray[6], rowArray[7], rowArray[8], rowArray[9], rowArray[10], rowArray[11]);
            }
        }
        private List<string[]> GetExportData()
        {
            // Initialize database variables.
            DataSet StaffInfoDS;
            DataSet ExportInfoDS;
            DataSet JobPositionDS;
            DataSet PayslipDS;
            DataTable StaffInfoTable;
            DataTable ExportInfoTable;
            DataTable JobPositionTable;
            DataTable PayslipTable;
            OleDbDataAdapter da;
            string sql;
            // Initialize local function variables.
            string contractType;
            List<string[]> dataGridData = new List<string[]>();

            // Open Database Connection.
            con.Open();

            // Presence check validation for the radio button selection.
            if (rBtnSalaried.Checked) { contractType = "Salaried"; }
            else if (rBtnFlexible.Checked) { contractType = "Flexible"; }
            else { MessageBox.Show("neither salaried nor flexible checked."); return dataGridData; }

            // Initialize staff dataset.
            sql = $"SELECT staff_id, jobposition_id, staff_firstname, staff_surname, staff_NI_number, staff_works_number, staff_NI_letter, staff_tax_code, staff_salaried_hours FROM tblStaff WHERE staff_contract_type='{contractType}'";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            // Initialize export dataset.
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT export_id, pay_date FROM tblExport WHERE tax_month_start_date=#{currentTaxMonth.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");

            // Initialize export datatable and staff datatable.
            ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];
            StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            foreach (DataRow row in StaffInfoTable.Rows)
            {
                /*For each row in the staff datatable, get the corresponding job info and hours worked info, then append this to the list declared at the start of the function.*/
                sql = $"SELECT jobposition_wage FROM tblJobPositions WHERE jobposition_id={row.Field<int>("jobposition_id")}";
                da = new OleDbDataAdapter(sql, con);
                JobPositionDS = new DataSet();
                da.Fill(JobPositionDS, "JobPositionInfo");
                JobPositionTable = JobPositionDS.Tables["JobPositionInfo"];

                // Different sql depending on contract type.
                if (contractType == "Salaried") { sql = $"SELECT standard_hours_worked, holiday_hours_taken FROM tblPayslip WHERE export_id={ExportInfoTable.Rows[0].Field<int>("export_id")} AND staff_id={row.Field<int>("staff_id")}"; }
                else { sql = $"SELECT standard_hours_worked, holiday_hours_worked FROM tblPayslip WHERE export_id={ExportInfoTable.Rows[0].Field<int>("export_id")} AND staff_id={row.Field<int>("staff_id")}"; }
                // Initialize payslip dataset.
                da = new OleDbDataAdapter(sql, con);
                PayslipDS = new DataSet();
                da.Fill(PayslipDS, "PayslipInfo");
                // Initialize payslip datatable.
                PayslipTable = PayslipDS.Tables["PayslipInfo"];

                // If this staff member doesn't have a row for the current months exportID then generate one.
                if (PayslipTable.Rows.Count == 0)
                {
                    GeneratePayslipData(row.Field<int>("staff_id"), float.Parse(JobPositionTable.Rows[0].Field<string>("jobposition_wage").Remove(0, 1)), contractType, row.Field<int>("staff_salaried_hours"));
                    if (contractType == "Salaried") { sql = $"SELECT standard_hours_worked, holiday_hours_taken FROM tblPayslip WHERE export_id={ExportInfoTable.Rows[0].Field<int>("export_id")} AND staff_id={row.Field<int>("staff_id")}"; }
                    else { sql = $"SELECT standard_hours_worked, holiday_hours_worked FROM tblPayslip WHERE export_id={ExportInfoTable.Rows[0].Field<int>("export_id")} AND staff_id={row.Field<int>("staff_id")}"; }
                    da = new OleDbDataAdapter(sql, con);
                    PayslipDS = new DataSet();
                    da.Fill(PayslipDS, "PayslipInfo");
                    PayslipTable = PayslipDS.Tables["PayslipInfo"];
                }

                // Close Database Connection.
                con.Close();

                string staffForename = row.Field<string>("staff_firstname");
                string staffSurname = row.Field<string>("staff_surname");
                string payDate = ExportInfoTable.Rows[0].Field<DateTime>("pay_date").ToString("d");
                string NINumber = row.Field<string>("staff_NI_number");
                string NILetter = row.Field<string>("staff_NI_letter");
                string taxCode = row.Field<string>("staff_tax_code");
                string worksNumber = row.Field<string>("staff_works_number");
                float jobpositionWage = float.Parse(JobPositionTable.Rows[0].Field<string>("jobposition_wage").Remove(0, 1));
                float standardWage = jobpositionWage;
                double standardHours;
                if (PayslipTable.Rows.Count > 0) { standardHours = PayslipTable.Rows[0].Field<double>("standard_hours_worked"); }
                else { standardHours = 0; }
                float holidayWage = jobpositionWage;
                double holidayHours = -1; // If it is not assigned here then compiler doesn't build, -1 is a rogue value to ensure it is gettings assigned while testing.
                if (PayslipTable.Rows.Count > 0)
                {
                    if (contractType == "Salaried") { holidayHours = PayslipTable.Rows[0].Field<double>("holiday_hours_taken"); }
                    else { holidayHours = PayslipTable.Rows[0].Field<double>("holiday_hours_worked"); }
                }
                else { holidayHours = 0; }

                string[] dataGridRow = new string[12]; //[forename, surname, pay date, NI number, NI letter, tax code, works number, std rate, std hours, holiday rate, holiday hours].
                dataGridRow[0] = staffForename;
                dataGridRow[1] = staffSurname;
                dataGridRow[2] = payDate;
                dataGridRow[3] = NINumber;
                dataGridRow[4] = NILetter;
                dataGridRow[5] = taxCode;
                dataGridRow[6] = worksNumber;
                dataGridRow[7] = standardWage.ToString();
                dataGridRow[8] = Math.Round(standardHours, 2).ToString();
                dataGridRow[9] = holidayWage.ToString();
                dataGridRow[10] = Math.Round(holidayHours, 2).ToString();
                dataGridRow[11] = Math.Round((standardHours + holidayHours) * jobpositionWage, 2).ToString();
                dataGridData.Add(dataGridRow);
            }
            return dataGridData;
        }

        private void GeneratePayslipData(int staffID, float jobpositionWage, string contractType, int salariedHours)
        {
            /*Generates payslip data if the staff member doesn't have a row for the current months exportID*/
            Tuple<DataTable, int> TimesheetExportTuple = GetTimesheetHoursWorkedTable(staffID);
            DataTable TimesheetTable = TimesheetExportTuple.Item1;
            int exportID = TimesheetExportTuple.Item2;
            double standardHoursWorked = -1;
            double holidayHoursWorked = -1;
            double totalHolidayToAdd = 0;

            // Different calculations based on contract type.
            if (contractType == "Flexible")
            {
                standardHoursWorked = CalculateStandardHours(TimesheetTable);
                holidayHoursWorked = standardHoursWorked * 0.1207;
            }
            else if (contractType == "Salaried")
            {
                standardHoursWorked = CalculateStandardHours(TimesheetTable);
                holidayHoursWorked = CalculateHolidayHours(TimesheetTable);
                //MessageBox.Show($"holidayHoursWorked = {holidayHoursWorked}");
                totalHolidayToAdd = holidayHoursWorked;
                if (standardHoursWorked + holidayHoursWorked < salariedHours)
                {
                    totalHolidayToAdd += (salariedHours - standardHoursWorked - holidayHoursWorked);
                    //MessageBox.Show($"totalHolidayToAdd = {totalHolidayToAdd}");
                }
            }

            if (standardHoursWorked == 0)
            {
                Console.WriteLine();
                //MessageBox.Show("Employee has worked 0 standardHours. Either there has been an error or this employee has no timesheet data for this month.");
                return;
            }

            //MessageBox.Show($"standardHoursWorked = {Math.Round(standardHoursWorked, 2).ToString()}, holidayHoursWorked = {Math.Round(holidayHoursWorked, 2).ToString()}");
            WritePayslipInfoToDatabase(standardHoursWorked, holidayHoursWorked, totalHolidayToAdd, staffID, exportID);
        }
        private void WritePayslipInfoToDatabase(double standardHoursWorked, double holidayHoursWorked, double totalHolidayToAdd, int staffID, int exportID)
        {
            // Initialize database variables.
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            DataTable PayslipInfoTable;
            string sql;
            int payslipID;

            // Open database connection.
            con.Open();

            // Initialize payslip dataset.
            sql = $"SELECT * FROM tblPayslip WHERE staff_id={staffID} AND export_id={exportID}";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");

            // Initialize payslip datatable.
            PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            if (PayslipInfoTable.Rows.Count > 0)
            {
                // If there is already a row for this staffID, exportID pair then update it.
                var updateCommand = new OleDbCommand();
                sql = $"UPDATE [tblPayslip] SET [standard_hours_worked]={standardHoursWorked}, [holiday_hours_worked]={holidayHoursWorked}, [holiday_hours_taken]={totalHolidayToAdd} WHERE [staff_id]={staffID} AND [export_id]={exportID};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                updateCommand.ExecuteNonQuery();
                con.Close();
                return;
            }
            // If there isn't already a row for this staffID, exportID pair -> create one.

            sql = $"SELECT * FROM tblPayslip";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");
            PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            // Close Database Connection.
            con.Close();

            // If the payslip table contains no rows then initialize it with the first one having an ID of 1.
            if (PayslipInfoTable.Rows.Count == 0) { payslipID = 1; }
            else { payslipID = PayslipInfoTable.Rows[PayslipInfoTable.Rows.Count - 1].Field<int>("payslip_id") + 1; }

            DataRow newRow = PayslipInfoTable.NewRow();
            newRow["payslip_id"] = payslipID;
            newRow["export_id"] = exportID;
            newRow["staff_id"] = staffID;
            newRow["standard_hours_worked"] = standardHoursWorked;
            newRow["holiday_hours_worked"] = holidayHoursWorked;
            newRow["holiday_hours_taken"] = totalHolidayToAdd;
            PayslipInfoTable.Rows.Add(newRow);

            // Generate command builder for data adapter 'da' and update the database.
            _ = new OleDbCommandBuilder(da);
            da.Update(PayslipInfoDS, "PayslipInfo");
        }
        private double CalculateHolidayHours(DataTable TimesheetTable)
        {
            // Initialize variables.
            double holidayHoursWorked = 0;
            TimeSpan TotalHolidayHoursWorked = TimeSpan.Zero;

            // For each row in the timesheet table given, skip the row if it is not a holiday row, otherwise calculate the number of hours the worker was meant to take based on the rota information set.
            foreach (DataRow row in TimesheetTable.Rows)
            {
                string timesheetStartTimeString = row.Field<string>("timesheet_start_time");
                string timesheetEndTimeString = row.Field<string>("timesheet_end_time");

                // Skip row if not holiday row.
                if (timesheetStartTimeString != "Holiday" || timesheetEndTimeString != "Holiday")
                {
                    continue;
                }

                string rotaStartTimeString = row.Field<string>("rota_start_time");
                string rotaEndTimeString = row.Field<string>("rota_end_time");

                // Calculate expected hours to be worked.
                DateTime startTime = DateTime.ParseExact($"{rotaStartTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{rotaEndTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                TotalHolidayHoursWorked += (endTime - startTime);
            }
            // Return total holiday hours rota'd.
            holidayHoursWorked = TotalHolidayHoursWorked.TotalHours;
            return holidayHoursWorked;
        }
        private double CalculateStandardHours(DataTable TimesheetTable)
        {
            // Initialize variables.
            double standardHoursWorked = 0;
            TimeSpan TotalStandardHoursWorked = TimeSpan.Zero;

            // Foreach row in the timesheet table given, skip it if its an absence or holiday, then calculate the hours worked during the day and return it
            foreach (DataRow row in TimesheetTable.Rows)
            {
                string startTimeString = row.Field<string>("timesheet_start_time");
                string endTimeString = row.Field<string>("timesheet_end_time");

                // Skip the row if it is an absence or a holiday.
                if (startTimeString == "Absent" || startTimeString == "Holiday" || startTimeString == null) { continue; } // Dealt with in CalculateHolidayHours
                if (startTimeString.Trim() == "") { continue; }
                if (endTimeString == "Absent" || endTimeString == "Holiday" || endTimeString == null) { continue; } // Dealt with in CalculateStandardHours
                if (endTimeString.Trim() == "") { continue; }

                // Calculate hours worked.
                DateTime startTime = DateTime.ParseExact($"{startTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{endTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                TotalStandardHoursWorked += (endTime - startTime);
            }
            // Return total standard hours worked.
            standardHoursWorked = TotalStandardHoursWorked.TotalHours;
            return standardHoursWorked;
        }
        private Tuple<DataTable, int> GetTimesheetHoursWorkedTable(int staffID)
        {
            // Initialize database variables.
            DataSet ExportInfoDS;
            DataSet TimesheetDS;
            OleDbDataAdapter da;
            DataTable ExportInfoTable;
            DataTable TimesheetTable;
            string sql;

            // Database connection doesn't need to be opened since this is only called when the connection is already open.

            // Initialize export dataset, USCulture is required since this is how access stores dates.
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT export_id FROM tblExport WHERE tax_month_start_date=#{currentTaxMonth.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");
            // Initialize export info table and the associated exportID.
            ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];
            int exportID = ExportInfoTable.Rows[0].Field<int>("export_id");

            // Initialize timesheet dataset
            sql = $"SELECT rota_start_time, rota_end_time, timesheet_start_time, timesheet_end_time FROM tblRota WHERE export_id={exportID} AND staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            TimesheetDS = new DataSet();
            da.Fill(TimesheetDS, "TimesheetInfo");
            // Initialize timesheet table.
            TimesheetTable = TimesheetDS.Tables["TimesheetInfo"];

            //MessageBox.Show(TimesheetTable.Rows.Count.ToString());

            // Close Database Connection
            con.Close();

            return new Tuple<DataTable, int>(TimesheetTable, exportID);
        }
        private void SetCurrentMonth()
        {
            // Set the current tax month to the the sixth day of the current month of the current year, this is how a tax month is defined.
            string dd = "06";
            string MM = DateTime.Now.Month.ToString();
            string yyyy = DateTime.Now.Year.ToString();

            if (MM.Length == 1) { MM = $"0{MM}"; }

            currentTaxMonth = DateTime.ParseExact($"{dd}/{MM}/{yyyy}", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        private void UpdateCurrentMonthLabel()
        {
            // Set the current tax month label to the current tax month variable being stored. ':D' is equivalent to '.ToString("D")'
            lblCurrentTaxMonth.Text = $"Tax Month - {currentTaxMonth:D}";
        }

        private void rBtnSalaried_CheckedChanged(object sender, EventArgs e)
        {
            // If the salaried option has been switched to then fill the datagrid again, this time the data retrieved will have the salaried contract type search filter.
            if (rBtnSalaried.Checked) { FillDatagrid(); }
        }

        private void rBtnFlexible_CheckedChanged(object sender, EventArgs e)
        {
            // If the flexible option has been switched to then fill the datagrid again, this time the data retrieved will have the flexible contract type search filter.
            if (rBtnFlexible.Checked) { FillDatagrid(); }
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            // Update the current tax month to the current value plus a month, update the current month label and fill the datagrid with the new months data.
            currentTaxMonth = currentTaxMonth.AddMonths(1);
            UpdateCurrentMonthLabel();
            FillDatagrid();
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            // Update the current tax month to the current value plus a month, update the current month label and fill the datagrid with the new months data.
            currentTaxMonth = currentTaxMonth.AddMonths(-1);
            UpdateCurrentMonthLabel();
            FillDatagrid();
        }

        private void btnSaveJobPositions_Click(object sender, EventArgs e)
        {
            try
            {
                // Try saving the data in the datagrid view to a csv file, denoted .csv when saved. If this fails then send the user a message.
                string[] lines = new string[exportDataGrid.Rows.Count+1];
                lines[0] = "Forename 1,Surname,N.I. number,NI Table Letter,Tax Code,Works number,Total Pay"; // This doesn't match up fully with my export table but this is due to limitations of what can be imported into moneysoft
                for (int row = 0; row < exportDataGrid.Rows.Count; row++)
                {
                    lines[row + 1] = $"{exportDataGrid.Rows[row].Cells[0].Value},{exportDataGrid.Rows[row].Cells[1].Value},{exportDataGrid.Rows[row].Cells[3].Value},{exportDataGrid.Rows[row].Cells[4].Value},{exportDataGrid.Rows[row].Cells[5].Value},{exportDataGrid.Rows[row].Cells[6].Value},{exportDataGrid.Rows[row].Cells[11].Value}";
                }
                string CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                System.IO.File.WriteAllLines($@"{CurrentProjectPath}\{currentTaxMonth:MMMM}{currentTaxMonth.Year}.csv", lines);
                MessageBox.Show($"File saved. Location: " +
                    $@"{CurrentProjectPath}{currentTaxMonth:MMMM}{currentTaxMonth.Year}.csv");
            }
            catch (Exception ex)
            {
                // ----------exception handling----------
                // Send an exception message.
                MessageBox.Show($"Failed to save file. Exception: {ex}");
            }
        }
    }
}
