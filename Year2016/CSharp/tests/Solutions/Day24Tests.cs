using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day24Tests
    {

        private string[] demoMaze = new string[]
        {
            "###########",
            "#0.1.....2#",
            "#.#######.#",
            "#4.......3#",
            "###########",
        };

        [TestMethod]
        public void ConvertTest()
        {
            var expectedCharArray = new char[][]
            {
                new char[]{'#','#','#','#','#','#','#','#','#','#','#'},
                new char[]{'#','0','.','1','.','.','.','.','.','2','#'},
                new char[]{'#','.','#','#','#','#','#','#','#','.','#'},
                new char[]{'#','4','.','.','.','.','.','.','.','3','#'},
                new char[]{'#','#','#','#','#','#','#','#','#','#','#'}
            };

            char[][] actual = Day24.Convert(demoMaze);
            for (int i = 0; i < expectedCharArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedCharArray[i], actual[i]);
            }
        }

        [TestMethod]
        public void GetNumbersTest()
        {
            var expectedPositions = new (int, int)[]
            {
                (1,1),(1,3),(1,9),(3,9),(3,1)
            };

            CollectionAssert.AreEqual(expectedPositions, Day24.GetNumberPositions(Day24.Convert(demoMaze)));
        }

        [TestMethod]
        public void FirstProblemTest()
        {
            var charData = Day24.Convert(demoMaze);

            Assert.AreEqual(14, Day24.FirstProblem(charData));
        }

        [TestMethod]
        public void SecondProblemTest()
        {
            var charData = Day24.Convert(demoMaze);

            Assert.AreEqual(20, Day24.SecondProblem(charData));
        }
    }
}
