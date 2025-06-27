using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
namespace MemoryLib.Models
{
    /// <summary>
    /// Represents a memory game with two players, a grid of cards, and game management logic.
    /// </summary>
    public class Game : ObservableObject
    {
        public GridSize GridSize { get; init; }

        /// <summary>
        /// Get the first player
        /// </summary>
        public Player Player1 { get; }

        /// <summary>
        /// Get the second player
        /// </summary>
        public Player Player2 { get; }

        private Player _currentPlayer;

        /// <summary>
        /// Get the active player in the game.
        /// </summary>
        public Player CurrentPlayer 
        { 
            get => _currentPlayer;

            private set 
            {
                _currentPlayer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Represents the grid of the game, containing the cards and their positions.
        /// </summary>
        public GridManager Grid { get; set; }

        /// <summary>
        /// Initialize an instance of a game with the selected players and a defined grid size.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="g">The grid size used for the game.</param>
        /// <exception >Throws an exception if one of the players is null.</exception>
        public Game(Player player1, Player player2, GridSize g)
        {
            if (player1 is null)
                throw new ArgumentNullException(nameof(player1), "Player cannot be null");

            if (player2 is null)
                throw new ArgumentNullException(nameof(player2), "Player cannot be null");


            Player1 = player1;
            Player2 = player2;

            _currentPlayer = Player1;

            GridSize = g;


            (int x, int y) = GridSizeManager.GetGridSizeValues(g);

            Grid = new GridManager(x, y);
            RemainingCardsCount = 0;
            Round = 0;
            CurrentPlayer = player1;
            RemainingCardsCount = x * y;
        }

        /// <summary>
        /// Initialize an instance of a game with the selected players and a defined grid size.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="g">The grid size used for the game.</param>
        /// <exception >Throws an exception if one of the players is null.</exception>
        public Game(string player1, string player2, GridSize g)
        {
            if (player1 is null)
                throw new ArgumentNullException(nameof(player1), "Player cannot be null");

            if (player2 is null)
                throw new ArgumentNullException(nameof(player2), "Player cannot be null");

            Player1 = new Player(player1);
            Player2 = new Player(player2);

            _currentPlayer = Player1;

            GridSize = g;

            (int x, int y) = GridSizeManager.GetGridSizeValues(g);

            Grid = new GridManager(x, y);
            RemainingCardsCount = 0;
            Round = 0;
            CurrentPlayer = Player1;
            RemainingCardsCount = x * y;
        }

        private int Round { get; set; }

        /// <summary>
        /// Remaining cards count that were not found in the game.
        /// </summary>
        public int RemainingCardsCount { get; set; }

        /// <summary>
        /// Change current player to the other player.
        /// </summary>

        public void SwitchPlayer()
        {
            if (CurrentPlayer == Player1) 
                CurrentPlayer = Player2;

            else 
                CurrentPlayer = Player1; 
        }

        /// <summary>
        /// Increment the round count by one.
        /// </summary>
        public void AddRoundCount() => Round++;

        /// <summary>
        /// Reduce the remaining cards count by one pair (2 cards).
        /// </summary>
        public void ReduceCountByOnePair() => RemainingCardsCount -= 2;

        /// <summary>
        /// Check if the game is over (i.e., all cards have been found).
        /// </summary>
        /// <returns>Returns true if game is over and false if not.</returns>
        public bool IsGameOver() => RemainingCardsCount <= 0;
    }
}
