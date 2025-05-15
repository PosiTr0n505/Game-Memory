using MemoryLib.Models;
using System.Data;

namespace MemoryLib.Managers
{
    public class GameManager : IGameManager
    {
        public delegate void OnBoardChange(GameManager sender, IEnumerable<Card> cards);
        public event OnBoardChange? BoardChange;

        public int Moves { get; private set; }
        private int currentscore = 0;
        public readonly Game Game;
        private readonly ICardManager _cardManager;

        public GameManager(Game game)
        {
            Game = game;
            Moves = 0;
            _cardManager = new CardManager();
        }

        public void IncrementMoves()
        {
            Moves++;
            Game.CurrentPlayer.Add1ToMovesCount();
        }

        public void FlipCard(int x, int y)
        {
            var card = Game.Grid.GetCard(x, y);

            if (card == null) return;

            _cardManager.FlipCard(card);
        }

        public void playRound(int x1, int y1, int x2, int y2)
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
        }

        public bool IsGameOver()
        {
            return Game?.IsGameOver() ?? false;
        }

        public int UpdateScore(int score)
        {
            currentscore += score;
            Console.WriteLine($"Score updated: {currentscore}");
            return currentscore;
        }

        public void SwitchPlayers()
        {
            Game?.SwitchPlayer();
            Console.WriteLine("Switched players.");
        }

        public void HideCards()
        {
            Game.Grid.HideCards();
        }
    }
}
