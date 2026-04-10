namespace Tubes_Kelompok_3
{
    partial class PilihModeControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnModeMencocokanKata = new System.Windows.Forms.Button();
            this.btnModeGambar = new System.Windows.Forms.Button();
            this.btnModeMemilihKata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "PILIH GAMEMODE";
            // 
            // btnModeMencocokanKata
            // 
            this.btnModeMencocokanKata.Location = new System.Drawing.Point(71, 129);
            this.btnModeMencocokanKata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModeMencocokanKata.Name = "btnModeMencocokanKata";
            this.btnModeMencocokanKata.Size = new System.Drawing.Size(144, 28);
            this.btnModeMencocokanKata.TabIndex = 1;
            this.btnModeMencocokanKata.Text = "Mode Mencocokan Kata";
            this.btnModeMencocokanKata.UseVisualStyleBackColor = true;
            this.btnModeMencocokanKata.Click += new System.EventHandler(this.btnModeMencocokanKata_Click);
            // 
            // btnModeGambar
            // 
            this.btnModeGambar.Location = new System.Drawing.Point(71, 165);
            this.btnModeGambar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModeGambar.Name = "btnModeGambar";
            this.btnModeGambar.Size = new System.Drawing.Size(144, 28);
            this.btnModeGambar.TabIndex = 2;
            this.btnModeGambar.Text = "Mode Gambar";
            this.btnModeGambar.UseVisualStyleBackColor = true;
            this.btnModeGambar.Click += new System.EventHandler(this.btnModeGambar_Click);
            // 
            // btnModeMemilihKata
            // 
            this.btnModeMemilihKata.Location = new System.Drawing.Point(71, 201);
            this.btnModeMemilihKata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModeMemilihKata.Name = "btnModeMemilihKata";
            this.btnModeMemilihKata.Size = new System.Drawing.Size(144, 28);
            this.btnModeMemilihKata.TabIndex = 3;
            this.btnModeMemilihKata.Text = "Mode Memilih Kata";
            this.btnModeMemilihKata.UseVisualStyleBackColor = true;
            this.btnModeMemilihKata.Click += new System.EventHandler(this.btnModeMemilihKata_Click);
            // 
            // PilihModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnModeMencocokanKata);
            this.Controls.Add(this.btnModeGambar);
            this.Controls.Add(this.btnModeMemilihKata);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PilihModeControl";
            this.Size = new System.Drawing.Size(303, 271);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModeMencocokanKata;
        private System.Windows.Forms.Button btnModeGambar;
        private System.Windows.Forms.Button btnModeMemilihKata;
    }
}
