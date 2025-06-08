using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using MemoryMAUI.Resources.Templates;


namespace MemoryMAUI.Pages;
public partial class SingleplayerGamePage : ContentPage, IQueryAttributable
{
    private Card? _card1 = null;
    private Card? _card2 = null;
    private int _cardsClickedCount = 0;
    private readonly ISaveManager _saver;

    public string? PlayerName { get; set; }

    public GridSize GridSize { get; set; }

    private GameManager? _gameManager;
    public GameManager? GameManager
    {
        get => _gameManager;
        private set
        {
            _gameManager = value;
            OnPropertyChanged();
        }
    }

    private void InitializeGame()
    {
        var player = new Player(PlayerName);
        GameManager = new GameManager(new Game(player, player, GridSize));
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("playerName", out var value))
            PlayerName = value as string;

        if (query.TryGetValue("gridSize", out value))
        {
            var gridSizeValue = value;
            GridSize = (GridSize)gridSizeValue;
        }
        if (GridSize != GridSize.None)
            InitializeGame();
    }

    private bool _waitContinuePressed = false;

    public bool WaitContinuePressed
    {
        get => _waitContinuePressed;

        set
        {
            _waitContinuePressed = value;
            OnPropertyChanged();
        }
    }

    private readonly IScoreManager _scoreManager;

    public SingleplayerGamePage(IScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
        InitializeComponent();
        BindingContext = this;
        CardTemplate.OnCardClicked += OnCardClicked;
        _saver = App.Current.Handler.MauiContext.Services.GetService<ISaveManager>()!;
    }

    private void SaveGameScore()
    {
        try
        {
            var player = GameManager.Game.CurrentPlayer;

            var score = new Score(
                player,
                player.CurrentScore,
                GridSize,
                player.GamesPlayed
            );

            _saver.SaveScores([score]);
        }
        catch
        {
        }
    }


    private void OnContinueButtonClicked(object sender, EventArgs e)
    {
        if (!WaitContinuePressed)
            return;

        GameManager?.HideCards();
        _cardsClickedCount = 0;
        WaitContinuePressed = false;
    }

    public void OnCardClicked(View sender, Card card)
    {
        if (GameManager is null)
        {
            return;
        }

        if (WaitContinuePressed)
        {
            WaitContinuePressed = false;
            GameManager.HideCards();
            return;
        }

        if (card.IsFound)
            return;

        if (_cardsClickedCount == 1 && ReferenceEquals(_card1, card))
        {
            return;
        }

        card.IsVisible = true;

        _cardsClickedCount += 1;

        if (_cardsClickedCount == 1)
            _card1 = card;

        if (_cardsClickedCount == 2)
        {
            GameManager.Game.CurrentPlayer.Add1ToMovesCount();
            _card2 = card;
            if (GameManager.Game.Grid.CompareCards(_card1!, _card2!))
            {
                _card1!.IsFound = true;
                _card2.IsFound = true;
                GameManager.Game.CurrentPlayer.Add1ToScore();
                GameManager.Game.ReduceCountByOnePair();
                if (GameManager.Game.IsGameOver())
                {
                    GameManager.Game.CurrentPlayer.IncrementGamesPlayed();
                    SaveGameScore();
                    return;
                }
            }
            else
            {
                GameManager.SwitchPlayers();
            }
            if (GameManager.IsGameOver())
            {
                var player = GameManager.Game.Player1;

                var navigationParameter = new Dictionary<string, object>
            {
                { nameof(player), player }
            };

                Shell.Current.GoToAsync("///endgamesingleplayerscreenpage", navigationParameter);
                return;
            }

            _waitContinuePressed = true;
            _cardsClickedCount = 0;
        }
    }
}