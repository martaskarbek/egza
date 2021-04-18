using System;
using Codecool.CaptureTheFlag.Actors;

namespace Codecool.CaptureTheFlag
{
    /// <summary>
    ///     Direction enum
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Extensions
    {
        /// <summary>
        ///     Returns a character representing given actor
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public static char GetChar(this Actor actor)
        {
            if (actor.GetType().ToString().Equals("Codecool.CaptureTheFlag.Actors.Paper"))
            {
                return 'P';
            }
            if (actor.GetType().ToString().Equals("Codecool.CaptureTheFlag.Actors.Rock"))
            {
                return 'R';
            }
            if (actor.GetType().ToString().Equals("Codecool.CaptureTheFlag.Actors.Scissors"))
            {
                return 'S';
            }
            if (actor.GetType().ToString().Equals("Codecool.CaptureTheFlag.Actors.Flag"))
            {
                return 'F';
            }
            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        ///     Returns a vector representing given direction
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, -1);
                case Direction.Down:
                    return (0, 1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        ///     Returns a direction that is opposite to given direction
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Direction Inverted(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        ///     Returns the amount of steps a player has to make in order to get from pos1 to pos2
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <returns></returns>
        public static int GetDistance((int x, int y) pos1, (int x, int y) pos2)
        {
            int result = (pos1.x - pos2.x) + (pos1.y - pos2.y);
            return result < 0 ? result * -1 : result;
        }
    }
}