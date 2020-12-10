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
    public partial class ClockHourSelectControl : UserControl
    {
        public string clockHoursSelected;
        public ClockHourSelectControl()
        {
            InitializeComponent();
        }

        private void rBtn01_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn01.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "13";
                }
                else
                {
                    clockHoursSelected = "01";
                }
            }
        }
        private void rBtn02_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn02.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "14";
                }
                else
                {
                    clockHoursSelected = "02";
                }
            }
        }
        private void rBtn03_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn03.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "15";
                }
                else
                {
                    clockHoursSelected = "03";
                }
            }
        }
        private void rBtn04_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn04.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "16";
                }
                else
                {
                    clockHoursSelected = "04";
                }
            }
        }
        private void rBtn05_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn05.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "17";
                }
                else
                {
                    clockHoursSelected = "05";
                }
            }
        }
        private void rBtn06_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn06.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "18";
                }
                else
                {
                    clockHoursSelected = "06";
                }
            }
        }
        private void rBtn07_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn07.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "19";
                }
                else
                {
                    clockHoursSelected = "07";
                }
            }
        }
        private void rBtn08_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn08.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "20";
                }
                else
                {
                    clockHoursSelected = "08";
                }
            }
        }
        private void rBtn09_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn09.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "21";
                }
                else
                {
                    clockHoursSelected = "09";
                }
            }
        }
        private void rBtn10_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn10.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "22";
                }
                else
                {
                    clockHoursSelected = "10";
                }
            }
        }
        private void rBtn11_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn11.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "23";
                }
                else
                {
                    clockHoursSelected = "11";
                }
            }
        }
        private void rBtn12_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn12.Checked)
            {
                if (checkBoxPM.Checked)
                {
                    clockHoursSelected = "24";
                }
                else
                {
                    clockHoursSelected = "12";
                }
            }
        }
    }
}
