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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = Day15.Algorithm(rawData, 30000000);
            stopWatch.Stop();
            Console.WriteLine(result);
            Console.WriteLine(stopWatch.Elapsed.ToString());

            // Fail so debugger stops and we get a chance to view the result.
            Debug.Fail(null);
        }
    }
}