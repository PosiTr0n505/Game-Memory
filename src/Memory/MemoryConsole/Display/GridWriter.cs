using MemoryLib.Managers;
using MemoryLib.Models;
using static System.Console;

namespace MemoryConsole.Display
{
    public static class GridWriter
    {
        public static void WriteGrid(GameManager sender, IEnumerable<Card> grid)
        {
            Console.Clear();

            int xSize = sender.Game.Grid.Y; // Colonnes
            int ySize = sender.Game.Grid.X; // Lignes
            // On inverse les deux pour un affichage correspondant aux indices

            var cardsArray = grid.ToArray(); // Stocké en row-major : (x, y) → index = y * xSize + x

            // En-tête des lignes Y (horizontal)
            Write("    ");
            for (int y = 0; y < ySize; y++)
            {
                Write($"{y,2} ");
            }
            WriteLine();

            // Ligne de séparation
            Write("   +");
            for (int y = 0; y < ySize; y++)
            {
                Write("---");
            }
            WriteLine();

            // Pour chaque colonne X (vertical)
            for (int x = 0; x < xSize; x++)
            {
                Write($"{x,2} |"); // numéro de colonne affichée comme ligne

                for (int y = 0; y < ySize; y++)
                {
                    int index = y * xSize + x; // Toujours row-major
                    if (index >= cardsArray.Length)
                    {
                        Write("   ");
                        continue;
                    }

                    var c = cardsArray[index];

                    if (c == null)
                    {
                        Write("   ");
                    }
                    else if (c.IsFound || c.IsFaceUp)
                    {
                        Write($" {c} ");
                    }
                    else
                    {
                        Write($" X ");
                    }
                }

                WriteLine();
            }

            WriteLine();
        }


    }
}
