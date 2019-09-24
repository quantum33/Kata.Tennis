using System.Collections.Generic;

namespace Quantum33.Kata.Tennis
{
    public class Score
    {
        static public List<int> Values { get; } = new List<int> { 0, 15, 30, 40 };

        public int CurrentValue { get => Values[_index]; }

        public void Reset()
        {
            _index = 0;
        }

        /// <summary>
        /// Increments the score value if the limit is not reached.
        /// If the limit is reached, the player wins the current game set
        /// </summary>
        /// <returns>true if the score is incremented by 1, false otherwise (i.e. the player wins the set)</returns>
        public bool TryScoreUp()
        {
            if (CanScoreUp())
            {
                _index++;
                return true;
            }
            return false;
        }

        private bool CanScoreUp()
            => _index + 1 < Values.Count;

        private int _index = 0;
    }
}
