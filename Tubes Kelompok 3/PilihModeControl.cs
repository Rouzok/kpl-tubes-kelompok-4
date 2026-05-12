using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class PilihModeControl : UserControl
    {
        public PilihModeControl()
        {
            InitializeComponent();
        }

        private void btnModeMencocokanKata_Click(
            object sender,
            EventArgs e)
        {
            PasswordForm form =
                new PasswordForm("COCOK");

            form.ShowDialog();

            GameManager.AlurSaatIni =
                AlurGame.MODE_MENCOCOKAN_KATA;
        }

        private void btnModeMemilihKata_Click(
            object sender,
            EventArgs e)
        {
            PasswordForm form =
                new PasswordForm("KATA");

            form.ShowDialog();

            GameManager.AlurSaatIni =
                AlurGame.MODE_MEMILIH_KATA;
        }

        private void btnModeGambar_Click(
            object sender,
            EventArgs e)
        {
            PasswordForm form =
                new PasswordForm("GAMBAR");

            form.ShowDialog();

            GameManager.AlurSaatIni =
                AlurGame.MODE_GAMBAR;
        }
    }
}