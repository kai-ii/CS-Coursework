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
    public partial class ClockMinuteSelectControl : UserControl
    {
        string clockMinuteSelected;
        public ClockMinuteSelectControl()
        {
            InitializeComponent();
        }

        public string GetClockMinuteSelected()
        {
            return clockMinuteSelected;
        }

        private void rBtn00_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn00.Checked)
            {
                clockMinuteSelected = "00";
            }
        }private void rBtn05_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn05.Checked)
            {
                clockMinuteSelected = "05";
            }
        }
        private void rBtn10_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn10.Checked)
            {
                clockMinuteSelected = "10";
            }
        }
        private void rBtn15_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn15.Checked)
            {
                clockMinuteSelected = "15";
            }
        }
        private void rBtn20_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn20.Checked)
            {
                clockMinuteSelected = "20";
            }
        }
        private void rBtn25_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn25.Checked)
            {
                clockMinuteSelected = "25";
            }
        }
        private void rBtn30_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn30.Checked)
            {
                clockMinuteSelected = "30";
            }
        }
        private void rBtn35_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn35.Checked)
            {
                clockMinuteSelected = "35";
            }
        }
        private void rBtn40_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn40.Checked)
            {
                clockMinuteSelected = "40";
            }
        }
        private void rBtn45_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn45.Checked)
            {
                clockMinuteSelected = "45";
            }
        }
        private void rBtn50_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn50.Checked)
            {
                clockMinuteSelected = "50";
            }
        }
        private void rBtn55_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn55.Checked)
            {
                clockMinuteSelected = "55";
            }
        }

        private void rBtn05_CheckedChaged_1(object sender, EventArgs e)
        {

        }
    }
}
