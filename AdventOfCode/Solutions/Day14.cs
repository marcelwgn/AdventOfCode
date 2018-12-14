using AdventOfCode.Model;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions {
  public class Day14 {
    public static Tuple<CyclicList<int>, int> convert(String[] data)
    {
      CyclicList<int> list = new CyclicList<int>();

      string firstLine = data[0];
      for (int i = 0; i < firstLine.Length; i++)
      {
        string current = firstLine[i].ToString();
        list.addLast(int.Parse(current));
      }

      return new Tuple<CyclicList<int>, int>(list, int.Parse(data[1]));
    }

    public static string firstProblem(Tuple<CyclicList<int>, int> data)
    {

      CyclicList<int> list = data.Item1;

      LinkedListNode<int> firstPointer = list.first;
      LinkedListNode<int> secondPointer = list.first.Next;

      int offset = list.count;

      for (int iterations = 0; iterations < data.Item2 + 10; iterations++)
      {
        int currentSum = firstPointer.Value + secondPointer.Value;

        if (currentSum >= 10)
        {
          list.addLast(1);
        }
        list.addLast(currentSum % 10);

        int firstIterations = firstPointer.Value;
        int secondIterations = secondPointer.Value;
        for (int i = 0; i < firstIterations + 1; i++)
        {
          firstPointer = list.getNextNode(firstPointer);
        }
        for (int i = 0; i < secondIterations + 1; i++)
        {
          secondPointer = list.getNextNode(secondPointer);
        }
      }

      String result = "";
      firstPointer = list.first;
      for (int i = 0; i < data.Item2; i++)
      {
        firstPointer = list.getNextNode(firstPointer);
      }
      for (int i = 0; i < 10; i++)
      {
        result += firstPointer.Value.ToString();
        firstPointer = list.getNextNode(firstPointer);
      }
      return result;
    }

    public static string secondProblem(Tuple<CyclicList<int>, int> list)
    {
      return "";
    }

  }
}
