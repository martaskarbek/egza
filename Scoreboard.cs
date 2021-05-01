using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.CaptureTheFlag.Actors;

namespace Codecool.CaptureTheFlag
{
    /// <summary>
    ///     Static class with extension methods for reports about players' performance during the game
    /// </summary>
    public static class Scoreboard
    {
        /// <summary>
        ///     Returns a collection of all players, sorted by their score (from highest to lowest)
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static IEnumerable<Player> GetRankedPlayers(this IEnumerable<Player> players)
        {
            //IEnumerable<Player> result = players.OrderByDescending(p => p.CurrentScore);
            return players.OrderByDescending(p => p.CurrentScore);;
        }

        /// <summary>
        ///     Returns a collection of all players, from given team, sorted by their score (from highest to lowest)
        /// </summary>
        /// <param name="players"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public static IEnumerable<Player> GetRankedPlayersInTeam(this IEnumerable<Player> players, PlayerTeam team)
        {
            //IEnumerable<Player> result = players.Where(p => p.Team == team).OrderByDescending(p => p.CurrentScore);
            return players.Where(p => p.Team == team).OrderByDescending(p => p.CurrentScore);;
        }

        /// <summary>
        ///     Returns the team that has the greatest amount of points scored by its players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static PlayerTeam GetWinningTeam(this IEnumerable<Player> players)
        {
            var teams = players.GroupBy(team => team.Team)
                .Select(x => new { Team = x.Key, TotalPoint = x.Sum(x => x.CurrentScore) })
                .OrderByDescending(x => x.TotalPoint)
                .FirstOrDefault();

            return teams.Team;
        }

        /// <summary>
        ///     Returns amount of dead players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static int GetDeadPlayersAmount(this IEnumerable<Player> players)
        {
            return players.Count(player => !player.Alive);
        }

        /// <summary>
        ///     Returns full scoreboard string for current game (see the example)
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static string GetScoreboard(this IEnumerable<Player> players)
        {
            // Team Rock Adam Points: 20
            // Team Paper Eve Points: 10
            // Team Scissors Abel Points: 5 DEAD

            StringBuilder scoreboard = new StringBuilder();
            string isDead = String.Empty;
            foreach (var player in players)
            {
                var teamName = player.Team switch
                {
                    PlayerTeam.Paper => "Paper",
                    PlayerTeam.Rock => "Rock",
                    PlayerTeam.Scissors => "Scissors",
                    //  _ => teamName
                };

                scoreboard.Append(!player.Alive
                    ? $"Team {teamName} {player.Name} Points: {player.CurrentScore.ToString()} DEAD\n"
                    : $"Team {teamName} {player.Name} Points: {player.CurrentScore.ToString()}\n");
            }

            return scoreboard.ToString();
        }
    }
}