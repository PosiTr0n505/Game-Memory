using MemoryLib.Managers;
using MemoryLib.Models;
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

        await Shell.Current.GoToAsync("///singleplayergamepage", navigationParameter);

    }
}