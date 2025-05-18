
using System.Collections.ObjectModel;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using static System.Console;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Représente une grille de cartes dans le jeu, contenant une matrice de cartes et offrant des méthodes pour interagir avec celle-ci.
    /// </summary>
    public class GridManager : ICardManager
    {
        /// <summary>
        /// Obtient le nombre de lignes de la grille.
        /// </summary>
        public int X { get; }

        public Card GetCard(int x, int y)
        {
            return _cards[x, y];
        }

        public bool IsCardFound(int x, int y) => _cards[x, y].IsFound;

        /// <summary>
        /// Obtient le nombre de colonnes de la grille.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Matrice des cartes de la grille.
        /// </summary>
        private readonly Card[,] _cards;

        private static readonly Random rand = new();

        private readonly List<Card> _cardsList;

        /// <summary>
        /// Initialise une nouvelle instance de la grille avec les dimensions spécifiées.
        /// </summary>
        /// <param name="x">Le nombre de lignes de la grille.</param>
        /// <param name="y">Le nombre de colonnes de la grille.</param>

        private void InitializeGrid()
        {
            List<CardType> types = [.. Enum.GetValues<CardType>().Cast<CardType>()];

            int CardSlotCount = X * Y;

            List<CardType> typesSelected = [.. types.OrderBy(t => rand.Next()).Take(CardSlotCount / 2)];
            List<Card> allCards = [];

            foreach (var type in typesSelected)
            {
                allCards.Add(new Card(type));
                allCards.Add(new Card(type));
            }
            allCards = [.. allCards.OrderBy(c => rand.Next())];
            int index = 0;
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    AddCard(allCards[index++], (byte)i, (byte)j);
                }
            }
        }

        public GridManager(int x, int y) 
        {
            X = x;
            Y = y;
            _cards = new Card[x, y];
            InitializeGrid();
            _cardsList = [.. _cards];
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
        public void ClearGrid(GridManager grid)
        {
            throw new NotImplementedException();
        }

        internal void HideCards()
        {
            foreach(var card in _cards)
            {
                card.IsFaceUp = false;
            }
        }

        public void FlipCard(Card card)
        {
            foreach (var c in _cards)
            {
                if (c == card)
                {
                    if (!c.IsFaceUp)
                        c.Flip();
                    return;
                }
            }
        }

        public void UnFlipCard(Card card)
        {
            foreach (var c in _cards)
            {
                if (c == card)
                {
                    if (c.IsFaceUp)
                        c.Flip();
                    return;
                }
            }
        }

        public bool CompareCards(Card card1, Card card2)
        {
            return card1 == card2;
        }
    }

}