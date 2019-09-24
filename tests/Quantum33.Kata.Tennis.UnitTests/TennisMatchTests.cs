using NUnit.Framework;
using Quantum33.Kata.Tennis;

namespace Tests
{
    public class TennisMatchTests
    {
        [Test]
        public void IsOver_BothPlayersHaveNoWinGames_False()
        {
            var match = new TennisMatch();
            Assert.IsFalse(match.IsOver());
        }

        [Test]
        public void IsOver_Player1Has6WinGamesAndHasAMinimumOf2GamesOfDifferenceWithPlayer2_True()
        {
            var match = new TennisMatch();
            match.Player1.NumberOfWinGames = 6;
            match.Player2.NumberOfWinGames = 0;
            Assert.IsTrue(match.IsOver());
        }

        [Test]
        public void IsOver_Player1Has6WinGamesAndHasA1WinGamesOfDifferenceWithPlayer2_False()
        {
            var match = new TennisMatch();
            match.Player1.NumberOfWinGames = 6;
            match.Player2.NumberOfWinGames = 5;
            Assert.IsFalse(match.IsOver());
        }

        [Test]
        public void IsOver_Player1Has7WinGamesAndHasAMinimumOf2GamesOfDifferenceWithPlayer2_True()
        {
            var match = new TennisMatch();
            match.Player1.NumberOfWinGames = 7;
            match.Player2.NumberOfWinGames = 5;
            Assert.IsTrue(match.IsOver());
        }
    }
}