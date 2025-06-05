using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

namespace MemoryMAUI.Pages;

public partial class EndgameTwoPlayersScreenPage : ContentPage
{

    public GameManager GameManager { get; } = new(new Game("Player1", "Player2", GridSize.Size2));
    public EndgameTwoPlayersScreenPage()
    {
        BindingContext = this;
        InitializeComponent();
	}
}