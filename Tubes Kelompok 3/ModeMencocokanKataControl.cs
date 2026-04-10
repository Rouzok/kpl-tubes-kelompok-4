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
    public partial class ModeMencocokanKataControl : UserControl
    {
        public ModeMencocokanKataControl()
        {
            InitializeComponent();
        }

        private void btnMenuPilihMode_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MENU_PILIH_MODE;
        }
    }
}
