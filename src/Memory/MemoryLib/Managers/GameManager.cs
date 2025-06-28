using MemoryLib.Managers.Interface;
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Manages the main game logic, including moves, card flipping, turn management, and board change notifications.
    /// </summary>
    public class GameManager : IGameManager
    {
        /// <summary>
        /// Delegate used to notify board changes.
        /// </summary>
        /// <param name="sender">The instance of the game manager that triggers the event.</param>
        /// <param name="cards">The collection of cards on the board at this instant.</param>
        public delegate void OnBoardChange(GameManager sender, IEnumerable<Card> cards);

        /// <summary>
        /// Event triggered when the game board changes (e.g., after a turn).
        /// </summary>
        public event OnBoardChange? BoardChange;

        /// <summary>
        /// Gets the total number of moves made in the game.
        /// </summary>
        public int Moves { get; private set; } = 0;
        private int currentscore = 0;

        /// <summary>
        /// The game model associated with this manager.
        /// </summary>
        public Game Game { get; private init; }

        public GameManager(Game game)
        {
            Game = game;
            _cardManager = new();
        }

        /// <summary>
        /// Increments the move counter and updates the current player's move count.
        /// </summary>
        private readonly CardManager _cardManager;

        public void IncrementMoves()
        {
            Moves++;
            Game.CurrentPlayer.Add1ToMovesCount();
        }

        /// <summary>
        /// Returns a card at the specified position. If the card is face up, it is flipped face down, and vice versa.
        /// </summary>
        /// <param name="x">The X coordinate of the card on the grid.</param>
        /// <param name="y">The Y coordinate of the card on the grid.</param>

        public void FlipCard(int x, int y)
        {
            var card = Game.Grid.GetCard(x, y);

            if (card == null) return;
            if (card.IsVisible) _cardManager.UnFlipCard(card);
            else _cardManager.FlipCard(card);
        }

        /// <summary>
        /// Starts a new round by flipping two cards and checking if they match.
        /// Updates the score and card states, then notifies board changes.
        /// </summary>
        /// <param name="x1">The X coordinate of the first card on the grid.</param>
        /// <param name="y1">The Y coordinate of the first card on the grid.</param>
        /// <param name="x2">The X coordinate of the second card on the grid.</param>
        /// <param name="y2">The Y coordinate of the second card on the grid.</param>
        public void PlayRound(int x1, int y1, int x2, int y2)
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

        /// <summary>
        /// Indicates if the game is over.
        /// </summary>
        /// <returns>True if the game is over, else false.</returns>
        public bool IsGameOver() => Game?.IsGameOver() ?? false;

        /// <summary>
        /// Updates the current score by adding the specified value.
        /// </summary>
        /// <param name="score">The score we wanna add.</param>
        /// <returns>The updated total score.</returns>
        public int UpdateScore(int score) => currentscore += score;

        /// <summary>
        /// Changes the active player to the next player in the game.
        /// </summary>
        public void SwitchPlayers() => Game?.SwitchPlayer();

        /// <summary>
        /// Hides all cards on the board by flipping them face down.
        /// </summary>
        public void HideCards() => Game.Grid.HideCards();
    }
}
