namespace CSCoursework_Smiley
{
    partial class StaffControlGraphs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpBoxLineGraph = new System.Windows.Forms.GroupBox();
            this.lineChartHoursWorked = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpBoxPieChart = new System.Windows.Forms.GroupBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.grpBoxLineGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineChartHoursWorked)).BeginInit();
            this.grpBoxPieChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxLineGraph
            // 
            this.grpBoxLineGraph.Controls.Add(this.lineChartHoursWorked);
            this.grpBoxLineGraph.Location = new System.Drawing.Point(3, 3);
            this.grpBoxLineGraph.Name = "grpBoxLineGraph";
            this.grpBoxLineGraph.Size = new System.Drawing.Size(549, 288);
            this.grpBoxLineGraph.TabIndex = 1;
            this.grpBoxLineGraph.TabStop = false;
            this.grpBoxLineGraph.Text = "Line Graph";
            this.grpBoxLineGraph.Enter += new System.EventHandler(this.grpBoxLineGraph_Enter);
            // 
            // lineChartHoursWorked
            // 
            this.lineChartHoursWorked.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.lineChartHoursWorked.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.lineChartHoursWorked.Legends.Add(legend1);
            this.lineChartHoursWorked.Location = new System.Drawing.Point(6, 19);
            this.lineChartHoursWorked.Name = "lineChartHoursWorked";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.lineChartHoursWorked.Series.Add(series1);
            this.lineChartHoursWorked.Size = new System.Drawing.Size(537, 253);
            this.lineChartHoursWorked.TabIndex = 0;
            this.lineChartHoursWorked.Text = "hoursWorkedChart";
            // 
            // grpBoxPieChart
            // 
            this.grpBoxPieChart.Controls.Add(this.pieChart1);
            this.grpBoxPieChart.Location = new System.Drawing.Point(3, 294);
            this.grpBoxPieChart.Name = "grpBoxPieChart";
            this.grpBoxPieChart.Size = new System.Drawing.Size(549, 288);
            this.grpBoxPieChart.TabIndex = 2;
            this.grpBoxPieChart.TabStop = false;
            this.grpBoxPieChart.Text = "Pie Chart";
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(6, 13);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(537, 269);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "pieChartHoursWorked";
            // 
            // StaffControlGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxPieChart);
            this.Controls.Add(this.grpBoxLineGraph);
            this.Name = "StaffControlGraphs";
            this.Size = new System.Drawing.Size(556, 585);
            this.Load += new System.EventHandler(this.StaffControlGraphs_Load);
            this.grpBoxLineGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineChartHoursWorked)).EndInit();
            this.grpBoxPieChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxLineGraph;
        private System.Windows.Forms.GroupBox grpBoxPieChart;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChartHoursWorked;
    }
}
