using MemoryLib.Managers;
using static System.Console;

namespace MemoryLib.Models
{
    /// <summary>
    /// Représente une grille de cartes dans le jeu, contenant une matrice de cartes et offrant des méthodes pour interagir avec celle-ci.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Obtient le nombre de lignes de la grille.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Obtient le nombre de colonnes de la grille.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Matrice des cartes de la grille.
        /// </summary>
        private Card[,] Cards { get; }

        /// <summary>
        /// Initialise une nouvelle instance de la grille avec les dimensions spécifiées.
        /// </summary>
        /// <param name="x">Le nombre de lignes de la grille.</param>
        /// <param name="y">Le nombre de colonnes de la grille.</param>
        
        public Grid(int x, int y) 
        {
            X = x;
            Y = y;
            Cards = new Card[x, y];
        }
        /// <summary>
        /// Initialise une nouvelle instance d'une grille vide (0x0).
        /// </summary>

        public Grid()
        {
            X = 0;
            Y = 0;
            Cards = new Card[0, 0];
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
            Cards[x, y] = card;
        }

        public Card?[,] GetCards() => Cards;

        /// <summary>
        /// Obtient la carte à la position spécifiée dans la grille.
        /// </summary>
        /// <param name="x">La ligne de la carte dans la grille.</param>
        /// <param name="y">La colonne de la carte dans la grille.</param>
        /// <returns>La carte située à la position spécifiée.</returns>
        public Card GetCard(int x, int y) => Cards[x, y];

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
                    Card? c = Cards[x, y];
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
                    Cards[x, y] = null!;
        }
        /// <summary>
        /// Indique si la grille est vide (toutes les cases sont nulles).
        /// </summary>
        public bool IsEmpty()
        {
            for (int x = 0; x < X; x++)
                for (int y = 0; y < Y; y++)
                    if (Cards[x, y] != null)
                        return false;
            return true;
        }
    }

}
