using MemoryLib.Managers;
using MemoryLib.Models;

namespace MemoryMAUI.Pages;

public partial class TwoPlayersGamePage : ContentPage
{
	public GameManager GameManager { get; private init; } = new(new Game("Player1", "Player2", GridSize.Size1));
	public TwoPlayersGamePage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}