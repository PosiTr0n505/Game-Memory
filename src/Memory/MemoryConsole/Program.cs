
using MemoryLib.Managers;
using MemoryLib.Models;

using static System.Console;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new(new Game(new Player("test1"), new Player("test2"), 4, 4));
            gameManager.StartGame();
        }
    }
}