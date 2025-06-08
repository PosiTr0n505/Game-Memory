using System.Collections.ObjectModel;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Représente le tableau des scores, permettant d'ajouter des scores et de les récupérer selon différents critères.
    /// </summary>
    public class ScoreManager : IScoreManager
    {
        public delegate void ScoresAddedEventHandler();

        public event ScoresAddedEventHandler? ScoresAdded;

        /// <summary>
        /// Liste interne des scores enregistrés.
        /// </summary>
        private readonly List<Score> _scores;

        /// <summary>
        /// Obtient une collection en lecture seule des scores enregistrés.
        /// </summary>
        public IEnumerable<Score> Scores => _scores.AsReadOnly();

        /// <summary>
        ///  Gestionnaire de chargement et de sauvegarde des scores.
        /// </summary>
        private readonly ISaveManager _saver;

        /// <summary>
        /// Constructeur de la classe Leaderboard.
        /// </summary>
        /// <param name="loader"></param>
        /// <param name="saver"></param>
        public ScoreManager(ILoadManager loader, ISaveManager saver)
        {
            ILoadManager _loader = loader;
            _saver = saver;
            _scores = _loader.LoadScores();
        }

        /// <summary>
        /// Destructeur de la classe Leaderboard.
        /// </summary>
        ~ScoreManager()
        {
            _saver.SaveScores(_scores);
        }

        public void SaveScores()
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
        public IEnumerable<Score> GetScores(GridSize? gridSize)
        {
            if (gridSize is null)
                return Scores;

            return new ReadOnlyCollection<Score>(
                [.. _scores.Where(s => s.GridSize == gridSize).OrderByDescending(s => s.ScoreValue)]
            );
        }

        /// <summary>
        /// Récupère les scores associés à un joueur spécifique et, optionnellement, à une taille de grille spécifique.
        /// </summary>
        /// <param name="playerName">Le nom du joueur pour lequel récupérer les scores.</param>
        /// <param name="gridSize">La taille de la grille pour filtrer les scores.</param>
        /// <returns>Une collection des scores associés au joueur et à la taille de la grille.</returns>
        public IEnumerable<Score> GetScores(string playerName, GridSize? gridSize = null)
        {
            // Si aucun filtre n'est fourni, retourne tous les scores
            if (string.IsNullOrWhiteSpace(playerName) && gridSize is null)
                throw new ArgumentException("the playerName provided is not valid");

            var filteredScores = _scores.Where(s =>
                (
                    string.IsNullOrWhiteSpace(playerName)
                    || s.Player.NameTag.Contains(playerName, StringComparison.OrdinalIgnoreCase)
                ) && (gridSize == null || s.GridSize == gridSize)
            );

            return new ReadOnlyCollection<Score>([.. filteredScores]);
        }

        /// <summary>
        /// Récupère les scores associés à un joueur spécifique.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="gs"></param>
        /// <param name="scoreValue"></param>
        public void ChangeScoreValueIfGreater(Player p, GridSize gs, int scoreValue)
        {
            var score = _scores.FirstOrDefault(s => s.Player.Equals(p) && s.GridSize == gs);
            score?.ChangeScoreValueIfGreater(scoreValue);
        }

        /// <summary>
        /// Incrémente le nombre de jeux joués pour un joueur spécifique et une taille de grille donnée.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="gs"></param>
        public void IncrementGamesPlayed(Player p, GridSize gs)
        {
            var score = _scores.FirstOrDefault(s => s.Player.Equals(p) && s.GridSize == gs);
            score?.IncrementGamesPlayed();
        }

        /// <summary>
        /// Ajoute un score à la liste des scores.
        /// </summary>
        /// <param name="score"></param>
        public void SaveScore(Score score)
        {
            Score? s = _scores.FirstOrDefault(s => s.Player.NameTag == score.Player.NameTag);

            if (s is not null)
            {
                s.IncrementGamesPlayed();
                s.ChangeScoreValueIfGreater(score.ScoreValue);
                ScoresAdded?.Invoke();
            }

            else
            {
                _scores.Add(score);
                ScoresAdded?.Invoke();
            }
                
        }
    }
}
