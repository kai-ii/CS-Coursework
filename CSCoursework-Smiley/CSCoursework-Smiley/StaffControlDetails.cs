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
    public partial class StaffControlDetails : UserControl
    {
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        int jobpositionID;
        string jobpositionName;
        StaffControl parentForm;

        public void SetCon(OleDbConnection Con)
        {
            con = Con;
        }
        public void SetParentForm(StaffControl ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template StaffControl which is passed in from the Staff Control.
            parentForm = ParentForm;
        }

        //Initialise dict
        Dictionary<string, string> staffInfoDict = new Dictionary<string, string>();

        public void SetStaffDetails(DataRow value)
        {
            // If the given value is not a null one, then assign the staff information dictionary the values corresponding with the fields in the database.
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

                // Finally update the user details with these values.
                UpdateUserDetails();
            }
        }
        public StaffControlDetails()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        private void StaffControlDetails_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database. Otherwise, this form is entirely event driven.
        }
        public void PersonalView()
        {
            // If the staff member only has personal permissions then don't allow them to edit their own details.
            btnEditAddressDetails.Visible = false;
            btnEditEmploymentDetails.Visible = false;
            btnEditContactInfoDetails.Visible = false;
            btnEditEmploymentInfoDetails.Visible = false;
            btnEditPaymentDetails.Visible = false;
        }
        public void AdminView()
        {
            // If the staff member has all permissions then allow them to edit all staff member details.
            btnEditAddressDetails.Visible = true;
            btnEditEmploymentDetails.Visible = true;
            btnEditContactInfoDetails.Visible = true;
            btnEditEmploymentInfoDetails.Visible = true;
            btnEditPaymentDetails.Visible = true;
        }
        private string GetJobPositionName(int jobposition_id)
        {
            //Initialize variables
            DataSet JobPositionDS;
            OleDbDataAdapter da;
            string sql;

            // Open the database connection
            con.Open();

            //Check Login Details
            sql = $"SELECT * FROM tblJobPositions WHERE jobposition_id={jobposition_id}";
            da = new OleDbDataAdapter(sql, con);
            JobPositionDS = new DataSet();
            da.Fill(JobPositionDS, "JobPosition");

            // Close the database connection.
            con.Close();

            // Set the job position name and return it.
            string jobposition_name = Convert.ToString(JobPositionDS.Tables["JobPosition"].Rows[0].Field<string>("jobposition_name"));
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
            txtPaymentDetailsNINumber.Text = $"{staffInfoDict["staff_NI_number"]}";
            txtPaymentDetailsNILetter.Text = $"{staffInfoDict["staff_NI_letter"]}";
            txtPaymentDetailsTaxCode.Text = $"{staffInfoDict["staff_tax_code"]}";
            txtPaymentDetailsWorksNumber.Text = $"{staffInfoDict["staff_works_number"]}";
        }
        private void btnEditAddressDetails_Click(object sender, EventArgs e)
        {
            // Change the readonly settings of the section to be editted, and hide or show the sections save button respectively.
            txtAddressStreet.ReadOnly = !txtAddressStreet.ReadOnly;
            txtAddressCity.ReadOnly = !txtAddressCity.ReadOnly;
            txtAddressCounty.ReadOnly = !txtAddressCounty.ReadOnly;
            txtAddressPostcode.ReadOnly = !txtAddressPostcode.ReadOnly;
            btnSaveAddressDetails.Visible = !btnSaveAddressDetails.Visible;
        }
        private void btnSaveAddressDetails_Click(object sender, EventArgs e)
        {
            // Setup the address details array and then update the database using the staffdetails public UpdateAddressInfo function.
            string[] addressDetails = new string[5]; // [staffid, street, city, country, postcode]
            addressDetails[0] = txtEmploymentStaffID.Text.Trim();
            addressDetails[1] = txtAddressStreet.Text.Trim();
            addressDetails[2] = txtAddressCity.Text.Trim();
            addressDetails[3] = txtAddressCounty.Text.Trim();
            addressDetails[4] = txtAddressPostcode.Text.Trim();
            parentForm.UpdateAddressInfo(addressDetails);
        }
        private void btnSaveEmploymentDetails_Click(object sender, EventArgs e)
        {
            string[] employmentDetails = new string[4]; //staffid, jobpositionID, contracttype, salariedhours
            employmentDetails[0] = txtEmploymentStaffID.Text.Trim();
            int jobID = GetJobPositionID(txtEmploymentJobTitle.Text);
            if (jobID == -1) { return; } //rogue value to terminate function in case of failed validation.
            employmentDetails[1] = Convert.ToString(jobID);

            // Set up the array based on contract type.
            if (txtEmploymentContractType.Text.ToLower().Trim() == "flexible")
            {
                employmentDetails[2] = "Flexible";
                employmentDetails[3] = "0";
            }
            else if (txtEmploymentContractType.Text.ToLower().Trim() == "salaried")
            {
                employmentDetails[2] = "Salaried";

                // Type validation check.
                foreach (char letter in txtEmploymentSalariedHours.Text)
                {
                    if (Char.IsLetter(letter))
                    {
                        MessageBox.Show("Salaried hours must be an integer.");
                        return;
                    }
                }
                // Range check.
                if (Convert.ToInt32(txtEmploymentSalariedHours.Text) > 0)
                {
                    employmentDetails[3] = txtEmploymentSalariedHours.Text;
                }
                else
                {
                    //----------Exception handling----------
                    // Tells the user their entry is invalid.
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
            // Change the readonly settings of the section to be editted, and hide or show the sections save button respectively.
            txtEmploymentJobTitle.ReadOnly = !txtEmploymentJobTitle.ReadOnly;
            txtEmploymentContractType.ReadOnly = !txtEmploymentContractType.ReadOnly;
            txtEmploymentSalariedHours.ReadOnly = !txtEmploymentSalariedHours.ReadOnly;
            btnSaveEmploymentDetails.Visible = !btnSaveEmploymentDetails.Visible;
        }

        private void btnEditContactInfoDetails_Click(object sender, EventArgs e)
        {
            // Change the readonly settings of the section to be editted, and hide or show the sections save button respectively.
            txtContactInfoEmailAddress.ReadOnly = !txtContactInfoEmailAddress.ReadOnly;
            txtContactInfoMobileNumber.ReadOnly = !txtContactInfoMobileNumber.ReadOnly;
            txtContactInfoHomeNumber.ReadOnly = !txtContactInfoHomeNumber.ReadOnly;
            btnSaveContactInfoDetails.Visible = !btnSaveContactInfoDetails.Visible;
        }

        private void btnSaveContactInfoDetails_Click(object sender, EventArgs e)
        {
            // Format validation for the email address
            if (!Regex.IsMatch(txtContactInfoEmailAddress.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                MessageBox.Show("Email Address must be in the format string@string.string");
                return;
            }
            // Length check validation for the mobile number
            if (txtContactInfoMobileNumber.Text.Trim().Length != 11)
            {
                MessageBox.Show("Mobile Number must be 11 digits.");
                return;
            }
            // Length check validation for the home number.
            if (txtContactInfoHomeNumber.Text.Trim().Length != 11)
            {
                MessageBox.Show("Home Number must be 11 digits.");
                return;
            }
            
            string[] contactInfoDetails = new string[4]; // staffID, emailAddress, mobileNumber, homeNumber
            contactInfoDetails[0] = txtEmploymentStaffID.Text.Trim();
            contactInfoDetails[1] = txtContactInfoEmailAddress.Text.Trim();
            contactInfoDetails[2] = txtContactInfoMobileNumber.Text.Trim();
            contactInfoDetails[3] = txtContactInfoHomeNumber.Text.Trim();
            parentForm.UpdateContactInfoDetails(contactInfoDetails);
        }

        private void btnEditEmploymentInfoDetails_Click(object sender, EventArgs e)
        {
            // Change the readonly settings of the section to be editted, and hide or show the sections save button respectively.
            txtEmploymentInfoDoB.ReadOnly = !txtEmploymentInfoDoB.ReadOnly;
            txtEmploymentInfoGender.ReadOnly = !txtEmploymentInfoGender.ReadOnly;
            txtEmploymentInfoCurrentlyEmployed.ReadOnly = !txtEmploymentInfoCurrentlyEmployed.ReadOnly;
            btnSaveEmploymentInfoDetails.Visible = !btnSaveEmploymentInfoDetails.Visible;
        }

        private void btnSaveEmploymentInfoDetails_Click(object sender, EventArgs e)
        {
            // Format Check.
            string DateOfBirth = txtEmploymentInfoDoB.Text;
            string formatString = "dd/MM/yyyy";
            if (!DateTime.TryParseExact(DateOfBirth, formatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Invalid Date. Check the Date Of Birth field.");
                return;
            }
            // Checks for specific inputs.
            if (txtEmploymentInfoGender.Text.Trim().ToLower() != "male" && txtEmploymentInfoGender.Text.Trim().ToLower() != "female")
            {
                MessageBox.Show("Gender must be either male or female.");
                return;
            }
            // Checks for specific inputs.
            if (txtEmploymentInfoCurrentlyEmployed.Text.Trim().ToLower() != "true" && txtEmploymentInfoCurrentlyEmployed.Text.Trim().ToLower() != "false")
            {
                MessageBox.Show("Employed must be either true or false.");
                return;
            }
            
            string[] employmentInfoDetails = new string[4]; //staffID, DoB, gender, employed
            employmentInfoDetails[0] = txtEmploymentStaffID.Text.Trim();
            employmentInfoDetails[1] = txtEmploymentInfoDoB.Text.Trim();
            employmentInfoDetails[2] = txtEmploymentInfoGender.Text.Trim();

            if (txtEmploymentInfoCurrentlyEmployed.Text.Trim().ToLower() == "true") { employmentInfoDetails[3] = "True"; }
            else { employmentInfoDetails[3] = "False"; } // Since if it is not true, it must be false if it passed the validation check.

            // Update the employment info details using the public function in the staff details control.
            parentForm.UpdateEmploymentInfoDetails(employmentInfoDetails);
        }

        private void btnEditPaymentDetails_Click(object sender, EventArgs e)
        {
            // Change the readonly settings of the section to be editted, and hide or show the sections save button respectively.
            txtPaymentDetailsNINumber.ReadOnly = !txtPaymentDetailsNINumber.ReadOnly;
            txtPaymentDetailsNILetter.ReadOnly = !txtPaymentDetailsNILetter.ReadOnly;
            txtPaymentDetailsTaxCode.ReadOnly = !txtPaymentDetailsTaxCode.ReadOnly;
            txtPaymentDetailsWorksNumber.ReadOnly = !txtPaymentDetailsWorksNumber.ReadOnly;
            btnSavePaymentDetails.Visible = !btnSavePaymentDetails.Visible;
        }

        private void btnSavePaymentDetails_Click(object sender, EventArgs e)
        {
            string[] paymentDetails = new string[5]; // [staffID, NINumber, NIletter, taxcode, worksnumber].
            paymentDetails[0] = txtEmploymentStaffID.Text.Trim();

            // National insurance number format check.
            if (txtPaymentDetailsNINumber.Text.Substring(0, 2).IndexOfAny("DFIQUV".ToCharArray()) == -1)
            {
                if (Regex.IsMatch(txtPaymentDetailsNINumber.Text.Trim(), @"^[a-zA-z][a-zA-z]\d{6}[a-zA-Z]$"))
                {
                    paymentDetails[1] = txtPaymentDetailsNINumber.Text.Trim();
                }
                else
                {
                    //----------Exception handling----------.
                    // Tell the user the issue with their nation insurance number format.
                    MessageBox.Show("National insurance number must be in the format 'AB123456C'");
                    return;
                }
            }
            else
            {
                //----------Exception handling----------.
                // Tell the user the issue with their national insurance number format.
                MessageBox.Show("The first 2 characters of a national insurance number cannot be 'D', 'F', 'I', 'Q', U' or 'V'.");
                return;
            }
            
            // NI Letter + Length Check + Character Check.
            if (txtPaymentDetailsNILetter.Text.ToString().Trim() != "")
            {
                char[] acceptableNILetters = { 'A', 'B', 'C', 'H', 'J', 'M', 'Z' };
                if (!(txtPaymentDetailsNILetter.Text.ToString().Trim().Length == 1 && char.IsLetter(txtPaymentDetailsNILetter.Text.ToString().Trim()[0])))
                {
                    MessageBox.Show("NI Letter must only be a single letter.");
                    return;
                }
                else if (!acceptableNILetters.Contains<char>(char.Parse(txtPaymentDetailsNILetter.Text.ToString())))
                {
                    MessageBox.Show("NI Letter must be one of ['A','B','C','H','J','M','Z']");
                    return;
                }
                paymentDetails[2] = txtPaymentDetailsNILetter.Text.ToString();
            }

            // Tax code format check.
            for (int index = 0; index<txtPaymentDetailsTaxCode.Text.Length; index++)
            {
                if (index == txtPaymentDetailsTaxCode.Text.Length - 1)
                {
                    if (!Char.IsLetter(txtPaymentDetailsTaxCode.Text[index]))
                    {
                        MessageBox.Show("Tax code must be in the format of a number followed by a letter.");
                        return;
                    }
                }
                else
                {
                    if (Char.IsLetter(txtPaymentDetailsTaxCode.Text[index]))
                    {
                        MessageBox.Show("Tax code must be in the format of a number followed by a letter.");
                        return;
                    }
                }
            }
            paymentDetails[3] = txtPaymentDetailsTaxCode.Text;

            // Works number has no unique format and is used by the employer for internal employee referencing.
            paymentDetails[4] = txtPaymentDetailsWorksNumber.Text;
            // Update the editted payment details using the staff controls public UpdatePaymentDetails function.
            parentForm.UpdatePaymentDetails(paymentDetails);
        }
    }
}
