using AdventOfCode2018.Model;
using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Solutions
{
    public static class Day14
    {
        public static Tuple<CyclicList<int>, int> Convert(string[] data)
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

        public static string FirstProblem(Tuple<CyclicList<int>, int> data)
        {

            CyclicList<int> list = data.Item1;

            LinkedListNode<int> firstPointer = list.first;
            LinkedListNode<int> secondPointer = list.first.Next;

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

            string result = "";
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


        //Creates over 1 gig of objects
        public static int SecondProblem(Tuple<CyclicList<int>, int> data)
        {
            CyclicList<int> list = data.Item1;

            LinkedListNode<int> firstPointer = list.first;
            LinkedListNode<int> secondPointer = list.first.Next;

            int sequenceLength = data.Item2.ToString().Length;

            int elementsToTheLeft = -sequenceLength - 2;

            int[] sequenceValues = new int[sequenceLength];
            for (int i = 0; i < sequenceLength; i++)
            {
                sequenceValues[i] = int.Parse(data.Item2.ToString()[i].ToString());
            }

            for (int preperationIndex = 0; preperationIndex < sequenceLength; preperationIndex++)
            {
                int currentSum = firstPointer.Value + secondPointer.Value;
                if (currentSum >= 10)
                {
                    list.addLast(1);
                    elementsToTheLeft++;
                }
                elementsToTheLeft++;
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

            LinkedListNode<int> startOfSequenceToCheck = list.first;

            bool found = false;


            while (!found)
            {
                int currentSum = firstPointer.Value + secondPointer.Value;

                if (currentSum >= 10)
                {
                    list.addLast(1);
                    elementsToTheLeft++;
                    startOfSequenceToCheck = startOfSequenceToCheck.Next;
                }
                list.addLast(currentSum % 10);
                elementsToTheLeft++;
                startOfSequenceToCheck = startOfSequenceToCheck.Next;


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
                found = true;
                LinkedListNode<int> walkerNode = startOfSequenceToCheck;
                for (int i = 0; i < sequenceLength; i++)
                {
                    if (walkerNode.Value != sequenceValues[i])
                    {
                        found = false;
                    }
                    walkerNode = walkerNode.Next;
                }

            }

            return elementsToTheLeft;
        }

    }
}
