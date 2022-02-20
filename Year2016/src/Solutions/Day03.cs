using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day03
    {
        public static int[][] Convert(string[] data) => data.Select(x => x.Split(" ").Where(y => y != "").ToArray().ToIntArray()).ToArray();

        public static int FirstProblem(int[][] data)
        {
            return data.Where(x => IsValidTriangle(x)).Count();
        }

        public static int SecondProblem(int[][] data)
        {
            int validCount = 0;
            for (int i = 0; i < data.Length - 2; i += 3)
            {
                for (int j = 0; j < data[i].Length; j++)
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
