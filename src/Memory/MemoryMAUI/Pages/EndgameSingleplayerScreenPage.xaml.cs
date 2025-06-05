using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

namespace MemoryMAUI.Pages;

public partial class EndgameSingleplayerScreenPage : ContentPage
{
    private readonly Player _player;

    public GameManager GameManager { get; }
    public EndgameSingleplayerScreenPage()
	{
        _player = new("dqdqd");
        GameManager = new(new Game(_player, _player, GridSize.Size2));
        InitializeComponent();
        BindingContext = this;
    }
}