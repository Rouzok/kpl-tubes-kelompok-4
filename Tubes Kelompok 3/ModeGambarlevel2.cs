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

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.Instance.SetProgressModeGambar(
                10,
                2,
                ProgressModeGambar.LEVEL3,
                AlurGame.MODE_GAMBAR_LEVEL3);
        }
    }
}