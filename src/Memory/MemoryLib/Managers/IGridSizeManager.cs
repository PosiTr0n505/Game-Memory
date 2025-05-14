using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public interface IGridSizeManager
    {
        public (int, int) GetGridSizeValues(GridSize g);
    }
}
