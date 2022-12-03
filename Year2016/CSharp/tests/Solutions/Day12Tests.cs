using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public void FirstProblemTest()
        {
            var data = new string[]
            {
                "cpy 41 a",
                "inc a",
                "inc a",
                "dec a",
                "jnz a 2",
                "dec a"
            };

            Assert.AreEqual(42, Day12.FirstProblem(data));
        }

        [TestMethod]
        public void SecondProblemTest()
        {
            var data = new string[]
            {
                "cpy 41 a",
                "inc a",
                "jnz a 2",
                "dec a",
                "cpy c a"
            };

            Assert.AreEqual(1, Day12.SecondProblem(data));
        }
    }
}
