using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class GridTest
    {
        [Fact]
        public void Add_Card_In_Grid_And_Grid_Not_Null()
        {
            GridManager g = new(2, 2);

            Card c1 = new(CardType.A);
            Card c2 = new(CardType.B);
            Card c3 = new(CardType.C);
            Card c4 = new(CardType.D);

            g.AddCard(c1, 0, 0);
            g.AddCard(c2, 0, 1);
            g.AddCard(c3, 1, 0);
            g.AddCard(c4, 1, 1);

            foreach (var card in g.Cards)
            {
                Assert.NotNull(card);
            }
        }

        [Fact]
        public void AddCard_Should_Throw_Exception_When_Outside_Grid()
        {
            GridManager g = new(2, 2);
            Card c1 = new(CardType.A);

            Assert.Throws<IndexOutOfRangeException>(() => g.AddCard(c1, 3, 3));
            Assert.Throws<IndexOutOfRangeException>(() => g.AddCard(c1, 0, 3));
            Assert.Throws<IndexOutOfRangeException>(() => g.AddCard(c1, 3, 0));
        }

        [Fact]
        public void GetCard_Should_Return_Correct_Card()
        {
            GridManager g = new(2, 2);
            Card c1 = new(CardType.A);
            Card c2 = new(CardType.B);
            g.AddCard(c1, 0, 0);
            g.AddCard(c2, 1, 1);

            Card retrievedCard = g.GetCard(0, 0);

            Assert.Equal(c1, retrievedCard);
        }


    }
}
