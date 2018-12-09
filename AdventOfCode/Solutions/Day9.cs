using AdventOfCode.Model;
using System;
using System.Linq;

namespace AdventOfCode.Solutions {
  public class Day9 {
    public static Tuple<long[], int> convert(String[] data)
    {
      string[] split = data[0].Split(" ");
      long[] playerValues = new long[int.Parse(split[0])];
      int maxCountValue = int.Parse(split[6]);

      return new Tuple<long[], int>(playerValues, maxCountValue);

    }

    public static long firstProblem(Tuple<long[], int> data)
    {
      long[] playerScores = data.Item1;

      int maxScore = data.Item2;

      int currentPlayerIndex = 2;
      int currentNumberIndex = 1;
      int currentNumberToAdd = 2;

      CyclicList<int> field = new CyclicList<int>();
      field.insertAfter(0, 0);
      field.insertAfter(1, 1);
      field.insertAfter(0, 2);
      while (currentNumberToAdd < maxScore)
      {

        currentNumberToAdd++;

        if (currentNumberToAdd % 23 == 0)
        {
          //Yay scoring

          //Getting score
          currentNumberIndex -= 7;
          int value = currentNumberToAdd + field[currentNumberIndex];

          //Adding to players score
          playerScores[currentPlayerIndex] += value;

          field.remove(currentNumberIndex);
        }
        else
        {
          //Normal way

          int injectionNumber = currentNumberIndex + 1;

          field.insertAfter(injectionNumber, currentNumberToAdd);


          int unmodified = currentNumberIndex;

          while(field[currentNumberIndex] != currentNumberToAdd){
            currentNumberIndex = (currentNumberIndex + 1) % field.Count;
          }

          //if (currentNumberIndex + 2 < field.Count)
          //{
          //  currentNumberIndex += 2;
          //}
          //if (currentNumberIndex + 2 == field.Count)
          //{
          //  currentNumberIndex++;
          //}
          //if (currentNumberIndex + 1 == field.Count)
          //{
          //  currentNumberIndex = -1;
          //}
          // int diffValue = field.getIndex(currentNumberToAdd);

          //if (currentNumberIndex != diffValue)
          //{
          //  currentNumberIndex = field.getIndex(currentNumberToAdd);

          //}
        }

        //Increase values
        currentPlayerIndex = (currentPlayerIndex + 1) % (playerScores.Length);
      }


      return playerScores.Max();
    }

    //This is not the right solution ................... -.-
    public static long secondProblem(Tuple<long[], int> data)
    {
      long[] playerScores = data.Item1;

      int maxScore = data.Item2;

      int currentPlayerIndex = 2;
      int currentNumberIndex = 1;
      int currentNumberToAdd = 2;

      CyclicList<int> field = new CyclicList<int>();
      field.insertAfter(0, 0);
      field.insertAfter(1, 1);
      field.insertAfter(0, 2);

      int maxModified = maxScore * 100;

      while (currentNumberToAdd < maxModified)
      {

        currentNumberToAdd++;

        if (currentNumberToAdd % 23 == 0)
        {
          //Yay scoring

          //Getting score
          currentNumberIndex -= 7;
          int value = currentNumberToAdd + field[currentNumberIndex];

          //Adding to players score
          playerScores[currentPlayerIndex] += value;

          field.remove(currentNumberIndex);
        }
        else
        {
          //Normal way

          int injectionNumber = currentNumberIndex + 1;

          field.insertAfter(injectionNumber, currentNumberToAdd);


          int unmodified = currentNumberIndex;

          while (field[currentNumberIndex] != currentNumberToAdd)
          {
            currentNumberIndex = (currentNumberIndex + 1) % field.Count;
          }

          //if (currentNumberIndex + 2 < field.Count)
          //{
          //  currentNumberIndex += 2;
          //}
          //if (currentNumberIndex + 2 == field.Count)
          //{
          //  currentNumberIndex++;
          //}
          //if (currentNumberIndex + 1 == field.Count)
          //{
          //  currentNumberIndex = -1;
          //}
          // int diffValue = field.getIndex(currentNumberToAdd);

          //if (currentNumberIndex != diffValue)
          //{
          //  currentNumberIndex = field.getIndex(currentNumberToAdd);

          //}
        }

        //Increase values
        currentPlayerIndex = (currentPlayerIndex + 1) % (playerScores.Length);
      }


      return playerScores.Max();
    }


  }
}
