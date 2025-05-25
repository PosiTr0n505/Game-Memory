using MemoryLib.Models;
using Persistence;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MemoryMAUI.Pages;

public partial class LeaderboardPage : ContentPage, INotifyPropertyChanged
{

    private readonly ScoreManager leaderboard = new(new StubLoadManager(), new StubSaveManager());

    private List<Score> _scores = [];

    public List<Score> Scores
    {
        get => _scores;
        private set
        {
            _scores = value;
            OnPropertyChanged();
        }
    }

    private void OnGridSizeSelected(object? sender, GridSize? e)
	{
		Scores = [.. leaderboard.GetScores(e)];

    }


    public LeaderboardPage()
	{
		InitializeComponent();
        Scores = [.. leaderboard.Scores];
        GridButtons.GridSizeSelected += OnGridSizeSelected;
        BindingContext = this;
    }

    private async void NavigateToMainpage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///mainpage");
    }
}