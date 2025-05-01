using static System.Console;

namespace MemoryLib.Models
{
    public class Grid
    {
        private byte X { get; }
        private byte Y { get; }
        private Card?[,] Cards { get; }
        public Grid(byte x, byte y) 
        {
            X = x;
            Y = y;
            Cards = new Card[x, y];
        }

        public Grid(){
            X = 0;
            Y = 0;
            Cards = new Card[0, 0];
        }

        public void AddCard(Card card, byte x, byte y)
        {
            Cards[x, y] = card;
        }

        public Card?[,] GetCards()
        {
            return Cards;
        }

        public Card? GetCard(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cards.GetLength(0) || y >= Cards.GetLength(1))
                return null;
            return Cards[x, y];
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
