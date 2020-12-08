
using System.Linq;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day02
    {

        public static int FirstProblem(string[] strings)
        {
            return strings.AsParallel().Count(s => IsValidFirstProblem(s));
        }

        public static int SecondProblem(string[] strings)
        {
            return strings.AsParallel().Count(s => IsValidSecondProblem(s));
        }

        static bool IsValidFirstProblem(string line)
        {
            var split = line.Split(" ");
            var splitDash = split[0].Split("-");
            var lower = int.Parse(splitDash[0]);
            var upper = int.Parse(splitDash[1]);

            var character = split[1][0];

            var count = split[2].Count(c => c == character);
            return lower <= count && count <= upper;
        }
        static bool IsValidSecondProblem(string line)
        {
            var split = line.Split(" ");
            var splitDash = split[0].Split("-");
            var lower = int.Parse(splitDash[0]) - 1;
            var upper = int.Parse(splitDash[1]) - 1;

            var character = split[1][0];

            return split[2][lower] == character && split[2][upper] != character ||
                split[2][lower] != character && split[2][upper] == character;
        }
    }
}
