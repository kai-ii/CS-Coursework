namespace CSCoursework_Smiley
{
    partial class RotaControl
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
            this.RotaControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RotaControlButton
            // 
            this.RotaControlButton.Location = new System.Drawing.Point(453, 265);
            this.RotaControlButton.Name = "RotaControlButton";
            this.RotaControlButton.Size = new System.Drawing.Size(75, 23);
            this.RotaControlButton.TabIndex = 0;
            this.RotaControlButton.Text = "Rota";
            this.RotaControlButton.UseVisualStyleBackColor = true;
            // 
            // RotaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RotaControlButton);
            this.Name = "RotaControl";
            this.Size = new System.Drawing.Size(814, 636);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RotaControlButton;
    }
}
