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
    public partial class ModeGambarLevel1 : UserControl
    {
        public ModeGambarLevel1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.ScoreModeGambarLevel1 = 8;
            // Update progress
            ProgressGame.ProgressGambar =
                ProgressModeGambar.LEVEL2;

            // Pindah state UI
            GameManager.AlurSaatIni =
                AlurGame.MODE_GAMBAR_LEVEL2;
        }
        
    }
}
