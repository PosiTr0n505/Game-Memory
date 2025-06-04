using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Collections;
using System.Collections.ObjectModel;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Gère les tailles de grilles prédéfinies et donne leurs dimensions associées.
    /// </summary>
    public class GridSizeManager : IGridSizeManager
    {
        /// <summary>
        /// Dictionnaire statique interne associant chaque taille de grille à ses dimensions (lignes, colonnes).
        /// </summary>
        private readonly static Dictionary<GridSize, (int, int)> _gridSizeValues = new()
        {
            { GridSize.Size1, (3, 4) },
            { GridSize.Size2, (5, 4) },
            { GridSize.Size3, (4, 6) },
            { GridSize.Size4, (5, 6) },
            { GridSize.Size5, (6, 6) },
            { GridSize.Size6, (6, 8) }
        };

        /// <summary>
        /// Dictionnaire en lecture seule exposant les tailles de grille et leurs dimensions.
        /// </summary>
        public static ReadOnlyDictionary<GridSize, (int, int)> Values { get; } =
            new ReadOnlyDictionary<GridSize, (int, int)>(_gridSizeValues);

        /// <summary>
        /// Obtient les dimensions (lignes, colonnes) associées à une taille de grille spécifiée.
        /// </summary>
        /// <param name="g">La taille de grille à interroger.</param>
        /// <returns>Un tuple contenant le nombre de lignes et le nombre de colonnes.</returns>
        /// <exception>Levée si la taille de grille fournie n'est pas valide.</exception>
        public static (int, int) GetGridSizeValues(GridSize g)
        {
            if (!_gridSizeValues.TryGetValue(g, out var sizeValues))
                throw new ArgumentException($"Invalid GridSize: {g}");
            return sizeValues;
        }
    }
}
