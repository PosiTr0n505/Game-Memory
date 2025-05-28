
using System.Globalization;

namespace MemoryMAUI.Converters
{
    internal class CardBooleanToImageSource : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) throw new NullReferenceException(nameof(value));

            return ((bool)value) ? "hiddencard.png" : "visiblecard.png";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}