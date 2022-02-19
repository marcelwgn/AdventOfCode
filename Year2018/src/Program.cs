using System;
using AdventOfCode.Common;
using Solver = AdventOfCode.Year2018.Solutions.Day14;


namespace AdventOfCode.Year2018
{
    public class Program
    {
        private static void Main(string[] _)
        {
            string fileName = "data.txt";
            //Reading data
            string[] data = ReadUtils.ReadDataFromFile(fileName);

            //Converting result
            Tuple<Model.CyclicList<int>, int> converted = Solver.Convert(data);

            //Calculating result
            string resultOne = Solver.FirstProblem(converted);

            //Printing result
            Console.WriteLine("First problem:");
            Console.WriteLine(resultOne);

            data = ReadUtils.ReadDataFromFile(fileName);

            //Converting result
            converted = Solver.Convert(data);

            int resultTwo = Solver.SecondProblem(converted);

            Console.WriteLine("Second problem:");
            Console.WriteLine(resultTwo);

            //Keep console open so result can be read
            Console.ReadKey();
        }
    }
}
