using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public enum TerrainItem
    {
        Empty = 0,
        VisitedEmpty = 1,
        VisitedNonEmpty = 2,
        Tree = 3
    }

    public static class TerrainCharMapping
    {
        private static readonly Dictionary<TerrainItem, char> _outputCharMap;
        private static readonly Dictionary<char, TerrainItem> _inputCharMap;

        static TerrainCharMapping()
        {
            _inputCharMap = new Dictionary<char, TerrainItem>();
            _outputCharMap = new Dictionary<TerrainItem, char>()
            {
                [TerrainItem.Tree] = '#',
                [TerrainItem.Empty] = '.',
                [TerrainItem.VisitedEmpty] = 'X',
                [TerrainItem.VisitedNonEmpty] = 'Y',
            };
            foreach (var entry in _outputCharMap)
            {
                _inputCharMap[entry.Value] = entry.Key;
            }
        }

        public static TerrainItem ConvertFrom(char symbol)
        {
            return _inputCharMap.ContainsKey(symbol) ? _inputCharMap[symbol]: TerrainItem.Empty;
        }

        public static char ConvertTo(TerrainItem symbol)
        {
            return _outputCharMap[symbol];
        }
    }
}
