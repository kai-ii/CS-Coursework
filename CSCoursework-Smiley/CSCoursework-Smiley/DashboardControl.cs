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
    public partial class DashboardControl : UserControl
    {
        public string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                lblLoggedInAs.Text = $"Logged in as: {username}";
            }
        }
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
        }
    }
}
