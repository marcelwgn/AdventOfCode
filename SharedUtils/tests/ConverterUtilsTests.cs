using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.SharedUtils.Tests
{
    [TestClass()]
    public class DataConverterTests
    {
        [TestMethod()]
        public void VerifyGetNumbersWorksCorrectly()
        {
            string[] data = { "1", "-2", "+3" };

            int[] result = ConverterUtils.GetNumbers(data);

            int[] expected = { 1, -2, 3 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VerifyStringArrayToCharCharArrayWorksCorrectly()
        {
            var data = new string[]
            {
                "text", "1234","ABC"
            };

            var expected = new char[][]
            {
                new char[]{'t','e','x','t'},
                new char[]{'1','2','3','4'},
                new char[]{'A','B','C'}
            };
            var result = data.ToCharArray();
            for (int i = 0; i < 3; i++)
            {
                CollectionAssert.AreEqual(expected[i], result[i]);
            }
        }
    }
}