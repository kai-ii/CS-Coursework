using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Wpf;

namespace CSCoursework_Smiley
{
    public partial class StaffControlGraphs : UserControl
    {
        public void SetLineChartValues(double[] LineChartValues)
        {
            // Initialize taxmonths in an array and set the line chart label to be the hours worked.
            string[] months = { "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Jan", "Feb", "Mar" };
            string lineChartLabel = "Hours Worked";

            // Remove default/prev series.
            if (lineChartHoursWorked.Series.Count() == 1)
            {
                lineChartHoursWorked.Series.Remove(lineChartHoursWorked.Series[0]);
            }
            // Add new values
            if (months.Length == LineChartValues.Length)
            {
                lineChartHoursWorked.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(lineChartLabel));
                lineChartHoursWorked.Series[lineChartLabel].IsValueShownAsLabel = true;
                lineChartHoursWorked.Series[lineChartLabel].BorderWidth = 3;
                lineChartHoursWorked.Series[lineChartLabel].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                lineChartHoursWorked.Series[lineChartLabel].Points.DataBindXY(months, LineChartValues);
            }
        }

        public StaffControlGraphs()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        private void StaffControlGraphs_Load(object sender, EventArgs e)
        {
            // Nothing is done when this form is loaded since its only use is to display the data given to it. This form itself does no processing and doesn't handle any events.
        }

        public void UpdatePieChart(SeriesCollection newPieChartData)
        {
            // Update the pieChart with the given data.
            pieChart1.Series = newPieChartData;
            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
    }
}
