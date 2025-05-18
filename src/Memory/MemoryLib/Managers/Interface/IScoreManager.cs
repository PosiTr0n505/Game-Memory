using MemoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Managers.Interface
{
    /// <summary>
    /// Interface for managing score-related operations.
    /// </summary>
    public interface IScoreManager
    {
        /// <summary>
        /// Updates the score value if the provided value is greater than the current score.
        /// </summary>
        /// <param name="scoreValue">The new score value to compare and potentially set.</param>
        void ChangeScoreValueIfGreater(int scoreValue);

        /// <summary>
        /// Increments the count of games played by one.
        /// </summary>
        void IncrementGamesPlayed();
    }
}
