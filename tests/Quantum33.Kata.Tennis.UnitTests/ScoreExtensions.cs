using Quantum33.Kata.Tennis;
using System;

namespace Tests
{
    internal static class ScoreExtensions
    {
        public static Score SetCurrentValueTo(this Score score, int value)
        {
            if (!Score.Values.Contains(value))
            {
                throw new IndexOutOfRangeException($"{value} is not a VALID value");
            }

            score.Reset();
            while (score.CurrentValue != value)
            {
                score.TryScoreUp();
            }

            return score;
        }
    }
}