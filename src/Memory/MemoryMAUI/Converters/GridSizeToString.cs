using System.Globalization;
using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Converters;
public class GridSizeToString : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is GridSize gridSize && GridSizeManager.Values.TryGetValue(gridSize, out var result))
            return $"{result.Item1}x{result.Item2}";

        return "ERROR";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string strValue)
        {
            var parts = strValue.Split('x');
            if (parts.Length == 2 && int.TryParse(parts[0], out int width) && int.TryParse(parts[1], out int height))
            {
                foreach (var gridSize in GridSizeManager.Values)
                {
                    if (gridSize.Value.Item1 == width && gridSize.Value.Item2 == height)
                        return gridSize.Key;
                }
            }
        }
        throw new ArgumentException($"Invalid grid size string: {value}. Unable to convert back.");
    }

}