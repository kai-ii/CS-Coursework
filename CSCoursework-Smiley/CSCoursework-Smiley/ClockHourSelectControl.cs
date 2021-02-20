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
        string clockHoursSelected;
        bool pm = false;
        public ClockHourSelectControl()
        {
            InitializeComponent();
        }

        public string GetClockHoursSelected()
        {
            return clockHoursSelected;
        }
        private void ClockHourSelectControl_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxPM_CheckedChanged(object sender, EventArgs e)
        {
            confirmCheckBoxState();
        }

        private void confirmCheckBoxState()
        {
            if (checkBoxPM.Checked)
            {
                pm = true;
            }
            else
            {
                pm = false;
            }
        }

        public void checkButtons()
        {
            confirmCheckBoxState();
            if (rBtn01.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "13";
                }
                else
                {
                    clockHoursSelected = "01";
                }
            }
            if (rBtn02.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "14";
                }
                else
                {
                    clockHoursSelected = "02";
                }
            }
            if (rBtn03.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "15";
                }
                else
                {
                    clockHoursSelected = "03";
                }
            }
            if (rBtn04.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "16";
                }
                else
                {
                    clockHoursSelected = "04";
                }
            }
            if (rBtn05.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "17";
                }
                else
                {
                    clockHoursSelected = "05";
                }
            }
            if (rBtn06.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "18";
                }
                else
                {
                    clockHoursSelected = "06";
                }
            }
            if (rBtn07.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "19";
                }
                else
                {
                    clockHoursSelected = "07";
                }
            }
            if (rBtn08.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "20";
                }
                else
                {
                    clockHoursSelected = "08";
                }
            }
            if (rBtn09.Checked == true)
            {
                if (pm)
                {
                    clockHoursSelected = "21";
                }
                else
                {
                    clockHoursSelected = "09";
                }
            }
            if (rBtn10.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "22";
                }
                else
                {
                    clockHoursSelected = "10";
                }
            }
            if (rBtn11.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "23";
                }
                else
                {
                    clockHoursSelected = "11";
                }
            }
            if (rBtn12.Checked)
            {
                if (pm)
                {
                    clockHoursSelected = "00";
                }
                else
                {
                    clockHoursSelected = "12";
                }
            }
        }
    }
}
