using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public class GameManager : IGameManager
    {
        private int moves = 0;
        private int currentscore = 0;
        private readonly Game? game;

        public GameManager() => game = new Game();

        public GameManager(Game gameInstance) => game = gameInstance;
        public void IncrementMoves()
        {
            moves++;
            Console.WriteLine("Move count incremented.");
        }

        public void FlipCard(int x, int y)
        {
            var card = game?.Grid.GetCard(x, y);

            if (card == null)
            {
                Console.WriteLine($"No card found at ({x}, {y})");
                return;
            }

            card.Flip();
            Console.WriteLine($"Card at ({x}, {y}) flipped. Face up: {card.IsFaceUp}");
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
