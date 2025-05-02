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
    }
}
