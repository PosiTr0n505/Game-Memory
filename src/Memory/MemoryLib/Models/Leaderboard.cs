using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Leaderboard
    {
        private List<Score> scores = new List<Score>();

        public void AddScore(Score score)
        {
            scores.Add(score);
        }
        
        public IEnumerable<Score> GetTopScores(GridSize gridSize)
        {
            return new ReadOnlyCollection<Score>([.. scores
                .Where(s => s.GridSize == gridSize) //Filtre les scores par GridSize
                .OrderByDescending(s => s.ScoreValue)]); // Trie par scores décroissant

        }

        public IEnumerable<Score> GetScores(GridSize gridSize,string? playerName = null)
        {
            scores.Exists(s => s.Player.NameTag == playerName && s.GridSize == gridSize);
            return new ReadOnlyCollection<Score>([.. scores]);
        }
    }
}
