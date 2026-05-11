using System;

namespace Tubes_Kelompok_3
{
    
    // ENUM PROGRESS MODE GAMBAR
    public enum ProgressModeGambar
    {
        LOCKED,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        SELESAI
    }

    // ENUM PROGRESS MEMILIH KATA
    public enum ProgressMemilihKata
    {
        LOCKED,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        SELESAI
    }

    // ENUM PROGRESS MENCOCOKAN KATA
    public enum ProgressMencocokanKata
    {
        LOCKED,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        SELESAI
    }

    // PROGRESS GAME MANAGER
    public static class ProgressGame
    {
        // PROGRESS LEVEL MODE GAMBAR
        public static ProgressModeGambar ProgressGambar =
            ProgressModeGambar.LEVEL1;

        // PROGRESS LEVEL MODE MEMILIH KATA
        public static ProgressMemilihKata ProgressMemilihKata =
            ProgressMemilihKata.LEVEL1;

        // PROGRESS LEVEL MODE MENCOCOKAN KATA
        public static ProgressMencocokanKata ProgressMencocokanKata =
            ProgressMencocokanKata.LEVEL1;

        // SCORE MODE GAMBAR
        public static int ScoreModeGambarLevel1 = 0;
        public static int ScoreModeGambarLevel2 = 0;
        public static int ScoreModeGambarLevel3 = 0;

        // SCORE MODE MEMILIH KATA
        public static int ScoreMemilihKataLevel1 = 0;
        public static int ScoreMemilihKataLevel2 = 0;
        public static int ScoreMemilihKataLevel3 = 0;

        // SCORE MODE MENCOCOKAN KATA
        public static int ScoreMencocokanKataLevel1 = 0;
        public static int ScoreMencocokanKataLevel2 = 0;
        public static int ScoreMencocokanKataLevel3 = 0;

        // TOTAL SCORE MODE GAMBAR
        public static int TotalScoreModeGambar()
        {
            return ScoreModeGambarLevel1 +
                   ScoreModeGambarLevel2 +
                   ScoreModeGambarLevel3;
        }

        // TOTAL SCORE MODE MEMILIH KATA
        public static int TotalScoreMemilihKata()
        {
            return ScoreMemilihKataLevel1 +
                   ScoreMemilihKataLevel2 +
                   ScoreMemilihKataLevel3;
        }

        // TOTAL SCORE MODE MENCOCOKAN KATA
        public static int TotalScoreMencocokanKata()
        {
            return ScoreMencocokanKataLevel1 +
                   ScoreMencocokanKataLevel2 +
                   ScoreMencocokanKataLevel3;
        }

        // DEFENSIVE PROGRAMMING VALIDASI SCORE
        public static bool IsValidScore(int score)
        {
            return score >= 0 && score <= 100;
        }
    }
}