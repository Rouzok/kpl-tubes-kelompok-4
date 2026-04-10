namespace Tubes_Kelompok_3
{
    partial class MainMenuControl
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
            this.main_menu = new System.Windows.Forms.Label();
            this.btnPilihMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // main_menu
            // 
            this.main_menu.AutoSize = true;
            this.main_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_menu.Location = new System.Drawing.Point(3, 15);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(147, 26);
            this.main_menu.TabIndex = 0;
            this.main_menu.Text = "MAIN MENU";
            // 
            // btnPilihMode
            // 
            this.btnPilihMode.Location = new System.Drawing.Point(26, 87);
            this.btnPilihMode.Name = "btnPilihMode";
            this.btnPilihMode.Size = new System.Drawing.Size(92, 23);
            this.btnPilihMode.TabIndex = 1;
            this.btnPilihMode.Text = "Pilih Gamemode";
            this.btnPilihMode.UseVisualStyleBackColor = true;
            this.btnPilihMode.Click += new System.EventHandler(this.btnPilihMode_Click);
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPilihMode);
            this.Controls.Add(this.main_menu);
            this.Name = "MainMenuControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label main_menu;
        private System.Windows.Forms.Button btnPilihMode;
    }
}
