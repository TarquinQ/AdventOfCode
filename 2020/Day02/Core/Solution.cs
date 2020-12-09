using Advent2020.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2020.Core
{
    public class Solution1
    {
        public int Answer { get; protected set; } = 0;
        public int CountValid { get; protected set; } = 0;

        public virtual Solution1 Calc(ICollection<InputtedPolicyLine> inputLines)
        {
            foreach (var p in inputLines)
            {
                bool isValid = p.IsValid1();
                this.CountValid += isValid ? 1 : 0;
            }
            this.Answer = this.CountValid;
            return this;
        }
    }
    
    public class Solution2 : Solution1
    {
        public override Solution2 Calc(ICollection<InputtedPolicyLine> inputLines)
        {
            foreach (var p in inputLines)
            {
                bool isValid = p.IsValid2();
                this.CountValid += isValid ? 1 : 0;
            }
            this.Answer = this.CountValid;
            return this;
        }
    }
}
