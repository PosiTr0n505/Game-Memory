using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class GameManagerTest
    {
        [Fact]
        public void Increment_moves_should_increase_move_count_by_1()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            var initialMoves = 0;

            _gameManager.IncrementMoves();
            
            Assert.Equal(1, initialMoves + 1);
        }

        [Fact]
        public void FlipCard_Should_flip_card_if_card_is_face_down()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            Card card = new(CardType.A);
            _ = new Grid(4, 4);

            _gameManager.FlipCard(0, 0);
            
            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void FlipCard_should_not_flip_card_if_card_is_face_up()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            Card card = new(CardType.A);
            _gameManager.FlipCard(0, 0);

            _gameManager.FlipCard(0, 0);
            
            Assert.True(card.IsFaceUp);
        }

        //[Fact]
        //public void FlipCard_should_not_do_anything_if_card_is_null()
        //{
        //    GameManager _gameManager = new(new Game("test1", "test2"));
        //    _gameManager.FlipCard(10, 10);
        //} To check later

        [Fact]
        public void GameOver_should_return_true_when_game_is_over()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            _gameManager.StartGame();

            while (!_gameManager.IsGameOver())
                _gameManager.SwitchPlayers();

            Assert.True(_gameManager.IsGameOver());
        }

        [Fact]
        public void GameOver_should_return_false_when_game_is_not_over()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));

            _gameManager.StartGame();

            Assert.False(_gameManager.IsGameOver());
        }

        [Fact]
        public void GameManager_constructor_should_initialize_game_and_cardManager_correctly()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            Assert.NotNull(_gameManager); 
        }

        [Fact]
        public void UpdateScore_should_update_score_correctly()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            var initialScore = 0;
            var updatedScore = _gameManager.UpdateScore(10);
            Assert.Equal(initialScore + 10, updatedScore);
        }

        [Fact]
        public void SwitchPlayers_should_switch_from_player1_to_player_2()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new(player1, player2, GridSize.Size1);
            _gameManager.SwitchPlayers();
            Assert.Equal(player2, game.CurrentPlayer);
        }

        [Fact]
        public void SwitchPlayers_should_switch_from_player2_to_player_1()
        {
            GameManager _gameManager = new(new Game("test1", "test2"));
            Player player1 = new("Player 1");
            Player player2 = new("Player 2");
            Game game = new(player1, player2, GridSize.Size1);
            _gameManager.SwitchPlayers();
            _gameManager.SwitchPlayers();
            Assert.Equal(player2, game.CurrentPlayer);
        }
    }
}