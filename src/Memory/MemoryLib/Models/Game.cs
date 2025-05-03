using MemoryLib.Managers;
namespace MemoryLib.Models
{
    public class Game
    {
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Player CurrentPlayer { get; private set; }

        public Grid Grid { get; set; }

        public Game()
        {
            Grid = new Grid();
            Player1 = new Player("Player 1");
            Player2 = new Player("Player 2");
            CurrentPlayer = Player1;
        }

        public Game(Player player1, Player player2, GridSize g)
        {
            if (ReferenceEquals(null, player1) || ReferenceEquals(null, player2))
                throw new ArgumentNullException("Player cannot be null");
            Player1 = player1;
            Player2 = player2;
            IGridSizeManager gridSizeManager = new GridSizeManager();
            (int x, int y) = gridSizeManager.GetGridSizeValues(g);
            Grid = new Grid(x, y);
            RemainingCardsCount = 0;
            Round = 0;
            CurrentPlayer = player1;
            RemainingCardsCount = x * y;
        }

        private int Round { get; set; }

        public int RemainingCardsCount { get; set; }

        public void StartGame()
        {
            InitializeGame();
            Grid.ShowGrid();
        }

        private void InitializeGame()
        {
            if (Grid == null)
                return;

            List<CardType> types = Enum.GetValues(typeof(CardType)).Cast<CardType>().ToList();

            Random rand = new Random();

            int CardSlotCount = Grid.GetCards().GetLength(0) * Grid.GetCards().GetLength(1); // Calculer nombre total d'emplacement dans la grille

            List<CardType> typesSelected = types.OrderBy(t => rand.Next()).Take(CardSlotCount / 2).ToList(); // C pour créer les paires
            List<Card> allCards = new();

            foreach (var type in typesSelected)
            {
                allCards.Add(new Card(type));   // Créer les deux cartes identiques (de meme type)
                allCards.Add(new Card(type));
            }
            allCards = allCards.OrderBy(c => rand.Next()).ToList(); // Mélange
            int index = 0;
            for (int i = 0; i < Grid.GetCards().GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetCards().GetLength(1); j++)
                {
                    Grid.AddCard(allCards[index++], (byte)i, (byte)j); // Parcourir toute la grille pour placer une cartte a chaque position
                }
            }
        }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == Player1) 
                CurrentPlayer = Player2;

            else 
                CurrentPlayer = Player1; 
        }

        public void AddRoundCount() => Round++;

        public void ReduceCountByOnePair() => RemainingCardsCount -= 2;

        public bool IsGameOver() => RemainingCardsCount <= 0;
    }
}
