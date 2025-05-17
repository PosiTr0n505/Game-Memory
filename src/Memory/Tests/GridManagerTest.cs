using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class GridManagerTest
    {
        [Fact]
        public void Clear_should_clear_grid()
        {
            var grid = new Grid(4, 4);
            var gridManager = new GridManager();

            gridManager.Clear(grid);

            Assert.True(grid.IsEmpty());
        }
    }
}
