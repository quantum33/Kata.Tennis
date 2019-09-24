using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Quantum33.Kata.Tennis.UnitTests")]
namespace Quantum33.Kata.Tennis
{
    public class TennisMatch
    {
        public Player Player1 { get; } = new Player("Player 1");

        public Player Player2 { get; } = new Player("Player 2");

        public void Play()
        {
            while(!IsOver())
            {
                var game = new Game(Player1, Player2);
                (Player winner, Player loser) = GetWinnerAndLoserOfThePoint();

                Console.WriteLine($"{winner.Name} wins the point");

                while (!game.IsFinished)
                {
                    game.PlayTheBall(winner);

                    if (!game.IsFinished)
                    {
                        LogScores();
                    }
                }
                LogPlayerWinGames();
            }
        }

        internal bool IsOver()
        {
            Func<Player, bool> playerHasAMinimumOfSixWinGames = (player) => player.NumberOfWinGames >= Constants.NumberOfSetsToWinTheMatch;
            Func<bool> playerHaveMinimumOfTwoGamesOfDifference = () => Math.Abs(Player1.NumberOfWinGames - Player2.NumberOfWinGames) >= 2;

            return (playerHasAMinimumOfSixWinGames(Player1) || playerHasAMinimumOfSixWinGames(Player2))
                && playerHaveMinimumOfTwoGamesOfDifference();
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
                Console.WriteLine($"{player.Name}: {player.Score.CurrentValue}");
            }
        }

        private void LogPlayerWinGames()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Win games:");
            _logWinGames(Player1);
            _logWinGames(Player2);
            Console.WriteLine("-----------------------------------------");

            void _logWinGames(Player player)
            {
                Console.WriteLine($"{player.Name}: {player.NumberOfWinGames}");
            }
        }
    }
}
