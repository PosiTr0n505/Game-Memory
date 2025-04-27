using static System.Console;

namespace MemoryLib.Models
{
    public class Grid
    {
        private byte X { get; }
        private byte Y { get; }
        public Grid(byte x, byte y) 
        {
            X = x;
            Y = y;
            Cards = new Card[x, y];
        }

        private Card?[,] Cards { get; }

        public void AddCard(Card card, byte x, byte y)
        {
            Cards[x, y] = card;
        }

        public Card?[,] GetCards()
        {
            return Cards;
        }

        public void ShowGrid()
        {
            WriteLine("Current grid:");
            foreach (var card in Cards)
            {
                if (card != null)
                {
                    Console.WriteLine($"Card ID: {card.Id}, FaceUp: {card.IsFaceUp}");
                }
            }
        }
        public void Clear()
        {
            for (var x = 0; x < X; x++)
                for (var y = 0; y < Y; y++)
                    Cards[x,y] = null;
        }
    }

}
