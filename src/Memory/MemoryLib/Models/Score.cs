using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Score : IEquatable<Score>
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
        public int GamesPlayed { get => gamesPlayed; set => gamesPlayed++; }

        public bool Equals(Score other) => this.Player.NameTag.Equals(other.Player.NameTag);
    }
}
