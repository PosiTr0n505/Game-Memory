using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryLib.Models;

namespace Tests
{
    public class LeaderboardTest
    {
        [Fact]
        public void Add_A_Score_Into_The_Leaderboard_And_Check_If_It_Exists()
        {
            Leaderboard l = new Leaderboard();
            Player p = new Player("");
            Score s = new Score(p, p.CurrentScore, GridSize.Size6);

            l.AddScore(s);

            Assert.Contains(s, l.GetScores(GridSize.Size6));
        }
    }
}
