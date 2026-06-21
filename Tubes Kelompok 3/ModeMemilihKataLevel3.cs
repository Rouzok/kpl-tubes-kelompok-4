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
            ProgressGame.Instance.SetProgressMemilihKata(
                15,
                3,
                ProgressMemilihKata.SELESAI,
                AlurGame.MAIN_MENU);

            MessageBox.Show("Mode memilih kata selesai!");
        }
    }
}