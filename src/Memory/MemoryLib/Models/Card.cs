
namespace MemoryLib.Models

{
    /// <summary>
    /// Représente une carte dans un jeu de cartes, avec un identifiant de type CardType et un état face visible ou cachée.
    /// </summary>
    public class Card : ICardManager, IEquatable<Card>
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe Card avec un identifiant de type CardType.
        /// </summary>
        /// <param name="id"></param>
        public Card(CardType id)
        {
            Id = id;
            IsFaceUp = false;
        }
        /// <summary>
        /// Obtient l'identifiant unique de la carte.
        /// </summary>
        public CardType Id { get; private init; }

        /// <summary>
        /// Obtient ou définit un indicateur indiquant si la carte est face visible.
        /// </summary>
        public bool IsFaceUp { get; private set; }

        /// <summary>
        /// Retourne la carte, changeant son état de face cachée à face visible ou inversement.
        /// </summary>

        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        /// <summary>
        /// Renvoie une chaîne représentant l'identifiant de la carte.
        /// </summary>
        /// <returns>La chaîne de caractères représentant l'identifiant de la carte.</returns>
        public override string ToString()
        {
            return Id.ToString();
        }

        /// <summary>
        /// Compare deux cartes pour vérifier si elles sont identiques en termes de type.
        /// </summary>
        /// <param name="card1">La première carte à comparer.</param>
        /// <param name="card2">La deuxième carte à comparer.</param>
        /// <returns>Retourne true si les cartes ont le même identifiant, sinon false.</returns>
        public static bool MatchCards(Card? card1, Card? card2)
        {
            if (card1 == null || card2 == null)
                return false;
            return card1.Id == card2.Id;
        }

        /// <summary>
        /// Compare deux cartes et retourne true si elles sont identiques.
        /// </summary>
        /// <param name="card1">La première carte à comparer.</param>
        /// <param name="card2">La deuxième carte à comparer.</param>
        /// <returns>Retourne true si les cartes ont le même identifiant, sinon false.</returns>
        public bool CompareCards(Card card1, Card card2)
        {
            return card1.Id == card2.Id;
        }

        /// <summary>
        /// Retourne une carte si elle est face cachée.
        /// </summary>
        /// <param name="card">La carte à retourner.</param>

        public void FlipCard(Card card)
        {
            if (!card.IsFaceUp)
                card.Flip();
        }

        /// <summary>
        /// Affiche un message dans la console lorsque deux cartes sont matchées.
        /// </summary>
        /// <param name="card">La carte associée qui a été trouvée.</param>
        public void MatchCard(Card card)
        {
            Console.WriteLine($"Card {card.Id} matched.");
        }

        /// <summary>
        /// Retourne une carte si elle est face visible.
        /// </summary>
        /// <param name="card">La carte à remettre face cachée.</param>
        public void UnFlipCard(Card card)
        {
            if (card.IsFaceUp)
                card.Flip();
        }

        /// <summary>
        /// Vérifie si deux cartes sont égales en référence.
        /// </summary>
        /// <param name="other">L'autre carte à comparer.</param>
        /// <returns>Retourne true si les deux cartes sont identiques en référence, sinon false<.</returns>
        public bool Equals(Card? other)
        {
            return ReferenceEquals(other, null) ? false : ReferenceEquals(this, other);
        }

        /// <summary>
        /// Vérifie si l'objet spécifié est égal à l'instance actuelle.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'instance actuelle.</param>
        /// <returns>Retourne true si les objets sont égaux, sinon false<.</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Card)obj);
        }

        /// <summary>
        /// Calcule un code de hachage pour l'objet actuel.
        /// </summary>
        /// <returns>Le code de hachage de l'identifiant de la carte.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
