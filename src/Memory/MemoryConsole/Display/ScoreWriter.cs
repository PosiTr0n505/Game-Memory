using static System.Console;
using MemoryLib.Models;


namespace MemoryConsole.Display
{
    internal static class ScoreWriter
    {
        public static void OnScoreChange(Player player, int score)
        {
            Write($"{player.NameTag} : {score}");
        }
    }
}
