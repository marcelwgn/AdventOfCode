using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Common.Tests
{
    [TestClass()]
    public class DataConverterTests
    {
        [TestMethod()]
        public void VerifyGetIntegersWorksCorrectly()
        {
            string[] data = { "1", "-2", "+3", "text" };

            var result = data.ToIntArray();

            int[] expected = { 1, -2, 3, 0 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void VerifyGetLongsWorksCorrectly()
        {
            string[] data = { "1000000000000", "-2", "+3", "text" };

            var result = data.ToLongArray();

            long[] expected = { 1000000000000, -2, 3, 0 };

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
            for (var i = 0; i < 3; i++)
            {
                CollectionAssert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod()]
        public void VerifyGetIntegersFromStringWorksCorrectly()
        {

            var result = Converters.GetNumbers("100 -2 +3");

            int[] expected = { 100, -2, 3 };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}