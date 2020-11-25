using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCoursework_Smiley
{
    public partial class StaffControlDetails : UserControl
    {
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
                staffInfoDict.Add("staff_salaried_hours", value.Field<string>("staff_salaried_hours"));
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

        private void UpdateUserDetails()
        {
            lblAddressStreet.Text = staffInfoDict["staff_street"];
        }
    }
}
