
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
                WriteLine("6. Quit Game");
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
            //gameManager.StartGame();
        }

        static void StartTwoPlayersGame()
        {
            Clear();
            WriteLine("Starting Two Players Game...");
            GameManager gameManager = new GameManager(new Game(new Player("Player 1"), new Player("Player 2"), GridSize.Size1));
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