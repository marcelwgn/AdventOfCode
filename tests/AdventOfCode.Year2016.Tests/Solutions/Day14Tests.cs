using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void FirstProblemTest()
        {
            Assert.AreEqual(22728, Day14.FirstProblem(["abc"]));
        }

		// Disabled due to long runtime
		//[TestMethod]
#pragma warning disable CA1822 // Mark members as static
		public void SecondProblemTest()
#pragma warning restore CA1822 // Mark members as static
		{
            Assert.AreEqual(22551, Day14.SecondProblem(["abc"]));
        }
    }
}
