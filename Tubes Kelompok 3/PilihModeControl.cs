using System;
using System.Windows.Forms;
using Tubes_Kelompok_3.Library;

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
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_MENCOCOKKAN_KATA;
        }

        private void btnModeMemilihKata_Click(
            object sender,
            EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_MEMILIH_KATA;
        }

        private void btnModeGambar_Click(
            object sender,
            EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_GAMBAR;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (UserSession.Instance != null)
            {
                UserSession.Instance.CurrentUser = null;
            }

            GameManager.Instance.AlurSaatIni = AlurGame.HalamanLogin;
        }
    }
}