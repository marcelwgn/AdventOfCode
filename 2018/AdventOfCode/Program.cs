using AdventOfCode2018.SharedUtils;
using System;
using Solver = AdventOfCode2018.Solutions.Day14;


namespace AdventOfCode2018
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            //fileName = args[0];
            string fileName = @"..\..\..\Data\day14.txt";

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
