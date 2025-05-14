
using MemoryConsole;
using MemoryConsole.Display;
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

                WriteLine("\n\nPress any key to return to the main menu...");
                ReadKey();
            }
        }

        static void StartSingleplayerGame()
        {
            Clear();

            string playerName = ConsoleAsking.AskPlayersName("1");

            Player player = new Player(playerName);

            GridSize gridSize = ConsoleAsking.AskGridSize();

            Game g = new Game(player, player, gridSize);

            GameManager gameManager = new GameManager(g);

            gameManager.Game.StartGame();

            GridWriter.WriteGrid(gameManager, g.Grid.Cards);

        }

        static void StartTwoPlayersGame()
        {
            Clear();
            WriteLine("Starting Two Players Game...\nEnter The Name of the 2 Players\n");

            string P1Name = ConsoleAsking.AskPlayersName("1");

            string P2Name = ConsoleAsking.AskPlayersName("2");

            while (P1Name == P2Name)
            {
                WriteLine("Please enter a different name for Player 2.");
                P2Name = ConsoleAsking.AskPlayersName("2");
            }

            WriteLine();
            GridSize gridSize = ConsoleAsking.AskGridSize();

            Player player1 = new Player(P1Name);
            Player player2 = new Player(P2Name);

            Game game = new Game(player1, player2, gridSize);

            GameManager gameManager = new GameManager(game);
            gameManager.StartGame();
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