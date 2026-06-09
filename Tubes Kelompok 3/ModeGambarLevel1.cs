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
            ProgressGame.Instance.SetProgressModeGambar(
                8,
                1,
                ProgressModeGambar.LEVEL2,
                AlurGame.MODE_GAMBAR_LEVEL2);
        }

    }
}
