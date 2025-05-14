using static System.Console;
using MemoryLib.Managers;
using MemoryLib.Models;
using System.Xml.Linq;

namespace MemoryConsole
{
    public class ConsoleAsking
    {
        public ConsoleAsking() { }

        public void AskOnePlayerName(out string playerName) 
        {
            Write("Enter your name :    ");
            playerName = ReadLine();
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Write("Please enter a valid name.\nEnter your name :   ");
                playerName = ReadLine();
            }
        }

        public void AskTwoPlayersNames(out string? P1Name, out string? P2Name)
        {
            Write("Player 1 :   ");
            P1Name = ReadLine();
            while (string.IsNullOrWhiteSpace(P1Name))
            {
                Write("Please enter a valid name.\nPlayer 1 :   ");
                P1Name = ReadLine();
            }

            Write("Player 2 :   ");
            P2Name = ReadLine();

            if (P2Name == P1Name)
            {
                WriteLine("The two players cannot have the same name.\n");
                P2Name = null;
            }

            while (string.IsNullOrWhiteSpace(P2Name))
            {
                Write("Please enter a valid name.\nPlayer 2 :   ");
                P2Name = ReadLine();
            }
        }

        public GridSize AskGridSize()
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
