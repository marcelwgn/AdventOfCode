using System;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day12
    {

        public const int offset = 100;

        public static Tuple<bool[], PatternMatcher[]> Convert(string[] data)
        {
            var flowers = new bool[300];
            for (var i = 0; i < flowers.Length; i++)
            {
                flowers[i] = new bool();
            }

            var line = data[0][14..];
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    flowers[i + offset] = true;
                }
            }

            var patterns = new PatternMatcher[data.Length - 2];

            for (var i = 0; i < data.Length - 2; i++)
            {
                patterns[i] = new PatternMatcher(data[i + 2]);
            }

            return new Tuple<bool[], PatternMatcher[]>(flowers, patterns);
        }

        public static bool[] GetNewFlowerArray(bool[] flowers, PatternMatcher[] patterns)
        {
            var newArray = new bool[flowers.Length];
            for (var i = 0; i < newArray.Length; i++)
            {
                newArray[i] = false;
            }

            for (var i = 2; i < flowers.Length - 2; i++)
            {
                var first = flowers[i - 2];
                var second = flowers[i - 1];
                var third = flowers[i];
                var fourth = flowers[i + 1];
                var fifth = flowers[i + 2];

                var result = false;
                for (var j = 0; j < patterns.Length; j++)
                {
                    if (patterns[j].Matches(first, second, third, fourth, fifth))
                    {
                        result = patterns[j].Result;
                    }
                }
                newArray[i] = result;
            }

            return newArray;
        }

        public static int FirstProblem(Tuple<bool[], PatternMatcher[]> data)
        {
            var flowers = data.Item1;
            var patterns = data.Item2;
            Print(flowers, 90, 300);
            for (var repititions = 0; repititions < 20; repititions++)
            {
                flowers = GetNewFlowerArray(flowers, patterns);
                Print(flowers, 90, 300);
            }

            var sum = 0;
            for (var i = 0; i < flowers.Length; i++)
            {
                if (flowers[i])
                {
                    sum += i - offset - 1;
                }
            }

            return sum;
        }

        public static int SecondProblem(Tuple<bool[], PatternMatcher[]> data)
        {
            var flowers = new bool[2147483580];

            var offsetIntern = 250000000;

            for (var i = 0; i < data.Item1.Length; i++)
            {
                flowers[i + offsetIntern] = data.Item1[i];
            }

            var patterns = data.Item2;
            for (long repititions = 0; repititions < 5000000000; repititions++)
            {
                flowers = GetNewFlowerArray(flowers, patterns);
            }

            var sum = 0;
            for (var i = 0; i < flowers.Length; i++)
            {
                if (flowers[i])
                {
                    sum += i - offset - 1;
                }
            }

            return sum;
        }

        public static void Print(bool[] flowers, int offset, int max)
        {
            Console.WriteLine();
            for (var i = offset; i < max; i++)
            {
                if (flowers[i])
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }

    public class PatternMatcher
    {
        public bool[] Values { get; private set; } = new bool[5];
		public bool Result { get; private set; }

		public PatternMatcher(string label)
        {
            for (var i = 0; i < Values.Length; i++)
            {
                if (label[i] == '#')
                {
                    Values[i] = true;
                }
            }

            if (label[9] == '#')
            {
                Result = true;
            }

        }

        public bool Matches(bool first, bool second, bool third, bool fourth, bool fifth)
        {
            if (first == Values[0] && second == Values[1] && third == Values[2] && fourth == Values[3] && fifth == Values[4])
            {
                return true;
            }
            return false;
        }

        public void UpdatePositions(bool[] flowers)
        {
            for (var i = 2; i < flowers.Length - 2; i++)
            {
                var matches = Matches(flowers[i - 2],
                flowers[i - 1], flowers[i]
                , flowers[i + 1], flowers[i + 2]);
                if (matches)
                {
                    flowers[i] = Result;
                }

            }
        }

    }
}
