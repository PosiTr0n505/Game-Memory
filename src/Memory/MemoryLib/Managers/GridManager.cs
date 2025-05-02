using MemoryLib.Models;
namespace MemoryLib.Managers
{
    public class GridManager : IGridManager
    {
        public void ClearGrid(Grid grid)
        {
            grid.Clear();
        }

        public void InitializeGrid()
        {
            throw new NotImplementedException();
        }
    }
}
