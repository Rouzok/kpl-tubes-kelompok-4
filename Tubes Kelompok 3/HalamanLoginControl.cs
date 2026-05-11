using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tubes_Kelompok_3.HalamanRegistrasiControl;
using AuthLibrary; //Library

namespace Tubes_Kelompok_3
{
    public partial class HalamanLoginControl : UserControl
    {
        public HalamanLoginControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                //Mengambil Inputan 
                string usernameLogin = tb_username_login.Text;
                string passwordLogin = tb_password_login.Text;

                //Defensive Programming 
                if (ValidasiInput.IsEmpty(usernameLogin)) //Library
                {
                    MessageBox.Show("Username tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsUsernameValid(usernameLogin)) //Library
                {
                    MessageBox.Show("Username minimal 5 karakter!");
                    return;
                }

                if (ValidasiInput.IsEmpty(passwordLogin)) //Library
                {
                    MessageBox.Show("Password tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsPasswordValid(passwordLogin)) //Library
                {
                    MessageBox.Show("Password minimal 6 karakter!");
                    return;
                }

                //Mencari User di Generic List
                User<string> userDitemukan =
                    HalamanRegistrasiControl.daftarUser.FirstOrDefault(
                        user =>
                            user.Username == usernameLogin &&
                            user.Password == passwordLogin
                    );

                //User Ditemukan
                if (userDitemukan != null)
                {
                    MessageBox.Show(
                        "Login berhasil!\nHalo " +
                        userDitemukan.NamaDepan + " " +
                        userDitemukan.NamaBelakang
                    );
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error : " + ex.Message);
            }
        }

        private void btn_buat_akun_Click(object sender, EventArgs e)
        {
            HalamanRegistrasiControl registerPage =
                new HalamanRegistrasiControl();

            this.Parent.Controls.Add(registerPage);

            registerPage.Dock = DockStyle.Fill;

            registerPage.BringToFront();

            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void HalamanLoginControl_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}