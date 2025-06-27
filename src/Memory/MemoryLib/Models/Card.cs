
namespace MemoryLib.Models
{
    /// <summary>
    /// Represents a card in a card game, with an identifier of type CardType and a face-up or face-down state.
    /// </summary>
    /// <remarks>
    /// Initialize a new instance of the Card class with a CardType identifier.
    /// </remarks>
    /// <param name="id"></param>
    public sealed class Card : ObservableObject, IEquatable<Card>
    {
        /// <summary>
        /// Get the Id of the card.
        /// </summary>
        public CardType Id { get; private init; }

        public Card(CardType id)
        {
            Id = id;
        }

        private bool _isVisible = false;

        /// <summary>
        /// Get or define a flag indicating whether the card is face up.
        /// </summary>
        public bool IsVisible
        {
            get 
            {
                return _isVisible;
            }
            set 
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Get or define a flag indicating whether the card has been found.
        /// </summary>

        private bool _isFound = false;
        public bool IsFound 
        {
            get => _isFound;
        
            set 
            {
                _isFound = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Returns the card, changing it's state from face down to face up or vice versa.
        /// </summary>
        public void Flip()
        {
            IsVisible = !IsVisible;
        }

        /// <summary>
        /// Returns a string representing the Id of the card.
        /// </summary>
        /// <returns>The string that carries the Id of the card.</returns>
        public override string ToString() => Id.ToString();

        /// <summary>
        /// Returns a card if it is face down.
        /// </summary>
        /// <param name="card">The card that should be returned</param>
        public static void FlipCard(Card card)
        {
            if (!card.IsVisible)
                card.Flip();
        }

        /// <summary>
        /// Display a console message when two cards are matched.
        /// </summary>
        /// <param name="card">The card that was found</param>
        public static void MatchCard(Card card)
        {
            Console.WriteLine($"Card {card.Id} matched.");
        }

        /// <summary>
        /// Returns a card if it is face up.
        /// </summary>
        /// <param name="card">The card to unflip and place as face down.</param>
        public static void UnFlipCard(Card card)
        {
            if (card.IsVisible)
                card.Flip();
        }

        /// <summary>
        /// Checks if two cards are equal by reference.
        /// </summary>
        /// <param name="other">The second card used to compare</param>
        /// <returns>Returns true if the two cards have the same reference, else returns false</returns>
        public bool Equals(Card? other)
        {
            return Id == other?.Id;
        }

        /// <summary>
        /// Check if the specified object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object that will be compared with the current instance.</param>
        /// <returns>True if the objects are equal, else False.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Card)obj);
        }

        /// <summary>
        /// Get the hash code for the current instance.
        /// </summary>
        /// <returns>The hash code of the Id of the card.</returns>
        public override int GetHashCode() => Id.GetHashCode();
    }
}
