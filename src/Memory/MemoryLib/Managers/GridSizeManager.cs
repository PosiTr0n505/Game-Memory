using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using System.Collections;
using System.Collections.ObjectModel;

namespace MemoryLib.Managers
{

    public class GridSizeManager : IGridSizeManager
    {
        private static Dictionary<GridSize, (int, int)> _gridSizeValues = new Dictionary<GridSize, (int, int)>
            {
                { GridSize.Size1, (2, 2) },
                { GridSize.Size2, (3, 4) },
                { GridSize.Size3, (4, 4) },
                { GridSize.Size4, (5, 4) },
                { GridSize.Size5, (6, 5) },
                { GridSize.Size6, (7, 6) }
            };

        public static ReadOnlyDictionary<GridSize, (int, int)> Values { get; } =
            new ReadOnlyDictionary<GridSize, (int, int)>(_gridSizeValues);

        public (int, int) GetGridSizeValues(GridSize g)
        {
            if (!_gridSizeValues.TryGetValue(g, out var sizeValues))
                throw new ArgumentException($"Invalid GridSize: {g}");
            return sizeValues;
        }
    }
}
