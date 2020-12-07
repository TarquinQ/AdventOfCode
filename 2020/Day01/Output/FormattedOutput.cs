using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent2020.Core;
using Advent2020.Input;

namespace Advent2020.Output
{
    class FormattedOutput
    {

        public static void PrintOpening()
        {
            string message = $@"
[INFO] Advent of Code 2020!
[INFO] {HardCodedConfig.AdventDay}, Challenge {HardCodedConfig.ChallengeNumber}
";
            if (HardCodedConfig.TestInputOnly)
            {
                message += @"[INFO] Processing Test Input
";
            }
            else
            {
                message += @"[INFO] Processing Main Input
";
            }
            Console.WriteLine(message);
        }

        public static void PrintInputs(FormattedInput input)
        {
            Console.WriteLine($@"
[INFO] Number of records read in: {input.RawInput.Count}
");
        }

        public static void PrintResults(Solution1 calcResults)
        {
            Solution2? results = calcResults as Solution2;
            if (results is null)
            {
                PrintResults1(calcResults);
            }
            else
            {
                PrintResults2(results);
            }
        }

        private static void PrintResults1(Solution1 calcResults)
        {
            Console.WriteLine($@"
--------------------------------------
[INFO] Results of Challenge 01:
--------------------------------------
[INFO] Number 1: {calcResults.Number1}
[INFO] Number 1: {calcResults.Number2}
[INFO] Sum     : {calcResults.Sum}
[INFO] Multiply: {calcResults.Multiplied}
--------------------------------------

");
        }

        private static void PrintResults2(Solution2 calcResults)
        {
            Console.WriteLine($@"
--------------------------------------
[INFO] Results of Challenge 02:
--------------------------------------
[INFO] Number 1: {calcResults.Number1}
[INFO] Number 1: {calcResults.Number2}
[INFO] Number 1: {calcResults.Number3}
[INFO] Sum     : {calcResults.Sum}
[INFO] Multiply: {calcResults.Multiplied}
--------------------------------------

");
        }
    }
}
