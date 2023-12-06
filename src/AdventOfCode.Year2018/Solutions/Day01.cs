using AdventOfCode.Common;
using System.Collections.Generic;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day01
    {
        public static int[] Convert(string[] data)
        {
            return data.ToIntArray();
        }

        public static int FirstProblem(int[] data)
        {
            var sum = 0;
            foreach (var s in data)
            {
                sum += s;
            }
            return sum;
        }

        public static int SecondProblem(int[] data)
        {
            var calcedFreqs = new List<int>();
            var freqDouble = false;

            var index = 0;
            var sum = 0;

            var dataSize = data.Length;
            while (!freqDouble)
            {
                //Already found
                if (calcedFreqs.Contains(sum))
                {
                    break;
                }

                calcedFreqs.Add(sum);
                sum += data[index];
                index = (index + 1) % dataSize;
            }
            return sum;
        }
    }
}
