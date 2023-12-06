using AdventOfCode.Common;
using AdventOfCode.Year2018.Model;
using System;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day10
    {
        public static ChangingVector[] Convert(string[] data)
        {
            var vectors = new ChangingVector[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                var result = data[i][10..];
                result = result.Replace(" velocity=", "");
                result = result.Replace(">", "");
                result = result.Replace("<", ",");
                var split = Converters.GetNumbers(result, ",");
                vectors[i] = new ChangingVector(split[0], split[1], split[2], split[3]);
            }

            return vectors;
        }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "We actually want a 2d grid here")]
		public static void PrintVectors(int maxValue, int offset, ChangingVector[] vectors)
        {
            var field = new bool[maxValue - offset, maxValue - offset];
            for (var i = 0; i < vectors.Length; i++)
            {
                try
                {
                    field[vectors[i].Location.X - offset, vectors[i].Location.Y - offset] = true;

                }
                catch (IndexOutOfRangeException) { }
            }

            var line = "";

            var gridSize = (int)Math.Sqrt(field.Length);

            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
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
            for (var i = 0; i < vectors.Length; i++)
            {
                vectors[i].GoNSteps(10518);
            }

            var maxValue = 0;
            var offset = 0;

            for (var i = 0; i < vectors.Length; i++)
            {
                var maxVector = Math.Max(vectors[i].Location.X, vectors[i].Location.Y);
                maxValue = Math.Max(maxValue, maxVector);

                var minVector = Math.Min(vectors[i].Location.X, vectors[i].Location.Y);
                offset = Math.Min(offset, minVector);
            }
            for (var iterations = 0; iterations < 10; iterations++)
            {

                PrintVectors(maxValue, offset, vectors);
                for (var i = 0; i < vectors.Length; i++)
                {
                    vectors[i].GoStep();
                }
                Console.WriteLine("---------------");
            }

            return true;
        }

        public static bool SecondProblem(ChangingVector[] vectors)
        {
            for (var i = 0; i < vectors.Length; i++)
            {
                vectors[i].GoNSteps(10518);
            }

            var maxValue = 0;
            var offset = 0;

            for (var i = 0; i < vectors.Length; i++)
            {
                var maxVector = Math.Max(vectors[i].Location.X, vectors[i].Location.Y);
                maxValue = Math.Max(maxValue, maxVector);

                var minVector = Math.Min(vectors[i].Location.X, vectors[i].Location.Y);
                offset = Math.Min(offset, minVector);
            }
            for (var iterations = 0; iterations < 10; iterations++)
            {

                PrintVectors(maxValue, offset, vectors);
                for (var i = 0; i < vectors.Length; i++)
                {
                    vectors[i].GoStep();
                }
                Console.WriteLine("---------------          " + (iterations + 10500));
            }

            return true;
        }
    }
}
