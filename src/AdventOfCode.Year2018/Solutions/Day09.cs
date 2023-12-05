using AdventOfCode.Year2018.Model;
using System;
using System.Linq;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day09
    {
        public static Tuple<long[], int> Convert(string[] data)
        {
            var split = data[0].Split(" ");
            var playerValues = new long[int.Parse(split[0])];
            var maxCountValue = int.Parse(split[6]);

            return new Tuple<long[], int>(playerValues, maxCountValue);
        }

        public static long FirstProblem(Tuple<long[], int> data)
        {
            var playerScores = data.Item1;

            var maxScore = data.Item2;

            var currentPlayerIndex = 2;
            var currentNumberToAdd = 2;

            var field = new CyclicList<int>();

            field.AddFirst(0);
            var curNode = field.First;

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
                    for (var i = 0; i < 7; i++)
                    {
                        curNode = field.GetPreviousNode(curNode);
                    }

                    var value = currentNumberToAdd + curNode.Value;

                    var nexNode = field.GetNextNode(curNode);

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
                currentPlayerIndex = (currentPlayerIndex + 1) % playerScores.Length;
            }

            return playerScores.Max();
        }

        //This is not the right solution ................... -.-
        public static long SecondProblem(Tuple<long[], int> data)
        {
            var playerScores = data.Item1;

            var maxScore = data.Item2;

            var maxModified = maxScore * 100;
            for (var i = 0; i < playerScores.Length; i++)
            {
                playerScores[i] = 0;
            }
            var newTuple = new Tuple<long[], int>(playerScores, maxModified);
            return FirstProblem(newTuple);
        }

    }
}
