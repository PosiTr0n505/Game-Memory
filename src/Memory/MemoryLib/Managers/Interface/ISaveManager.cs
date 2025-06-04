using MemoryLib.Models;

namespace MemoryLib.Managers.Interface
{
    public interface ISaveManager
    {
        /// <summary>
        /// Saves the current state of the game.
        /// </summary>
        /// <param name="scores">The list of scores to be saved.</param>
        void SaveScores(List<Score> scores);
    }
}
