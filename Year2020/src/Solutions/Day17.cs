using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day17
    {
        public static int FirstProblem(string[] data)
        {
            var dictionary = ProcessProblem(data, false);
            return dictionary.Count;
        }

        public static int SecondProblem(string[] data)
        {
            var dictionary = ProcessProblem(data, true);
            return dictionary.Count;
        }

        private static HashSet<(int X, int Y, int Z, int W)> ProcessProblem(string[] data, bool useW)
        {
            var dictionary = new HashSet<(int X, int Y, int Z, int W)>();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == '#')
                    {
                        dictionary.Add((i, j, 0, 0));
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                dictionary = Transform(dictionary, useW);
            }

            return dictionary;
        }

        public static HashSet<(int X, int Y, int Z, int W)> Transform(HashSet<(int X, int Y, int Z, int W)> active, bool useW)
        {
            var (xStart, xEnd, yStart, yEnd, zStart, zEnd, wStart, wEnd) = (0, 0, 0, 0, 0, 0, 0, 0);

            foreach (var (X, Y, Z, W) in active)
            {
                xStart = Math.Min(xStart, X);
                xEnd = Math.Max(xEnd, X);
                yStart = Math.Min(yStart, Y);
                yEnd = Math.Max(yEnd, Y);
                zStart = Math.Min(zStart, Z);
                zEnd = Math.Max(zEnd, Z);
                wStart = Math.Min(wStart, W);
                wEnd = Math.Max(wEnd, W);
            }

            var newValues = new HashSet<(int X, int Y, int Z, int W)>();

            for (int i = xStart - 1; i <= xEnd + 1; i++)
            {
                for (int j = yStart - 1; j <= yEnd + 1; j++)
                {
                    for (int k = zStart - 1; k <= zEnd + 1; k++)
                    {
                        if (useW)
                        {
                            for (int l = wStart - 1; l <= wEnd + 1; l++)
                            {
                                ProcessCount(newValues, (i, j, k, l),
                                    NeighborCount((i, j, k, l)),
                                    active.Contains((i, j, k, l)));
                            }
                        }
                        else
                        {
                            ProcessCount(newValues, (i, j, k, 0),
                                NeighborCount((i, j, k, 0)),
                                active.Contains((i, j, k, 0)));
                        }
                    }
                }
            }
            return newValues;

            int NeighborCount((int X, int Y, int Z, int W) position)
            {
                // We might find one item: the coordinate its self; Account for that now.
                int count = active.Contains(position) ? -1 : 0;
                for (int i = position.X - 1; i <= position.X + 1; i++)
                {
                    for (int j = position.Y - 1; j <= position.Y + 1; j++)
                    {
                        for (int k = position.Z - 1; k <= position.Z + 1; k++)
                        {
                            if (useW)
                            {
                                for (int l = position.W - 1; l <= position.W + 1; l++)
                                {
                                    if (active.Contains((i, j, k, l)))
                                    {
                                        count++;
                                    }
                                }
                            }
                            else
                            {
                                if (active.Contains((i, j, k, 0)))
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
                return count;
            }

            void ProcessCount(HashSet<(int X, int Y, int Z, int W)> newValues, (int i, int j, int k, int l) pos, int count, bool isActive)
            {
                if (isActive && (count == 2 || count == 3))
                {
                    newValues.Add(pos);
                }
                if (!isActive && count == 3)
                {
                    newValues.Add(pos);
                }
            }
        }

    }
}
