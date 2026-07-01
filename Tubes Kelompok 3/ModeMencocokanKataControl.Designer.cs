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
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.flpKiri = new System.Windows.Forms.FlowLayoutPanel();
            this.flpKanan = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "MODE MENCOCOKAN KATA";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(533, 63);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(77, 22);
            this.lblScore.TabIndex = 14;
            this.lblScore.Text = "Score: 0";
            // 
            // flpKiri
            // 
            this.flpKiri.Location = new System.Drawing.Point(147, 105);
            this.flpKiri.Name = "flpKiri";
            this.flpKiri.Size = new System.Drawing.Size(206, 371);
            this.flpKiri.TabIndex = 15;
            // 
            // flpKanan
            // 
            this.flpKanan.Location = new System.Drawing.Point(410, 105);
            this.flpKanan.Name = "flpKanan";
            this.flpKanan.Size = new System.Drawing.Size(211, 371);
            this.flpKanan.TabIndex = 16;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 27);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ModeMencocokanKataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.flpKanan);
            this.Controls.Add(this.flpKiri);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Name = "ModeMencocokanKataControl";
            this.Size = new System.Drawing.Size(705, 476);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.FlowLayoutPanel flpKiri;
        private System.Windows.Forms.FlowLayoutPanel flpKanan;
        private System.Windows.Forms.Button btnBack;
    }
}