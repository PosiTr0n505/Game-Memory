
using MemoryLib.Managers.Interface;

namespace MemoryLib.Models

{
    /// <summary>
    /// Représente une carte dans un jeu de cartes, avec un identifiant de type CardType et un état face visible ou cachée.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe Card avec un identifiant de type CardType.
    /// </remarks>
    /// <param name="id"></param>
    public class Card(CardType id) : IEquatable<Card>
    {
        /// <summary>
        /// Obtient l'identifiant unique de la carte.
        /// </summary>
        public CardType Id { get; private init; } = id;

        /// <summary>
        /// Obtient ou définit un indicateur indiquant si la carte est face visible.
        /// </summary>
        public bool IsVisible { get; set; } = false;

        /// <summary>
        /// Obtient ou définit un indicateur indiquant si la carte a été trouvée.
        /// </summary>

        public bool IsFound { get; set; } = false;

        /// <summary>
        /// Retourne la carte, changeant son état de face cachée à face visible ou inversement.
        /// </summary>
        public void Flip()
        {
            IsVisible = !IsVisible;
        }

        public string Source { get; set; } = "Ressources/Images/hiddenCard.png";

        /// <summary>
        /// Renvoie une chaîne représentant l'identifiant de la carte.
        /// </summary>
        /// <returns>La chaîne de caractères représentant l'identifiant de la carte.</returns>
        public override string ToString() => Id.ToString();

        /// <summary>
        /// <summary>
        /// Retourne une carte si elle est face cachée.
        /// </summary>
        /// <param name="card">La carte à retourner.</param>
        public static void FlipCard(Card card)
        {
            if (!card.IsVisible)
                card.Flip();
        }

        /// <summary>
        /// Affiche un message dans la console lorsque deux cartes sont matchées.
        /// </summary>
        /// <param name="card">La carte associée qui a été trouvée.</param>
        public static void MatchCard(Card card)
        {
            Console.WriteLine($"Card {card.Id} matched.");
        }

        /// <summary>
        /// Retourne une carte si elle est face visible.
        /// </summary>
        /// <param name="card">La carte à remettre face cachée.</param>
        public static void UnFlipCard(Card card)
        {
            if (card.IsVisible)
                card.Flip();
        }

        /// <summary>
        /// Vérifie si deux cartes sont égales en référence.
        /// </summary>
        /// <param name="other">L'autre carte à comparer.</param>
        /// <returns>Retourne true si les deux cartes sont identiques en référence, sinon false<.</returns>
        public bool Equals(Card? other)
        {
            return other is not null && ReferenceEquals(this, other);
        }

        /// <summary>
        /// Vérifie si l'objet spécifié est égal à l'instance actuelle.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'instance actuelle.</param>
        /// <returns>Retourne true si les objets sont égaux, sinon false<.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Card)obj);
        }

        /// <summary>
        /// Calcule un code de hachage pour l'objet actuel.
        /// </summary>
        /// <returns>Le code de hachage de l'identifiant de la carte.</returns>
        public override int GetHashCode() => Id.GetHashCode();
    }
}
