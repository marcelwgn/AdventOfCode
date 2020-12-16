using System.Collections.Generic;
using AdventOfCode.SharedUtils;

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
            int sum = 0;
            foreach (int s in data)
            {
                sum += s;
            }
            return sum;
        }

        public static int SecondProblem(int[] data)
        {
            List<int> calcedFreqs = new List<int>();
            bool freqDouble = false;

            int index = 0;
            int sum = 0;

            int dataSize = data.Length;
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
