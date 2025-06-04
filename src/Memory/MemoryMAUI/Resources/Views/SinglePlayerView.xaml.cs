using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class SinglePlayerView : ContentView
{
    public GameManager GMgr { get; private set; }
    public SinglePlayerView()
	{
        Player player = new("Player1");
        Game game = new(player, player, GridSize.Size1);
        GMgr = new GameManager(game);

        InitializeComponent();
        BindingContext = this;
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        var playerName = GMgr.Game.Player1.NameTag;
        var gridSize = GMgr.Game.GridSize.ToString();

        await Shell.Current.GoToAsync($"///singleplayergamepage?playerName={playerName}&gridSize={gridSize}");

    }
}