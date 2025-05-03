using MemoryLib.Models;

namespace Tests
{
    public class ScoreTest
    {
        [Fact]
        public void Increment_GamesPlayed_Increments_GamesPlayed_By_1()
        {
            Player p = new("Test");
            Score score = new(p, 100, GridSize.Size6);

            Assert.Equal(0, score.GamesPlayed);

            score.IncrementGamesPlayed();
            Assert.Equal(1, score.GamesPlayed);
        }

        [Fact]
        public void ChangeScoreValue_Changes_ScoreValue_When_Valid()
        {
            Player p = new("Test");
            Score score = new(p, 100, GridSize.Size6);

            score.ChangeScoreValue(150);

            Assert.Equal(150, score.ScoreValue);
        }

        [Fact]
        public void ChangeScoreValue_Throws_Exception_When_NewScore_Is_Less_Than_Current()
        {
            Player p = new("Test");
            Score score = new(p, 100, GridSize.Size6);

            var exception = Assert.Throws<ArgumentException>(() => score.ChangeScoreValue(50));
            Assert.Equal("New score cannot be lower than the current score", exception.Message);
        }

        [Fact]
        public void Equals_Returns_True_For_Same_Player_And_GridSize()
        {
            Player p = new("Test");
            Score score1 = new(p, 100, GridSize.Size6);
            Score score2 = new(p, 150, GridSize.Size6);

            Assert.True(score1.Equals(score2));
        }

        [Fact]
        public void Equals_Returns_False_For_Different_Player_Or_GridSize()
        {
            Player p1 = new("Test");
            Player p2 = new("Other");
            Score score1 = new(p1, 100, GridSize.Size6);
            Score score2 = new(p2, 150, GridSize.Size6);
            Score score3 = new(p1, 100, GridSize.Size4);

            Assert.False(score1.Equals(score2));
            Assert.False(score1.Equals(score3));
        }



    }
}
