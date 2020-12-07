using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2020.Core
{
    public class Solution1
    {
        public virtual bool SolutionFound { get; protected set; } = false;
        public int Number1 { get; protected set; } = 0;
        public int Number2 { get; protected set; } = 0;
        public virtual int Multiplied => this.Number1 * this.Number2;
        public virtual int Sum => this.Number1 + this.Number2;

        public virtual int RequiredTotal => 2020;

        public virtual Solution1 Calc(ICollection<int> inputNumbers)
        {
            List<int> checkedNumbers2 = new();
            foreach (int number in inputNumbers)
            {
                foreach (int checkedNum in checkedNumbers2)
                {
                    if (number + checkedNum == this.RequiredTotal)
                    {
                        this.Number1 = number;
                        this.Number2 = checkedNum;
                        this.SolutionFound = true;
                        break;
                    }
                }
                checkedNumbers2.Add(number);
                if (this.SolutionFound) { break; }
            }
            return this;
        }
    }
    
    public class Solution2 : Solution1
    {
        public int Number3 { get; protected set; } = 0;
        public override int Multiplied => this.Number1 * this.Number2 * this.Number3;
        public override int Sum => this.Number1 + this.Number2 + this.Number3;

        public override Solution2 Calc(ICollection<int> inputNumbers)
        {
            List<int> checkedNumbers2 = new();
            List<int> checkedNumbers3 = new();
            foreach (int number in inputNumbers)
            {
                foreach (int checkedNum2 in checkedNumbers2)
                {
                    foreach (int checkedNum3 in checkedNumbers3)
                    {
                        if (number + checkedNum2 + checkedNum3 == this.RequiredTotal)
                        {
                            this.Number1 = number;
                            this.Number2 = checkedNum2;
                            this.Number3 = checkedNum3;
                            this.SolutionFound = true;
                            break;
                        }
                    }
                    checkedNumbers3.Add(number);
                    if (this.SolutionFound) { break; }
                }
                checkedNumbers2.Add(number);
                if (this.SolutionFound) { break; }
            }
            return this;
        }
    }
}
