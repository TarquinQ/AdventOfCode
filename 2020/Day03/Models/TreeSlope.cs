using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public class TreeSlope
    {
        protected TerrainItem[][] _terrainInput;
        protected TerrainItem[,] _terrainActive;
        public int Height { get; }
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
                this._terrainInput[row++] = terrLine.ToArray();
            }
            this.Width = terrain.First().Count;
            this._lastRowAdded = height;
            this.Reset();
        }

        public TreeSlope(int height)
        {
            this.Height = height;
            this._terrainInput = new TerrainItem[height][];
            this._terrainActive = new TerrainItem[1,height];
            this._terrainActive[0, 0] = TerrainItem.Empty;
        }

        public TreeSlope Reset()
        {
            this._terrainActive = new TerrainItem[this.Width, this.Height];
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    this._terrainActive[j, i] = this._terrainInput[i][j];
                }
            }
            return this;
        }

        public TreeSlope AddLine(TerrainItem[] line)
        {
            if (this._lastRowAdded == -1)
            {
                this.Width = line.Length;
            }
            this._lastRowAdded++;
            this._terrainInput[this._lastRowAdded] = line;

            return this;
        }

        public TerrainItem GetPosition(int x, int y)
        {
            return this._terrainActive[x, y];
        }

        public TreeSlope SetPosition(int x, int y, TerrainItem item)
        {
            this._terrainActive[x, y] = item;
            return this;
        }

        public TreeSlope CompleteSetup()
        {
            return this.Reset();
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    sb.Append(TerrainCharMapping.ConvertTo(this._terrainActive[i, j]));
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
