using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public enum AlurGame { NULL, MAIN_MENU, MENU_PILIH_MODE, MODE_MEMILIH_KATA, MODE_GAMBAR, MODE_MENCOCOKAN_KATA}
    public static class GameManager
    {
        public static event Action<AlurGame> OnAlurChanged;
        private static AlurGame _alurSaatIni = AlurGame.NULL;
        public static AlurGame AlurSaatIni
        {
            get { return _alurSaatIni; }
            set
            {
                if (_alurSaatIni != value)
                {
                    _alurSaatIni = value;

                    OnAlurChanged?.Invoke(_alurSaatIni);
                }
            }
        }

    }
    //public class GameMode
    //{
    //    private string nama;
    //    private int level;
    //    private
    //}
}
