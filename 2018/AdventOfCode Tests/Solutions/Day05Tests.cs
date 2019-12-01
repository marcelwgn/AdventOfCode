using AdventOfCode2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018Tests.SolutionsTests
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
        public void PolymerTest_aA()
        {
            string data = "aA";
            string changed = Day05.Polymer(data).Item1;

            Assert.AreEqual("", changed);
        }
        [TestMethod()]
        public void PolymerTest_Zz()
        {
            string data = "Zz";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("", changed);
        }
        [TestMethod()]
        public void PolymerTest_abBA()
        {
            string data = "abBA";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("aA", changed);
        }
        [TestMethod()]
        public void PolymerTest_abAB()
        {
            string data = "abAB";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("abAB", changed);
        }
        [TestMethod()]
        public void PolymerTest_aabAAB()
        {
            string data = "aabAAB";
            string changed = Day05.Polymer(data).Item1;
            Assert.AreEqual("aabAAB", changed);
        }

        [TestMethod()]
        public void FirstProblemTest_One()
        {
            string data = "dabAcCaCBAcCcaDA";
            int changed = Day05.FirstProblem(data);
            Assert.AreEqual(10, changed);
        }
        [TestMethod()]
        public void FirstProblemTest_Two()
        {
            string data = "dbcCCBcCcD";
            int changed = Day05.FirstProblem(data);
            Assert.AreEqual(6, changed);
        }
        [TestMethod()]
        public void FirstProblemTest_Three()
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