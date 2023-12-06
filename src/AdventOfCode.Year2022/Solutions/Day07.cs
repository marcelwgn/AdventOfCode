using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Solutions
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "We need to add items later so its fine")]
	public class FileSystemNode
	{
		public FileSystemNode? Parent { get; set; }
		public string Name { get; set; } = "/";
		public List<FileSystemNode> Children { get; } = [];
		public long Size { get; set; }
		public long CalculatedSize => Children.Sum(x => x.CalculatedSize) + Size;
		public bool IsFolder => Children.Count > 0;

		public override string ToString()
		{
			return Name + ": " + CalculatedSize;
		}
	}
	public static class Day07
    {

        public const long MAXSIZE = 40_000_000;

        public static FileSystemNode Convert(string[] data)
        {
            var rootNode = new FileSystemNode();
            var currentNode = rootNode;

            for (var i = 1; i < data.Length; i++)
            {
                // Skipping those entries
                if (data[i] == "$ ls" || data[i] == "$ cd /" || data[i].StartsWith("dir"))
                {
                    continue;
                }

                // Handling moving up
                if (data[i] == "$ cd ..")
                {
                    // If the parent does not exist, lets just fail through NRE
                    currentNode = currentNode.Parent!;
                    continue;
                }

                // Handling moving to new folder
                if (data[i].StartsWith("$ cd "))
                {
                    var folderName = data[i][5..];
                    var node = new FileSystemNode() { Name = folderName };
                    currentNode.Children.Add(node);
                    node.Parent = currentNode;
                    currentNode = node;
                    continue;
                }

                var parsed = data[i].Split(' ');
                var fileNode = new FileSystemNode()
                {
                    Name = parsed[1],
                    Size = long.Parse(parsed[0])
                };
                currentNode.Children.Add(fileNode);
                fileNode.Parent = currentNode;
            }

            return rootNode;
        }

        public static long FirstProblem(FileSystemNode item)
        {
            var folders = ListFolders(item);

            return folders.Where(x => x.Key <= 100_000).Sum(x => x.Value.CalculatedSize);
        }

        public static long SecondProblem(FileSystemNode node)
        {
            var spaceToClearUp = node.CalculatedSize - MAXSIZE;
            var folders = ListFolders(node);
            foreach (var item in folders)
            {
                if (item.Value.CalculatedSize >= spaceToClearUp)
                {
                    return item.Value.CalculatedSize;
                }
            }
            return -1;
        }

        static SortedList<long, FileSystemNode> ListFolders(FileSystemNode node)
        {
            var folders = new SortedList<long, FileSystemNode>(new DuplicateKeyComparer<long>());
            foreach (var child in node.Children)
            {
                if (child.IsFolder)
                {
                    var innerFolders = ListFolders(child);
                    foreach (var innerFolder in innerFolders)
                    {
                        folders.Add(innerFolder.Key, innerFolder.Value);
                    }
                }
            }
            folders.Add(node.CalculatedSize, node);
            return folders;
        }

        private class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey? x, TKey? y)
            {
                var result = x!.CompareTo(y!);
                return result == 0 ? 1 : result;
            }
        }
    }
}
