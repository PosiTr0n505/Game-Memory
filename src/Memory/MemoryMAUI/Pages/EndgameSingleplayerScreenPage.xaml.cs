using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

namespace MemoryMAUI.Pages;

public partial class EndgameSingleplayerScreenPage : ContentPage, IQueryAttributable
{
    public Player? Player { get; set; }

    public EndgameSingleplayerScreenPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void NavigateToMainMenu(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///mainpage");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("player", out var playerObj) && playerObj is Player player)
        {
            Player = player;
            OnPropertyChanged(nameof(Player));
        }
    }
}