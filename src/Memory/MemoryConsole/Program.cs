
using MemoryLib.Models;

using static System.Console;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new(2, 2);
            var a = grid.GetCards().GetLength(1);
            grid.ShowGrid();
            int? test = null;
            Console.WriteLine(test);
        }
    }
}