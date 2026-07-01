namespace Tubes_Kelompok_3
{
    public class MencocokkanKataScoreStrategy : IScoreStrategy
    {
        public int HitungScore(int currentScore, bool jawabanBenar)
        {
            if (jawabanBenar)
                return currentScore + 1;

            return currentScore - 1;
        }
    }
}