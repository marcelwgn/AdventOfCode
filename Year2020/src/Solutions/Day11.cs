namespace AdventOfCode.Year2020.Solutions
{
    public static class Day11
    {
        public static int FirstProblem(char[][] data)
        {
            while (TransformFirstProblem(data)) { }

            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == '#')
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        public static int SecondProblem(char[][] data)
        {
            while (TransformSecondProblem(data)) { }

            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == '#')
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        public static bool TransformFirstProblem(char[][] data)
        {
            bool modified = false;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    int neighbors = 0;
                    neighbors += SeatCount(i - 1, j - 1);
                    neighbors += SeatCount(i - 1, j);
                    neighbors += SeatCount(i - 1, j + 1);
                    neighbors += SeatCount(i, j - 1);
                    neighbors += SeatCount(i, j + 1);
                    neighbors += SeatCount(i + 1, j - 1);
                    neighbors += SeatCount(i + 1, j);
                    neighbors += SeatCount(i + 1, j + 1);
                    if (data[i][j] == '#' && neighbors >= 4)
                    {
                        modified = true;
                        data[i][j] = 'l';
                    }
                    else if (data[i][j] == 'L' && neighbors == 0)
                    {
                        modified = true;
                        data[i][j] = '*';
                    }
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == '*')
                    {
                        data[i][j] = '#';
                    }
                    else if (data[i][j] == 'l')
                    {
                        data[i][j] = 'L';
                    }
                }
            }

            return modified;

            int SeatCount(int xPos, int yPos)
            {
                if (xPos < 0 || xPos == data.Length || yPos < 0 || yPos == data[xPos].Length)
                {
                    return 0;
                }
                else
                {
                    return data[xPos][yPos] == '#' || data[xPos][yPos] == 'l' ? 1 : 0;
                }
            }
        }
        public static bool TransformSecondProblem(char[][] data)
        {
            bool modified = false;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    int neighbors = 0;
                    neighbors += SeatCount(i, j, -1, 0);
                    neighbors += SeatCount(i, j, -1, 1);
                    neighbors += SeatCount(i, j, 0, 1);
                    neighbors += SeatCount(i, j, 1, 1);
                    neighbors += SeatCount(i, j, 1, 0);
                    neighbors += SeatCount(i, j, 1, -1);
                    neighbors += SeatCount(i, j, 0, -1);
                    neighbors += SeatCount(i, j, -1, -1);
                    if (data[i][j] == '#' && neighbors >= 5)
                    {
                        modified = true;
                        data[i][j] = 'l';
                    }
                    else if (data[i][j] == 'L' && neighbors == 0)
                    {
                        modified = true;
                        data[i][j] = '*';
                    }
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == '*')
                    {
                        data[i][j] = '#';
                    }
                    else if (data[i][j] == 'l')
                    {
                        data[i][j] = 'L';
                    }
                }
            }

            return modified;

            int SeatCount(int xPos, int yPos, int modifierX, int modifierY)
            {
                int xPosLocal = xPos;
                int yPosLocal = yPos;
                do
                {
                    xPosLocal += modifierX;
                    yPosLocal += modifierY;
                } while (xPosLocal >= 0 && xPosLocal < data.Length && yPosLocal >= 0 && yPosLocal < data[xPosLocal].Length && data[xPosLocal][yPosLocal] == '.');

                if (xPosLocal < 0 || xPosLocal == data.Length || yPosLocal < 0 || yPosLocal == data[xPosLocal].Length)
                {
                    return 0;
                }
                else
                {
                    return data[xPosLocal][yPosLocal] == '#' || data[xPosLocal][yPosLocal] == 'l' ? 1 : 0;
                }
            }
        }

    }
}
