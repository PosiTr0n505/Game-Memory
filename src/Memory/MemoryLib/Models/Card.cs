using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Models
{
    public class Card
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

    }
}
