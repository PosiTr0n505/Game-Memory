using MemoryLib.Models;

namespace MemoryLib.Managers.Interface
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
    }
}