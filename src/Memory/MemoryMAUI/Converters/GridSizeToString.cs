using System.Globalization;
using MemoryLib.Managers;
using MemoryLib.Models;


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
        throw new NotImplementedException();
    }
}