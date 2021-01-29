using Advent2020.Helpers;
using Advent2020.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2020.Core
{
    public class Solution1
    {
        public long Answer { get; protected set; } = 0;
        public int CountTrees { get; protected set; } = 0;

        protected SkierOnSlope _skier;

        public Solution1(TreeSlope terrainFromInput)
        {
            this._skier = new SkierOnSlope(terrainFromInput);
        }

        public virtual Solution1 Calc(MovementVector vector)
        {
            int countNonEmpty = 0;
            this._skier.Reset();
            this.DumpStart();
            while (this._skier.CanMove(vector))
            {
                this._skier.Move(vector);
                Logger.Debug("Current Skier Position is now: {0} -- TerrainItem is: {1}", this._skier.CurrentPos.ToString(), this._skier.CurrentTerrainItem);
                //Logger.Debug("Current Map:{0}{1}", Environment.NewLine, this._skier.Slope.ToString());
                if (this._skier.CurrentTerrainItem.Equals(TerrainItem.VisitedNonEmpty))
                {
                    countNonEmpty++;
                }
            }
            this.CountTrees = countNonEmpty;
            this.Answer = countNonEmpty;
            return this;
        }

        protected void DumpStart()
        {
            Logger.Debug("Starting Solution.");
            Logger.Debug("Input Slope Height is: {0}", this._skier.Slope.Height.ToString());
            Logger.Debug("Current Skier Position is: {0}", this._skier.CurrentPos.ToString());
        }
    }

    public class Solution2 : Solution1
    {
        public Solution2(TreeSlope terrainFromInput) : base(terrainFromInput)
        {
        }


        public Solution2 Calc2(MovementVector[] vectors)
        {
            var answers = new List<long>();
            foreach (MovementVector vector in vectors)
            {
                Logger.Info("Now processing slope with movementVector: {0}", vector.ToString());
                answers.Add(this.Calc(vector).Answer);
                Logger.Info("Slope with movementVector: {0} has count: {1}", vector.ToString(), answers[^1]);
                Logger.Info("Completed slope with at position: {0}", this._skier.CurrentPos.ToString());
                this._skier.Reset();
                Logger.Info("Reset slope to position: {0}", this._skier.CurrentPos.ToString());
            }

            long finalAnswer = 1;
            foreach (long answer in answers)
            {
                finalAnswer *= answer;
            }
            this.Answer = finalAnswer;
            Logger.Info("Answers: {0}, from: {1}", finalAnswer.ToString(), String.Join<long>(" * ", answers));

            return this;
        }
    }
}
