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
                game.ReduceCountByOnePair();

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

        [Fact]
        public void StartGame_fills_grid_correctly()
        {
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game? game = new Game(player1, player2, 2, 2); // C un test avec 4 cartes

            game.StartGame();
            int count = 0;
            var cards = game.Grid.GetCards();
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
            Game game = new Game(player1, player2, 2, 2);

            game.StartGame();

            int cardCount = 0;
            foreach (var c in game.Grid.GetCards())
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
            Game? game = new Game(player1, player2, 2, 2);

            game.StartGame();
            var cards = game.Grid.GetCards();
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
    }
}
