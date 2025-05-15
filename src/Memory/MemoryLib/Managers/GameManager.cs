using MemoryLib.Models;
using System.Data;

namespace MemoryLib.Managers
{
    public class GameManager : IGameManager
    {
        public delegate void OnBoardChange(GameManager sender, IEnumerable<Card> cards);
        public event OnBoardChange? BoardChange;

        public int Moves { get; private set; }
        private int currentscore = 0;
        public readonly Game Game;
        private readonly ICardManager _cardManager = new CardManager();

        public GameManager(Game game)
        {
            Game = game;
            Moves = 0;
            _cardManager = new CardManager();
        }

        public void IncrementMoves() => Moves++;

        public void FlipCard(int x, int y)
        {
            var card = Game.Grid.GetCard(x, y);

            if (card == null) return;

            _cardManager.FlipCard(card);
        }

        public void PlayTurn(int x1, int y1, int x2, int y2)
        {
            BoardChange?.Invoke(this, Game.Grid.Cards);
        }

        public void StartGame()
        {
            Game.StartGame();

            Card card1;
            Card card2;

            while (Game.IsGameOver() != true)
            {
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
                    continue;
                }
                
                if (card1 == card2)
                {
                    continue;
                }

                if (_cardManager.CompareCards(card1, card2))
                {
                    card1.Flip();
                    card2.Flip();
                    Game.CurrentPlayer.Add1ToScore();
                    Game.ReduceCountByOnePair();
                }

                else 
                    Game.SwitchPlayer();

                IncrementMoves();
            }

            //Console.WriteLine("Game Over!");
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

            if (x < 0 || y < 0 || x >= Game.Grid.X || y >= Game.Grid.Y)
                throw new ArgumentOutOfRangeException("Coordinates are out of range. Please try again.");

            try
            {
                var c = Game.Grid.GetCard(x, y);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

            Card card = Game.Grid.GetCard(x, y);

            return card;
        }

        public bool IsGameOver()
        {
            return Game?.IsGameOver() ?? false;
        }

        public int UpdateScore(int score)
        {
            currentscore += score;
            Console.WriteLine($"Score updated: {currentscore}");
            return currentscore;
        }

        public void SwitchPlayers()
        {
            Game?.SwitchPlayer();
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
