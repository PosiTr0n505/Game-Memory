using MemoryLib.Models;

namespace Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Add_1_To_CurrentScore_Result_Is_One()
        {
            Player p = new Player("");

            p.add1ToMovesCount();

            Assert.Equal(1, p.MovesCount);
        }
    }
}
