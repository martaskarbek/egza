using System;
using System.Collections.Generic;
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
            IEnumerable<Players> result = new 
        }

        /// <summary>
        ///     Returns a collection of all players, from given team, sorted by their score (from highest to lowest)
        /// </summary>
        /// <param name="players"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public static IEnumerable<Player> GetRankedPlayersInTeam(this IEnumerable<Player> players, PlayerTeam team)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns the team that has the greatest amount of points scored by its players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static PlayerTeam GetWinningTeam(this IEnumerable<Player> players)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns amount of dead players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static int GetDeadPlayersAmount(this IEnumerable<Player> players)
        {
            throw new NotImplementedException();
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

            throw new NotImplementedException();
        }
    }
}