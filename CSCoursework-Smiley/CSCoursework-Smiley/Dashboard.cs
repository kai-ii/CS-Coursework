using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCoursework_Smiley
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SmileyLogo.Image = Properties.Resources.SmileyImage;
            btnExitDashboard.Image = Properties.Resources.Close_Button;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
