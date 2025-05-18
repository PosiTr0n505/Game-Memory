using MemoryLib.Managers.Interface;
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Gère les opérations sur les cartes du jeu, telles que retourner une carte et comparer deux cartes.
    /// </summary>
    public class CardManager : ICardManager
    {
        /// <summary>
        /// Retourne une carte face visible si elle est face cachée.
        /// </summary>
        /// <param name="card">La carte à retourner.</param>
        public void FlipCard(Card card)
        {
            if (!card.IsFaceUp)
                card.Flip();
        }
        /// <summary>
        /// Retourne une carte face cachée si elle est face visible.
        /// </summary>
        /// <param name="card">La carte à retourner face cachée.</param>
        public void UnFlipCard(Card card)
        {
            if (card.IsFaceUp)
                card.Flip();
        }
        /// <summary>
        /// Compare deux cartes pour déterminer si elles sont identiques selon leur identifiant.
        /// </summary>
        /// <param name="card1">La première carte à comparer.</param>
        /// <param name="card2">La deuxième carte à comparer.</param>
        /// <returns>True si les cartes ont le même identifiant, sinon false.</returns>
        public bool CompareCards(Card card1, Card card2)
        {
            return card1.Id == card2.Id;
        }
    }
}
