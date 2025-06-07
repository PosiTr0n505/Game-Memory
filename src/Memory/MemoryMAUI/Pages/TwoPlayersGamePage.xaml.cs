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

    private bool _waitContinuePressed = false;

    public GameManager GameManager { get; } = new(new Game("Player1", "Player2", GridSize.Size2));

    public TwoPlayersGamePage()
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
	    
            if (GameManager.IsGameOver())
            {
                var player1 = GameManager.Game.Player1;
                var player2 = GameManager.Game.Player2;
                var winnerMovesCount = (player1.MovesCount > player2.MovesCount) ? player1 : player2;

                var navigationParameter = new Dictionary<string, object>
                {
                    { nameof(player1), player1 },
                    { nameof(player2), player2 }
                };

                AppShell.Current.GoToAsync("///", navigationParameter);

                _scoreManager.SaveScore(new(winnerMovesCount, winnerMovesCount.MovesCount, GameManager.Game.GridSize));
            }
            _waitContinuePressed = true;
            _cardsClickedCount = 0;
        }
    }
}
