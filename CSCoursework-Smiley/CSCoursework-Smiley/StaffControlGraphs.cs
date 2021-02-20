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
        //int[] lineChartValues = { 0 };

        //public int[] LineChartValues
        //{
        //    get { return lineChartValues; }
        //    set
        //    {
        //        // Remove default/prev series.
        //        if (lineChart1.Series.Count() == 1)
        //        {
        //            lineChart1.Series.Remove(lineChart1.Series[0]);
        //        }
        //        // Add new values
        //        if (months.Length == LineChartValues.Length)
        //        {
        //            lineChart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(lineChartLabel));
        //            lineChart1.Series[lineChartLabel].IsValueShownAsLabel = true;
        //            lineChart1.Series[lineChartLabel].BorderWidth = 3;
        //            lineChart1.Series[lineChartLabel].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //            lineChart1.Series[lineChartLabel].Points.DataBindXY(months, LineChartValues);
        //        }
        //    }
        //}
        public void SetLineChartValues(double[] LineChartValues)
        {
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
            InitializeComponent();
        }

        private void StaffControlGraphs_Load(object sender, EventArgs e)
        {
            
        }

        public void UpdatePieChart(SeriesCollection newPieChartData)
        {
            pieChart1.Series = newPieChartData;
            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void grpBoxLineGraph_Enter(object sender, EventArgs e)
        {

        }
    }
}
