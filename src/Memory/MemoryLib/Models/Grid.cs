using static System.Console;

namespace MemoryLib.Models
{
    public class Grid
    {
        private List<Card> cards = new List<Card>();

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        public void ShowGrid()
        {
            WriteLine("Current grid:");
            foreach (var card in cards)
            {
                Console.WriteLine($"Card ID: {card.Id}, FaceUp: {card.IsFaceUp}");
            }
        }
        public void Clear()
        {
            cards.Clear();
        }
    }

}
