using NUnit.Framework;
using Quantum33.Kata.Tennis;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void IsInDeuce_ValidScoresOf40Each_True()
        {
            var game = new Game(new Player(), new Player());

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(40);

            Assert.IsTrue(game.IsInDeuce());
        }

        [Test]
        public void IsInDeuce_Player1HasAScoreNotEqualsTo40_False()
        {
            var game = new Game(new Player(), new Player());

            game.Player1.Score.SetCurrentValueTo(15);
            game.Player2.Score.SetCurrentValueTo(40);

            Assert.IsFalse(game.IsInDeuce());
        }

        [Test]
        public void Play_Player1ToScoreUpFrom0To15_Success()
        {
            var game = new Game(new Player(), new Player());

            game.Player1.Score.SetCurrentValueTo(0);
            game.Player2.Score.SetCurrentValueTo(0);

            game.Play(game.Player1);
            Assert.AreEqual(15, game.Player1.Score.CurrentValue);
            Assert.AreEqual(0, game.Player2.Score.CurrentValue);
        }

        [Test]
        public void Play_Player1ToScoreUpAndWinsTheSets_Success()
        {
            var game = new Game(new Player(), new Player());

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(0);

            game.Play(game.Player1);

            Assert.AreEqual(1, game.Player1.NumberOfSets);
            Assert.AreEqual(0, game.Player1.Score.CurrentValue);
            Assert.AreEqual(0, game.Player2.Score.CurrentValue);

        }

        [Test]
        public void Play_Player1ToScoreUpFrom40ButPlayer2HasTheAdvantage_ShouldBeBackToDeuce()
        {
            var game = new Game(new Player(), new Player());

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(40);
            game.Player2.HasAdvantage = true;

            Assert.IsFalse(game.IsInDeuce());
            game.Play(game.Player1);
            Assert.IsTrue(game.IsInDeuce());
        }

        [Test]
        public void Play_GameIsInDeuceAndPlayer1ScoreUp_PlayerOneShouldTakeAdvantage()
        {
            var game = new Game(new Player(), new Player());

            game.Player1.Score.SetCurrentValueTo(40);
            game.Player2.Score.SetCurrentValueTo(40);

            game.Play(game.Player1);
            Assert.IsFalse(game.IsInDeuce());
            Assert.IsTrue(game.Player1.HasAdvantage);
            Assert.IsFalse(game.Player2.HasAdvantage);
        }

    }
}