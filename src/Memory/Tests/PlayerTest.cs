using MemoryLib.Models;

namespace Tests
{
    public class PlayerTest
    {

        [Fact]
        public void Initial_MovesCount_is_Zero()
        {
            Player player = new("Test");

            Assert.Equal(0, player.MovesCount);
        }

        [Fact]
        public void Initial_CurrentScore_is_Zero()
        {
            Player player = new("Test");

            Assert.Equal(0, player.CurrentScore);
        }

        [Fact]
        public void Add_1_To_MovesCount_Result_Is_One()
        {
            Player p = new("Test");

            p.Add1ToMovesCount();
                
            Assert.Equal(1, p.MovesCount);
        }

        [Fact]
        public void Add_1_To_CurrentScore_Result_Is_One()
        {
            Player p = new("Test");
            p.Add1ToScore();
            Assert.Equal(1, p.CurrentScore);
        }

        [Fact]
        public void Constructor_Sets_NameTag_Correctly()
        {
            var name = "Player3";
            
            Player player = new(name);
            
            Assert.Equal(name, player.NameTag);
        }

        [Fact]
        public void Players_With_Same_Name_Are_Equal()
        {
            Player p1 = new("Bob");
            Player p2 = new("Bob");
            
            Assert.True(p1.Equals(p2));
            Assert.True(p1.Equals((object)p2));
            Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
        }

        [Fact]
        public void Players_With_Different_Names_Are_Not_Equal()
        {
            Player p1 = new("Player1");
            Player p2 = new("Player2");
            Assert.False(p1.Equals(p2));
            Assert.False(p1.Equals((object)p2));
        }

        [Fact]
        public void Equals_Returns_False_For_Null_Or_Different_Type()
        {
            Player p = new("Player");
            
            Assert.False(p.Equals(null));
            Assert.False(p.Equals("string"));
        }
    }
}
