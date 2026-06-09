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
    public partial class ModeMencocokkanKataLevel3 : UserControl
    {
        public ModeMencocokkanKataLevel3()
        {
            InitializeComponent();
        }
        private void btnPilihMenuPilihMode_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MENU_PILIH_MODE;

        }
        private void btnLevel1_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MODE_GAMBAR_LEVEL1;
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MODE_GAMBAR_LEVEL2;
        }

        private void btnLevel3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.Instance.SetProgressMencocokanKata(
                15,
                3,
                ProgressMencocokanKata.SELESAI,
                AlurGame.MAIN_MENU);

            MessageBox.Show("Mode mencocokan kata selesai!");
        }
    }
}