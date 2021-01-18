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
        }
        private void UpdateWeekLabel()
        {
            lblCurrentWeek.Text = $"Current Week - {currentWeek.ToString("D")}";
        }
        private void SetUpEventHandlers()
        {
            this.rotaDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rotaDataGrid_CellContentClick);
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
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = $"SELECT tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.timesheet_start_time, tblRota.timesheet_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id";
            da = new OleDbDataAdapter(sql, con);
            RotaInfoDS = new DataSet();
            da.Fill(RotaInfoDS, "RotaInfo");

            //Close database connection
            con.Close();

            DataTable RotaInfoTable = RotaInfoDS.Tables["RotaInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = RotaInfoTable.Columns["rota_id"];
            RotaInfoTable.PrimaryKey = keyColumns;

            foreach (DataColumn column in RotaInfoTable.Columns)
            {
                //MessageBox.Show(column.ColumnName);
            }

            //Clear the rows
            this.rotaDataGrid.Rows.Clear();

            for (int staffMemberCount = 1; staffMemberCount <= 2; staffMemberCount++)
            {
                string[] staffRotaRow = new string[21];
                foreach (DataRow row in RotaInfoTable.Rows)
                {
                    if (row.Field<int>("staff_id") == staffMemberCount)
                    {
                        if (row.Field<DateTime>("rota_week").ToString("d") == currentWeek.ToString("d"))
                        {
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
                    }
                }
                this.rotaDataGrid.Rows.Add(staffRotaRow[0], staffRotaRow[1], staffRotaRow[2], staffRotaRow[3], staffRotaRow[4], staffRotaRow[5], staffRotaRow[6], staffRotaRow[7], staffRotaRow[8], staffRotaRow[9], staffRotaRow[10], staffRotaRow[11], staffRotaRow[12], staffRotaRow[13], staffRotaRow[14], staffRotaRow[15], staffRotaRow[16], staffRotaRow[17], staffRotaRow[18], staffRotaRow[19], staffRotaRow[20]);
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

            for (int staffMemberCount = 1; staffMemberCount <= 2; staffMemberCount++)
            {
                //Variable to check if this staff member already has a row for this week
                bool staffMemberHasRow = false;

                //Add validation here
                List<string> staffRotaRow = new List<string>();
                int pointer = 0;
                while (staffRotaRow.Count < 10)
                {
                    //Increment pointer by 2 to get to the next cell pair.
                    pointer += 2;

                    string cell1 = rotaDataGrid.Rows[staffMemberCount - 1].Cells[++pointer].Value?.ToString();
                    //Format Check
                    if (cell1 != null && cell1 != "")
                    {
                        if (Regex.IsMatch(cell1, @"[0-2][0-9]\:[0-6][0-9]"))
                        {
                            staffRotaRow.Add(cell1);
                        }
                        else if (Regex.IsMatch(cell1, @"[0-9]\:[0-6][0-9]"))
                        {
                            staffRotaRow.Add($"0{cell1}");
                            rotaDataGrid.Rows[staffMemberCount - 1].Cells[pointer].Value = $"0{cell1}";
                        }
                        else
                        {
                            MessageBox.Show($"Invalid input in Row: {staffMemberCount}, Cell: {pointer}. Must in the format hh:mm");
                            return;
                        }
                    }
                    else
                    {
                        staffRotaRow.Add(cell1);
                    }

                    string cell2 = rotaDataGrid.Rows[staffMemberCount - 1].Cells[++pointer].Value?.ToString();
                    //Format Check
                    if (cell2 != null && cell2 != "")
                    {
                        if (Regex.IsMatch(cell2, @"[0-2][0-9]\:[0-6][0-9]"))
                        {
                            staffRotaRow.Add(cell2);
                        }
                        else if (Regex.IsMatch(cell2, @"[0-9]\:[0-6][0-9]"))
                        {
                            staffRotaRow.Add($"0{cell2}");
                            rotaDataGrid.Rows[staffMemberCount - 1].Cells[pointer].Value = $"0{cell2}";
                        }
                        else
                        {
                            MessageBox.Show($"Invalid input in Row: {staffMemberCount}, Col: {pointer + 1}. Must in the format hh:mm");
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
                    if (dynamicRow.Field<int>("staff_id") == staffMemberCount)
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
                    int staffID = staffMemberCount;
                    int exportID = 1;
                    int branchID = 1;
                    string rotaWeek = currentWeek.ToString("d");

                    for (int dayID = 1; dayID <= 5; dayID++)
                    {
                        rotaID++;
                        newRotaRow = RotaInfoTable.NewRow();
                        newRotaRow["rota_id"] = rotaID;
                        newRotaRow["day_id"] = dayID;
                        newRotaRow["staff_id"] = staffID;
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
        }

        private void btnNextWeek_Click_1(object sender, EventArgs e)
        {
            currentWeek = currentWeek.AddDays(7);
            GetTimesheetRotaData();
            UpdateWeekLabel();
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
