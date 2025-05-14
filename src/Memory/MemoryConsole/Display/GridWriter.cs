using MemoryLib.Managers;
using MemoryLib.Models;
using static System.Console;

namespace MemoryConsole.Display
{
    public static class GridWriter
    {
        public static void WriteGrid(GameManager sender, IEnumerable<Card> grid)
        {
            int i = 0;
            foreach (var card in grid)
            {
                if (i % sender.Game.Grid.X == 0)
                {
                    Write("\n");
                    i = 0;
                }
                Write(card + " ");
                ++i;
            }
        }
    }
}
