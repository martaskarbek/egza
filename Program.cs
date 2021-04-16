using System;
using System.Collections.Generic;
using Codecool.CaptureTheFlag;

namespace namespace Codecool.CaptureTheFlag
{
    class Program
    {
        static void Main(string[] args)
        {
                    public static readonly string TestMap = "FFFFFFFFFFFFFFFF" + Environment.NewLine + "F..............F" + Environment.NewLine + "F..............F" + Environment.NewLine + "F..PRSPRSPRSP..F" + Environment.NewLine + "F..S........R..F"
                                                + Environment.NewLine + "F..R........S..F" + Environment.NewLine + "F..P..FFFF..P..F" + Environment.NewLine + "F..S..FFFF..R..F" + Environment.NewLine + "F..R..FFFF..S..F" + Environment.NewLine + "F..P..FFFF..P..F" + Environment.NewLine + "F..S........R..F"
                                                + Environment.NewLine + "F..R........S..F" + Environment.NewLine + "F..PSRPSRPSRP..F" + Environment.NewLine + "F..............F" + Environment.NewLine + "F..............F" + Environment.NewLine + "FFFFFFFFFFFFFFFF";

            var gameMap = new GameMap(TestMap);
            var game = new Game(gameMap);

            game.SimulateGame();

        }
    }
}
