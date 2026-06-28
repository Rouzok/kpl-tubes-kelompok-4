namespace Tubes_Kelompok_3
{
    partial class ModeGambarControl
    {
       
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnLevel1;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Label lblTitle;

      
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.pbQuestion = new System.Windows.Forms.PictureBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestion)).BeginInit();
            this.SuspendLayout();

            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(54, 98);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(73, 20);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "Question";
            this.lblQuestion.Click += new System.EventHandler(this.lblQuestion_Click);

            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(706, 98);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(72, 20);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score : 0";
            this.lblScore.Click += new System.EventHandler(this.lblScore_Click);

            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(549, 264);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(111, 35);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "CHECK";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            // 
            // pbQuestion
            // 
            this.pbQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbQuestion.Location = new System.Drawing.Point(58, 138);
            this.pbQuestion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbQuestion.Name = "pbQuestion";
            this.pbQuestion.Size = new System.Drawing.Size(388, 236);
            this.pbQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQuestion.TabIndex = 9;
            this.pbQuestion.TabStop = false;

            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(512, 207);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(183, 26);
            this.txtAnswer.TabIndex = 10;

            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(508, 98);
            this.lblAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(62, 20);
            this.lblAnswer.TabIndex = 11;
            this.lblAnswer.Text = "Answer";
            this.lblAnswer.Click += new System.EventHandler(this.lblAnswer_Click);

            // 
            // ModeGambarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.pbQuestion);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblQuestion);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "ModeGambarControl";
            this.Size = new System.Drawing.Size(1106, 795);
            this.Load += new System.EventHandler(this.ModeGambarControl_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.PictureBox pbQuestion;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lblAnswer;
    }
}




