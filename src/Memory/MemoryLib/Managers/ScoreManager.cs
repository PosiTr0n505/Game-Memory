using MemoryLib.Models;

namespace MemoryLib.Managers

{
    public class ScoreManager : IScoreManager
    {
        private readonly Score? score;
        private readonly Leaderboard? leaderboard;

        public ScoreManager(Score score, Leaderboard leaderboard)
        {
            this.score = score;
            this.leaderboard = leaderboard;
        }

        public void ChangeScoreValueIfGreater(int scoreValue)
        {
            
        }

        public int GetScore() => score?.ScoreValue ?? 0;

        public void IncrementGamesPlayed()
        {
            throw new NotImplementedException();
        }

        //public void IncrementGamesPlayed() => score.GamesPlayed += 1;

        public void SaveScore() => leaderboard.AddScore(score: score);
    }
}
