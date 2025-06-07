using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;
using MemoryStubPersistence;
using MemoryLib.Managers.Interface;


namespace MemoryMAUI.Pages;
public partial class TwoPlayersGamePage : ContentPage, IQueryAttributable
{
    private Card? _card1 = null;
    private Card? _card2 = null;
    private int _cardsClickedCount = 0;

    public string? Player1Name{ get; set; }

    public string? Player2Name{ get; set; }

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

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("player1Name", out object? value) && value is string player1NameValue)
            Player1Name = player1NameValue;

        if (query.TryGetValue("player2Name", out value) && value is string player2NameValue)
            Player2Name = player2NameValue;

        if (query.TryGetValue("gridSize", out value))
        {
            GridSize = (GridSize)value;
        }

        if (GridSize != GridSize.None)
        {
            InitializeGame();
        }
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

    private void InitializeGame()
    {
        var player1 = new Player(Player1Name);
        var player2 = new Player(Player2Name);
        GameManager = new GameManager(new Game(player1, player2, GridSize));
    }

    private readonly IScoreManager _scoreManager;

    public TwoPlayersGamePage(IScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
        InitializeComponent();
        BindingContext = this;
        WaitContinuePressed = false;
        CardTemplate.OnCardClicked += OnCardClicked;
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
        if (WaitContinuePressed)
        {
            WaitContinuePressed = false;
            GameManager?.HideCards();
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

        if (_cardsClickedCount == 2 && GameManager is not null)
        {
            GameManager.Game.CurrentPlayer.Add1ToMovesCount();
            _card2 = card;
            if (GameManager.Game.Grid.CompareCards(_card1!, _card2!))
            {
                _card1!.IsFound = true;
                _card2.IsFound = true;
                GameManager.Game.CurrentPlayer.Add1ToScore();
                GameManager.Game.ReduceCountByOnePair();
            }
            else 
            {
                GameManager.SwitchPlayers();
            }
	    
            if (GameManager.IsGameOver())
            {
                var player1 = GameManager.Game.Player1;
                var player2 = GameManager.Game.Player2;

                _scoreManager.SaveScore(new(player1, player1.MovesCount, GameManager.Game.GridSize));

                _scoreManager.SaveScore(new(player2, player2.MovesCount, GameManager.Game.GridSize));

                var navigationParameter = new Dictionary<string, object>
                {
                    { nameof(player1), player1 },
                    { nameof(player2), player2 }
                };

                Shell.Current.GoToAsync("///endgametwoplayersscreenpage", navigationParameter);
            }
            _waitContinuePressed = true;
            _cardsClickedCount = 0;
        }
    }
}
