using MemoryLib.Models;

namespace Tests
{
    public class LeaderboardTest
    {
        [Fact]
        public void Add_A_Score_Into_The_Leaderboard_And_Check_If_It_Exists_GetScores()
        {
            Leaderboard l = new();
            Player p = new("Test");
            Score s = new(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            Assert.Contains(s, l.GetScores(GridSize.Size6));
        }

        [Fact]
        public void Add_A_Score_Into_The_Leaderboard_Search_With_Name_GetScores()
        {
            Leaderboard l = new();
            Player p = new("Test");
            Score s = new(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            Assert.Contains(s, l.GetScores("Test"));
        }

        [Fact]
        public void Add_A_Score_Into_The_Leaderboard_Search_With_Name_And_GridSize_GetScores()
        {
            Leaderboard l = new();
            Player p = new("Test");
            Score s = new(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            Assert.Contains(s, l.GetScores("Test", GridSize.Size6));
        }

        [Fact]
        public void Add_A_Score_Into_The_Leaderboard_Search_With_Name_And_Wrong_GridSize_GetScores()
        {
            Leaderboard l = new();
            Player p = new("Test");
            Score s = new(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            Assert.DoesNotContain(s, l.GetScores("Test", GridSize.Size4));
        }

        [Fact]
        public void Add_A_Score_Into_The_Leaderboard_Search_With_Wrong_Name_GetScores()
        {
            Leaderboard l = new();
            Player p = new("Test");
            Score s = new(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            Assert.DoesNotContain(s, l.GetScores("qsdqdfhd"));
        }

        [Fact]
        public void GetScores_Throws_Exception_When_PlayerName_Is_Empty_Or_Whitespace()
        {
            Leaderboard l = new();
            Player p = new("Test");
            Score s = new(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            var exception1 = Assert.Throws<ArgumentException>(() => l.GetScores(""));
            Assert.Equal("the playerName provided is invalid", exception1.Message);

            var exception2 = Assert.Throws<ArgumentException>(() => l.GetScores("    "));
            Assert.Equal("the playerName provided is invalid", exception2.Message);
        }

        [Fact]
        public void GetScores_Returns_Empty_Collection_When_No_Scores_Exist()
        {
            Leaderboard l = new();
            var scores = l.GetScores("Test");
            Assert.Empty(scores);
        }

        [Fact]
        public void GetScores_Sorts_Scores_By_Descending_Order()
        {
            Leaderboard l = new();
            Player p1 = new("Player1");
            Player p2 = new("Player2");
            Player p3 = new("Player3");

            Score s1 = new(p1, 100, GridSize.Size6);
            Score s2 = new(p2, 150, GridSize.Size6);
            Score s3 = new(p1, 200, GridSize.Size6);
            Score s4 = new(p2, 50, GridSize.Size6);

            l.AddScore(s1);
            l.AddScore(s2);
            l.AddScore(s3);
            l.AddScore(s4);

            var scores = l.GetScores(GridSize.Size6).ToList();

            Assert.Equal(200, scores[0].ScoreValue);
            Assert.Equal(150, scores[1].ScoreValue);
            Assert.Equal(100, scores[2].ScoreValue);
            Assert.Equal(50, scores[3].ScoreValue);
        }

        [Fact]
        public void GetScores_Returns_Correct_Scores_For_Different_GridSizes()
        {
            Leaderboard l = new();
            Player p1 = new("Player1");
            Player p2 = new("Player2");

            Score s1 = new(p1, 100, GridSize.Size6);
            Score s2 = new(p2, 150, GridSize.Size6);
            Score s3 = new(p1, 200, GridSize.Size4);
            Score s4 = new(p2, 50, GridSize.Size4);

            l.AddScore(s1);
            l.AddScore(s2);
            l.AddScore(s3);
            l.AddScore(s4);

            var size6Scores = l.GetScores(GridSize.Size6).ToList();
            Assert.Contains(s1, size6Scores);
            Assert.Contains(s2, size6Scores);
            Assert.DoesNotContain(s3, size6Scores);
            Assert.DoesNotContain(s4, size6Scores);

            var size4Scores = l.GetScores(GridSize.Size4).ToList();
            Assert.Contains(s3, size4Scores);
            Assert.Contains(s4, size4Scores);
            Assert.DoesNotContain(s1, size4Scores);
            Assert.DoesNotContain(s2, size4Scores);
        }

        [Fact]
        public void GetScores_Returns_Multiple_Scores_For_Same_Player()
        {
            Leaderboard l = new();
            Player p = new("Test");

            Score s1 = new(p, 100, GridSize.Size6);
            Score s2 = new(p, 200, GridSize.Size6);
            Score s3 = new(p, 150, GridSize.Size4);

            l.AddScore(s1);
            l.AddScore(s2);
            l.AddScore(s3);

            var allScores = l.GetScores("Test").ToList();
            Assert.Contains(s1, allScores);
            Assert.Contains(s2, allScores);
            Assert.Contains(s3, allScores);

            var size6Scores = l.GetScores("Test", GridSize.Size6).ToList();
            Assert.Contains(s1, size6Scores);
            Assert.Contains(s2, size6Scores);
            Assert.DoesNotContain(s3, size6Scores);

            var size4Scores = l.GetScores("Test", GridSize.Size4).ToList();
            Assert.DoesNotContain(s1, size4Scores);
            Assert.DoesNotContain(s2, size4Scores);
            Assert.Contains(s3, size4Scores);
        }


    }
}
