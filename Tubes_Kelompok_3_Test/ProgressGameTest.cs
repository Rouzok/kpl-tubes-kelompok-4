using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_Kelompok_3;

namespace Tubes_Kelompok_3_Test
{
    [TestClass]
    public class ProgressGameTest
    {
        [TestMethod]
        public void TotalScoreModeGambar_Benar()
        {
            ProgressGame.ScoreModeGambarLevel1 = 10;
            ProgressGame.ScoreModeGambarLevel2 = 20;
            ProgressGame.ScoreModeGambarLevel3 = 30;

            int total =
                ProgressGame.TotalScoreModeGambar();

            Assert.AreEqual(60, total);
        }

        [TestMethod]
        public void TotalScoreMemilihKata_Benar()
        {
            ProgressGame.ScoreMemilihKataLevel1 = 10;
            ProgressGame.ScoreMemilihKataLevel2 = 10;
            ProgressGame.ScoreMemilihKataLevel3 = 10;

            int total =
                ProgressGame.TotalScoreMemilihKata();

            Assert.AreEqual(30, total);
        }

        [TestMethod]
        public void TotalScoreMencocokan_Benar()
        {
            ProgressGame.ScoreMencocokanKataLevel1 = 5;
            ProgressGame.ScoreMencocokanKataLevel2 = 5;
            ProgressGame.ScoreMencocokanKataLevel3 = 5;

            int total =
                ProgressGame.TotalScoreMencocokanKata();

            Assert.AreEqual(15, total);
        }

        [TestMethod]
        public void Score_Valid()
        {
            bool result =
                ProgressGame.IsValidScore(80);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Score_Invalid_Minus()
        {
            bool result =
                ProgressGame.IsValidScore(-1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Score_Invalid_Over100()
        {
            bool result =
                ProgressGame.IsValidScore(200);

            Assert.IsFalse(result);
        }
    }
}