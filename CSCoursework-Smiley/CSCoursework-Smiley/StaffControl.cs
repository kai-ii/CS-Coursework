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
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        Dictionary<string, string> staffNameDictionary;
        Dictionary<string, string> staffUsernameDictionary;
        int primaryKeySelected;
        bool displayPersonalData = false;
        string username;

        public StaffControl()
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
            // Initialize the form by settings up the textboxes, comboboxes and listboxes in the form.
            InitializeParentChildRelationships();
            InitializeSearchTextbox();
            InitializeStaffMembers();
            lstBoxEmployees.Visible = false;
            lstBoxDummy.Visible = true;
            comboBoxSort.SelectedIndex = 0;
            CopyBaseListBoxToDummyBox();
            SortDummyBox();
            rBtnDetails.Checked = true;
        }
        private void StaffControl_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database.
        }
        private void InitializeParentChildRelationships()
        {
            // Set this form to be the parent form of staffControlDetails1, this will allow that instance of it to access this forms public functions. This is used to allow the editting of the details displayed.
            staffControlDetails1.SetParentForm(this);
            staffControlNotes1.SetParentForm(this);
            staffControlDetails1.SetCon(con);
        }
        public void UpdateAddressInfo(string[] addressInfo)
        {
            // This uses a manual update command since I know it must be an update as the records already exist. It is slightly more efficient than a command builder as it has less overhead.
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblStaff] SET [staff_street]='{addressInfo[1]}', [staff_city]='{addressInfo[2]}', [staff_county]='{addressInfo[3]}', [staff_postcode]='{addressInfo[4]}' WHERE [staff_id]={Convert.ToInt32(addressInfo[0])};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //----------Exception handling----------
                // This error would be due to an apostrophe in the inputs, which would break the string formatting. 
                MessageBox.Show($"There was an error saving to database. Exception: {ex}. Try removing any apostrophes.");
            }
        }

        public void UpdateEmploymentDetails(string[] employmentDetails)
        {
            // This uses a manual update command since I know it must be an update as the records already exist. It is slightly more efficient than a command builder as it has less overhead.
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblStaff] SET [jobposition_id]={Convert.ToInt32(employmentDetails[1])}, [staff_contract_type]='{employmentDetails[2]}', [staff_salaried_hours]={Convert.ToInt32(employmentDetails[3])} WHERE [staff_id]={Convert.ToInt32(employmentDetails[0])};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //----------Exception handling----------
                // This error would be due to an apostrophe in the inputs, which would break the string formatting. 
                MessageBox.Show($"There was an error saving to database. Exception: {ex}. Try removing any apostrophes.");
            }
        }
        public void UpdateContactInfoDetails(string[] contactInfoDetails)
        {
            // This uses a manual update command since I know it must be an update as the records already exist. It is slightly more efficient than a command builder as it has less overhead.
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblStaff] SET [staff_email_address]='{contactInfoDetails[1]}', [staff_mobile_number]='{contactInfoDetails[2]}', [staff_home_number]='{contactInfoDetails[3]}' WHERE [staff_id]={Convert.ToInt32(contactInfoDetails[0])};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //----------Exception handling----------
                // This error would be due to an apostrophe in the inputs, which would break the string formatting. 
                MessageBox.Show($"There was an error saving to database. Exception: {ex}. Try removing any apostrophes.");
            }
        }
        public void UpdateEmploymentInfoDetails(string[] employmentInfoDetails)
        {
            // This uses a manual update command since I know it must be an update as the records already exist. It is slightly more efficient than a command builder as it has less overhead.
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblStaff] SET [staff_DoB]='{employmentInfoDetails[1]}', [staff_gender]='{employmentInfoDetails[2]}', [staff_employed]={Convert.ToBoolean(employmentInfoDetails[3])} WHERE [staff_id]={Convert.ToInt32(employmentInfoDetails[0])};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //----------Exception handling----------
                // This error would be due to an apostrophe in the inputs, which would break the string formatting. 
                MessageBox.Show($"There was an error saving to database. Exception: {ex}. Try removing any apostrophes.");
            }
        }
        public void UpdatePaymentDetails(string[] paymentDetails)
        {
            // This uses a manual update command since I know it must be an update as the records already exist. It is slightly more efficient than a command builder as it has less overhead.
            try
            {
                var updateCommand = new OleDbCommand();
                string sql = $"UPDATE [tblStaff] SET [staff_NI_number]='{paymentDetails[1]}', [staff_NI_letter]='{paymentDetails[2]}', [staff_tax_code]='{paymentDetails[3]}', [staff_works_number]='{paymentDetails[4]}' WHERE [staff_id]={Convert.ToInt32(paymentDetails[0])};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //----------Exception handling----------
                // This error would be due to an apostrophe in the inputs, which would break the string formatting. 
                MessageBox.Show($"There was an error saving to database. Exception: {ex}. Try removing any apostrophes.");
            }
        }
        public void UpdateStaffControl()
        {
            // When a stafff member is added, this is called to reset the list box, ensuring that is displays the added staff member as well.
            lstBoxEmployees.Items.Clear();
            lstBoxDummy.Items.Clear();
            InitializeStaffMembers();
            CopyBaseListBoxToDummyBox();
            SortDummyBox();
        }
        private void InitializeSearchTextbox()
        {
            // Set up the events for entering and leaving the search textbox to give it the "search" tag when not entering it for user intuition.
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.Text = "search";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            // When the user enters the search textbox and the text is currently search set it to nothing to allow the user to search.
            if (txtSearch.Text == "search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            // When the user leaves the textbox empty, return the text to being search.
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "search";
                txtSearch.ForeColor = SystemColors.GrayText;
                //lstBoxDummy.Visible = false;
                CopyBaseListBoxToDummyBox();
                SortDummyBox();
            }
        }
        private void InitializeStaffMembers()
        {
            // Initialize Staff List
            staffNameDictionary = new Dictionary<string, string>();
            staffUsernameDictionary = new Dictionary<string, string>();

            // Open database connection
            con.Open();

            // Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Initialize staff info dataset with all staff members.
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            // For each employee add the names to the full employee list box.
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

            // Initialize staff datatable.
            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            // Setup primary key.
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = StaffInfoTable.Columns["staff_id"];
            StaffInfoTable.PrimaryKey = keyColumns;

            // Update the staff
            DataRow row = StaffInfoDS.Tables["StaffInfo"].Rows.Find(primaryKey);
            staffControlDetails1.SetStaffDetails(row);
        }

        private void UpdateNoteDetails(int primaryKey)
        {
            // Updates the general notes for the staff notes control with the selected staffID (thats what primary key represents) and set up the absence tuple list which is used for the calendar absence section. Finally refresh the calendar with the new details (absence pairs).
            UpdateGeneralNotesDetails(primaryKey);
            UpdateAbsenceTupleList(primaryKey);
            staffControlNotes1.RefreshMonthCalendar();
        }

        private void UpdateAbsenceTupleList(int primaryKey)
        {
            // Open database connection.
            con.Open();

            // Initialize database variables.
            DataSet AbsenceInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Initialize variables.
            List<Tuple<DateTime, string>> absenceTupleList = new List<Tuple<DateTime, string>>();

            // Join tblRota and tblAbsence on rota_id where staff_id is the selected user.
            sql = $"SELECT tblAbsence.absence_date, tblAbsence.absence_notes FROM tblAbsence INNER JOIN tblRota ON tblAbsence.rota_id=tblRota.rota_id WHERE tblRota.staff_id={primaryKey}";
            da = new OleDbDataAdapter(sql, con);
            AbsenceInfoDS = new DataSet();
            da.Fill(AbsenceInfoDS, "AbsenceInfo");

            // Close database connection.
            con.Close();

            // Initialize absence datatable.
            DataTable AbsenceInfoTable = AbsenceInfoDS.Tables["AbsenceInfo"];

            // Initailize primary key.
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = AbsenceInfoTable.Columns["rota_id"];
            AbsenceInfoTable.PrimaryKey = keyColumns;

            // Foreach row, add the absence date and corresponding notes to the absencetuplelist to be sent to the staff notes control.
            for (int row = 0; row < AbsenceInfoTable.Rows.Count; row++)
            {
                DateTime rowDate = AbsenceInfoTable.Rows[row].Field<DateTime>("absence_date");
                string rowString = AbsenceInfoTable.Rows[row].Field<string>("absence_notes");
                Tuple<DateTime, string> rowTuple = new Tuple<DateTime, string>(rowDate, rowString);
                absenceTupleList.Add(rowTuple);
            }

            staffControlNotes1.SetAbsenceTupleList(absenceTupleList);
        }

        private void UpdateGeneralNotesDetails(int primaryKey)
        {
            // Updates general notes of the staff notes control.
            staffControlNotes1.SetGeneralNotes(GetStaffGeneralNotes(primaryKey));
        }

        private void UpdateGraphDetails(int primaryKey)
        {
            // Updates the staff graph control with line chart and pie chart values.
            UpdateLineChartDetails(primaryKey);
            UpdatePieChartDetails(primaryKey);
        }
        private double[] GetHoursWorkedByTaxMonth(int staffID)
        {
            // Initialize variables.
            double[] hoursWorkedByTaxMonth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //index 0 = april
            Dictionary<int, DateTime> exportIDTaxMonthDictionary = new Dictionary<int, DateTime>(); // key: exportID, value: taxMonthStartDate;
            int exportID;
            DateTime taxMonthStartDate;

            // Open database connection.
            con.Open();

            // Initialize database variables.
            DataSet ExportInfoDS;
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get export taxmonthdate combos.
            sql = $"SELECT export_id, tax_month_start_date FROM tblExport";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");

            // Close database connection.
            con.Close();

            // Initialize export datatable
            DataTable ExportTable = ExportInfoDS.Tables["ExportInfo"];

            // Foreach row, add the exportid taxmonth combo to the corresponding dictionary for use later on.
            foreach (DataRow row in ExportTable.Rows)
            {
                exportID = row.Field<int>("export_id");
                taxMonthStartDate = row.Field<DateTime>("tax_month_start_date");
                exportIDTaxMonthDictionary.Add(exportID, taxMonthStartDate);
            }

            // Open Database connection.
            con.Open();

            // Get payslip data to find hours worked.
            sql = $"SELECT export_id, standard_hours_worked FROM tblPayslip WHERE staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");

            // Close Database connection.
            con.Close();

            // Initialize payslip datatable.
            DataTable PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];

            // Foreach row in the payslip table, get the month for the rows exportID and add them to the corresponding index in the hoursWOrkedByTaxMonth array.
            foreach (DataRow row in PayslipInfoTable.Rows)
            {
                int index = exportIDTaxMonthDictionary[row.Field<int>("export_id")].AddMonths(-4).Month; //e.g. if the export_id is 11, the month given would be 04 which is april, this is 0 in the hoursWorkedByTaxMonth array defined in StaffControlGraph so 4 is subtracted here.
                double indexValue = hoursWorkedByTaxMonth[index];
                indexValue += row.Field<double>("standard_hours_worked");
                hoursWorkedByTaxMonth[index] = Math.Round(indexValue, 2);
            }

            // Return the completed hours worked array.
            return hoursWorkedByTaxMonth;
        }
        private void UpdateLineChartDetails(int primaryKey)
        {
            // Initialize variables.
            double[] hoursWorkedByTaxMonth = GetHoursWorkedByTaxMonth(primaryKey);

            // Update the staff graph control with the received values.
            staffControlGraphs1.SetLineChartValues(hoursWorkedByTaxMonth);
        }
        private Tuple<double, double> GetHoursWorked(int staffID) 
        {
            /*Returns tuple of <standard hours worked, holiday hours taken>*/

            // Open database connection
            con.Open();

            // Initialize database variables
            DataSet PayslipInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Initialize variables.
            Tuple<double, double> hoursWorkedTuple;
            double standardHoursWorked = 0;
            double holidayHoursTaken = 0;

            // Get payslip data to find hours worked
            sql = $"SELECT standard_hours_worked, holiday_hours_taken FROM tblPayslip WHERE staff_id={staffID}";
            da = new OleDbDataAdapter(sql, con);
            PayslipInfoDS = new DataSet();
            da.Fill(PayslipInfoDS, "PayslipInfo");

            //Close database connection
            con.Close();

            // Initialize payslip datatable
            DataTable PayslipInfoTable = PayslipInfoDS.Tables["PayslipInfo"];
            
            // Foreach row in the payslip table for the given staffID parameter, add the staffhours worked
            foreach (DataRow row in PayslipInfoTable.Rows)
            {
                standardHoursWorked += row.Field<double>("standard_hours_worked");
                holidayHoursTaken += row.Field<double>("holiday_hours_taken");
            }

            // Create the tuple that will be returned and return it.
            hoursWorkedTuple = new Tuple<double, double>(standardHoursWorked, holidayHoursTaken);
            return hoursWorkedTuple;
        }
        private void UpdatePieChartDetails(int primaryKey)
        {
            // Initialize variables.
            Tuple<double, double> hoursWorkedTuple = GetHoursWorked(primaryKey);
            double hoursWorked = hoursWorkedTuple.Item1;
            double paidTimeOff = hoursWorkedTuple.Item2;

            // Set up piechart.
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

            // Update the pie chart with the values just set up.
            staffControlGraphs1.UpdatePieChart(pieChartValues);
        }

        private void lstBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the lstBoxUpdate function when its index it changed, this gets changed to match the value selected in the dummy listbox.
            lstBoxEmployeeUpdate();
        }

        private void lstBoxEmployeeUpdate()
        {
            // If the main list box is updated with respect to the dummy box changing then change the primary key to this listbox's index+1, coinciding with the staff members added to it (in this listbox they are sorted by staffID)
            int index = lstBoxEmployees.SelectedIndex + 1;

            // If the current staff member being displayed is different to the changed one then set the selected primary key (e.g. staffID) to the index of the parent list box and then get the respective details based on which radio button has been selected, if graphs has been selected bet the graphs into etc. 
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
            /*Search the list box dummy items for the search text, if there is no search text then just sort the items*/
            if (txtSearch.Text.Length == 0)
            {
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
                    // Calculate the midpoint.
                    int midpoint = (min + max) / 2;
                    if (sortedArray[midpoint].ToLower().Contains(searchItem.ToLower()))
                    {
                        // If the item is found then add it to the dummy list box and break out of the loop to prevent an infinite loop.
                        lstBoxDummy.Items.Add(sortedArray[midpoint]);
                        break;
                    }
                    else if (String.Compare(searchItem, sortedArray[midpoint]) > 0)
                    {
                        // If the item is greater then "remove" the bottom values of the array by changing the min index.
                        min = midpoint + 1;
                    }
                    else if (String.Compare(searchItem, sortedArray[midpoint]) < 0)
                    {
                        // If the item is greater then "remove" the top values of the array by changing the max index.
                        max = midpoint - 1;
                    }
                }
            }
            // Sort the dummy box to ensure that if there is no search value the textbox is still sorted.
            SortDummyBox();
        }

        private void CopyBaseListBoxToDummyBox()
        {
            // Reset the dummy box with all the staff members.
            lstBoxDummy.Items.Clear();
            if (displayPersonalData)
            {
                // Only add the staff member signed in if they only have personal permissions.
                lstBoxDummy.Items.Add(staffUsernameDictionary[username]);
            }
            else
            {
                // Otherwise show all employees.
                foreach (string employee in lstBoxEmployees.Items)
                {
                    lstBoxDummy.Items.Add(employee);
                }
            }
        }

        private void SortDummyBox()
        {
            /*Quicksorts all of the items in the dummy list box using a standard quicksort algorithm with the pivot point at the end of the list*/
            if (staffNameDictionary == null) { Console.WriteLine("SortDummyBox somehow got accidentally called."); return; }
            // Assign quicksort array its values, only add the user signed in if they are viewing with personal staff permissions only.
            if (displayPersonalData)
            {
                lstBoxDummy.Items.Clear();
                lstBoxDummy.Items.Add(staffUsernameDictionary[username]);
                return;
            }
            string[] quicksortArray = lstBoxDummy.Items.OfType<string>().ToArray();

            // Debug console writelines.
            Console.Write("Unsorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            // Perform the quicksort on the quicksortarray.
            Quicksort(quicksortArray, 0, quicksortArray.Length - 1);
            Console.Write("Sorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            // Clear the items in the dummy list box.
            lstBoxDummy.Items.Clear();
            // Foreach sorted item in the quicksort array add it to the dummy list box.
            Array.ForEach<string>(quicksortArray, staffMember => lstBoxDummy.Items.Add(staffMember));

            void Quicksort(string[] arr, int start, int end)
            {
                // Get the pivot point and set it to i, quicksort the values between the start and pivot and the pivot and the end.
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
                // Initialize variables.
                string[] a = arr;
                string pivot = a[end];
                int i = start - 1;
                string tempLow;
                string tempHigh;

                for (int j = start; j < end; j++)
                {
                    // if sorting from A-Z.
                    if (comboBoxSort.SelectedIndex == 0)
                    {
                        // if this item is less than the pivot, swap its place with the temp low value this ensures that at the end the items less than the pivot are on the left.
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
                    // else if sorting from Z-A
                    else if (comboBoxSort.SelectedIndex == 1)
                    {
                        // if this item is greater than the pivot, swap its place with the temp high value this ensures that at the end the items greater than the pivot are on the left.
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

                // Debug console writes.
                Console.Write($"Pivot = {pivot}. Current Array: ");
                foreach (string item in a)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();

                // return the pivot point.
                return i + 1;
            }
        }

        private void lstBoxDummy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Presence check.
            if (lstBoxDummy.SelectedItem != null)
            {
                // Else match the employee selected with the main list box and set that staff member to the selected employee in the parent list box.
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
            // Bring the graphs control to the front and update its values.
            staffControlGraphs1.BringToFront();
            UpdateGraphDetails(primaryKeySelected);
        }

        private void rBtnNotes_CheckedChanged(object sender, EventArgs e)
        {
            // Bring the notes control to the front and update its values.
            staffControlNotes1.BringToFront();
            UpdateNoteDetails(primaryKeySelected);
        }

        private void rBtnDetails_CheckedChanged(object sender, EventArgs e)
        {
            // Bring the notes control to the front and update its values.
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

            // Initialize the notes datatable.
            DataTable NoteInfoTable = NoteInfoDS.Tables["NoteInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = NoteInfoTable.Columns["staff_id"];
            NoteInfoTable.PrimaryKey = keyColumns;

            DataRow row = NoteInfoTable.Rows.Find(primaryKey);

            // try to get the notes contents, if there is no row then this will cause a crash, so just return no note in this case.
            try
            {
                return Convert.ToString(row.Field<string>("note_contents"));
            }
            catch
            {
                //----------Exception handling----------
                // In the case of no row, just return a blank string.
                return "";
            }
            
        }

        private void staffControlNotes1_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database.
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

            //This line of code is needed for the command builder to be autogenerated so the da.Update line works
            _ = new OleDbCommandBuilder(da);

            // Update the database with the new notes.
            DataRow row = NoteInfoTable.Rows.Find(primaryKeySelected);
            row["note_contents"] = updateNotes;
            da.Update(NoteInfoDS, "NoteInfo");
        }
        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the sorting is changed from A-Z to Z-A or vice versa, then re-sort the dummy list box. This is handled within the SortDummyBox function.
            SortDummyBox();
        }

        public void displayPersonalStaffInfo(string Username)
        {
            // Assign personal details and variables. Notes aren't visable and you will only be able to see your own details and graphs.
            displayPersonalData = true;
            username = Username;
            SortDummyBox();
            lstBoxDummy.SelectedIndex = 0;
            staffControlDetails1.PersonalView();
            rBtnNotes.Visible = false;
        }

        public void displayAllStaffInfo()
        {
            // Let the user see all staff members and all details. Permissions to view all 3 of details, graphs, and notes.
            displayPersonalData = false;
            SortDummyBox();
            staffControlDetails1.AdminView();
            rBtnNotes.Visible = true;
        }
    }
}
