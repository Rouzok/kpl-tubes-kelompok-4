namespace Tubes_Kelompok_3
{
    partial class ModeMencocokanKataControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLevel1;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Label lblTitle;

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

        private void InitializeComponent()
        {
            this.btnLevel1 = new System.Windows.Forms.Button();
            this.btnLevel2 = new System.Windows.Forms.Button();
            this.btnLevel3 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 25);
            this.lblTitle.Text = "Pilih Level Mencocokan Kata";

            // 
            // btnLevel1
            // 
            this.btnLevel1.Location = new System.Drawing.Point(100, 80);
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.Size = new System.Drawing.Size(120, 35);
            this.btnLevel1.Text = "Level 1";
            this.btnLevel1.UseVisualStyleBackColor = true;
            this.btnLevel1.Click += new System.EventHandler(this.btnLevel1_Click);

            // 
            // btnLevel2
            // 
            this.btnLevel2.Location = new System.Drawing.Point(100, 130);
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(120, 35);
            this.btnLevel2.Text = "Level 2";
            this.btnLevel2.UseVisualStyleBackColor = true;
            this.btnLevel2.Click += new System.EventHandler(this.btnLevel2_Click);

            // 
            // btnLevel3
            // 
            this.btnLevel3.Location = new System.Drawing.Point(100, 180);
            this.btnLevel3.Name = "btnLevel3";
            this.btnLevel3.Size = new System.Drawing.Size(120, 35);
            this.btnLevel3.Text = "Level 3";
            this.btnLevel3.UseVisualStyleBackColor = true;
            this.btnLevel3.Click += new System.EventHandler(this.btnLevel3_Click);

            // 
            // ModeMencocokanKataControl
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLevel1);
            this.Controls.Add(this.btnLevel2);
            this.Controls.Add(this.btnLevel3);
            this.Name = "ModeMencocokanKataControl";
            this.Size = new System.Drawing.Size(314, 284);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}