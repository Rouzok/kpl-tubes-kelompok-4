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
        private void btnModeMencocokanKata_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni= AlurGame.MODE_MENCOCOKAN_KATA;
        }

        private void btnModeMemilihKata_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.MODE_MEMILIH_KATA;
        }

        private void btnModeGambar_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.MODE_GAMBAR;
        }
    }
}
