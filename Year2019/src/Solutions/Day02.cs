using System;

namespace AdventOfCode.Year2019.Solutions
{
    public static class Day02
    {
        public static int FirstProblem(int[] data, bool dataModification = false, int noun = 12, int verb = 2)
        {
            if (dataModification)
            {
                data[1] = noun;
                data[2] = verb;
            }

            for (int i = 0; i < data.Length; i += 4)
            {
                int opCode = data[i];
                if (opCode == 99)
                {
                    return data[0];
                }

                int firstPosition = data[i + 1];
                int secondPosition = data[i + 2];
                int targetPosition = data[i + 3];

                if (opCode == 1)
                {
                    data[targetPosition] = data[firstPosition] + data[secondPosition];
                }
                else if (opCode == 2)
                {
                    data[targetPosition] = data[firstPosition] * data[secondPosition];
                }
                else
                {
                    return data[0];
                }
            }
            return 0;
        }

        public static int SecondProblem(int[] data)
        {
            int[] dataCopied = new int[data.Length];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Array.Copy(data, dataCopied, data.Length);
                    var result = FirstProblem(dataCopied, true, i, j);
                    if (result == 19690720)
                    {
                        return i * 100 + j;
                    }
                }
            }
            return 0;
        }

    }
}
