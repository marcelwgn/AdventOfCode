using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day15
    {
        public static int Algorithm(int[] data, int turns)
        {
            var spokenNumbers = new Dictionary<int, (int secondToLast, int last)>((int)Math.Log10(turns));

            var number = data[0];
            spokenNumbers[number] = (-1, 1);
            for (int i = 1; i < turns; i++)
            {
                if (i < data.Length)
                {
                    number = SpeakNumber(data[i], i);
                }
                else
                {
                    number = SpeakNumber(number, i);
                }
            }

            return number;

            int SpeakNumber(int number, int turn)
            {
                if (spokenNumbers.ContainsKey(number))
                {
                    if (spokenNumbers[number].secondToLast == -1)
                    {
                        spokenNumbers[0] = (spokenNumbers[0].last, turn + 1);
                        return 0;
                    }
                    else
                    {
                        var nextNumber = spokenNumbers[number].last - spokenNumbers[number].secondToLast;
                        if (!spokenNumbers.ContainsKey(nextNumber))
                        {
                            spokenNumbers[nextNumber] = (-1, turn + 1);
                        }
                        else
                        {
                            spokenNumbers[nextNumber] = (spokenNumbers[nextNumber].last, turn + 1);
                        }
                        return nextNumber;
                    }
                }
                else
                {
                    spokenNumbers[number] = (-1, turn + 1);
                    return number;
                }
            }
        }
    }
}
