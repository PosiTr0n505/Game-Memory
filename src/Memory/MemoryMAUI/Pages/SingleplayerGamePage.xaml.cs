using MemoryLib.Managers;
using MemoryLib.Models;
using MemoryMAUI.Converters;
using MemoryMAUI.Resources.Templates;
using Persistence;
using System.Diagnostics;


namespace MemoryMAUI.Pages;
public partial class SingleplayerGamePage : ContentPage, IQueryAttributable
{
    private Card? _card1 = null;
    private Card? _card2 = null;
    private int _cardsClickedCount = 0;
    private bool _waitContinuePressed = false;

    private string playerName;
    public string PlayerName
    {
        get => playerName;
        set
        {
            playerName = value;
        }
    }

    public GridSize GridSize { get; set; }

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

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("playerName"))
            PlayerName = query["playerName"] as string;

        if (query.ContainsKey("gridSize"))
        {
            var gridSizeValue = query["gridSize"];
            GridSize = (GridSize)gridSizeValue;
        }
        if (GridSize != GridSize.None)
            InitializeGame();
    }

    private bool _waitContinuePressed;

    public bool WaitContinuePressed
    {
        get => _waitContinuePressed;

        set
        {
            _waitContinuePressed = value;
            OnPropertyChanged();
        }
    }

    private readonly Player _player;


    public SingleplayerGamePage()
    {
        InitializeComponent();
        BindingContext = this;
        CardTemplate.OnCardClicked += OnCardClicked;

    }

    private void OnContinueButtonClicked(object sender, EventArgs e)
    {
        if (!WaitContinuePressed)
            return;

        GameManager.HideCards();
        _cardsClickedCount = 0;
        WaitContinuePressed = false;
    }

    public void OnCardClicked(View sender, Card card)
    {
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
            }
            else
            {
                GameManager.SwitchPlayers();
            }
            WaitContinuePressed = true;
            _cardsClickedCount = 0;
        }
    }
}