using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public class TreeSlope
    {
        public TerrainItem[][] Terrain { get; }
        public int Height => this.Terrain.Length;
        public int Width { get; protected set; }

        private int _lastRowAdded = -1;

        public TreeSlope(ICollection<ICollection<TerrainItem>> terrain)
            : this(terrain: terrain, height: terrain.Count)
        {
        }

        public TreeSlope(IEnumerable<ICollection<TerrainItem>> terrain, int height)
            : this(height: height)
        {
            int row = 0;
            foreach (ICollection<TerrainItem> terrLine in terrain)
            {
                this.Terrain[row++] = terrLine.ToArray();
            }
            this.Width = terrain.First().Count;
            this._lastRowAdded = height;
        }

        public TreeSlope(int height)
        {
            this.Terrain = new TerrainItem[height][];
        }

        public TreeSlope AddLine(TerrainItem[] line)
        {
            if (this._lastRowAdded == -1)
            {
                this.Width = line.Length;
            }
            this._lastRowAdded++;
            this.Terrain[this._lastRowAdded] = line;

            return this;
        }

        public TerrainItem GetPosition(int x, int y)
        {
            return this.Terrain[y][x];
        }

        public TreeSlope SetPosition(int x, int y, TerrainItem item)
        {
            this.Terrain[y][x] = item;
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    sb.Append(TerrainCharMapping.ConvertTo(this.Terrain[i][j]));
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
