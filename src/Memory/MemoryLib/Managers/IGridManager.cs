using System;
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public interface IGridManager
    {
        void InitializeGrid();

        void ClearGrid(Grid grid);
    }
}
