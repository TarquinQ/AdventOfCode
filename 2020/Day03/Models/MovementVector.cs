using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public class MovementVector
    {
        public int Move_x { get; set; }
        public int Move_y { get; set; }

        public MovementVector ( ) {}

        public MovementVector (int x, int y)
        {
            this.Move_x = x;
            this.Move_y = y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", this.Move_x, this.Move_y);
        }
    }
}
