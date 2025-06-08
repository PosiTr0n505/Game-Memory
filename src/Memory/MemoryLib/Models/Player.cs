using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MemoryLib.Models
{
    /// <summary>
    /// Représente un joueur dans le jeu, avec un nom, un score actuel et un nombre de mouvements.
    /// </summary>
    public sealed class Player : ObservableObject, IEquatable<Player>
    {

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Player"/> avec un nom donné.
        /// </summary>
        /// <param name="name">Le nom du joueur. Ne peut pas être nul ou vide.</param>
        /// <exception>Lève une exception si le nom est nul ou vide.</exception>
        public Player(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            NameTag = name;
            MovesCount = 0;
            CurrentScore = 0;
        }

        private Player() => NameTag = "Temp";

        /// <summary>
        /// Obtient le nom du joueur.
        /// </summary>
        public string NameTag { get; init; }

        private int _currentScore;

        /// <summary>
        /// Obtient ou définit le score actuel du joueur.
        /// </summary>
        public int CurrentScore 
        {
            get => _currentScore;
            private set
            {
                _currentScore = value;
                OnPropertyChanged();
            }
        }

        private int _movesCount;

        /// <summary>
        /// Obtient ou définit le nombre de mouvements effectués par le joueur.
        /// </summary>
        public int MovesCount 
        {
            get => _movesCount;
            private set 
            {
                _movesCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Nombre de jeux joués par le joueur.
        /// </summary>
        private int _gamesPlayed = 0;
        public int GamesPlayed
        {
            get => _gamesPlayed;
            private set
            {
                _gamesPlayed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ajoute 1 au nombres de jeux joués par le joueur.
        /// </summary>
        public void IncrementGamesPlayed() => GamesPlayed++;

        /// <summary>
        /// Ajoute 1 au score actuel du joueur.
        /// </summary>
        public void Add1ToScore() => CurrentScore++;


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
            if (other is null) return false;
            return NameTag.Equals(other.NameTag);
        }

        /// <summary>
        /// Compare l'objet actuel à un autre objet pour vérifier si les joueurs sont égaux.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'instance actuelle.</param>
        /// <returns>true si les deux objets sont égaux, sinon false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Player)obj);
        }


        /// <summary>
        /// Calcule le code de hachage de l'objet actuel en fonction de son nom.
        /// </summary>
        /// <returns>Le code de hachage du nom du joueur.</returns>
        public override int GetHashCode() => NameTag.GetHashCode();

        /// <summary>
        /// Retourne une chaîne de caractères représentant le joueur, y compris son nom, son score actuel et le nombre de mouvements.
        /// </summary>
        /// <returns>score et moves du joueur</returns>
        public override string ToString()
        {
            return NameTag + $" (score : {CurrentScore}, moves : {MovesCount})" ;
        }
    }
}
