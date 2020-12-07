using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Input
{
    class FormattedInput
    {
        public ICollection<string> RawInput { get; private set; } = new List<string>();
        public ICollection<int> ParsedInput { get; private set; } = new List<int>();
        public string InputFilePath { get; private set; }

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
                ParsedInput.Add(Int32.Parse(line));
            }
            return this;
        }
    }
}
