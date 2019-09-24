using System;

namespace Quantum33.Kata.Tennis
{
    public class Player
    {
        public Player(string name)
        {
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name));
        }

        public int NumberOfWinGames { get; set; } = 0;
        public string Name { get; }

        public Score Score { get; private set; } = new Score();

        public bool HasAdvantage { get; set; } = false;        
        
        public void WinsTheGame()
        {
            NumberOfWinGames++;
            Score.Reset();
        }

        public void LoseTheGame()
        {
            Score.Reset();
        }
    }
}
