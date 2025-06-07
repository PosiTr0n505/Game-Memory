using MemoryLib.Models;
using MemoryLib.Managers.Interface;

namespace MemoryStubPersistence
{
    public class StubSaveManager : ISaveManager
    {
        public void SaveScores(List<Score> scores)
        {
            // Does nothing because its the STUB
        }
    }
}
