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
    // Payslip tax -> national insurance based on NI number + income tax based on tax code
    public partial class PayslipControl : UserControl
    {
        // Initialize variables
        OleDbConnection con = new OleDbConnection();
        DateTime currentTaxMonth;
        Dictionary<int, string> staffNameDictionary; // StaffID, StaffName
        Dictionary<int, int> staffJobDictionary; // StaffID, JobID
        Dictionary<int, string> staffSalaryTypeDictionary; // StaffID, SalaryType
        Dictionary<int, int> staffContractedHoursDictionary; // StaffID, StaffContractedHours
        Dictionary<int, char> staffNILetterDictionary; // StaffID, NILetter
        Dictionary<int, string> staffTaxCodeDictionary; // StaffID, TaxCode
        Dictionary<int, float> jobValueDictionary; // JobID, JobWage
        public PayslipControl()
        {
            InitializeComponent();
        }
        private void PayslipControl_Load(object sender, EventArgs e)
        {
            // Initialize Database
            InitializeDatabaseConnection();

            // Initialize Form
            SetCurrentMonth();
            UpdateCurrentMonthLabel();
            GetStaffData();
            GetJobWageData();
            InitializeStaffComboBox();
        }
        public void UpdatePayslipInfo() // Called after manage jobs is changed.
        {
            GetJobWageData();
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private void CalculatePayslipInformation(int staffID)
        {
            Tuple<DataTable, int> TimesheetExportTuple = GetTimesheetHoursWorkedTable(staffID);
            DataTable TimesheetTable = TimesheetExportTuple.Item1;
            int exportID = TimesheetExportTuple.Item2;
            double standardHoursWorked = -1;
            double holidayHoursWorked = -1;
            double totalHolidayToAdd = 0;

            if (staffSalaryTypeDictionary[staffID] == "Flexible")
            {
                standardHoursWorked = CalculateStandardHours(TimesheetTable);
                holidayHoursWorked = standardHoursWorked * 0.1207;
            }
            else if (staffSalaryTypeDictionary[staffID] == "Salaried")
            {
                standardHoursWorked = CalculateStandardHours(TimesheetTable);
                holidayHoursWorked = CalculateHolidayHours(TimesheetTable);
                //MessageBox.Show($"holidayHoursWorked = {holidayHoursWorked}");
                totalHolidayToAdd = holidayHoursWorked;
                if (standardHoursWorked+holidayHoursWorked < staffContractedHoursDictionary[staffID])
                {
                    totalHolidayToAdd += (staffContractedHoursDictionary[staffID] - standardHoursWorked - holidayHoursWorked);
                    //MessageBox.Show($"totalHolidayToAdd = {totalHolidayToAdd}");
                }
            }

            if (standardHoursWorked == 0)
            {
                MessageBox.Show("Employee has worked 0 standardHours. Either there has been an error or this employee has no timesheet data for this month.");
                return;
            }

            //MessageBox.Show($"standardHoursWorked = {Math.Round(standardHoursWorked, 2).ToString()}, holidayHoursWorked = {Math.Round(holidayHoursWorked, 2).ToString()}");
            WritePayslipInfoToDatabase(standardHoursWorked, holidayHoursWorked, totalHolidayToAdd, staffID, exportID);

            if (standardHoursWorked + holidayHoursWorked < staffContractedHoursDictionary[staffID])
            {
                holidayHoursWorked = totalHolidayToAdd;
            }

            UpdatePayslipLabels(standardHoursWorked, holidayHoursWorked, staffID);
        }
        private void UpdatePayslipLabels(double standardHoursWorked, double holidayHoursWorks, int staffID)
        {
            if (staffTaxCodeDictionary[staffID] != "1250L")
            {
                MessageBox.Show("Payslip creation only works for employees with a tax code of 1250L, for standard tax-free Personal Allowance.");
                return;
            }

            int jobPositionID = staffJobDictionary[staffID];
            float jobPositionWage = jobValueDictionary[jobPositionID];
            double totalHoursWorked = holidayHoursWorks + standardHoursWorked;
            double totalHourlyPay = totalHoursWorked * jobPositionWage;
            double taxableWage = totalHourlyPay - (12500 / 12); if (taxableWage < 0) { taxableWage = 0; }
            double additionalRateTaxBand;
            double higherRateTaxBand;
            double basicRateTaxBand;
            double personalAllowance;
            double incomeTax;

            if (totalHourlyPay > (150000/12))
            {
                additionalRateTaxBand = totalHourlyPay - (150000 / 12);
                higherRateTaxBand = (150000 / 12) - (50001 / 12);
                basicRateTaxBand = (50000 / 12) - (12501 / 12);
                personalAllowance = (12500 / 12);
            }
            else if (totalHourlyPay > (50000 / 12))
            {
                additionalRateTaxBand = 0;
                higherRateTaxBand = totalHourlyPay - (50001 / 12);
                basicRateTaxBand = (50000 / 12) - (12501 / 12);
                personalAllowance = (12500 / 12);
            }
            else if (totalHourlyPay > (12500 / 12))
            {
                additionalRateTaxBand = 0;
                higherRateTaxBand = 0;
                basicRateTaxBand = totalHourlyPay - (12501 / 12);
                personalAllowance = (12500 / 12);
            }
            else
            {
                additionalRateTaxBand = 0;
                higherRateTaxBand = 0;
                basicRateTaxBand = 0;
                personalAllowance = totalHourlyPay;
            }

            incomeTax = additionalRateTaxBand * 0.45 + higherRateTaxBand * 0.4 + basicRateTaxBand * 0.2 + personalAllowance * 0;

            double nationalInsurance;
            double employerNationalInsurance;
            char NILetter = staffNILetterDictionary[staffID];
            double UpperBandTax;
            double MiddleBandTax;
            double LowerBandTax;

            if (totalHourlyPay > 4167)
            {
                UpperBandTax = totalHourlyPay - 4167;
                MiddleBandTax = 4167 - 792.01;
                LowerBandTax = 792;
            }
            else if (totalHourlyPay > 792)
            {
                UpperBandTax = 0;
                MiddleBandTax = totalHourlyPay - 792.01;
                LowerBandTax = 792;
            }
            else
            {
                UpperBandTax = 0;
                MiddleBandTax = 0;
                LowerBandTax = totalHourlyPay - 792;
            }

            // Liable to change in the future, these values are the values which would need to be maintained.
            switch (NILetter)
            {
                case 'A':
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.12 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'B':
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.0585 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'C':
                    nationalInsurance = UpperBandTax * 0 + MiddleBandTax * 0 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'H':
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.12 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0 + LowerBandTax * 0;
                    break;
                case 'J':
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.02 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'M':
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.12 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0 + LowerBandTax * 0;
                    break;
                case 'Z':
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.02 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0 + LowerBandTax * 0;
                    break;
                default:
                    nationalInsurance = -1; // rogue value
                    employerNationalInsurance = -1; // rogue value
                    break;
            }

            double takeHomePay = totalHourlyPay - nationalInsurance - incomeTax;
            

            lblEmployeeIDValue.Text = staffID.ToString();
            lblTaxMonthValue.Text = currentTaxMonth.ToString("MMMM");
            lblStandardHoursWorkedValue.Text = $"{Math.Round(standardHoursWorked, 2)} hours";
            lblHolidayHoursWorkedValue.Text = $"{Math.Round(holidayHoursWorks, 2)} hours";
            lblTotalHoursWorkedValue.Text = $"{Math.Round(totalHoursWorked, 2)} hours";
            lblHourlyRateValue.Text = $"£{jobPositionWage}";
            lblTotalHourlyPayValue.Text = $"£{Math.Round(totalHourlyPay, 2)}";
            lblTaxableWageValue.Text = $"£{Math.Round(taxableWage, 2)}";
            lblIncomeTaxValue.Text = $"£{Math.Round(incomeTax, 2)}";
            lblNationalInsuranceValue.Text = $"£{Math.Round(nationalInsurance, 2)}";
            lblEmployerNationalInsuranceValue.Text = $"£{Math.Round(employerNationalInsurance, 2)}";
            lblTakeHomePayValue.Text = $"£{Math.Round(takeHomePay, 2)}";
        }
        private void WritePayslipInfoToDatabase(double standardHoursWorked, double holidayHoursWorked, double totalHolidayToAdd, int staffID, int exportID)
        {
            // Initialize variables
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            DataTable PayslipInfoTable;
            string sql;
            int payslipID;

            // Open Database Connection
            con.Open();

            sql = $"SELECT * FROM tblPayslip WHERE staff_id={staffID} AND export_id={exportID}";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");
            PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            if (PayslipInfoTable.Rows.Count > 0)
            {
                // If there is already a row for this staffID, exportID pair then update it
                var updateCommand = new OleDbCommand();
                sql = $"UPDATE [tblPayslip] SET [standard_hours_worked]={standardHoursWorked}, [holiday_hours_worked]={holidayHoursWorked}, [holiday_hours_taken]={totalHolidayToAdd} WHERE [staff_id]={staffID} AND [export_id]={exportID};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                updateCommand.ExecuteNonQuery();
                con.Close();
                return;
            }
            // If there isn't already a row for this staffID, exportID pair then create one
            // If there isn't already a row for this staffID, exportID pair then add to the staff holiday taken.

            sql = $"SELECT * FROM tblPayslip";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");
            PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            // Close Database Connection
            con.Close();

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
            _ = new OleDbCommandBuilder(da);
            da.Update(PayslipInfoDS, "PayslipInfo");
        }
        private double CalculateStandardHours(DataTable TimesheetTable)
        {
            double standardHoursWorked = 0;
            TimeSpan TotalStandardHoursWorked = TimeSpan.Zero;
            foreach (DataRow row in TimesheetTable.Rows)
            {
                string startTimeString = row.Field<string>("timesheet_start_time");
                string endTimeString = row.Field<string>("timesheet_end_time");

                if ( startTimeString == "Absent" || startTimeString == "Holiday" || startTimeString == null ) { continue; } // Dealt with in CalculateHolidayHours
                if ( startTimeString.Trim() == "") { continue; }
                if ( endTimeString == "Absent" || endTimeString == "Holiday" || endTimeString == null ) { continue; } // Dealt with in CalculateStandardHours
                if (endTimeString.Trim() == "") { continue; }

                DateTime startTime = DateTime.ParseExact($"{startTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{endTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                TotalStandardHoursWorked += (endTime - startTime);
            }
            standardHoursWorked = TotalStandardHoursWorked.TotalHours;
            return standardHoursWorked;
        }
        private double CalculateHolidayHours(DataTable TimesheetTable)
        {
            double holidayHoursWorked = 0;
            TimeSpan TotalHolidayHoursWorked = TimeSpan.Zero;

            foreach (DataRow row in TimesheetTable.Rows)
            {
                string timesheetStartTimeString = row.Field<string>("timesheet_start_time");
                string timesheetEndTimeString = row.Field<string>("timesheet_end_time");

                if (timesheetStartTimeString != "Holiday" || timesheetEndTimeString != "Holiday") 
                {
                    continue; 
                }

                string rotaStartTimeString = row.Field<string>("rota_start_time");
                string rotaEndTimeString = row.Field<string>("rota_end_time");

                DateTime startTime = DateTime.ParseExact($"{rotaStartTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact($"{rotaEndTimeString}:00", "HH:mm:ss", CultureInfo.InvariantCulture);
                TotalHolidayHoursWorked += (endTime - startTime);
            }
            holidayHoursWorked = TotalHolidayHoursWorked.TotalHours;
            return holidayHoursWorked;
        }

        private Tuple<DataTable, int> GetTimesheetHoursWorkedTable(int staffID)
        {
            // Initialize variables
            DataSet ExportInfoDS;
            DataSet TimesheetDS;
            OleDbDataAdapter da;
            DataTable ExportInfoTable;
            DataTable TimesheetTable;
            string sql;

            // Open Database Connection
            con.Open();

            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT export_id FROM tblExport WHERE tax_month_start_date=#{currentTaxMonth.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");
            ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];
            int exportID = ExportInfoTable.Rows[0].Field<int>("export_id");

            sql = $"SELECT rota_start_time, rota_end_time, timesheet_start_time, timesheet_end_time FROM tblRota WHERE export_id={exportID} AND staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            TimesheetDS = new DataSet();
            da.Fill(TimesheetDS, "TimesheetInfo");
            TimesheetTable = TimesheetDS.Tables["TimesheetInfo"];

            //MessageBox.Show(TimesheetTable.Rows.Count.ToString());

            // Close Database Connection
            con.Close();

            return new Tuple<DataTable, int>(TimesheetTable, exportID);
        }
        private void UpdateCurrentMonthLabel()
        {
            lblCurrentTaxMonth.Text = $"Tax Month - {currentTaxMonth.ToString("D")}";
        }
        private void SetCurrentMonth()
        {
            string dd = "06";
            string MM = DateTime.Now.Month.ToString();
            string yyyy = DateTime.Now.Year.ToString();

            if (MM.Length == 1) { MM = $"0{MM}"; }

            currentTaxMonth = DateTime.ParseExact($"{dd}/{MM}/{yyyy}", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        private void InitializeStaffComboBox()
        {
            string[] employeeArray = staffNameDictionary.Values.ToArray<string>();
            comboBoxSelectEmployee.Items.AddRange(employeeArray);
        }
        private void GetJobWageData()
        {
            // Initialize Job Dictionary
            jobValueDictionary = new Dictionary<int, float>();

            // Initialize variables
            DataSet JobInfoDS;
            OleDbDataAdapter da;
            DataTable JobInfoTable;
            string sql;

            // Open Database Connection
            con.Open();

            sql = $"SELECT jobposition_id, jobposition_wage FROM tblJobPositions";
            da = new OleDbDataAdapter(sql, con);
            JobInfoDS = new DataSet();
            da.Fill(JobInfoDS, "JobInfo");
            JobInfoTable = JobInfoDS.Tables["JobInfo"];

            // CLose Database Connection
            con.Close();

            foreach (DataRow row in JobInfoTable.Rows)
            {
                int jobpositionID = row.Field<int>("jobposition_id");
                float jobpositionWage = float.Parse(row.Field<string>("jobposition_wage").Remove(0,1));
                //MessageBox.Show($"jobpositionID = {jobpositionID}, jobpositionWage = {jobpositionWage}");
                jobValueDictionary.Add(jobpositionID, jobpositionWage);
            }
        }
        private void GetStaffData()
        {
            // Initialize Dictionarys
            staffNameDictionary = new Dictionary<int, string>();
            staffJobDictionary = new Dictionary<int, int>();
            staffSalaryTypeDictionary = new Dictionary<int, string>();
            staffContractedHoursDictionary = new Dictionary<int, int>();
            staffNILetterDictionary = new Dictionary<int, char>();
            staffTaxCodeDictionary = new Dictionary<int, string>();

            // Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            DataTable StaffInfoTable;
            string sql;

            // Open Database Connection
            con.Open();

            sql = $"SELECT staff_id, jobposition_id, staff_firstname, staff_surname, staff_contract_type, staff_salaried_hours, staff_NI_letter, staff_tax_code FROM tblStaff ORDER BY staff_surname ASC";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");
            StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            // CLose Database Connection
            con.Close();

            foreach (DataRow row in StaffInfoTable.Rows)
            {
                int staffID = row.Field<int>("staff_id");
                int jobpositionID = row.Field<int>("jobposition_id");
                string staffName = $"{row.Field<string>("staff_firstname")} {row.Field<string>("staff_surname")}";
                string staffContractType = row.Field<string>("staff_contract_type");
                int staffSalariedHours = row.Field<int>("staff_salaried_hours");
                char staffNILetter = char.Parse(row.Field<string>("staff_NI_letter"));
                string staffTaxCode = row.Field<string>("staff_tax_code");
                staffNameDictionary.Add(staffID, staffName);
                staffJobDictionary.Add(staffID, jobpositionID);
                staffSalaryTypeDictionary.Add(staffID, staffContractType);
                staffContractedHoursDictionary.Add(staffID, staffSalariedHours);
                staffNILetterDictionary.Add(staffID, staffNILetter);
                staffTaxCodeDictionary.Add(staffID, staffTaxCode);
            }
        }
        private void InitializeDatabaseConnection()
        {
            // Initialize variables
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FullDatabasePath = "";
            string dbSource;

            try
            {
                // Establish Connection with Database
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
                Console.WriteLine($"Error establishing database connection Payslip. FullDatabasePath = {FullDatabasePath}");
                MessageBox.Show($"Error establishing database connection Payslip. FullDatabasePath = {FullDatabasePath}");
            }
        }
        private void comboBoxSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private int GetStaffID(string staffName)
        {
            return staffNameDictionary.FirstOrDefault(keyValuePair => keyValuePair.Value == staffName).Key;
        }
        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            currentTaxMonth = currentTaxMonth.AddMonths(-1);
            UpdateCurrentMonthLabel();
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentTaxMonth = currentTaxMonth.AddMonths(1);
            UpdateCurrentMonthLabel();
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
    }
}
