namespace Tubes_Kelompok_3
{
    partial class ModeMemilihKataControl
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
            this.btnMenuPilihMode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMenuPilihMode
            // 
            this.btnMenuPilihMode.Location = new System.Drawing.Point(60, 111);
            this.btnMenuPilihMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMenuPilihMode.Name = "btnMenuPilihMode";
            this.btnMenuPilihMode.Size = new System.Drawing.Size(119, 28);
            this.btnMenuPilihMode.TabIndex = 0;
            this.btnMenuPilihMode.Text = "Main Menu";
            this.btnMenuPilihMode.UseVisualStyleBackColor = true;
            this.btnMenuPilihMode.Click += new System.EventHandler(this.btnMenuPilihMode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quiz Memilih Kata";
            // 
            // ModeMemilihKata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMenuPilihMode);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModeMemilihKata";
            this.Size = new System.Drawing.Size(200, 185);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenuPilihMode;
        private System.Windows.Forms.Label label1;
    }
}
