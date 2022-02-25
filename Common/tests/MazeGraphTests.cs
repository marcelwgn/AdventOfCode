using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Common.Tests
{
    [TestClass()]
    public class MazeGraphTests
    {

        [TestMethod]
        public void InitializesCorrectly()
        {
            var maze = new char[][]
            {
                new char[]{'.','1','.' },
                new char[]{'#','#','#' },
                new char[]{'.','1','#' },
                new char[]{'.','#','1' },
            };

            var graph = new MazeGraph(maze);

            var neighborCount = new int[,]
            {
                {
                    1,2,1
                },
                {
                    0,0,0
                },
                {
                    2,1,0
                },
                {
                    1,0,0
                }
            };


            Assert.AreEqual(7, graph.Vertices.Count);

            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (graph.Neighbors.ContainsKey((i, j)))
                    {
                        Assert.AreEqual(neighborCount[i, j], graph.Neighbors[(i, j)].Count);
                    }
                    else
                    {
                        Assert.IsTrue(0 == neighborCount[i, j]);
                    }
                }
            }
        }

        [TestMethod]
        [DataRow(0, 0, 0, 1, 1)]
        [DataRow(0, 0, 0, 3, 3)]
        [DataRow(2, 0, 2, 3, 3)]
        [DataRow(0, 0, 3, 0, -2147483648)]
        public void VerifyCalculatedDistances(int firstX, int firstY, int secX, int secY, int distance)
        {
            var maze = new char[][]
            {
                new char[]{'.','1','.','1','1','1','#' },
                new char[]{'#','#','#','#','#','#','#' },
                new char[]{'.','1','1','1','1','1','#' },
                new char[]{'.','#','1','#','#','1','1'},
            };

            var graph = new MazeGraph(maze);

            Assert.AreEqual(distance, graph.CalculateDistance((firstX, firstY), (secX, secY)));
        }
    }
}