using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Year2019.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Tests.Solutions
{
    [TestClass]
    public class Day02Tests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 0, 0, 0, 99 },2)]
        [DataRow(new int[] { 2, 3, 0, 3, 99 },2)]
        [DataRow(new int[] { 2, 4, 4, 5, 99, 0 },2)]
        [DataRow(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 },30)]
        public void VerifyFirstProblem(int[] data, int expectedValue)
        {
            Assert.AreEqual(expectedValue, Day02.FirstProblem(data));
        }

    }
}
