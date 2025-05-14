using static System.Console;
using MemoryLib.Models;


namespace MemoryConsole.Display
{
    internal class ScoreWriter
    {
        public void OnScoreChange(Player player, int score)
        {
            Write($"{player.NameTag} : {score}");
        }
    }
}
