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
    public GameManager GameManager { get; private init; } = new(new Game("Player1", "Player2", GridSize.Size1));
    public TwoPlayersGamePage()
    {
        InitializeComponent();
        BindingContext = this;
        CardTemplate.OnCardClicked += OnCardClicked;
        StartGame(GameManager);
    }

    public void OnCardClicked(Card card)
    {
        if (_cardsClickedCount == 1)
        {
            if (ReferenceEquals(_card1, _card2))
                return;
        }

        _cardsClickedCount += 1;

        if (_cardsClickedCount == 1)
            _card1 = card;

        if (_cardsClickedCount == 2)
            _card2 = card;

        card.IsVisible = true;
    }

    private void StartGame(GameManager gameManager)
    {
        while (!gameManager.IsGameOver())
        {

            if (_cardsClickedCount != 2 || _card1 is null || _card2 is null)
                continue;

            if (_card1 == _card2)
            {
                _card1.IsFound = true;
                _card2.IsFound = true;
                gameManager.Game.CurrentPlayer.Add1ToScore();
                gameManager.Game.ReduceCountByOnePair();
            }

            gameManager.IncrementMoves();

            _cardsClickedCount = 0;

            Task.Delay(2000);

            if (_card1 != _card2)
            {
                gameManager.SwitchPlayers();
            }

                gameManager.HideCards();
        }

        var score = new Score(gameManager.Game.CurrentPlayer, gameManager.Game.CurrentPlayer.CurrentScore, gameManager.Game.GridSize);
        ScoreManager leaderboard = new(new StubLoadManager(), new StubSaveManager());
        leaderboard.AddScore(score);
    }

    /*public void PlayRound(int x1, int y1, int x2, int y2)
        {
            Card c1, c2;

            c1 = Game.Grid.GetCard(x1, y1);
            c2 = Game.Grid.GetCard(x2, y2);

            c1.Flip();
            c2.Flip();

            if (_cardManager.CompareCards(c1, c2))
            {
                c1.IsFound = true;
                c2.IsFound = true;
                Game.CurrentPlayer.Add1ToScore();
                IncrementMoves();
                Game.ReduceCountByOnePair();
            }
            else
            {
                IncrementMoves();
                Game.SwitchPlayer();
            }

            BoardChange?.Invoke(this, Game.Grid.Cards);
        }*/
}