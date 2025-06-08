using System.ComponentModel;
using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;

namespace MemoryMAUI.Pages;
public partial class LeaderboardPage : ContentPage
{
    private readonly ScoreManager leaderboard;

    private GridSize? gridSize;

    private List<Score> _scoresI;

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
        if (e is null)
        {
            NameTagEntry.Text = "";
        }

        gridSize = e;

        var nameTag = NameTagEntry.Text;

        Scores =
        [
            .. _scoresI.Where(s =>
                (
                    string.IsNullOrWhiteSpace(nameTag)
                    || s.Player.NameTag.Contains(nameTag, StringComparison.OrdinalIgnoreCase)
                ) && (e == null || s.GridSize == e)
            ),
        ];
    }

    public LeaderboardPage(ScoreManager scoreManager)
    {
        leaderboard = scoreManager;
        _scoresI = [.. leaderboard.Scores.OrderBy(s => s.ScoreValue)];
        Scores = _scoresI;

        InitializeComponent();
        BindingContext = this;
        GridButtons.GridSizeSelected += OnGridSizeSelected;
        leaderboard.ScoresAdded += LeaderboardPage_ScoresAdded;
    }

    private void LeaderboardPage_ScoresAdded()
    {
        _scoresI = [.. leaderboard.Scores];
    }

    private async void NavigateToMainpage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///mainpage");
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue;

        Scores =
        [
            .. _scoresI.Where(s =>
                (
                    string.IsNullOrEmpty(text)
                    || s.Player.NameTag.Contains(text, StringComparison.OrdinalIgnoreCase)
                ) && (gridSize == null || s.GridSize == gridSize)
            ),
        ];
    }
}
