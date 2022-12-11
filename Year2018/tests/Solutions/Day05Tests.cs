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

            var converted = Day05.Convert(data);

            Assert.AreEqual("a", converted);
        }

        [TestMethod()]
        public void PolymerTestaA()
        {
            var data = "aA";
            var changed = Day05.Polymer(data).Item1;

            Assert.AreEqual("", changed);
        }

        [TestMethod()]
        public void PolymerTestZz()
        {
            var data = "Zz";
            var changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("", changed);
        }

        [TestMethod()]
        public void PolymerTestabBA()
        {
            var data = "abBA";
            var changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("aA", changed);
        }

        [TestMethod()]
        public void PolymerTestabAB()
        {
            var data = "abAB";
            var changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("abAB", changed);
        }

        [TestMethod()]
        public void PolymerTestaabAAB()
        {
            var data = "aabAAB";
            var changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("aabAAB", changed);
        }

        [TestMethod()]
        public void FirstProblemTestOne()
        {
            var data = "dabAcCaCBAcCcaDA";
            var changed = Day05.FirstProblem(data);
            Assert.AreEqual(10, changed);
        }

        [TestMethod()]
        public void FirstProblemTestTwo()
        {
            var data = "dbcCCBcCcD";
            var changed = Day05.FirstProblem(data);
            Assert.AreEqual(6, changed);
        }

        [TestMethod()]
        public void FirstProblemTestThree()
        {
            var data = "dabAaBAaDA";
            var changed = Day05.FirstProblem(data);
            Assert.AreEqual(4, changed);
        }

        [TestMethod()]
        public void SecondProblemTest()
        {
            var data = "dabAcCaCBAcCcaDA";
            var changed = Day05.SecondProblem(data);
            Assert.AreEqual(4, changed);
        }
    }
}