using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Advent2020.Helpers;

namespace Advent2020
{
    public static class HardCodedConfig
    {
        public static string AdventDay => "Day03";
        public static bool TestInputOnly => false;
        public static bool RunChallenge2 => true;

        public static LogLevel LogLevel => LogLevel.Debug;
        public static string ChallengeNumber => RunChallenge2 ? "02" : "01";

        public static string MainInputFileName => "input.txt";
        public static string MainInputFilePath { get; } = Path.Join(AppContext.BaseDirectory, "Input", MainInputFileName);
        public static string TestInputFileName => "test-input.txt";
        public static string TestInputFilePath { get; } = Path.Join(AppContext.BaseDirectory, "Input", TestInputFileName);

        public static string InputFilePath => TestInputOnly ? TestInputFilePath : MainInputFilePath;
    }
}
