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
        int primaryKeySelected;

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
                string searchString = txtSearch.Text;
                lstBoxDummy.Items.Clear();
                foreach (string employee in lstBoxEmployees.Items)
                {
                    //lstBoxDummy.Visible = true;
                    if (employee.ToLower().Contains(searchString))
                    {
                        if (!lstBoxDummy.Items.Contains(employee))
                        {
                            lstBoxDummy.Items.Add(employee);
                        }
                    }
                }
            }
            SortDummyBox();
        }

        private void CopyBaseListBoxToDummyBox()
        {
            lstBoxDummy.Items.Clear();
            foreach (string employee in lstBoxEmployees.Items)
            {
                lstBoxDummy.Items.Add(employee);
            }
        }

        private void SortDummyBox()
        {
            if (staffNameDictionary == null) { Console.WriteLine("SortDummyBox somehow got accidentally called."); return; }
            string[] quicksortArray = staffNameDictionary.Keys.ToArray();

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
            foreach (string key in quicksortArray)
            {
                //MessageBox.Show(staffNameDictionary[key]);
                lstBoxDummy.Items.Add(staffNameDictionary[key]);
            }

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

            

            //List<string> bubbleSortList = new List<string>();
            //bool sorted = false;

            //if (lstBoxDummy.Items.Count > 0)
            //{
            //    foreach (string employee in lstBoxDummy.Items)
            //    {
            //        bubbleSortList.Add(employee);
            //    }
            //}
            //else
            //{
            //    foreach (string employee in lstBoxEmployees.Items)
            //    {
            //        bubbleSortList.Add(employee);
            //    }
            //}


            //if (comboBoxSort.SelectedIndex == 0)
            //{
            //    while (!sorted)
            //    {
            //        sorted = true;
            //        for (int item = 0; item<bubbleSortList.Count-1; item++)
            //        {
            //            string pair1 = bubbleSortList[item];
            //            string pair2 = bubbleSortList[item + 1];
            //            if ((int)pair1[0] > (int)pair2[0])
            //            {
            //                bubbleSortList[item] = pair2;
            //                bubbleSortList[item + 1] = pair1;
            //                sorted = false;
            //            }
            //        }
            //    }
            //}
            //else if (comboBoxSort.SelectedIndex == 1)
            //{
            //    while (!sorted)
            //    {
            //        sorted = true;
            //        for (int item = 0; item<bubbleSortList.Count-1; item++)
            //        {
            //            string pair1 = bubbleSortList[item];
            //            string pair2 = bubbleSortList[item + 1];
            //            if ((int)pair1[0] < (int)pair2[0])
            //            {
            //                bubbleSortList[item] = pair2;
            //                bubbleSortList[item + 1] = pair1;
            //                sorted = false;
            //            }
            //        }
            //    }
            //}

            //lstBoxDummy.Items.Clear();
            //foreach (string employee in bubbleSortList)
            //{
            //    lstBoxDummy.Items.Add(employee);
            //}

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
    }
}
