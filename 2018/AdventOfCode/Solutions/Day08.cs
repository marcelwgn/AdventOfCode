using AdventOfCode2018.Model;
using AdventOfCode2018.SharedUtils;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Solutions
{
    public static class Day08
    {
        public static Node<List<int>> Convert(string[] data)
        {
            int[] parsed = ConverterUtils.GetNumbers(data[0]);

            Node<List<int>> root = GetNode(parsed, 0);

            return root;
        }

        public static int FirstProblem(Node<List<int>> rootNode)
        {
            int start = 0;

            start += rootNode.data.Aggregate((a, b) => { return a + b; });
            if (rootNode.children.Count != 0)
            {
                for (int i = 0; i < rootNode.children.Count; i++)
                {
                    start += FirstProblem(rootNode.children[i]);
                }
            }
            return start;
        }

        public static int SecondProblem(Node<List<int>> rootNode)
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
                        sum += SecondProblem(rootNode.children[index]);
                    }
                }
                return sum;
            }

        }



        public static Node<List<int>> GetNode(int[] data, int start)
        {
            Node<List<int>> rootNode = new Node<List<int>>(new List<int>());
            int childCount = data[start];
            int metaCount = data[start + 1];
            int metaStart = FindMetaData(data, start);

            //Adding metadata
            for (int i = 0; i < metaCount; i++)
            {
                rootNode.data.Add(data[metaStart + i]);
            }

            //Checking children
            if (childCount != 0)
            {
                Node<List<int>> firstChild = GetNode(data, start + 2);
                rootNode.AddChild(firstChild);
                int nextChildStart = FindNextNode(data, start + 2);
                for (int i = 1; i < childCount; i++)
                {
                    Node<List<int>> child = GetNode(data, nextChildStart);
                    rootNode.AddChild(child);
                    nextChildStart = FindNextNode(data, nextChildStart);
                }
            }

            return rootNode;
        }

        public static int FindMetaData(int[] data, int start)
        {
            int result = start;

            
            
            
            
            
            
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
                    int metaStartChild = FindMetaData(data, newIndex);
                    newIndex = metaStartChild + metaCountOfChild;
                }
            }
            return newIndex;

        }

        public static int FindNextNode(int[] data, int start)
        {
            int metaCountCurrent = data[start + 1];
            return FindMetaData(data, start) + metaCountCurrent;
        }

    }
}
