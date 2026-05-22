using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics; //DBC
using static Tubes_Kelompok_3.HalamanRegistrasiControl;
using AuthLibrary; //Library

namespace Tubes_Kelompok_3
{
    public partial class HalamanLoginControl : UserControl
    {
        //Automata State
        enum LoginState
        {
            InputKosong,
            UsernameTidakValid,
            PasswordTidakValid,
            LoginBerhasil,
            LoginGagal
        }

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

                //DBC (Precondition)
                Debug.Assert(usernameLogin != null,
                    "Username tidak boleh null");

                Debug.Assert(passwordLogin != null,
                    "Password tidak boleh null");

                //Automata State
                LoginState state;

                //Library Validation
                if (ValidasiInput.IsEmpty(usernameLogin) ||
                    ValidasiInput.IsEmpty(passwordLogin))
                {
                    state = LoginState.InputKosong;

                    MessageBox.Show(
                        "Username dan Password tidak boleh kosong!"
                    );

                    return;
                }

                //Validasi Username
                if (!ValidasiInput.IsUsernameValid(usernameLogin))
                {
                    state = LoginState.UsernameTidakValid;

                    MessageBox.Show(
                        "Username minimal 5 karakter dan hanya boleh huruf atau angka!"
                    );

                    return;
                }

                //Password menggunakan char[]
                if (!ValidasiInput.IsPasswordValid(
                    passwordLogin.ToCharArray()))
                {
                    state = LoginState.PasswordTidakValid;

                    MessageBox.Show(
                        "Password minimal 6 karakter, mengandung huruf besar dan angka!"
                    );

                    return;
                }

                //Mencari User di List
                User userDitemukan =
                    HalamanRegistrasiControl.daftarUser.FirstOrDefault(
                        user =>
                            user.Username == usernameLogin &&
                            new string(user.Password) == passwordLogin
                    );

                //DBC (Postcondition)
                Debug.Assert(
                    HalamanRegistrasiControl.daftarUser != null,
                    "Daftar user tidak boleh null"
                );

                //State Login
                if (userDitemukan != null)
                {
                    state = LoginState.LoginBerhasil;

                    MessageBox.Show(
                        "Login berhasil!\nHalo " +
                        userDitemukan.NamaDepan + " " +
                        userDitemukan.NamaBelakang
                    );
                }
                else
                {
                    state = LoginState.LoginGagal;

                    MessageBox.Show(
                        "Username atau Password salah!"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi error : " + ex.Message
                );
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