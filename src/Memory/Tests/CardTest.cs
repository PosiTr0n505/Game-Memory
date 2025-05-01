using MemoryLib;
using MemoryLib.Managers;
using MemoryLib.Models;
namespace Tests
{
    public class CardTest
    {
        [Fact]
        public void FlipCard_should_turn_face_up()
        {
            CardManager cardManager = new CardManager();
            Card card = new Card(CardType.A);

            cardManager.FlipCard(card);

            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void UnFlipCard_should_turn_face_down()
        {
            CardManager cardManager = new CardManager();
            Card card = new Card(CardType.B);

            card.Flip();
            cardManager.UnFlipCard(card);

            Assert.False(card.IsFaceUp);
        }

        [Fact]
        public void CompareCards_should_return_true_when_id_match()
        {
            CardManager cardManager = new CardManager();
            Card c1 = new Card(CardType.C);
            Card c2 = new Card(CardType.C);

            Assert.True(cardManager.CompareCards(c1, c2));
        }

        [Fact]
        public void CompareCards_should_return_false_when_ids_dont_match()
        {
            CardManager cardManager = new CardManager();
            Card c1 = new Card(CardType.D);
            Card c2 = new Card(CardType.E);
            Assert.False(cardManager.CompareCards(c1, c2));
        }
    }
}
