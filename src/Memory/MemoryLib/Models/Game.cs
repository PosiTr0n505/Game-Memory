namespace MemoryLib.Models
{
    public class Game
    {
        public Game(Player? player1, Player? player2)
        {
            Player1 = player1;
            Player2 = player2;
            RemainingCardsCount = 0;
        }

        public Player? Player1 { get; init; }
        public Player? Player2 { get; init; }

        public Grid? Grid { get; set; } = new Grid();

        public Player? CurrentPlayer { get; private set; }

        private int Round = 1;

        int RemainingCardsCount { get; set; }

        public void SwitchPlayer()
        {
            if (ReferenceEquals(CurrentPlayer, Player1)) CurrentPlayer = Player2;
            else CurrentPlayer = Player1;
        }

        public bool IsGameOver() { return RemainingCardsCount == 0; }
    }
}
