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
    public partial class ModeMencocokanKataControl : UserControl
    {
        public ModeMencocokanKataControl()
        {
            InitializeComponent();

            if (ProgressGame.Instance.ProgressMencocokanKata ==
                ProgressMencocokanKata.LOCKED)
            {
                ProgressGame.Instance.ProgressMencocokanKata =
                    ProgressMencocokanKata.LEVEL1;
            }
        }

        private void btnMenuPilihMode_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
                AlurGame.MENU_PILIH_MODE;
        }

        private void btnLevel1_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
                AlurGame.MODE_MENCOCOKKANKATA_LEVEL1;
        }

        private void btnLevel2_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
                AlurGame.MODE_MENCOCOKKANKATA_LEVEL2;
        }

        private void btnLevel3_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
                AlurGame.MODE_MENCOCOKKANKATA_LEVEL3;
        }
    }
}