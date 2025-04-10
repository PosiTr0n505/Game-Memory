using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    internal class Leaderboard
    {
        private List<Score> scores = new List<Score>();

        public void AddScore(Score score)
        {
            scores.Add(score);
        }

        public List<Score> GetTopScores(int gridSize)
        {
            return scores
                .Where(s => s.GridSize == gridSize) //Filtre les scores par GridSize
                .OrderByDescending(s => s.ScoreValue)//Trie par ScoreValue décroissant
                .ToList();// Transforme le résultat en liste
        }
    }
}
