using MemoryLib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public sealed class Score : IEquatable<Score>, IScoreManager
    {
        public Score(Player p, int scoreValue, GridSize gs, int gp = 0) 
        { 
            this.Player = p;
            this.ScoreValue = scoreValue;
            this.GridSize = gs;
            GamesPlayed = gp;
        }
        public Player Player { get; }
        public int ScoreValue { get; private set; }
        public GridSize GridSize { get; }
        public int GamesPlayed { get; private set; }

        public void IncrementGamesPlayed() => GamesPlayed++;

        public void ChangeScoreValue(int scoreValue) 
        {
            if (scoreValue < ScoreValue)
                throw new ArgumentException("New score value cannot be less than the current score", nameof(scoreValue));
            ScoreValue = scoreValue;
        }

        public bool Equals(Score? other) 
        {
            if (ReferenceEquals(other, null)) return false;
            return this.Player.NameTag.Equals(other.Player.NameTag) && this.GridSize==other.GridSize;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Score)obj);
        }

        public override int GetHashCode()
        {
            return Player.NameTag.GetHashCode();
        }


    }
}
