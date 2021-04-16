using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a position of given actor instance
        ///     Should throw an ArgumentException if actor is not found or no actor is given
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public (int x, int y) GetPosition(Actor actor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Assignes given actor to given position
        ///     Should throw an ArgumentException if the position is occupied by an another actor
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="position"></param>
        public void SetPosition(Actor actor, (int x, int y) position)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns true if given position is within the map's boundaries
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool WithinBoundaries((int x, int y) position)
        {
            throw new NotImplementedException();
        }
    }
}