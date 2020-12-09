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
    public partial class TimesheetControl : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        DateTime currentWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);

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
            GetRotaData();
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

            //foreach (DataRow row in RotaInfoTable.Rows)
            //{
            //    //MessageBox.Show($"{row.Field<DateTime>("rota_week").ToString("d")} == {currentWeek.ToString("d")}");
            //    if (row.Field<DateTime>("rota_week").ToString("d") == currentWeek.ToString("d"))
            //    {
            //        int day = row.Field<int>("day_id");
            //        string staffMember = $"{row.Field<string>("staff_firstname")}. {row.Field<string>("staff_surname")[0]}";
            //        string rotaStartTime = row.Field<string>("rota_start_time");
            //        string rotaEndTime = row.Field<string>("rota_end_time");
            //        switch(day)
            //        {
            //            case 1:
            //                this.rotaDataGrid.Rows.Add(staffMember, rotaStartTime, rotaEndTime);
            //                break;

            //        }
            //    }
            //}
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
