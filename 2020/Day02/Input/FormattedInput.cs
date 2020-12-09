using Advent2020.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2020.Input
{
    public class FormattedInput
    {
        public ICollection<string> RawInput { get; private set; } = new List<string>();
        public ICollection<InputtedPolicyLine> ParsedInput { get; private set; } = new List<InputtedPolicyLine>();
        public string InputFilePath { get; private set; }

        public string ValidPasswordLineRegEx { get; private set; } = @"^\b([0-9]+)\b-\b([0-9]+)\b \b([a-z])\b: \b([a-z]+)$";

        public FormattedInput(string inputFilePath)
        {
            this.InputFilePath = inputFilePath;
            this.ReadInput()
                .ParseInput();
        }

        public FormattedInput ReadInput()
        {
            this.RawInput = File.ReadAllLines(this.InputFilePath);
            return this;
        }

        public FormattedInput ParseInput()
        {
            foreach (string line in this.RawInput)
            {
                Match match = Regex.Match(line, this.ValidPasswordLineRegEx);
                if (!match.Success)
                {
                    Console.WriteLine($"[NOTE] Ignoring invalid Input line: {line.Trim()}");
                    continue;
                }
                PasswordPolicy1 p = new PasswordPolicy1(
                    character: Char.Parse(match.Groups[3].Value),
                    min: Int32.Parse(match.Groups[1].Value),
                    max: Int32.Parse(match.Groups[2].Value)
                );
                InputtedPolicyLine pl = new InputtedPolicyLine(policy: p, password: match.Groups[4].Value);
                this.ParsedInput.Add(pl);
            }
            return this;
        }
    }
}
