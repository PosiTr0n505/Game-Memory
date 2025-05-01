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
        int GetScore();

        void SaveScore();

        void IncrementGamesPlayed(Score score);

        void ChangeBestScore(Score score, int s);
    }
}
