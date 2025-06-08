using MemoryLib.Managers;
using MemoryLib.Models;
using MemoryMAUI.Converters;
using System.Diagnostics;

namespace MemoryMAUI.Resources.Views;

public partial class SinglePlayerView : ContentView
{
    public string? NameTag { get; set; }
    private GridSize _gsize;
    public GridSize Gsize
    {
        get => _gsize;
        set
        {
            if (_gsize != value)
            {
                _gsize = value;
                OnPropertyChanged();
            }
        }
    }

    private void OnGridSizeSelected(object? sender, GridSize? selectedGridSize)
    {
        if (selectedGridSize.HasValue)
            Gsize = selectedGridSize.Value;
    }
    public SinglePlayerView()
	{
        InitializeComponent();
        BindingContext = this;
        GridSizes.GridSizeSelected += OnGridSizeSelected;
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        var playerName = NameTag?.Trim();

        var mainPage = Application.Current?.Windows[0].Page;

        if (mainPage is null)
            return;

        if (string.IsNullOrWhiteSpace(playerName))
        {
            await mainPage.DisplayAlert("Alert", "Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }
        var gridSize = Gsize;
        if (gridSize == GridSize.None)
        {
            await mainPage.DisplayAlert("Alert", "Please select a grid size", "Ok");
            return;
        }
        var navigationParameter = new Dictionary<string, object>
        {
            { "playerName", playerName },
            { "gridSize", gridSize }
        };

        await Shell.Current.GoToAsync("singleplayergamepage", navigationParameter);

    }

    private void EldenRingButtonClicked(object sender, EventArgs e)
    {
        CardBooleanToImageSource.SelectTheme("eldenring");
    }

    private void PokemonButtonClicked(object sender, EventArgs e)
    {
        CardBooleanToImageSource.SelectTheme("pokemon");
    }

    private async void CustomThemeButtonClicked(object sender, EventArgs e)
    {
        if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, "Images")))
            Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "Images"));

        var (hiddenCard, visibleCard) = CardBooleanToImageSource.Themes.GetValueOrDefault("custom");

        string? sourceHiddenCard = hiddenCard?.ToString()?.Replace("File:", "", StringComparison.OrdinalIgnoreCase)?.Trim();
        string? sourceVisibleCard = visibleCard?.ToString()?.Replace("File:", "", StringComparison.OrdinalIgnoreCase)?.Trim();

        if (string.IsNullOrWhiteSpace(sourceHiddenCard) || string.IsNullOrWhiteSpace(sourceVisibleCard))
            return;

        string imagesDir = Path.Combine(AppContext.BaseDirectory, "Images");

        string[] allowedExtensions = [".png", ".jpg", ".jpeg"];

        string? hiddenCardPath = allowedExtensions
            .Select(ext => Path.Combine(imagesDir, sourceHiddenCard + ext))
            .FirstOrDefault(File.Exists);

        string? visibleCardPath = allowedExtensions
            .Select(ext => Path.Combine(imagesDir, sourceVisibleCard + ext))
            .FirstOrDefault(File.Exists);

        if (hiddenCardPath is null || visibleCardPath is null)
        {

#if WINDOWS
            Process.Start("explorer.exe", imagesDir);
#elif MACCATALYST || MACOS
        Process.Start("open", imagesDir);
#elif LINUX
        Process.Start("xdg-open", imagesDir);
#endif

            var mainPage = Application.Current?.Windows[0].Page;

            if (mainPage is null)
                return;

            await mainPage.DisplayAlert(
                "Images not found",
                "You must place two image files in the 'Images' folder with supported extensions (.png, .jpg, .jpeg). " +
                "Expected filenames: customhiddencard and customvisiblecard.",
                "OK"
            );

            return;
        }

        CardBooleanToImageSource.SelectTheme("custom", hiddenCardPath, visibleCardPath);
    }

}