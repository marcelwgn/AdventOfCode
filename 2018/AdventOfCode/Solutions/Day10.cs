using AdventOfCode2018.Model;
using AdventOfCode2018.SharedUtils;
using System;

namespace AdventOfCode2018.Solutions
{
    public static class Day10
    {
        public static ChangingVector[] Convert(string[] data)
        {
            ChangingVector[] vectors = new ChangingVector[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                string result = data[i].Substring(10);
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
            bool[,] field = new bool[maxValue - offset, maxValue - offset];
            for (int i = 0; i < vectors.Length; i++)
            {
                try
                {
                    field[vectors[i].location.x - offset, vectors[i].location.y - offset] = true;

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
                vectors[i].goNSteps(10518);
            }

            int maxValue = 0;
            int offset = 0;

            for (int i = 0; i < vectors.Length; i++)
            {
                int maxVector = Math.Max(vectors[i].location.x, vectors[i].location.y);
                maxValue = Math.Max(maxValue, maxVector);

                int minVector = Math.Min(vectors[i].location.x, vectors[i].location.y);
                offset = Math.Min(offset, minVector);
            }
            for (int iterations = 0; iterations < 10; iterations++)
            {

                PrintVectors(maxValue, offset, vectors);
                for (int i = 0; i < vectors.Length; i++)
                {
                    vectors[i].goStep();
                }
                Console.WriteLine("---------------");
            }


            return true;
        }


        public static bool SecondProblem(ChangingVector[] vectors)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i].goNSteps(10518);
            }

            int maxValue = 0;
            int offset = 0;

            for (int i = 0; i < vectors.Length; i++)
            {
                int maxVector = Math.Max(vectors[i].location.x, vectors[i].location.y);
                maxValue = Math.Max(maxValue, maxVector);

                int minVector = Math.Min(vectors[i].location.x, vectors[i].location.y);
                offset = Math.Min(offset, minVector);
            }
            for (int iterations = 0; iterations < 10; iterations++)
            {

                PrintVectors(maxValue, offset, vectors);
                for (int i = 0; i < vectors.Length; i++)
                {
                    vectors[i].goStep();
                }
                Console.WriteLine("---------------          " + (iterations + 10500));
            }


            return true;
        }
    }
}
