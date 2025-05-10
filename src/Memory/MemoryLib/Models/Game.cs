using MemoryLib.Managers;
namespace MemoryLib.Models
{
    /// <summary>
    /// Représente le jeu de mémoire, comprenant deux joueurs, une grille de cartes, et la logique de gestion du jeu.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Obtient le premier joueur du jeu.
        /// </summary>
        public Player Player1 { get; }

        /// <summary>
        /// Obtient le deuxième joueur du jeu.
        /// </summary>
        public Player Player2 { get; }

        /// <summary>
        /// Obtient ou définit le joueur actuellement actif dans le jeu.
        /// </summary>
        public Player CurrentPlayer { get; private set; }

        /// <summary>
        /// Représente la grille de cartes du jeu.
        /// </summary>

        public Grid Grid { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance du jeu avec une grille par défaut et deux joueurs.
        /// </summary>
        public Game(String p1, String p2)
        {
            Grid = new Grid();
            Player1 = new(p1);
            Player2 = new(p2);
            CurrentPlayer = Player1;
        }

        /// <summary>
        /// Initialise une nouvelle instance du jeu avec des joueurs personnalisés et une taille de grille spécifiée.
        /// </summary>
        /// <param name="player1">Le premier joueur.</param>
        /// <param name="player2">Le deuxième joueur.</param>
        /// <param name="g">La taille de la grille à utiliser dans le jeu.</param>
        /// <exception >Lève une exception si l'un des joueurs est null.</exception>

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

        /// <summary>
        /// Nombre de cartes restantes à découvrir dans le jeu.
        /// </summary>
        public int RemainingCardsCount { get; set; }

        /// <summary>
        /// Démarre le jeu en initialisant la grille et affichant l'état actuel du jeu.
        /// </summary>

        public void StartGame()
        {
            InitializeGame();
            Grid.ShowGrid();
        }


        /// <summary>
        /// Initialise le jeu en remplissant la grille avec des cartes aléatoires.
        /// </summary>
        private void InitializeGame()
        {
            if (Grid == null)
                return;

            List<CardType> types = Enum.GetValues(typeof(CardType)).Cast<CardType>().ToList();

            Random rand = new Random();

            int CardSlotCount = Grid.GetCards().GetLength(0) * Grid.GetCards().GetLength(1);

            List<CardType> typesSelected = types.OrderBy(t => rand.Next()).Take(CardSlotCount / 2).ToList();
            List<Card> allCards = new();

            foreach (var type in typesSelected)
            {
                allCards.Add(new Card(type)); 
                allCards.Add(new Card(type));
            }
            allCards = allCards.OrderBy(c => rand.Next()).ToList();
            int index = 0;
            for (int i = 0; i < Grid.GetCards().GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetCards().GetLength(1); j++)
                {
                    Grid.AddCard(allCards[index++], (byte)i, (byte)j); 
                }
            }
        }

        /// <summary>
        /// Change le joueur actif et passe au joueur suivant.
        /// </summary>

        public void SwitchPlayer()
        {
            if (CurrentPlayer == Player1) 
                CurrentPlayer = Player2;

            else 
                CurrentPlayer = Player1; 
        }

        /// <summary>
        /// Incrémente le nombre de rounds joués.
        /// </summary>
        public void AddRoundCount() => Round++;

        /// <summary>
        /// Réduit le nombre de cartes restantes de deux lorsque deux cartes sont découvertes et correspondantes.
        /// </summary>
        public void ReduceCountByOnePair() => RemainingCardsCount -= 2;

        /// <summary>
        /// Vérifie si le jeu est terminé (c'est-à-dire si toutes les cartes ont été trouvées).
        /// </summary>
        /// <returns>Retourne true si le jeu est terminé sinon false.</returns>

        public bool IsGameOver() => RemainingCardsCount <= 0;
    }
}
