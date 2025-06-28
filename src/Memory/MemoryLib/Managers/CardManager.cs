using MemoryLib.Managers.Interface;
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Manages card operations in the Memory game, such as flipping a card and comparing two cards.
    /// </summary>
    public class CardManager : ICardManager
    {
        /// <summary>
        /// Returns a card face up if it is face down.
        /// </summary>
        /// <param name="card">The specified card.</param>
        public void FlipCard(Card card)
        {
            if (!card.IsVisible)
                card.Flip();
        }
        /// <summary>
        /// Returns a card face down if it is face up.
        /// </summary>
        /// <param name="card">The specified card.</param>
        public void UnFlipCard(Card card)
        {
            if (card.IsVisible)
                card.Flip();
        }
        /// <summary>
        /// Compares two cards to determine if they are identical based on their Id.
        /// </summary>
        /// <param name="card1">The first card.</param>
        /// <param name="card2">The second card.</param>
        /// <returns>True if the cards have the same Id, else false. </returns>
        public bool CompareCards(Card card1, Card card2)
        {
            return card1.Id == card2.Id;
        }
    }
}
