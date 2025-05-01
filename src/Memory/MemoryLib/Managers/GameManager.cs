using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public class GameManager : IGameManager
    {
        private int moves = 0;
        private int currentscore = 0;
        private readonly Game? game;

        public GameManager(Game gameInstance)
        {
            game = gameInstance;
        }
        public void IncrementMoves()
        {
            moves++;
            Console.WriteLine("Move count incremented.");
        }

        public void FlipCard(int x, int y)
        {
            
            Console.WriteLine($"Flipping card at ({x}, {y})");
        }

        public void StartGame()
        {
            Console.WriteLine("Game started.");
        }

        public bool IsGameOver()
        {
            return game?.IsGameOver() ?? false;
        }

        public int UpdateScore(int score)
        {
            currentscore += score;
            Console.WriteLine($"Score updated: {currentscore}");
            return currentscore;
        }

        public void SwitchPlayers()
        {
            game?.SwitchPlayer();
            Console.WriteLine("Switched players.");
        }
    }
}
