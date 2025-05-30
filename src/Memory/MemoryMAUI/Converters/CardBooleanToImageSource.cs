using System.Globalization;
using MemoryLib.Models;

namespace MemoryMAUI.Converters
{
    internal class CardBooleanToImageSource : IMultiValueConverter
    {
        private static readonly ImageSource HiddenImage = ImageSource.FromFile("hiddencard.png");
        private static readonly ImageSource VisibleImage = ImageSource.FromFile("visiblecard.png");

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is null || values[1] is null)
                return "hiddencard.png";

            bool isVisible = (bool)values[0];
            bool isFound = (bool)values[1];

            bool isVisibleOrFound = isVisible || isFound;

            return (isVisibleOrFound)
                ? HiddenImage
                : VisibleImage;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}