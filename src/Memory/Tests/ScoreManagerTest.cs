using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class ScoreManagerTest
    {
        [Fact]
        public void ChangeScoreValueIfGreater_should_update_score_when_new_value_is_greater()
        {
            
            Player player = new("Player1");
            Score score = new(player, 10, GridSize.Size2, 5);
            var leaderboard = new Leaderboard();
            var scoreManager = new ScoreManager(score, leaderboard);
            
            scoreManager.ChangeScoreValueIfGreater(15);
            
            Assert.Equal(15, scoreManager.GetScore());
        }
    }
}
