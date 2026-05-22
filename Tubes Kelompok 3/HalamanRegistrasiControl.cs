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
        //Automata / State-Based
        public enum RegisterState
        {
            RegistrasiBerhasil,
            RegistrasiGagal
        }

        //Class User
        public class User
        {
            public string NamaDepan { get; set; }
            public string NamaBelakang { get; set; }

            public string Username { get; set; }
            public char[] Password { get; set; }

            public User(
                string namaDepan,
                string namaBelakang,
                string username,
                char[] password)
            {
                NamaDepan = namaDepan;
                NamaBelakang = namaBelakang;
                Username = username;
                Password = password;
            }
        }

        //List User
        public static List<User> daftarUser = new List<User>();

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

                //Membuat User Baru
                User userBaru = new User(
                    namaDepan,
                    namaBelakang,
                    usernameRegistrasi,
                    passwordRegistrasi.ToCharArray()
                );

                //Menyimpan User ke List
                daftarUser.Add(userBaru);

                //DBC (Postcondition)
                Debug.Assert(
                    daftarUser.Contains(userBaru),
                    "User harus berhasil ditambahkan");

                //Automata 
                RegisterState state =
                    RegisterState.RegistrasiBerhasil;

                MessageBox.Show(
                    "Registrasi berhasil!\n" +
                    "Halo " +
                    namaDepan + " " +
                    namaBelakang
                );

                //Reset TextBox
                tb_nama_depan.Text = "";
                tb_nama_belakang.Text = "";
                tb_username_registrasi.Text = "";
                tb_password_registrasi.Text = "";

                //Berpindah ke Halaman Login
                HalamanLoginControl loginPage =
                    new HalamanLoginControl();

                this.Parent.Controls.Add(loginPage);

                loginPage.Dock = DockStyle.Fill;

                loginPage.BringToFront();

                this.Hide();
            }
            catch (Exception ex)
            {
                //Automata
                RegisterState state =
                    RegisterState.RegistrasiGagal;

                MessageBox.Show(
                    "Terjadi error : " + ex.Message);
            }
        }
    }
}