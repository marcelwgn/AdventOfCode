using AdventOfCode.Year2018.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day09
    {
        public static Tuple<long[], int> Convert(string[] data)
        {
            string[] split = data[0].Split(" ");
            long[] playerValues = new long[int.Parse(split[0])];
            int maxCountValue = int.Parse(split[6]);

            return new Tuple<long[], int>(playerValues, maxCountValue);
        }

        public static long FirstProblem(Tuple<long[], int> data)
        {
            long[] playerScores = data.Item1;

            int maxScore = data.Item2;

            int currentPlayerIndex = 2;
            int currentNumberToAdd = 2;

            CyclicList<int> field = new CyclicList<int>();

            field.AddFirst(0);
            LinkedListNode<int> curNode = field.First;

            //Initializing first values
            curNode = field.GetNextNode(curNode);
            field.AddAfter(curNode, 1);
            curNode = field.GetNextNode(curNode);
            curNode = field.GetNextNode(curNode);
            field.AddAfter(curNode, 2);
            curNode = field.GetNextNode(curNode);

            while (currentNumberToAdd < maxScore)
            {

                currentNumberToAdd++;
                if (currentNumberToAdd % 23 == 0)
                {
                    //Yay scoring
                    for (int i = 0; i < 7; i++)
                    {
                        curNode = field.GetPreviousNode(curNode);
                    }

                    int value = currentNumberToAdd + curNode.Value;

                    LinkedListNode<int> nexNode = field.GetNextNode(curNode);

                    field.Remove(curNode);
                    playerScores[currentPlayerIndex] += value;

                    curNode = nexNode;
                }
                else
                {
                    //Normal way
                    curNode = field.GetNextNode(curNode);
                    field.AddAfter(curNode, currentNumberToAdd);
                    curNode = field.GetNextNode(curNode);
                }

                //Increase playerIndex
                currentPlayerIndex = (currentPlayerIndex + 1) % (playerScores.Length);
            }

            return playerScores.Max();
        }

        //This is not the right solution ................... -.-
        public static long SecondProblem(Tuple<long[], int> data)
        {
            long[] playerScores = data.Item1;

            int maxScore = data.Item2;

            int maxModified = maxScore * 100;
            for (int i = 0; i < playerScores.Length; i++)
            {
                playerScores[i] = 0;
            }
            Tuple<long[], int> newTuple = new Tuple<long[], int>(playerScores, maxModified);
            return FirstProblem(newTuple);
        }


    }
}
