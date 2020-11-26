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
    public partial class StaffControlDetails : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();

        //Initialise dict
        Dictionary<string, string> staffInfoDict = new Dictionary<string, string>();
        public DataRow staff_details 
        {
            get { return staff_details; }
            set
            {
                staffInfoDict.Add("staff_id", Convert.ToString(value.Field<int>("staff_id")));
                staffInfoDict.Add("jobposition_id", Convert.ToString(value.Field<int>("jobposition_id")));
                staffInfoDict.Add("staff_firstname", value.Field<string>("staff_firstname"));
                staffInfoDict.Add("staff_surname", value.Field<string>("staff_surname"));
                staffInfoDict.Add("staff_NI_number", value.Field<string>("staff_NI_number"));
                staffInfoDict.Add("staff_DoB", value.Field<string>("staff_DoB"));
                staffInfoDict.Add("staff_gender", value.Field<string>("staff_gender"));
                staffInfoDict.Add("staff_contract_type", value.Field<string>("staff_contract_type"));
                staffInfoDict.Add("staff_salaried_hours", Convert.ToString(value.Field<int>("staff_salaried_hours")));
                staffInfoDict.Add("staff_works_number", value.Field<string>("staff_works_number"));
                staffInfoDict.Add("staff_NI_letter", value.Field<string>("staff_NI_letter"));
                staffInfoDict.Add("staff_tax_code", value.Field<string>("staff_tax_code"));
                staffInfoDict.Add("staff_street", value.Field<string>("staff_street"));
                staffInfoDict.Add("staff_city", value.Field<string>("staff_city"));
                staffInfoDict.Add("staff_county", value.Field<string>("staff_county"));
                staffInfoDict.Add("staff_postcode", value.Field<string>("staff_postcode"));
                staffInfoDict.Add("staff_mobile_number", value.Field<string>("staff_mobile_number"));
                staffInfoDict.Add("staff_home_number", value.Field<string>("staff_home_number"));
                staffInfoDict.Add("staff_email_address", value.Field<string>("staff_email_address"));
                staffInfoDict.Add("staff_employed", Convert.ToString(value.Field<bool>("staff_employed")));
                InitializeDatabaseConnection();
                staffInfoDict.Add("jobposition_name", GetJobPositionName(Convert.ToInt32(staffInfoDict["jobposition_id"])));
                UpdateUserDetails();
            }
        }
        public StaffControlDetails()
        {
            InitializeComponent();
        }

        private void StaffControlDetails_Load(object sender, EventArgs e)
        {

        }

        private string GetJobPositionName(int jobposition_id)
        {
            //Initialize variables
            DataSet JobPositionDS;
            OleDbDataAdapter da;
            string sql;

            //Check Login Details
            sql = $"SELECT * FROM tblJobPositions WHERE jobposition_id={jobposition_id}";
            da = new OleDbDataAdapter(sql, con);
            JobPositionDS = new DataSet();
            da.Fill(JobPositionDS, "JobPosition");

            return Convert.ToString(JobPositionDS.Tables["JobPosition"].Rows[0].Field<string>("jobposition_name"));
        }

        private void InitializeDatabaseConnection()
        {
            //Initialize variables
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FormattedDatabasePath;
            string FullDatabasePath;
            string dbSource;

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "/TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                FormattedDatabasePath = CurrentProjectPath.Remove(CurrentProjectPath.Length - 31, 31); //Cuts off the last 31 chars which gives the directory which the database is located
                FullDatabasePath = FormattedDatabasePath + DatabasePath;
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
            }
            catch
            {
                MessageBox.Show("Error establishing database connection.");
            }
        }

        private void UpdateUserDetails()
        {
            //Address
            lblAddressStreet.Text = staffInfoDict["staff_street"];
            lblAddressCity.Text = staffInfoDict["staff_city"];
            lblAddressCounty.Text = staffInfoDict["staff_county"];
            lblAddressPostcode.Text = staffInfoDict["staff_postcode"];
            //Employment
            lblEmploymentStaffID.Text = $"Staff ID: {staffInfoDict["staff_id"]}";
            lblEmploymentJobTitle.Text = $"Job Title: {staffInfoDict["jobposition_name"]}";
            lblEmploymentContractType.Text = $"Branch: {staffInfoDict["staff_contract_type"]}";
            //Contact Info
            lblContactInfoEmailAddress.Text = $"Email Address: {staffInfoDict["staff_email_address"]}";
            lblContactInfoMobileNumber.Text = $"Mobile Number: {staffInfoDict["staff_mobile_number"]}";
            lblContactInfoHomeNumber.Text = $"Home Number: {staffInfoDict["staff_home_number"]}";
            //Employment Info
            lblEmploymentInfoDoB.Text = $"Date of Birth: {staffInfoDict["staff_DoB"]}";
            lblEmploymentInfoGender.Text = $"Gender: {staffInfoDict["staff_gender"]}";
            lblEmploymentInfoCurrentlyEmployed.Text = $"Currently Employed: {staffInfoDict["staff_employed"]}";
            //Payment Details
            lblPaymentDetailsNILetter.Text = $"NI Letter: {staffInfoDict["staff_NI_letter"]}";
            lblPaymentDetailsTaxCode.Text = $"Tax Code: {staffInfoDict["staff_tax_code"]}";
            lblPaymentDetailsWorksNumber.Text = $"Works Number: {staffInfoDict["staff_works_number"]}";
        }
    }
}
