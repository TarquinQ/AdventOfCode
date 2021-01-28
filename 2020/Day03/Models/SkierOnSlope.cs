using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    class SkierOnSlope
    {
        public (int x, int y) CurrentPos { get; protected set; }
        public TreeSlope Slope { get; }
        public bool CompletedDownhill => this.CurrentPos.y == this.Slope.Height;
        public TerrainItem CurrentTerrainItem => this.Slope.GetPosition(this.CurrentPos.x, this.CurrentPos.y);

        public SkierOnSlope(ICollection<ICollection<TerrainItem>> terrainMap)
            : this(slope: new TreeSlope(terrain: terrainMap))
        {
        }

        public SkierOnSlope(TreeSlope slope)
        {
            this.Slope = slope;
            this.CurrentPos = (0, 0);
            this.MarkTerrainAsVisited();
        }

        public SkierOnSlope Move(MovementVector vector)
        {
            if ((this.CurrentPos.y + vector.Move_y) >= this.Slope.Height)
            {
                throw new Exception("bad move, too high");
            }
            int new_x = (this.CurrentPos.x + vector.Move_x) % this.Slope.Width;
            int new_y = (this.CurrentPos.y + vector.Move_y);
            this.CurrentPos = (new_x, new_y);
            this.MarkTerrainAsVisited();
            return this;
        }

        public bool CanMove(MovementVector vector)
        {
            return (this.CurrentPos.y + vector.Move_y) < this.Slope.Height;
        }

        private void MarkTerrainAsVisited()
        {
            var currItem = this.Slope.GetPosition(this.CurrentPos.x, this.CurrentPos.y);
            TerrainItem newItem = currItem.Equals(TerrainItem.Empty) ? TerrainItem.VisitedEmpty : TerrainItem.VisitedNonEmpty;
            this.Slope.SetPosition(this.CurrentPos.x, this.CurrentPos.y,  newItem);
        }
    }
}
