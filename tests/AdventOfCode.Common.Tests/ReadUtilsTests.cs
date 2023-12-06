using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Common.Tests
{
    [TestClass]
    public class ReadUtilsTests
    {
        [TestMethod]
        public void VerifyReadsStringDataCorrectly()
        {
			string[] expected =
			[
				"Text1",
                "Text2",
                "Text3",
                "Text4",
                "Text5"
            ];

            CollectionAssert.AreEqual(expected, ReadUtils.ReadDataFromFile("MockData/StringTestData.txt"));
        }
    }
}
