using AdventOfCode.Model;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions {
  public class Day08 {
    public static Node<List<int>> convert(String[] data)
    {
      int[] parsed = ConverterUtils.getNumbers(data[0]);

      Node<List<int>> root = getNode(parsed, 0);

      return root;
    }

    public static int firstProblem(Node<List<int>> rootNode)
    {
      int start = 0;

      start += rootNode.data.Aggregate((a, b) => { return a + b; });
      if (rootNode.children.Count != 0)
      {
        for (int i = 0; i < rootNode.children.Count; i++)
        {
          start += firstProblem(rootNode.children[i]);
        }
      }
      return start;
    }

    public static int secondProblem(Node<List<int>> rootNode)
    {
      int childCount = rootNode.children.Count;
      if (childCount == 0)
      {
        //Just add metadata values
        return rootNode.data.Aggregate((a, b) => { return a + b; });
      }
      else
      {
        //Deal with childern bullshittery
        int sum = 0;
        for (int i = 0; i < rootNode.data.Count; i++)
        {
          int index = rootNode.data[i] - 1;
          if (index <= childCount - 1)
          {
            sum += secondProblem(rootNode.children[index]);
          }
        }
        return sum;
      }

    }



    public static Node<List<int>> getNode(int[] data, int start)
    {
      Node<List<int>> rootNode = new Node<List<int>>(new List<int>());
      int childCount = data[start];
      int metaCount = data[start + 1];
      int metaStart = findMetaData(data, start);

      //Adding metadata
      for (int i = 0; i < metaCount; i++)
      {
        rootNode.data.Add(data[metaStart + i]);
      }

      //Checking children
      if (childCount != 0)
      {
        Node<List<int>> firstChild = getNode(data, start + 2);
        rootNode.addChild(firstChild);
        int nextChildStart = findNextNode(data, start + 2);
        for (int i = 1; i < childCount; i++)
        {
          Node<List<int>> child = getNode(data, nextChildStart);
          rootNode.addChild(child);
          nextChildStart = findNextNode(data, nextChildStart);
        }
      }

      return rootNode;
    }

    public static int findMetaData(int[] data, int start)
    {
      int result = start;

      int metaCount = data[start + 1];

      int newIndex = start + 2;

      if (data[start] == 0)
      {
        result += 2;
        return result;
      }
      else
      {
        int childCount = data[start];
        for (int i = 0; i < childCount; i++)
        {
          int metaCountOfChild = data[newIndex + 1];
          int metaStartChild = findMetaData(data, newIndex);
          newIndex = metaStartChild + metaCountOfChild;
        }
      }
      return newIndex;

    }

    public static int findNextNode(int[] data, int start)
    {
      int metaCountCurrent = data[start + 1];
      return findMetaData(data, start) + metaCountCurrent;
    }

  }
}
