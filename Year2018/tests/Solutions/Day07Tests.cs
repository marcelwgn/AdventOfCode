using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day07Tests
    {

        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            Model.NodeList<string> converted = Day07.Convert(data);
            converted.Sort();
            Assert.AreEqual(6, converted.Count);

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(65 + i, converted[i].Name[0]);

            }
        }


        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };
            Model.NodeList<string> converted = Day07.Convert(data);
            string value = Day07.FirstProblem(converted);

            Assert.AreEqual("CABDFE", value);

        }
        [TestMethod()]
        public void SecondProblemTest()
        {
            string[] data = {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };
            Model.NodeList<string> converted = Day07.Convert(data);
            int value = Day07.SecondProblem(converted);

            Assert.AreEqual(253, value);
        }
    }
}
