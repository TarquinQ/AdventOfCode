using System;
using Advent2020.Input;
using Advent2020.Core;
using Advent2020.Output;

namespace Advent2020
{
    class Program
    {
        static void Main(string[] args)
        {
            FormattedOutput.PrintOpening();

            var input = new FormattedInput(HardCodedConfig.InputFilePath);
            FormattedOutput.PrintInputs(input);

            var results1 = new Solution1();
            results1.Calc(input.ParsedInput);
            FormattedOutput.PrintResults(results1);

            if (HardCodedConfig.Challenge2)
            {
                var results2 = new Solution2();
                results2.Calc(input.ParsedInput);
                FormattedOutput.PrintResults(results2);
            }
        }
    }
}
