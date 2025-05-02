using MemoryLib.Models;

namespace MemoryLib.Managers
{
    public class GameManager : IGameManager
    {
        private int moves = 0;
        private int currentscore = 0;
        private readonly Game _game;
        private readonly CardManager _cardManager;

        public GameManager()
        {
            _game = new Game();
            _cardManager = new CardManager();
        }

        public GameManager(Game game)
        {
            _game = game;
            _cardManager = new CardManager();
        }

        public void IncrementMoves()
        {
            moves++;
            Console.WriteLine("Move count incremented.");
        }

        public void FlipCard(int x, int y)
        {
            var card = _game.Grid.GetCard(x, y);

            if (card == null)
            {
                Console.WriteLine($"No card found at ({x}, {y})");
                return;
            }

            _cardManager.FlipCard(card);
            Console.WriteLine($"Card at ({x}, {y}) flipped. Face up: {card.IsFaceUp}");
        }

        public void StartGame()
        {
            _game.StartGame();
            Console.WriteLine("Game started.");
        }

        public bool IsGameOver()
        {
            return _game?.IsGameOver() ?? false;
        }

        public int UpdateScore(int score)
        {
            currentscore += score;
            Console.WriteLine($"Score updated: {currentscore}");
            return currentscore;
        }

        public void SwitchPlayers()
        {
            _game?.SwitchPlayer();
            Console.WriteLine("Switched players.");
        }
    }
}
