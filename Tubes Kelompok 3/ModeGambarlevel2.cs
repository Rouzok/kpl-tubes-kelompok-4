using System;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeGambarLevel2 : UserControl
    {
        public ModeGambarLevel2()
        {
            InitializeComponent();
        }

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            ProgressGame.ScoreModeGambarLevel2 = 10;

            ProgressGame.ProgressGambar =
                ProgressModeGambar.LEVEL3;

            GameManager.AlurSaatIni =
                AlurGame.MODE_GAMBAR_LEVEL3;
        }
    }
}