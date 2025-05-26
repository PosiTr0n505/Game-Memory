using MemoryLib.Models;

namespace MemoryMAUI.Pages;

public partial class TwoPlayersPage : ContentPage
{
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }

    public TwoPlayersPage()
    {
        InitializeComponent();
        Player1 = new Player("Player 1");
        Player2 = new Player("Player 2");
        BindingContext = this;
    }
}
