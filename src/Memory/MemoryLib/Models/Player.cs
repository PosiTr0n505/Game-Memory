namespace MemoryLib.Models
{
    /// <summary>
    /// Représente un joueur dans le jeu, avec un nom, un score actuel et un nombre de mouvements.
    /// </summary>
    public class Player : IEquatable<Player>
    {

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Player"/> avec un nom donné.
        /// </summary>
        /// <param name="name">Le nom du joueur. Ne peut pas être nul ou vide.</param>
        /// <exception>Lève une exception si le nom est nul ou vide.</exception>
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            this.NameTag = name;
            this.MovesCount = 0;
            this.CurrentScore = 0;
        }
        /// <summary>
        /// Obtient le nom du joueur.
        /// </summary>
        public string NameTag { get; init; }

        /// <summary>
        /// Obtient ou définit le score actuel du joueur.
        /// </summary>
        public int CurrentScore { get; private set; }

        /// <summary>
        /// Obtient ou définit le nombre de mouvements effectués par le joueur.
        /// </summary>
        public int MovesCount { get; private set; }

        /// <summary>
        /// Ajoute 1 au score actuel du joueur.
        /// </summary>

        public void Add1ToScore() => CurrentScore += 1;

        /// <summary>
        /// Ajoute 1 au nombre de mouvements effectués par le joueur.
        /// </summary>
        public void Add1ToMovesCount() => MovesCount += 1;

        /// <summary>
        /// Compare deux joueurs pour vérifier si leurs noms sont identiques.
        /// </summary>
        /// <param name="other">L'autre joueur à comparer.</param>
        /// <returns>true si les joueurs ont le même nom, sinon false.</returns>
        public bool Equals(Player? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return NameTag.Equals(other.NameTag);
        }

        /// <summary>
        /// Compare l'objet actuel à un autre objet pour vérifier si les joueurs sont égaux.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'instance actuelle.</param>
        /// <returns>true si les deux objets sont égaux, sinon false.</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Player)obj);
        }


        /// <summary>
        /// Calcule le code de hachage de l'objet actuel en fonction de son nom.
        /// </summary>
        /// <returns>Le code de hachage du nom du joueur.</returns>
        public override int GetHashCode() => NameTag.GetHashCode();
    }
}
