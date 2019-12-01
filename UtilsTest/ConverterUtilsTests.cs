using AdventOfCode2018.SharedUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCode.UtilsTests
{
    [TestClass()]
    public class DataConverterTests
    {
        [TestMethod()]
        public void GetNumbersTest()
        {
            string[] data = { "1", "-2", "+3" };

            int[] result = ConverterUtils.GetNumbers(data);

            int[] expected = { 1, -2, 3 };

            for (int i = 0; i < data.Length; i++)
            {
                if (!result.Contains(expected[i]))
                {
                    Assert.Fail();
                }
            }
        }
    }
}