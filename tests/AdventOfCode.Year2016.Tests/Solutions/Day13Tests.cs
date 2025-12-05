using AdventOfCode.Common.DataStructures;
using AdventOfCode.Year2016.Solutions;

namespace AdventOfCode.Year2016.Tests.Solutions;

[TestClass]
public class Day13Tests
{

    [TestMethod]
    public void VerifyGeneratedGraph()
    {
        var expectedVertexSet = new HashSet<Coordinate>
        {
            new(0,0),
            new(2,0),
            new(0,1),
            new(1,1),
            new(3,1),
            new(4,1),
            new(1,2),
            new(2,2),
            new(3,2),
            new(4,2),
            new(3,3),
            new(0,4),
            new(3,4),
            new(4,4),
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
