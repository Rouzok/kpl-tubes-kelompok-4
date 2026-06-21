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
            ProgressGame.Instance.ScoreModeGambarLevel1 = 10;
            ProgressGame.Instance.ScoreModeGambarLevel2 = 20;
            ProgressGame.Instance.ScoreModeGambarLevel3 = 30;

            int total =
                ProgressGame.Instance.TotalScoreModeGambar();

            Assert.AreEqual(60, total);
        }

        [TestMethod]
        public void TotalScoreMemilihKata_Benar()
        {
            ProgressGame.Instance.ScoreMemilihKataLevel1 = 10;
            ProgressGame.Instance.ScoreMemilihKataLevel2 = 10;
            ProgressGame.Instance.ScoreMemilihKataLevel3 = 10;

            int total =
                ProgressGame.Instance.TotalScoreMemilihKata();

            Assert.AreEqual(30, total);
        }

        [TestMethod]
        public void TotalScoreMencocokan_Benar()
        {
            ProgressGame.Instance.ScoreMencocokanKataLevel1 = 5;
            ProgressGame.Instance.ScoreMencocokanKataLevel2 = 5;
            ProgressGame.Instance.ScoreMencocokanKataLevel3 = 5;

            int total =
                ProgressGame.Instance.TotalScoreMencocokanKata();

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