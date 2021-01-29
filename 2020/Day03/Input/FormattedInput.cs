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
        public TreeSlope TerrainFromInput { get; private set; }
        public string InputFilePath { get; private set; }

#pragma warning disable CS8618 // False-positive Non-nullable
        public FormattedInput(string inputFilePath)
#pragma warning restore CS8618
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
            TreeSlope slope = new TreeSlope(this.RawInput.Count);
            foreach (string line in this.RawInput)
            {
                slope.AddLine(
                    line.Select(lineChar => TerrainCharMapping.ConvertFrom(lineChar)).ToArray()
                );
            }
            this.TerrainFromInput = slope.CompleteSetup();
            return this;
        }
    }
}
