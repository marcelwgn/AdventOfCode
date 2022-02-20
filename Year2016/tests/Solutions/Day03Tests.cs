using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day03Tests
    {

        [TestMethod]
        public void ConverterTest()
        {
            var data = new string[]
            {
                "1 2 3",
                "     10 -1 20",
                "     10 -1 20    ",
                "     10   -1   20    ",
            };

            var converted = Day03.Convert(data);

            CollectionAssert.AreEqual(new int[] {1,2,3} , converted[0]);
            CollectionAssert.AreEqual(new int[] {10,-1,20}, converted[1]);
            CollectionAssert.AreEqual(new int[] {10,-1,20}, converted[2]);
            CollectionAssert.AreEqual(new int[] {10,-1,20}, converted[3]);
        }

        [TestMethod]
        public void FirstProblemTest()
        {
            var data = new int[][]
            {
                new int[]{2,2,3},
                new int[]{1000,2,3},
                new int[]{1,2000,3},
                new int[]{10,20,20},
                new int[]{1,2,30000},
            };
            Assert.AreEqual(2, Day03.FirstProblem(data));
        }

        [TestMethod]
        public void SecondProblemTest()
        {
            var data = new int[][]
            {
                new int[]{2,20,3},
                new int[]{2,200,3},
                new int[]{3,10,3},
                new int[]{10,20,20},
                new int[]{1,20,1},
                new int[]{1,20,1},
            };
            Assert.AreEqual(3, Day03.SecondProblem(data));
        }
    }
}
