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
            this.grpBoxPieChart = new System.Windows.Forms.GroupBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.lineChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpBoxLineGraph.SuspendLayout();
            this.grpBoxPieChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxLineGraph
            // 
            this.grpBoxLineGraph.Controls.Add(this.lineChart1);
            this.grpBoxLineGraph.Location = new System.Drawing.Point(3, 3);
            this.grpBoxLineGraph.Name = "grpBoxLineGraph";
            this.grpBoxLineGraph.Size = new System.Drawing.Size(549, 288);
            this.grpBoxLineGraph.TabIndex = 1;
            this.grpBoxLineGraph.TabStop = false;
            this.grpBoxLineGraph.Text = "Line Graph";
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
            // lineChart1
            // 
            this.lineChart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.lineChart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.lineChart1.Legends.Add(legend1);
            this.lineChart1.Location = new System.Drawing.Point(6, 19);
            this.lineChart1.Name = "lineChart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.lineChart1.Series.Add(series1);
            this.lineChart1.Size = new System.Drawing.Size(537, 253);
            this.lineChart1.TabIndex = 0;
            this.lineChart1.Text = "chart1";
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
            this.grpBoxPieChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineChart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxLineGraph;
        private System.Windows.Forms.GroupBox grpBoxPieChart;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart1;
    }
}
