using System;
using System.Diagnostics;
using AdventOfCode.SharedUtils;
using AdventOfCode.Year2020.Solutions;
namespace AdventOfCode.Year2020
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            var rawData = ReadUtils.ReadIntDataFromFileSingleLine("data.txt");
            var result = Day15.Algorithm(rawData, 30000000);
            Console.WriteLine(result);
            Debug.WriteLine(result);

            // Fail so debugger stops and we get a chance to view the result.
            Debug.Fail(null);
        }
    }
}