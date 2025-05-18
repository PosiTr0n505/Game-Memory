using MemoryLib.Models;
using MemoryLib.Managers.Interface;

namespace Persistence
{
    public class StubSaveManager : ISaveManager
    {
        public void SaveScores(List<Score> scores)
        {
            return;
        }
    }
}
