﻿using NUnit.Framework;
using Quantum33.Kata.Tennis;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void IsInDeuce_ValidScoresOf40Each_True()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(40);

            Assert.IsTrue(game.IsInDeuce());
        }

        [Test]
        public void IsInDeuce_Player1HasAScoreNotEqualsTo40_False()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.Score.SetCurrentValueTo(15);
            game.Player2.Score.SetCurrentValueTo(40);

            Assert.IsFalse(game.IsInDeuce());
        }

        [Test]
        public void PlayerToScoreUp_Player1ToScoreUpFrom0To15_Success()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.Score.SetCurrentValueTo(0);
            game.Player2.Score.SetCurrentValueTo(0);

            game.PlayerToScoreUp(game.Player1);
            Assert.AreEqual(15, game.Player1.Score.CurrentValue);
            Assert.AreEqual(0, game.Player2.Score.CurrentValue);
        }

        [Test]
        public void PlayerToScoreUp_Player1HasNoWinGames_ShouldHave1WinGames()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.NumberOfWinGames = 0;
            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(0);

            game.PlayerToScoreUp(game.Player1);

            Assert.AreEqual(1, game.Player1.NumberOfWinGames);
            Assert.AreEqual(0, game.Player1.Score.CurrentValue);
            Assert.AreEqual(0, game.Player2.Score.CurrentValue);
        }

        [Test]
        public void PlayerToScoreUp_Player1ToScoreUpFrom40ButPlayer2HasTheAdvantage_ShouldBeBackToDeuce()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(40);
            game.Player2.HasAdvantage = true;

            Assert.IsFalse(game.IsInDeuce());
            game.PlayerToScoreUp(game.Player1);
            Assert.IsTrue(game.IsInDeuce());
        }

        [Test]
        public void PlayerToScoreUp_GameIsInDeuceAndPlayer1ScoreUp_PlayerOneShouldTakeAdvantage()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(40);

            game.PlayerToScoreUp(game.Player1);
            Assert.IsFalse(game.IsInDeuce());
            Assert.IsTrue(game.Player1.HasAdvantage);
            Assert.IsFalse(game.Player2.HasAdvantage);
        }

        [Test]
        public void SetWinnerOfTheGame_WithPlayer1HasAScoreOf40_WithPlayer1WinsTheGame_WithPlayer2HasAScoreOf15_ShouldPlayer1HaveANumberOf1WinGamesAndBothPlayersScoresAreSetToZero()
        {
            var game = new Game(new Player("Player 1"), new Player("Player 2"));

            game.Player1.NumberOfWinGames = 0;

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(15);

            game.SetWinnerOfTheGame(game.Player1);

            Assert.AreEqual(1, game.Player1.NumberOfWinGames);
            Assert.AreEqual(0, game.Player1.Score.CurrentValue);
            Assert.AreEqual(0, game.Player2.Score.CurrentValue);
        }
    }
}