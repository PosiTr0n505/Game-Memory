using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryConsole.Display
{
    internal class LeaderboardWriter
    {
        public static void WriteLeaderboard(IEnumerable<Score> scores, GridSize? gridSize = null, int max = 15)
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

            // Tri des scores par valeur décroissante
            var sortedScores = scores.OrderByDescending(s => s.ScoreValue).ToList();

            Console.WriteLine();
            Console.WriteLine("╔═════════════════════ TABLEAU DES SCORES ════════════════════╗");

            // En-tête du tableau
            Console.WriteLine("║ {0,-4} │ {1,-15} │ {2,-7} │ {3,-13} │ {4,-8} ║",
                "Rang", "Joueur", "Score", "Taille grille", "Parties");

            Console.WriteLine("╠══════╪═════════════════╪═════════╪═══════════════╪══════════╣");

            var gsm = new GridSizeManager();

            // Affichage des scores
            for (int i = 0; i < sortedScores.Count && i < max; i++)
            {
                var score = sortedScores[i];
                Console.WriteLine("║ {0,-4} │ {1,-15} │ {2,-7} │ {3,-13} │ {4,-8} ║",
                    $"{i + 1}",
                    score.Player.NameTag.Length > 15 ? score.Player.NameTag.Substring(0, 12) + "..." : score.Player.NameTag,
                    score.ScoreValue,
                    gsm.GetGridSizeValues(score.GridSize),
                    score.GamesPlayed
                    );
            }

            Console.WriteLine("╚══════╧═════════════════╧═════════╧═══════════════╧══════════╝");
        }
    }
}
