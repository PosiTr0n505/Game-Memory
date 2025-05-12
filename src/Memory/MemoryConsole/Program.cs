
using MemoryLib.Managers;
using MemoryLib.Models;

using static System.Console;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Clear();
                WriteLine("=== Memory Game ===");
                WriteLine("1. Singleplayer Game");
                WriteLine("2. Two Players Game");
                WriteLine("3. Game Rules");
                WriteLine("4. Leaderboard");
                WriteLine("5. Credits");
                WriteLine("6. Quit Game\n");
                Write("Select an option: ");

                string? choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        StartSingleplayerGame();
                        break;
                    case "2":
                        StartTwoPlayersGame();
                        break;
                    case "3":
                        ShowGameRules();
                        break;
                    case "4":
                        ShowLeaderboard();
                        break;
                    case "5":
                        ShowCredits();
                        break;
                    case "6":
                        WriteLine("Goodbye!");
                        return;
                    default:
                        WriteLine("Invalid choice. Please try again.");
                        break;
                }

                WriteLine("\nPress any key to return to the main menu...");
                ReadKey();
            }
        }

        static void StartSingleplayerGame()
        {
            Clear();
            WriteLine("Starting Singleplayer Game...");
            // A modifier pour faire le startgame 1 player :
            // GameManager gameManager = new GameManager(new Game(new Player("Player 1"),  GridSize.Size1)); 
            // gameManager.StartGame();
        }

        static void StartTwoPlayersGame()
        {
            Clear();
            WriteLine("Starting Two Players Game...\nEnter The Name of the 2 Players\n");

            AskTwoPlayersNames(out string? P1Name, out string? P2Name);
            WriteLine();
            GridSize gridSize = AskGridSize();

            GameManager gameManager = new GameManager(new Game(new Player(P1Name), new Player(P2Name), gridSize));
            gameManager.StartGame();
        }

        static void AskTwoPlayersNames(out string? P1Name, out string? P2Name)
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

        static GridSize AskGridSize()
        {
            GridSizeManager gridSizeManager = new GridSizeManager();
            WriteLine("Select the grid size:");
            int i=1;
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

        static void ShowGameRules()
        {
            Clear();
            WriteLine("=== Game Rules ===\n");
            WriteLine("Le Memory est un jeu qui se joue au tour à tour.\n");
            WriteLine("Lorsque la taille de la grille et le thème de carte ont été choisis :\n" +
                "Les cartes vont être étalées sur le plateau de jeu.\n");
            WriteLine("La partie commence, préparez-vous ! :\n");
            WriteLine("Le premier joueur retourne deux cartes.\n" +
                "Si les images sont identiques, il gagne la paire constituée, ajoute 1 point à son score et rejoue.\n" +
                "Si les images sont différentes, il les repose faces cachées là où elles étaient, ne gagne aucun point\n" +
                "et c'est au joueur suivant de jouer.\n ");
            WriteLine("Le jeu se déroule suivant ces règles.\n");
            WriteLine("La partie est terminée lorsque toutes les cartes ont été assemblées par paires.\n" +
                "Le joueur qui remporte la partie est celui qui possédera le plus de paires (donc de points),\n" +
                "lorsque celles-ci auront toutes été rassemblées.\n");
        }

        static void ShowLeaderboard()
        {
            Clear();
            WriteLine("=== Leaderboard ===\n");
            WriteLine("Not done yet");
        }

        static void ShowCredits()
        {
            Clear();
            WriteLine("=== Credits ===\n");
            WriteLine("Memory Game developed by Sami HALILOU, Ghassan JABBOUR, Mylan PERRIER.");
            WriteLine("We used .NET MAUI and C# to make this game.");
        }
    }
}