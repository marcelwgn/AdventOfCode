using System;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day09
    {
        public static long FirstProblem(long[] data)
        {
            for (int i = 25; i < data.Length; i++)
            {
                if (!HasSum(data[(i - 25)..i], data[i]))
                {
                    return data[i];
                }
            }

            return 0;

            bool HasSum(long[] range, long number)
            {
                for (int i = 0; i < range.Length; i++)
                {
                    for (int j = 0; j < range.Length; j++)
                    {
                        if (range[i] + range[j] == number)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public static long SecondProblem(long[] data)
        {
            var invalidNumber = FirstProblem(data);
            for (int i = 0; i < data.Length; i++)
            {
                var smallest = data[i];
                var largest = data[i];
                var endIndex = i;
                var sum = data[i];
                while (sum < invalidNumber)
                {
                    endIndex++;
                    sum += data[endIndex];
                    smallest = Math.Min(smallest, data[endIndex]);
                    largest = Math.Max(largest, data[endIndex]);
                }
                if (sum == invalidNumber)
                {
                    return smallest + largest;
                }
            }

            return 0;
        }
    }
}
