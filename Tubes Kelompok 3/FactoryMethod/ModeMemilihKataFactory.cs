using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public class ModeMemilihKataFactory : GameFactory
    {
        public override UserControl CreateGame()
        {
            return new ModeMemilihKataControl();
        }
    }
}