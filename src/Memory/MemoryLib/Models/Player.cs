using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MemoryLib.Models
{
    /// <summary>
    /// Représente un joueur dans le jeu, avec un nom, un score actuel et un nombre de mouvements.
    /// </summary>
    public class Player : IEquatable<Player>, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        /// <summary>
        /// Délégué pour notifier les changements de score.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="score"></param>
        /// 
        public delegate void OnScoreChangeNotify(Player player, int score);

        /// <summary>
        /// Événement déclenché lorsque le score du joueur change.
        /// </summary>
        
        public event OnScoreChangeNotify? ScorePropertyChanged;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Player"/> avec un nom donné.
        /// </summary>
        /// <param name="name">Le nom du joueur. Ne peut pas être nul ou vide.</param>
        /// <exception>Lève une exception si le nom est nul ou vide.</exception>
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            NameTag = name;
            MovesCount = 0;
            CurrentScore = 0;
        }
        /// <summary>
        /// Obtient le nom du joueur.
        /// </summary>
        private string _nameTag;
        public string NameTag
        {
            get => _nameTag;
            set
            {
                if (_nameTag != value)
                {
                    _nameTag = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Obtient ou définit le score actuel du joueur.
        /// </summary>
        private int _currentScore;
        public int CurrentScore
        {
            get => _currentScore;
            private set
            {
                if (_currentScore != value)
                {
                    _currentScore = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Obtient ou définit le nombre de mouvements effectués par le joueur.
        /// </summary>
        private int _movesCount;
        public int MovesCount
        {   
            get => _movesCount;
            private set
            {
                if (_movesCount != value)
                {
                    _movesCount = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Ajoute 1 au score actuel du joueur.
        /// </summary>
        public void Add1ToScore()
        {
            CurrentScore++;
            ScorePropertyChanged?.Invoke(this, CurrentScore);
        }

        /// <summary>
        /// Ajoute 1 au nombre de mouvements effectués par le joueur.
        /// </summary>
        public void Add1ToMovesCount() => MovesCount += 1;

        /// <summary>
        /// Compare deux joueurs pour vérifier si leurs noms sont identiques.
        /// </summary>
        /// <param name="other">L'autre joueur à comparer.</param>
        /// <returns>true si les joueurs ont le même nom, sinon false.</returns>
        public bool Equals(Player? other) => other is not null && NameTag.Equals(other.NameTag);

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
