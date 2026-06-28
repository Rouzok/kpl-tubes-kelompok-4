using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_Kelompok_3.Factory
{
    public class MainMenuFactory : GameFactory
    {
        public override UserControl CreateGameScreen()
        {
            return new MainMenuControl();
        }
    }
}