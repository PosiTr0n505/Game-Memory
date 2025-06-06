using MemoryLib.Managers;
using MemoryLib.Models;
using System.Diagnostics;

namespace MemoryMAUI.Resources.Views;

public partial class SinglePlayerView : ContentView
{
    public string NameTag { get; set; }
    private GridSize _gsize;
    public GridSize gsize
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
            gsize = selectedGridSize.Value;
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
        if(string.IsNullOrWhiteSpace(playerName))
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }
        var gridSize = gsize;
        if (gridSize == GridSize.None)
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Please select a grid size", "Ok");
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