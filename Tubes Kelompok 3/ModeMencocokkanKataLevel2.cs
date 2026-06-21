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
    public partial class ModeMencocokkanKataLevel2 : UserControl
    {
        public ModeMencocokkanKataLevel2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressGame.Instance.SetProgressMencocokanKata(
                10,
                2,
                ProgressMencocokanKata.LEVEL3,
                AlurGame.MODE_MENCOCOKKANKATA_LEVEL3);
        }
    }
}