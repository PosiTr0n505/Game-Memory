using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryConsole.Display
{
    internal static class LeaderboardWriter
    {
        public static void WriteLeaderboard(IEnumerable<Score> scores, GridSize? gridSize = null, int max = 15, string? player = null)
        {
            if (scores == null)
            {
                Console.WriteLine("Aucun score à afficher.");
                return;
            }

            if (gridSize != null)
            {
                scores = scores.Where(s => s.GridSize == gridSize);
            }

            if (!string.IsNullOrWhiteSpace(player))
            {
                scores = scores.Where(s => s.Player.NameTag.Contains(player, StringComparison.OrdinalIgnoreCase));
            }

            // Tri des scores par valeur décroissante
            var sortedScores = scores.OrderByDescending(s => s.ScoreValue).ToList();

            Console.WriteLine();
            Console.WriteLine("┌──────────────────────── Leaderboard ────────────────────────┐");

            // En-tête du tableau
            Console.WriteLine("│ {0,-4} │ {1,-15} │ {2,-7} │ {3,-8} │ {4,-13} │",
                "Rank", "Player", "Score", "Grd Size", "Games Played");

            Console.WriteLine("├──────┼─────────────────┼─────────┼──────────┼───────────────┤");

            var gsm = new GridSizeManager();

            // Affichage des scores
            for (int i = 0; i < sortedScores.Count && i < max; i++)
            {
                var score = sortedScores[i];

                var gridValue = GridSizeManager.GetGridSizeValues(score.GridSize);

                Console.WriteLine("│ {0,-4} │ {1,-15} │ {2,-7} │ {3,-8} │ {4,-13} │",
                    $"{i + 1}",
                    score.Player.NameTag.Length > 15 ? string.Concat(score.Player.NameTag.AsSpan(0, 12), "...") : score.Player.NameTag,
                    score.ScoreValue,
                    $"{gridValue.Item1}x{gridValue.Item2}",
                    score.GamesPlayed
                    );
            }

            Console.WriteLine("└──────┴─────────────────┴─────────┴───────────────┴──────────┘");
        }
    }
}
