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
    public partial class ModeMemilihKataLevel2 : UserControl
    {
        public ModeMemilihKataLevel2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.ScoreMemilihKataLevel2 = 10;

            // Update progress
            ProgressGame.ProgressMemilihKata =
                ProgressMemilihKata.LEVEL3;

            // Pindah state UI
            GameManager.AlurSaatIni =
                AlurGame.MODE_MEMILIHKATA_LEVEL3;
        }
    }
}