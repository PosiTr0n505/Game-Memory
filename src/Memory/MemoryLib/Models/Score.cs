using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public sealed class Score : IEquatable<Score>
    {
        public Score(Player p, int scoreValue, GridSize gs) 
        { 
            this.Player = p;
            this.ScoreValue = scoreValue;
            this.GridSize = gs;
        }
        public Player Player { get; init; }

        private int scoreValue;
        internal int ScoreValue
        {
            get => scoreValue;
            set => this.scoreValue = Math.Max(value, scoreValue);
        }
        public GridSize GridSize { get; set; }
        private int gamesPlayed;
        public int GamesPlayed { get; private set; }

        public int AddGamePlayed() => GamesPlayed++;

        public bool Equals(Score? other) 
        {
            if (ReferenceEquals(null, other)) return false;
            if (this.Player.NameTag != null && other != null)
                return this.Player.NameTag.Equals(other.Player.NameTag); 
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj != null && obj.GetType() != this.GetType()) return false;
            return this.Equals((Score?)obj);
        }

        public override int GetHashCode()
        {
            return Player.NameTag.GetHashCode();
        }
    }
}
