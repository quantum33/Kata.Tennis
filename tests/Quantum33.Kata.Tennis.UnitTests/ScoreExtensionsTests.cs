using NUnit.Framework;
using Quantum33.Kata.Tennis;

namespace Tests
{
    public class ScoreExtensionsTests
    {
        [Test]
        public void SetCurrentValueTo_40()
        {
            Score score = new Score().SetCurrentValueTo(40);

            Assert.AreEqual(40, score.CurrentValue);
        }

        [Test]
        public void SetCurrentValueTo_40_ThenTo15()
        {
            Score score = new Score()
                .SetCurrentValueTo(40)
                .SetCurrentValueTo(15);

            Assert.AreEqual(15, score.CurrentValue);
        }

        [Test]
        public void SetCurrentValueTo_0_ThenTo30_ThenTo0()
        {
            Score score = new Score()
                .SetCurrentValueTo(0)
                .SetCurrentValueTo(30)
                .SetCurrentValueTo(0);

            Assert.AreEqual(0, score.CurrentValue);
        }
    }
}