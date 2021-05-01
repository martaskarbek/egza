using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Codecool.CaptureTheFlag.Actors;

namespace Codecool.CaptureTheFlag
{
    /// <summary>
    ///     GameMap class
    /// </summary>
    public class GameMap
    {
        /// <summary>
        ///     A 2D matrix of all actor references (null if the field is empty)
        /// </summary>
        public Actor[,] ActorMatrix { get; }

        /// <summary>
        ///     Returns a new GameMap instance, constructed from given char matrix
        /// </summary>
        /// <param name="charMatrix"></param>
        public GameMap(string charMatrix)
        {
            Flags = new List<Flag>();
            Players = new List<Player>();
            char[,] charsMatrix = CharsMatrix(charMatrix);
            
            
            ActorMatrix = new Actor[charsMatrix.GetLength(0), charsMatrix.GetLength(1)];
            FillMatrix(charsMatrix);
        }

        private char[,] CharsMatrix(string charMatrix)
        {
            var strings = Regex.Split(charMatrix, "\r\n|\r|\n");
            string[,] stringMatrix = new string[strings.Length, 1];
            for (var i = 0; i < strings.Length; i++)
            {
                stringMatrix[i,0] = strings[i];
            }
          
            char[,] charsMatrix = new char[strings.Length, stringMatrix[0,0].Length];
            for(var i = 0; i < stringMatrix.Length; i++)
            {
                var chars = stringMatrix[i, 0].ToCharArray();
                for(var j = 0; j < chars.Length; j++)
                {
                    charsMatrix[i, j] = chars[j];
                }
            }

            return charsMatrix;
        }

        private void FillMatrix(char[,] charsMatrix)
        {
            Actor actor = null;
            for (var i = 0; i < charsMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < charsMatrix.GetLength(1); j++)
                {
                    if (charsMatrix[i, j].Equals('.'))
                        ActorMatrix[i,j] = null;
                    else
                    {
                        actor = ActorFactory.CreateFromChar(charsMatrix[i,j], this);
                        SetPosition(actor, (i,j));
                        if (actor.GetType().ToString().Equals("Codecool.CaptureTheFlag.Actors.Flag"))
                        {
                            Flags.Add((Flag)actor);
                        }
                        else
                        {
                            Players.Add((Player)actor);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Contains all players present on the map (also dead ones)
        /// </summary>
        public List<Player> Players { get; }

        /// <summary>
        ///     Contains all players present on the map (also captured ones)
        /// </summary>
        public List<Flag> Flags { get; }

        /// <summary>
        ///     Returns a char matrix of map's current state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            var singleResult = new StringBuilder();
            
            for (var i = 0; i < ActorMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < ActorMatrix.GetLength(1); j++)
                {
                    singleResult.Append(GetActor((i, j)).GetChar());
                }

                result.Append($"{singleResult}");
                result.Append(Environment.NewLine);
                //result.Append(singleResult + Environment.NewLine);
                singleResult.Clear();
            }

            return result.ToString();
        }

        /// <summary>
        ///     Returns an actor instance present on given position
        ///     Should return null if no actor is present
        ///     Should throw an ArgumentException if the position is outside map's boundaries
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Actor GetActor((int x, int y) position)
        {
            if (position.x > ActorMatrix.GetLength(1) - 1)
                throw new ArgumentException();
            if (position.y > ActorMatrix.GetLength(0) - 1)
                throw new ArgumentException();
            return ActorMatrix[position.y, position.x];
        }

        /// <summary>
        ///     Returns a position of given actor instance
        ///     Should throw an ArgumentException if actor is not found or no actor is given
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public (int x, int y) GetPosition(Actor actor)
        {
            int X = 0;
            int Y = 0;
            if (actor == null)
                throw new AggregateException();
            for (var i = 0; i < ActorMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < ActorMatrix.GetLength(1); j++)
                {
                    if (ActorMatrix[i, j] == actor)
                    {
                        Y += i;
                        X += j;
                        return (X, Y);
                    }
                }
            }

            throw new ArgumentException();
        }

        /// <summary>
        ///     Assignes given actor to given position
        ///     Should throw an ArgumentException if the position is occupied by an another actor
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="position"></param>
        public void SetPosition(Actor actor, (int x, int y) position)
        {
            if (ActorMatrix[position.x, position.y] != null)
                throw new ArgumentException();
            ActorMatrix[position.x, position.y] = actor;
        }

        /// <summary>
        ///     Attempts to move given player to a new position
        ///     If necessary, restricts movement or simulates fights between players (DO NOT MODIFY)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="currentPosition"></param>
        /// <param name="dir"></param>
        public void TryMovePlayer(Player player, (int x, int y) currentPosition, Direction dir)
        {
            var (x, y) = dir.ToVector();
            (int x, int y) targetPosition = (currentPosition.x + x, currentPosition.y + y);

            if (!WithinBoundaries(targetPosition))
                return;

            var actorOnTargetPosition = GetActor(targetPosition);

            switch (actorOnTargetPosition)
            {
                case null:
                {
                    // Empty field, player can move here
                    ActorMatrix[currentPosition.y, currentPosition.x] = null;
                    SetPosition(player, targetPosition);
                    break;
                }

                case Flag flag:
                {
                    // Capture the flag
                    ActorMatrix[currentPosition.y, currentPosition.x] = null;
                    ActorMatrix[targetPosition.y, targetPosition.x] = null;
                    SetPosition(player, targetPosition);

                    player.CapturedFlags++;
                    flag.Captured = true;
                    break;
                }

                case Player otherPlayer:
                {
                    var fightResult = player.Fight(otherPlayer);

                    if (fightResult == 1)
                    {
                        // Player has won, move to the target position
                        otherPlayer.Alive = false;
                        ActorMatrix[currentPosition.y, currentPosition.x] = null;
                        ActorMatrix[targetPosition.y, targetPosition.x] = null;
                        SetPosition(player, targetPosition);

                        player.KilledPlayers++;
                    }
                    else if (fightResult == 0)
                    {
                        // Other player has won
                        player.Alive = false;
                        ActorMatrix[currentPosition.y, currentPosition.x] = null;
                        ActorMatrix[targetPosition.y, targetPosition.x] = null;
                        SetPosition(otherPlayer, currentPosition);

                        otherPlayer.KilledPlayers++;
                    }

                    break;
                }
            }
        }

        /// <summary>
        ///     Returns the position of an uncaptured flag that is closest to given player
        ///     Should throw ArgumentException if there are no uncaptured flags
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public (int x, int y) GetNearestFlagPosition(Player player)
        {
            int x = 0;
            var playerPosition = GetPosition(player);
            var flagsPositions = new (int x, int y)[Flags.Count];
            for (int i = 0; i < Flags.Count; i++)
            {
                flagsPositions[i] = GetPosition(Flags[i]);
            }

            var distances = new int[Flags.Count];
            
            for (int i = 0; i < Flags.Count; i++)
            {
                int distance = Extensions.GetDistance(playerPosition, flagsPositions[i]);
                distances[i] = distance;
            }

            int lowerDistance = distances.Min();

            var lower = Flags.FirstOrDefault(f => Extensions.GetDistance(playerPosition, GetPosition(f)) == lowerDistance);
            
            return GetPosition(lower);
        }

        /// <summary>
        ///     Returns true if given position is within the map's boundaries
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool WithinBoundaries((int x, int y) position)
        {
            return position.x < ActorMatrix.GetLength(0) -1 && position.y < ActorMatrix.GetLength(1) -1;
        }
    }
}