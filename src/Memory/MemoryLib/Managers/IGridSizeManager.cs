using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public interface IGridSizeManager
    {
        (int, int) GetGridSizeValues(GridSize g);
    }
}
