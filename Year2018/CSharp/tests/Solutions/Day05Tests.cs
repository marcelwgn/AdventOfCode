using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day05Tests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "a", "b", "c" };

            string converted = Day05.Convert(data);

            Assert.AreEqual("a", converted);
        }

        [TestMethod()]
        public void PolymerTestaA()
        {
            string data = "aA";
            string changed = Day05.Polymer(data).Item1;

            Assert.AreEqual("", changed);
        }

        [TestMethod()]
        public void PolymerTestZz()
        {
            string data = "Zz";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("", changed);
        }

        [TestMethod()]
        public void PolymerTestabBA()
        {
            string data = "abBA";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("aA", changed);
        }

        [TestMethod()]
        public void PolymerTestabAB()
        {
            string data = "abAB";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("abAB", changed);
        }

        [TestMethod()]
        public void PolymerTestaabAAB()
        {
            string data = "aabAAB";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("aabAAB", changed);
        }

        [TestMethod()]
        public void FirstProblemTestOne()
        {
            string data = "dabAcCaCBAcCcaDA";
            int changed = Day05.FirstProblem(data);
            Assert.AreEqual(10, changed);
        }

        [TestMethod()]
        public void FirstProblemTestTwo()
        {
            string data = "dbcCCBcCcD";
            int changed = Day05.FirstProblem(data);
            Assert.AreEqual(6, changed);
        }

        [TestMethod()]
        public void FirstProblemTestThree()
        {
            string data = "dabAaBAaDA";
            int changed = Day05.FirstProblem(data);
            Assert.AreEqual(4, changed);
        }

        [TestMethod()]
        public void SecondProblemTest()
        {
            string data = "dabAcCaCBAcCcaDA";
            int changed = Day05.SecondProblem(data);
            Assert.AreEqual(4, changed);
        }
    }
}