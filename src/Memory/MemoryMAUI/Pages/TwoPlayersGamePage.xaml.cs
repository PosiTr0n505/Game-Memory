using MemoryLib.Managers;
using MemoryMAUI.Resources.Templates;
using MemoryLib.Models;
using Persistence;


namespace MemoryMAUI.Pages;

public partial class TwoPlayersGamePage : ContentPage
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

    public GameManager GameManager { get; } = new(new Game("Player1", "Player2", GridSize.Size2));

    public TwoPlayersGamePage()
    {
        InitializeComponent();
        BindingContext = this;
        WaitContinuePressed = false;
        CardTemplate.OnCardClicked += OnCardClicked;
    }

    private void OnContinueButtonClicked(object sender, EventArgs e)
    {
        GameManager.HideCards();
        _cardsClickedCount = 0;
        _waitContinuePressed = false;
    }

    public void OnCardClicked(View sender, Card card)
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