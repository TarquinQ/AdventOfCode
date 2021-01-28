using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent2020.Core;
using Advent2020.Input;
using Advent2020.Models;

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
                message += @"[INFO] Processing Test Input";
            }
            else
            {
                message += @"[INFO] Processing Test _and_ Main Input";
            }
            PrintMessageInColour(message, ConsoleColor.Cyan, true);
        }

        public static void PrintClosing(Answers answers, ExpectedAnswers expected)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-- Final Results: ");
            Console.WriteLine("--");
            Console.Write($"-- TEST Challenge 01:  "); PrintAnswer(answers.AnswerTest1, expected.AnswerTest1);
            if (answers.AnswerFound1)
            {
                Console.Write($"--      Challenge 01:  "); PrintAnswer(answers.Answer1, expected.Answer1);
            }
            if (answers.AnswerFoundTest2)
            {
                Console.Write($"-- TEST Challenge 02:  "); PrintAnswer(answers.AnswerTest2, expected.AnswerTest2);
            }
            if (answers.AnswerFound2)
            {
                Console.Write($"--      Challenge 02:  "); PrintAnswer(answers.Answer2, expected.Answer2);
            }
            Console.WriteLine("--");
            Console.WriteLine("--------------------------------------");
        }

        public static void PrintInputs(string filename, FormattedInput input)
        {
            Console.WriteLine($@"
--------------------------------------
[INFO] Processed InputFile      : {filename}
[INFO] Number of records read in: {input.RawInput.Count}
--------------------------------------");
        }

        public static void PrintResults(Solution1 calcResults, bool isTest = false)
        {
            Solution2? results = calcResults as Solution2;
            if (results is null)
            {
                PrintResults1(calcResults, isTest);
            }
            else
            {
                PrintResults2(results, isTest);
            }
        }

        private static void PrintResults1(Solution1 calcResults, bool isTest)
        {

            string testMessage = isTest ? "*** TEST ***  " : String.Empty;
            Console.WriteLine($@"
--------------------------------------");
            PrintMessageInColour($"[INFO] {testMessage}Results of Challenge 01:", ConsoleColor.Cyan, true);
            Console.WriteLine($@"[INFO] {testMessage}CountValid: {calcResults.CountTrees}
--------------------------------------");
        }

        private static void PrintResults2(Solution2 calcResults, bool isTest)
        {
            string testMessage = isTest ? "*** TEST ***  " : String.Empty;
            Console.WriteLine($@"
--------------------------------------");
            PrintMessageInColour($"[INFO] {testMessage}Results of Challenge 02:", ConsoleColor.Cyan, true);
            Console.WriteLine($@"[INFO] {testMessage}CountValid: {calcResults.CountTrees}
--------------------------------------");
        }

        public static void PrintPhase(string phaseName, bool isTest, ConsoleColor colour = ConsoleColor.Blue)
        {
            string testMessage = isTest ? "*** TEST ***  " : String.Empty;
            string message = $"Now commencing to calculate Challenge: {phaseName} {testMessage}";
            PrintMessageInColour(message: message, colour: colour, trailingNewLine: false);
        }

        public static void PrintLineBreak(int breaks = 1)
        {
            for (int i = 0; i < breaks; i++)
            {
                Console.WriteLine();
            }
        }

        public static void PrintMessageInColour(string message, ConsoleColor colour, bool trailingNewLine = false)
        {
            ConsoleColor originalColour = Console.ForegroundColor;
            Console.ForegroundColor = colour;
            Console.Write(message);
            Console.ForegroundColor = originalColour;
            if (trailingNewLine)
            {
                Console.WriteLine();
            }
        }

        private static void PrintAnswer(int answer, int expected)
        {
            string message;
            ConsoleColor colour;
            if (answer == expected)
            {
                message = $"Correct: {answer}";
                colour = ConsoleColor.Green;
            }
            else if (answer > expected)
            {
                message = $"Too High: {answer} -- Expected: {expected}";
                colour = ConsoleColor.Yellow;
            }
            else
            {
                message = $"Too Low: {answer} -- Expected: {expected}";
                colour = ConsoleColor.Red;
            }
            PrintMessageInColour(message, colour, true);
        }
    }
}
