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
            var rawData = ReadUtils.ReadDataFromFile("data.txt");
            var result = Day13.SecondProblem(rawData[1]);
            Console.WriteLine(result);
            Debug.WriteLine(result);

            // Fail so debugger stops and we get a chance to view the result.
            Debug.Fail(null);
        }
    }
}