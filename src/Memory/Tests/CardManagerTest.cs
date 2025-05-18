using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class CardManagerTest
    {
        [Fact]
        public void FlipCard_Should_Flip_Card_When_Card_Is_Face_Down()
        {
            Card card = new(CardType.A);
            CardManager cardManager = new();
            cardManager.FlipCard(card);
            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void FlipCard_Should_Not_Flip_Card_When_Card_Is_Face_Up()
        {
            Card card = new(CardType.A);
            CardManager cardManager = new();
            cardManager.FlipCard(card);
            cardManager.FlipCard(card);
            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void UnFlipCard_Should_UnFlip_Card_When_Card_Is_Face_Up()
        {
            Card card = new(CardType.A);
            CardManager cardManager = new();
            cardManager.FlipCard(card);
            cardManager.UnFlipCard(card);
            Assert.False(card.IsFaceUp);
        }

        [Fact]
        public void UnFlipCard_Should_Not_UnFlip_Card_When_Card_Is_Face_Down()
        {
            Card card = new(CardType.A);
            CardManager cardManager = new();
            cardManager.UnFlipCard(card);
            Assert.False(card.IsFaceUp);
        }

        [Fact]
        public void CompareCards_Should_Return_True_When_Cards_Are_Equal()
        {
            Card card1 = new(CardType.A);
            Card card2 = new(CardType.A);
            CardManager cardManager = new();
            bool compare = cardManager.CompareCards(card1, card2);
            Assert.True(compare);
        }

        [Fact]
        public void CompareCards_Should_Return_False_When_Cards_Are_Not_Equal()
        {
            Card card1 = new(CardType.A);
            Card card2 = new(CardType.B);
            CardManager cardManager = new();
            bool compare = cardManager.CompareCards(card1, card2);
            Assert.False(compare);
        }
    }
}
