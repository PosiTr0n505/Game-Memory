namespace MemoryLib.Models
{
    public class Game
    {
        public Player? Player1 { get; }
        public Player? Player2 { get; }
        public Player? CurrentPlayer { get; private set; }

        public Grid? Grid { get; set; }

        public Game()
        {
            Grid = new Grid();
        }

        private int Round { get; set; }

        public int RemainingCardsCount { get; set; }

        public Game(Player? player1, Player? player2, byte x, byte y)
        {
            Player1 = player1;
            Player2 = player2;
            Grid = new Grid(x, y);
            RemainingCardsCount = 0;
            CurrentPlayer = player1;
            RemainingCardsCount = x * y;
        }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == Player1) 
                CurrentPlayer = Player2;

            else 
                CurrentPlayer = Player1; 
        }

        public void AddRoundCount() => Round++;

        public void ReduceCardByOne() => RemainingCardsCount--;

        public bool IsGameOver() => RemainingCardsCount <= 0;
    }
}
