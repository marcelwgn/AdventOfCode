using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCode2018.Solutions;
namespace AdventOfCode2018Tests.SolutionsTests
{
    [TestClass()]
    public class Day14Tests
    {

        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "37", "8" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            //Killing demetes law with one line at a time
            Assert.AreEqual(3, converted.Item1.first.Value);
            Assert.AreEqual(7, converted.Item1.first.Next.Value);

            Assert.AreEqual(8, converted.Item2);
        }

        [TestMethod()]
        public void FirstProblemTest_9Recipes()
        {
            string[] data = { "37", "9" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            string result = Day14.FirstProblem(converted);

            Assert.AreEqual("5158916779", result);
        }

        [TestMethod()]
        public void FirstProblemTest_5Recipes()
        {
            string[] data = { "37", "5" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            string result = Day14.FirstProblem(converted);

            Assert.AreEqual("0124515891", result);
        }

        [TestMethod()]
        public void FirstProblemTest_18Recipes()
        {
            string[] data = { "37", "18" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            string result = Day14.FirstProblem(converted);

            Assert.AreEqual("9251071085", result);
        }

        [TestMethod()]
        public void FirstProblemTest_2018Recipes()
        {
            string[] data = { "37", "2018" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            string result = Day14.FirstProblem(converted);

            Assert.AreEqual("5941429882", result);
        }

        [TestMethod()]
        public void SecondProblemTest_51589()
        {
            string[] data = { "37", "51589" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            int result = Day14.SecondProblem(converted);

            Assert.AreEqual(9, result);
        }


        [TestMethod()]
        public void SecondProblemTest_92510()
        {
            string[] data = { "37", "92510" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            int result = Day14.SecondProblem(converted);

            Assert.AreEqual(18, result);
        }
        [TestMethod()]
        public void SecondProblemTest_59414()
        {
            string[] data = { "37", "59414" };

            System.Tuple<AdventOfCode2018.Model.CyclicList<int>, int> converted = Day14.Convert(data);

            int result = Day14.SecondProblem(converted);

            Assert.AreEqual(2018, result);
        }
    }
}
