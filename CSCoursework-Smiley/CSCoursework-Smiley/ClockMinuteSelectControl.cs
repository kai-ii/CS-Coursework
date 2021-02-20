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
        // Initialise local class variables.
        string clockMinuteSelected;
        public ClockMinuteSelectControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        public string GetClockMinuteSelected()
        {
            // When requested by the rota control or the timesheet control, return the selected clock minute.
            return clockMinuteSelected;
        }

        private void rBtn00_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn00.Checked)
            {
                clockMinuteSelected = "00";
            }
        }private void rBtn05_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn05.Checked)
            {
                clockMinuteSelected = "05";
            }
        }
        private void rBtn10_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn10.Checked)
            {
                clockMinuteSelected = "10";
            }
        }
        private void rBtn15_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn15.Checked)
            {
                clockMinuteSelected = "15";
            }
        }
        private void rBtn20_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn20.Checked)
            {
                clockMinuteSelected = "20";
            }
        }
        private void rBtn25_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn25.Checked)
            {
                clockMinuteSelected = "25";
            }
        }
        private void rBtn30_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn30.Checked)
            {
                clockMinuteSelected = "30";
            }
        }
        private void rBtn35_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn35.Checked)
            {
                clockMinuteSelected = "35";
            }
        }
        private void rBtn40_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn40.Checked)
            {
                clockMinuteSelected = "40";
            }
        }
        private void rBtn45_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn45.Checked)
            {
                clockMinuteSelected = "45";
            }
        }
        private void rBtn50_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn50.Checked)
            {
                clockMinuteSelected = "50";
            }
        }
        private void rBtn55_CheckedChanged(object sender, EventArgs e)
        {
            // If this minute button is clicked, check if this btn is the one checked, if it is checked, set the selected minute to the corresponding value.
            if (rBtn55.Checked)
            {
                clockMinuteSelected = "55";
            }
        }
    }
}
