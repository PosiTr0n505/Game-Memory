using MemoryLib.Models;

namespace MemoryLib.Managers

{
    public class ScoreManager(Score? score, Leaderboard? leaderboard) : IScoreManager
    {
        private readonly Score? score = score;
        private readonly Leaderboard? leaderboard = leaderboard;

        public void ChangeScoreValueIfGreater(int scoreValue) => score?.ChangeScoreValueIfGreater(scoreValue);

        public int GetScore() => score?.ScoreValue ?? 0;

        public void IncrementGamesPlayed() => score?.IncrementGamesPlayed();

        public void SaveScore()
        {
            if (score != null && leaderboard != null)
                leaderboard.AddScore(score);
        }
    }
}
