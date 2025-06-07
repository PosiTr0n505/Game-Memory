
using MemoryConsole;
using MemoryConsole.Display;
using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using MemoryStubPersistence;
using System.Text;
using static System.Console;

namespace MemoryConsole
{
    internal static class Program
    {
        static void Main()
        {
            int selectedIndex = 0;
            string[] options = [
        "Single Player Game",
        "Two Players Game",
        "Game Rules",
        "Leaderboard",
        "Credits",
        "Quit Game"
            ];

            ConsoleColor defaultColor = ConsoleColor.White;
            ConsoleColor highlightColor = ConsoleColor.Green;

            while (true)
            {
                Console.Clear();
                int width = Console.WindowWidth;

                static string Center(string text, int w)
                {
                    int padding = Math.Max((w - text.Length) / 2, 0);
                    return new string(' ', padding) + text;
                }

                string[] asciiArt =
                [
            "╔╦╗╔═╗╔╦╗╔═╗╦═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗",
            "║║║║╣ ║║║║ ║╠╦╝╚╦╝  ║ ╦╠═╣║║║║╣ ",
            "╩ ╩╚═╝╩ ╩╚═╝╩╚═ ╩   ╚═╝╩ ╩╩ ╩╚═╝"
        ];

                WriteLine();

                foreach (var line in asciiArt)
                {
                    Console.WriteLine(Center(line, width));
                }

                Console.WriteLine("\n" + new string('─', width) + "\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = highlightColor;
                        Console.Write("  ► ");
                    }
                    else
                    {
                        Console.ForegroundColor = defaultColor;
                        Console.Write("    ");
                    }

                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                Console.ForegroundColor = defaultColor;
                Console.WriteLine("\n" + new string('─', width));
                Console.Write("\nUse ↑/↓ arrows to navigate, Enter to select");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Length;
                        break;

                    case ConsoleKey.NumPad1:
                        selectedIndex = 0;
                        break;

                    case ConsoleKey.NumPad2:
                        selectedIndex = 1;
                        break;

                    case ConsoleKey.NumPad3:
                        selectedIndex = 2;
                        break;

                    case ConsoleKey.NumPad4:
                        selectedIndex = 3;
                        break;

                    case ConsoleKey.NumPad5:
                        selectedIndex = 4;
                        break;

                    case ConsoleKey.NumPad6:
                        selectedIndex = 5;
                        break;

                    case ConsoleKey.Escape:
                        Clear();
                        return;

                    case ConsoleKey.Enter:
                        switch (selectedIndex)
                        {
                            case 0:
                                StartSinglePlayerGame();
                                break;
                            case 1:
                                StartTwoPlayersGame();
                                break;
                            case 2:
                                ShowGameRules();
                                ReadAndEnter();
                                break;
                            case 3:
                                ShowLeaderboard();
                                break;
                            case 4:
                                ShowCredits();
                                ReadAndEnter();
                                break;
                            case 5:
                                Console.Clear();
                                return;
                        }
                        break;
                }
            }
        }

        public static void ReadAndEnter()
        {
            Write("Press any key...");
            ReadLine();
        }

        static void StartSinglePlayerGame()
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

                card1coordinates = AskAndCheckCoordinates(gameManager, "1");

                card2coordinates = AskAndCheckCoordinates(gameManager, "2", card1coordinates);

                gameManager.PlayRound(card1coordinates.Item1, card1coordinates.Item2, card2coordinates.Item1, card2coordinates.Item2);

                WriteLine("Appuyez sur entrée pour continuer...");
                ReadLine();

                gameManager.HideCards();

                GridWriter.WriteGrid(gameManager, gameManager.Game.Grid.Cards);

            }

            gameManager.BoardChange -= GridWriter.WriteGrid;

            var score = new Score(gameManager.Game.CurrentPlayer, gameManager.Game.CurrentPlayer.CurrentScore, gameManager.Game.GridSize);

            ScoreManager leaderboard = new(new StubLoadManager(), new StubSaveManager());

            leaderboard.AddScore(score);

            EndScreen.DisplayEndScreen(score);

            ReadAndEnter();

        }

        static (int, int) AskAndCheckCoordinates(GameManager gameManager, string i)
        {
            (int, int) cardcoordinates;
            while (true)
            {
                try
                {
                    cardcoordinates = ConsoleAsking.AskCoordinates(i, gameManager.Game.Grid.X, gameManager.Game.Grid.Y);

                    if (gameManager.Game.Grid.IsCardFound(cardcoordinates.Item1, cardcoordinates.Item2))
                    {
                        WriteLine("You cannot select a card that is already found");
                        continue;
                    }
                    break;

                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            return cardcoordinates;
        }

        static (int, int) AskAndCheckCoordinates(GameManager gameManager, string i, (int, int) card1coordinates)
        {
            (int, int) cardcoordinates;
            while (true)
            {
                try
                {
                    cardcoordinates = ConsoleAsking.AskCoordinates(i, gameManager.Game.Grid.X, gameManager.Game.Grid.Y);

                    if (card1coordinates == cardcoordinates)
                    {
                        WriteLine("You cannot select the same card twice. Please select a different card.");
                        continue;
                    }

                    if (gameManager.Game.Grid.IsCardFound(cardcoordinates.Item1, cardcoordinates.Item2))
                    {
                        WriteLine("You cannot select a card that is already found");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            return cardcoordinates;
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
            (int, int) card2coordinates;

            gameManager.BoardChange += GridWriter.WriteGrid;

            System.Console.Clear();

            GridWriter.WriteGrid(gameManager, game.Grid.Cards);

            while (!gameManager.IsGameOver())
            {
                WriteLine($"{gameManager.Game.CurrentPlayer} : \n\n");

                card1coordinates = AskAndCheckCoordinates(gameManager, "1");

                card2coordinates = AskAndCheckCoordinates(gameManager, "2", card1coordinates);

                gameManager.PlayRound(card1coordinates.Item1, card1coordinates.Item2, card2coordinates.Item1, card2coordinates.Item2);

                WriteLine("Appuyez sur entrée pour continuer...");
                ReadLine();

                gameManager.HideCards();

                GridWriter.WriteGrid(gameManager, gameManager.Game.Grid.Cards);

            }

            EndScreen.DisplayEndScreen(new Score(gameManager.Game.CurrentPlayer, gameManager.Game.CurrentPlayer.CurrentScore, gameManager.Game.GridSize));

            ReadAndEnter();

            gameManager.BoardChange -= GridWriter.WriteGrid;
        }

        static void ShowGameRules()
        {
            Clear();

            int width = Math.Max(Console.WindowWidth, 40);

            string Center(string text)
            {
                int padding = (width - text.Length) / 2;
                return new string(' ', Math.Max(padding, 0)) + text;
            }

            WriteLine();
            WriteLine(Center("MEMORY GAME RULES"));
            WriteLine();

            WriteLine(Center("Match all pairs by flipping cards two at a time."));
            WriteLine(Center("The game ends when all pairs are found."));
            WriteLine();

            WriteLine(Center("[ SINGLEPLAYER ]"));
            WriteLine(Center("Flip 2 cards per turn."));
            WriteLine(Center("Match = 1 point + another turn."));
            WriteLine(Center("No match = flip back, try again."));
            WriteLine();

            WriteLine(Center("[ TWO-PLAYER ]"));
            WriteLine(Center("Players take turns."));
            WriteLine(Center("Match = 1 point + another turn."));
            WriteLine(Center("No match = next player's turn."));
            WriteLine(Center("Most points at the end wins."));
            WriteLine();

            WriteLine(Center("[ RULES ]"));
            WriteLine(Center("- Don't flip the same card twice."));
            WriteLine(Center("- Strategy and memory matter."));
            WriteLine();

            WriteLine(Center("Good luck!"));
        }

        static void ShowLeaderboard()
        {
            Clear();
            ScoreManager leaderboard = new(new StubLoadManager(), new StubSaveManager());

            LeaderboardWriter.WriteLeaderboard(leaderboard.Scores);

            var filterDisplay = "\nFiltrer par taille de grille : ";
            WriteLine(filterDisplay);

            int i = 1;

            StringBuilder gridSizeDisplay = new();

            foreach (var size in GridSizeManager.Values)
            {
                gridSizeDisplay.Append($"{i}. {size.Value}   ");
                ++i;
            }

            gridSizeDisplay.Append("\n7. Search by NameTag");

            WriteLine(gridSizeDisplay);

            var select = "\nSélection (Entrée pour quitter) : ";

            Write(select);

            while (true)
            {
                string? choice = ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                    break;

                if (int.TryParse(choice, out int selected) && selected > 0 && selected <= GridSizeManager.Values.Count + 1)
                {
                    Clear();

                    if (selected == GridSizeManager.Values.Count + 1)
                    {
                        Write("\nEnter the Name of the Player, Press Enter to Cancel : ");
                        string? name = ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                            break;

                        LeaderboardWriter.WriteLeaderboard(leaderboard.Scores, null, 15, name);
                        WriteLine(filterDisplay);
                        WriteLine(gridSizeDisplay);
                        Write(select);
                        continue;
                    }

                    LeaderboardWriter.WriteLeaderboard(leaderboard.Scores, GridSizeManager.Values.Keys.ToList()[selected - 1]);
                    WriteLine(filterDisplay);
                    WriteLine(gridSizeDisplay);
                    Write(select);
                    continue;
                }
                else
                {
                    Write("Entrée invalide, réessaie : ");
                }
            }
        }


        static void ShowCredits()
        {
            Console.Clear();
            int width = Console.WindowWidth;

            string Center(string text) =>
                new string(' ', Math.Max((width - text.Length) / 2, 0)) + text;

            string[] creditsText =
        [    
    "CREDITS",
    "",
    "This game was proudly crafted by:",
    "Sami HALILOU",
    "Ghassan JABBOUR",
    "Mylan PERRIER",
    "",
    "Built with ❤️ using C# and .NET MAUI",
    "",
    "Thanks for playing!"
];

            Console.WriteLine("\n" + new string('─', width) + "\n");
            foreach (string line in creditsText)
            {
                Console.WriteLine(Center(line));
            }
            Console.WriteLine("\n" + new string('─', width) + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}