using MemoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Managers
{
    public interface IScoreManager
    {
        void ChangeScoreValueIfGreater(int scoreValue);
        void IncrementGamesPlayed();
        void SaveScore();
        int GetScore();
    }
}
