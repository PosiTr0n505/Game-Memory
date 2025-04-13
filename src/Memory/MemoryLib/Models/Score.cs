using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Score
    {
        public Score(Player p, int scoreValue, int GridSize) 
        { 
            this.Player = p;
            this.ScoreValue = scoreValue;
            this.GridSize = GridSize;
        }
        public Player Player { get; init; }

        private int scoreValue;
        internal int ScoreValue{
            get => scoreValue;
            set => this.scoreValue = Math.Max(value, scoreValue);
        }
        public int GridSize { get; set; }
        private int gamesPlayed;
        public int GamesPlayed { get => gamesPlayed; set => gamesPlayed++; }

    }
}
