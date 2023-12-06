using System;

namespace AdventOfCode.Year2018.Solutions
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "We actually need 2d grids here")]
    public static class Day11
    {
        public const int gridSize = 300;

        public static int[,] Convert(string[] data)
        {
            var gridSerialNumber = int.Parse(data[0]);
            var field = new int[gridSize, gridSize];

            for (var x = 0; x < 300; x++)
            {
                for (var y = 0; y < 300; y++)
                {
                    long rackID = x + 1 + 10;
                    var power = (y + 1) * rackID;
                    power += gridSerialNumber;
                    power *= rackID;

                    var hundredDigit = GetHundreds(power);
                    hundredDigit -= 5;
                    field[x, y] = hundredDigit;

                }
            }
            return field;
        }

        public static int GetHundreds(long value)
        {
            var hundreds = (int)(value % 1000 - value % 100) / 100;
            return hundreds;
        }

        public static long Get3x3Sum(int[,] field, int x, int y, int squareSize)
        {
            long sum = 0;
            for (var i = 0; i < squareSize; i++)
            {
                for (var j = 0; j < squareSize; j++)
                {
                    sum += field[i + x, j + y];
                }
            }

            return sum;
        }

        public static string FirstProblem(int[,] field)
        {
            long best = 0;
            var bestX = 0;
            var bestY = 0;
            for (var i = 0; i < gridSize - 2; i++)
            {
                for (var j = 0; j < gridSize - 2; j++)
                {
                    var res = Get3x3Sum(field, i, j, 3);
                    if (best < res)
                    {
                        best = res;
                        bestX = i + 1;
                        bestY = j + 1;
                    }
                }
            }

            return "BestX: " + bestX + " BestY: " + bestY;
        }

		public static string SecondProblem(int[,] field)
        {
            long best = 0;
            var bestX = 0;
            var bestY = 0;
            var bestSquareSize = 1;
            for (var i = 0; i < gridSize - 2; i++)
            {
                for (var j = 0; j < gridSize - 2; j++)
                {
                    var maxAvailable = gridSize - Math.Max(i, j);
                    for (var squareSize = 1; squareSize < maxAvailable; squareSize++)
                    {
                        var res = Get3x3Sum(field, i, j, squareSize);
                        if (best < res)
                        {
                            best = res;
                            bestX = i + 1;
                            bestY = j + 1;
                            bestSquareSize = squareSize;
                        }
                    }

                }
            }

            return "BestX: " + bestX + " BestY: " + bestY + " BestSquare: " + bestSquareSize;
        }
    }
}
