using MemoryLib.Models;


namespace MemoryMAUI.Pages;

public partial class SingleplayerPage : ContentPage
{

	public Player Player { get; private set; }
	public SingleplayerPage()
	{
		InitializeComponent();
		Player = new Player("Player 1");
		BindingContext = Player;
    }
}