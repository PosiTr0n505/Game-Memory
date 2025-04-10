using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    internal class Score
    {
        private Player Player { get; init; }
        internal int ScoreValue { get; set; } // internal accessible dans tout le projet
        internal int GridSize { get; set; }// internal accessible dans tout le projet
        private int GamesPlayed;

    }
}
