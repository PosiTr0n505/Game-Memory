using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MemoryLib.Models
{
    /// <summary>
    /// Represents a player in the game, with a name, current score, and number of moves.
    /// </summary>
    public sealed class Player : ObservableObject, IEquatable<Player>
    {

        /// <summary>
        /// Initialize a new instance of the <see cref="Player"/> class with a given name.
        /// </summary>
        /// <param name="name">The name tag of the player. Cannot be null or empty space.</param>
        /// <exception>Throw an exception if the name tag is null or empty.</exception>
        public Player(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            NameTag = name;
            MovesCount = 0;
            CurrentScore = 0;
        }

        private Player() => NameTag = "Temp";

        /// <summary>
        /// Get the name tag of the player.
        /// </summary>
        public string NameTag { get; init; }

        private int _currentScore;

        /// <summary>
        /// Gets or sets the current score of the player.
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
        /// Gets or sets the number of moves made by the player.
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
        /// Number of games played by the player.
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
        /// Increment the number of games played by the player by 1.
        /// </summary>
        public void IncrementGamesPlayed() => GamesPlayed++;

        /// <summary>
        /// Increment the player's current score by 1.
        /// </summary>
        public void Add1ToScore() => CurrentScore++;


        /// <summary>
        /// Increment the player's moves count by 1.
        /// </summary>
        public void Add1ToMovesCount() => MovesCount += 1;

        /// <summary>
        /// Compares two players to check if their names are the same.
        /// </summary>
        /// <param name="other">The other player to compare to</param>
        /// <returns>True is the players have the same name tags, else false.</returns>
        public bool Equals(Player? other)
        {
            if (other is null) return false;
            return NameTag.Equals(other.NameTag);
        }

        /// <summary>
        /// Compares the current object with another object to check if they are equal players.
        /// </summary>
        /// <param name="obj">The other object to compare with the current one.</param>
        /// <returns>True if both objects are equal, else false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Player)obj);
        }


        /// <summary>
        /// Gets the hash code of the current object based on its name tag.
        /// </summary>
        /// <returns>The hash code of the name tag of the player</returns>
        public override int GetHashCode() => NameTag.GetHashCode();

        /// <summary>    
        /// Returns a string representation of the player, including their name tag, current score, and moves count.
        /// </summary>
        /// <returns>Score and moves count of the player.</returns>
        public override string ToString()
        {
            return NameTag + $" (score : {CurrentScore}, moves : {MovesCount})" ;
        }
    }
}
