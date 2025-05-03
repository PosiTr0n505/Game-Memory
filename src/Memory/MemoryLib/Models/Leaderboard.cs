
using System.Collections.ObjectModel;


namespace MemoryLib.Models
{
    public class Leaderboard
    {
        private readonly List<Score> scores = [];

        public void AddScore(Score score) => scores.Add(score);

        public IEnumerable<Score> GetScores(GridSize gridSize)
        {
            return new ReadOnlyCollection<Score>([.. scores
                .Where(s => s.GridSize == gridSize) //Filtre les scores par GridSize
                .OrderByDescending(s => s.ScoreValue)]); // Trie par scores décroissant

        }

        public IEnumerable<Score> GetScores(string playerName, GridSize? gridSize = null)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentException("the playerName provided is not valid");

            if (scores.Exists(s => s.Player.NameTag == playerName) && gridSize != null)
                return scores.Where(s => s.Player.NameTag == playerName && s.GridSize == gridSize);

            return scores.Where(s => s.Player.NameTag == playerName);
        }
    }
}
