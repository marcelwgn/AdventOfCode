using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void ConvertTests()
        {
            var data = new string[]
            {
                "swap position 4 with position 0",
                "swap letter d with letter b",
                "reverse positions 0 through 4",
                "rotate left 1 step",
                "rotate right 1 step",
                "move position 1 to position 4",
                "move position 3 to position 0",
                "rotate based on position of letter b",
                "rotate based on position of letter d",
            };

            var expected = new Day21.TextInstruction[]
            {
                new Day21.TextInstruction()
                {
                    Operation = "SWAP",
                    FirstIndex = 4,
                    SecondIndex = 0,
                    IndexBased = true
                },
                new Day21.TextInstruction()
                {
                    Operation = "SWAP",
                    FirstChar = 'd',
                    SecondChar= 'b',
                },
                new Day21.TextInstruction()
                {
                    Operation = "REVERSE",
                    FirstIndex = 0,
                    SecondIndex = 4,
                    IndexBased = true
                },
                new Day21.TextInstruction()
                {
                    Operation = "ROTATE",
                    FirstIndex = -1,
                    IndexBased = true
                },
                new Day21.TextInstruction()
                {
                    Operation = "ROTATE",
                    FirstIndex = 1,
                    IndexBased = true
                },
                new Day21.TextInstruction()
                {
                    Operation = "MOVE",
                    FirstIndex = 1,
                    SecondIndex = 4,
                    IndexBased = true
                },
                new Day21.TextInstruction()
                {
                    Operation = "MOVE",
                    FirstIndex = 3,
                    SecondIndex = 0,
                    IndexBased = true
                },
                new Day21.TextInstruction()
                {
                    Operation = "ROTATE",
                    FirstChar = 'b',
                },
                new Day21.TextInstruction()
                {
                    Operation = "ROTATE",
                    FirstChar = 'd',
                },

            };

            CollectionAssert.AreEqual(expected, Day21.Convert(data));
        }

        [TestMethod]
        public void ProcessInstructionsMoveTest()
        {
            var moveInstructionOne = new Day21.TextInstruction()
            {
                Operation = "MOVE",
                FirstIndex = 1,
                SecondIndex = 4,
                IndexBased = true
            };
            var moveInstructionTwo = new Day21.TextInstruction()
            {
                Operation = "MOVE",
                FirstIndex = 3,
                SecondIndex = 0,
                IndexBased = true
            };

            Assert.AreEqual("bdeac", Day21.ProcessInstruction("bcdea", moveInstructionOne));
            Assert.AreEqual("abdec", Day21.ProcessInstruction("bdeac", moveInstructionTwo));
        }

        [TestMethod]
        public void ProcessInstructionsSwapTest()
        {
            var indexSwap = new Day21.TextInstruction()
            {
                Operation = "SWAP",
                FirstIndex = 4,
                SecondIndex = 0,
                IndexBased = true
            };
            var charSwap = new Day21.TextInstruction()
            {
                Operation = "SWAP",
                FirstChar = 'd',
                SecondChar = 'b',
            };

            Assert.AreEqual("ebcda", Day21.ProcessInstruction("abcde", indexSwap));
            Assert.AreEqual("edcba", Day21.ProcessInstruction("ebcda", charSwap));
        }

        [TestMethod]
        public void ProcessInstructionsReverseTest()
        {
            var indexSwap = new Day21.TextInstruction()
            {
                Operation = "REVERSE",
                FirstIndex = 1,
                SecondIndex = 4,
                IndexBased = true
            };
            var completeStringReverse = new Day21.TextInstruction()
            {
                Operation = "REVERSE",
                FirstIndex = 0,
                SecondIndex = 4,
                IndexBased = true
            };

            Assert.AreEqual("aedcb", Day21.ProcessInstruction("abcde", indexSwap));
            Assert.AreEqual("abcde", Day21.ProcessInstruction("edcba", completeStringReverse));
        }

        [TestMethod]
        public void ProcessInstructionsRotateTest()
        {
            var leftShift = new Day21.TextInstruction()
            {
                Operation = "ROTATE",
                FirstIndex = -1,
                IndexBased = true
            };
            var rightShift = new Day21.TextInstruction()
            {
                Operation = "ROTATE",
                FirstIndex = 10,
                IndexBased = true
            };
            var bShift = new Day21.TextInstruction()
            {
                Operation = "ROTATE",
                FirstChar = 'b',
            };
            var dShift = new Day21.TextInstruction()
            {
                Operation = "ROTATE",
                FirstChar = 'd',
            };

            Assert.AreEqual("bcdea", Day21.ProcessInstruction("abcde", leftShift));
            Assert.AreEqual("bcdea", Day21.ProcessInstruction("bcdea", rightShift));
            Assert.AreEqual("ecabd", Day21.ProcessInstruction("abdec", bShift));
            Assert.AreEqual("decab", Day21.ProcessInstruction("ecabd", dShift));
        }

        [TestMethod]

        public void FirstProblemTest()
        {
            var data = new (uint, uint)[]
            {
                (5,8),
                (0,2),
                (4,7)
            };
            Assert.AreEqual(3u, Day20.FirstProblem(data));
        }

        [TestMethod]

        public void SecondProblemTest()
        {
            var data = new (uint, uint)[]
            {
                (0,2),
                (4,7),
                (5,8),
                (11,14),
                (16, uint.MaxValue)
            };
            Assert.AreEqual(4u, Day20.SecondProblem(data));
        }

        [TestMethod]

        public void GetUniqueIntervalsTest()
        {
            var data = new (uint, uint)[]
            {
                (0,2),
                (4,7),
                (5,8),
                (11,14),
                (12,17),
                (16, 22),
                (25, uint.MaxValue - 10)
            };

            var expected = new List<(long, long)>
            {
                (0,2),(4,8),(11,22),(25, uint.MaxValue - 10)
            };

            CollectionAssert.AreEqual(expected, Day20.GetUniqueIntervals(data));
        }

    }
}
