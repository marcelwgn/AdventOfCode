using System;
using System.Diagnostics;
using AdventOfCode.Common;
using AdventOfCode.Year2022.Solutions;

namespace AdventOfCode.Year2022
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var rawData = ReadUtils.ReadDataFromFile("data.txt");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = Day03.SecondProblem(rawData);
            stopWatch.Stop();
            Console.WriteLine(result);
            Console.WriteLine(stopWatch.Elapsed.ToString());

            // Fail so debugger stops and we get a chance to view the result.
            Debug.Fail(null);
        }
    }
}