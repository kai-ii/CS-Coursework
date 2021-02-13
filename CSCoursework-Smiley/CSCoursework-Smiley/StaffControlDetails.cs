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
        int jobpositionID;
        string jobpositionName;
        public StaffControl parentForm { get; set; }

        //Initialise dict
        Dictionary<string, string> staffInfoDict = new Dictionary<string, string>();
        public DataRow Staff_details 
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    staffInfoDict = new Dictionary<string, string>();
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
                    jobpositionID = Convert.ToInt32(staffInfoDict["jobposition_id"]);
                    jobpositionName = GetJobPositionName(jobpositionID);
                    staffInfoDict.Add("jobposition_name", jobpositionName);
                    UpdateUserDetails();
                }
            }
        }
        public StaffControlDetails()
        {
            InitializeComponent();
        }

        private void StaffControlDetails_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
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

            string jobposition_name = Convert.ToString(JobPositionDS.Tables["JobPosition"].Rows[0].Field<string>("jobposition_name"));
            con.Close();
            return jobposition_name;
        }

        private int GetJobPositionID(string jobpositionName)
        {
            //Initialize variables
            DataSet JobPositionDS;
            DataTable JobPositionTable;
            OleDbDataAdapter da;
            string sql;

            //Check Login Details
            sql = $"SELECT * FROM tblJobPositions WHERE jobposition_name='{jobpositionName}'";
            da = new OleDbDataAdapter(sql, con);
            JobPositionDS = new DataSet();
            da.Fill(JobPositionDS, "JobPosition");
            JobPositionTable = JobPositionDS.Tables["JobPosition"];

            if (JobPositionTable.Rows.Count == 0) { MessageBox.Show("Invalid Job Title."); return -1; }
            int jobposition_id = JobPositionTable.Rows[0].Field<int>("jobposition_id");
            con.Close();
            //MessageBox.Show(jobposition_id.ToString());
            return jobposition_id;
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
            }
            catch
            {
                //MessageBox.Show("Error establishing database connection StaffControlDetails.");
            }
        }

        private void UpdateUserDetails()
        {
            txtContactInfoMobileNumber.AutoSize = true;
            //Address
            txtAddressStreet.Text = staffInfoDict["staff_street"];
            txtAddressCity.Text = staffInfoDict["staff_city"];
            txtAddressCounty.Text = staffInfoDict["staff_county"];
            txtAddressPostcode.Text = staffInfoDict["staff_postcode"];
            //Employment
            txtEmploymentSalariedHours.Text = $"{staffInfoDict["staff_salaried_hours"]}";
            txtEmploymentStaffID.Text = $"{staffInfoDict["staff_id"]}";
            txtEmploymentJobTitle.Text = $"{staffInfoDict["jobposition_name"]}";
            txtEmploymentContractType.Text = $"{staffInfoDict["staff_contract_type"]}";
            //Contact Info
            txtContactInfoEmailAddress.Text = $"{staffInfoDict["staff_email_address"]}";
            txtContactInfoMobileNumber.Text = $"{staffInfoDict["staff_mobile_number"]}";
            txtContactInfoHomeNumber.Text = $"{staffInfoDict["staff_home_number"]}";
            //Employment Info
            txtEmploymentInfoDoB.Text = $"{staffInfoDict["staff_DoB"]}";
            txtEmploymentInfoGender.Text = $"{staffInfoDict["staff_gender"]}";
            txtEmploymentInfoCurrentlyEmployed.Text = $"{staffInfoDict["staff_employed"]}";
            //Payment Details
            txtPaymentDetailsNILetter.Text = $"{staffInfoDict["staff_NI_letter"]}";
            txtPaymentDetailsTaxCode.Text = $"{staffInfoDict["staff_tax_code"]}";
            txtPaymentDetailsWorksNumber.Text = $"{staffInfoDict["staff_works_number"]}";
        }

        private void grpAddress_Enter(object sender, EventArgs e)
        {

        }

        private void btnEditAddressDetails_Click(object sender, EventArgs e)
        {
            txtAddressStreet.ReadOnly = !txtAddressStreet.ReadOnly;
            txtAddressCity.ReadOnly = !txtAddressCity.ReadOnly;
            txtAddressCounty.ReadOnly = !txtAddressCounty.ReadOnly;
            txtAddressPostcode.ReadOnly = !txtAddressPostcode.ReadOnly;
            btnSaveAddressDetails.Visible = !btnSaveAddressDetails.Visible;
        }
        private void btnSaveAddressDetails_Click(object sender, EventArgs e)
        {
            string[] addressDetails = new string[5]; //staffid, street, city, country, postcode
            addressDetails[0] = txtEmploymentStaffID.Text;
            addressDetails[1] = txtAddressStreet.Text;
            addressDetails[2] = txtAddressCity.Text;
            addressDetails[3] = txtAddressCounty.Text;
            addressDetails[4] = txtAddressPostcode.Text;
            parentForm.UpdateAddressInfo(addressDetails);
        }
        private void btnSaveEmploymentDetails_Click(object sender, EventArgs e)
        {
            string[] employmentDetails = new string[4]; //staffid, jobpositionID, contracttype, salariedhours
            employmentDetails[0] = txtEmploymentStaffID.Text;
            int jobID = GetJobPositionID(txtEmploymentJobTitle.Text);
            if (jobID == -1) { return; } //rogue value to terminate function in case of failed validation.
            employmentDetails[1] = Convert.ToString(jobID);

            if (txtEmploymentContractType.Text.ToLower().Trim() == "flexible")
            {
                employmentDetails[2] = "Flexible";
                employmentDetails[3] = "0";
            }
            else if (txtEmploymentContractType.Text.ToLower().Trim() == "salaried")
            {
                employmentDetails[2] = "Salaried";

                foreach (char letter in txtEmploymentSalariedHours.Text)
                {
                    if (Char.IsLetter(letter))
                    {
                        MessageBox.Show("Salaried hours must be an integer.");
                        return;
                    }
                }
                if (Convert.ToInt32(txtEmploymentSalariedHours.Text) > 0)
                {
                    employmentDetails[3] = txtEmploymentSalariedHours.Text;
                }
                else
                {
                    MessageBox.Show("Salaried hours must be greater than 0.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Contract type must be 'Flexible' or 'Salaried'.");
                return;
            }
            parentForm.UpdateEmploymentDetails(employmentDetails);
        }

        private void btnEditEmploymentDetails_Click(object sender, EventArgs e)
        {
            txtEmploymentJobTitle.ReadOnly = !txtEmploymentJobTitle.ReadOnly;
            txtEmploymentContractType.ReadOnly = !txtEmploymentContractType.ReadOnly;
            txtEmploymentSalariedHours.ReadOnly = !txtEmploymentSalariedHours.ReadOnly;
            btnSaveEmploymentDetails.Visible = !btnSaveEmploymentDetails.Visible;
        }
    }
}
