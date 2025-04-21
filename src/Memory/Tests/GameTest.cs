using MemoryLib.Models;

namespace Tests
{
    public class GameTest
    {
        [Fact]
        public void Switch_player_1_to_player_2()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2);
            game.CurrentPlayer = player1;
            game.SwitchPlayer();
            Assert.Equal(player2, game.CurrentPlayer);
            Console.WriteLine("Player 2 is the current player");
        }

        [Fact]
        public void Switch_player_2_to_player_1()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2);
            game.CurrentPlayer = player2;
            game.SwitchPlayer();
            Assert.Equal(player1, game.CurrentPlayer);
            Console.WriteLine("Player 1 is the current player");
        }

        [Fact]
        public void Game_over_when_remaining_cards_count_is_0()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2);
            game.CurrentPlayer = player2;
            Assert.True(game.IsGameOver());
            Console.WriteLine("Game is over");
        }

        [Fact]
        public void Game_not_over_when_remaining_cards_count_is_not_0()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2);
            game.CurrentPlayer = player2;
            Assert.False(game.IsGameOver());
            Console.WriteLine("Game is not over");
        }
    }
}
