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
            Game? game = new(player1, player2, 2, 2);
            game.SwitchPlayer();
            Assert.Equal(player2, game.CurrentPlayer);
        }

        [Fact]
        public void Switch_player_2_to_player_1()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2, 2, 2);
            game.SwitchPlayer();
            game.SwitchPlayer();
            Assert.Equal(player1, game.CurrentPlayer);
        }

        [Fact]
        public void Game_over_when_remaining_cards_count_is_0()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2, 2, 2);

            for (int i=0; i<4; i++)
                game.ReduceCardByOne();

            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void Game_not_over_when_remaining_cards_count_is_not_0()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2, 2, 2);

            if (game.Grid != null)
                game.Grid.AddCard(new Card(CardType.A), 0, 0);

            Assert.False(game.IsGameOver());
        }
    }
}
