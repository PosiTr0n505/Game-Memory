using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public class CardManager : ICardManager
    {
        public void FlipCard(Card card)
        {
            if (!card.IsFaceUp)
                card.Flip();
        }
        public void UnFlipCard(Card card)
        {
            if (card.IsFaceUp)
                card.Flip();
        }
        public bool CompareCards(Card card1, Card card2)
        {
            return card1.Id == card2.Id;
        }
        public void MatchCard(Card card)
        {
            Console.WriteLine($"Card {card.Id} matched.");
        }
    }
}
