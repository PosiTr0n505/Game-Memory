namespace MemoryLib.Models
{
    public class Game
    {
        public Player? Player1 { get; }
        public Player? Player2 { get; }
        public Player? CurrentPlayer { get; set; }

        public Grid? Grid { get; set; } = new Grid();

        private readonly int Round = 1;

        int RemainingCardsCount { get; set; }

        public Game(Player? player1, Player? player2)
        {
            Player1 = player1;
            Player2 = player2;
            RemainingCardsCount = 0;
            CurrentPlayer = player1;
        }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == Player1) { CurrentPlayer = Player2; }
            else { CurrentPlayer = Player1; }
        }

        public bool IsGameOver() { return RemainingCardsCount == 0; }
    }
}
