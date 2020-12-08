using System;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day12
    {

        public const int offset = 100;

        public static Tuple<bool[], PatternMatcher[]> Convert(string[] data)
        {
            bool[] flowers = new bool[300];
            for (int i = 0; i < flowers.Length; i++)
            {
                flowers[i] = new bool();
            }

            string line = data[0][14..];
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    flowers[i + offset] = true;
                }
            }

            PatternMatcher[] patterns = new PatternMatcher[data.Length - 2];

            for (int i = 0; i < data.Length - 2; i++)
            {
                patterns[i] = new PatternMatcher(data[i + 2]);
            }

            return new Tuple<bool[], PatternMatcher[]>(flowers, patterns);
        }

        public static bool[] GetNewFlowerArray(bool[] flowers, PatternMatcher[] patterns)
        {
            bool[] newArray = new bool[flowers.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = false;
            }


            for (int i = 2; i < flowers.Length - 2; i++)
            {
                bool first = flowers[i - 2];
                bool second = flowers[i - 1];
                bool third = flowers[i];
                bool fourth = flowers[i + 1];
                bool fifth = flowers[i + 2];

                bool result = false;
                for (int j = 0; j < patterns.Length; j++)
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
            bool[] flowers = data.Item1;
            PatternMatcher[] patterns = data.Item2;
            Print(flowers, 90, 300);
            for (int repititions = 0; repititions < 20; repititions++)
            {
                flowers = GetNewFlowerArray(flowers, patterns);
                Print(flowers, 90, 300);
            }

            int sum = 0;
            for (int i = 0; i < flowers.Length; i++)
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
            bool[] flowers = new bool[2147483580];

            int offsetIntern = 250000000;

            for (int i = 0; i < data.Item1.Length; i++)
            {
                flowers[i + offsetIntern] = data.Item1[i];
            }

            PatternMatcher[] patterns = data.Item2;
            for (long repititions = 0; repititions < 5000000000; repititions++)
            {
                flowers = GetNewFlowerArray(flowers, patterns);
            }

            int sum = 0;
            for (int i = 0; i < flowers.Length; i++)
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
            for (int i = offset; i < max; i++)
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
#pragma warning disable CA1819
        public bool[] Values { get; private set; } = new bool[5];
#pragma warning restore CA1819
        public bool Result { get; private set; } = false;

        public PatternMatcher(string label)
        {
            for (int i = 0; i < Values.Length; i++)
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
            for (int i = 2; i < flowers.Length - 2; i++)
            {
                bool matches = Matches(flowers[i - 2],
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
