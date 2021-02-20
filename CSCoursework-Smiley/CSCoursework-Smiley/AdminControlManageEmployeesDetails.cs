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
    public partial class AdminControlManageEmployeesDetails : UserControl
    {
        // Initialise local class variables.
        private AdminControlManageEmployees parentForm;

        public void SetParentForm(AdminControlManageEmployees ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template AdminControlMangeEmployees which is passed in from the Admin Manage Employees control.
            parentForm = ParentForm;
        }
        public AdminControlManageEmployeesDetails()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        private void AdminControlManageEmployeesDetails_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since this form is updated based on values from the Admin Manage Employees control.
        }

        public void UpdateAccountDetails(string[] accountDetails)
        {
            // With the name and job position values given by the Admin Manage Employees control, update the corresponding labels on this control.
            lblForename.Text = accountDetails[0];
            lblSurname.Text = accountDetails[1];
            lblJobPosition.Text = accountDetails[2];
        }

        public void UpdatePermissionDetails(bool[] permissionDetails)
        {
            // With the permisison values given by the Admin Manage Employees control, update the corresponding permission labels on this control.
            checkBoxDashboardPermission.Checked = permissionDetails[0];
            checkBoxStaffPersonalPermission.Checked = permissionDetails[1];
            checkBoxStaffAllPermission.Checked = permissionDetails[2];
            checkBoxRotaPermission.Checked = permissionDetails[3];
            checkBoxTimesheetPermission.Checked = permissionDetails[4];
            checkBoxPayslipPermission.Checked = permissionDetails[5];
            checkBoxExportPermission.Checked = permissionDetails[6];
            // User has an account so remove the account not created warning.
            lblAccountNotCreatedWarning.Visible = false;
        }
        public void UpdatePermissionsAccountNotCreated()
        {
            // If the staff member doesn't have an account then show the account not yet created warning.
            lblAccountNotCreatedWarning.Visible = true;
        }

        private void btnSavePermissions_Click(object sender, EventArgs e)
        {
            // If account does not exist then return.
            if (lblAccountNotCreatedWarning.Visible) { MessageBox.Show("Cannot update an account that doesn't exist"); return; }
            // Create a permission array and fill it with the options selected (note admit cannot be given for security reasons).
            bool[] permissionArray = new bool[7];
            permissionArray[0] = checkBoxDashboardPermission.Checked;
            permissionArray[1] = checkBoxStaffPersonalPermission.Checked;
            permissionArray[2] = checkBoxStaffAllPermission.Checked;
            permissionArray[3] = checkBoxRotaPermission.Checked;
            permissionArray[4] = checkBoxTimesheetPermission.Checked;
            permissionArray[5] = checkBoxPayslipPermission.Checked;
            permissionArray[6] = checkBoxExportPermission.Checked;
            // Save it using the parent forms database connection.
            parentForm.SavePermissions(permissionArray);
        }
    }
}
