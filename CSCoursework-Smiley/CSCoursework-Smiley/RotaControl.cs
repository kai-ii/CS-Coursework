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
using PdfSharp;
using PdfSharp.Pdf;
using MigraDoc;
using System.Diagnostics;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CSCoursework_Smiley
{
    public partial class RotaControl : UserControl
    {
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        DateTime currentWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        int timeSaveSection = 0;
        string clockHourChoice;
        string clockMinuteChoice;
        Tuple<int, int> cellLocation;
        List<string> staffMemberList;
        Dictionary<string, int> fullStaffMemberDict;
        bool changeToRotaTableMade = false;

        private System.Drawing.Color backgroundColour;
        private System.Drawing.Color highlightColour;

        public void setBackgroundHighlightColours(System.Drawing.Color receivedBackgroundColour, System.Drawing.Color receivedHighlightColour)
        {
            // Initialize the background colours dictated by the user database settings.
            backgroundColour = receivedBackgroundColour;
            highlightColour = receivedHighlightColour;
            UpdateDataGridViewColumnColours();
        }

        private void UpdateWeekLabel()
        {
            // update the current week label with the value in the current week.
            lblCurrentWeek.Text = $"Current Week - {currentWeek:D}";
        }
        public RotaControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        private void RotaControl_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database.
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
            // Initialize the datagrid headers as well as initialize the staff members
            InitializeDataGridHeaderDate();
            rotaDataGrid.AutoGenerateColumns = false;
            InitializeStaffMemberComboBox();
            GetRotaData();
            SetUpEventHandlers();
            UpdateWeekLabel();
        }
        public void UpdateRotaControl()
        {
            // Initialize the staff members in the first column of the rota table.
            InitializeStaffMemberComboBox();
        }

        private void InitializeStaffMemberComboBox()
        {
            staffMemberList = new List<string>();
            fullStaffMemberDict = new Dictionary<string, int>();

            // Open database connection.
            con.Open();

            // Initialize variables.
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Join tblRota and tblAbsence on rota_id where staff_id is the selected user.
            sql = "SELECT tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblStaff ORDER BY tblStaff.staff_firstname, tblStaff.staff_surname ASC";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            // Close database connection.
            con.Close();

            // Get staff datatable.
            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            // Initialize primary key.
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = StaffInfoTable.Columns["staff_id"];
            StaffInfoTable.PrimaryKey = keyColumns;

            // Foreach row add to the staff dictionary and staff member list to be used later on.
            foreach (DataRow row in StaffInfoTable.Rows)
            {
                fullStaffMemberDict.Add($"{row.Field<string>("staff_firstname")}{row.Field<string>("staff_surname")[0]}", row.Field<int>("staff_id"));
                staffMemberList.Add($"{row.Field<string>("staff_firstname")}. {row.Field<string>("staff_surname")[0]}");
            }

            // Update the staff members that can be selected in the first column of the rota.
            UpdateStaffMemberComboBox();
        }
        private void UpdateStaffMemberComboBox()
        {
            // Update the combo box column datasource to display to the user.
            DataGridViewComboBoxColumn staffMemberComboBox = (DataGridViewComboBoxColumn)rotaDataGrid.Columns[0];
            staffMemberComboBox.DataSource = staffMemberList;
        }

        private void SetUpEventHandlers()
        {
            // Setup event handlers of: cell content click and cell value changed.
            this.rotaDataGrid.CellContentClick += new DataGridViewCellEventHandler(this.rotaDataGrid_CellContentClick);
            this.rotaDataGrid.CellValueChanged += new DataGridViewCellEventHandler(this.rotaDataGrid_CellValueChanged);
        }

        private void rotaDataGrid_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            // Set the change to rota table made variable to true, this variable dictates whether or not the rota should be saved, if no change made then the save button will do nothing to increase efficiency.
            changeToRotaTableMade = true;
        }
        private void UpdateDataGridViewColumnColours()
        {
            // Sets the columns to change colour and then update the colour.
            int[] backgroundColumnsToFill = { 1, 2, 5, 6, 9, 10, 13, 14, 17, 18 };

            foreach (int column in backgroundColumnsToFill)
            {
                rotaDataGrid.Columns[column].DefaultCellStyle.BackColor = backgroundColour;
            }

            rotaDataGrid.Columns[0].DefaultCellStyle.BackColor = highlightColour;
        }

        private void InitializeDataGridHeaderDate()
        {
            // Set the date of the rota.
            rotaHeaderDataGrid.Columns[0].HeaderText = currentWeek.ToString("d");
        }
        private void GetRotaData()
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
            sql = $"SELECT tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id WHERE tblRota.rota_week >= #{prevDay.ToString("d", USCulture)}# AND tblRota.rota_week <= #{nextDay.ToString("d", USCulture)}# ORDER BY tblRota.rota_id ASC";
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

            
            if (uniqueStaffMembers > 0)
            {
                for (int staffMemberCount = 1; staffMemberCount <= uniqueStaffMembers; staffMemberCount++)
                {
                    int currentID = 0;
                    string[] staffRotaRow = new string[11];
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

                        if (uniqueStaffIDDict[currentID] == 5)
                        {
                            //MessageBox.Show($"currentID = {currentID}, breaking");
                            break;
                        }
                    }

                    //MessageBox.Show($"Adding Row for {staffRotaRow[0]}");
                    this.rotaDataGrid.Rows.Add(staffRotaRow[0], staffRotaRow[1], staffRotaRow[2], "", "", staffRotaRow[3], staffRotaRow[4], "", "", staffRotaRow[5], staffRotaRow[6], "", "", staffRotaRow[7], staffRotaRow[8], "", "", staffRotaRow[9], staffRotaRow[10], "", "");
                }
            }
        }
        private void GetPreviousWeekRotaData()
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet RotaInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            DateTime prevDay = currentWeek.AddDays(-7).AddDays(-1); // Get previous weeks rota instead of this weeks
            DateTime nextDay = currentWeek.AddDays(-7).AddDays(1); // Get previous weeks rota instead of this weeks
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id WHERE tblRota.rota_week >= #{prevDay.ToString("d", USCulture)}# AND tblRota.rota_week <= #{nextDay.ToString("d", USCulture)}# ORDER BY tblRota.rota_id ASC";
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


            if (uniqueStaffMembers > 0)
            {
                for (int staffMemberCount = 1; staffMemberCount <= uniqueStaffMembers; staffMemberCount++)
                {
                    int currentID = 0;
                    string[] staffRotaRow = new string[11];
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

                            switch (day)
                            {
                                // Write the rota info to the correct day.
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

                        if (uniqueStaffIDDict[currentID] == 5)
                        {
                            //MessageBox.Show($"currentID = {currentID}, breaking");
                            break;
                        }
                    }

                    //MessageBox.Show($"Adding Row for {staffRotaRow[0]}");
                    this.rotaDataGrid.Rows.Add(staffRotaRow[0], staffRotaRow[1], staffRotaRow[2], "", "", staffRotaRow[3], staffRotaRow[4], "", "", staffRotaRow[5], staffRotaRow[6], "", "", staffRotaRow[7], staffRotaRow[8], "", "", staffRotaRow[9], staffRotaRow[10], "", "");
                }
            }
        }

        private void checkBoxClockInput_CheckedChanged(object sender, EventArgs e)
        {
            // If the clock input button has been clicked then save the database and update the respective columns to button inputs. When these are clicked, the custom clock control opens.
            SaveRotaToDatabase();
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

            // Update the colours and update headers since these will reset when readding all of the columns.
            NameColumnHeaders();
            UpdateDataGridViewColumnColours();
        }
        private void NameColumnHeaders()
        {
            // Simple algorithm to get all even columns. label even to out and odd to in except the first column which is named 'Staff Name'.
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
            /*When a cell is clicked, if it is a button then find the location that the clock control should appear. Then display it.*/
            var senderGrid = (DataGridView)sender;
            timeSaveSection = 0;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                cellLocation = new Tuple<int, int>(e.RowIndex, e.ColumnIndex);
                Rectangle cellRectangle = rotaDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point clockLocation;
                Point btnLocation;
                // If cell >= 17 display the clock on the left of the button rather than on the right, else the clock isn't usable.
                if (e.ColumnIndex >= 17)
                {
                    clockLocation = new Point(cellRectangle.Left - 138, cellRectangle.Bottom);
                    btnLocation = new Point(cellRectangle.Left - 138, cellRectangle.Bottom + 148);
                }
                else
                {
                    clockLocation = new Point(cellRectangle.Right, cellRectangle.Bottom);
                    btnLocation = new Point(cellRectangle.Right, cellRectangle.Bottom + 148);
                }

                if (clockHourSelectControl1.Location == clockLocation && clockHourSelectControl1.Visible == true)
                {
                    // If the button is clicked again then stop showing the clock control.
                    clockHourSelectControl1.Visible = false;
                    clockMinuteSelectControl1.Visible = false;
                    btnSaveClockSelection.Visible = false;
                }
                else
                {
                    // Otherwise show the clock in the location set previously.
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
                // If the clock save is on stage 0, set the hour and then set it to stage 1. (stage 0 is hour select and stage 1 is minute select)
                clockHourSelectControl1.checkButtons();
                clockHourChoice = clockHourSelectControl1.GetClockHoursSelected();
                clockHourSelectControl1.Visible = false;
                clockMinuteSelectControl1.Visible = true;
                timeSaveSection = 1;
            }
            else if (timeSaveSection == 1)
            {
                // If the clock save is on stage `, set the minute and then reset the clock save stage back to 0. (stage 0 is hour select and stage 1 is minute select)
                clockMinuteChoice = clockMinuteSelectControl1.GetClockMinuteSelected();
                clockHourSelectControl1.Visible = false;
                clockMinuteSelectControl1.Visible = false;
                btnSaveClockSelection.Visible = false;
                timeSaveSection = 0;
                UpdateClockCell();
            }
        }

        private void UpdateClockCell()
        {
            // Update the cell that the clock control is being used for with the clock value.
            rotaDataGrid.Rows[cellLocation.Item1].Cells[cellLocation.Item2].Value = $"{clockHourChoice}:{clockMinuteChoice}";
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            // When clicking the previous week button add -7 days to the current week, this sets it to last week, now get the new rota data and update the week label.
            currentWeek = currentWeek.AddDays(-7);
            GetRotaData();
            UpdateWeekLabel();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            // When clicking the next week button add +7 days to the current week, this sets it to next week, now get the new rota data and update the week label.
            currentWeek = currentWeek.AddDays(7);
            GetRotaData();
            UpdateWeekLabel();
        }

        private void btnSaveRota_Click(object sender, EventArgs e)
        {
            // When the save rota button is clicked, call the save rota to database method which will save the current state of the datagridview to database.
            SaveRotaToDatabase();
        }

        private void GenerateNewExportRow()
        {
            // Initialize Variables.
            DataSet ExportInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get export_id for current week.
            sql = $"SELECT * FROM tblExport";
            da = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            da.Fill(ExportInfoDS, "ExportInfo");

            // Initialize export datatable.
            DataTable ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];

            // Create a new row.
            DataRow newRow = ExportInfoTable.NewRow();
            int previousRow = ExportInfoTable.Rows.Count - 1;
            newRow["export_id"] = ExportInfoTable.Rows[previousRow].Field<int>("export_id") + 1;
            newRow["tax_month_start_date"] = ExportInfoTable.Rows[previousRow].Field<DateTime>("tax_month_start_date").AddMonths(1);
            newRow["tax_month_end_date"] = ExportInfoTable.Rows[previousRow].Field<DateTime>("tax_month_end_date").AddMonths(1);
            newRow["pay_date"] = ExportInfoTable.Rows[previousRow].Field<DateTime>("pay_date").AddMonths(1);

            // Create a command builder for the data adapter da
            _ = new OleDbCommandBuilder(da);
            // Add the new row to the database using the data adapter to auto generate the insert sql query.
            ExportInfoTable.Rows.Add(newRow);
            da.Update(ExportInfoDS, "ExportInfo");
        }
        private void SaveRotaToDatabase()
        {
            if (!changeToRotaTableMade) // if no change has been made then do not save
            {
                return;
            }

            string validationRowValue;
            //Confirms each row has a staff member assigned to it
            //Check rows 0 to total-2, this is because the auto generated row will never have a name assigned to it.
            for (int row = 0; row <= rotaDataGrid.Rows.Count-2; row++)
            {
                validationRowValue = rotaDataGrid.Rows[row].Cells[0].Value?.ToString();
                //MessageBox.Show($"validationRowValue check1 = {validationRowValue}");
                if (validationRowValue == null)
                {
                    MessageBox.Show($"All rows must have an associated staff member. See row {row+1}.");
                    return;
                }
            }

            //Confirms no duplicates staff members
            List<string> staffMembersInRota = new List<string>();
            for (int row = 0; row <= rotaDataGrid.Rows.Count-2; row++)
            {
                //MessageBox.Show(row.Cells[0].Value.ToString());
                staffMembersInRota.Add(rotaDataGrid.Rows[row].Cells[0].Value.ToString());
            }

            for (int row = 0; row <= rotaDataGrid.Rows.Count-2; row++)
            {
                validationRowValue = rotaDataGrid.Rows[row].Cells[0].Value.ToString();
                staffMembersInRota.Remove(validationRowValue);
                if (staffMembersInRota.Contains(validationRowValue))
                {
                    MessageBox.Show($"Cannot save rota with multiple instances of {validationRowValue}");
                    return;
                }
            }

            //Open database connection
            con.Open();

            //Initialize variables
            DataSet DynamicRotaInfoDS;
            DataSet RotaInfoDS;
            DataSet ExportInfoDS;
            OleDbDataAdapter ExportDA;
            OleDbDataAdapter da;
            string sql;

            //Get export_id for current week
            CultureInfo USCulture = CultureInfo.CreateSpecificCulture("en-US");
            sql = $"SELECT export_id, tax_month_start_date, tax_month_end_date FROM tblExport WHERE #{currentWeek.ToString("d", USCulture)}#>=tax_month_start_date AND #{currentWeek.ToString("d", USCulture)}#<=tax_month_end_date";
            ExportDA = new OleDbDataAdapter(sql, con);
            ExportInfoDS = new DataSet();
            ExportDA.Fill(ExportInfoDS, "ExportInfo");

            // Set up ExportInfoTable
            DataTable ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];

            if (ExportInfoTable.Rows.Count == 0) // if export id for current tax month doesn't exist, create it.
            {
                GenerateNewExportRow();

                //Get export_id for current week
                sql = $"SELECT export_id, tax_month_start_date, tax_month_end_date FROM tblExport WHERE #{currentWeek.ToString("d", USCulture)}#>=tax_month_start_date AND #{currentWeek.ToString("d", USCulture)}#<=tax_month_end_date";
                ExportDA = new OleDbDataAdapter(sql, con);
                ExportInfoDS = new DataSet();
                ExportDA.Fill(ExportInfoDS, "ExportInfo");

                // Set up ExportInfoTable
                ExportInfoTable = ExportInfoDS.Tables["ExportInfo"];
            }

            //Join tblRota and tblAbsence on rota_id where staff_id is the selected user
            sql = $"SELECT tblRota.rota_id, tblRota.day_id, tblRota.rota_week, tblRota.rota_start_time, tblRota.rota_end_time, tblRota.branch_id, tblStaff.staff_firstname, tblStaff.staff_surname, tblStaff.staff_id FROM tblRota INNER JOIN tblStaff ON tblRota.staff_id=tblStaff.staff_id";
            da = new OleDbDataAdapter(sql, con);
            DynamicRotaInfoDS = new DataSet();
            da.Fill(DynamicRotaInfoDS, "DynamicRotaInfo");

            //Close database connection
            con.Close();

            //Set up DynamicRotaInfoTable
            DataTable DynamicRotaInfoTable = DynamicRotaInfoDS.Tables["DynamicRotaInfo"];

            DataColumn[] dynamicKeyColumns = new DataColumn[1];
            dynamicKeyColumns[0] = DynamicRotaInfoTable.Columns["rota_id"];
            DynamicRotaInfoTable.PrimaryKey = dynamicKeyColumns;

            //Create second dataset to update (SQL cannot form dynamic insert commands on joined datasets)
            sql = $"SELECT * FROM tblRota ORDER BY rota_id ASC";
            da = new OleDbDataAdapter(sql, con);
            RotaInfoDS = new DataSet();
            da.Fill(RotaInfoDS, "RotaInfo");

            //Set up RotaInfoTable
            DataTable RotaInfoTable = RotaInfoDS.Tables["RotaInfo"];

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = RotaInfoTable.Columns["rota_id"];
            RotaInfoTable.PrimaryKey = keyColumns;

            //This line of code is needed for the update builder to be autogenerated so the da.Update line works
            _ = new OleDbCommandBuilder(da);
            
            for (int staffMemberCount = 0; staffMemberCount < rotaDataGrid.Rows.Count - 1; staffMemberCount++)
            {
                //Variable to check if this staff member already has a row for this week
                bool staffMemberHasRow = false;

                //Check the staffID of the member in the rota
                int staffIDToSave;
                string firstNameToCheck = rotaDataGrid.Rows[staffMemberCount].Cells[0].Value.ToString().Split('.')[0];
                char secondNameToCheck = rotaDataGrid.Rows[staffMemberCount].Cells[0].Value.ToString().Split('.')[1][1];
                staffIDToSave = fullStaffMemberDict[$"{firstNameToCheck}{secondNameToCheck}"];
                //for (int i = 0; i < fullStaffMemberDict.Count; i++)
                //{
                //    if (firstNameToCheck == fullStaffMemberDict[i].Split(',')[0] && secondNameToCheck == fullStaffMemberDict[i].Split(',')[1][0])
                //    {
                //        staffID = i + 1;
                //        staffIDToSave = staffID;
                //        //MessageBox.Show($"staffID = {staffID}, for Kai. C expect 2");
                //    }
                //}

                //Format Validation
                List<string> staffRotaRow = new List<string>();
                int pointer = 0;
                DateTime cell1time = DateTime.Now; // must assign value or visual studio freaks out, this is always reassigned
                DateTime cell2time = DateTime.Now; // must assign value or visual studio freaks out, this is always reassigned
                string textToWriteToDatabase;
                while (staffRotaRow.Count < 10)
                {
                    string cell1 = rotaDataGrid.Rows[staffMemberCount].Cells[++pointer].Value?.ToString();
                    //Format Check
                    if (cell1 != null && cell1 != "")
                    {
                        // Time format check in the format '12:34'
                        if (Regex.IsMatch(cell1, @"[0-2][0-9]\:[0-6][0-9]"))
                        {
                            textToWriteToDatabase = cell1;
                            staffRotaRow.Add(textToWriteToDatabase);
                            cell1time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                        }
                        // Time format check in the format '1:23'
                        else if (Regex.IsMatch(cell1, @"[0-9]\:[0-6][0-9]"))
                        {
                            // Normalise '1:23' to '01:23'
                            textToWriteToDatabase = $"0{cell1}";
                            staffRotaRow.Add(textToWriteToDatabase);
                            rotaDataGrid.Rows[staffMemberCount].Cells[pointer].Value = $"0{cell1}";
                            cell1time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                        }
                        else
                        {
                            //----------Exception handling----------
                            // If the format is invalid, tell the user where the error is and tell them the correct format.
                            MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Cell: {pointer}. Must in the format hh:mm");
                            return;
                        }
                    }
                    else
                    {
                        staffRotaRow.Add(cell1); // Allows for incomplete rotas to be saved for convenience. (saving null/"" values)
                    }


                    string cell2 = rotaDataGrid.Rows[staffMemberCount].Cells[++pointer].Value?.ToString();
                    //Format Check
                    if (cell2 != null && cell2 != "")
                    {
                        // Time format check in the format '12:34'
                        if (Regex.IsMatch(cell2, @"[0-2][0-9]\:[0-6][0-9]"))
                        {
                            textToWriteToDatabase = cell2;
                            staffRotaRow.Add(textToWriteToDatabase);
                            cell2time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                            //----------Exception handling----------
                            // Validation to check if the first cell is greater than the second, this is impossible because the 'in' time should come before the 'out' time.
                            if (cell1time > cell2time) { MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Col: {pointer + 1}. The second item of an in-out pair cannot exceed the first item."); return; }
                        }
                        // Time format check in the format '1:23'
                        else if (Regex.IsMatch(cell2, @"[0-9]\:[0-6][0-9]"))
                        {
                            // Normalise '1:23' to '01:23'
                            textToWriteToDatabase = $"0{cell2}";
                            staffRotaRow.Add(textToWriteToDatabase);
                            rotaDataGrid.Rows[staffMemberCount].Cells[pointer].Value = $"0{cell2}";
                            cell2time = DateTime.ParseExact(textToWriteToDatabase, "H:mm", null, System.Globalization.DateTimeStyles.None);
                            //----------Exception handling----------
                            // Validation to check if the first cell is greater than the second, this is impossible because the 'in' time should come before the 'out' time.
                            if (cell1time > cell2time) { MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Col: {pointer + 1}. The second item of an in-out pair cannot exceed the first item."); return; }
                        }
                        else
                        {
                            //----------Exception handling----------
                            // If the format is invalid, tell the user where the error is and tell them the correct format.
                            MessageBox.Show($"Invalid input in Row: {staffMemberCount + 1}, Col: {pointer + 1}. Must in the format hh:mm");
                            return;
                        }
                    }
                    else
                    {
                        staffRotaRow.Add(cell2); // Allows for incomplete rotas to be saved for convenience. (saving null/"" values)
                    }

                    //Increment pointer by 2 to get to the next cell pair.
                    pointer += 2;
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
                                // Switch based on the day and save the rota in the correct day.
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

                            // Try catch to use
                            try
                            {
                                da.Update(RotaInfoDS, "RotaInfo");
                                MessageBox.Show("Rota Updated.");
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
                    // Initialise rotaID as the latest rota_id added.
                    int rotaToStart = RotaInfoTable.Rows[RotaInfoTable.Rows.Count - 1].Field<int>("rota_id");
                    int rotaID = rotaToStart;
                    bool generatedNewExportRow = false;

                    DataRow newRotaRow;
                    int exportID;
                    int branchID = 1;
                    string rotaWeek = currentWeek.ToString("d");

                    for (int dayID = 1; dayID <= 5; dayID++)
                    {
                        exportID = ExportInfoTable.Rows[0].Field<int>("export_id");

                        // Check if still in current tax month, this deals with when weeks are in multiple tax months. e.g. a week starting on the 4th of a month.
                        if (currentWeek.AddDays(dayID) > ExportInfoTable.Rows[0].Field<DateTime>("tax_month_end_date"))
                        {
                            // If it's not and a new one hasn't been generated yet, generate a new tax export ID for the next tax month. Eitherway, the exportID must be incremented here.
                            if (!generatedNewExportRow) { GenerateNewExportRow(); generatedNewExportRow = true; }
                            exportID++;
                        }

                        // Generate the new rota row for the staff member
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

                        // Save this row to the database.
                        RotaInfoTable.Rows.Add(newRotaRow);
                        da.Update(RotaInfoDS, "RotaInfo");
                    }
                }
            }

            // Reset the change made variable, if you click save twice in a row, the second time will do nothing thanks to this, saving on processing power and making the program more efficient.
            changeToRotaTableMade = false;
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

            // Try to update the rota table we have saved, if this does not work there may be a problem with the database relationship integrity settings. This try catch prevents a crash in this case.
            try
            {
                da.Update(RotaInfoDS, "RotaInfo");
                GetRotaData();
            }
            catch
            {
                MessageBox.Show("Could not delete rota. Check relational integrity settings in the database.");
            }

        }

        private void btnPrintRota_Click(object sender, EventArgs e)
        {
            /*Creates a PDF which displays the current datagridview rota being displayed, along with the date and giving ample room to write in.*/
            string filename = $"{currentWeek:m}RotaPDF.pdf";
            filename = Regex.Replace(filename, @"\s+", "");
            //filename = Guid.NewGuid().ToString("D").ToUpper() + ".pdf";
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"{currentWeek.ToString("d")}Rota";
            document.Info.Author = "Kai Chevannes";
            document.Info.Subject = "Displays weekly rota in PDF form for printing.";
            document.Info.Keywords = "PDFsharp, XGraphics";

            if (RotaPdfPage1(document)) { return; }

            //Save document
            document.Save(filename);
            //Start a viewer
            Process.Start(filename);
        }

        private bool RotaPdfPage1(PdfDocument document)
        {
            //reference http://www.pdfsharp.net/wiki/Invoice-sample.ashx#Source_Code_6
            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.MUH = PdfFontEncoding.Unicode;
            //XFont font = new XFont("Verdana", 13, XFontStyle.Bold);

            //A MigraDoc document is required for rendering
            Document doc = new Document();
            Section section = doc.AddSection();

            //Set document to horizontal
            section.PageSetup = doc.DefaultPageSetup.Clone();
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
            section.PageSetup.PageHeight = "10cm";

            //Table
            Table table;
            table = section.AddTable();
            table.Style = "Table";
            //table.Borders.Color = 
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            // Before adding a row, columns must be defined
            string columnWidth = "1.235cm";
            //Date
            Column column = table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            //Monday column group
            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            //Tuesday column group
            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            //Wednesday column group
            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            //Thursday column group
            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            //Friday column group
            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn(columnWidth);
            column.Format.Alignment = ParagraphAlignment.Right;


            // Create the header of the table length = 20 [0->20 = 21columns]
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;
            row.Cells[0].AddParagraph($"{currentWeek.ToString("d")}");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeDown = 1;
            row.Cells[1].AddParagraph("Monday");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[1].MergeRight = 3;
            row.Cells[5].AddParagraph("Tuesday");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[5].MergeRight = 3;
            row.Cells[9].AddParagraph("Wednesday");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[9].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[9].MergeRight = 3;
            row.Cells[13].AddParagraph("Thursday");
            row.Cells[13].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[13].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[13].MergeRight = 3;
            row.Cells[17].AddParagraph("Friday");
            row.Cells[17].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[17].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[17].MergeRight = 3;

            // Add the header row
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue

            //Monday columns
            row.Cells[1].AddParagraph("In");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].AddParagraph("Out");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].AddParagraph("In");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].AddParagraph("Out");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;

            //Tuesday columns
            row.Cells[5].AddParagraph("In");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[6].AddParagraph("Out");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[7].AddParagraph("In");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[8].AddParagraph("Out");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Left;

            //Wednesday columns
            row.Cells[9].AddParagraph("In");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[10].AddParagraph("Out");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[11].AddParagraph("In");
            row.Cells[11].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[12].AddParagraph("Out");
            row.Cells[12].Format.Alignment = ParagraphAlignment.Left;

            //Thursday columns
            row.Cells[13].AddParagraph("In");
            row.Cells[13].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[14].AddParagraph("Out");
            row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[15].AddParagraph("In");
            row.Cells[15].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[16].AddParagraph("Out");
            row.Cells[16].Format.Alignment = ParagraphAlignment.Left;

            //Friday columns
            row.Cells[17].AddParagraph("In");
            row.Cells[17].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[18].AddParagraph("Out");
            row.Cells[18].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[19].AddParagraph("In");
            row.Cells[19].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[20].AddParagraph("Out");
            row.Cells[20].Format.Alignment = ParagraphAlignment.Left;

            // Fill Table with the datagrid current weeks rota data.
            for (int staffMemberCount = 1; staffMemberCount < rotaDataGrid.Rows.Count; staffMemberCount++)
            {
                List<string> staffRowInformation = new List<string>();
                Row staffRow = table.AddRow();
                staffRow.Height = "1.0cm";
                staffRow.VerticalAlignment = VerticalAlignment.Center;
                string cellValue;
                for (int cell = 0; cell < rotaDataGrid.Rows[staffMemberCount - 1].Cells.Count; cell++)
                {
                    //----------Exception handling----------
                    // If the rota is not complete, a pdf cannot be created. This isn't a technical issue, it just doesn't make sense to have a rota that is not complete be printed. Therefore this validation check ensures that the rota has been fully completed.
                    cellValue = rotaDataGrid.Rows[staffMemberCount - 1].Cells[cell].Value?.ToString();
                    if (cellValue == null)
                    {
                        MessageBox.Show($"Incomplete Rota. (Row {staffMemberCount}, Column {cell+1})");
                        return true;
                    }
                    staffRowInformation.Add(cellValue);
                    staffRow.Cells[cell].AddParagraph(staffRowInformation[cell]);
                }
            }

            table.SetEdge(0, 0, 21, rotaDataGrid.Rows.Count+1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            //Create a renderer and prepare (=layout) the document
            DocumentRenderer docRenderer = new DocumentRenderer(doc);
            docRenderer.PrepareDocument();

            //Render the paragraph. You can render tables or shapes the same way
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(1), XUnit.FromCentimeter(1), "19cm", table);

            return false;
        }

        private void btnCopyPreviousWeek_Click(object sender, EventArgs e)
        {
            // Get pevious week rota data just calls the normal getrotadata function but sets previous day and next day to the week previous.
            GetPreviousWeekRotaData();
        }
    }
}
