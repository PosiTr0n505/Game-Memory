using MemoryLib.Managers.Interface;
using System.Collections.ObjectModel;


namespace MemoryLib.Models
{
    /// <summary>
    /// Représente le tableau des scores, permettant d'ajouter des scores et de les récupérer selon différents critères.
    /// </summary>
    public class Leaderboard : IScoreManager
    {
        /// <summary>
        /// Liste interne des scores enregistrés.
        /// </summary>
        private List<Score> _scores = [];

        public IEnumerable<Score> Scores => _scores.AsReadOnly();

        private ILoadManager _loader;
        private ISaveManager _saver;

        public Leaderboard(ILoadManager loader, ISaveManager saver)
        {
            _loader = loader;
            _saver = saver;
            _scores = _loader.LoadScores();
        }

        ~Leaderboard() 
        {
            _saver.SaveScores(_scores);
        }

        /// <summary>
        /// Ajoute un score à la liste des scores du tableau.
        /// </summary>
        /// <param name="score">Le score à ajouter au tableau.</param>
        public void AddScore(Score score) => _scores.Add(score);

        /// <summary>
        /// Récupère les scores associés à une taille de grille spécifique, triés par valeur de score en ordre décroissant.
        /// </summary>
        /// <param name="gridSize">La taille de la grille pour filtrer les scores.</param>
        /// <returns>Une collection en lecture seule des scores pour la taille de la grille spécifiée.</returns>
        public IEnumerable<Score> GetScores(GridSize gridSize)
        {
            return new ReadOnlyCollection<Score>([.. _scores
                .Where(s => s.GridSize == gridSize)
                .OrderByDescending(s => s.ScoreValue)]);

        }

        /// <summary>
        /// Récupère les scores associés à un joueur spécifique et, optionnellement, à une taille de grille spécifique.
        /// </summary>
        /// <param name="playerName">Le nom du joueur pour lequel récupérer les scores.</param>
        /// <param name="gridSize">La taille de la grille pour filtrer les scores.</param>
        /// <returns>Une collection des scores associés au joueur et à la taille de la grille.</returns>
        /// <exception>Lève une exception si le nom du joueur est invalide.</exception>
        public IEnumerable<Score> GetScores(string playerName, GridSize? gridSize = null)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentException("the playerName provided is not valid");

            if (_scores.Exists(s => s.Player.NameTag == playerName) && gridSize != null)
                return new ReadOnlyCollection<Score>([.. _scores.Where(s => s.Player.NameTag == playerName && s.GridSize == gridSize)]);

            return new ReadOnlyCollection<Score>( [.. _scores.Where(s => s.Player.NameTag == playerName) ]);
        }

        public void ChangeScoreValueIfGreater(Player p, GridSize gs, int scoreValue)
        {
            var score = _scores.FirstOrDefault(s => s.Player.Equals(p) && s.GridSize == gs);
            if (score != null)
            {
                score.ChangeScoreValueIfGreater(scoreValue);
            }
        }

        public void IncrementGamesPlayed(Player p, GridSize gs)
        {
            var score = _scores.FirstOrDefault(s => s.Player.Equals(p) && s.GridSize == gs);
            if (score != null)
            {
                score.IncrementGamesPlayed();
            }
        }

        public void SaveScore(Score score)
        {
            _scores.Add(score);
        }
    }
}
