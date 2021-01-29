using Advent2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Input
{
    public static class ExtraInput
    {
        public static MovementVector MovementVector_Solution1_Test1 { get; } = new(3,1);
        public static MovementVector[] MovementVectors_Solution2 { get; } = new[] {
            new MovementVector(1,1),
            new MovementVector(3,1),
            new MovementVector(5,1),
            new MovementVector(7,1),
            new MovementVector(1,2),
        };
    }
}
