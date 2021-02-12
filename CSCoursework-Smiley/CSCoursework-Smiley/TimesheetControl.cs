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
using System.Text.RegularExpressions;
using System.Globalization;

namespace CSCoursework_Smiley
{
    public partial class TimesheetControl : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        DateTime currentWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        int timeSaveSection = 0;
        string clockHourChoice;
        string clockMinuteChoice;
        Tuple<int, int> cellLocation;
        List<string> fullStaffMemberList;
        List<string> staffMembersInDataGridList;
        int staffIDToSave;
        bool changeToRotaTableMade = false;

        private Color backgroundColour;
        private Color highlightColour;

        public void setBackgroundHighlightColours(Color receivedBackgroundColour, Color receivedHighlightColour)
        {
            backgroundColour = receivedBackgroundColour;
            highlightColour = receivedHighlightColour;
            UpdateDataGridViewColumnColours();
        }
        
        public TimesheetControl()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void weekDayTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TimesheetControl_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
            InitializeDataGridHeaderDate();
            rotaDataGrid.AutoGenerateColumns = false;
            GetTimesheetRotaData();
            SetUpEventHandlers();
            UpdateWeekLabel();
            InitializeStaffMemberList();
            UpdateControlEmployees();
            InitializeParentForms();
        }

        public void UpdateTimesheetControl()
        {
            GetTimesheetRotaData();
            InitializeStaffMemberList();
            UpdateControlEmployees();
        }
        private void UpdateControlEmployees()
        {
            List<Tuple<int, List<bool>>> staffMembersInDataGridListHolidayTuple = new List<Tuple<int, List<bool>>>();
            List<Tuple<int, List<bool>>> staffMembersInDataGridListAbsenceTuple = new List<Tuple<int, List<bool>>>();

            for (int row = 0; row < rotaDataGrid.Rows.Count; row++)
            {
                List<bool> absenceList = new List<bool>();
                List<bool> holidayList = new List<bool>();

                int rowToAdd = row;
                for (int column = 3; column<20; column+=4)
                {
                    if (rotaDataGrid.Rows[row].Cells[column].Value?.ToString() == "Absent")
                    {
                        absenceList.Add(true);
                    }
                    else
                    {
                        absenceList.Add(false);
                    }

                    if (rotaDataGrid.Rows[row].Cells[column].Value?.ToString() == "Holiday")
                    {
                        holidayList.Add(true);
                        //MessageBox.Show($"true added to holiday list, column={column}");
                    }
                    else
                    {
                        holidayList.Add(false);
                        //MessageBox.Show($"false added to holiday list, column={column}");
                    }
                }

                staffMembersInDataGridListAbsenceTuple.Add(new Tuple<int, List<bool>>(rowToAdd, absenceList));
                staffMembersInDataGridListHolidayTuple.Add(new Tuple<int, List<bool>>(rowToAdd, holidayList));
            }

            timesheetHolidayDataControl1.employeeCombobox = staffMembersInDataGridListHolidayTuple;
            timesheetAbsenceDataControl1.employeeCombobox = staffMembersInDataGridListAbsenceTuple;
            timesheetHolidayDataControl1.SetComboBoxMembers(staffMembersInDataGridList);
            timesheetAbsenceDataControl1.SetComboBoxMembers(staffMembersInDataGridList);
            timesheetHolidayDataControl1.UpdateDatagrid();
            timesheetAbsenceDataControl1.UpdateDatagrid();
            
        }

        private void InitializeParentForms()
        {
            timesheetHolidayDataControl1.parentForm = this;
            timesheetAbsenceDataControl1.parentForm = this;
        }

        public void UpdateHolidayData(int rowToChange, int dayToChange, bool checkedValue)
        {
            switch (dayToChange)
            {
                case 1:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[3].Value = "Holiday";
                        rotaDataGrid.Rows[rowToChange].Cells[4].Value = "Holiday";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[3].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[4].Value = "";
                    }
                    break;
                case 2:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[7].Value = "Holiday";
                        rotaDataGrid.Rows[rowToChange].Cells[8].Value = "Holiday";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[7].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[8].Value = "";
                    }
                    break;
                case 3:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[11].Value = "Holiday";
                        rotaDataGrid.Rows[rowToChange].Cells[12].Value = "Holiday";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[11].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[12].Value = "";
                    }
                    break;
                case 4:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[15].Value = "Holiday";
                        rotaDataGrid.Rows[rowToChange].Cells[16].Value = "Holiday";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[15].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[16].Value = "";
                    }
                    break;
                case 5:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[19].Value = "Holiday";
                        rotaDataGrid.Rows[rowToChange].Cells[20].Value = "Holiday";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[19].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[20].Value = "";
                    }
                    break;
            }

            UpdateControlEmployees();
        }
        public void UpdateAbsenceDataGrid(int rowToChange, int dayToChange, bool checkedValue)
        {
            switch (dayToChange)
            {
                case 1:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[3].Value = "Absent";
                        rotaDataGrid.Rows[rowToChange].Cells[4].Value = "Absent";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[3].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[4].Value = "";
                    }
                    break;
                case 2:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[7].Value = "Absent";
                        rotaDataGrid.Rows[rowToChange].Cells[8].Value = "Absent";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[7].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[8].Value = "";
                    }
                    break;
                case 3:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[11].Value = "Absent";
                        rotaDataGrid.Rows[rowToChange].Cells[12].Value = "Absent";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[11].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[12].Value = "";
                    }
                    break;
                case 4:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[15].Value = "Absent";
                        rotaDataGrid.Rows[rowToChange].Cells[16].Value = "Absent";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[15].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[16].Value = "";
                    }
                    break;
                case 5:
                    if (checkedValue)
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[19].Value = "Absent";
                        rotaDataGrid.Rows[rowToChange].Cells[20].Value = "Absent";
                    }
                    else
                    {
                        rotaDataGrid.Rows[rowToChange].Cells[19].Value = "";
                        rotaDataGrid.Rows[rowToChange].Cells[20].Value = "";
                    }
                    break;
            }

            UpdateControlEmployees();
        }
        public void UpdateAbsenceDatabaseInformation(Day dayOfWeek, string textToSave, int employeeSelected)
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet RotaIDDS;
            DataSet AbsenceNoteInfoDS;
            OleDbDataAdapter da;
            string sql;

            string staffMemberToFind = staffMembersInDataGridList[employeeSelected];
            int staffID = 0;
            int rotaID;

            for (int staffIDIterator = 0; staffIDIterator < fullStaffMemberList.Count; staffIDIterator++)
            {
                string firstname = fullStaffMemberList[staffIDIterator].Split(',')[0];
                char surname = fullStaffMemberList[staffIDIterator].Split(',')[1][0];
                string fullNameToCheck = $"{firstname}. {surname}";
                if (staffMemberToFind == fullNameToCheck) { staffID = staffIDIterator+1; }
                //MessageBox.Show($"firstname = {firstname}, surname = {surname}, staffMemberToFind={staffMemberToFind}, fullNameToCheck = {fullNameToCheck}, identical={staffMemberToFind==fullNameToCheck}");
            }

            // Get the rota id for this day/employee | day/employee combos will always be unique since we can just check from current week
            DateTime prevDay = currentWeek.AddDays(-1);
            DateTime nextDay = currentWeek.AddDays(1);
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");

            sql = $"SELECT rota_id FROM tblRota where day_id={Convert.ToInt32(dayOfWeek + 1)} AND staff_id={staffID} AND rota_week >= #{prevDay.ToString("d", USCulture)}# AND rota_week <= #{nextDay.ToString("d", USCulture)}# ORDER BY tblRota.rota_id ASC";
            da = new OleDbDataAdapter(sql, con);
            RotaIDDS = new DataSet();
            da.Fill(RotaIDDS, "RotaIDInfo");

            rotaID = RotaIDDS.Tables["RotaIDInfo"].Rows[0].Field<int>("rota_id");
            //MessageBox.Show(rotaID.ToString());

            // Get absence info row if exists
            sql = $"SELECT * FROM tblAbsence where rota_id={rotaID}";
            da = new OleDbDataAdapter(sql, con);
            AbsenceNoteInfoDS = new DataSet();
            da.Fill(AbsenceNoteInfoDS, "AbsenceNoteInfo");

            if (AbsenceNoteInfoDS.Tables["AbsenceNoteInfo"].Rows.Count > 0)
            {
                DataTable AbsenceNoteInfoTable = AbsenceNoteInfoDS.Tables["NoteInfo"];

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = AbsenceNoteInfoTable.Columns["staff_id"];
                AbsenceNoteInfoTable.PrimaryKey = keyColumns;

                // This line of code is needed for the update builder to be autogenerated so the da.Update line works
                _ = new OleDbCommandBuilder(da);

                DataRow row = AbsenceNoteInfoTable.Rows.Find(rotaID);
                row["absence_notes"] = textToSave;
                da.Update(AbsenceNoteInfoDS, "AbsenceNoteInfo");

                return;
            }
            else
            {
                AbsenceNoteInfoDS.Clear();
                DataSet FullAbsenceDS;

                sql = "Select * FROM tblAbsence";
                da = new OleDbDataAdapter(sql, con);
                FullAbsenceDS = new DataSet();
                da.Fill(FullAbsenceDS, "AbsenceInfo");

                DataTable FullAbsenceTable = FullAbsenceDS.Tables["AbsenceInfo"];
                
                int absenceID = FullAbsenceDS.Tables["AbsenceInfo"].Rows.Count+1;
                string absenceType = "absence"; //Future proofing
                string absenceDate = currentWeek.AddDays(Convert.ToInt32(dayOfWeek)).ToShortDateString();

                DataRow newRotaRow = FullAbsenceTable.NewRow();

                newRotaRow["absence_id"] = absenceID;
                newRotaRow["rota_id"] = rotaID;
                newRotaRow["absence_type"] = absenceType;
                newRotaRow["absence_date"] = absenceDate;
                newRotaRow["absence_notes"] = textToSave;

                _ = new OleDbCommandBuilder(da);

                FullAbsenceTable.Rows.Add(newRotaRow);
                da.Update(FullAbsenceDS, "AbsenceInfo");
            }

            // Close database connection
            con.Close();
        }
        
        private void InitializeStaffMemberList()
        {
            fullStaffMemberList = new List<string>();

            //Open database connection
            con.Open();

            //Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = "SELECT tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblStaff ORDER BY tblStaff.staff_firstname, tblStaff.staff_surname ASC";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            //Close database connection
            con.Close();

            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = StaffInfoTable.Columns["staff_id"];
            StaffInfoTable.PrimaryKey = keyColumns;

            foreach (DataRow row in StaffInfoTable.Rows)
            {
                fullStaffMemberList.Add($"{row.Field<string>("staff_firstname")},{row.Field<string>("staff_surname")}");
            }
        }
        private void UpdateWeekLabel()
        {
            lblCurrentWeek.Text = $"Current Week - {currentWeek.ToString("D")}";
        }
        private void SetUpEventHandlers()
        {
            this.rotaDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rotaDataGrid_CellContentClick);
            this.rotaDataGrid.CellValueChanged += new DataGridViewCellEventHandler(this.rotaDataGrid_CellValueChanged);
        }
        private void rotaDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            changeToRotaTableMade = true;
        }

        private void rotaDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            timeSaveSection = 0;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                cellLocation = new Tuple<int, int>(e.RowIndex, e.ColumnIndex);
                Rectangle cellRectangle = rotaDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point clockLocation = new Point(cellRectangle.Right, cellRectangle.Bottom);
                Point btnLocation = new Point(cellRectangle.Right, cellRectangle.Bottom + 148);

                if (clockHourSelectControl1.Location == clockLocation && clockHourSelectControl1.Visible == true)
                {
                    clockHourSelectControl1.Visible = false;
                    clockMinuteSelectControl1.Visible = false;
                    btnSaveClockSelection.Visible = false;
                }
                else
                {
                    btnSaveClockSelection.Location = btnLocation;
                    clockHourSelectControl1.Location = clockLocation;
                    clockMinuteSelectControl1.Location = clockLocation;
                    btnSaveClockSelection.Visible = true;
                    clockHourSelectControl1.Visible = true;
                    clockMinuteSelectControl1.Location = clockLocation;
                }
            }
        }
        private void UpdateDataGridViewColumnColours()
        {
            int[] backgroundColumnsToFill = { 3, 4, 7, 8, 11, 12, 15, 16, 19, 20 };

            foreach (int column in backgroundColumnsToFill)
            {
                rotaDataGrid.Columns[column].DefaultCellStyle.BackColor = backgroundColour;
                rotaDataGrid.Columns[column].HeaderCell.Style.BackColor = backgroundColour;
            }
        }

        private void InitializeDataGridHeaderDate()
        {
            rotaHeaderDataGrid.Columns[0].HeaderText = currentWeek.ToString("d");
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
        private void GetTimesheetRotaData()
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            DateTime prevDay = currentWeek.AddDays(-1);
            DateTime nextDay = currentWeek.AddDays(1);
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            //sql = $"SELECT tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.timesheet_start_time, tlbRota.timesheet_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id WHERE tblRota.rota_week >= #{prevDay.ToString("d", USCulture)}# AND tblRota.rota_week <= #{nextDay.ToString("d", USCulture)}# ORDER BY tblRota.rota_id ASC";
            sql = $"SELECT tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.timesheet_start_time, tblRota.timesheet_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id WHERE tblRota.rota_week >= #{prevDay.ToString("d", USCulture)}# AND tblRota.rota_week <= #{nextDay.ToString("d", USCulture)}# ORDER BY tblRota.rota_id ASC";
            da = new OleDbDataAdapter(sql, con);
            RotaInfoDS = new DataSet();
            da.Fill(RotaInfoDS, "RotaInfo");

            // Close database connection
            con.Close();

            DataTable RotaInfoTable = RotaInfoDS.Tables["RotaInfo"];
            //MessageBox.Show(RotaInfoTable.Rows.Count.ToString());

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = RotaInfoTable.Columns["rota_id"];
            RotaInfoTable.PrimaryKey = keyColumns;

            // Clear the rows
            this.rotaDataGrid.Rows.Clear();

            // Identify number of unique rows to be displayed
            int uniqueStaffMembers = RotaInfoTable.Rows.Count / 5; // since 5 rows are created per rota added.
            //MessageBox.Show($"uniqueStaffMembers = {uniqueStaffMembers}");
            Dictionary<int, int> uniqueStaffIDDict = new Dictionary<int, int>();
            uniqueStaffIDDict.Add(0, 0);

            foreach (DataRow row in RotaInfoTable.Rows)
            {
                //MessageBox.Show($"row staff ID = {row.Field<int>("staff_id")}");
            }

            staffMembersInDataGridList = new List<string>();

            if (uniqueStaffMembers > 0)
            {
                for (int staffMemberCount = 1; staffMemberCount <= uniqueStaffMembers; staffMemberCount++)
                {
                    int currentID = 0;
                    string[] staffRotaRow = new string[21];
                    foreach (DataRow row in RotaInfoTable.Rows)
                    {
                        int rowStaffID = row.Field<int>("staff_id"); // set rowStaffID to the current rows staff id
                        if (!uniqueStaffIDDict.ContainsKey(rowStaffID)) // if the dictionary does not contain this staff id
                        {
                            uniqueStaffIDDict.Add(rowStaffID, 1); // add this staff id to the dictionary
                            currentID = rowStaffID; // set the currentID to this id, this current id will last for 1 loop cycle
                            //MessageBox.Show($"Added {rowStaffID} to the dict.");
                        }
                        else if (uniqueStaffIDDict.ContainsKey(rowStaffID) && uniqueStaffIDDict[rowStaffID] >= 5) // if the dictionary does contain this staff id and it has been seen at least 5 times
                        {
                            continue; // pass over this row
                        }
                        else // if the dictionary does contain this staff id and it has not been seen at least 5 times
                        {
                            uniqueStaffIDDict[currentID]++; // increment the amount of times this staff id has been seen
                        }

                        if (rowStaffID == currentID)
                        {
                            //MessageBox.Show($"staffRotaRow[0] = {staffRotaRow[0]}, rowstaffID = {rowStaffID}, currentID = {currentID}");
                            int day = row.Field<int>("day_id");
                            string staffMember = $"{row.Field<string>("staff_firstname")}. {row.Field<string>("staff_surname")[0]}";
                            staffRotaRow[0] = staffMember;
                            string rotaStartTime = row.Field<string>("rota_start_time");
                            string rotaEndTime = row.Field<string>("rota_end_time");
                            string timesheetStartTime = row.Field<string>("timesheet_start_time");
                            string timesheetEndTime = row.Field<string>("timesheet_end_time");
                            switch (day)
                            {
                                case 1:
                                    staffRotaRow[1] = rotaStartTime;
                                    staffRotaRow[2] = rotaEndTime;
                                    staffRotaRow[3] = timesheetStartTime;
                                    staffRotaRow[4] = timesheetEndTime;
                                    break;
                                case 2:
                                    staffRotaRow[5] = rotaStartTime;
                                    staffRotaRow[6] = rotaEndTime;
                                    staffRotaRow[7] = timesheetStartTime;
                                    staffRotaRow[8] = timesheetEndTime;
                                    break;
                                case 3:
                                    staffRotaRow[9] = rotaStartTime;
                                    staffRotaRow[10] = rotaEndTime;
                                    staffRotaRow[11] = timesheetStartTime;
                                    staffRotaRow[12] = timesheetEndTime;
                                    break;
                                case 4:
                                    staffRotaRow[13] = rotaStartTime;
                                    staffRotaRow[14] = rotaEndTime;
                                    staffRotaRow[15] = timesheetStartTime;
                                    staffRotaRow[16] = timesheetEndTime;
                                    break;
                                case 5:
                                    staffRotaRow[17] = rotaStartTime;
                                    staffRotaRow[18] = rotaEndTime;
                                    staffRotaRow[19] = timesheetStartTime;
                                    staffRotaRow[20] = timesheetEndTime;
                                    break;
                            }
                        }

                        if (uniqueStaffIDDict[currentID] == 5)
                        {
                            //MessageBox.Show($"currentID = {currentID}, breaking");
                            break;
                        }
                    }

                    staffMembersInDataGridList.Add(staffRotaRow[0]);
                    //MessageBox.Show($"Adding Row for {staffRotaRow[0]}");
                    this.rotaDataGrid.Rows.Add(staffRotaRow[0], staffRotaRow[1], staffRotaRow[2], staffRotaRow[3], staffRotaRow[4], staffRotaRow[5], staffRotaRow[6], staffRotaRow[7], staffRotaRow[8], staffRotaRow[9], staffRotaRow[10], staffRotaRow[11], staffRotaRow[12], staffRotaRow[13], staffRotaRow[14], staffRotaRow[15], staffRotaRow[16], staffRotaRow[17], staffRotaRow[18], staffRotaRow[19], staffRotaRow[20]);
                }
            }
        }

        private void checkBoxClockInput_CheckedChanged(object sender, EventArgs e)
        {
            SaveRotaToDatabase();
            int[] columnsToChange = { 3, 4, 7, 8, 11, 12, 15, 16, 19, 20 };
            if (checkBoxClockInput.Checked)
            {
                foreach (int column in columnsToChange)
                {
                    this.rotaDataGrid.Columns.RemoveAt(column);
                    this.rotaDataGrid.Columns.Insert(column, new DataGridViewButtonColumn());
                    this.rotaDataGrid.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                GetTimesheetRotaData();
            }
            else
            {
                foreach (int column in columnsToChange)
                {
                    this.rotaDataGrid.Columns.RemoveAt(column);
                    this.rotaDataGrid.Columns.Insert(column, new DataGridViewTextBoxColumn());
                    this.rotaDataGrid.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                GetTimesheetRotaData();
            }
            NameColumnHeaders();
            UpdateDataGridViewColumnColours();
        }
        private void NameColumnHeaders()
        {
            rotaDataGrid.Columns[0].HeaderText = "Staff Name";
            for (int column = 1; column <= 20; column++)
            {
                if (column % 2 == 0)
                {
                    rotaDataGrid.Columns[column].HeaderText = "Out";
                }
                else
                {
                    rotaDataGrid.Columns[column].HeaderText = "In";
                }
            }
        }
        private void UpdateClockCell()
        {
            rotaDataGrid.Rows[cellLocation.Item1].Cells[cellLocation.Item2].Value = $"{clockHourChoice}:{clockMinuteChoice}";
        }
        private void SaveRotaToDatabase()
        {
            if (!changeToRotaTableMade) // if no change has been made then do not save
            {
                return;
            }

            //Open database connection
            con.Open();

            //Initialize variables
            DataSet DynamicRotaInfoDS;
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = $"SELECT tblRota.rota_id, tblRota.day_id, tblRota.rota_week, tblRota.timesheet_start_time, tblRota.timesheet_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id";
            da = new OleDbDataAdapter(sql, con);
            DynamicRotaInfoDS = new DataSet();
            da.Fill(DynamicRotaInfoDS, "DynamicRotaInfo");

            //Create second dataset to update (SQL cannot form dynamic insert commands on joined datasets)
            sql = $"SELECT * FROM tblRota ORDER BY rota_id ASC";
            da = new OleDbDataAdapter(sql, con);
            RotaInfoDS = new DataSet();
            da.Fill(RotaInfoDS, "RotaInfo");

            //Close database connection
            con.Close();

            DataTable DynamicRotaInfoTable = DynamicRotaInfoDS.Tables["DynamicRotaInfo"];

            DataColumn[] dynamicKeyColumns = new DataColumn[1];
            dynamicKeyColumns[0] = DynamicRotaInfoTable.Columns["rota_id"];
            DynamicRotaInfoTable.PrimaryKey = dynamicKeyColumns;

            //Set up RotaInfoTable
            DataTable RotaInfoTable = RotaInfoDS.Tables["RotaInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = RotaInfoTable.Columns["rota_id"];
            RotaInfoTable.PrimaryKey = keyColumns;

            //This line of code is needed for the update builder to be autogenerated so the da.Update line works
            _ = new OleDbCommandBuilder(da);

            for (int staffMemberCount = 0; staffMemberCount < rotaDataGrid.Rows.Count; staffMemberCount++)
            {
                //Variable to check if this staff member already has a row for this week
                bool staffMemberHasRow = false;

                //Check the staffID of the member in the timesheet
                int staffID;
                string firstNameToCheck = rotaDataGrid.Rows[staffMemberCount].Cells[0].Value.ToString().Split('.')[0];
                char secondNameToCheck = rotaDataGrid.Rows[staffMemberCount].Cells[0].Value.ToString().Split('.')[1][1];
                for (int i = 0; i < fullStaffMemberList.Count; i++)
                {
                    if (firstNameToCheck == fullStaffMemberList[i].Split(',')[0] && secondNameToCheck == fullStaffMemberList[i].Split(',')[1][0])
                    {
                        staffID = i + 1;
                        staffIDToSave = staffID;
                        //MessageBox.Show($"staffID = {staffID}, for Kai. C expect 2");
                    }
                }

                //Add validation here
                List<string> staffRotaRow = new List<string>();
                int pointer = 0;
                bool cell1holiday;
                bool cell1absent;
                DateTime cell1time = DateTime.Now; // must assign value or visual studio freaks out, this is always reassigned
                DateTime cell2time = DateTime.Now; // must assign value or visual studio freaks out, this is always reassigned
                string textToWriteToDatabase;
                while (staffRotaRow.Count < 10)
                {
                    // Reset holiday and absent pair validation
                    cell1holiday = false;
                    cell1absent = false;

                    // Increment pointer by 2 to get to the next cell pair.
                    pointer += 2;

                    string cell1 = rotaDataGrid.Rows[staffMemberCount].Cells[++pointer].Value?.ToString();
                    // Format Check
                    if (cell1 == "Holiday") { cell1holiday = true; }
                    if (cell1 == "Absent") { cell1absent = true; }
                    if (cell1 != null && cell1 != "" && cell1 != "Holiday" && cell1 != "Absent")
                    {
                        if (Regex.IsMatch(cell1, @"[0-2][0-9]\:[0-6][0-9]"))
                        {
                            textToWriteToDatabase = cell1;
                            staffRotaRow.Add(textToWriteToDatabase);
                            cell1time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                        }
                        else if (Regex.IsMatch(cell1, @"[0-9]\:[0-6][0-9]"))
                        {
                            textToWriteToDatabase = $"0{cell1}";
                            staffRotaRow.Add(textToWriteToDatabase);
                            rotaDataGrid.Rows[staffMemberCount].Cells[pointer].Value = $"0{cell1}";
                            cell1time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                        }
                        else
                        {
                            MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Cell: {pointer}. Must in the format hh:mm");
                            return;
                        }
                    }
                    else
                    {
                        staffRotaRow.Add(cell1);
                    }

                    string cell2 = rotaDataGrid.Rows[staffMemberCount].Cells[++pointer].Value?.ToString();
                    //Format Check

                    if (cell1holiday) { if (cell2 != "Holiday") { MessageBox.Show($"Invalid input in row {staffMemberCount + 1}, Col: {pointer + 1}. Holidays must always come in pairs."); } }
                    if (cell1absent) { if (cell2 != "Absent") { MessageBox.Show($"Invalid input in row {staffMemberCount + 1}, Col: {pointer + 1}. Absences must always come in pairs."); } }

                    if (cell2 != null && cell2 != "" && cell2 != "Holiday" && cell2 != "Absent")
                    {
                        if (Regex.IsMatch(cell2, @"[0-2][0-9]\:[0-6][0-9]"))
                        {
                            textToWriteToDatabase = cell2;
                            staffRotaRow.Add(textToWriteToDatabase);
                            cell2time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                            if (cell1time > cell2time) { MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Col: {pointer + 1}. The second item of an in-out pair cannot exceed the first item."); return; }
                        }
                        else if (Regex.IsMatch(cell2, @"[0-9]\:[0-6][0-9]"))
                        {
                            textToWriteToDatabase = $"0{cell2}";
                            staffRotaRow.Add(textToWriteToDatabase);
                            rotaDataGrid.Rows[staffMemberCount].Cells[pointer].Value = $"0{cell2}";
                            cell2time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                            if (cell1time > cell2time) { MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Col: {pointer + 1}. The second item of an in-out pair cannot exceed the first item."); return; }
                        }
                        else
                        {
                            MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Col: {pointer + 1}. Must in the format hh:mm");
                            return;
                        }
                    }
                    else
                    {
                        staffRotaRow.Add(cell2);
                    }
                }

                //Update existing database entries
                foreach (DataRow dynamicRow in DynamicRotaInfoTable.Rows)
                {
                    if (dynamicRow.Field<int>("staff_id") == staffIDToSave)
                    {
                        if (dynamicRow.Field<DateTime>("rota_week").ToString("d") == currentWeek.ToString("d"))
                        {
                            staffMemberHasRow = true;
                            int day = dynamicRow.Field<int>("day_id");
                            DataRow row = RotaInfoTable.Rows.Find(dynamicRow.Field<int>("rota_id"));
                            switch (day)
                            {
                                case 1:
                                    row["timesheet_start_time"] = staffRotaRow[0];
                                    row["timesheet_end_time"] = staffRotaRow[1];
                                    break;
                                case 2:
                                    row["timesheet_start_time"] = staffRotaRow[2];
                                    row["timesheet_end_time"] = staffRotaRow[3];
                                    break;
                                case 3:
                                    row["timesheet_start_time"] = staffRotaRow[4];
                                    row["timesheet_end_time"] = staffRotaRow[5];
                                    break;
                                case 4:
                                    row["timesheet_start_time"] = staffRotaRow[6];
                                    row["timesheet_end_time"] = staffRotaRow[7];
                                    break;
                                case 5:
                                    row["timesheet_start_time"] = staffRotaRow[8];
                                    row["timesheet_end_time"] = staffRotaRow[9];
                                    break;
                            }

                            try
                            {
                                da.Update(RotaInfoDS, "RotaInfo");
                                //MessageBox.Show("Rota Updated.");
                            }
                            catch
                            {
                                MessageBox.Show("There was a problem updating the rota.");
                            }
                        }
                    }
                }

                if (!staffMemberHasRow)
                {
                    //Initialise rotaID as the latest rota_id added.
                    int rotaToStart = RotaInfoTable.Rows[RotaInfoTable.Rows.Count - 1].Field<int>("rota_id");
                    int rotaID = rotaToStart;

                    DataRow newRotaRow;
                    int exportID = 1;
                    int branchID = 1;
                    string rotaWeek = currentWeek.ToString("d");

                    for (int dayID = 1; dayID <= 5; dayID++)
                    {
                        rotaID++;
                        newRotaRow = RotaInfoTable.NewRow();
                        newRotaRow["rota_id"] = rotaID;
                        newRotaRow["day_id"] = dayID;
                        newRotaRow["staff_id"] = staffIDToSave;
                        newRotaRow["export_id"] = exportID;
                        newRotaRow["branch_id"] = branchID;
                        newRotaRow["rota_week"] = rotaWeek;
                        newRotaRow["rota_start_time"] = staffRotaRow[2 * dayID - 2];
                        newRotaRow["rota_end_time"] = staffRotaRow[2 * dayID - 1];

                        RotaInfoTable.Rows.Add(newRotaRow);
                        da.Update(RotaInfoDS, "RotaInfo");
                    }
                }
            }
        }

        private void btnSaveRota_Click(object sender, EventArgs e)
        {
            SaveRotaToDatabase();
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            currentWeek = currentWeek.AddDays(-7);
            GetTimesheetRotaData();
            UpdateWeekLabel();
            UpdateControlEmployees();
        }

        private void btnNextWeek_Click_1(object sender, EventArgs e)
        {
            currentWeek = currentWeek.AddDays(7);
            GetTimesheetRotaData();
            UpdateWeekLabel();
            UpdateControlEmployees();
        }

        private void btnSaveClockSelection_Click(object sender, EventArgs e)
        {
            if (timeSaveSection == 0)
            {
                clockHourSelectControl1.checkButtons();
                clockHourChoice = clockHourSelectControl1.clockHoursSelected;
                clockHourSelectControl1.Visible = false;
                clockMinuteSelectControl1.Visible = true;
                timeSaveSection = 1;
            }
            else if (timeSaveSection == 1)
            {
                clockMinuteChoice = clockMinuteSelectControl1.clockMinuteSelected;
                clockHourSelectControl1.Visible = false;
                clockMinuteSelectControl1.Visible = false;
                btnSaveClockSelection.Visible = false;
                timeSaveSection = 0;
                UpdateClockCell();
            }
        }

        private void rotaHeaderDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInputHolidayData_Click(object sender, EventArgs e)
        {
            if (timesheetAbsenceDataControl1.Visible) 
            {
                timesheetAbsenceDataControl1.Visible = false;
                timesheetAbsenceDataControl1.ClearDataGrid();
                timesheetAbsenceDataControl1.UpdateDatagrid();
            }
            timesheetHolidayDataControl1.Visible = !timesheetHolidayDataControl1.Visible;
            timesheetHolidayDataControl1.ClearDataGrid();
            timesheetHolidayDataControl1.UpdateDatagrid();
        }

        private void btnInputAbsenceData_Click(object sender, EventArgs e)
        {
            if (timesheetHolidayDataControl1.Visible) 
            { 
                timesheetHolidayDataControl1.Visible = false;
                timesheetHolidayDataControl1.ClearDataGrid();
                timesheetHolidayDataControl1.UpdateDatagrid();
            }
            timesheetAbsenceDataControl1.Visible = !timesheetAbsenceDataControl1.Visible;
            timesheetAbsenceDataControl1.ClearDataGrid();
            timesheetAbsenceDataControl1.UpdateDatagrid();
        }
    }

    public static class DateTimeExtension
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
