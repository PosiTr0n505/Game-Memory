using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;
using MemoryStubPersistence;


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

    public TwoPlayersGamePage()
    {
        InitializeComponent();
        BindingContext = this;
        WaitContinuePressed = false;
        CardTemplate.OnCardClicked += OnCardClicked;
    }

    private void OnContinueButtonClicked(object sender, EventArgs e)
    {
        GameManager?.HideCards();
        _cardsClickedCount = 0;
        _waitContinuePressed = false;
    }

    public void OnCardClicked(View sender, Card card)
    {
        if (_waitContinuePressed)
        {
            _waitContinuePressed = false;
            GameManager?.HideCards();
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
            GameManager?.Game.CurrentPlayer.Add1ToMovesCount();
            _card2 = card;
            if (GameManager is not null && GameManager.Game.Grid.CompareCards(_card1!, _card2!))
            {
                _card1!.IsFound = true;
                _card2.IsFound = true;
                GameManager.Game.CurrentPlayer.Add1ToScore();
                GameManager.Game.ReduceCountByOnePair();
            }
            else 
            {
                GameManager?.SwitchPlayers();
            }
            _waitContinuePressed = true;
            _cardsClickedCount = 0;
        }
    }
}