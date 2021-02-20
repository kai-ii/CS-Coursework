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
        // Initialise local class variables.
        OleDbConnection con;
        private Dashboard parentForm;

        public void SetParentForm(Dashboard ParentForm)
        {
            // Assign parent form with the Dashboard template
            parentForm = ParentForm;
        }
        public void SetCon(OleDbConnection Con)
        {
            // Assign the local connection string value to the already generated one, saving on processing since otherwise the database location would have to be grabbed multiple times.
            con = Con;
            // Initialize the form once the connection string has been assigned.
            InitializeForm();
        }
        private void InitializeForm()
        {
            // Setup locations.
            Point origin = new Point(0, 0);
            adminControlAddNewStaff1.Location = origin;
            adminControlManageEmployees1.Location = origin;
            adminControlCreateAnnouncement1.Location = origin;
            adminControlManageJobPositions1.Location = origin;

            // Setup parent child relationships and pass children the database connection string.
            InitializeParentChildRelationships();
            SetChildConnections();
        }
        private void SetChildConnections()
        {
            // Pass children database connection string.
            adminControlAddNewStaff1.SetCon(con);
            adminControlCreateAnnouncement1.SetCon(con);
            adminControlManageEmployees1.SetCon(con);
            adminControlManageJobPositions1.SetCon(con);
        }
        public AdminControl()
        {
            // Standard Form Initialize Component.
            InitializeComponent();
        }
        private void InitializeParentChildRelationships()
        {
            // Set this form to be the parent form for AddNewStaff and ManageJobPositions to allow them to use this form for function calls.
            adminControlAddNewStaff1.SetParentForm(this);
            adminControlManageJobPositions1.setParentForm(this);
        }

        public void UpdatePayslipJobPositions()
        {
            // When ManageJobPositions calls this, pass the request up to the dashboard form (background form).
            parentForm.UpdatePayslipJobPositions();
        }
        public void ResetControls()
        {
            // When any job position values are updated, other forms must be updated/reset so the request is passed to the dashboard form (background form).
            parentForm.ResetControls();
        }
        private void AdminControl_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            // When the new staff button is clicked, make the new staff form visible.
            adminControlAddNewStaff1.Visible = true;
        }

        private void btnAccountManagement_Click(object sender, EventArgs e)
        {
            // When the new account management button is clicked, make the account management form visible.
            adminControlManageEmployees1.Visible = true;
        }

        private void btnCreateAnnouncement_Click(object sender, EventArgs e)
        {
            // When the create announcement button is clicked, make the create announcement form visible.
            adminControlCreateAnnouncement1.Visible = true;
        }

        private void btnManageJobPositions_Click(object sender, EventArgs e)
        {
            // When the manage job position button is clicked, make the manage job position form visible.
            adminControlManageJobPositions1.Visible = true;
        }
    }
}
