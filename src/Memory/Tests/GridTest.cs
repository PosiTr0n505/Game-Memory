using MemoryLib.Models;

namespace Tests
{
    public class GridTest
    {
        [Fact]
        public void Add_A_Card_In_A_Grid_And_Grid_Not_Null()
        {
            Grid g = new();
            Card c = new(CardType.A);

            g.AddCard(c);

            Assert.Contains(c, g.GetCards());
            
        }
    }
}
