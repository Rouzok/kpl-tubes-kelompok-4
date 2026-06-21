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
    public partial class ModeMemilihKataLevel1 : UserControl
    {
        public ModeMemilihKataLevel1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.Instance.SetProgressMemilihKata(
                8,
                1,
                ProgressMemilihKata.LEVEL2,
                AlurGame.MODE_MEMILIHKATA_LEVEL2);
        }
    }
}