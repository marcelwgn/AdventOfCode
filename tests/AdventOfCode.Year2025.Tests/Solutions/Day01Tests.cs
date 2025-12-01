using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Year2025.Tests.Solutions
{
    [TestClass]
    public class Day01Tests
    {
        public static readonly string[] DATA =
        [
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82",
        ];

        [TestMethod]
        public void VerifyFirstProblem()
        {
            Assert.AreEqual("3", Year2025.Solutions.Day01.FirstProblem(DATA));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            Assert.AreEqual("6", Year2025.Solutions.Day01.SecondProblem(DATA));
        }


        [TestMethod]
        public void VerifySecondProblemHundreds()
        {
            string[] data = [
                "R200",
                "L200",
            ];
            Assert.AreEqual("4", Year2025.Solutions.Day01.SecondProblem(data));
        }


        [TestMethod]
        public void VerifySecondProblemHundredsCaseTwo()
        {
            string[] data = [
                "R50",
                "L200",
            ];
            Assert.AreEqual("3", Year2025.Solutions.Day01.SecondProblem(data));
        }
    }
}
