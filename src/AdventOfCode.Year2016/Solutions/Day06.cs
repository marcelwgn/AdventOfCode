﻿using AdventOfCode.Common.Extensions;
using System.Linq;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day06
    {
        public static string FirstProblem(string[] data)
        {
            var result = "";
            for (var i = 0; i < data[0].Length; i++)
            {
                result += data.GetColumn(i).GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            }
            return result;
        }

        public static string SecondProblem(string[] data)
        {
            var result = "";
            for (var i = 0; i < data[0].Length; i++)
            {
                result += data.GetColumn(i).GroupBy(x => x).OrderByDescending(x => x.Count()).Last().Key;
            }
            return result;
        }
    }
}
