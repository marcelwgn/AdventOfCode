using AdventOfCode.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day19
    {
        /// <summary>
        /// This is the Josephus problem, we are using the algorithm for it.
        /// </summary>
        public static int FirstProblem(string[] data)
        {
            int num = int.Parse(data[0]);
            int maxPowerOf2 = (int)Math.Log2(num);
            int remainder = num - (int)Math.Pow(2, maxPowerOf2);
            return 2 * remainder + 1;
        }

        public static int SecondProblem(string[] data)
        {
            var num = int.Parse(data[0]);
            var currentIndex = 2;
            var currentNumber = 5;
            while (currentNumber < num)
            {
                if (currentNumber % 2 == 0)
                {
                    if (currentIndex >= (currentNumber / 2))
                    {
                        currentIndex += 2;
                    }
                    else
                    {
                        currentIndex++;
                    }
                }
                else
                {
                    if (currentIndex >= (currentNumber / 2) + 1)
                    {
                        currentIndex += 2;
                    }
                    else
                    {
                        currentIndex++;
                    }
                }
                if (currentIndex > currentNumber)
                {
                    if(currentIndex == currentNumber + 1)
                    {
                        currentIndex = currentNumber;
                    }
                    else
                    {
                        currentIndex = 1;
                    }
                }
                currentNumber++;
            }
            return currentIndex;
        }
    }
}
