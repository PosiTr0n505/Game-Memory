using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class GridSizeManagerTest
    {
        [Theory]
        [InlineData(GridSize.Size1, 2, 2)]
        [InlineData(GridSize.Size2, 3, 4)]
        [InlineData(GridSize.Size3, 4, 4)]
        [InlineData(GridSize.Size4, 5, 4)]
        [InlineData(GridSize.Size5, 6, 5)]
        [InlineData(GridSize.Size6, 7, 6)]
        public void GetGridSizeValues_Returns_Expected_Values(GridSize size, int expectedRows, int expectedCols)
        {
            GridSizeManager manager = new();

            var (rows, cols) = manager.GetGridSizeValues(size);

            Assert.Equal(expectedRows, rows);
            Assert.Equal(expectedCols, cols);
        }

        [Fact]
        public void GetGridSizeValues_InvalidValue_ThrowsArgumentException()
        {
            var manager = new GridSizeManager();
            var invalidValue = (GridSize)999;

            Assert.Throws<ArgumentException>(() => manager.GetGridSizeValues(invalidValue));
        }
    }

}

