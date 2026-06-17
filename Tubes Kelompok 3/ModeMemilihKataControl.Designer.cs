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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.flpWordContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Select the real English words in this list";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(0, 440);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(400, 60);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // flpWordContainer
            // 
            this.flpWordContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWordContainer.Location = new System.Drawing.Point(0, 60);
            this.flpWordContainer.Name = "flpWordContainer";
            this.flpWordContainer.Padding = new System.Windows.Forms.Padding(15);
            this.flpWordContainer.Size = new System.Drawing.Size(400, 380);
            this.flpWordContainer.TabIndex = 2;
            // 
            // ModeMemilihKataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpWordContainer);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblTitle);
            this.Name = "ModeMemilihKataControl";
            this.Size = new System.Drawing.Size(400, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSubmit;
        public System.Windows.Forms.FlowLayoutPanel flpWordContainer;
    }
}
