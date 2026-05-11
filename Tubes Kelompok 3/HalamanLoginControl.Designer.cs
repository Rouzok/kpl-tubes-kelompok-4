namespace Tubes_Kelompok_3
{
    partial class HalamanLoginControl
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
            this.lbl_login = new System.Windows.Forms.Label();
            this.tb_username_login = new System.Windows.Forms.TextBox();
            this.tb_password_login = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_buat_akun = new System.Windows.Forms.Button();
            this.lbl_buat_akun = new System.Windows.Forms.Label();
            this.lbl_username_login = new System.Windows.Forms.Label();
            this.lbl_password_login = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(117, 91);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(127, 37);
            this.lbl_login.TabIndex = 0;
            this.lbl_login.Text = "LOGIN";
            this.lbl_login.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_username_login
            // 
            this.tb_username_login.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username_login.Location = new System.Drawing.Point(51, 204);
            this.tb_username_login.Name = "tb_username_login";
            this.tb_username_login.Size = new System.Drawing.Size(277, 28);
            this.tb_username_login.TabIndex = 1;
            this.tb_username_login.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tb_password_login
            // 
            this.tb_password_login.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password_login.Location = new System.Drawing.Point(51, 261);
            this.tb_password_login.Name = "tb_password_login";
            this.tb_password_login.Size = new System.Drawing.Size(277, 28);
            this.tb_password_login.TabIndex = 2;
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(124, 326);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 49);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_buat_akun
            // 
            this.btn_buat_akun.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buat_akun.Location = new System.Drawing.Point(124, 471);
            this.btn_buat_akun.Name = "btn_buat_akun";
            this.btn_buat_akun.Size = new System.Drawing.Size(120, 34);
            this.btn_buat_akun.TabIndex = 4;
            this.btn_buat_akun.Text = "Buat Akun";
            this.btn_buat_akun.UseVisualStyleBackColor = true;
            this.btn_buat_akun.Click += new System.EventHandler(this.btn_buat_akun_Click);
            // 
            // lbl_buat_akun
            // 
            this.lbl_buat_akun.AutoSize = true;
            this.lbl_buat_akun.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buat_akun.Location = new System.Drawing.Point(90, 439);
            this.lbl_buat_akun.Name = "lbl_buat_akun";
            this.lbl_buat_akun.Size = new System.Drawing.Size(202, 15);
            this.lbl_buat_akun.TabIndex = 5;
            this.lbl_buat_akun.Text = "Belum punya akun? Daftar sekarang.";
            this.lbl_buat_akun.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbl_username_login
            // 
            this.lbl_username_login.AutoSize = true;
            this.lbl_username_login.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username_login.Location = new System.Drawing.Point(48, 184);
            this.lbl_username_login.Name = "lbl_username_login";
            this.lbl_username_login.Size = new System.Drawing.Size(69, 17);
            this.lbl_username_login.TabIndex = 6;
            this.lbl_username_login.Text = "Username";
            this.lbl_username_login.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_password_login
            // 
            this.lbl_password_login.AutoSize = true;
            this.lbl_password_login.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password_login.Location = new System.Drawing.Point(48, 241);
            this.lbl_password_login.Name = "lbl_password_login";
            this.lbl_password_login.Size = new System.Drawing.Size(66, 17);
            this.lbl_password_login.TabIndex = 7;
            this.lbl_password_login.Text = "Password";
            // 
            // HalamanLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_password_login);
            this.Controls.Add(this.lbl_username_login);
            this.Controls.Add(this.lbl_buat_akun);
            this.Controls.Add(this.btn_buat_akun);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_password_login);
            this.Controls.Add(this.tb_username_login);
            this.Controls.Add(this.lbl_login);
            this.Name = "HalamanLoginControl";
            this.Size = new System.Drawing.Size(374, 533);
            this.Load += new System.EventHandler(this.HalamanLoginControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.TextBox tb_username_login;
        private System.Windows.Forms.TextBox tb_password_login;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_buat_akun;
        private System.Windows.Forms.Label lbl_buat_akun;
        private System.Windows.Forms.Label lbl_username_login;
        private System.Windows.Forms.Label lbl_password_login;
    }
}
