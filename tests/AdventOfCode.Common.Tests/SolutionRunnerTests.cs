using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Common.Tests
{
    [TestClass]
    public class SolutionRunnerTests
    {
        private static class EmptyClass
        {

        }

        private static class NoConverterSolver
        {
            public static string FirstProblem(string[] data)
            {
                return data[1];
            }

            public static string SecondProblem(string[] data)
            {
                return data[2];
            }
        }

        private static class SolverWithConverter
        {
            public static int Convert(string[] data) => data.Length;

            public static int FirstProblem(int length)
            {
                return length * 2;
            }

            public static int SecondProblem(int length)
            {
                return length * 3;
            }
        }

        [TestMethod]
        public void VerifyRunnerDoesNotCrashWithMissingFunctions()
        {
            SolutionRunner.RunSolution(typeof(EmptyClass), "MockData/StringTestData.txt");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void VerifyFirstAndSecondProblemWithoutConverter()
        {
            (var firstSolution, var secondSolution) = SolutionRunner.RunSolution(typeof(NoConverterSolver), "MockData/StringTestData.txt");
            Assert.AreEqual(firstSolution, "Text2");
            Assert.AreEqual(secondSolution, "Text3");
        }

        [TestMethod]
        public void VerifyFirstAndSecondProblemWithConverter()
        {
            (var firstSolution, var secondSolution) = SolutionRunner.RunSolution(typeof(SolverWithConverter), "MockData/StringTestData.txt");
            Assert.AreEqual(firstSolution, 10);
            Assert.AreEqual(secondSolution, 15);
        }
    }
}
