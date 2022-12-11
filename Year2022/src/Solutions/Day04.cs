using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2022.Solutions
{
    public static class Day04
    {
        public class Range
        {
            public int Min { get; set; }
            public int Max { get; set; }

            public bool ContainsRange(Range range)
            {
                return Min <= range.Min && Max >= range.Max;
            }

            public bool Overlaps(Range range)
            {
                return (range.Min <= Max && range.Min >= Min) || (range.Max <= Max && range.Max >= Min);
            }
        }

        public static IEnumerable<Tuple<Range, Range>> Convert(string[] items)
        {
            {
                var ranges = new List<Tuple<Range, Range>>();
                foreach (var item in items)
                {
                    var split = item.Split(",");
                    var firstRange = new Range()
                    {
                        Min = int.Parse(split[0].Split("-")[0]),
                        Max = int.Parse(split[0].Split("-")[1])
                    };

                    var secondRange = new Range()
                    {
                        Min = int.Parse(split[1].Split("-")[0]),
                        Max = int.Parse(split[1].Split("-")[1])
                    };
                    ranges.Add(Tuple.Create(firstRange, secondRange));
                }
                return ranges;
            }
        }

        public static long FirstProblem(IEnumerable<Tuple<Range, Range>> items)
        {
            long score = 0;
            foreach (var item in items)
            {
                if (item.Item1.ContainsRange(item.Item2) ||
                    item.Item2.ContainsRange(item.Item1))
                {
                    score++;
                }
            }
            return score;
        }
        public static long SecondProblem(IEnumerable<Tuple<Range, Range>> items)
        {
            long score = 0;
            foreach (var item in items)
            {
                if (item.Item1.Overlaps(item.Item2) ||
                    item.Item2.Overlaps(item.Item1))
                {
                    score++;
                }
            }
            return score;
        }

    }
}
