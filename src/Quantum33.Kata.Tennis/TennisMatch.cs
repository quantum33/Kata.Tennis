using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Quantum33.Kata.Tennis.UnitTests")]
namespace Quantum33.Kata.Tennis
{
    public class TennisMatch
    {
        public TennisMatch(Action<string> logMethod = null)
        {
            LogMethod = logMethod ?? _defaultLogMethod;
        }

        public Player Player1 { get; } = new Player("Player 1");

        public Player Player2 { get; } = new Player("Player 2");

        public void Play()
        {
            while(!IsOver())
            {
                var game = new Game(Player1, Player2);
                LogMethod("");
                LogMethod("Playing....");
                (Player winner, Player loser) = GetWinnerAndLoserOfThePoint();

                LogMethod($"{winner.Name} wins the point");

                while (!game.IsFinished)
                {
                    game.PlayerToScoreUp(winner);

                    if (!game.IsFinished)
                    {
                        LogScores();
                    }
                }
                LogPlayersWinGames();
            }
        }

        internal bool IsOver()
        {
            Func<Player, bool> playerHasAMinimumOfSixWinGames = 
                (player) => player.NumberOfWinGames >= Constants.NumberOfSetsToWinTheMatch;

            Func<bool> playerHaveMinimumOfTwoGamesOfDifference =
                () => Math.Abs(Player1.NumberOfWinGames - Player2.NumberOfWinGames) >= 2;

            return (playerHasAMinimumOfSixWinGames(Player1) || playerHasAMinimumOfSixWinGames(Player2))
                && playerHaveMinimumOfTwoGamesOfDifference();
        }

        public bool TryGetWinner(out Player player)
        {
            player = null;
            if (!IsOver()) return false;

            player = Player1.NumberOfWinGames > Player2.NumberOfWinGames
                ? Player1
                : Player2;
            return true;
        }

        private (Player winner, Player loser) GetWinnerAndLoserOfThePoint()
        {
            return new Random().Next(0, 100) < 50
                ? (winner: Player1, loser: Player2)
                : (winner: Player2, loser: Player1);
        }

        private void LogScores()
        {
            _logScoreFor(Player1);
            _logScoreFor(Player2);

            void _logScoreFor(Player player)
            {
                LogMethod($"{player.Name}: {player.Score.CurrentValue}");
            }
        }

        private void LogPlayersWinGames()
        {
            Action<Player> logWinGames = 
                (player) => LogMethod($"{player.Name}: {player.NumberOfWinGames}");

            LogMethod("-----------------------------------------");
            LogMethod("Win games:");
            logWinGames(Player1);
            logWinGames(Player2);
            LogMethod("-----------------------------------------");
        }

        public Action<string> LogMethod { get; }

        private readonly Action<string> _defaultLogMethod =
            (message) => Console.WriteLine(message);
    }
}
