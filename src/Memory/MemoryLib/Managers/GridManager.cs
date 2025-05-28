
using System.Collections.ObjectModel;
using MemoryLib.Managers.Interface;
using MemoryLib.Models;
using static System.Console;

namespace MemoryLib.Managers
{
    /// <summary>
    /// Représente une grille de cartes dans le jeu, contenant une grille de cartes et offrant des méthodes pour interagir avec celle-ci.
    /// </summary>
    public class GridManager : ICardManager
    {
        /// <summary>
        /// Obtient le nombre de lignes de la grille.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Obtient la carte à la position spécifiée dans la grille.
        /// </summary>
        /// <param name="x">La ligne de la carte.</param>
        /// <param name="y">La colonne de la carte.</param>
        /// <returns>La carte située aux coordonnées (x, y).</returns>
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
        /// <summary>
        /// Initialise une nouvelle instance de la grille avec les dimensions spécifiées.
        /// La grille est automatiquement remplie avec des paires de cartes mélangées.
        /// </summary>
        /// <param name="x">Le nombre de lignes de la grille.</param>
        /// <param name="y">Le nombre de colonnes de la grille.</param>
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

        /// <summary>
        /// Cache toutes les cartes de la grille (retourne toutes les cartes face cachée).
        /// </summary>
        internal void HideCards()
        {
            foreach(var card in _cards)
            {
                card.IsVisible = false;
            }
        }

        /// <summary>
        /// Retourne la carte spécifiée si elle est face cachée.
        /// </summary>
        /// <param name="card">La carte à retourner.</param>
        public void FlipCard(Card card)
        {
            foreach (var c in _cards)
            {
                if (c == card)
                {
                    if (!c.IsVisible)
                        c.Flip();
                    return;
                }
            }
        }


        /// <summary>
        /// Retourne la carte spécifiée face cachée si elle est face visible.
        /// </summary>
        /// <param name="card">La carte à retourner face cachée.</param>

        public void UnFlipCard(Card card)
        {
            foreach (var c in _cards)
            {
                if (c == card)
                {
                    if (c.IsVisible)
                        c.Flip();
                    return;
                }
            }
        }

        /// <summary>
        /// Compare deux cartes pour déterminer si ce sont la même instance.
        /// </summary>
        /// <param name="card1">La première carte à comparer.</param>
        /// <param name="card2">La deuxième carte à comparer.</param>
        /// <returns>True si les deux cartes sont la même instance, sinon false.</returns>
        public bool CompareCards(Card card1, Card card2)
        {
            return card1 == card2;
        }
    }

}