﻿using System;
using System.Linq;

namespace AdventOfCode.Year2019.Solutions
{
    public static class Day02
    {
        public static int[] Convert(string[] data)
        {
            return data[0].Split(",").Select(int.Parse).ToArray();
        }

        public static int FirstProblem(int[] data)
        {
            return FirstProblemAlgorithm(data);
        }

        public static int FirstProblemAlgorithm(int[] data, bool dataModification = false, int noun = 12, int verb = 2)
        {
            if (dataModification)
            {
                data[1] = noun;
                data[2] = verb;
            }

            for (var i = 0; i < data.Length; i += 4)
            {
                var opCode = data[i];
                if (opCode == 99)
                {
                    return data[0];
                }

                var firstPosition = data[i + 1];
                var secondPosition = data[i + 2];
                var targetPosition = data[i + 3];

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
            var dataCopied = new int[data.Length];
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    Array.Copy(data, dataCopied, data.Length);
                    var result = FirstProblemAlgorithm(dataCopied, true, i, j);
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
