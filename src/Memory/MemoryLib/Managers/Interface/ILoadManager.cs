using MemoryLib.Models;

namespace MemoryLib.Managers.Interface
{
    public interface ILoadManager
    {
        /// <summary>
        /// Loads a saved game instance.
        /// </summary>
        /// <returns>
        /// A <see cref="Game"/> object representing the loaded game state.
        /// </returns>
        public List<Score> LoadScores();
    }
}
