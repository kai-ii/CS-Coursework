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
        // Initialise local class variables.
        string clockHoursSelected;
        bool pm = false;
        public ClockHourSelectControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        public string GetClockHoursSelected()
        {
            // When requested by the rota control or the timesheet control, return the selected clock hour.
            return clockHoursSelected;
        }
        private void ClockHourSelectControl_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since this form only only performs its functions when being used by another form as a custom control.
        }

        private void checkBoxPM_CheckedChanged(object sender, EventArgs e)
        {
            // If the pm checkbox is changed, ensure that the pm bool is set to the correct value.
            confirmCheckBoxState();
        }

        private void confirmCheckBoxState()
        {
            // Set the pm bool to the value of checkBoxPM.Checked.
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
            // This is called to set the value of clockHoursSelected when it is required before it is grabbed by the function "GetClockHoursSelected".
            confirmCheckBoxState();
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
            // If this hour button is clicked, check if pm is true. If it is true then return the pm version of the number in 24 hour format.
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
