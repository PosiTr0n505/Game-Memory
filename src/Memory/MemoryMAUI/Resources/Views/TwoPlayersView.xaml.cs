using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Resources.Views;

public partial class TwoPlayersView : ContentView
{
    public GameManager GMgr { get; private set; }
    public TwoPlayersView()
	{
        Player p1 = new("Player1");
        Player p2 = new("Player2");
        Game game = new(p1, p2, GridSize.Size1);
        GMgr = new GameManager(game);

        InitializeComponent();
        BindingContext = this;
    }
    private async void OnClickedStartGame(object sender, EventArgs e)
    {
        var player1Name = GMgr.Game.Player1.NameTag;
        var player2Name = GMgr.Game.Player2.NameTag;
        var gridSize = GMgr.Game.GridSize.ToString();

        await Shell.Current.GoToAsync($"///singleplayergamepage?p1Name={player1Name}&p2Name={player2Name}&gridSize={gridSize}");
    }
}