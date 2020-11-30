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
            this.grpBoxLineGraph = new System.Windows.Forms.GroupBox();
            this.grpBoxPieChart = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpBoxLineGraph
            // 
            this.grpBoxLineGraph.Location = new System.Drawing.Point(3, 3);
            this.grpBoxLineGraph.Name = "grpBoxLineGraph";
            this.grpBoxLineGraph.Size = new System.Drawing.Size(549, 288);
            this.grpBoxLineGraph.TabIndex = 1;
            this.grpBoxLineGraph.TabStop = false;
            this.grpBoxLineGraph.Text = "Line Graph";
            // 
            // grpBoxPieChart
            // 
            this.grpBoxPieChart.Location = new System.Drawing.Point(3, 294);
            this.grpBoxPieChart.Name = "grpBoxPieChart";
            this.grpBoxPieChart.Size = new System.Drawing.Size(549, 288);
            this.grpBoxPieChart.TabIndex = 2;
            this.grpBoxPieChart.TabStop = false;
            this.grpBoxPieChart.Text = "Pie Chart";
            // 
            // StaffControlGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxPieChart);
            this.Controls.Add(this.grpBoxLineGraph);
            this.Name = "StaffControlGraphs";
            this.Size = new System.Drawing.Size(556, 585);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxLineGraph;
        private System.Windows.Forms.GroupBox grpBoxPieChart;
    }
}
