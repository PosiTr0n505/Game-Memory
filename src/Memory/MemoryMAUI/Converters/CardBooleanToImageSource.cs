using System.Globalization;
using MemoryLib.Models;

namespace MemoryMAUI.Converters
{
    internal class CardBooleanToImageSource : IMultiValueConverter
    {
        public static ImageSource HiddenImage = ImageSource.FromFile("eldenringhiddencard.png");
        public static ImageSource VisibleImage = ImageSource.FromFile("eldenringvisiblecard.png");

        public static readonly Dictionary<string, (ImageSource hiddenCard, ImageSource visibleCard)> Themes = new()
        {
            { "eldenring", (ImageSource.FromFile("eldenringhiddencard.png"), ImageSource.FromFile("eldenringvisiblecard.png")) },
            { "pokemon", (ImageSource.FromFile("pokemonhiddencard.png"), ImageSource.FromFile("pokemonvisiblecard.png")) },
            { "custom", (ImageSource.FromFile("customhiddencard"), ImageSource.FromFile("customvisiblecard")) }

        };

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is null || values[1] is null)
                return HiddenImage;

            bool isVisible = (bool)values[0];
            bool isFound = (bool)values[1];

            bool isVisibleOrFound = isVisible || isFound;

            return (isVisibleOrFound)
                ? VisibleImage
                : HiddenImage;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static void SelectTheme(string theme, string? hiddencardPath = null, string? visiblecardPath = null)
        {
            var (hiddenCard, visibleCard) = Themes.GetValueOrDefault(theme);

            if (hiddencardPath is not null && visiblecardPath is not null && theme == "custom")
            {
                HiddenImage = ImageSource.FromFile(hiddencardPath);
                VisibleImage = ImageSource.FromFile(visiblecardPath);
                return;
            }

            HiddenImage = hiddenCard;
            VisibleImage = visibleCard;
        }
    }
}