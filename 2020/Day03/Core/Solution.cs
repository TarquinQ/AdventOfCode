using Advent2020.Helpers;
using Advent2020.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2020.Core
{
    public class Solution1
    {
        public int Answer { get; protected set; } = 0;
        public int CountTrees { get; protected set; } = 0;

        public virtual Solution1 Calc(TreeSlope terrainFromInput, MovementVector vector)
        {
            int countNonEmpty = 0;
            SkierOnSlope skier = new SkierOnSlope(terrainFromInput);
            DumpStart(skier);
            while (skier.CanMove(vector))
            {
                skier.Move(vector);
                Logger.Debug("Current Skier Position is now: {0} -- TerrainItem is: {1}", skier.CurrentPos.ToString(), skier.CurrentTerrainItem);
                Logger.Debug("Current Map:{0}{1}", Environment.NewLine, skier.Slope.ToString());
                if (skier.CurrentTerrainItem.Equals(TerrainItem.VisitedNonEmpty))
                {
                    countNonEmpty++;
                }
            }
            this.CountTrees = countNonEmpty;
            this.Answer = countNonEmpty;
            return this;
        }

        private static void DumpStart(SkierOnSlope skier)
        {
            Logger.Debug("Starting Solution.");
            Logger.Debug("Input Slope Height is: {0}", skier.Slope.Height.ToString());
            Logger.Debug("Current Skier Position is: {0}", skier.CurrentPos.ToString());
        }
    }

    public class Solution2 : Solution1
    {
        //public override Solution2 Calc(ICollection<InputtedPolicyLine> inputLines)
        //{
        //    return this;
        //}
    }
}
