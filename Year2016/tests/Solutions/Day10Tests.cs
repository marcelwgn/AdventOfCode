using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day10Tests
    {

        string[] instructions = new string[]
        {
            "value 5 goes to bot 2",
            "bot 2 gives low to bot 1 and high to bot 0",
            "value 3 goes to bot 1",
            "bot 1 gives low to output 1 and high to bot 0",
            "bot 0 gives low to output 2 and high to output 0",
            "value 2 goes to bot 2",
        };

        [TestMethod]
        public void ConvertBotTestWorks()
        {
            var expected = new (int?, int?)[]
            {
                (null,null),
                (3,null),
                (2,5),
                (null,null)
            };

            CollectionAssert.AreEqual(expected, Day10.GenerateBots(instructions));
        }

        [TestMethod]
        public void FindsComparisonCorrectlyWorks()
        {
            var bots = Day10.GenerateBots(instructions);
            Assert.AreEqual(2, Day10.ProcessInput(instructions, bots, (5,2)).FoundComparison);
        }

        [TestMethod]
        public void OutputsAreCorrect()
        {
            var bots = Day10.GenerateBots(instructions);
            var expectedOutput = new int?[]
            {
                5,2,3, null
            };
            var actual = Day10.ProcessInput(instructions, bots, (-1, -1)).Outputs;
            CollectionAssert.AreEqual(expectedOutput, actual);
        }
    }
}
