namespace Tubes_Kelompok_3
{
    partial class HalamanRegistrasiControl
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
            this.tb_nama_depan = new System.Windows.Forms.TextBox();
            this.tb_nama_belakang = new System.Windows.Forms.TextBox();
            this.tb_username_registrasi = new System.Windows.Forms.TextBox();
            this.tb_password_registrasi = new System.Windows.Forms.TextBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_nama_depan
            // 
            this.tb_nama_depan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nama_depan.Location = new System.Drawing.Point(38, 161);
            this.tb_nama_depan.Name = "tb_nama_depan";
            this.tb_nama_depan.Size = new System.Drawing.Size(260, 28);
            this.tb_nama_depan.TabIndex = 1;
            this.tb_nama_depan.Text = "Masukkan nama depan Anda";
            this.tb_nama_depan.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tb_nama_belakang
            // 
            this.tb_nama_belakang.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nama_belakang.Location = new System.Drawing.Point(38, 210);
            this.tb_nama_belakang.Name = "tb_nama_belakang";
            this.tb_nama_belakang.Size = new System.Drawing.Size(260, 28);
            this.tb_nama_belakang.TabIndex = 2;
            this.tb_nama_belakang.Text = "Masukkan nama belakang Anda";
            this.tb_nama_belakang.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tb_username_registrasi
            // 
            this.tb_username_registrasi.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username_registrasi.Location = new System.Drawing.Point(38, 264);
            this.tb_username_registrasi.Name = "tb_username_registrasi";
            this.tb_username_registrasi.Size = new System.Drawing.Size(260, 28);
            this.tb_username_registrasi.TabIndex = 3;
            this.tb_username_registrasi.Text = "Masukkan username Anda";
            this.tb_username_registrasi.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tb_password_registrasi
            // 
            this.tb_password_registrasi.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password_registrasi.Location = new System.Drawing.Point(38, 320);
            this.tb_password_registrasi.Name = "tb_password_registrasi";
            this.tb_password_registrasi.Size = new System.Drawing.Size(260, 28);
            this.tb_password_registrasi.TabIndex = 4;
            this.tb_password_registrasi.Text = "Masukkan password Anda";
            // 
            // btn_register
            // 
            this.btn_register.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.Location = new System.Drawing.Point(104, 385);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(130, 39);
            this.btn_register.TabIndex = 5;
            this.btn_register.Text = "REGISTER";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_registrasi_Click);
            // 
            // HalamanRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.tb_password_registrasi);
            this.Controls.Add(this.tb_username_registrasi);
            this.Controls.Add(this.tb_nama_belakang);
            this.Controls.Add(this.tb_nama_depan);
            this.Controls.Add(this.label1);
            this.Name = "HalamanRegister";
            this.Size = new System.Drawing.Size(333, 492);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_nama_depan;
        private System.Windows.Forms.TextBox tb_nama_belakang;
        private System.Windows.Forms.TextBox tb_username_registrasi;
        private System.Windows.Forms.TextBox tb_password_registrasi;
        private System.Windows.Forms.Button btn_register;
    }
}
