namespace CSCoursework_Smiley
{
    partial class AdminControlManageJobPositions
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
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveJobPositions = new System.Windows.Forms.Button();
            this.jobPositionDataGrid = new System.Windows.Forms.DataGridView();
            this.JobPositionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobPositionWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobPositionDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jobPositionDataGrid);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 522);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Job Positions";
            // 
            // btnSaveJobPositions
            // 
            this.btnSaveJobPositions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveJobPositions.Location = new System.Drawing.Point(694, 560);
            this.btnSaveJobPositions.Name = "btnSaveJobPositions";
            this.btnSaveJobPositions.Size = new System.Drawing.Size(114, 37);
            this.btnSaveJobPositions.TabIndex = 14;
            this.btnSaveJobPositions.Text = "Save";
            this.btnSaveJobPositions.UseVisualStyleBackColor = true;
            this.btnSaveJobPositions.Click += new System.EventHandler(this.btnSaveJobPositions_Click);
            // 
            // jobPositionDataGrid
            // 
            this.jobPositionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobPositionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobPositionID,
            this.JobPositionName,
            this.JobPositionWage});
            this.jobPositionDataGrid.Location = new System.Drawing.Point(6, 30);
            this.jobPositionDataGrid.Name = "jobPositionDataGrid";
            this.jobPositionDataGrid.Size = new System.Drawing.Size(796, 486);
            this.jobPositionDataGrid.TabIndex = 0;
            this.jobPositionDataGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.jobPositionDataGrid_UserAddedRow);
            // 
            // JobPositionID
            // 
            this.JobPositionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.JobPositionID.HeaderText = "Job Position ID";
            this.JobPositionID.Name = "JobPositionID";
            // 
            // JobPositionName
            // 
            this.JobPositionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.JobPositionName.HeaderText = "Job Position Name";
            this.JobPositionName.Name = "JobPositionName";
            // 
            // JobPositionWage
            // 
            this.JobPositionWage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.JobPositionWage.HeaderText = "JobPositionWage";
            this.JobPositionWage.Name = "JobPositionWage";
            // 
            // AdminControlManageJobPositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveJobPositions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Name = "AdminControlManageJobPositions";
            this.Size = new System.Drawing.Size(814, 636);
            this.Load += new System.EventHandler(this.AdminControlManageJobPositions_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jobPositionDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveJobPositions;
        private System.Windows.Forms.DataGridView jobPositionDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobPositionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobPositionWage;
    }
}
