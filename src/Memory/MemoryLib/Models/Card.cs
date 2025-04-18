using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Card
    {
        public Card(CardType id, Card c)
        {
            Id = id;
            IsFaceUp = false;
        }

        public CardType Id { get; init; }
        public bool IsFaceUp { get; set; }

    }
}
