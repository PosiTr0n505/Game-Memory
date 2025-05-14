using static System.Console;
using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryConsole
{
    public class ConsoleAsking
    {
        public ConsoleAsking() { }

        public static string AskPlayersName(string i)
        {
            Write($"Player {i}, Enter your name :   ");
            string P1Name = ReadLine()!;

            while (string.IsNullOrWhiteSpace(P1Name))
            {
                Write("Please enter a valid name.\nPlayer 1 :   ");
                P1Name = ReadLine()!;
            }

            return P1Name;
        }

        public static GridSize AskGridSize()
        {
            GridSizeManager gridSizeManager = new GridSizeManager();
            WriteLine("Select the grid size:");
            int i = 1;
            foreach (var size in gridSizeManager.Values)
            {
                WriteLine($"{i} : {size.Value}");
                ++i;
            }
            Write("\nGrid Size : ");
            string? choice = ReadLine();

            int gsc = gridSizeManager.Values.Count;

            int gridSize;

            while (!int.TryParse(choice, out gridSize) || gridSize < 1 || gridSize > gsc)
            {
                if (!int.TryParse(choice, out gridSize))
                {
                    WriteLine("Invalid input. Please enter a number.");
                }
                else if (gridSize < 1 || gridSize > gsc)
                {
                    WriteLine($"Invalid choice. Please select a number between 1 and {gsc}.");
                }
                Write("Select the grid size: ");
                choice = ReadLine();
            }

            return (GridSize)(gridSize - 1);
        }
    }
}
