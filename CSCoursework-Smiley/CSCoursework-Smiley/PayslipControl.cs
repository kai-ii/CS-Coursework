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
using MigraDoc.DocumentObjectModel;
using System.Text.RegularExpressions;
using PdfSharp.Pdf;
using PdfSharp;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel.Shapes;
using System.Diagnostics;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace CSCoursework_Smiley.Properties
{
    // dev note: Payslip tax -> national insurance based on NI number + income tax based on tax code
    public partial class PayslipControl : UserControl
    {
        // Initialise local class variables.
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
            // Initialize the current month and then update the current month label.
            SetCurrentMonth();
            UpdateCurrentMonthLabel();
            // Get staff and job data and then initialize the staff combobox with a default value.
            GetStaffData();
            GetJobWageData();
            InitializeStaffComboBox();
            comboBoxSelectEmployee.SelectedIndex = 0;
        }
        private void PayslipControl_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database.
        }
        public void UpdatePayslipInfo() // Called after manage jobs is changed.
        {
            // Recalculate the payslip information since a job position wage may have changed.
            GetJobWageData();
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private void CalculatePayslipInformation(int staffID)
        {
            // Initialize variables.
            Tuple<DataTable, int> TimesheetExportTuple = GetTimesheetHoursWorkedTable(staffID);
            DataTable TimesheetTable = TimesheetExportTuple.Item1;
            int exportID = TimesheetExportTuple.Item2;
            double standardHoursWorked = -1;
            double holidayHoursWorked = -1;
            double totalHolidayToAdd = 0;

            // Check the contract type of the selected employee
            if (staffSalaryTypeDictionary[staffID] == "Flexible")
            {
                // If flexible then calculate standard hours worked as normal
                standardHoursWorked = CalculateStandardHours(TimesheetTable);
                // Then at Smiley Happy People, holiday wage is paid as a 12.07% bonus on the standard hours worked. In practise this is represented by setting the holiday hours worked to simply 12.07% of the standard hours worked by multiplying it by 0.1207
                holidayHoursWorked = standardHoursWorked * 0.1207;
            }
            else if (staffSalaryTypeDictionary[staffID] == "Salaried")
            {
                // If salaried then calculate standard hours normally
                standardHoursWorked = CalculateStandardHours(TimesheetTable);
                // Then holiday hours are calculated based on how many holiday fields there are in the month and calculating it based on the hours they were supposed to work.
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
                MessageBox.Show("Employee has worked 0 standard hours. Either there has been an error or this employee has no timesheet data for this month.");
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
        private double GetIncomeTax(double totalHourlyPay)
        {
            // Initialize variables.
            double additionalRateTaxBand;
            double higherRateTaxBand;
            double basicRateTaxBand;
            double personalAllowance;
            double incomeTax;

            // Calculate income tax based on tax bands.
            if (totalHourlyPay > (150000 / 12))
            {
                additionalRateTaxBand = totalHourlyPay - (150000 / 12);
                higherRateTaxBand = (150000 / 12) - (50001 / 12);
                basicRateTaxBand = (50000 / 12) - (12501 / 12);
                personalAllowance = (12500 / 12);
            }
            // Calculate income tax based on tax bands.
            else if (totalHourlyPay > (50000 / 12))
            {
                additionalRateTaxBand = 0;
                higherRateTaxBand = totalHourlyPay - (50001 / 12);
                basicRateTaxBand = (50000 / 12) - (12501 / 12);
                personalAllowance = (12500 / 12);
            }
            // Calculate income tax based on tax bands.
            else if (totalHourlyPay > (12500 / 12))
            {
                additionalRateTaxBand = 0;
                higherRateTaxBand = 0;
                basicRateTaxBand = totalHourlyPay - (12501 / 12);
                personalAllowance = (12500 / 12);
            }
            // Calculate income tax based on tax bands.
            else
            {
                additionalRateTaxBand = 0;
                higherRateTaxBand = 0;
                basicRateTaxBand = 0;
                personalAllowance = totalHourlyPay;
            }

            // Calculate income tax based on tax bands.
            incomeTax = additionalRateTaxBand * 0.45 + higherRateTaxBand * 0.4 + basicRateTaxBand * 0.2 + personalAllowance * 0;
            return incomeTax;
        }
        private Tuple<double, double> GetNationalInsurance(double totalHourlyPay, char NILetter)
        {
            // Initialize national insurance.
            double nationalInsurance;
            double employerNationalInsurance;
            double UpperBandTax;
            double MiddleBandTax;
            double LowerBandTax;

            // Calculate national insurance based on tax bands.
            if (totalHourlyPay > 4167)
            {
                UpperBandTax = totalHourlyPay - 4167;
                MiddleBandTax = 4167 - 792.01;
                LowerBandTax = 792;
            }
            // Calculate national insurance based on tax bands.
            else if (totalHourlyPay > 792)
            {
                UpperBandTax = 0;
                MiddleBandTax = totalHourlyPay - 792.01;
                LowerBandTax = 792;
            }
            // Calculate national insurance based on tax bands.
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
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.12 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'B':
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.0585 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'C':
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0 + MiddleBandTax * 0 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'H':
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.12 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0 + LowerBandTax * 0;
                    break;
                case 'J':
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.02 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0.138 + LowerBandTax * 0;
                    break;
                case 'M':
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.12 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0 + LowerBandTax * 0;
                    break;
                case 'Z':
                    // Calculate the weights of each tax band based on government given values.
                    nationalInsurance = UpperBandTax * 0.02 + MiddleBandTax * 0.02 + LowerBandTax * 0;
                    employerNationalInsurance = UpperBandTax * 0.138 + MiddleBandTax * 0 + LowerBandTax * 0;
                    break;
                default:
                    nationalInsurance = -1; // rogue value
                    employerNationalInsurance = -1; // rogue value
                    break;
            }

            // return the employees and employers national insurance.
            return new Tuple<double, double>(nationalInsurance, employerNationalInsurance);
        }
        private void UpdatePayslipLabels(double standardHoursWorked, double holidayHoursWorks, int staffID)
        {
            /*Displays the payslip information for the selected employee*/
            if (staffTaxCodeDictionary[staffID] != "1250L")
            {
                // These income tax calculations are only applicable to a tax code of 1250L.
                MessageBox.Show("Payslip creation only works for employees with a tax code of 1250L, for standard tax-free Personal Allowance.");
                return;
            }

            // Initialize variables.
            int jobPositionID = staffJobDictionary[staffID];
            float jobPositionWage = jobValueDictionary[jobPositionID];
            double totalHoursWorked = holidayHoursWorks + standardHoursWorked;
            double totalHourlyPay = totalHoursWorked * jobPositionWage;
            double taxableWage = totalHourlyPay - (12500 / 12); if (taxableWage < 0) { taxableWage = 0; }

            // Get income tax.
            double incomeTax = GetIncomeTax(totalHourlyPay);

            // Get national insurance.
            char NILetter = staffNILetterDictionary[staffID];
            Tuple<double, double> nationalInsuranceEmployeeEmployer = GetNationalInsurance(totalHourlyPay, NILetter);
            double nationalInsurance = nationalInsuranceEmployeeEmployer.Item1;
            double employerNationalInsurance = nationalInsuranceEmployeeEmployer.Item2;

            // Calculate take home pay.
            double takeHomePay = totalHourlyPay - nationalInsurance - incomeTax;
            
            // Set all labels.
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
            // Initialize database variables.
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            DataTable PayslipInfoTable;
            string sql;

            // Initialize variables.
            int payslipID;

            // Open Database Connection.
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

            // Generate new row and add it to the database.
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
            // Initialize variables
            double standardHoursWorked = 0;
            TimeSpan TotalStandardHoursWorked = TimeSpan.Zero;

            // For each row get the start time and end time, skip the row if its an absent or holiday row. Then calculate the hours worked for that day and add it to the TotalStandardHoursWorked variable.
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
            // Return standardHoursWorked.
            standardHoursWorked = TotalStandardHoursWorked.TotalHours;
            return standardHoursWorked;
        }
        private double CalculateHolidayHours(DataTable TimesheetTable)
        {
            // Initialize variables.
            double holidayHoursWorked = 0;
            TimeSpan TotalHolidayHoursWorked = TimeSpan.Zero;

            // Foreach row in the timesheet table, if the row is not a holiday row skip it, otherwise calculate the hours the worker was meant to wrote, dictated by the rota'd hours, then add it to the total hours worked variable.
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
            // Return the total holiday hours worked.
            holidayHoursWorked = TotalHolidayHoursWorked.TotalHours;
            return holidayHoursWorked;
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

            // Open Database Connection.
            con.Open();

            // Initialize export dataset.
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT export_id FROM tblExport WHERE tax_month_start_date=#{currentTaxMonth.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");

            // Initialize export datatable.
            ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];

            // Initialize exportID.
            int exportID = ExportInfoTable.Rows[0].Field<int>("export_id");

            // Initialize timesheet dataset.
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
        private void UpdateCurrentMonthLabel()
        {
            // Update the current tax month label with the current tax month.
            lblCurrentTaxMonth.Text = $"Tax Month - {currentTaxMonth:D}";
        }
        private void SetCurrentMonth()
        {
            // Set up the current month variable as the sixth of the current month of the current year.
            string dd = "06";
            string MM = DateTime.Now.Month.ToString();
            string yyyy = DateTime.Now.Year.ToString();

            // If the month is only a single digit, format it to have a 0 infront.
            if (MM.Length == 1) { MM = $"0{MM}"; }

            // ParseExact is used to parse the current tax month since the string will always be valid.
            currentTaxMonth = DateTime.ParseExact($"{dd}/{MM}/{yyyy}", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        private void InitializeStaffComboBox()
        {
            // Add the employees grabbed from the database to the combobox.
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

            // Close Database Connection
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
            // Initialize Dictionaries
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

            // Foreach row, add to the local dictionaries for use in other functions.
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
        private void comboBoxSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the selected employee changed, get the staffID of the staff member selected and calculate the payslip information of that employee. This will then be displayed.
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private int GetStaffID(string staffName)
        {
            // Returns a backwards dictionary search which finds the key (staffID) for the given value (staffName)
            return staffNameDictionary.FirstOrDefault(keyValuePair => keyValuePair.Value == staffName).Key;
        }
        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            // Change the selected month by -1 months (previous month) and update the displayed month
            currentTaxMonth = currentTaxMonth.AddMonths(-1);
            UpdateCurrentMonthLabel();
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            // Change the selected month by +1 months (next month) and update the displayed month
            currentTaxMonth = currentTaxMonth.AddMonths(1);
            UpdateCurrentMonthLabel();
            int staffID = GetStaffID(comboBoxSelectEmployee.SelectedItem.ToString());
            CalculatePayslipInformation(staffID);
        }
        private void AddPage(PdfDocument document, string staffName)
        {
            /*Add a page to the PDF document.*/
            int staffID = GetStaffID(staffName);

            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Portrait;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.MUH = PdfFontEncoding.Unicode;

            //A MigraDoc document is required for rendering
            Document doc = new Document();
            Section section = doc.AddSection();

            //Set document to portrait
            section.PageSetup = doc.DefaultPageSetup.Clone();
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
            section.PageSetup.PageFormat = PageFormat.A4;

            // Add employee/employer info text frame
            TextFrame employeeEmployerTextFrame = section.AddTextFrame();
            employeeEmployerTextFrame.Height = "4.0cm";
            employeeEmployerTextFrame.Width = "10.0cm";
            employeeEmployerTextFrame.Left = ShapePosition.Left;
            employeeEmployerTextFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            employeeEmployerTextFrame.RelativeVertical = RelativeVertical.Page;
            employeeEmployerTextFrame.Top = "1.0cm";

            // Fill employee/employer info text frame
            Paragraph employeeEmployerParagraph = employeeEmployerTextFrame.AddParagraph();
            employeeEmployerParagraph.Format.Font.Size = "0.4cm";
            employeeEmployerParagraph.AddFormattedText("Employer's Name: ", TextFormat.Bold);
            employeeEmployerParagraph.AddText($"Vron Walters");
            employeeEmployerParagraph.AddLineBreak();
            employeeEmployerParagraph.AddFormattedText("Employee's name: ", TextFormat.Bold);
            employeeEmployerParagraph.AddText($"{staffName}");
            employeeEmployerParagraph.AddLineBreak();
            employeeEmployerParagraph.AddFormattedText("NI Letter: ", TextFormat.Bold);
            employeeEmployerParagraph.AddText($"{staffNILetterDictionary[staffID]}");
            employeeEmployerParagraph.AddLineBreak();
            employeeEmployerParagraph.AddFormattedText("Tax Code: ", TextFormat.Bold);
            employeeEmployerParagraph.AddText($"{staffTaxCodeDictionary[staffID]}");

            // Add pay period and pay date text frome
            TextFrame payPeriodDateTextFrame = section.AddTextFrame();
            payPeriodDateTextFrame.Height = "4.0cm";
            payPeriodDateTextFrame.Width = "10.0cm";
            payPeriodDateTextFrame.Left = ShapePosition.Left;
            payPeriodDateTextFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            payPeriodDateTextFrame.RelativeVertical = RelativeVertical.Page;
            payPeriodDateTextFrame.Top = "1.0cm";

            // Fill pay period and pay date text frame
            Paragraph payPeriodDateParagraph = payPeriodDateTextFrame.AddParagraph();
            payPeriodDateParagraph.Format.Font.Size = "0.4cm";
            payPeriodDateParagraph.AddFormattedText("Pay period: ", TextFormat.Bold);
            payPeriodDateParagraph.AddText($"{currentTaxMonth:d}");
            payPeriodDateParagraph.AddFormattedText(" to ", TextFormat.Bold);
            payPeriodDateParagraph.AddText($"{currentTaxMonth.AddDays(-1).AddMonths(1):d}");
            payPeriodDateParagraph.AddLineBreak();
            payPeriodDateParagraph.AddFormattedText("Date of payment: ", TextFormat.Bold);
            payPeriodDateParagraph.AddText($"{currentTaxMonth.AddMonths(1):d}");
            payPeriodDateParagraph.AddLineBreak();

            // Add the earnings table
            Table earningsTable = section.AddTable();
            earningsTable.Style = "Table";
            earningsTable.Borders.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(0, 0, 0);
            earningsTable.Borders.Width = 0.25;
            earningsTable.Borders.Left.Width = 0.25;
            earningsTable.Borders.Right.Width = 0.25;
            earningsTable.Rows.LeftIndent = 0;

            // Add the table columns, 7cm/4cm/4cm/4cm
            Column earningsColumn = earningsTable.AddColumn("7cm");
            earningsColumn.Format.Alignment = ParagraphAlignment.Left;

            earningsColumn = earningsTable.AddColumn("4cm");
            earningsColumn.Format.Alignment = ParagraphAlignment.Right;

            earningsColumn = earningsTable.AddColumn("4cm");
            earningsColumn.Format.Alignment = ParagraphAlignment.Right;

            earningsColumn = earningsTable.AddColumn("4cm");
            earningsColumn.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row earningsRow = earningsTable.AddRow();
            earningsRow.HeadingFormat = true;
            earningsRow.Format.Alignment = ParagraphAlignment.Center;
            earningsRow.Format.Font.Bold = true;
            earningsRow.Height = "0.7cm";
            earningsRow.Format.Font.Size = "0.41cm";
            earningsRow.Cells[0].AddParagraph("Earnings");
            earningsRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            earningsRow.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow.Cells[1].AddParagraph("Unit");
            earningsRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            earningsRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;
            earningsRow.Cells[2].AddParagraph("Rate");
            earningsRow.Cells[2].Format.Alignment = ParagraphAlignment.Right;
            earningsRow.Cells[2].VerticalAlignment = VerticalAlignment.Top;
            earningsRow.Cells[3].AddParagraph("Total");
            earningsRow.Cells[3].Format.Alignment = ParagraphAlignment.Right;
            earningsRow.Cells[3].VerticalAlignment = VerticalAlignment.Top;

            // Get Earnings Table Information
            Tuple<double, double> hoursWorkedTuple = GetHoursWorkedTuple(staffID);
            double standardHoursWorked = hoursWorkedTuple.Item1;
            double holidayHoursWorked = hoursWorkedTuple.Item2;
            int jobpositionID = staffJobDictionary[staffID];
            float jobpositionWage = jobValueDictionary[jobpositionID];
            double standardHourlyPay = standardHoursWorked * jobpositionWage;
            double holidayHourlyPay = holidayHoursWorked * jobpositionWage;
            double totalHourlyPay = standardHourlyPay + holidayHourlyPay;

            // Format Row 1
            Row earningsRow1 = earningsTable.AddRow();
            earningsRow1.Height = "0.7cm";
            earningsRow1.Format.Font.Size = "0.4cm";
            earningsRow1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            earningsRow1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            earningsRow1.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow1.Cells[2].Format.Alignment = ParagraphAlignment.Right;
            earningsRow1.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow1.Cells[3].Format.Alignment = ParagraphAlignment.Right;
            earningsRow1.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 1 Data
            earningsRow1.Cells[0].AddParagraph("Standard Hours");
            earningsRow1.Cells[1].AddParagraph($"{Math.Round(standardHoursWorked, 2)} hours");
            earningsRow1.Cells[2].AddParagraph($"£{jobpositionWage}");
            earningsRow1.Cells[3].AddParagraph($"£{Math.Round(standardHourlyPay, 2)}");

            // Format Row 2
            Row earningsRow2 = earningsTable.AddRow();
            earningsRow2.Height = "0.7cm";
            earningsRow2.Format.Font.Size = "0.4cm";
            earningsRow2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            earningsRow2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow2.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            earningsRow2.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow2.Cells[2].Format.Alignment = ParagraphAlignment.Right;
            earningsRow2.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow2.Cells[3].Format.Alignment = ParagraphAlignment.Right;
            earningsRow2.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 2 Data
            earningsRow2.Cells[0].AddParagraph("Holiday Hours");
            earningsRow2.Cells[1].AddParagraph($"{Math.Round(holidayHoursWorked, 2)} hours");
            earningsRow2.Cells[2].AddParagraph($"£{jobpositionWage}");
            earningsRow2.Cells[3].AddParagraph($"£{Math.Round(holidayHoursWorked * jobpositionWage, 2)}");

            // Format Row 3
            Row earningsRow3 = earningsTable.AddRow();
            earningsRow3.Height = "0.75cm";
            earningsRow3.Format.Font.Size = "0.41cm";
            earningsRow3.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            earningsRow3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            earningsRow3.Cells[0].MergeRight = 2;
            earningsRow3.Cells[3].Format.Alignment = ParagraphAlignment.Right;
            earningsRow3.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 3 Data
            Paragraph earningsRow3Paragraph = earningsRow3.Cells[0].AddParagraph();
            earningsRow3Paragraph.AddFormattedText("Gross Payment", TextFormat.Bold);
            earningsRow3.Cells[3].AddParagraph($"£{Math.Round(totalHourlyPay, 2)}");

            // Set Table Edge
            earningsTable.SetEdge(0, 0, 4, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            // Add the deductions table
            Table deductionsTable = section.AddTable();
            deductionsTable.Style = "Table";
            deductionsTable.Borders.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(0, 0, 0);
            deductionsTable.Borders.Width = 0.25;
            deductionsTable.Borders.Left.Width = 0.25;
            deductionsTable.Borders.Right.Width = 0.25;
            deductionsTable.Rows.LeftIndent = 0;

            // Add the table columns, 15cm/4cm
            Column deductionsColumn = deductionsTable.AddColumn("15cm");
            deductionsColumn.Format.Alignment = ParagraphAlignment.Left;

            deductionsColumn = deductionsTable.AddColumn("4cm");
            deductionsColumn.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row deductionsRow = deductionsTable.AddRow();
            deductionsRow.HeadingFormat = true;
            deductionsRow.Format.Alignment = ParagraphAlignment.Center;
            deductionsRow.Format.Font.Bold = true;
            deductionsRow.Height = "0.7cm";
            deductionsRow.Format.Font.Size = "0.41cm";
            deductionsRow.Cells[0].AddParagraph("Deductions");
            deductionsRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            deductionsRow.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            deductionsRow.Cells[1].AddParagraph("Total");
            deductionsRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            deductionsRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Get Deductions Table Information
            Tuple<double, double> nationalInsuranceEmployeeEmployer = GetNationalInsurance(totalHourlyPay, staffNILetterDictionary[staffID]);
            double nationalInsurance = nationalInsuranceEmployeeEmployer.Item1;
            double incomeTax = GetIncomeTax(totalHourlyPay);

            // Format Row 1
            Row deductionsRow1 = deductionsTable.AddRow();
            deductionsRow1.Height = "0.7cm";
            deductionsRow1.Format.Font.Size = "0.4cm";
            deductionsRow1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            deductionsRow1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            deductionsRow1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            deductionsRow1.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 1 Data
            deductionsRow1.Cells[0].AddParagraph("Income Tax");
            deductionsRow1.Cells[1].AddParagraph($"£{Math.Round(incomeTax, 2)}");

            // Format Row 2
            Row deductionsRow2 = deductionsTable.AddRow();
            deductionsRow2.Height = "0.7cm";
            deductionsRow2.Format.Font.Size = "0.4cm";
            deductionsRow2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            deductionsRow2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            deductionsRow2.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            deductionsRow2.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 2 Data
            deductionsRow2.Cells[0].AddParagraph("National Insurance");
            deductionsRow2.Cells[1].AddParagraph($"£{Math.Round(nationalInsurance, 2)}");

            // Format Row 3
            Row deductionsRow3 = deductionsTable.AddRow();
            deductionsRow3.Height = "0.75cm";
            deductionsRow3.Format.Font.Size = "0.41cm";
            deductionsRow3.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            deductionsRow3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            deductionsRow3.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            deductionsRow3.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 3 Data
            Paragraph deductionsRow3Paragraph = deductionsRow3.Cells[0].AddParagraph();
            deductionsRow3Paragraph.AddFormattedText("Total Deductions", TextFormat.Bold);
            deductionsRow3.Cells[1].AddParagraph($"£{Math.Round(nationalInsurance + incomeTax, 2)}");

            // Set Table Edge
            deductionsTable.SetEdge(0, 0, 2, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            // Add the employer contributions table
            Table contributionsTable = section.AddTable();
            contributionsTable.Style = "Table";
            contributionsTable.Borders.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(0, 0, 0);
            contributionsTable.Borders.Width = 0.25;
            contributionsTable.Borders.Left.Width = 0.25;
            contributionsTable.Borders.Right.Width = 0.25;
            contributionsTable.Rows.LeftIndent = 0;

            // Add the table columns, 15cm/4cm
            Column contributionsColumn = contributionsTable.AddColumn("15cm");
            contributionsColumn.Format.Alignment = ParagraphAlignment.Left;

            contributionsColumn = contributionsTable.AddColumn("4cm");
            contributionsColumn.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row contributionsRow = contributionsTable.AddRow();
            contributionsRow.HeadingFormat = true;
            contributionsRow.Format.Alignment = ParagraphAlignment.Center;
            contributionsRow.Format.Font.Bold = true;
            contributionsRow.Height = "0.7cm";
            contributionsRow.Format.Font.Size = "0.41cm";
            contributionsRow.Cells[0].AddParagraph("Employer Contributions");
            contributionsRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            contributionsRow.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            contributionsRow.Cells[1].AddParagraph("Total");
            contributionsRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            contributionsRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Get Employer Contributions Information
            double employerNationalInsurance = nationalInsuranceEmployeeEmployer.Item2;

            // Format Row 1
            Row contributionsRow1 = contributionsTable.AddRow();
            contributionsRow1.Height = "0.7cm";
            contributionsRow1.Format.Font.Size = "0.4cm";
            contributionsRow1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            contributionsRow1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            contributionsRow1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            contributionsRow1.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 1 Data
            contributionsRow1.Cells[0].AddParagraph("Employer National Insurance Contributions");
            contributionsRow1.Cells[1].AddParagraph($"£{Math.Round(employerNationalInsurance, 2)}");

            // Format Row 2
            Row contributionsRow2 = contributionsTable.AddRow();
            contributionsRow2.Height = "0.75cm";
            contributionsRow2.Format.Font.Size = "0.41cm";
            contributionsRow2.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            contributionsRow2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            contributionsRow2.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            contributionsRow2.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 2 Data
            Paragraph contributionsRow2Paragraph = contributionsRow2.Cells[0].AddParagraph();
            contributionsRow2Paragraph.AddFormattedText("Total Net Contribution", TextFormat.Bold);
            contributionsRow2.Cells[1].AddParagraph($"£{Math.Round(employerNationalInsurance, 2)}");

            // Set Table Edge
            contributionsTable.SetEdge(0, 0, 2, 3, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            // Add the totals table
            Table totalsTable = section.AddTable();
            totalsTable.Style = "Table";
            totalsTable.Borders.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(0, 0, 0);
            totalsTable.Borders.Width = 0.25;
            totalsTable.Borders.Left.Width = 0.25;
            totalsTable.Borders.Right.Width = 0.25;
            totalsTable.Rows.LeftIndent = 0;

            // Add the table columns, 15cm/4cm
            Column totalsColumn = totalsTable.AddColumn("15cm");
            totalsColumn.Format.Alignment = ParagraphAlignment.Left;

            totalsColumn = totalsTable.AddColumn("4cm");
            totalsColumn.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row totalsRow = totalsTable.AddRow();
            totalsRow.HeadingFormat = true;
            totalsRow.Format.Alignment = ParagraphAlignment.Center;
            totalsRow.Format.Font.Bold = true;
            totalsRow.Height = "0.7cm";
            totalsRow.Format.Font.Size = "0.41cm";
            totalsRow.Cells[0].AddParagraph("Totals");
            totalsRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            totalsRow.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            totalsRow.Cells[1].AddParagraph("Total");
            totalsRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            totalsRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Get totals data
            double netPayment = totalHourlyPay - nationalInsurance - incomeTax;
            string netPaymentString;
            try
            {
                if (Math.Round(netPayment, 2).ToString().Split('.')[1].Length == 1)
                {
                    netPaymentString = $"{Math.Round(netPayment, 2)}0";
                }
                else
                {
                    netPaymentString = Math.Round(netPayment, 2).ToString();
                }
            }
            catch
            {
                netPaymentString = $"{Math.Round(netPayment, 2)}.00";
            }
            

            // Format Row 1
            Row totalsRow1 = totalsTable.AddRow();
            totalsRow1.Height = "0.7cm";
            totalsRow1.Format.Font.Size = "0.4cm";
            totalsRow1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            totalsRow1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            totalsRow1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            totalsRow1.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 1 Data
            totalsRow1.Cells[0].AddParagraph("Gross Earnings");
            totalsRow1.Cells[1].AddParagraph($"£{Math.Round(totalHourlyPay, 2)}");

            // Format Row 2
            Row totalsRow2 = totalsTable.AddRow();
            totalsRow2.Height = "0.7cm";
            totalsRow2.Format.Font.Size = "0.4cm";
            totalsRow2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            totalsRow2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            totalsRow2.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            totalsRow2.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 2 Data
            totalsRow2.Cells[0].AddParagraph("Total Deductions");
            totalsRow2.Cells[1].AddParagraph($"£{Math.Round(nationalInsurance + incomeTax, 2)}");

            // Format Row 3
            Row totalsRow3 = totalsTable.AddRow();
            totalsRow3.Height = "0.75cm";
            totalsRow3.Format.Font.Size = "0.41cm";
            totalsRow3.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            totalsRow3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            totalsRow3.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            totalsRow3.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            // Add Row 3 Data
            Paragraph totalsRow3Paragraph = totalsRow3.Cells[0].AddParagraph();
            totalsRow3Paragraph.AddFormattedText("Net Payment", TextFormat.Bold);
            totalsRow3.Cells[1].AddParagraph($"£{netPaymentString}");

            // Set Table Edge
            totalsTable.SetEdge(0, 0, 2, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            //Create a renderer and prepare (=layout) the document
            DocumentRenderer docRenderer = new DocumentRenderer(doc);
            docRenderer.PrepareDocument();

            //Render the paragraph. You can render tables or shapes the same way
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(13), XUnit.FromCentimeter(1), "10cm", payPeriodDateParagraph);
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(1), XUnit.FromCentimeter(2), "10cm", employeeEmployerParagraph);
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(1), XUnit.FromCentimeter(4.5), "20cm", earningsTable);
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(1), XUnit.FromCentimeter(8.85), "20cm", deductionsTable);
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(1), XUnit.FromCentimeter(13.2), "20cm", contributionsTable);
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(1), XUnit.FromCentimeter(16.85), "20cm", totalsTable);
        }

        private Tuple<double, double> GetHoursWorkedTuple(int staffID)
        {
            // Initialize database variables.
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            DataTable PayslipInfoTable;
            string sql;

            // Open Database Connection.
            con.Open();

            // Initialize database variables.
            DataSet ExportInfoDS;
            DataTable ExportInfoTable;

            // Initialize export dataset.
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT export_id FROM tblExport WHERE tax_month_start_date=#{currentTaxMonth.ToString("d", USCulture)}#";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");

            // Initialize export datatable.
            ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];

            // Initialize exportID.
            int exportID = ExportInfoTable.Rows[0].Field<int>("export_id");

            if (staffSalaryTypeDictionary[staffID] == "Salaried") { sql = $"SELECT standard_hours_worked, holiday_hours_taken FROM tblPayslip WHERE staff_id={staffID} AND export_id={exportID}"; }
            else { sql = $"SELECT standard_hours_worked, holiday_hours_worked FROM tblPayslip WHERE staff_id={staffID} AND export_id={exportID}"; }

            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");
            PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            // Close Database Connection.
            con.Close();

            // If there isn't a row for the current staff member, generate one.
            if (PayslipInfoTable.Rows.Count == 0) 
            {
                CalculatePayslipInformation(staffID);

                // Open database connection.
                con.Open();

                // Change sql based on contract type of the staff member.
                if (staffSalaryTypeDictionary[staffID] == "Salaried") { sql = $"SELECT standard_hours_worked, holiday_hours_taken FROM tblPayslip WHERE staff_id={staffID} AND export_id={exportID}"; }
                else { sql = $"SELECT standard_hours_worked, holiday_hours_worked FROM tblPayslip WHERE staff_id={staffID} AND export_id={exportID}"; }

                // Initialize payslip dataset.
                da = new OleDbDataAdapter(sql, con);
                PayslipInfoDS = new DataSet();
                da.Fill(PayslipInfoDS, "PayslipInfo");

                // Close database connection.
                con.Close();

                PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];
                if (PayslipInfoTable.Rows.Count == 0)
                {
                    // If even after generating the new payslip information there is no row for this staff member, return 0 hours worked.
                    return new Tuple<double, double>(0, 0);
                }
            }
            if (staffSalaryTypeDictionary[staffID] == "Salaried") { return new Tuple<double, double>(PayslipInfoTable.Rows[0].Field<double>("standard_hours_worked"), PayslipInfoTable.Rows[0].Field<double>("holiday_hours_taken")); }
            return new Tuple<double, double>(PayslipInfoTable.Rows[0].Field<double>("standard_hours_worked"), PayslipInfoTable.Rows[0].Field<double>("holiday_hours_worked"));
        }
        private void btnGenerateSinglePayslip_Click(object sender, EventArgs e)
        {
            string filename = $"{currentTaxMonth:MMMM}{currentTaxMonth.Year}{comboBoxSelectEmployee.SelectedItem.ToString().Split(' ')[0]}{comboBoxSelectEmployee.SelectedItem.ToString().Split(' ')[1]}Payslip.pdf";
            //filename = Regex.Replace(filename, @"\s+", "");

            PdfDocument pdfdocument = new PdfDocument();
            pdfdocument.Info.Title = $"{currentTaxMonth:MMMM}{currentTaxMonth.Year}{comboBoxSelectEmployee.SelectedItem.ToString().Split(' ')[0]}{comboBoxSelectEmployee.SelectedItem.ToString().Split(' ')[1]}Payslip";
            pdfdocument.Info.Author = "Kai Chevannes";
            pdfdocument.Info.Subject = $"Displays payslip for {comboBoxSelectEmployee.SelectedItem} for {currentTaxMonth:d}";
            pdfdocument.Info.Keywords = "PDFsharp, XGraphics";

            // Only add a single page for the selected employee.
            AddPage(pdfdocument, comboBoxSelectEmployee.SelectedItem.ToString());

            //Save document
            pdfdocument.Save(filename);
            //Start a viewer
            Process.Start(filename);
        }
        private void btnGenerateAllPayslips_Click(object sender, EventArgs e)
        {
            string filename = $"{currentTaxMonth:MMMM}{currentTaxMonth.Year}Payroll.pdf";
            //filename = Regex.Replace(filename, @"\s+", "");

            PdfDocument pdfdocument = new PdfDocument();
            pdfdocument.Info.Title = $"{currentTaxMonth:MMMM}{currentTaxMonth.Year}Payroll";
            pdfdocument.Info.Author = "Kai Chevannes";
            pdfdocument.Info.Subject = $"Displays payslip for {comboBoxSelectEmployee.SelectedItem} for {currentTaxMonth:d}";
            pdfdocument.Info.Keywords = "PDFsharp, XGraphics";

            // Add a page for all staffIDs stored in the staff name/ID dictionary. key=staffID, value=staffName
            foreach (string value in staffNameDictionary.Values)
            {
                AddPage(pdfdocument, value);
            }

            //Save document
            pdfdocument.Save(filename);
            //Start a viewer
            Process.Start(filename);
        }
    }
}
