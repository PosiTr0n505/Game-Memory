using static System.Console;
using MemoryLib.Managers;
using MemoryLib.Models;
using System.Data;


namespace MemoryConsole
{
    public class ConsoleAsking
    {
        public ConsoleAsking() { }
        public static void AskOnePlayerName(out string playerName)
        {
            Write("Enter your name :    ");
            playerName = ReadLine()!;
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Write("Please enter a valid name.\nEnter your name :   ");
                playerName = ReadLine()!;
            }
        }

        public static void AskPlayersName(string i, out string PName)
        {
            Write($"Player {i}, Enter your name :   ");
            PName = ReadLine()!;

            while (string.IsNullOrWhiteSpace(PName))
            {
                Write($"Please enter a valid name.\nPlayer {i} :   ");
                PName = ReadLine()!;
            }

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

        public static (int, int) AskCoordinates(string i, int X, int Y)
        {
            WriteLine("Enter the coordinates (x y) : ");
            Write($"Card {i} : ");
            var input = ReadLine();

            if (input == null)
                throw new NoNullAllowedException();

            var inputs = input.Split(' ');

            if (inputs.Length != 2)
                throw new ArgumentException("Invalid input. Please enter two coordinates separated by a space.");

            if (!int.TryParse(inputs[0], out int x) || !int.TryParse(inputs[1], out int y))
                throw new ArgumentException("Invalid input. Please enter two valid numbers separated by a space.");

            if (x < 0 || y < 0 || x >= X || y >= Y)
                throw new ArgumentException($"Coordinates out of range. Please enter valid coordinates.");


            return (x, y);
        }

    }
}
