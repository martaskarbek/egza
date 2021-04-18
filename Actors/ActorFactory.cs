using System;
using System.Collections.Generic;

namespace Codecool.CaptureTheFlag.Actors
{
    /// <summary>
    ///     Static class for creating new actor instances
    /// </summary>
    public static class ActorFactory
    {
        /// <summary>
        ///     A predefined collection of names for the players
        /// </summary>
        private static readonly Queue<string> _names = new Queue<string>(new[]
        {
            "Marcel", "Moises", "Zane", "Dashawn", "Sean", "Rashad", "Seth", "Oliver", "Chris", "Quinton",
            "August", "Yusuf", "Jeramiah", "Bryce", "Rory", "Preston", "Eli", "Elisha", "Vicente", "Cristian",
            "Justice", "Eddie", "Allan", "Aarav", "Layne", "Owen", "Julio", "Soren", "Levi", "Mekhi", "Paul",
            "Griffin", "Agustin", "Johan", "Jaydin", "Skylar", "Rodrigo", "Brian", "John", "Davon", "Damari",
            "Ty", "Raymond", "Ronald", "Noah", "Abdiel", "Tyree", "Trent", "Rafael", "Jamarion"
        });

        /// <summary>
        ///     Use this method for getting names
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static string Get(this Queue<string> queue)
        {
            var s = queue.Dequeue();
            queue.Enqueue(s);

            return s;
        }

        /// <summary>
        ///     Returns a new player instance, depending on given team
        /// </summary>
        /// <param name="team"></param>
        /// <param name="mapReference"></param>
        /// <returns></returns>
        public static Actor CreatePlayer(PlayerTeam team, GameMap mapReference)
        {
            Actor actor = null;
            string name = Get(_names);
            switch (team)
            {
                case PlayerTeam.Paper: 
                    actor = new Paper(name, mapReference);
                    break;
                case PlayerTeam.Rock:
                    actor = new Rock(name, mapReference);
                    break;
                case PlayerTeam.Scissors:
                    actor = new Scissors(name, mapReference);
                    break;
            }

            return actor;
        }

        /// <summary>
        ///     Returns a new Flag instance
        /// </summary>
        /// <param name="mapReference"></param>
        /// <returns></returns>
        public static Actor CreateFlag(GameMap mapReference)
        {
            return new Flag(mapReference);
        }

        /// <summary>
        ///     Returns a new actor instance, depending on given character
        /// </summary>
        /// <param name="c"></param>
        /// <param name="mapReference"></param>
        /// <returns></returns>
        public static Actor CreateFromChar(char c, GameMap mapReference)
        {
            Actor actor = null;
            switch (c)
            {
                case 'F':
                    actor = CreateFlag(mapReference);
                    break;
                case 'R':
                    actor = CreatePlayer(PlayerTeam.Rock, mapReference);
                    break;
                case 'P':
                    actor = CreatePlayer(PlayerTeam.Paper, mapReference);
                    break;
                case 'S':
                    actor = CreatePlayer(PlayerTeam.Scissors, mapReference);
                    break;
            }

            return actor;
        }
    }
}