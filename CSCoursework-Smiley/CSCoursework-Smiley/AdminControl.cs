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

namespace CSCoursework_Smiley.Properties
{
    public partial class AdminControl : UserControl
    {
        OleDbConnection con;
        private Dashboard parentForm;

        public void SetParentForm(Dashboard ParentForm)
        {
            parentForm = ParentForm;
        }
        public void SetCon(OleDbConnection Con)
        {
            con = Con;
            InitializeForm();
        }
        private void InitializeForm()
        {
            // Setup locations
            Point origin = new Point(0, 0);
            adminControlAddNewStaff1.Location = origin;
            adminControlManageEmployees1.Location = origin;
            adminControlCreateAnnouncement1.Location = origin;
            adminControlManageJobPositions1.Location = origin;

            // Setup code things
            InitializeParentChildRelationships();
            SetChildConnections();
        }
        private void SetChildConnections()
        {
            adminControlAddNewStaff1.SetCon(con);
            adminControlCreateAnnouncement1.SetCon(con);
            adminControlManageEmployees1.SetCon(con);
            adminControlManageJobPositions1.SetCon(con);
        }
        public AdminControl()
        {
            InitializeComponent();
        }
        private void InitializeParentChildRelationships()
        {
            adminControlAddNewStaff1.SetParentForm(this);
            adminControlManageJobPositions1.setParentForm(this);
        }

        public void UpdatePayslipJobPositions()
        {
            parentForm.UpdatePayslipJobPositions();
        }
        public void ResetControls()
        {
            parentForm.ResetControls();
        }
        private void AdminControl_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            adminControlAddNewStaff1.Visible = true;
        }

        private void btnAccountManagement_Click(object sender, EventArgs e)
        {
            adminControlManageEmployees1.Visible = true;
        }

        private void btnCreateAnnouncement_Click(object sender, EventArgs e)
        {
            adminControlCreateAnnouncement1.Visible = true;
        }

        private void btnManageJobPositions_Click(object sender, EventArgs e)
        {
            adminControlManageJobPositions1.Visible = true;
        }
    }
}
