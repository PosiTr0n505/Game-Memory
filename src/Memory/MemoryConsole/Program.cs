
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
                System.Console.Clear();
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
            WriteLine("Starting Single Player Game...\nEnter your Name\n");

            ConsoleAsking.AskPlayersName("1", out string Player1Name);

            WriteLine();

            GridSize gridSize = ConsoleAsking.AskGridSize();

            Player player1 = new(Player1Name);

            Game game = new(player1, player1, gridSize);

            GameManager gameManager = new(game);

            (int, int) card1coordinates;
            (int, int) card2coordinates;

            gameManager.BoardChange += GridWriter.WriteGrid;

            System.Console.Clear();

            GridWriter.WriteGrid(gameManager, game.Grid.Cards);

            while (!gameManager.IsGameOver())
            {
                WriteLine($"{gameManager.Game.CurrentPlayer} : \n\n");

                while (true)
                {
                    try
                    {
                        card1coordinates = ConsoleAsking.AskCoordinates("1", gameManager.Game.Grid.X, gameManager.Game.Grid.Y);

                        if (gameManager.Game.Grid.IsCardFound(card1coordinates.Item1, card1coordinates.Item2))
                        {
                            WriteLine("You cannot select a card that is already found");
                            continue;
                        }

                        break;

                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                        continue;
                    }
                }

                while (true)
                {
                    try
                    {
                        card2coordinates = ConsoleAsking.AskCoordinates("2", gameManager.Game.Grid.X, gameManager.Game.Grid.Y);

                        if (card1coordinates == card2coordinates)
                        {
                            WriteLine("You cannot select the same card twice. Please select a different card.");
                            continue;
                        }

                        if (gameManager.Game.Grid.IsCardFound(card2coordinates.Item1, card2coordinates.Item2))
                        {
                            WriteLine("You cannot select a card that is already found");
                            continue;
                        }

                        else
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                        continue;
                    }
                }

                gameManager.playRound(card1coordinates.Item1, card1coordinates.Item2, card2coordinates.Item1, card2coordinates.Item2);

                WriteLine("Appuyez sur entrée pour continuer...");
                ReadLine();

                gameManager.HideCards();

                GridWriter.WriteGrid(gameManager, gameManager.Game.Grid.Cards);

            }

            gameManager.BoardChange -= GridWriter.WriteGrid;

        }

        static void StartTwoPlayersGame()
        {
            Clear();
            WriteLine("Starting Two Players Game...\nEnter The Name of the 2 Players\n");

            ConsoleAsking.AskPlayersName("1", out string Player1Name);

            ConsoleAsking.AskPlayersName("2", out string Player2Name);

            while (Player1Name == Player2Name)
            {
                WriteLine("Please enter a different name for Player 2.");
                ConsoleAsking.AskPlayersName("2", out Player2Name);
            }

            WriteLine();
            GridSize gridSize = ConsoleAsking.AskGridSize();

            Player player1 = new(Player1Name);
            Player player2 = new(Player2Name);

            Game game = new(player1, player2, gridSize);

            GameManager gameManager = new(game);

            (int, int) card1coordinates;
            (int, int) card2coordiantes;

            gameManager.BoardChange += GridWriter.WriteGrid;
            
            System.Console.Clear();

            GridWriter.WriteGrid(gameManager, game.Grid.Cards);

            while (!gameManager.IsGameOver())
            {
                WriteLine($"{gameManager.Game.CurrentPlayer} : \n\n");

                while (true)
                {
                    try
                    {
                        card1coordinates = ConsoleAsking.AskCoordinates("1", gameManager.Game.Grid.X, gameManager.Game.Grid.Y);
                        break;

                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                        continue;
                    }
                }

                while (true)
                {
                    try
                    {
                        card2coordiantes = ConsoleAsking.AskCoordinates("2", gameManager.Game.Grid.X, gameManager.Game.Grid.Y);
                        if (card1coordinates == card2coordiantes)
                        {
                            WriteLine("You cannot select the same card twice. Please select a different card.");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                        continue;
                    }
                }

                gameManager.playRound(card1coordinates.Item1, card1coordinates.Item2, card2coordiantes.Item1, card2coordiantes.Item2);

                WriteLine("Appuyez sur entrée pour continuer...");
                ReadLine();

                gameManager.HideCards();

                GridWriter.WriteGrid(gameManager, gameManager.Game.Grid.Cards);

            }
            
            gameManager.BoardChange -= GridWriter.WriteGrid;

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