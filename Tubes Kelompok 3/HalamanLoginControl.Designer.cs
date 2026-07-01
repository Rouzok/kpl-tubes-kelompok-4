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
            this.btn_registrasi2 = new System.Windows.Forms.Button();
            this.lbl_buat_akun = new System.Windows.Forms.Label();
            this.lbl_username_login = new System.Windows.Forms.Label();
            this.lbl_password_login = new System.Windows.Forms.Label();
            this.lbl_aplikasi_login = new System.Windows.Forms.Label();
            this.btn_show_password = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.ForeColor = System.Drawing.Color.Black;
            this.lbl_login.Location = new System.Drawing.Point(127, 114);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(107, 32);
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
            this.btn_login.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(118, 320);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 49);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_registrasi2
            // 
            this.btn_registrasi2.BackColor = System.Drawing.Color.OldLace;
            this.btn_registrasi2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registrasi2.ForeColor = System.Drawing.Color.Goldenrod;
            this.btn_registrasi2.Location = new System.Drawing.Point(101, 462);
            this.btn_registrasi2.Name = "btn_registrasi2";
            this.btn_registrasi2.Size = new System.Drawing.Size(154, 46);
            this.btn_registrasi2.TabIndex = 4;
            this.btn_registrasi2.Text = "REGISTRASI";
            this.btn_registrasi2.UseVisualStyleBackColor = false;
            this.btn_registrasi2.Click += new System.EventHandler(this.btn_buat_akun_Click);
            // 
            // lbl_buat_akun
            // 
            this.lbl_buat_akun.AutoSize = true;
            this.lbl_buat_akun.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buat_akun.Location = new System.Drawing.Point(90, 434);
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
            this.lbl_username_login.ForeColor = System.Drawing.Color.Black;
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
            // lbl_aplikasi_login
            // 
            this.lbl_aplikasi_login.AutoSize = true;
            this.lbl_aplikasi_login.BackColor = System.Drawing.Color.OldLace;
            this.lbl_aplikasi_login.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aplikasi_login.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl_aplikasi_login.Location = new System.Drawing.Point(79, 23);
            this.lbl_aplikasi_login.Name = "lbl_aplikasi_login";
            this.lbl_aplikasi_login.Size = new System.Drawing.Size(204, 22);
            this.lbl_aplikasi_login.TabIndex = 8;
            this.lbl_aplikasi_login.Text = "EduEnglish Quiz";
            // 
            // btn_show_password
            // 
            this.btn_show_password.BackColor = System.Drawing.Color.OldLace;
            this.btn_show_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_password.Location = new System.Drawing.Point(334, 261);
            this.btn_show_password.Name = "btn_show_password";
            this.btn_show_password.Size = new System.Drawing.Size(29, 31);
            this.btn_show_password.TabIndex = 14;
            this.btn_show_password.Text = "👁";
            this.btn_show_password.UseVisualStyleBackColor = false;
            this.btn_show_password.Click += new System.EventHandler(this.btn_show_password_Click);
            // 
            // HalamanLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.btn_show_password);
            this.Controls.Add(this.lbl_aplikasi_login);
            this.Controls.Add(this.lbl_password_login);
            this.Controls.Add(this.lbl_username_login);
            this.Controls.Add(this.lbl_buat_akun);
            this.Controls.Add(this.btn_registrasi2);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_password_login);
            this.Controls.Add(this.tb_username_login);
            this.Controls.Add(this.lbl_login);
            this.Name = "HalamanLoginControl";
            this.Size = new System.Drawing.Size(374, 600);
            this.Load += new System.EventHandler(this.HalamanLoginControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.TextBox tb_username_login;
        private System.Windows.Forms.TextBox tb_password_login;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_registrasi2;
        private System.Windows.Forms.Label lbl_buat_akun;
        private System.Windows.Forms.Label lbl_username_login;
        private System.Windows.Forms.Label lbl_password_login;
        private System.Windows.Forms.Label lbl_aplikasi_login;
        private System.Windows.Forms.Button btn_show_password;
    }
}
