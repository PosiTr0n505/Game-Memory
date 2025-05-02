using MemoryLib.Models;

namespace Tests
{
    public class GridTest
    {
        [Fact]
        public void Add_Card_In_Grid_And_Grid_Not_Null()
        {
            Grid g = new(2, 2);

            Card c1 = new(CardType.A);
            Card c2 = new(CardType.B);
            Card c3 = new(CardType.C);
            Card c4 = new(CardType.D);

            g.AddCard(c1, 0, 0);
            g.AddCard(c2, 0, 1);
            g.AddCard(c3, 1, 0);
            g.AddCard(c4, 1, 1);

            foreach (var card in g.GetCards())
            {
                Assert.NotNull(card);
            }
        }
    }
}
