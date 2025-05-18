using MemoryLib.Models;

namespace MemoryLib.Managers.Interface
{
    /// <summary>
    /// Interface for managing card operations in the Memory game.
    /// </summary>
    public interface ICardManager
    {
        /// <summary>
        /// Flips the specified card to reveal its face.
        /// </summary>
        /// <param name="card">The card to be flipped.</param>
        void FlipCard(Card card);

        /// <summary>
        /// Unflips the specified card to hide its face.
        /// </summary>
        /// <param name="card">The card to be unflipped.</param>
        void UnFlipCard(Card card);

        /// <summary>
        /// Compares two cards to determine if they match.
        /// </summary>
        /// <param name="card1">The first card to compare.</param>
        /// <param name="card2">The second card to compare.</param>
        /// <returns>True if the cards match; otherwise, false.</returns>
        bool CompareCards(Card card1, Card card2);
    }
}