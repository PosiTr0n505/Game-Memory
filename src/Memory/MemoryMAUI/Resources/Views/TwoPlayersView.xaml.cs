using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class TwoPlayersView : ContentView
{
    public string NameTag1 { get; set; }
    public string NameTag2 { get; set; }
    private GridSize gsize;
    public TwoPlayersView()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        var player1Name = NameTag1.Trim();
        var player2Name = NameTag2.Trim();
        if (string.IsNullOrWhiteSpace(player1Name))
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Player 1's Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }
        if (string.IsNullOrWhiteSpace(player2Name))
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Player 2's Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }
        var gridSize = gsize;

        await Shell.Current.GoToAsync($"///singleplayergamepage?player1Name={player1Name}&player2Name={player2Name}&gridSize={gridSize}");
    }
}