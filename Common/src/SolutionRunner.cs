using System;
using System.Diagnostics;

namespace AdventOfCode.Common
{
    /// <summary>
    /// This class is designed to make running tests a lot easier by removing the boilerplate of invoking the correct functions.
    /// 
    /// While we could have requiered to pass in an instance implementing an interface, it was chosen to require a type being passed.
    /// This is mostly due to the fact that the use case is always having a stateless function that only needs data to output data the other way.
    /// By using reflection, we do not impose any implementation specifications beside having static functions 
    /// with a specific name which is a lot easier to work with from an implementers standpoint.
    /// 
    /// Converting is an optional step which will only be done once. The converted data will be copied to both functions,
    /// if FirstProblem modifies the data, the modified data will be passed into the SecondProblem function of the class.
    /// All invoked functions need to be static since we do not operate on instances.
    /// </summary>
    public static class SolutionRunner
    {
        const string ConvertFunctionName = "Convert";
        const string FirstProblemName = "FirstProblem";
        const string SecondProblemName = "SecondProblem";

        public static (object?, object?) RunSolution(Type classType, string fileName = "data.txt")
        {
            var rawData = ReadUtils.ReadDataFromFile(fileName);

            object rawDataActual = rawData;
            if (classType.GetMethod(ConvertFunctionName) != null)
            {
                var convertStopwatch = new Stopwatch();
                convertStopwatch.Start();
                rawDataActual = classType.GetMethod(ConvertFunctionName)!.Invoke(null, new object[] { rawData })!;
                convertStopwatch.Stop();
                Console.WriteLine($"Converting data took {convertStopwatch.Elapsed}");
                Debug.WriteLine($"Converting data took {convertStopwatch.Elapsed}");
            }

            var (firstResult, firstResultTime) = SolveProblem(classType, rawDataActual, FirstProblemName);
            Console.WriteLine($"First problem solution {firstResult} , execution time: {firstResultTime}");
            Debug.WriteLine($"First problem solution {firstResult} , execution time: {firstResultTime}");

            var (secondResult, secondResultTime) = SolveProblem(classType, rawDataActual, SecondProblemName);
            Console.WriteLine($"Second problem solution {secondResult} , execution time: {secondResultTime}");
            Debug.WriteLine($"Second problem solution {secondResult} , execution time: {secondResultTime}");

            return (firstResult, secondResult);
        }

        private static (object?, TimeSpan?) SolveProblem(Type classType, object rawDataActual, string problemName)
        {
            object? firstResult = null;
            TimeSpan? firstResultTime = null;
            if (classType.GetMethod(problemName) != null)
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                firstResult = classType.GetMethod(problemName)!.Invoke(null, new object[] { rawDataActual });
                stopWatch.Stop();
                firstResultTime = stopWatch.Elapsed;
            }
            return (firstResult, firstResultTime);
        }
    }
}
