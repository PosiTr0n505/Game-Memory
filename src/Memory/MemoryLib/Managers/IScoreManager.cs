using MemoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLib.Managers
{
    internal interface IScoreManager
    {
        void ChangeScoreValue(int scoreValue);
        void IncrementGamesPlayed();
    }
}
