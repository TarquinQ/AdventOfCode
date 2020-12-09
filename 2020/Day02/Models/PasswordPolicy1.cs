using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public class PasswordPolicy1
    {
        public char Character { get; set; }
        public int Min { get; set; } = int.MaxValue;
        public int Max { get; set; } = -1;

        public PasswordPolicy1(char character)
        {
            this.Character = character;
        }

        public PasswordPolicy1(char character, int min, int max)
        {
            this.Character = character;
            this.Min = min;
            this.Max = max;
        }

        public bool ValidateInput(string input)
        {
            int count = input.Count(x => x == this.Character);
            return (count >= this.Min) && (count <= this.Max);
        }
    }
}
