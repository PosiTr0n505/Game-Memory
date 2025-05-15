
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Interface for managing the game logic and operations.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Increments the number of moves made in the game.
        /// </summary>
        void IncrementMoves();

        /// <summary>
        /// Flips a card at the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the card to flip.</param>
        /// <param name="y">The y-coordinate of the card to flip.</param>
        void FlipCard(int x, int y);

        /// <summary>
        /// Starts the game and initializes necessary components.
        /// </summary>
        void StartGame();

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        /// <returns>True if the game is over; otherwise, false.</returns>
        bool IsGameOver();

        /// <summary>
        /// Updates the score with the specified value.
        /// </summary>
        /// <param name="score">The score to add or update.</param>
        /// <returns>The updated score.</returns>
        int UpdateScore(int score);

        /// <summary>
        /// Switches the turn to the next player.
        /// </summary>
        void SwitchPlayers();

        /// <summary>
        /// Asks the player for card coordinates.
        /// </summary>
        /// <returns>A <see cref="Card"/> object representing the selected card.</returns>
        Card AskCoordinates();
    }
}