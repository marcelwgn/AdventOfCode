using System;
using System.Linq;

namespace AdventOfCode.Year2022.Solutions
{
    public static class Day08
    {
        public static (short Height, bool Processed)[][] Convert(string[] data)
        {
            var field = new (short, bool)[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                field[i] = new (short, bool)[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                {
                    field[i][j] = new(short.Parse(data[i][j].ToString()), false);
                }
            }
            return field;
        }

        public static long FirstProblem((short Height, bool Valid)[][] field)
        {
            // Walk rows
            for (int i = 0; i < field.Length; i++)
            {
                ProcessRow(i);
            }

            for (int i = 0; i < field[0].Length; i++)
            {
                ProcessColumn(i);
            }

            return field.SelectMany(x => x).Where(x => x.Valid).Count();

            void ProcessRow(int rowIndex)
            {
                int maximum = -1;
                // Process from start
                for (int i = 0; i < field[rowIndex].Length; i++)
                {
                    if (maximum < field[rowIndex][i].Height)
                    {
                        field[rowIndex][i].Valid = true;
                        maximum = field[rowIndex][i].Height;
                    }
                }

                // Process from end
                maximum = -1;
                for (int i = field[rowIndex].Length - 1; i >= 0; i--)
                {
                    if (maximum < field[rowIndex][i].Height)
                    {
                        field[rowIndex][i].Valid = true;
                        maximum = field[rowIndex][i].Height;
                    }
                }
            }

            void ProcessColumn(int columnIndex)
            {
                int maximum = -1;
                // Process from start
                for (int i = 0; i < field.Length; i++)
                {
                    if (maximum < field[i][columnIndex].Height)
                    {
                        field[i][columnIndex].Valid = true;
                        maximum = field[i][columnIndex].Height;
                    }
                }

                // Process from end
                maximum = -1;
                for (int i = field.Length - 1; i >= 0; i--)
                {
                    if (maximum < field[i][columnIndex].Height)
                    {
                        field[i][columnIndex].Valid = true;
                        maximum = field[i][columnIndex].Height;
                    }
                }
            }
        }

        public static long SecondProblem((short Height, bool Valid)[][] field)
        {
            int maxLength = Math.Max(field.Length, field[0].Length);
            var bestScore = 0;
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    bestScore = Math.Max(bestScore, GetScore(i, j));
                }
            }
            return bestScore;

            int GetScore(int row, int column)
            {
                int leftDistance = 0;
                int rightDistance = 0;
                int topDistance = 0;
                int bottomDistance = 0;

                bool leftFinished = false;
                bool rightFinished = false;
                bool topFinished = false;
                bool bottomFinished = false;
                for (int i = 1; i < maxLength; i++)
                {
                    if (column - i >= 0 && !leftFinished)
                    {
                        leftDistance++;
                        if (field[row][column - i].Height >= field[row][column].Height)
                        {
                            leftFinished = true;
                        }
                    }
                    if (column + i < field[0].Length && !rightFinished)
                    {
                        rightDistance++;
                        if (field[row][column + i].Height >= field[row][column].Height)
                        {
                            rightFinished = true;
                        }
                    }
                    if (row - i >= 0 && !bottomFinished)
                    {
                        bottomDistance++;
                        if (field[row - i][column].Height >= field[row][column].Height)
                        {
                            bottomFinished = true;
                        }
                    }
                    if (row + i < field.Length && !topFinished)
                    {
                        topDistance++;
                        if (field[row + i][column].Height >= field[row][column].Height)
                        {
                            topFinished = true;
                        }
                    }
                }

                return leftDistance * rightDistance * topDistance * bottomDistance;
            }
        }
    }
}
