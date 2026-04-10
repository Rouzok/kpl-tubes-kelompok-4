namespace Tubes_Kelompok_3
{
    partial class ModeGambarControl
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
            this.btnPilihMenuPilihMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPilihMenuPilihMode
            // 
            this.btnPilihMenuPilihMode.Location = new System.Drawing.Point(16, 61);
            this.btnPilihMenuPilihMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnPilihMenuPilihMode.Name = "btnPilihMenuPilihMode";
            this.btnPilihMenuPilihMode.Size = new System.Drawing.Size(119, 28);
            this.btnPilihMenuPilihMode.TabIndex = 1;
            this.btnPilihMenuPilihMode.Text = "Main Menu";
            this.btnPilihMenuPilihMode.UseVisualStyleBackColor = true;
            this.btnPilihMenuPilihMode.Click += new System.EventHandler(this.btnPilihMenuPilihMode_Click);
            // 
            // ModeGambar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPilihMenuPilihMode);
            this.Name = "ModeGambar";
            this.Size = new System.Drawing.Size(418, 349);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPilihMenuPilihMode;
    }
}
