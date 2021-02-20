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
    public partial class AdminControlManageJobPositions : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        Properties.AdminControl parentForm;

        public void SetCon(OleDbConnection Con)
        {
            con = Con;
            InitializeForm();
        }
        private void InitializeForm()
        {
            GetJobPositionData();
        }
        public AdminControlManageJobPositions()
        {
            InitializeComponent();
        }
        public void setParentForm(Properties.AdminControl AdminControlParent)
        {
            parentForm = AdminControlParent;
        }
        private void AdminControlManageJobPositions_Load(object sender, EventArgs e)
        {
            //InitializeDatabaseConnection();
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
                MessageBox.Show("Error establishing database connection AdminControlManageJobPositions");
            }
        }
        private void GetJobPositionData()
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet JobPositionDS;
            OleDbDataAdapter da;
            string sql;

            // Get JobPositionData
            sql = $"SELECT * FROM tblJobPositions";
            da = new OleDbDataAdapter(sql, con);
            JobPositionDS = new DataSet();
            da.Fill(JobPositionDS, "JobPositionInfo");

            // Close database connection
            con.Close();

            DataTable JobPositionTable = JobPositionDS.Tables["JobPositionInfo"];

            // Clear the rows and sets ReadOnly column
            this.jobPositionDataGrid.Rows.Clear();
            jobPositionDataGrid.Columns["JobPositionID"].ReadOnly = true;

            // Identify number of unique rows to be displayed
            foreach (DataRow row in JobPositionTable.Rows)
            {
                jobPositionDataGrid.Rows.Add(row.ItemArray[0].ToString(), row.ItemArray[1], row.ItemArray[2]);
            }
        }
        private void btnSaveJobPositions_Click(object sender, EventArgs e)
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet JobPositionDS;
            OleDbDataAdapter da;
            string sql;

            // Get JobPositionData
            sql = $"SELECT * FROM tblJobPositions";
            da = new OleDbDataAdapter(sql, con);
            JobPositionDS = new DataSet();
            da.Fill(JobPositionDS, "JobPositionInfo");

            // Close database connection
            con.Close();

            DataTable JobPositionTable = JobPositionDS.Tables["JobPositionInfo"];
            int[] jobpositionIDArray = new int[JobPositionTable.Rows.Count];
            for (int row = 0; row < JobPositionTable.Rows.Count; row++)
            {
                jobpositionIDArray[row] = JobPositionTable.Rows[row].Field<int>("jobposition_id");
            }

            foreach (DataGridViewRow row in jobPositionDataGrid.Rows)
            {
                if (row.Cells[0].Value?.ToString() == null) { continue; }
                int rowJobPositionID = int.Parse(row.Cells[0].Value.ToString()); //this will always parse since this is a readonly column
                // Format check
                if (!Regex.IsMatch(row.Cells[2].Value.ToString(), @"^\£\d{2}\.\d{2}$") && !Regex.IsMatch(row.Cells[2].Value.ToString(), @"^\£\d{1}\.\d{2}$"))
                {
                    MessageBox.Show($"Invalid wage for JobPositionID {rowJobPositionID}. It must be in the format '£12.34' or '£1.23'");
                    return;
                }
                // Presence check
                if (row.Cells[1].Value?.ToString() == "" || row.Cells[1].Value?.ToString() == null)
                {
                    MessageBox.Show($"Invalid Job Position Name for JobPositionID {rowJobPositionID}");
                    return;
                }
                if (jobpositionIDArray.Contains<int>(rowJobPositionID))
                {
                    var updateCommand = new OleDbCommand();
                    sql = $"UPDATE [tblJobPositions] SET [jobposition_name]='{row.Cells[1].Value}', [jobposition_wage]='{row.Cells[2].Value}' WHERE [jobposition_id]={rowJobPositionID};";
                    updateCommand.CommandText = sql;
                    updateCommand.Connection = con;
                    con.Open();
                    updateCommand.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    DataRow newRow = JobPositionTable.NewRow();
                    newRow["jobposition_id"] = rowJobPositionID;
                    newRow["jobposition_name"] = row.Cells[1].Value;
                    newRow["jobposition_wage"] = row.Cells[2].Value;
                    JobPositionTable.Rows.Add(newRow);
                    _ = new OleDbCommandBuilder(da);
                    da.Update(JobPositionDS, "JobPositionInfo");
                }
            }
            MessageBox.Show("Successfully updated job position information.");
            parentForm.UpdatePayslipJobPositions();
        }
        private void jobPositionDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            int previousRow = jobPositionDataGrid.Rows.Count - 3;
            int currentRow = jobPositionDataGrid.Rows.Count - 2;
            jobPositionDataGrid.Rows[currentRow].Cells[0].Value = Convert.ToString(int.Parse(jobPositionDataGrid.Rows[previousRow].Cells[0].Value.ToString()) + 1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
