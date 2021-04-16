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
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a vector representing given direction
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static (int x, int y) ToVector(this Direction dir)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a direction that is opposite to given direction
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Direction Inverted(this Direction dir)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns the amount of steps a player has to make in order to get from pos1 to pos2
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <returns></returns>
        public static int GetDistance((int x, int y) pos1, (int x, int y) pos2)
        {
            throw new NotImplementedException();
        }
    }
}