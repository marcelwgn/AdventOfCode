using System.Collections.Generic;

namespace AdventOfCode.Year2022.Solutions
{
    public static class Day01
    {
        public static long FirstProblem(string[] numbers)
        {
            var sortedNumbers = ParseData(numbers);
            return sortedNumbers.Max;
        }
        public static long SecondProblem(string[] numbers)
        {
            var sortedNumbers = ParseData(numbers);
            var biggest = sortedNumbers.Max;
            sortedNumbers.Remove(sortedNumbers.Max);
            var secondBiggest = sortedNumbers.Max;
            sortedNumbers.Remove(sortedNumbers.Max);
            var thirdBiggest = sortedNumbers.Max;
            return biggest + secondBiggest + thirdBiggest;
        }

        private static SortedSet<long> ParseData(string[] numbers)
        {
            var sortedNumbers = new SortedSet<long>();
            var curNum = 0L;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != "")
                {
                    curNum += long.Parse(numbers[i]);
                }
                else
                {
                    sortedNumbers.Add(curNum);
                    curNum = 0;
                }
            }
            sortedNumbers.Add(curNum);

            return sortedNumbers;
        }

    }
}
