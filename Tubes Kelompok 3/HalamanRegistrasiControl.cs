using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AuthLibrary; //Library
using System.Diagnostics; //DBC

namespace Tubes_Kelompok_3
{
    public partial class HalamanRegistrasiControl : UserControl
    {
        //Automata
        public enum RegisterState
        {
            RegistrasiBerhasil,
            RegistrasiGagal
        }


        public HalamanRegistrasiControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.HalamanLogin;
        }

        private void btn_registrasi_Click(object sender, EventArgs e)
        {
            try
            {
                //Mengambil Inputan
                string namaDepan = tb_nama_depan.Text;
                string namaBelakang = tb_nama_belakang.Text;
                string usernameRegistrasi = tb_username_registrasi.Text;
                string passwordRegistrasi = tb_password_registrasi.Text;

                //DBC (Precondition)
                Debug.Assert(namaDepan != null,
                    "Nama depan tidak boleh null");

                Debug.Assert(namaBelakang != null,
                    "Nama belakang tidak boleh null");

                Debug.Assert(usernameRegistrasi != null,
                    "Username tidak boleh null");

                Debug.Assert(passwordRegistrasi != null,
                    "Password tidak boleh null");

                //Defensive Programming dan Library

                //Validasi Nama Depan
                if (ValidasiInput.IsEmpty(namaDepan))
                {
                    MessageBox.Show(
                        "Nama depan tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsNameValid(
                    namaDepan.ToCharArray()))
                {
                    MessageBox.Show(
                        "Nama depan hanya boleh huruf!");
                    return;
                }

                //Validasi Nama Belakang
                if (ValidasiInput.IsEmpty(namaBelakang))
                {
                    MessageBox.Show(
                        "Nama belakang tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsNameValid(
                    namaBelakang.ToCharArray()))
                {
                    MessageBox.Show(
                        "Nama belakang hanya boleh huruf!");
                    return;
                }

                //Validasi Username
                if (ValidasiInput.IsEmpty(usernameRegistrasi))
                {
                    MessageBox.Show(
                        "Username tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsUsernameValid(
                    usernameRegistrasi))
                {
                    MessageBox.Show(
                        "Username minimal 5 karakter dan hanya boleh huruf atau angka!");
                    return;
                }

                //Validasi Password
                if (ValidasiInput.IsEmpty(passwordRegistrasi))
                {
                    MessageBox.Show(
                        "Password tidak boleh kosong!");
                    return;
                }

                //Password menggunakan char[]
                if (!ValidasiInput.IsPasswordValid(
                    passwordRegistrasi.ToCharArray()))
                {
                    MessageBox.Show(
                        "Password minimal 6 karakter, mengandung huruf besar dan angka!");
                    return;
                }

                // Eksekusi fungsi dan evaluasi hasil komputasi basis data
                bool registrasiBerhasil = DatabaseSingleton.GetInstance().Register(
                    usernameRegistrasi,
                    passwordRegistrasi,
                    namaDepan,
                    namaBelakang
                );

                if (registrasiBerhasil)
                {
                    // Automata 
                    RegisterState state = RegisterState.RegistrasiBerhasil;

                    MessageBox.Show(
                        "Registrasi berhasil!\n" +
                        "Halo " + namaDepan + " " + namaBelakang,
                        "Status Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );

                    // Instruksi pembersihan (Disposal) pada input setelah sukses
                    tb_nama_depan.Text = "";
                    tb_nama_belakang.Text = "";
                    tb_username_registrasi.Text = "";
                    tb_password_registrasi.Text = "";

                    // Transisi Alur Permainan
                    GameManager.Instance.AlurSaatIni = AlurGame.HalamanLogin;
                }
                else
                {
                    // Automata
                    RegisterState state = RegisterState.RegistrasiGagal;

                    MessageBox.Show(
                        "Username telah terdaftar. Silakan gunakan username lain.",
                        "Registrasi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception){
                //Automata
                RegisterState state = RegisterState.RegistrasiGagal;
                MessageBox.Show("Terjadi kesalahan saat registrasi.");
            }

        }
    }
}