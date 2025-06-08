using MemoryLib.Managers.Interface;
using System.Runtime.Serialization;
namespace MemoryLib.Models
{
    /// <summary>
    /// Représente un score pour un joueur dans le jeu, avec des informations sur le joueur, la valeur du score, 
    /// la taille de la grille et le nombre de jeux joués.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe Score avec les valeurs spécifiées pour le joueur, le score, la taille de la grille et les jeux joués.
    /// </remarks>
    /// <param name="p">Le joueur associé à ce score.</param>
    /// <param name="scoreValue">La valeur du score.</param>
    /// <param name="gs">La taille de la grille associée au score.</param>
    /// <param name="gp">Le nombre de jeux joués (par défaut à 0).</param>
    public sealed class Score : IEquatable<Score>
    {
        public Score(Player p, int scoreValue, GridSize gs, int gp = 0)
        {
            Player = p;
            ScoreValue = scoreValue;
            GridSize = gs;
            GamesPlayed = gp;
        }

        private Score() : this(new Player("Temp"), 0, GridSize.Size1, 0) { }
        /// <summary>
        /// Obtient le joueur associé à ce score.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Obtient ou définit la valeur du score.
        /// </summary>
        public int ScoreValue { get; private set; }

        /// <summary>
        /// Obtient la taille de la grille associée à ce score.
        /// </summary>
        public GridSize GridSize { get; }

        /// <summary>
        /// Obtient ou définit le nombre de jeux joués par le joueur.
        /// </summary>
        public int GamesPlayed { get; private set; }

        /// <summary>
        /// Incrémente le nombre de jeux joués de 1.
        /// </summary>

        public void IncrementGamesPlayed() => GamesPlayed++;

        /// <summary>
        /// Modifie la valeur du score uniquement si la nouvelle valeur est supérieure à l'ancienne.
        /// </summary>
        /// <param name="scoreValue">La nouvelle valeur du score.</param>

        public void ChangeScoreValueIfGreater(int scoreValue) 
        {
            if (scoreValue < ScoreValue)
                return;
            ScoreValue = scoreValue;
        }

        /// <summary>
        /// Compare deux objets Score pour vérifier si le joueur et la taille de la grille sont identiques.
        /// </summary>
        /// <param name="other">L'autre objet Score à comparer.</param>
        /// <returns>true si les scores sont égaux, sinon false.</returns>
        public bool Equals(Score? other) 
        {
            if (other is null) return false;
            return this.Player.NameTag.Equals(other.Player.NameTag) && this.GridSize==other.GridSize;
        }

        /// <summary>
        /// Compare l'objet actuel avec un autre objet pour vérifier s'ils sont égaux.
        /// </summary>
        /// <param name="obj">L'objet à comparer.</param>
        /// <returns>true si les objets sont égaux, sinon false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Score)obj);
        }

        /// <summary>
        /// Calcule le code de hachage basé sur le nom du joueur.
        /// </summary>
        /// <returns>Le code de hachage du nom du joueur.</returns>
        public override int GetHashCode() => Player.NameTag.GetHashCode();

        /// <summary>
        /// 
        /// </summary>
        /// <exception> "NotImplementedException"></exception>
        public void SaveScore()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception> "NotImplementedException"></exception>
        public int GetScore()
        {
            throw new NotImplementedException();
        }
    }
}
