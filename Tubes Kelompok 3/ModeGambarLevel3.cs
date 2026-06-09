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
    public partial class ModeGambarLevel3 : UserControl
    {
        public ModeGambarLevel3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.Instance.SetProgressModeGambar(
                15,
                3,
                ProgressModeGambar.SELESAI,
                AlurGame.MAIN_MENU);

            MessageBox.Show("Mode gambar selesai!");
        }
    }
}