using System;
using System.Diagnostics;
using System.Linq;
using AdventOfCode.SharedUtils;
using AdventOfCode.Year2019.Solutions;

namespace AdventOfCode.Year2019
{
    class Program
    {
        static void Main(string[] _)
        {
            var rawData = ReadUtils.ReadDataFromFile("data.txt")[0].Split(",").Select(str => int.Parse(str)).ToArray();
            var result = Day02.SecondProblem(rawData);
            Console.WriteLine(result);
            Debug.WriteLine(result);

            // Fail so debugger stops and we get a chance to view the result.
            Debug.Fail(null);
        }
    }
}
