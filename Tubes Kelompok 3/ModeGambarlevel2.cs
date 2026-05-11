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
    public partial class ModeGambarlevel2 : UserControl
    {
        public ModeGambarlevel2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.ScoreModeGambarLevel2 = 10;
            ProgressGame.ProgressGambar =
             ProgressModeGambar.LEVEL3;

            GameManager.AlurSaatIni =
                AlurGame.MODE_GAMBAR_LEVEL3;
        }
    }
}