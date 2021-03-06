using System;

namespace Codecool.CaptureTheFlag.Actors
{
    /// <summary>
    ///     Scissors player class
    /// </summary>
    public class Scissors : Player
    {
        public Scissors(string name, GameMap mapReference) : base(name, mapReference)
        {
        }

        public override PlayerTeam Team => PlayerTeam.Scissors;

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
            return otherPlayer is Rock ? 0 : 1;
        }
    }
}