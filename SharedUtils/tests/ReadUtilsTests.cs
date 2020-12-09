using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.SharedUtils.tests
{
    [TestClass]
    public class ReadUtilsTests
    {

        [TestMethod]
        public void VerifyReadsStringDataCorrectly()
        {
            var expected = new string[]
            {
                "Text1",
                "Text2",
                "Text3",
                "Text4",
                "Text5"
            };

            CollectionAssert.AreEqual(expected, ReadUtils.ReadDataFromFile("MockData/StringTestData.txt"));
        }

        [TestMethod]
        public void VerifyReadsIntDataCorrectly()
        {
            var expected = new int[]
            {
                1,
                2,
                3,
                4,
                5
            };

            CollectionAssert.AreEqual(expected, ReadUtils.ReadLongDataFromFile("MockData/IntTestData.txt"));
        }

    }
}
