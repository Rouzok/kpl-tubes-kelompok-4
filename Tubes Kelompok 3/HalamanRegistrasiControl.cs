using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using AuthLibrary; //Library
using System.Diagnostics; //DBC

namespace Tubes_Kelompok_3
{
    public partial class HalamanRegistrasiControl : UserControl
    {

        //Generic Class
        public class User<T>
        {
            public string NamaDepan { get; set; }
            public string NamaBelakang { get; set; }

            public T Username { get; set; }
            public T Password { get; set; }

            public User(string namaDepan, string namaBelakang, T username, T password)
            {
                NamaDepan = namaDepan;
                NamaBelakang = namaBelakang;
                Username = username;
                Password = password;
            }
        }

        //Generic List
        public static List<User<string>> daftarUser = new List<User<string>>();

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

                //Defensive Programming 
                if (ValidasiInput.IsEmpty(namaDepan)) //Library
                {
                    MessageBox.Show("Nama depan tidak boleh kosong!");
                    return;
                }
                if (!ValidasiInput.IsNameValid(namaDepan)) //Library
                {
                    MessageBox.Show("Nama depan hanya boleh huruf!");
                    return;
                }

                if (ValidasiInput.IsEmpty(namaBelakang)) //Library
                {
                    MessageBox.Show("Nama belakang tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsNameValid(namaBelakang)) //Library
                {
                    MessageBox.Show("Nama belakang hanya boleh huruf!");
                    return;
                }

                if (ValidasiInput.IsEmpty(usernameRegistrasi)) //Library
                {
                    MessageBox.Show("Username tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsUsernameValid(usernameRegistrasi)) //Library
                {
                    MessageBox.Show("Username minimal 5 karakter!");
                    return;
                }

                if (ValidasiInput.IsEmpty(passwordRegistrasi)) //Library
                {
                    MessageBox.Show("Password tidak boleh kosong!");
                    return;
                }

                if (!ValidasiInput.IsPasswordValid(passwordRegistrasi)) //Library
                {
                    MessageBox.Show("Password minimal 6 karakter!");
                    return;
                }


                //Membuat User Baru (Generic Type)
                User<string> userBaru = new User<string>(
                    namaDepan,
                    namaBelakang,
                    usernameRegistrasi,
                    passwordRegistrasi
                );

                //Menyimpan User Baru ke Generic List
                daftarUser.Add(userBaru);

                //DBC (Postcondition)
                Debug.Assert(
                    daftarUser.Contains(userBaru),
                    "User harus berhasil ditambahkan ke daftar user"
                );

                MessageBox.Show(
                    "Registrasi berhasil!\n" +
                    "Halo " + namaDepan + " " + namaBelakang
                );


                tb_nama_depan.Text = "";
                tb_nama_belakang.Text = "";
                tb_username_registrasi.Text = "";
                tb_password_registrasi.Text = "";

                //Berpindah ke HalamanLoginControl
                HalamanLoginControl loginPage = new HalamanLoginControl();

                this.Parent.Controls.Add(loginPage);

                loginPage.Dock = DockStyle.Fill;
                loginPage.BringToFront();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error : " + ex.Message);
            }
        }
    }
}
