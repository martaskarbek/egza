using System;

namespace Codecool.CaptureTheFlag.Actors
{
    /// <summary>
    ///     Rock player class
    /// </summary>
    public class Rock : Player
    {
        public Rock(string name, GameMap mapReference) : base(name, mapReference)
        {
        }

        public override PlayerTeam Team => PlayerTeam.Rock;

        public override void OnGameCycle()
        {
            if (!Alive)
                return;
            
            var myPosition = MapReference.GetPosition(this);
            var nearestFlagPosition = MapReference.GetNearestFlagPosition(this);
            var targetDirection = GetMoveDirection(myPosition, nearestFlagPosition);

            MapReference.TryMovePlayer(this, myPosition, targetDirection);
        }

        public override int Fight(Player otherPlayer)
        {
            return otherPlayer is Paper ? 0 : 1;
        }
    }
}