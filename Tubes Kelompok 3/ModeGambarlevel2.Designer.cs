namespace Tubes_Kelompok_3
{
    partial class ModeGambarLevel2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.label1 =
                new System.Windows.Forms.Label();

            this.button1 =
                new System.Windows.Forms.Button();

            this.SuspendLayout();

            // label1

            this.label1.AutoSize = true;

            this.label1.Location =
                new System.Drawing.Point(52, 28);

            this.label1.Name = "label1";

            this.label1.Size =
                new System.Drawing.Size(42, 13);

            this.label1.TabIndex = 0;

            this.label1.Text = "Level 2";

            // button1

            this.button1.Location =
                new System.Drawing.Point(44, 87);

            this.button1.Name = "button1";

            this.button1.Size =
                new System.Drawing.Size(75, 23);

            this.button1.TabIndex = 1;

            this.button1.Text = "Submit";

            this.button1.UseVisualStyleBackColor = true;

            this.button1.Click +=
                new System.EventHandler(
                    this.button1_Click);

            // ModeGambarLevel2

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);

            this.Name = "ModeGambarLevel2";

            this.Size =
                new System.Drawing.Size(300, 200);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}