using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public class GridSizeManager : IGridSizeManager
    {
        public (int, int) GetGridSizeValues(GridSize g)
        {
            switch (g)
            {
                case GridSize.Size1: return (2, 2);
                case GridSize.Size2: return (3, 4);
                case GridSize.Size3: return (4, 4);
                case GridSize.Size4: return (5, 4);
                case GridSize.Size5: return (6, 5);
                case GridSize.Size6: return (7, 6);
                default: throw new ArgumentException("Invalid GridSize value");
            }
        }
    }
}
