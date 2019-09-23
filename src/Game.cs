using System;

namespace Quantum33.Kata.Tennis
{
    public class Game
    {
        public Player Player1 { get; }

        public Player Player2 { get; }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public bool IsInDeuce() =>
            Player1.Score.CurrentValue == 40
            && Player1.Score.CurrentValue == Player2.Score.CurrentValue
            && !OneOfThePlayersHasAdvantage();

        public void Play(Player playerToScoreUp)
        {
            if (IsInDeuce())
            {
                playerToScoreUp.Score.TryScoreUp();
                playerToScoreUp.HasAdvantage = true;
            }
            else if (TryBackToDeuce(playerToScoreUp))
            {
                // the game is back to deuce
            }
            else if (playerToScoreUp.Score.TryScoreUp())
            {
                // score up
            }
            else
            {
                IncrementNumberOfSetsFor(playerToScoreUp);
            }
        }

        private void IncrementNumberOfSetsFor(Player playerToScoreUp)
        {
            playerToScoreUp.NumberOfSets++;
            Player1.Score.Reset();
            Player2.Score.Reset();
        }

        private bool OneOfThePlayersHasAdvantage()
        {
            if (Player1.HasAdvantage || Player2.HasAdvantage)
            {
                return true;
            }
            return false;
        }

        private bool TryBackToDeuce(Player playerToScoreUp)
        {
            if (IsInDeuce())
            {
                return false;
            }

            Player other = playerToScoreUp == Player1
                ? Player2
                : Player1;
            if (playerToScoreUp.Score.CurrentValue == 40 && other.HasAdvantage)
            {
                Player1.HasAdvantage = false;
                Player2.HasAdvantage = false;
                return true;
            }
            return false;
        }
    }
}
