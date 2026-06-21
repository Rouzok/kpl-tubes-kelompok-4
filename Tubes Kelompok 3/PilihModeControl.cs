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
            GameManager.Instance.AlurSaatIni= AlurGame.MODE_MENCOCOKAN_KATA;
        }

        private void btnModeMemilihKata_Click(
            object sender,
            EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.MODE_MEMILIH_KATA;
        }

        private void btnModeGambar_Click(
            object sender,
            EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.MODE_GAMBAR;
        }
    }
}