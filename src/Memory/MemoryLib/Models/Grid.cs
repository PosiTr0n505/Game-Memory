using MemoryLib.Managers;
using static System.Console;

namespace MemoryLib.Models
{
    public class Grid : IGridManager
    {
        public int X { get; }
        public int Y { get; }
        private Card[,] Cards { get; }
        public Grid(int x, int y) 
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

        public void AddCard(Card card, int x, int y)
        {
            if (x >= X || y >= Y)
                throw new IndexOutOfRangeException("The coordinates are outside of the grid range");
            Cards[x, y] = card;
        }

        public Card?[,] GetCards() => Cards;

        public Card GetCard(int x, int y) => Cards[x, y];

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
        public void Clear()
        {
            for (var x = 0; x < X; x++)
                for (var y = 0; y < Y; y++)
                    Cards[x, y] = null!;
        }

        public void ClearGrid(Grid grid)
        {
            throw new NotImplementedException();
        }
    }

}
