using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;
using Persistence;


namespace MemoryMAUI.Pages;
[QueryProperty(nameof(PlayerName), "playerName")]
[QueryProperty(nameof(GSize), "gridSize")]
public partial class SingleplayerGamePage : ContentPage
{
    private Card? _card1 = null;

    private Card? _card2 = null;

    private int _cardsClickedCount = 0;

    private bool _waitContinuePressed = false;

    private string? playerName;
    public string? PlayerName
    {
        get => playerName;
        set
        {
            playerName = value;
            InitializeGame();
        }
    }

    GridSize GridSize { get; set; }

    private string? gSize;
    public string? GSize
    {
        get => gSize;
        set
        {
            gSize = value;
            foreach (var size in Enum.GetValues(typeof(GridSize)))
            {
                if (size.ToString() == value)
                {
                    GridSize = (GridSize)size;
                }
            }
        }
    }

    private GameManager _gameManager;
    public GameManager GameManager
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


    public SingleplayerGamePage()
    {
        InitializeComponent();
        BindingContext = this;
        CardTemplate.OnCardClicked += OnCardClicked;
    }

    private void OnContinueButtonClicked(object sender, EventArgs e)
    {
        GameManager.HideCards();
        _cardsClickedCount = 0;
        _waitContinuePressed = false;
    }

    public void OnCardClicked(Grid sender, Card card)
    {
        if (_waitContinuePressed)
        {
            _waitContinuePressed = false;
            GameManager.HideCards();
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
            }
            else
            {
                GameManager.SwitchPlayers();
            }
            _waitContinuePressed = true;
            _cardsClickedCount = 0;
        }
    }
}