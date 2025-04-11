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
        private string? NameTag { get; init; }
        private int CurrentScore { get; }
        private int MovesCount { get; }
    }
}
