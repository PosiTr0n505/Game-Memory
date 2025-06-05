using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;
using Persistence;


namespace MemoryMAUI.Pages;
[QueryProperty(nameof(Player1Name), "player1Name")]
[QueryProperty(nameof(Player2Name), "player2Name")]
public partial class TwoPlayersGamePage : ContentPage
{
    private Card? _card1 = null;
    private Card? _card2 = null;
    private int _cardsClickedCount = 0;
    private bool _waitContinuePressed = false;

    private string player1Name;
    public string Player1Name
    {
        get => player1Name;
        set
        {
            player1Name = value;
            InitializeGame();
        }
    }

    private string player2Name;
    public string Player2Name
    {
        get => player2Name;
        set
        {
            player2Name = value;
            InitializeGame();
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

    public TwoPlayersGamePage()
    {
        InitializeComponent();
        BindingContext = this;
        CardTemplate.OnCardClicked += OnCardClicked;
    }

    private void InitializeGame()
    {
        var player1 = new Player(Player1Name);
        var player2 = new Player(Player2Name);
        GameManager = new GameManager(new Game(player1, player2, GridSize.Size2));
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