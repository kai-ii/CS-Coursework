using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCoursework_Smiley.Properties
{
    public partial class AdminControl : UserControl
    {
        public Dashboard parentForm { get; set; }
        public int userID { get; set; }
        public AdminControl()
        {
            InitializeComponent();
        }
        private void PassUserID()
        {
            adminControlManageEmployees1.userID = userID;
        }
        private void InitializeParentChildRelationships()
        {
            adminControlAddNewStaff1.parentForm = this;
        }

        public void ResetControls()
        {
            parentForm.ResetControls();
        }
        private void AdminControl_Load(object sender, EventArgs e)
        {
            // Setup locations
            Point origin = new Point(0,0);
            adminControlAddNewStaff1.Location = origin;
            adminControlManageEmployees1.Location = origin;

            // Setup code things
            InitializeParentChildRelationships();
            PassUserID();
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

        }

        private void btnManageJobPositions_Click(object sender, EventArgs e)
        {

        }

        
    }
}
