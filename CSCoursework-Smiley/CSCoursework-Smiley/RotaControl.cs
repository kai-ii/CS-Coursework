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



namespace CSCoursework_Smiley
{
    public partial class RotaControl : UserControl
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

        private void UpdateWeekLabel()
        {
            lblCurrentWeek.Text = $"Current Week - {currentWeek.ToString("D")}";
        }
        public RotaControl()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void weekDayTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RotaControl_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
            InitializeDataGridHeaderDate();
            rotaDataGrid.AutoGenerateColumns = false;
            GetRotaData();
            SetUpEventHandlers();
            UpdateWeekLabel();
        }

        private void SetUpEventHandlers()
        {
            this.rotaDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rotaDataGrid_CellContentClick);
        }
        private void UpdateDataGridViewColumnColours()
        {
            int[] backgroundColumnsToFill = { 1, 2, 5, 6, 9, 10, 13, 14, 17, 18 };

            foreach (int column in backgroundColumnsToFill)
            {
                rotaDataGrid.Columns[column].DefaultCellStyle.BackColor = backgroundColour;
            }

            rotaDataGrid.Columns[0].DefaultCellStyle.BackColor = highlightColour;
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

        private void GetRotaData()
        {
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = $"SELECT tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id";
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
                string[] staffRotaRow = new string[11];
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
                            switch (day)
                            {
                                case 1:
                                    staffRotaRow[1] = rotaStartTime;
                                    staffRotaRow[2] = rotaEndTime;
                                    break;
                                case 2:
                                    staffRotaRow[3] = rotaStartTime;
                                    staffRotaRow[4] = rotaEndTime;
                                    break;
                                case 3:
                                    staffRotaRow[5] = rotaStartTime;
                                    staffRotaRow[6] = rotaEndTime;
                                    break;
                                case 4:
                                    staffRotaRow[7] = rotaStartTime;
                                    staffRotaRow[8] = rotaEndTime;
                                    break;
                                case 5:
                                    staffRotaRow[9] = rotaStartTime;
                                    staffRotaRow[10] = rotaEndTime;
                                    break;
                            }
                        }
                    }
                }
                this.rotaDataGrid.Rows.Add(staffRotaRow[0], staffRotaRow[1], staffRotaRow[2], "", "", staffRotaRow[3], staffRotaRow[4], "", "", staffRotaRow[5], staffRotaRow[6], "", "", staffRotaRow[7], staffRotaRow[8], "", "", staffRotaRow[9], staffRotaRow[10], "", "");
            }
        }

        private void checkBoxClockInput_CheckedChanged(object sender, EventArgs e)
        {
            int[] columnsToChange = { 1, 2, 5, 6, 9, 10, 13, 14, 17, 18 };
            if (checkBoxClockInput.Checked)
            {
                foreach (int column in columnsToChange)
                {
                    this.rotaDataGrid.Columns.RemoveAt(column);
                    this.rotaDataGrid.Columns.Insert(column, new DataGridViewButtonColumn());
                    this.rotaDataGrid.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                GetRotaData();
            }
            else
            {
                foreach (int column in columnsToChange)
                {
                    this.rotaDataGrid.Columns.RemoveAt(column);
                    this.rotaDataGrid.Columns.Insert(column, new DataGridViewTextBoxColumn());
                    this.rotaDataGrid.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                GetRotaData();
            }
            NameColumnHeaders();
            UpdateDataGridViewColumnColours();
        }

        private void NameColumnHeaders()
        {
            rotaDataGrid.Columns[0].HeaderText = "Staff Name";
            for (int column = 1; column<=20; column++)
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

        private void UpdateClockCell()
        {
            rotaDataGrid.Rows[cellLocation.Item1].Cells[cellLocation.Item2].Value = $"{clockHourChoice}:{clockMinuteChoice}";
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            currentWeek = currentWeek.AddDays(-7);
            GetRotaData();
            UpdateWeekLabel();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            currentWeek = currentWeek.AddDays(7);
            GetRotaData();
            UpdateWeekLabel();
        }

        private void btnSaveRota_Click(object sender, EventArgs e)
        {
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet DynamicRotaInfoDS;
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = $"SELECT tblRota.rota_id, tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id";
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
                    staffRotaRow.Add(rotaDataGrid.Rows[staffMemberCount-1].Cells[++pointer].Value?.ToString());
                    staffRotaRow.Add(rotaDataGrid.Rows[staffMemberCount-1].Cells[++pointer].Value?.ToString());
                    pointer+=2;
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
                                    row["rota_start_time"] = staffRotaRow[0];
                                    row["rota_end_time"] = staffRotaRow[1];
                                    break;
                                case 2:
                                    row["rota_start_time"] = staffRotaRow[2];
                                    row["rota_end_time"] = staffRotaRow[3];
                                    break;
                                case 3:
                                    row["rota_start_time"] = staffRotaRow[4];
                                    row["rota_end_time"] = staffRotaRow[5];
                                    break;
                                case 4:
                                    row["rota_start_time"] = staffRotaRow[6];
                                    row["rota_end_time"] = staffRotaRow[7];
                                    break;
                                case 5:
                                    row["rota_start_time"] = staffRotaRow[8];
                                    row["rota_end_time"] = staffRotaRow[9];
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

                    for (int dayID = 1; dayID<=5; dayID++)
                    {
                        rotaID++;
                        newRotaRow = RotaInfoTable.NewRow();
                        newRotaRow["rota_id"] = rotaID;
                        newRotaRow["day_id"] = dayID;
                        newRotaRow["staff_id"] = staffID;
                        newRotaRow["export_id"] = exportID;
                        newRotaRow["branch_id"] = branchID;
                        newRotaRow["rota_week"] = rotaWeek;
                        newRotaRow["rota_start_time"] = staffRotaRow[2*dayID-2];
                        newRotaRow["rota_end_time"] = staffRotaRow[2*dayID-1];

                        RotaInfoTable.Rows.Add(newRotaRow);
                        da.Update(RotaInfoDS, "RotaInfo");
                    }
                }
            }
        }

        private void btnClearRota_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to clear this rota?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Operation Cancelled");
                return;
            }
            //Open database connection
            con.Open();

            //Initialize variables
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            sql = $"SELECT * FROM tblRota WHERE MONTH(rota_week) = {currentWeek.Month} AND DAY(rota_week) = {currentWeek.Day} AND YEAR(rota_week) = {currentWeek.Year}";
            da = new OleDbDataAdapter(sql, con);
            RotaInfoDS = new DataSet();
            da.Fill(RotaInfoDS, "RotaInfo");

            //Close database connection
            con.Close();

            //Set up RotaInfoTable
            DataTable RotaInfoTable = RotaInfoDS.Tables["RotaInfo"];

            //This line of code is needed for the update builder to be autogenerated
            _ = new OleDbCommandBuilder(da);

            foreach (DataRow row in RotaInfoTable.Rows)
            {
                row.Delete();
            }

            try
            {
                da.Update(RotaInfoDS, "RotaInfo");
                GetRotaData();
            }
            catch
            {
                MessageBox.Show("Could not delete rota.");
            }

        }

        private void btnPrintRota_Click(object sender, EventArgs e)
        {

        }
    }
}
