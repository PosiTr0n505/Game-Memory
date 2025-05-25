using MemoryLib.Managers;
using MemoryLib.Models;
using Persistence;

namespace Tests
{
    public class ScoreManagerTest
    {
        [Fact]
        public void ChangeScoreValueIfGreater_should_update_score_when_new_value_is_greater()
        {
            
            Player player = new("Player1");
            Score score = new(player, 10, GridSize.Size2, 5);
            var leaderboard = new ScoreManager(new StubLoadManager(), new StubSaveManager());

            leaderboard.AddScore(score);

            leaderboard.ChangeScoreValueIfGreater(score.Player, score.GridSize, 15);

            var scoreExpected = leaderboard.GetScores(score.Player.NameTag, score.GridSize).FirstOrDefault();

            Assert.NotNull(scoreExpected);

            Assert.Equal(15, scoreExpected.ScoreValue);
        }
    }
}
