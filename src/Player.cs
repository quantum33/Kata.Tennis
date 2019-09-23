namespace Quantum33.Kata.Tennis
{
    public class Player
    {
        public int NumberOfSets { get; set; } = 0;

        public Score Score { get; private set; } = new Score();

        public bool HasAdvantage { get; set; } = false;            
    }
}
