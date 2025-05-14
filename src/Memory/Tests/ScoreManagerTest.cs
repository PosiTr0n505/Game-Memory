using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class ScoreManagerTest
    {
        [Fact]
        public void ChangeScoreValueIfGreater_should_update_score_when_new_value_is_greater()
        {
            // Arrange
            Player player = new("Player1");
            GridSize gridSize = new(4, 4);
            Score score = new(player, 10, gridsize, 5);
            var leaderboard = new Leaderboard();
            var scoreManager = new ScoreManager(score, leaderboard);
            // Act
            scoreManager.ChangeScoreValueIfGreater(15);
            // Assert
            Assert.Equal(15, scoreManager.GetScore());
        }
    }
}
