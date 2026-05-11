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
    public partial class ModeMencocokkanKataLevel2 : UserControl
    {
        public ModeMencocokkanKataLevel2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.ScoreMencocokanKataLevel2 = 10;

            // Update progress
            ProgressGame.ProgressMencocokanKata =
                ProgressMencocokanKata.LEVEL3;

            // Pindah state UI
            GameManager.AlurSaatIni =
                AlurGame.MODE_MENCOCOKKANKATA_LEVEL3;
        }
    }
}