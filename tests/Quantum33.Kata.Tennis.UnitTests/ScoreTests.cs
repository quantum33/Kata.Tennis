using NUnit.Framework;
using Quantum33.Kata.Tennis;

namespace Tests
{
    public class ScoreTests
    {

        [Test]
        public void TryScoreUp_CurrentValueIsInitializedToZero()
        {
            Assert.AreEqual(0, new Score().CurrentValue);
        }

        [Test]
        public void TryScoreUp_EachValueIsCorrect()
        {
            var score = new Score();
            Assert.IsTrue(score.TryScoreUp());
            Assert.AreEqual(15, score.CurrentValue);

            Assert.IsTrue(score.TryScoreUp());
            Assert.AreEqual(30, score.CurrentValue);

            Assert.IsTrue(score.TryScoreUp());
            Assert.AreEqual(40, score.CurrentValue);

            Assert.IsFalse(score.TryScoreUp());
        }
    }
}