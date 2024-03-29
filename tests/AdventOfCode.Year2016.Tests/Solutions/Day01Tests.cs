﻿using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day01Tests
    {

        [TestMethod]
        [DataRow("R2, L3", 5)]
        [DataRow("R2, R2, R2", 2)]
        [DataRow("R5, L5, R5, R3", 12)]
        public void FirstProblemTest(string data, int expectedValue)
        {
            Assert.AreEqual(expectedValue, Day01.FirstProblem([data]));
        }


		[TestMethod]
        public void SecondProblemTest()
        {
            Assert.AreEqual(4, Day01.SecondProblem(["R8, R4, R4, R8"]));
        }
    }
}
