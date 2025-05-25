using System.ComponentModel;
using System.Runtime.CompilerServices;
using MemoryLib.Models;
using Persistence;

namespace MemoryMAUI.Pages;

public partial class LeaderboardPage : ContentPage, INotifyPropertyChanged
{
    private readonly ScoreManager leaderboard = new(new StubLoadManager(), new StubSaveManager());

    private GridSize? gridSize;

    private readonly List<Score> _scoresI = [];

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

    public LeaderboardPage()
    {
        InitializeComponent();
        _scoresI = [.. leaderboard.Scores.OrderBy(s => s.ScoreValue)];
        Scores = _scoresI;
        GridButtons.GridSizeSelected += OnGridSizeSelected;
        BindingContext = this;
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
