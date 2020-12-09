using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public class PasswordPolicy2
    {
        public char Character { get; set; }
        public int Pos1 { get; set; } = 0;
        public int Pos2 { get; set; } = 0;

        public PasswordPolicy2(char character)
        {
            this.Character = character;
        }

        public PasswordPolicy2(char character, int min, int max)
        {
            this.Character = character;
            this.Pos1 = min;
            this.Pos2 = max;
        }

        public PasswordPolicy2(PasswordPolicy1 p)
        {
            this.Character = p.Character;
            this.Pos1 = p.Min;
            this.Pos2 = p.Max;
        }

        public bool ValidateInput(string input)
        {
            if (input.Length < this.Pos2 -1)
            {
                return false;
            }
            return (input[this.Pos1-1] == this.Character) ^ (input[this.Pos2-1] == this.Character);
        }
    }
}
