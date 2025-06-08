using MemoryLib.Managers;
using MemoryLib.Models;
using System.Diagnostics;

namespace MemoryMAUI.Resources.Views;

public partial class TwoPlayersView : ContentView
{
    public string? NameTag1 { get; set; }
    public string? NameTag2 { get; set; }

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
    public TwoPlayersView()
    {
        InitializeComponent();
        BindingContext = this;
        GridSizes.GridSizeSelected += OnGridSizeSelected;
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        var player1Name = NameTag1?.Trim();
        var player2Name = NameTag2?.Trim();

        var mainPage = Application.Current?.Windows[0].Page;

        if (mainPage is null)
            return;

        if (string.IsNullOrWhiteSpace(player1Name))
        {
            await mainPage.DisplayAlert("Alert", "Player 1's Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }
        if (string.IsNullOrWhiteSpace(player2Name))
        {
            await mainPage.DisplayAlert("Alert", "Player 2's Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }

        if (player1Name.Equals(player2Name))
        {
            await mainPage.DisplayAlert("Alert", "Player 1's Name Tag and Player 2's Name Tag cannot be equal", "Ok");
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
            { "player1Name", player1Name },
            { "player2Name", player2Name },
            { "gridSize", gridSize }
        };
        await Shell.Current.GoToAsync("twoplayersgamepage", navigationParameter);
    }
}
