using System;
using System.ComponentModel.Design;

namespace Codecool.CaptureTheFlag.Actors
{
    /// <summary>
    ///     Paper player class
    /// </summary>
    public class Paper : Player
    {
        public Paper(string name, GameMap mapReference) : base(name, mapReference)
        {
        }

        public override PlayerTeam Team => PlayerTeam.Paper;

        public override void OnGameCycle()
        {
		    if (!Alive)
                    return;

            var myPosition = MapReference.GetPosition(this);
            var nearestFlagPosition = MapReference.GetNearestFlagPosition(this);
            var targetDirection = GetMoveDirection(myPosition, nearestFlagPosition);
            
            var (x, y) = targetDirection.ToVector();
           // (int x, int y) targetPosition = (myPosition.x + 1, myPosition.y + 1);

           if (MapReference.GetActor(targetDirection.ToVector()) is Flag ||
               MapReference.GetActor(targetDirection.ToVector()) is null)
           {
               targetDirection = GetMoveDirection(myPosition, nearestFlagPosition);
           }
            
            if (MapReference.GetActor(targetDirection.ToVector()) is Rock ||
                MapReference.GetActor(targetDirection.ToVector()) is Scissors)
            {
                targetDirection = targetDirection.Inverted();
            }

            MapReference.TryMovePlayer(this, myPosition, targetDirection);
        }

        public override int Fight(Player otherPlayer)
        {
            return otherPlayer is Scissors ? 0 : 1;
        }
    }
}