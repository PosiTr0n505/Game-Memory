using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public interface ISaveManager
    {
        /// <summary>
        /// Saves the current state of the game.
        /// </summary>
        /// <param name="game">The game instance to be saved.</param>
        void SaveGame(Game game);
    }
}
