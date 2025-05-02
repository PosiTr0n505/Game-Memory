using static System.Console;

namespace MemoryLib.Models
{
    public class Grid
    {
        public byte X { get; }
        public byte Y { get; }
        private Card[,] Cards { get; }
        public Grid(byte x, byte y) 
        {
            X = x;
            Y = y;
            Cards = new Card[x, y];
        }

        public Grid()
        {
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

        public Card GetCard(int x, int y)
        {
            return Cards[x, y];
        }

        public void ShowGrid()
        {
            WriteLine("Current grid:");
            for (int x = 0; x < X; x++)
               { 
                Console.WriteLine();
                for (int y = 0; y < Y; y++)
                {
                    Card? c = Cards[x, y];
                    if (c == null) Console.Write("N ");
                    if (c != null && c.IsFaceUp) Write($"! ");
                    else Write($"{c} ");
                }
            }
            WriteLine();
        }
/*        public void Clear()
        {
            for (var x = 0; x < X; x++)
                for (var y = 0; y < Y; y++)
                    Cards[x,y] = null;
        }
*/
    }

}
