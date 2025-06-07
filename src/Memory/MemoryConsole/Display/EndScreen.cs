using MemoryLib.Models;
using MemoryLib.Managers;
using System;

namespace MemoryConsole.Display
{
    internal static class EndScreen
    {
        public static void DisplayEndScreen(Score score)
        {
            Console.Clear();

            // Define console dimensions
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            // Define colors
            ConsoleColor originalColor = Console.ForegroundColor;
            ConsoleColor titleColor = ConsoleColor.Cyan;
            ConsoleColor playerColor = ConsoleColor.Yellow;
            ConsoleColor scoreColor = ConsoleColor.Green;
            ConsoleColor borderColor = ConsoleColor.Magenta;

            // Upper border
            Console.ForegroundColor = borderColor;
            string border = new('═', width - 2);
            Console.SetCursorPosition(1, 1);
            Console.Write(border);

            // Title
            string title = "End Game";
            Console.ForegroundColor = titleColor;
            Console.SetCursorPosition((width - title.Length) / 2, 3);
            Console.WriteLine(title);

            // Display player name and score
            Console.ForegroundColor = playerColor;
            string playerName = $"Player : {score.Player.NameTag}";
            Console.SetCursorPosition((width - playerName.Length) / 2, 6);
            Console.WriteLine(playerName);

            // Display score
            Console.ForegroundColor = scoreColor;
            string scoreText = $"Score : {score.ScoreValue} points";
            Console.SetCursorPosition((width - scoreText.Length) / 2, 8);
            Console.WriteLine(scoreText);

            // Display Moves count
            string movesText = $"Moves Count : {score.Player.MovesCount}";
            Console.SetCursorPosition((width - movesText.Length) / 2, 9);
            Console.WriteLine(movesText);

            // Display grid size
            string sizeText = $"Grid Size : {GridSizeManager.GetGridSizeValues(score.GridSize)}";
            Console.SetCursorPosition((width - sizeText.Length) / 2, 10);
            Console.WriteLine(sizeText);

            // Display message based on score
            string message = GetMessageBasedOnScore(score.ScoreValue, score.GridSize);
            Console.ForegroundColor = titleColor;
            Console.SetCursorPosition((width - message.Length) / 2, 14);
            Console.WriteLine(message);

            // Down border
            Console.ForegroundColor = borderColor;
            Console.SetCursorPosition(1, height - 2);
            Console.Write(border);

            // Reset console color
            Console.ForegroundColor = originalColor;
        }

        private static string GetMessageBasedOnScore(int score, GridSize g)
        {
            var item = GridSizeManager.GetGridSizeValues(g);

            if (score <= item.Item1 * item.Item2 + 3)
                return "Perfection !";

            return "You can do better !";
        }
    }
}

