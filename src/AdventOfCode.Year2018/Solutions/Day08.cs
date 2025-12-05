using AdventOfCode.Common;
using AdventOfCode.Year2018.Model;

namespace AdventOfCode.Year2018.Solutions;

public static class Day08
{
    public static Node<List<int>> Convert(string[] data)
    {
        var parsed = Converters.GetNumbers(data[0]);

        var root = GetNode(parsed, 0);

        return root;
    }

    public static int FirstProblem(Node<List<int>> rootNode)
    {
        var start = 0;

        start += rootNode.Data!.Aggregate((a, b) => { return a + b; });
        if (rootNode.Children.Count != 0)
        {
            for (var i = 0; i < rootNode.Children.Count; i++)
            {
                start += FirstProblem(rootNode.Children[i]);
            }
        }
        return start;
    }

    public static int SecondProblem(Node<List<int>> rootNode)
    {
        var childCount = rootNode.Children.Count;
        if (childCount == 0)
        {
            //Just add metadata values
            return rootNode.Data!.Aggregate((a, b) => { return a + b; });
        }
        else
        {
            //Deal with childern bullshittery
            var sum = 0;
            for (var i = 0; i < rootNode.Data!.Count; i++)
            {
                var index = rootNode.Data[i] - 1;
                if (index <= childCount - 1)
                {
                    sum += SecondProblem(rootNode.Children[index]);
                }
            }
            return sum;
        }

    }

    public static Node<List<int>> GetNode(int[] data, int start)
    {
        var rootNode = new Node<List<int>>(new List<int>());
        var childCount = data[start];
        var metaCount = data[start + 1];
        var metaStart = FindMetaData(data, start);

        //Adding metadata
        for (var i = 0; i < metaCount; i++)
        {
            rootNode.Data!.Add(data[metaStart + i]);
        }

        //Checking children
        if (childCount != 0)
        {
            var firstChild = GetNode(data, start + 2);
            rootNode.AddChild(firstChild);
            var nextChildStart = FindNextNode(data, start + 2);
            for (var i = 1; i < childCount; i++)
            {
                var child = GetNode(data, nextChildStart);
                rootNode.AddChild(child);
                nextChildStart = FindNextNode(data, nextChildStart);
            }
        }

        return rootNode;
    }

    public static int FindMetaData(int[] data, int start)
    {
        var result = start;

        var newIndex = start + 2;

        if (data[start] == 0)
        {
            result += 2;
            return result;
        }
        else
        {
            var childCount = data[start];
            for (var i = 0; i < childCount; i++)
            {
                var metaCountOfChild = data[newIndex + 1];
                var metaStartChild = FindMetaData(data, newIndex);
                newIndex = metaStartChild + metaCountOfChild;
            }
        }
        return newIndex;

    }

    public static int FindNextNode(int[] data, int start)
    {
        var metaCountCurrent = data[start + 1];
        return FindMetaData(data, start) + metaCountCurrent;
    }

}
