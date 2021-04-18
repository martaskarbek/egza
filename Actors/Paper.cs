using System;

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

        MapReference.TryMovePlayer(this, myPosition, targetDirection);
        }

        public override int Fight(Player otherPlayer)
        {
            throw new NotImplementedException();
        }
    }
}