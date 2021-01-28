using System;
using Advent2020.Input;
using Advent2020.Core;
using Advent2020.Output;
using Advent2020.Models;

namespace Advent2020
{
    class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        static void Main(string[] args)
        {
            FormattedOutput.PrintOpening();
            ProgramRuntime runtime = new();
            runtime.RunOnce();
            FormattedOutput.PrintClosing(runtime.FinalAnswers, new ExpectedAnswers());
        }
    }
#pragma warning restore IDE0060 // Remove unused parameter

    class ProgramRuntime
    {
        public Answers FinalAnswers = new();

        public void RunOnce()
        {
            this.RunSolution(HardCodedConfig.TestInputFilePath, isTest: true, runSolution2: HardCodedConfig.RunChallenge2);
            if (!HardCodedConfig.TestInputOnly)
            {
                this.RunSolution(HardCodedConfig.MainInputFilePath, isTest: false, runSolution2: HardCodedConfig.RunChallenge2);
            }
        }

        public void RunSolution(string filepath, bool isTest, bool runSolution2)
        {
            FormattedOutput.PrintPhase(phaseName: "Challenge 1", isTest: isTest);
            var input = new FormattedInput(filepath);
            FormattedOutput.PrintInputs(HardCodedConfig.TestInputFilePath, input);

            var results1 = new Solution1();
            results1.Calc(input.TerrainFromInput, ExtraInput.MovementVector_Solution1_Test1);
            this.FinalAnswers.SetAnswer(value: results1.Answer, isTestAnswer: isTest, isAnswer2: false);
            FormattedOutput.PrintResults(calcResults: results1, isTest: isTest);

            if (runSolution2)
            {
                FormattedOutput.PrintPhase(phaseName: "Challenge 2", isTest: isTest);
                var results2 = new Solution2();
//                results2.Calc(input.TerrainFromInput);
                this.FinalAnswers.SetAnswer(value: results2.Answer, isTestAnswer: isTest, isAnswer2: true);
                FormattedOutput.PrintResults(calcResults: results2, isTest: isTest);
            }
        }
    }
}
