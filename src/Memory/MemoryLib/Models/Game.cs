using MemoryLib.Managers;
using MemoryLib.Managers.Interface;
namespace MemoryLib.Models
{
    /// <summary>
    /// Représente le jeu de mémoire, comprenant deux joueurs, une grille de cartes, et la logique de gestion du jeu.
    /// </summary>
    public class Game
    {
        public GridSize GridSize { get; init; }

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
        public GridManager Grid { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance du jeu avec des joueurs personnalisés et une taille de grille spécifiée.
        /// </summary>
        /// <param name="player1">Le premier joueur.</param>
        /// <param name="player2">Le deuxième joueur.</param>
        /// <param name="g">La taille de la grille à utiliser dans le jeu.</param>
        /// <exception >Lève une exception si l'un des joueurs est null.</exception>
        public Game(Player player1, Player player2, GridSize g)
        {
            if (player1 is null)
                throw new ArgumentNullException(nameof(player1), "Player cannot be null");

            if (player2 is null)
                throw new ArgumentNullException(nameof(player2), "Player cannot be null");


            Player1 = player1;
            Player2 = player2;

            GridSize = g;


            (int x, int y) = new GridSizeManager().GetGridSizeValues(g);

            Grid = new GridManager(x, y);
            RemainingCardsCount = 0;
            Round = 0;
            CurrentPlayer = player1;
            RemainingCardsCount = x * y;
        }

        public Game(string player1, string player2, GridSize g)
        {
            if (player1 is null)
                throw new ArgumentNullException(nameof(player1), "Player cannot be null");

            if (player2 is null)
                throw new ArgumentNullException(nameof(player2), "Player cannot be null");

            Player1 = new Player(player1);
            Player2 = new Player(player2);

            GridSize = g;

            (int x, int y) = new GridSizeManager().GetGridSizeValues(g);

            Grid = new GridManager(x, y);
            RemainingCardsCount = 0;
            Round = 0;
            CurrentPlayer = Player1;
            RemainingCardsCount = x * y;
        }

        private int Round { get; set; }

        /// <summary>
        /// Nombre de cartes restantes à découvrir dans le jeu.
        /// </summary>
        public int RemainingCardsCount { get; set; }

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
