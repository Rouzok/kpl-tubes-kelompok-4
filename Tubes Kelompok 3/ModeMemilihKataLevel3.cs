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
    public partial class ModeMemilihKataLevel3 : UserControl
    {
        public ModeMemilihKataLevel3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.ScoreMemilihKataLevel3 = 15;

            // Update progress
            ProgressGame.ProgressMemilihKata =
                ProgressMemilihKata.SELESAI;

            MessageBox.Show("Mode memilih kata selesai!");

            // Kembali ke menu utama
            GameManager.AlurSaatIni =
                AlurGame.MAIN_MENU;
        }
    }
}
