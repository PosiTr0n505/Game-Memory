using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    internal class Player
    {
        public Player(string? name)
        {
            this.NameTag = name;
            this.MovesCount = 0;
            this.CurrentScore = 0;
        }
        public string? NameTag { get; init; }
        public int CurrentScore { get; private set; }
        public int MovesCount { get; private set; }

        public void add1ToScore()
        {
            CurrentScore += 1;
        }

        public void add1ToMovesCount()
        {
            MovesCount += 1;
        }
    }
}
