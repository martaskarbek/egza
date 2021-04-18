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
            return actor.GetType().ToString() switch
            {
                "Codecool.CaptureTheFlag.Actors.Paper" => 'P',
                "Codecool.CaptureTheFlag.Actors.Rock" => 'R',
                "Codecool.CaptureTheFlag.Actors.Scissors" => 'S',
                "Codecool.CaptureTheFlag.Actors.Flag" => 'F',
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>
        ///     Returns a vector representing given direction
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static (int x, int y) ToVector(this Direction dir)
        {
            return dir switch
            {
                Direction.Up => (0, -1),
                Direction.Down => (0, 1),
                Direction.Left => (-1, 0),
                Direction.Right => (1, 0),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>
        ///     Returns a direction that is opposite to given direction
        ///     Throws an ArgumentOutOfRangeException when given invalid input
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Direction Inverted(this Direction dir)
        {
            return dir switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>
        ///     Returns the amount of steps a player has to make in order to get from pos1 to pos2
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <returns></returns>
        public static int GetDistance((int x, int y) pos1, (int x, int y) pos2)
        {
            int X = pos1.x - pos2.x;
            int XConverted = X < 0 ? X * -1 : X;
            int Y = pos1.y - pos2.y;
            int YConverted = Y < 0 ? Y * -1 : Y;
            
            return XConverted + YConverted;
        }
    }
}