﻿using MemoryLib.Models;

namespace MemoryLib.Managers.Interface
{
    public interface IGridSizeManager
    {
        /// <summary>
        /// Retrieves the width and height values corresponding to the specified grid size.
        /// </summary>
        /// <param name="g">The grid size enumeration value.</param>
        /// <returns>A tuple containing the width and height as integers.</returns>
        public abstract static (int, int) GetGridSizeValues(GridSize g);
    }
}
