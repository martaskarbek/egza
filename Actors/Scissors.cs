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

        public override PlayerTeam Team => throw new NotImplementedException();

        public override void OnGameCycle()
        {
		
		            if (!Alive)
                return;

            // Rock movement logic is fully implemented as an example

            // Make next move
            var myPosition = MapReference.GetPosition(this);
            var nearestFlagPosition = MapReference.GetNearestFlagPosition(this);
            var targetDirection = GetMoveDirection(myPosition, nearestFlagPosition);

            MapReference.TryMovePlayer(this, myPosition, targetDirection);
            // See Rock.OnGameCycle() for example implementation

            //throw new NotImplementedException();
        }

        public override int Fight(Player otherPlayer)
        {
            throw new NotImplementedException();
        }
    }
}