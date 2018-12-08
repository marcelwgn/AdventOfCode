﻿using System;
using AdventOfCode.Utils;
using Solver = AdventOfCode.Solutions.Day8;


namespace AdventOfCode {
  internal class Program {

    private static void Main(String[] args) {
      string fileName = "";

      //fileName = args[0];
      fileName = @"..\..\..\Data\day8.txt";

      //Reading data
      string[] data = ReadUtils.readDataFromFile(fileName);

      //Converting result
      var converted = Solver.convert(data);

      //Calculating result
      var resultOne = Solver.firstProblem(converted);

      //Printing result
      Console.WriteLine("First problem:");
      Console.WriteLine(resultOne);

      var resultTwo = Solver.secondProblem(converted);

      Console.WriteLine("Second problem:");
      Console.WriteLine(resultTwo);

      //Keep console open so result can be read
      Console.ReadKey();

    }

  }
}
