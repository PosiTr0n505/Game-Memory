using System.Xml.Linq;
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
            Game? game = new(player1, player2, GridSize.Size2);
            game.SwitchPlayer();
            Assert.Equal(player2, game.CurrentPlayer);
        }

        [Fact]
        public void Switch_player_2_to_player_1()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2, GridSize.Size1);
            game.SwitchPlayer();
            game.SwitchPlayer();
            Assert.Equal(player1, game.CurrentPlayer);
        }

        [Fact]
        public void Game_over_when_remaining_cards_count_is_0()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new(player1, player2, GridSize.Size1);

            for (int i=0; i<2; i++)
                game.ReduceCountByOnePair();

            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void Game_not_over_when_remaining_cards_count_is_not_0()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new(player1, player2, GridSize.Size5);

            Assert.NotEqual(0, game.RemainingCardsCount);

            Assert.False(game.IsGameOver());
        }

        [Fact]
        public void StartGame_fills_grid_correctly()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new Game(player1, player2, GridSize.Size1); // C un test avec 4 cartes

            int count = 0;
            var cards = game.Grid.Cards;
            foreach (var card in cards)
            {
                if (card != null) count++;
            }

            Assert.Equal(4, count);
        }

        [Fact]
        public void StartGame_should_fill_grid_completely()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new Game(player1, player2, GridSize.Size1);

            int cardCount = 0;
            foreach (var c in game.Grid.Cards)
            {
                if (c != null) cardCount++;
            }

            Assert.Equal(4, cardCount);
        }

        [Fact]
        public void StartGame_assigns_pairs_correctly()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new Game(player1, player2, GridSize.Size4);

            var cards = game.Grid.Cards;
            var typeCount = new Dictionary<CardType, int>();

            foreach (var card in cards)
            {
                if (card != null)
                {
                    if (!typeCount.ContainsKey(card.Id))
                        typeCount[card.Id] = 0;
                    typeCount[card.Id]++;
                }
            }

            Assert.All(typeCount.Values, count => Assert.Equal(2, count)); // verifie qu'il existe 2 exemplaires de chaque type
        }

        [Fact]
        public void StartGame_with_larger_grid_fills_grid_correctly()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new Game(player1, player2, GridSize.Size3);

            int cardCount = 0;
            foreach (var c in game.Grid.Cards)
            {
                if (c != null) cardCount++;
            }
            Assert.Equal(16, cardCount);
        }

        [Fact]
        public void Game_initialization_should_fail_with_null_players()
        {
            Game? game = null;

            Assert.Throws<ArgumentNullException>(() => game = new Game(null!, null!, GridSize.Size3));
        }

/*        [Fact]
        public void StartGame_should_throw_error_when_incorrect_grid_size()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new(player1, player2, GridSize.Size1);

            Assert.Throws<InvalidOperationException>(game.StartGame);
        }*/
    }
}
