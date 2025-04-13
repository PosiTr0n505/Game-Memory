namespace MemoryLib.Models
{
    public class Game
    {
        private Player Player1 { get; set; } = new Player("");
        private Player Player2 { get; set; } = new Player("");
        private Grid Grid { get; set; } = new Grid();

        internal Player? CurrentPlayer = null;

        private int Round;

        int RemainingCardsCount { get; set; }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == Player1) CurrentPlayer = Player2;
            else CurrentPlayer = Player1;
        }

        public void StartGame()
        {
            Round = 1;
            Grid = new Grid();
            CurrentPlayer = Player1;
        }

        public bool IsGameOver() { return RemainingCardsCount == 0; }
    }
}
