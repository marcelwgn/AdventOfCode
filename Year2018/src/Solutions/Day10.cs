using AdventOfCode.Year2018.Model;
using AdventOfCode.SharedUtils;
using System;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day10
    {
        public static ChangingVector[] Convert(string[] data)
        {
            ChangingVector[] vectors = new ChangingVector[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                string result = data[i][10..];
                result = result.Replace(" velocity=", "");
                result = result.Replace(">", "");
                result = result.Replace("<", ",");
                int[] split = ConverterUtils.GetNumbers(result, ",");
                vectors[i] = new ChangingVector(split[0], split[1], split[2], split[3]);
            }

            return vectors;
        }

        public static void PrintVectors(int maxValue, int offset, ChangingVector[] vectors)
        {
#pragma warning disable CA1814
            bool[,] field = new bool[maxValue - offset, maxValue - offset];
#pragma warning restore CA1814
            for (int i = 0; i < vectors.Length; i++)
            {
                try
                {
                    field[vectors[i].Location.X - offset, vectors[i].Location.Y - offset] = true;

                }
                catch (IndexOutOfRangeException) { }
            }

            string line = "";

            int gridSize = (int)Math.Sqrt(field.Length);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (field[j, i])
                    {
                        line += "#";
                    }
                    else
                    {
                        line += ".";
                    }
                }
                Console.WriteLine(line);
                line = "";
            }

        }


        public static bool FirstProblem(ChangingVector[] vectors)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i].GoNSteps(10518);
            }

            int maxValue = 0;
            int offset = 0;

            for (int i = 0; i < vectors.Length; i++)
            {
                int maxVector = Math.Max(vectors[i].Location.X, vectors[i].Location.Y);
                maxValue = Math.Max(maxValue, maxVector);

                int minVector = Math.Min(vectors[i].Location.X, vectors[i].Location.Y);
                offset = Math.Min(offset, minVector);
            }
            for (int iterations = 0; iterations < 10; iterations++)
            {

                PrintVectors(maxValue, offset, vectors);
                for (int i = 0; i < vectors.Length; i++)
                {
                    vectors[i].GoStep();
                }
                Console.WriteLine("---------------");
            }


            return true;
        }


        public static bool SecondProblem(ChangingVector[] vectors)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i].GoNSteps(10518);
            }

            int maxValue = 0;
            int offset = 0;

            for (int i = 0; i < vectors.Length; i++)
            {
                int maxVector = Math.Max(vectors[i].Location.X, vectors[i].Location.Y);
                maxValue = Math.Max(maxValue, maxVector);

                int minVector = Math.Min(vectors[i].Location.X, vectors[i].Location.Y);
                offset = Math.Min(offset, minVector);
            }
            for (int iterations = 0; iterations < 10; iterations++)
            {

                PrintVectors(maxValue, offset, vectors);
                for (int i = 0; i < vectors.Length; i++)
                {
                    vectors[i].GoStep();
                }
                Console.WriteLine("---------------          " + (iterations + 10500));
            }


            return true;
        }
    }
}
