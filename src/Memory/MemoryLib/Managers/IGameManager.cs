
namespace MemoryLib.Managers
{
    internal interface IGameManager
    {
        void IncrementMoves();
        void FlipCard(int x, int y);
        
        void StartGame();

        bool IsGameOver();

        int UpdateScore(int score);

        void SwitchPlayers();
    }
}
