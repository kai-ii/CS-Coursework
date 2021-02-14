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
        public AdminControlManageEmployeesDetails()
        {
            InitializeComponent();
        }

        private void AdminControlManageEmployeesDetails_Load(object sender, EventArgs e)
        {

        }

        public void UpdateAccountDetails(string[] accountDetails)
        {
            lblForename.Text = accountDetails[0];
            lblSurname.Text = accountDetails[1];
            lblJobPosition.Text = accountDetails[2];
        }

        public void UpdatePermissionDetails(bool[] permissionDetails)
        {
            checkBoxDashboardPermission.Checked = permissionDetails[0];
            checkBoxStaffPersonalPermission.Checked = permissionDetails[1];
            checkBoxStaffAllPermission.Checked = permissionDetails[2];
            checkBoxRotaPermission.Checked = permissionDetails[3];
            checkBoxTimesheetPermission.Checked = permissionDetails[4];
            checkBoxPayslipPermission.Checked = permissionDetails[5];
            checkBoxExportPermission.Checked = permissionDetails[6];
            lblAccountNotCreatedWarning.Visible = false;
        }
        public void UpdatePermissionsAccountNotCreated()
        {
            lblAccountNotCreatedWarning.Visible = true;
        }
    }
}
