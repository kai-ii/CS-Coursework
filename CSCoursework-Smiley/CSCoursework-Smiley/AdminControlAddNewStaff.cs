﻿using System;
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
    public partial class AdminControlAddNewStaff : UserControl
    {
        //Initialise variables
        OleDbConnection con = new OleDbConnection();
        List<Tuple<int, string>> branchPairs;
        List<Tuple<int, string>> jobPositionPairs;
        public AdminControlAddNewStaff()
        {
            InitializeComponent();
        }

        public Properties.AdminControl parentForm { get; set; }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void AdminControlAddNewStaff_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
            InitializeBranchPairList();
            InitializeJobPositionPairList();
            InitializeBranchComboBox();
            InitializeJobPositionComboBox();
        }
        private void InitializeJobPositionComboBox()
        {
            foreach (var pair in jobPositionPairs)
            {
                comboBoxJobPosition.Items.Add(pair.Item2);
            }
        }
        private void InitializeBranchComboBox()
        {
            foreach (var pair in branchPairs)
            {
                comboBoxBranch.Items.Add(pair.Item2);
            }
        }
        private void InitializeBranchPairList()
        {
            //Initialize List
            branchPairs = new List<Tuple<int, string>>();

            //Initialize variables
            DataSet BranchDS;
            OleDbDataAdapter da;
            DataTable BranchTable;
            string sql;

            //Check Login Details
            con.Open();

            //sql = $"SELECT * FROM tblUsers WHERE username='{UsernameTextbox.Text}' AND password='{PasswordTextbox.Text}'";
            sql = $"SELECT branch_id, branch_name FROM tblBranch";
            da = new OleDbDataAdapter(sql, con);
            BranchDS = new DataSet();
            da.Fill(BranchDS, "BranchInfo");
            BranchTable = BranchDS.Tables["BranchInfo"];

            con.Close();

            foreach (DataRow row in BranchTable.Rows)
            {
                int branchID = row.Field<int>("branch_id");
                string branchName = row.Field<string>("branch_name");
                branchPairs.Add(new Tuple<int, string>(branchID, branchName));   
            }
        }
        private void InitializeJobPositionPairList()
        {
            //Initialize List
            jobPositionPairs = new List<Tuple<int, string>>();

            //Initialize variables
            DataSet JobPositionDS;
            OleDbDataAdapter da;
            DataTable JobPositionTable;
            string sql;

            //Check Login Details
            con.Open();

            sql = $"SELECT jobposition_id, jobposition_name FROM tblJobPositions";
            da = new OleDbDataAdapter(sql, con);
            JobPositionDS = new DataSet();
            da.Fill(JobPositionDS, "JobPositionInfo");
            JobPositionTable = JobPositionDS.Tables["JobPositionInfo"];

            con.Close();

            foreach (DataRow row in JobPositionTable.Rows)
            {
                int jobpositionID = row.Field<int>("jobposition_id");
                string jobpositionName = row.Field<string>("jobposition_name");
                jobPositionPairs.Add(new Tuple<int, string>(jobpositionID, jobpositionName));
            }
        }
        private void InitializeDatabaseConnection()
        {
            //Initialize variables
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FullDatabasePath = "";
            string dbSource;

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                FullDatabasePath = CurrentProjectPath + DatabasePath;
                //MessageBox.Show(FullDatabasePath);
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
                con.Close();
            }
            catch
            {
                Console.WriteLine($"Error establishing database connection AdminControlAddNewStaff. FullDatabasePath = {FullDatabasePath}");
            }
        }
        private void comboBoxContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxContractType.SelectedItem.ToString() == "Salaried")
            {
                lblContractedWeeklyHours.Text = "Contracted Weekly Hours";
                txtContractedWeeklyHours.Visible = true;
            }
            else if (comboBoxContractType.SelectedItem.ToString() == "Flexible")
            {
                lblContractedWeeklyHours.Text = "[Flexible Worker]";
                txtContractedWeeklyHours.Text = "";
                txtContractedWeeklyHours.Visible = false;
            }
            else
            {
                lblContractedWeeklyHours.Text = "[Select Contract]";
                txtContractedWeeklyHours.Visible = false;
            }
        }

        private void btnAddStaffMember_Click(object sender, EventArgs e)
        {
            // This is the function which handles all validation before any data processing occurs.
            if (!ValidateFields()) //If this is not true, at least one validation check was failed.
            {
                return;
            }

            //Initialize variables
            OleDbDataAdapter da;
            OleDbDataAdapter da2;
            DataSet StaffDS;
            DataTable StaffTable;
            DataSet StaffBranchDS;
            DataTable StaffBranchTable;
            string sql;
            int staffID;
            int branchID;
            int staffBranchID;
            int jobPositionID = 0;
            string staffFirstname;
            string staffSurname;
            string staffNINumber = "";
            string staffDoB;
            string staffGender;
            string staffContractType;
            int staffSalariedHours;
            string staffWorksNumber = "";
            string staffNILetter = "";
            string staffTaxCode = "";
            string staffStreet = "";
            string staffCity = "";
            string staffCounty = "";
            string staffPostcode = "";
            string staffMobileNumber = "";
            string staffHomeNumber = "";
            string staffEmailAddress = "";
            bool staffEmployed;

            //Initialize StaffDS
            con.Open();

            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffDS = new DataSet();
            da.Fill(StaffDS, "StaffInfo");
            StaffTable = StaffDS.Tables["StaffInfo"];

            sql = $"SELECT * FROM tblStaffBranch";
            da2 = new OleDbDataAdapter(sql, con);
            StaffBranchDS = new DataSet();
            da2.Fill(StaffBranchDS, "StaffBranchInfo");
            StaffBranchTable = StaffBranchDS.Tables["StaffBranchInfo"];

            con.Close();
            
            // StaffID
            staffID = StaffTable.Rows[StaffTable.Rows.Count - 1].Field<int>("staff_id") + 1; // staffID is set to 1 more than the last staff member in the database regardless of database size. Therefore no duplicate staff_ids since the last staff_id will alwasy be the greatest.

            // BranchID
            branchID = comboBoxBranch.SelectedIndex + 1;

            // StaffbranchID
            staffBranchID = StaffBranchTable.Rows[StaffBranchTable.Rows.Count - 1].Field<int>("staffbranch_id") + 1;

            // JobPosition
            foreach (var pair in jobPositionPairs)
            {
                if (pair.Item2.ToString() == comboBoxJobPosition.SelectedItem.ToString())
                {
                    jobPositionID = pair.Item1;
                }
            }
            //Validation - Forename Surname DateOfBirth Gender ContractType ContractedWeeklyHour Branch JobPosition

            // Firstname
            staffFirstname = txtForename.Text;

            // Surname
            staffSurname = txtSurname.Text;

            // NINumber
            if (txtNINumber.Text.Trim() != "") { staffNINumber = txtNINumber.Text; }

            // DateOfBirth
            staffDoB = txtDateOfBirth.Text;

            // Gender
            staffGender = comboBoxGender.SelectedItem.ToString();

            // Contract Type
            staffContractType = comboBoxContractType.SelectedItem.ToString();

            // Salaried Hours
            if (staffContractType == "Salaried") { staffSalariedHours = Convert.ToInt32(txtContractedWeeklyHours.Text.ToString()); } //Can safely use convert here since validation was done to check it is an integer
            else { staffSalariedHours = 0; } //0 salaried hours = flexible

            // Works Number
            if (txtWorksNumber.Text.ToString().Trim() != "") { staffWorksNumber = txtWorksNumber.Text.ToString(); }

            // NI Letter + Length Check
            if (txtNILetter.Text.ToString().Trim() != "")
            {
                if (txtNILetter.Text.ToString().Trim().Length == 1 && char.IsLetter(txtNILetter.Text.ToString().Trim()[0])) { staffNILetter = txtNILetter.Text.ToString(); }
                else { MessageBox.Show("NI Letter must only be a single letter."); return; }
            }

            // NI Number
            if (txtNINumber.Text.ToString().Trim() != "") { staffNINumber = txtNINumber.Text.ToString(); }

            // Tax Code
            if (txtTaxCode.Text.ToString().Trim() != "") { staffTaxCode = txtTaxCode.Text.ToString(); }

            // Street
            if (txtStreet.Text.ToString().Trim() != "") { staffStreet = txtStreet.Text.ToString(); }

            // City
            if (txtTownCity.Text.ToString().Trim() != "") { staffCity = txtTownCity.Text.ToString(); }

            // County
            if (txtCounty.Text.ToString().Trim() != "") { staffCounty = txtCounty.Text.ToString(); }

            // Postcode
            if (txtPostcode.Text.ToString().Trim() != "") { staffPostcode = txtPostcode.Text.ToString(); }

            // Mobile Number + Length Check
            if (txtMobileNumber.Text.ToString().Trim() != "")
            {
                if (txtMobileNumber.Text.ToString().Trim().Length == 11) { staffMobileNumber = txtMobileNumber.Text.ToString(); }
                else { MessageBox.Show("Mobile Number must have 11 digits."); return; }
                }

            // Home Number + Length Check
            if (txtHomeNumber.Text.ToString().Trim() != "")
            {
                if(txtHomeNumber.Text.ToString().Length == 11) { staffHomeNumber = txtHomeNumber.Text.ToString(); }
                else { MessageBox.Show("Home Number must have 11 digits."); return; }
            }

            // Email Address
            if (txtEmailAddress.Text.ToString().Trim() != "") { staffEmailAddress = txtEmailAddress.Text.ToString(); }

            // Employed
            staffEmployed = true;


            // Command Builder
            _ = new OleDbCommandBuilder(da);
            _ = new OleDbCommandBuilder(da2);

            // Staff Table Row Addition
            DataRow newStaffRow = StaffTable.NewRow();
            newStaffRow["staff_id"] = staffID;
            newStaffRow["jobposition_id"] = jobPositionID;
            newStaffRow["staff_firstname"] = staffFirstname;
            newStaffRow["staff_surname"] = staffSurname;
            newStaffRow["staff_NI_number"] = staffNINumber;
            newStaffRow["staff_DoB"] = staffDoB;
            newStaffRow["staff_gender"] = staffGender;
            newStaffRow["staff_contract_type"] = staffContractType;
            newStaffRow["staff_salaried_hours"] = staffSalariedHours;
            newStaffRow["staff_works_number"] = staffWorksNumber;
            newStaffRow["staff_NI_letter"] = staffNILetter;
            newStaffRow["staff_tax_code"] = staffTaxCode;
            newStaffRow["staff_street"] = staffStreet;
            newStaffRow["staff_city"] = staffCity;
            newStaffRow["staff_county"] = staffCounty;
            newStaffRow["staff_postcode"] = staffPostcode;
            newStaffRow["staff_mobile_number"] = staffMobileNumber;
            newStaffRow["staff_home_number"] = staffHomeNumber;
            newStaffRow["staff_email_address"] = staffEmailAddress;
            newStaffRow["staff_employed"] = staffEmployed;

            StaffTable.Rows.Add(newStaffRow);
            da.Update(StaffDS, "StaffInfo");

            // StaffBranch Table Row Addition
            DataRow newStaffBranchRow = StaffBranchTable.NewRow();
            newStaffBranchRow["staffbranch_id"] = staffBranchID;
            newStaffBranchRow["staff_id"] = staffID;
            newStaffBranchRow["branch_id"] = branchID;

            StaffBranchTable.Rows.Add(newStaffBranchRow);
            da2.Update(StaffBranchDS, "StaffBranchInfo");

            parentForm.ResetControls();
        }
        private bool hasOnlyLetters(string stringToValidate)
        {
            for (int character = 0; character < stringToValidate.Length; character++) // For every character in the input string
            {
                if (!char.IsLetter(stringToValidate[character])) // Check if the character is not a letter
                {
                    // If this is true, the string contains a number or other character, therefore it does not contain only letters. 
                    return false; // Therefore return false to represent that the string does not only have letters
                }
            }
            return true; // Else if the entire string contains only letters, return that the stringToValidate hasOnlyLetters, i.e. return true;
        }
        private bool ValidateFields() //True represents that every validation check was passed, false represents that at least one validation check failed.
        {
            // Presence Check
            if (txtForename.Text.Trim() == "")
            {
                MessageBox.Show("All required fields must be completed. The 'Forename' field is currently empty.");
                return false;
            }
            // Type Check/Character Check
            else if (!hasOnlyLetters(txtForename.Text))
            {
                MessageBox.Show("The 'Forename' field can only contain letters.");
                return false;
            }

            // Presence Check
            if (txtSurname.Text.Trim() == "")
            {
                MessageBox.Show("All required fields must be completed. The 'Surname' field is currently empty.");
                return false;
            }
            // Type Check/Character Check
            else if (!hasOnlyLetters(txtSurname.Text))
            {
                MessageBox.Show("The 'Surname' field can only contain letters.");
                return false;
            }

            // Presence Check
            if (txtDateOfBirth.Text.Trim() == "")
            {
                MessageBox.Show("All required fields must be completed. The 'Date Of Birth' field is currently empty.");
                return false;
            }
            else
            {
                // Format Check
                string DateOfBirth = txtDateOfBirth.Text;
                string formatString = "dd/MM/yyyy";
                //MessageBox.Show(DateTime.TryParseExact(DateOfBirth, formatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _).ToString());
                if (!DateTime.TryParseExact(DateOfBirth, formatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _))
                {
                    MessageBox.Show("Invalid Date. Check the Date Of Birth field.");
                }
            }

            // Presence Check
            if (comboBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("All required fields must be complete. The 'Gender' drop down box currently has no selected value.");
            }

            // Presence Check
            if (comboBoxContractType.SelectedIndex == -1)
            {
                MessageBox.Show("All required fields must be complete. The 'Contract Type' drop down box currently has no selected value.");
            }

            // Conditioned on the contract type being salaried:
            if (comboBoxContractType.SelectedItem.ToString() == "Salaried")
            {
                // Presence Check
                if (txtContractedWeeklyHours.Text.Trim() == "")
                {
                    MessageBox.Show("All required fields must be completed. The 'Contracted Weekly Hours' field is currently empty.");
                    return false;
                }
                // Type Check/Character Check
                else if (!int.TryParse(txtContractedWeeklyHours.Text, out _))
                {
                    MessageBox.Show("The 'Contracted Weekly Hours' field can only contain numbers.");
                    return false;
                }
            }

            // Presence Check
            if (comboBoxBranch.SelectedIndex == -1)
            {
                MessageBox.Show("All required fields must be complete. The 'Branch' drop down box currently has no selected value.");
            }

            // Presence Check
            if (comboBoxJobPosition.SelectedIndex == -1)
            {
                MessageBox.Show("All required fields must be complete. The 'Job Position' drop down box currently has no selected value.");
            }

            // If every validation check is passed -> return true;
            return true;
        }
    }
}
