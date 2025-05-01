using MemoryLib.Models;

namespace MemoryLib
{
    public interface ICardManager
    {
        void FlipCard(Card card);

        void UnFlipCard(Card card);

        bool CompareCards(Card card1, Card card2);

        void MatchCard(Card card);
    }
}
