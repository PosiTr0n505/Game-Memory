using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;

namespace MemoryMAUI.Pages;

public partial class EndgameTwoPlayersScreenPage : ContentPage, IQueryAttributable
{
    public Player? Player1 { get; set; }
    public Player? Player2 { get; set; }
    public Player? Winner { get; set; }



    public EndgameTwoPlayersScreenPage()
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
        if (query.TryGetValue("player1", out var p1) && p1 is Player player1)
        {
            Player1 = player1;
            OnPropertyChanged(nameof(Player1));
        }
        if (query.TryGetValue("player2", out var p2) && p2 is Player player2)
        {
            Player2 = player2;
            OnPropertyChanged(nameof(Player2));
        }
        if (Player1 != null && Player2 != null)
        {
            if (Player1.CurrentScore > Player2.CurrentScore)
                Winner = Player1;
            else if (Player2.CurrentScore > Player1.CurrentScore)
                Winner = Player2;
            else
                Winner = null;
            OnPropertyChanged(nameof(Winner));
        }
    }
}