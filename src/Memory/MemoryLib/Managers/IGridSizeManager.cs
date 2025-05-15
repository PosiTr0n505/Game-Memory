using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public interface IGridSizeManager
    {
        /// <summary>
        /// Retrieves the width and height values corresponding to the specified grid size.
        /// </summary>
        /// <param name="g">The grid size enumeration value.</param>
        /// <returns>A tuple containing the width and height as integers.</returns>
        (int, int) GetGridSizeValues(GridSize g);
    }
}
