using MemoryLib.Models;
//using MemoryConsole.SaveStub;
using System.Data;

namespace MemoryLib.Managers
{
    public class GameManager : IGameManager
    {
        private int moves = 0;
        private int currentscore = 0;
        private readonly Game _game;
        private readonly CardManager _cardManager;
        private readonly bool _enableConsoleOutput;

        public GameManager()
        {
            _game = new Game();
            _cardManager = new CardManager();
        }
        public GameManager(bool enableConsoleOutput = true)
        {
            _enableConsoleOutput = enableConsoleOutput;
            _game = new Game();
            _cardManager = new CardManager();
        }
        public GameManager(Game game)
        {
            _game = game;
            _cardManager = new CardManager();
        }

        public void ShowGrid() => _game.Grid.ShowGrid();

        public void IncrementMoves()
        {
            moves++;
            Console.WriteLine($"Move count incremented. Total moves: {moves}");
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

            Card card1;
            Card card2;
            if (_enableConsoleOutput)
            {
                Console.Clear(); // Efface la console uniquement si activé
                Console.WriteLine("Game started!");
            }


            while (_game.IsGameOver() != true)
            {
                
                ShowGrid();
                Console.WriteLine($"Current Player: {_game.CurrentPlayer.NameTag}");
                Console.WriteLine($"Score: {_game.CurrentPlayer.CurrentScore}");
                try 
                {
                    card1 = AskCoordinates();
                    card2 = AskCoordinates();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                if (card1.IsFaceUp)
                {
                    Console.WriteLine($"This Card at has already been found");
                    continue;
                }
                if (card1 == card2)
                {
                    Console.WriteLine($"You have selected the same card. Try again.");
                    continue;
                }
                if (Card.MatchCards(card1, card2))
                {
                    card1.Flip();
                    card2.Flip();
                    _game.CurrentPlayer.add1ToScore();
                    _game.ReduceCountByOnePair();
                }

                else 
                    _game.SwitchPlayer();

                IncrementMoves();
            }

            Console.WriteLine("Game Over!");
        }

        public Card AskCoordinates()
        {
            int x, y;

            var input = Console.ReadLine();

            if (input == null)
                throw new NoNullAllowedException();

            var inputs = input.Split(' ');

            if (inputs.Length != 2)
                throw new ArgumentException("Invalid input. Please enter two coordinates separated by a space.");

            if (!int.TryParse(inputs[0], out x) || !int.TryParse(inputs[1], out y))
                throw new ArgumentException("Invalid input. Please enter two valid numbers separated by a space.");

            x -= 1;
            y -= 1;
            if (x < 0 || y < 0 || x >= _game.Grid.X || y >= _game.Grid.Y)
                throw new ArgumentOutOfRangeException("Coordinates are out of range. Please try again.");

            try
            {
                var c = _game.Grid.GetCard(x, y);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

            Card card = _game.Grid.GetCard(x, y);

            return card;
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

        //public static void SaveGame() => Console.WriteLine("Game saved.");


        //public Game LoadGame()
        //{
        //    this._game = Stub.StubGame1();
        //    return _game;
        //}
    }
}
