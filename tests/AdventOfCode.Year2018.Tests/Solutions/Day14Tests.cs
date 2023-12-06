using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day14Tests
    {

        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = ["37", "8"];

            var converted = Day14.Convert(data);

            //Killing demeter's law with one line at a time
            Assert.AreEqual(3, converted.Item1.First.Value);
            Assert.AreEqual(7, converted.Item1.First.Next!.Value);

            Assert.AreEqual(8, converted.Item2);
        }

        [TestMethod()]
        public void FirstProblemTest9Recipes()
        {
            string[] data = ["37", "9"];

            var converted = Day14.Convert(data);

            var result = Day14.FirstProblem(converted);

            Assert.AreEqual("5158916779", result);
        }

        [TestMethod()]
        public void FirstProblemTest5Recipes()
        {
            string[] data = ["37", "5"];

            var converted = Day14.Convert(data);

            var result = Day14.FirstProblem(converted);

            Assert.AreEqual("0124515891", result);
        }

        [TestMethod()]
        public void FirstProblemTest18Recipes()
        {
            string[] data = ["37", "18"];

            var converted = Day14.Convert(data);

            var result = Day14.FirstProblem(converted);

            Assert.AreEqual("9251071085", result);
        }

        [TestMethod()]
        public void FirstProblemTest2018Recipes()
        {
            string[] data = ["37", "2018"];

            var converted = Day14.Convert(data);

            var result = Day14.FirstProblem(converted);

            Assert.AreEqual("5941429882", result);
        }

        [TestMethod()]
        public void SecondProblemTest51589()
        {
            string[] data = ["37", "51589"];

            var converted = Day14.Convert(data);

            var result = Day14.SecondProblem(converted);

            Assert.AreEqual(9, result);
        }

        [TestMethod()]
        public void SecondProblemTest92510()
        {
            string[] data = ["37", "92510"];

            var converted = Day14.Convert(data);

            var result = Day14.SecondProblem(converted);

            Assert.AreEqual(18, result);
        }

        [TestMethod()]
        public void SecondProblemTest59414()
        {
            string[] data = ["37", "59414"];

            var converted = Day14.Convert(data);

            var result = Day14.SecondProblem(converted);

            Assert.AreEqual(2018, result);
        }
    }
}
