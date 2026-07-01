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
        private bool isPasswordVisible = false;

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
            tb_password_login.UseSystemPasswordChar = true;
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
                User userDitemukan = DatabaseSingleton.GetInstance().Login(usernameLogin, passwordLogin);

                //State Login
                if (userDitemukan != null)
                {
                    state = LoginState.LoginBerhasil;

                    //Singleton Pattern
                    UserSession.Instance.CurrentUser =
                        userDitemukan;

                    MessageBox.Show(
                        "Login berhasil!\nHalo " +
                        userDitemukan.NamaDepan + " " +
                        userDitemukan.NamaBelakang,
                        "Status Autentikasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    GameManager.Instance.AlurSaatIni = AlurGame.MAIN_MENU;
                }
                else
                {
                    state = LoginState.LoginGagal;

                    MessageBox.Show(
                        "Username atau Password salah!"
                    );
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan saat login."
                );
            }

        }

        private void btn_buat_akun_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.HalamanRegistrasi;
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

        private void btn_show_password_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            tb_password_login.UseSystemPasswordChar = !isPasswordVisible;

            btn_show_password.Text = isPasswordVisible ? "👁" : "👁";
        }
    }
}