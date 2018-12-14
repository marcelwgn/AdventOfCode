using System;

namespace AdventOfCode.Solutions {
  public class Day11 {

    public const int gridSize = 300;

    public static int[,] convert(String[] data)
    {
      int gridSerialNumber = int.Parse(data[0]);
      int[,] field = new int[gridSize, gridSize];


      for (int x = 0; x < 300; x++)
      {
        for (int y = 0; y < 300; y++)
        {
          long rackID = x + 1 + 10;
          long power = (y + 1) * rackID;
          power += gridSerialNumber;
          power *= rackID;

          int hundredDigit = getHundreds(power);
          hundredDigit -= 5;
          field[x, y] = hundredDigit;

        }
      }


      return field;
    }

    public static int getHundreds(long value)
    {
      int hundreds = (int)(value % 1000 - value % 100) / 100;

      return hundreds;
    }

    public static long get3x3Sum(int[,] field, int x, int y, int squareSize)
    {
      long sum = 0;
      for (int i = 0; i < squareSize; i++)
      {
        for (int j = 0; j < squareSize; j++)
        {
          sum += field[i + x, j + y];
        }
      }

      return sum;
    }


    public static string firstProblem(int[,] field)
    {
      long best = 0;
      int bestX = 0;
      int bestY = 0;
      for (int i = 0; i < gridSize - 2; i++)
      {
        for (int j = 0; j < gridSize - 2; j++)
        {
          long res = get3x3Sum(field, i, j, 3);
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



    public static string secondProblem(int[,] field)
    {
      long best = 0;
      int bestX = 0;
      int bestY = 0;
      int bestSquareSize = 1;
      for (int i = 0; i < gridSize - 2; i++)
      {
        for (int j = 0; j < gridSize - 2; j++)
        {
          int maxAvailable = gridSize - Math.Max(i, j);
          for (int squareSize = 1; squareSize < maxAvailable; squareSize++)
          {
            long res = get3x3Sum(field, i, j, squareSize);
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
