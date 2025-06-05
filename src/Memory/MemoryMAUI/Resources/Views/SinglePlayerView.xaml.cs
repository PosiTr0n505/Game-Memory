using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class SinglePlayerView : ContentView
{
    public string NameTag { get; set; }
    private GridSize gsize;
    public SinglePlayerView()
	{
        InitializeComponent();
        BindingContext = this;
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        var playerName = NameTag.Trim();
        if(string.IsNullOrWhiteSpace(playerName))
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Name Tag is required and must not be empty or contain only spaces", "Ok");
            return;
        }
        var gridSize = gsize;

        await Shell.Current.GoToAsync($"///singleplayergamepage?playerName={playerName}&gridSize={gridSize}");

    }
}