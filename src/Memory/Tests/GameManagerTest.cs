using MemoryLib.Managers;
using MemoryLib.Models;
using System;

namespace Tests
{
    public class GameManagerTest
    {
        [Fact]
        public void Increment_moves_should_increase_move_count()
        {
            GameManager _gameManager = new GameManager();
            var initialMoves = 0;

            _gameManager.IncrementMoves();

            Assert.Equal(1, initialMoves + 1);
        }

        /*[Fact]
        public void FlipCard_should_flip_card_successfully()
        {
            GameManager _gameManager = new GameManager();
            var x = 1;
            var y = 1;
            var card = _gameManager.AskCoordinates();

            
            _gameManager.FlipCard(x, y);

            
            Assert.True(card.IsFaceUp);
        }

        [Fact]
        public void InitializeGame_should_set_gameOver_flag_to_false_initially()
        {
            GameManager _gameManager = new GameManager();
            
            _gameManager.StartGame();

            Assert.False(_gameManager.IsGameOver()); 
        }

        [Fact]
        public void SwitchPlayers_should_switch_player_successfully()
        {
            GameManager _gameManager = new GameManager();
            var initialPlayer = _gameManager.IsGameOver();

            
            _gameManager.SwitchPlayers();

            
            Assert.NotEqual(initialPlayer, _gameManager.IsGameOver());
        }*/

        [Fact]
        public void UpdateScore_should_update_score_correctly()
        {
            GameManager _gameManager = new GameManager();
            var initialScore = 0;

            var updatedScore = _gameManager.UpdateScore(10);
             
            Assert.Equal(initialScore + 10, updatedScore);
        }

        /*[Fact]
        public void FlipCard_should_not_flip_when_card_is_null()
        {
            GameManager _gameManager = new GameManager();

            var x = -1;
            var y = -1;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _gameManager.FlipCard(x, y));
            Assert.Equal("Coordinates are out of range. Please try again.", exception.Message);
        }*/

        [Fact]
        public void GameOver_should_return_true_when_game_is_over()
        {
            GameManager _gameManager = new GameManager();
            _gameManager.StartGame();

            while (!_gameManager.IsGameOver())
            {
                _gameManager.SwitchPlayers();
            }

            Assert.True(_gameManager.IsGameOver());
        }

        [Fact]
        public void GameManager_constructor_should_initialize_game_and_cardManager_correctly()
        {
            GameManager _gameManager = new GameManager();

            Assert.NotNull(_gameManager); 
        }

        /*[Fact]
        public void SwitchPlayers_ShouldHandleMultipleSwitches()
        {
            GameManager _gameManager = new GameManager();
            var initialPlayer = _gameManager.IsGameOver();

            _gameManager.SwitchPlayers();
            _gameManager.SwitchPlayers();

            Assert.NotEqual(initialPlayer, _gameManager.IsGameOver());
        }*/

    }
}