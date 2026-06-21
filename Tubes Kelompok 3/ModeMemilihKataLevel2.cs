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
            ProgressGame.Instance.SetProgressMemilihKata(
                10,
                2,
                ProgressMemilihKata.LEVEL3,
                AlurGame.MODE_MEMILIHKATA_LEVEL3);
        }
    }
}