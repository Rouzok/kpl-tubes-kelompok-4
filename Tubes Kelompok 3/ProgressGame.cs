using System;

namespace Tubes_Kelompok_3
{
    public enum ProgressModeGambar
    {
        LOCKED,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        SELESAI
    }

    public enum ProgressMemilihKata
    {
        LOCKED,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        SELESAI
    }

    public enum ProgressMencocokanKata
    {
        LOCKED,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        SELESAI
    }

    public sealed class ProgressGame
    {
        // Singleton Instance
        private static ProgressGame instance;

        public static ProgressGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProgressGame();
                }
                return instance;
            }
        }

        // Private Constructor
        private ProgressGame()
        {
        }

        // PROGRESS MODE GAMBAR
        public ProgressModeGambar ProgressGambar =
            ProgressModeGambar.LEVEL1;

        // PROGRESS MODE MEMILIH KATA
        public ProgressMemilihKata ProgressMemilihKata =
            ProgressMemilihKata.LEVEL1;

        // PROGRESS MODE MENCOCOKAN KATA
        public ProgressMencocokanKata ProgressMencocokanKata =
            ProgressMencocokanKata.LEVEL1;

        // SCORE MODE GAMBAR
        public int ScoreModeGambarLevel1 = 0;
        public int ScoreModeGambarLevel2 = 0;
        public int ScoreModeGambarLevel3 = 0;

        // SCORE MODE MEMILIH KATA
        public int ScoreMemilihKataLevel1 = 0;
        public int ScoreMemilihKataLevel2 = 0;
        public int ScoreMemilihKataLevel3 = 0;

        // SCORE MODE MENCOCOKAN KATA
        public int ScoreMencocokanKataLevel1 = 0;
        public int ScoreMencocokanKataLevel2 = 0;
        public int ScoreMencocokanKataLevel3 = 0;

        
        // DRY MODE GAMBAR
        public void SetProgressModeGambar(
            int score,
            int level,
            ProgressModeGambar progressBaru,
            AlurGame alurBaru)
        {
            if (level == 1)
                ScoreModeGambarLevel1 = score;
            else if (level == 2)
                ScoreModeGambarLevel2 = score;
            else
                ScoreModeGambarLevel3 = score;

            ProgressGambar = progressBaru;
            GameManager.AlurSaatIni = alurBaru;
        }

        // DRY MEMILIH KATA
        public void SetProgressMemilihKata(
            int score,
            int level,
            ProgressMemilihKata progressBaru,
            AlurGame alurBaru)
        {
            if (level == 1)
                ScoreMemilihKataLevel1 = score;
            else if (level == 2)
                ScoreMemilihKataLevel2 = score;
            else
                ScoreMemilihKataLevel3 = score;

            ProgressMemilihKata = progressBaru;
            GameManager.AlurSaatIni = alurBaru;
        }

        // DRY MENCOCOKAN KATA
        public void SetProgressMencocokanKata(
            int score,
            int level,
            ProgressMencocokanKata progressBaru,
            AlurGame alurBaru)
        {
            if (level == 1)
                ScoreMencocokanKataLevel1 = score;
            else if (level == 2)
                ScoreMencocokanKataLevel2 = score;
            else
                ScoreMencocokanKataLevel3 = score;

            ProgressMencocokanKata = progressBaru;
            GameManager.AlurSaatIni = alurBaru;
        }

        // TOTAL SCORE
        public int TotalScoreModeGambar()
        {
            return ScoreModeGambarLevel1 +
                   ScoreModeGambarLevel2 +
                   ScoreModeGambarLevel3;
        }

        public int TotalScoreMemilihKata()
        {
            return ScoreMemilihKataLevel1 +
                   ScoreMemilihKataLevel2 +
                   ScoreMemilihKataLevel3;
        }

        public int TotalScoreMencocokanKata()
        {
            return ScoreMencocokanKataLevel1 +
                   ScoreMencocokanKataLevel2 +
                   ScoreMencocokanKataLevel3;
        }

        // VALIDASI SCORE
        public static bool IsValidScore(int score)
        {
            return score >= 0 && score <= 100;
        }
    }
}