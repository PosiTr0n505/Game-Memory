using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;


namespace MemoryMAUI.Pages;

public partial class SingleplayerGamePage : ContentPage
{
    private Card? _card1 = null;

    private Card? _card2 = null;

    private int _cardsClickedCount = 0;

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

    public GameManager GameManager { get; }

    public SingleplayerGamePage()
    {
        _player = new("dqdqd");
        GameManager = new(new Game(_player, _player, GridSize.Size2));

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