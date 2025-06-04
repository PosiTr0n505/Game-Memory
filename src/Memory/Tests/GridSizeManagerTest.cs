using MemoryLib.Managers;
using MemoryLib.Models;
using Gm = MemoryLib.Managers.GridSizeManager;

namespace Tests
{
    public class GridSizeManagerTest
    {
        [Theory]
        [InlineData(GridSize.Size1)]
        [InlineData(GridSize.Size2)]
        [InlineData(GridSize.Size3)]
        [InlineData(GridSize.Size4)]
        [InlineData(GridSize.Size5)]
        [InlineData(GridSize.Size6)]
        public void GetGridSizeValues_Returns_Expected_Values(GridSize size)
        {
            int expectedRows = GridSizeManager.GetGridSizeValues(size).Item1;
            int expectedCols = GridSizeManager.GetGridSizeValues(size).Item2;

            GridSizeManager manager = new();

            var (rows, cols) = GridSizeManager.GetGridSizeValues(size);

            Assert.Equal(expectedRows, rows);
            Assert.Equal(expectedCols, cols);
        }

        [Fact]
        public void GetGridSizeValues_InvalidValue_ThrowsArgumentException()
        {
            var manager = new GridSizeManager();
            var invalidValue = (GridSize)999;

            Assert.Throws<ArgumentException>(() => GridSizeManager.GetGridSizeValues(invalidValue));
        }
    }

}

