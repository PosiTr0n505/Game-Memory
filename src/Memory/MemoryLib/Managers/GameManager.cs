using MemoryLib.Managers.Interface;
using MemoryLib.Models;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Gère la logique principale du jeu, incluant les mouvements, le retournement des cartes, 
    /// la gestion des tours, et la notification des changements sur le plateau.
    /// </summary>
    public class GameManager : IGameManager
    {
        /// <summary>
        /// Délégué pour notifier les changements sur le plateau.
        /// </summary>
        /// <param name="sender">L'instance du gestionnaire de jeu qui déclenche l'événement.</param>
        /// <param name="cards">La collection des cartes actuelles sur le plateau.</param>
        public delegate void OnBoardChange(GameManager sender, IEnumerable<Card> cards);

        /// <summary>
        /// Événement déclenché lorsque le plateau de jeu change (par exemple, après un tour).
        /// </summary>
        public event OnBoardChange? BoardChange;

        /// <summary>
        /// Obtient le nombre total de mouvements effectués dans la partie.
        /// </summary>
        public int Moves { get; private set; } = 0;
        private int currentscore = 0;

        /// <summary>
        /// Le modèle de jeu associé à ce gestionnaire.
        /// </summary>
        public Game Game { get; private init; }

        public GameManager(Game game)
        {
            Game = game;
            _cardManager = new();
        }

        /// <summary>
        /// Incrémente le compteur de mouvements et met à jour le nombre de mouvements du joueur courant.
        /// </summary>
        private readonly CardManager _cardManager;

        public void IncrementMoves()
        {
            Moves++;
            Game.CurrentPlayer.Add1ToMovesCount();
        }

        /// <summary>
        /// Retourne une carte à la position spécifiée. Si la carte est face visible, elle est retournée face cachée, et pareil pour la deuxième.
        /// </summary>
        /// <param name="x">La coordonnée X de la carte sur la grille.</param>
        /// <param name="y">La coordonnée Y de la carte sur la grille.</param>

        public void FlipCard(int x, int y)
        {
            var card = Game.Grid.GetCard(x, y);

            if (card == null) return;
            if (card.IsVisible) _cardManager.UnFlipCard(card);
            else _cardManager.FlipCard(card);
        }

        /// <summary>
        /// Exécute un tour de jeu en retournant deux cartes spécifiées et en regardant leur correspondance.
        /// Met à jour le score et les états des cartes, puis notifie les changements sur le plateau.
        /// </summary>
        /// <param name="x1">Coordonnée X de la première carte.</param>
        /// <param name="y1">Coordonnée Y de la première carte.</param>
        /// <param name="x2">Coordonnée X de la deuxième carte.</param>
        /// <param name="y2">Coordonnée Y de la deuxième carte.</param>
        public void PlayRound(int x1, int y1, int x2, int y2)
        {
            Card c1, c2;

            c1 = Game.Grid.GetCard(x1, y1);
            c2 = Game.Grid.GetCard(x2, y2);

            c1.Flip();
            c2.Flip();

            if (_cardManager.CompareCards(c1, c2))
            {
                c1.IsFound = true;
                c2.IsFound = true;
                Game.CurrentPlayer.Add1ToScore();
                IncrementMoves();
                Game.ReduceCountByOnePair();
            }
            else
            {
                IncrementMoves();
                Game.SwitchPlayer();
            }

            BoardChange?.Invoke(this, Game.Grid.Cards);
        }

        /// <summary>
        /// Indique si la partie est terminée.
        /// </summary>
        /// <returns>True si la partie est terminée sinon false.</returns>
        public bool IsGameOver() => Game?.IsGameOver() ?? false;

        /// <summary>
        /// Met à jour le score courant en ajoutant la valeur spécifiée.
        /// </summary>
        /// <param name="score">Le score à ajouter.</param>
        /// <returns>Le nouveau score total.</returns>
        public int UpdateScore(int score) => currentscore += score;

        /// <summary>
        /// Change le joueur actif.
        /// </summary>
        public void SwitchPlayers() => Game?.SwitchPlayer();

        /// <summary>
        /// Cache toutes les cartes du plateau (retourne face cachée).
        /// </summary>
        public void HideCards() => Game.Grid.HideCards();
    }
}
