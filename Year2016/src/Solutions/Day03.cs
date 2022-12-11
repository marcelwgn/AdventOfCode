using AdventOfCode.Common;
using System.Linq;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day03
    {
        public static int[][] Convert(string[] data) => data.Select(x => x.Split(" ").Where(y => y != "").ToArray().ToIntArray()).ToArray();

        public static int FirstProblem(int[][] data)
        {
            return data.Where(IsValidTriangle).Count();
        }

        public static int SecondProblem(int[][] data)
        {
            var validCount = 0;
            for (var i = 0; i < data.Length - 2; i += 3)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    if (IsValidTriangle(new int[] { data[i][j], data[i + 1][j], data[i + 2][j] }))
                    {
                        validCount++;
                    }
                }
            }
            return validCount;
        }

        private static bool IsValidTriangle(int[] data)
        {
            return data[0] + data[1] > data[2] && data[1] + data[2] > data[0] && data[2] + data[0] > data[1];
        }

    }
}
