﻿using MemoryLib.Managers;
using MemoryLib.Models;

namespace Tests
{
    public class GameManagerTest
    {
        [Fact]
        public void Increment_moves_should_increase_move_count_by_1()
        {
            Player player1 = new("Player1");
            Player player2 = new("Player2");
            Game game = new(player1, player2, GridSize.Size1);
            var gameManager = new GameManager(game);
            var initialMoves = gameManager.Moves;

            gameManager.IncrementMoves();

            Assert.Equal(initialMoves + 1, gameManager.Moves);
        }


        [Fact]
        public void FlipCard_Should_flip_card_if_card_is_face_down()
        {
            Game game = new("player1", "player2", GridSize.Size3);
            GridManager grid = new(2, 2);
            var card = new Card(CardType.A);
            grid.AddCard(card, 0, 0);
            game.Grid = grid;
            var gameManager = new GameManager(game);

            Assert.False(card.IsVisible);

            gameManager.FlipCard(0, 0);

            Assert.True(card.IsVisible);
        }

        [Fact]
        public void FlipCard_Should_flip_card_if_card_is_face_up()
        {
            Game game = new("player1", "player2", GridSize.Size6);
            GridManager grid = new(2, 2);
            Card card = new(CardType.A);
            grid.AddCard(card, 0, 0);
            game.Grid = grid;
            var gameManager = new GameManager(game);
            gameManager.FlipCard(0, 0);
            Assert.True(card.IsVisible);

            gameManager.FlipCard(0, 0);

            Assert.False(card.IsVisible);
        }

        [Fact]
        public void GameOver_should_return_true_when_game_is_over()
        {
            GameManager _gameManager = new(new Game("test1", "test2", GridSize.Size1));

            while (!_gameManager.IsGameOver())
                _gameManager.Game.ReduceCountByOnePair();

            Assert.True(_gameManager.IsGameOver());
        }

        [Fact]
        public void GameManager_constructor_should_initialize_game_and_cardManager_correctly()
        {
            GameManager _gameManager = new(new Game("test1", "test2", GridSize.Size4));
            Assert.NotNull(_gameManager); 
        }

        [Fact]
        public void UpdateScore_should_update_score_correctly()
        {
            GameManager _gameManager = new(new Game("test1", "test2", GridSize.Size4));
            var initialScore = 0;
            var updatedScore = _gameManager.UpdateScore(10);
            Assert.Equal(initialScore + 10, updatedScore);
        }

        [Fact]
        public void SwitchPlayers_should_switch_from_player1_to_player2()
        {
            Player player1 = new("player1");
            Player player2 = new("player2");
            Game game = new(player1, player2, GridSize.Size1);
            GameManager gameManager = new(game);

            Player firstPlayer = game.CurrentPlayer;
            gameManager.SwitchPlayers();
            Player secondPlayer = game.CurrentPlayer;

            Assert.NotEqual(firstPlayer, secondPlayer);
        }

        [Fact]
        public void SwitchPlayers_should_switch_from_player2_to_player_1()
        {
            Player player1 = new("player1");
            Player player2 = new("player2");
            Game game = new(player1, player2, GridSize.Size1);
            GameManager gameManager = new(game);

            gameManager.SwitchPlayers();
            Player secondPlayer = game.CurrentPlayer;

            gameManager.SwitchPlayers();
            Player firstPlayer = game.CurrentPlayer;

            Assert.NotEqual(firstPlayer, secondPlayer);
        }

    }
}