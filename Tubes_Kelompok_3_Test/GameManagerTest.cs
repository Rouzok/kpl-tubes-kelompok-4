using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_Kelompok_3;

namespace Tubes_Kelompok_3_Test
{
    [TestClass]
    public class GameManagerTest
    {
        [TestMethod]
        public void AlurSaatIni_Berubah()
        {
            GameManager.AlurSaatIni =
                AlurGame.MODE_GAMBAR;

            Assert.AreEqual(
                AlurGame.MODE_GAMBAR,
                GameManager.AlurSaatIni);
        }

        [TestMethod]
        public void AlurSaatIni_MainMenu()
        {
            GameManager.AlurSaatIni =
                AlurGame.MAIN_MENU;

            Assert.AreEqual(
                AlurGame.MAIN_MENU,
                GameManager.AlurSaatIni);
        }
    }
}