
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public interface IGameManager
    {
        void IncrementMoves();

        void FlipCard(int x, int y);
        
        void StartGame();

        bool IsGameOver();

        int UpdateScore(int score);

        void SwitchPlayers();

        Card AskCoordinates();
    }
}
