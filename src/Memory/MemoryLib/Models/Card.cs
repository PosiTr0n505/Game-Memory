using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Card : ICardManager, IEquatable<Card>
    {
        public Card(CardType id)
        {
            Id = id;
            IsFaceUp = false;
        }

        public CardType Id { get; private init; }
        public bool IsFaceUp { get; private set; }

        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
        
        public static bool MatchCards(Card? card1, Card? card2)
        {
            if (card1 == null || card2 == null)
                return false;
            return card1.Id == card2.Id;
        }
            
        public bool CompareCards(Card card1, Card card2)
        {
            return card1.Id == card2.Id;
        }

        public void FlipCard(Card card)
        {
            if (!card.IsFaceUp)
                card.Flip();
        }

        public void MatchCard(Card card)
        {
            Console.WriteLine($"Card {card.Id} matched.");
        }

        public void UnFlipCard(Card card)
        {
            if (card.IsFaceUp)
                card.Flip();
        }

        public bool Equals(Card? other)
        {
            return ReferenceEquals(other, null) ? false : ReferenceEquals(this, other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Card)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
