using AdventOfCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions {
  public class Day09 {
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
      int currentNumberToAdd = 2;

      CyclicList<int> field = new CyclicList<int>();

      field.addFirst(0);
      LinkedListNode<int> curNode = field.first;

      //Initializing first values
      curNode = field.getNextNode(curNode);
      field.addAfter(curNode, 1);
      curNode = field.getNextNode(curNode);
      curNode = field.getNextNode(curNode);
      field.addAfter(curNode, 2);
      curNode = field.getNextNode(curNode);

      while (currentNumberToAdd < maxScore)
      {

        currentNumberToAdd++;
        if (currentNumberToAdd % 23 == 0)
        {
          //Yay scoring
          for (int i = 0; i < 7; i++)
          {
            curNode = field.getPreviousNode(curNode);
          }

          int value = currentNumberToAdd + curNode.Value;

          LinkedListNode<int> nexNode = field.getNextNode(curNode);

          field.remove(curNode);
          playerScores[currentPlayerIndex] += value;

          curNode = nexNode;
        }
        else
        {
          //Normal way
          curNode = field.getNextNode(curNode);
          field.addAfter(curNode, currentNumberToAdd);
          curNode = field.getNextNode(curNode);
        }

        //Increase playerIndex
        currentPlayerIndex = (currentPlayerIndex + 1) % (playerScores.Length);
      }

      return playerScores.Max();
    }

    //This is not the right solution ................... -.-
    public static long secondProblem(Tuple<long[], int> data)
    {
      long[] playerScores = data.Item1;

      int maxScore = data.Item2;

      int maxModified = maxScore * 100;
      for (int i = 0; i < playerScores.Length; i++)
      {
        playerScores[i] = 0;
      }
      Tuple<long[], int> newTuple = new Tuple<long[], int>(playerScores, maxModified);
      return firstProblem(newTuple);
    }


  }
}
