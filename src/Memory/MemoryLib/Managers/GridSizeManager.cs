using MemoryLib.Models;
using System.Collections;
using System.Collections.ObjectModel;

namespace MemoryLib.Managers
{

    public class GridSizeManager : IGridSizeManager
    {
        public GridSizeManager()
        {
            Values = new ReadOnlyDictionary<GridSize, (int, int)>(_gridSizeValues);
        }

        private Dictionary<GridSize, (int, int)> _gridSizeValues = new()
        {
            { GridSize.Size1, (2, 2) },
            { GridSize.Size2, (3, 4) },
            { GridSize.Size3, (4, 4) },
            { GridSize.Size4, (5, 4) },
            { GridSize.Size5, (6, 5) },
            { GridSize.Size6, (7, 6) }
        };

        public ReadOnlyDictionary<GridSize, (int, int)> Values { get; }

        public (int, int) GetGridSizeValues(GridSize g)
        {
            return g switch
            {
                GridSize.Size1 => (2, 2),
                GridSize.Size2 => (3, 4),
                GridSize.Size3 => (4, 4),
                GridSize.Size4 => (5, 4),
                GridSize.Size5 => (6, 5),
                GridSize.Size6 => (7, 6),
                _ => throw new ArgumentException("Invalid GridSize value"),
            };
        }
    }
}
