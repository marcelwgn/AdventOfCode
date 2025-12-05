using AdventOfCode.Year2018.Model;

namespace AdventOfCode.Year2018.Solutions;

public static class Day14
{
    public static Tuple<CyclicList<int>, int> Convert(string[] data)
    {
        var list = new CyclicList<int>();

        var firstLine = data[0];
        for (var i = 0; i < firstLine.Length; i++)
        {
            var current = firstLine[i].ToString();
            list.AddLast(int.Parse(current));
        }

        return new Tuple<CyclicList<int>, int>(list, int.Parse(data[1]));
    }

    public static string FirstProblem(Tuple<CyclicList<int>, int> data)
    {

        var list = data.Item1;

        var firstPointer = list.First;
        var secondPointer = list.First.Next!;

        for (var iterations = 0; iterations < data.Item2 + 10; iterations++)
        {
            var currentSum = firstPointer.Value + secondPointer.Value;

            if (currentSum >= 10)
            {
                list.AddLast(1);
            }
            list.AddLast(currentSum % 10);

            var firstIterations = firstPointer.Value;
            var secondIterations = secondPointer.Value;
            for (var i = 0; i < firstIterations + 1; i++)
            {
                firstPointer = list.GetNextNode(firstPointer);
            }
            for (var i = 0; i < secondIterations + 1; i++)
            {
                secondPointer = list.GetNextNode(secondPointer);
            }
        }

        var result = "";
        firstPointer = list.First;
        for (var i = 0; i < data.Item2; i++)
        {
            firstPointer = list.GetNextNode(firstPointer);
        }
        for (var i = 0; i < 10; i++)
        {
            result += firstPointer.Value.ToString();
            firstPointer = list.GetNextNode(firstPointer);
        }
        return result;
    }

    //Creates over 1 gig of objects
    public static int SecondProblem(Tuple<CyclicList<int>, int> data)
    {
        var list = data.Item1;

        var firstPointer = list.First;
        var secondPointer = list.First.Next!;

        var sequenceLength = data.Item2.ToString().Length;

        var elementsToTheLeft = -sequenceLength - 2;

        var sequenceValues = new int[sequenceLength];
        for (var i = 0; i < sequenceLength; i++)
        {
            sequenceValues[i] = int.Parse(data.Item2.ToString()[i].ToString());
        }

        for (var preperationIndex = 0; preperationIndex < sequenceLength; preperationIndex++)
        {
            var currentSum = firstPointer.Value + secondPointer.Value;
            if (currentSum >= 10)
            {
                list.AddLast(1);
                elementsToTheLeft++;
            }
            elementsToTheLeft++;
            list.AddLast(currentSum % 10);
            var firstIterations = firstPointer.Value;
            var secondIterations = secondPointer.Value;
            for (var i = 0; i < firstIterations + 1; i++)
            {
                firstPointer = list.GetNextNode(firstPointer);
            }
            for (var i = 0; i < secondIterations + 1; i++)
            {
                secondPointer = list.GetNextNode(secondPointer);
            }
        }

        var startOfSequenceToCheck = list.First;

        var found = false;

        while (!found)
        {
            var currentSum = firstPointer.Value + secondPointer.Value;

            if (currentSum >= 10)
            {
                list.AddLast(1);
                elementsToTheLeft++;
                startOfSequenceToCheck = startOfSequenceToCheck.Next!;
            }
            list.AddLast(currentSum % 10);
            elementsToTheLeft++;
            startOfSequenceToCheck = startOfSequenceToCheck.Next!;

            var firstIterations = firstPointer.Value;
            var secondIterations = secondPointer.Value;
            for (var i = 0; i < firstIterations + 1; i++)
            {
                firstPointer = list.GetNextNode(firstPointer);
            }
            for (var i = 0; i < secondIterations + 1; i++)
            {
                secondPointer = list.GetNextNode(secondPointer);
            }
            found = true;
            var walkerNode = startOfSequenceToCheck;
            for (var i = 0; i < sequenceLength; i++)
            {
                if (walkerNode!.Value != sequenceValues[i])
                {
                    found = false;
                }
                walkerNode = walkerNode.Next!;
            }

        }

        return elementsToTheLeft;
    }

}
