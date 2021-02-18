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
        Dictionary<string, string> staffNameDictionary;
        Dictionary<string, string> staffUsernameDictionary;
        int primaryKeySelected;
        bool displayPersonalData = false;
        string username;

        public StaffControl()
        {
            InitializeComponent();
        }

        private void StaffControl_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
            InitializeSearchTextbox();
            InitializeStaffMembers();
            lstBoxEmployees.Visible = false;
            lstBoxDummy.Visible = true;
            comboBoxSort.SelectedIndex = 0;
            CopyBaseListBoxToDummyBox();
            SortDummyBox();
            rBtnDetails.Checked = true;
            InitializeParentChildRelationships();
        }
        private void InitializeParentChildRelationships()
        {
            staffControlDetails1.parentForm = this;
        }
        public void UpdateAddressInfo(string[] addressInfo)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblStaff] SET [staff_street]='{addressInfo[1]}', [staff_city]='{addressInfo[2]}', [staff_county]='{addressInfo[3]}', [staff_postcode]='{addressInfo[4]}' WHERE [staff_id]={Convert.ToInt32(addressInfo[0])};";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateEmploymentDetails(string[] employmentDetails)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblStaff] SET [jobposition_id]={Convert.ToInt32(employmentDetails[1])}, [staff_contract_type]='{employmentDetails[2]}', [staff_salaried_hours]={Convert.ToInt32(employmentDetails[3])} WHERE [staff_id]={Convert.ToInt32(employmentDetails[0])};";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateContactInfoDetails(string[] contactInfoDetails)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblStaff] SET [staff_email_address]='{contactInfoDetails[1]}', [staff_mobile_number]='{contactInfoDetails[2]}', [staff_home_number]='{contactInfoDetails[3]}' WHERE [staff_id]={Convert.ToInt32(contactInfoDetails[0])};";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmploymentInfoDetails(string[] employmentInfoDetails)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblStaff] SET [staff_DoB]='{employmentInfoDetails[1]}', [staff_gender]='{employmentInfoDetails[2]}', [staff_employed]={Convert.ToBoolean(employmentInfoDetails[3])} WHERE [staff_id]={Convert.ToInt32(employmentInfoDetails[0])};";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatePaymentDetails(string[] paymentDetails)
        {
            var updateCommand = new OleDbCommand();
            string sql = $"UPDATE [tblStaff] SET [staff_NI_number]='{paymentDetails[1]}', [staff_NI_letter]='{paymentDetails[2]}', [staff_tax_code]='{paymentDetails[3]}', [staff_works_number]='{paymentDetails[4]}' WHERE [staff_id]={Convert.ToInt32(paymentDetails[0])};";
            updateCommand.CommandText = sql;
            updateCommand.Connection = con;
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateStaffControl()
        {
            lstBoxEmployees.Items.Clear();
            lstBoxDummy.Items.Clear();
            InitializeStaffMembers();
            CopyBaseListBoxToDummyBox();
            SortDummyBox();
        }
        private void InitializeSearchTextbox()
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
                //lstBoxDummy.Visible = false;
                CopyBaseListBoxToDummyBox();
                SortDummyBox();
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
                MessageBox.Show("Error establishing database connection StaffControl.");
            }
        }
        private void InitializeStaffMembers()
        {
            //Initialize Staff List
            staffNameDictionary = new Dictionary<string, string>();
            staffUsernameDictionary = new Dictionary<string, string>();

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
                staffNameDictionary.Add($"{staff_surname.Trim()}{staff_firstname.Trim()}", $"{staff_firstname}. {staff_surname[0]}");
                staffUsernameDictionary.Add($"{staff_firstname.ToLower().Trim()[0]}{staff_surname.ToLower().Trim()}", $"{staff_firstname}. {staff_surname[0]}");
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
            UpdateLineChartDetails(primaryKey);
            UpdatePieChartDetails(primaryKey);
        }
        private double[] GetHoursWorkedByTaxMonth(int staffID)
        {
            //int[] hoursWorkedByTaxMonth = new int[12]; 
            double[] hoursWorkedByTaxMonth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //index 0 = april
            Dictionary<int, DateTime> exportIDTaxMonthDictionary = new Dictionary<int, DateTime>(); // key: exportID, value: taxMonthStartDate;

            // Open database connection
            con.Open();

            // Initialize variables
            DataSet ExportInfoDS;
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get export taxmonthdate combos
            sql = $"SELECT export_id, tax_month_start_date FROM tblExport";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");

            //Close database connection
            con.Close();

            DataTable ExportTable = ExportInfoDS.Tables["ExportInfo"];
            int exportID;
            DateTime taxMonthStartDate;
            foreach (DataRow row in ExportTable.Rows)
            {
                exportID = row.Field<int>("export_id");
                taxMonthStartDate = row.Field<DateTime>("tax_month_start_date");
                exportIDTaxMonthDictionary.Add(exportID, taxMonthStartDate);
            }

            // Open Database connection
            con.Open();

            // Get payslip data to find hours worked
            sql = $"SELECT export_id, standard_hours_worked FROM tblPayslip WHERE staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");

            // Close Database connection
            con.Close();

            DataTable PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            foreach (DataRow row in PayslipInfoTable.Rows)
            {
                int index = exportIDTaxMonthDictionary[row.Field<int>("export_id")].AddMonths(-4).Month; //e.g. if the export_id is 11, the month given would be 04 which is april, this is 0 in the hoursWorkedByTaxMonth array defined in StaffControlGraph so 4 is subtracted here.
                double indexValue = hoursWorkedByTaxMonth[index];
                indexValue += row.Field<double>("standard_hours_worked");
                hoursWorkedByTaxMonth[index] = Math.Round(indexValue, 2);
            }

            return hoursWorkedByTaxMonth;
        }
        private void UpdateLineChartDetails(int primaryKey)
        {
            //Random rnd = new Random();

            //int[] hoursWorkedByMonth = new int[12];
            //for (int month = 0; month < 12; month++)
            //{
            //    hoursWorkedByMonth[month] = rnd.Next(140, 180);
            //}

            double[] hoursWorkedByTaxMonth = GetHoursWorkedByTaxMonth(primaryKey);

            //staffControlGraphs1.LineChartValues = hoursWorkedByMonth;
            staffControlGraphs1.SetLineChartValues(hoursWorkedByTaxMonth);
        }
        private Tuple<double, double> GetHoursWorked(int staffID) // Returns tuple of <standard hours worked, holiday hours taken>
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get payslip data to find hours worked
            sql = $"SELECT standard_hours_worked, holiday_hours_taken FROM tblPayslip WHERE staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");

            //Close database connection
            con.Close();

            DataTable PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];
            Tuple<double, double> hoursWorkedTuple;
            double standardHoursWorked = 0;
            double holidayHoursTaken = 0;

            foreach (DataRow row in PayslipInfoTable.Rows)
            {
                standardHoursWorked += row.Field<double>("standard_hours_worked");
                holidayHoursTaken += row.Field<double>("holiday_hours_taken");
            }

            hoursWorkedTuple = new Tuple<double, double>(standardHoursWorked, holidayHoursTaken);
            return hoursWorkedTuple;
        }
        private void UpdatePieChartDetails(int primaryKey)
        {
            //Random rnd = new Random();
            //int hoursWorked = rnd.Next(730, 810);
            //int paidTimeOff = rnd.Next(35, 70);
            Tuple<double, double> hoursWorkedTuple = GetHoursWorked(primaryKey);
            double hoursWorked = hoursWorkedTuple.Item1;
            double paidTimeOff = hoursWorkedTuple.Item2;

            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection pieChartValues = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Hours Worked",
                    Values = new ChartValues<double> {Math.Round(hoursWorked, 2)},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Paid Time Off",
                    Values = new ChartValues<double> {Math.Round(paidTimeOff, 2)},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            staffControlGraphs1.UpdatePieChart(pieChartValues);
        }

        private void lstBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoxEmployeeUpdate();
        }

        private void lstBoxEmployeeUpdate()
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
            if (txtSearch.Text.Length == 0)
            {
                //lstBoxDummy.Visible = false;
                CopyBaseListBoxToDummyBox();
            }
            else
            {
                // Binary search the sorted list
                CopyBaseListBoxToDummyBox();
                SortDummyBox();
                string[] sortedArray = lstBoxDummy.Items.OfType<string>().ToArray();
                lstBoxDummy.Items.Clear();
                string searchItem = txtSearch.Text;
                int min = 0;
                int max = sortedArray.Length - 1;
                
                while (min <= max)
                {
                    int midpoint = (min + max) / 2;
                    if (sortedArray[midpoint].ToLower().Contains(searchItem.ToLower()))
                    {
                        lstBoxDummy.Items.Add(sortedArray[midpoint]);
                        break;
                    }
                    else if (String.Compare(searchItem, sortedArray[midpoint]) > 0)
                    {
                        min = midpoint + 1;
                    }
                    else if (String.Compare(searchItem, sortedArray[midpoint]) < 0)
                    {
                        max = midpoint - 1;
                    }
                }
                //string searchString = txtSearch.Text;
                //lstBoxDummy.Items.Clear();
                //foreach (string employee in lstBoxEmployees.Items)
                //{
                //    //lstBoxDummy.Visible = true;
                //    if (employee.ToLower().Contains(searchString))
                //    {
                //        if (!lstBoxDummy.Items.Contains(employee))
                //        {
                //            lstBoxDummy.Items.Add(employee);
                //        }
                //    }
                //}
            }
            SortDummyBox();
        }

        private void CopyBaseListBoxToDummyBox()
        {
            lstBoxDummy.Items.Clear();
            if (displayPersonalData)
            {
                lstBoxDummy.Items.Add(staffUsernameDictionary[username]);
            }
            else
            {
                foreach (string employee in lstBoxEmployees.Items)
                {
                    lstBoxDummy.Items.Add(employee);
                }
            }
        }

        private void SortDummyBox()
        {
            if (staffNameDictionary == null) { Console.WriteLine("SortDummyBox somehow got accidentally called."); return; }
            if (displayPersonalData)
            {
                lstBoxDummy.Items.Clear();
                lstBoxDummy.Items.Add(staffUsernameDictionary[username]);
                return;
            }
            string[] quicksortArray = lstBoxDummy.Items.OfType<string>().ToArray();

            Console.Write("Unsorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            Quicksort(quicksortArray, 0, quicksortArray.Length - 1);
            Console.Write("Sorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            lstBoxDummy.Items.Clear();
            Array.ForEach<string>(quicksortArray, staffMember => lstBoxDummy.Items.Add(staffMember));

            void Quicksort(string[] arr, int start, int end)
            {
                int i;
                if (start < end)
                {
                    i = Partition(arr, start, end);

                    Quicksort(arr, start, i - 1);
                    Quicksort(arr, i + 1, end);
                }
            }
            int Partition(string[] arr, int start, int end)
            {
                string[] a = arr;
                string pivot = a[end];
                int i = start - 1;
                string tempLow;
                string tempHigh;

                for (int j = start; j < end; j++)
                {
                    if (comboBoxSort.SelectedIndex == 0)
                    {
                        if (String.Compare(a[j], pivot) < 0)
                        {
                            Console.WriteLine($"{a[j]} < {pivot}");
                            i++;
                            tempLow = a[i];
                            tempHigh = a[j];
                            a[j] = tempLow;
                            a[i] = tempHigh;
                        }
                    }
                    else if (comboBoxSort.SelectedIndex == 1)
                    {
                        if (String.Compare(a[j], pivot) > 0)
                        {
                            Console.WriteLine($"{a[j]} > {pivot}");
                            i++;
                            tempLow = a[i];
                            tempHigh = a[j];
                            a[j] = tempLow;
                            a[i] = tempHigh;
                        }
                    }
                }

                tempLow = a[i + 1];
                tempHigh = a[end];
                a[i + 1] = tempHigh;
                a[end] = tempLow;

                Console.Write($"Pivot = {pivot}. Current Array: ");
                foreach (string item in a)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();

                return i + 1;
            }
        }

        private void lstBoxDummy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Presence check
            if (lstBoxDummy.SelectedItem != null)
            {
                for (int employee = 0; employee < lstBoxEmployees.Items.Count; employee++)
                {
                    if (lstBoxDummy.SelectedItem.ToString() == lstBoxEmployees.Items[employee].ToString())
                    {
                        lstBoxEmployees.SelectedIndex = employee;
                        lstBoxEmployeeUpdate();
                    }
                }
            }
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
            try
            {
                return Convert.ToString(row.Field<string>("note_contents"));
            }
            catch
            {
                return "";
            }
            
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

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortDummyBox();
        }

        public void displayPersonalStaffInfo(string Username)
        {
            displayPersonalData = true;
            username = Username;
            SortDummyBox();
            lstBoxDummy.SelectedIndex = 0;
            staffControlDetails1.PersonalView();
            rBtnNotes.Visible = false;
        }

        public void displayAllStaffInfo()
        {
            displayPersonalData = false;
            SortDummyBox();
            staffControlDetails1.AdminView();
            rBtnNotes.Visible = true;
        }
    }
}
