using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day15
    {

        public static int Algorithm(int[] data, int turns)
        {
            var spokenNumbers = new Dictionary<int, Tuple<int, int>>();

            var number = data[0];
            spokenNumbers[number] = new Tuple<int, int>(-1, 1);
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
                    if (spokenNumbers[number].Item1 == -1)
                    {
                        spokenNumbers[0] = new Tuple<int, int>(spokenNumbers[0].Item2, turn + 1);
                        return 0;
                    }
                    else
                    {
                        var nextNumber = spokenNumbers[number].Item2 - spokenNumbers[number].Item1;
                        if (!spokenNumbers.ContainsKey(nextNumber))
                        {
                            spokenNumbers[nextNumber] = new Tuple<int, int>(-1, turn + 1);
                        }
                        else
                        {
                            spokenNumbers[nextNumber] = new Tuple<int, int>(spokenNumbers[nextNumber].Item2, turn + 1);
                        }
                        return nextNumber;
                    }
                }
                else
                {
                    spokenNumbers[number] = new Tuple<int, int>(-1, turn + 1);
                    return number;
                }
            }
        }
    }
}
