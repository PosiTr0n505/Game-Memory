using System.Collections.ObjectModel;
using MemoryLib.Managers;
using static System.Console;

namespace MemoryLib.Models
{
    /// <summary>
    /// Représente une grille de cartes dans le jeu, contenant une matrice de cartes et offrant des méthodes pour interagir avec celle-ci.
    /// </summary>
    public class Grid : IGridManager
    {
        /// <summary>
        /// Obtient le nombre de lignes de la grille.
        /// </summary>
        public int X { get; }

        public Card GetCard(int x, int y)
        {
            return _cards[x, y];
        }

        /// <summary>
        /// Obtient le nombre de colonnes de la grille.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Matrice des cartes de la grille.
        /// </summary>
        private Card[,] _cards;

        private List<Card> _cardsList;

        /// <summary>
        /// Initialise une nouvelle instance de la grille avec les dimensions spécifiées.
        /// </summary>
        /// <param name="x">Le nombre de lignes de la grille.</param>
        /// <param name="y">Le nombre de colonnes de la grille.</param>

        private void InitializeGrid()
        {
            List<CardType> types = Enum.GetValues(typeof(CardType)).Cast<CardType>().ToList();

            Random rand = new Random();

            int CardSlotCount = X * Y;

            List<CardType> typesSelected = types.OrderBy(t => rand.Next()).Take(CardSlotCount / 2).ToList();
            List<Card> allCards = new();

            foreach (var type in typesSelected)
            {
                allCards.Add(new Card(type));
                allCards.Add(new Card(type));
            }
            allCards = allCards.OrderBy(c => rand.Next()).ToList();
            int index = 0;
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    AddCard(allCards[index++], (byte)i, (byte)j);
                }
            }
        }

        public Grid(int x, int y) 
        {
            X = x;
            Y = y;
            _cards = new Card[x, y];
            InitializeGrid();
            _cardsList = new List<Card>();
            foreach (Card card in _cards)
            {
                _cardsList.Add(card);
            }
            Cards = new ReadOnlyCollection<Card>(_cardsList);
        }

        /// <summary>
        /// Ajoute une carte à la grille à la position spécifiée.
        /// </summary>
        /// <param name="card">La carte à ajouter.</param>
        /// <param name="x">La ligne de la grille.</param>
        /// <param name="y">La colonne de la grille.</param>
        /// <exception>Lève une exception si les coordonnées sont hors de portée de la grille.</exception>
        public void AddCard(Card card, int x, int y)
        {
            if (x >= X || y >= Y)
                throw new IndexOutOfRangeException("The coordinates are outside of the grid range");
            _cards[x, y] = card;
        }

        public IEnumerable<Card> Cards { get; }

        /// <summary>
        /// Affiche l'état actuel de la grille dans la console.
        /// </summary>
        public void ShowGrid()
        {
            WriteLine("Current grid:");
            for (int x = 0; x < X; x++)
            {
                Console.WriteLine();
                for (int y = 0; y < Y; y++)
                {
                    Card? c = _cards[x, y];
                    if (c == null) Console.Write("N ");
                    if (c != null && c.IsFaceUp) Write($"! ");
                    else Write($"{c} ");
                }
            }
            WriteLine();
        }

        /// <summary>
        /// Efface toutes les cartes de la grille en les remplaçant par des valeurs nulles.
        /// </summary>
        public void Clear()
        {
            for (var x = 0; x < X; x++)
                for (var y = 0; y < Y; y++)
                    _cards[x, y] = null!;
        }

        /// <summary>
        /// Efface la grille, mais cette méthode n'est pas encore implémentée.
        /// </summary>
        /// <param name="grid">La grille à effacer.</param>
        /// <exception">A faire bientot</exception>
        public void ClearGrid(Grid grid)
        {
            throw new NotImplementedException();
        }
    }

}
