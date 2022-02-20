using AdventOfCode.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day18
    {
        public static bool[] Convert(string[] data) => data[0].Select(x => x == '^').ToArray();

        public static int FirstProblem(bool[] data)
        {
            return CountSaveTiles(data, 39);
        }

        public static int SecondProblem(bool[] data)
        {
            return CountSaveTiles(data, 399999);
        }

        public static int CountSaveTiles(bool[] start, int iterations)
        {
            var saveTileCount = start.Where(x => !x).Count();
            for (int i = 0; i < iterations; i++)
            {
                start = GenerateNextRow(start);
                saveTileCount += start.Where(x => !x).Count();
            }
            return saveTileCount;
        }

        public static bool[] GenerateNextRow(bool[] input)
        {
            var result = new bool[input.Length];
            result[0] = input[1];
            for (int i = 1; i < input.Length - 1; i++)
            {
                result[i] = (!input[i - 1] && !input[i] && input[i + 1]) ||
                            (input[i - 1] && !input[i] && !input[i + 1]) ||
                            (!input[i - 1] && input[i] && input[i + 1]) ||
                            (input[i - 1] && input[i] && !input[i + 1]);
            }
            result[^1] = input[^2];
            return result;
        }
    }
}
