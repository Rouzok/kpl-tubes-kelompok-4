using System;
using System.Windows.Forms;
using Tubes_Kelompok_3.Library;

namespace Tubes_Kelompok_3
{
    public partial class PasswordForm : Form
    {
        private string mode;

        public PasswordForm(string mode)
        {
            InitializeComponent();

            this.mode = mode;

            lblMode.Text =
                "Mode : " + mode;
        }

        private void btnLogin_Click(
            object sender,
            EventArgs e)
        {
            string password =
                txtPassword.Text;

            try
            {
                bool valid =
                    PasswordValidator.Validate(
                        mode,
                        password);

                if (valid)
                {
                    MessageBox.Show(
                        "Password benar!");

                    this.Close();

                    // MODE GAMBAR

                    if (mode == "GAMBAR")
                    {
                        GameManager.AlurSaatIni =
                            AlurGame.MODE_GAMBAR_LEVEL1;
                    }

                    // MODE MEMILIH KATA

                    else if (mode == "KATA")
                    {
                        GameManager.AlurSaatIni =
                            AlurGame.MODE_MEMILIHKATA_LEVEL1;
                    }

                    // MODE MENCOCOKAN KATA

                    else if (mode == "COCOK")
                    {
                        GameManager.AlurSaatIni =
                            AlurGame.MODE_MENCOCOKKANKATA_LEVEL1;
                    }
                }

                else
                {
                    MessageBox.Show(
                        "Password salah!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}