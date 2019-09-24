namespace Quantum33.Kata.Tennis
{

    public class Game
    {
        public Player Player1 { get; }

        public Player Player2 { get; }

        public bool IsFinished { get; private set; } = false;

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public bool IsInDeuce() =>
            Player1.Score.CurrentValue == 40
            && Player1.Score.CurrentValue == Player2.Score.CurrentValue
            && !OneOfThePlayersHasAdvantage();

        

        public void PlayerToScoreUp(Player winner)
        {
            if (IsInDeuce())
            {
                winner.Score.TryScoreUp();
                winner.HasAdvantage = true;
            }
            else if (TryBackToDeuce(winner))
            {
                // the game is back to deuce
            }
            else if (winner.Score.TryScoreUp())
            {
                // score up
            }
            else
            {
                SetWinnerOfTheGame(winner);
            }
        }

        private Player GetOtherPlayer(Player identifiedPlayer)
            => identifiedPlayer == Player1
            ? Player2
            : Player1;

        internal void SetWinnerOfTheGame(Player winner)
        {
            winner.WinsTheGame();

            Player loser = GetOtherPlayer(winner);
            loser.LoseTheGame();

            IsFinished = true;
        }

        private bool OneOfThePlayersHasAdvantage()
        {
            if (Player1.HasAdvantage || Player2.HasAdvantage)
            {
                return true;
            }
            return false;
        }

        private bool TryBackToDeuce(Player toScoreUp)
        {
            if (IsInDeuce())
            {
                return false;
            }

            Player other = GetOtherPlayer(toScoreUp);
            if (toScoreUp.Score.CurrentValue == 40 && other.HasAdvantage)
            {
                Player1.HasAdvantage = false;
                Player2.HasAdvantage = false;
                return true;
            }
            return false;
        }
    }
}