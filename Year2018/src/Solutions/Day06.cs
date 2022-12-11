using AdventOfCode.Year2018.Model;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2018.Solutions
{
#pragma warning disable CA1814
    public static class Day06
    {
        public static Tuple<Vector[], string[,]> Convert(string[] data)
        {
            var points = new Vector[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                var split = data[i].Split(",");
                var first = int.Parse(split[0]);
                var second = int.Parse(split[1]);
                points[i] = new Vector(first, second, i.ToString());

            }

            var fieldSize = 400;
            var field = new string[fieldSize, fieldSize];

            for (var i = 0; i < fieldSize; i++)
            {
                for (var j = 0; j < fieldSize; j++)
                {
                    var bestDistance = int.MaxValue;
                    var pointsBest = 0;
                    var isUndecided = false;
                    for (var pointsIndex = 0; pointsIndex < data.Length; pointsIndex++)
                    {
                        var current = points[pointsIndex];
                        var distance = current.GetDistance(j, i);
                        if (bestDistance == distance)
                        {
                            pointsBest = pointsIndex;
                            isUndecided = true;
                        }
                        if (bestDistance > distance)
                        {
                            isUndecided = false;
                            pointsBest = pointsIndex;
                            bestDistance = distance;
                        }
                    }

                    if (isUndecided)
                    {
                        field[i, j] = "";

                    }
                    else
                    {
                        field[i, j] = points[pointsBest].Name;
                    }
                }
            }

            return new Tuple<Vector[], string[,]>(points, field);
        }

        public static int FirstProblem(Tuple<Vector[], string[,]> data)
        {
            var points = data.Item1;
            var field = data.Item2;

            var fieldSize = (int)Math.Sqrt(field.Length);

            //Getting list of points that have an area not limited by array bounds, so to speak are finite
            var finiteSets = new List<string>();
            for (var label = 0; label < points.Length; label++)
            {
                finiteSets.Add(label.ToString());
            }
            for (var i = 0; i < fieldSize; i++)
            {
                var leftBorder = field[i, 0];
                var rightBorder = field[i, fieldSize - 1];

                var upperBorder = field[0, i];
                var lowerBorder = field[fieldSize - 1, i];

                finiteSets.Remove(leftBorder);
                finiteSets.Remove(rightBorder);
                finiteSets.Remove(upperBorder);
                finiteSets.Remove(lowerBorder);

            }
            var bestCount = 0;
            foreach (var label in finiteSets)
            {
                var count = 0;
                for (var i = 0; i < fieldSize; i++)
                {
                    for (var j = 0; j < fieldSize; j++)
                    {
                        if (field[i, j] == label)
                        {
                            count++;
                        }
                    }
                }
                if (count > bestCount)
                {
                    bestCount = count;
                }
            }
            return bestCount;
        }

        public static int SecondProblem(Tuple<Vector[], string[,]> data)
        {
            var points = data.Item1;
            var field = data.Item2;

            var fieldSize = (int)Math.Sqrt(field.Length);

            var suitableLocationsCount = 0;

            var maxDistance = 10000;

            for (var i = 0; i < fieldSize; i++)
            {
                for (var j = 0; j < fieldSize; j++)
                {
                    var count = 0;
                    for (var pointIndex = 0; pointIndex < points.Length; pointIndex++)
                    {
                        count += points[pointIndex].GetDistance(j, i);
                    }

                    if (maxDistance > count)
                    {
                        suitableLocationsCount++;
                    }
                }
            }
            return suitableLocationsCount;

        }
    }
#pragma warning restore CA1814
}