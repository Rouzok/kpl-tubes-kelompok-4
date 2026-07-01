namespace Tubes_Kelompok_3
{
    public class MemilihKataScoreStrategy : IScoreStrategy
    {
        public int HitungScore(int currentScore, bool jawabanBenar)
        {
            return jawabanBenar
                ? currentScore + 1
                : currentScore - 1;
        }
    }
} 