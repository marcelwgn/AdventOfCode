using AdventOfCode.Year2022.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCode.Year2022.Tests.Solutions
{
    [TestClass]
    public class Day07Tests
    {

        private static readonly string[] DATA =
		[
			"$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k",
        ];
        [TestMethod]
        public void VerifyConvert()
        {
            var node = Day07.Convert(DATA);
            var aFolder = node.Children.Where(x => x.Name == "a").First();
            Assert.AreEqual(94853, aFolder.CalculatedSize);
        }

        [TestMethod]
        public void VerifyFirstProblem()
        {
            var node = Day07.Convert(DATA);

            Assert.AreEqual(95437, Day07.FirstProblem(node));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            var node = Day07.Convert(DATA);

            Assert.AreEqual(24933642, Day07.SecondProblem(node));
        }
    }
}
