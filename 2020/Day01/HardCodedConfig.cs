using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2020
{
    static class HardCodedConfig
    {
        public static string AdventDay => "Day01";
        public static bool TestInputOnly => false;
        public static bool Challenge2 => true;
        public static string ChallengeNumber => Challenge2 ? "02" : "01";

        public static string MainInputFileName => "input.txt";
        public static string MainInputFilePath { get; } = Path.Join(AppContext.BaseDirectory, "Input", MainInputFileName);
        public static string TestInputFileName => "test-input.txt";
        public static string TestInputFilePath { get; } = Path.Join(AppContext.BaseDirectory, "Input", TestInputFileName);

        public static string InputFilePath => TestInputOnly ? TestInputFilePath : MainInputFilePath;
    }
}
