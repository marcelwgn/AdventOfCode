using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day13Tests
    {

        [TestMethod]
        public void VerifyGeneratedGraph()
        {
            var expectedVertexSet = new HashSet<(int, int)>
            {
                (0,0),
                (2,0),
                (0,1),
                (1,1),
                (3,1),
                (4,1),
                (1,2),
                (2,2),
                (3,2),
                (4,2),
                (3,3),
                (0,4),
                (3,4),
                (4,4),
            };

            var graph = Day13.Generate(10, 5);

            CollectionAssert.AreEquivalent(expectedVertexSet.ToList(), graph.Vertices.ToList());
        }

        [TestMethod]
        public void FirstProblemTest()
        {
            var data = new string[]
            {
                "10",
                "7",
                "4",
            };

            Assert.AreEqual(11, Day13.FirstProblem(data));
        }

		// Disabled because of performance
		// [TestMethod]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Usually a test, just disabled for performance reasons")]
		public void SecondProblemTest()
        {
            var data = new string[]
            {
                "10",
            };

            Assert.AreEqual(151, Day13.SecondProblem(data));
        }
    }
}
