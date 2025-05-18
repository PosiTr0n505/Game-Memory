using MemoryLib.Managers;
using MemoryLib.Models;
namespace Tests
{
    public class CardTest
    {
        [Fact]
        public void FlipCard_should_turn_face_up()
        {
            CardManager cardManager = new();
            Card card = new(CardType.A);

            cardManager.FlipCard(card);

            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void FlipCard_should_not_turn_face_down_when_card_already_face_up()
        {
            CardManager cardManager = new();
            Card card = new(CardType.A);
            card.Flip();
            
            cardManager.FlipCard(card);
            
            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void UnFlipCard_should_turn_face_down()
        {
            CardManager cardManager = new();
            Card card = new(CardType.B);
            card.Flip();

            cardManager.UnFlipCard(card);

            Assert.False(card.IsFaceUp);
        }

        [Fact]
        public void UnFlipCard_should_not_turn_face_up_when_card_already_face_down()
        {
            CardManager cardManager = new();
            Card card = new(CardType.B);

            cardManager.UnFlipCard(card);
            
            Assert.False(card.IsFaceUp);
        }

        [Fact]
        public void CompareCards_should_return_true_when_id_match()
        {
            CardManager cardManager = new();
            Card c1 = new(CardType.C);
            Card c2 = new(CardType.C);

            bool compare = cardManager.CompareCards(c1, c2);

            Assert.True(compare);
        }

        [Fact]
        public void CompareCards_should_return_false_when_ids_dont_match()
        {
            CardManager cardManager = new();
            Card c1 = new(CardType.D);
            Card c2 = new(CardType.E);

            bool compare = cardManager.CompareCards(c1, c2);

            Assert.False(compare);
        }
    }
}
