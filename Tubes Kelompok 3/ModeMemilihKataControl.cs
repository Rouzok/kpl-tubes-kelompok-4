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
    public partial class ModeMemilihKataControl : UserControl
    {
        public ModeMemilihKataControl()
        {
            InitializeComponent();
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
                AlurGame.MODE_MEMILIHKATA_LEVEL1;
        }

        private void btnLevel2_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
                AlurGame.MODE_MEMILIHKATA_LEVEL2;
        }

        private void btnLevel3_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
                AlurGame.MODE_MEMILIHKATA_LEVEL3;
        }
    }
}