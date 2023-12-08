
namespace AdventOfCode.Year2023.Solutions
{
	public record Day08ParsedInput(string Instructions, string FirstNode, Dictionary<string, (string Left, string Right)> Nodes);

	public static class Day08
	{
		public static Day08ParsedInput Convert(string[] data)
		{
			var instructions = data[0];

			var nodes = new Dictionary<string, (string Left, string Right)>();
			var (Name, Children) = Convert(data[2]);
			nodes.Add(Name, Children);

			for (int i = 3; i < data.Length; i++)
			{
				var node = Convert(data[i]);
				nodes.Add(node.Name, node.Children);
			}

			return new Day08ParsedInput(instructions, Name, nodes);

			static (string Name, (string Left, string Right) Children) Convert(string row)
			{
				return new(
					row[0..3],
					new(row[7..10],
					row[12..15])
				);
			}
		}

		public static int FirstProblem(Day08ParsedInput parsed)
		{
			var stepCounter = 0;
			var currentNode = parsed.FirstNode;
			while (currentNode != "ZZZ")
			{
				var (left, right) = parsed.Nodes[currentNode];
				var currentInstruction = parsed.Instructions[stepCounter++ % parsed.Instructions.Length];
				currentNode = currentInstruction == 'L' ? left : right;
			}
			return stepCounter;
		}

		public static long SecondProblem(Day08ParsedInput parsed)
		{
			// Idea: Loops must match, so we can calculate the loop size for each node 
			// and then find the least common multiple of all loop sizes since iterating might take ages
			var currentNodes = parsed.Nodes.Keys.Where(x => x[2] == 'A').ToArray();
			var loopSizes = currentNodes.Select(CalculateLoopSize).ToArray();

			for (int i = 0; i < currentNodes.Length; i++)
			{
				EnsureLoopSizeWorks(currentNodes[i], loopSizes[i]);
			}

			return LeastCommonMultiple(loopSizes);

			long CalculateLoopSize(string node)
			{
				var stepCounter = 0L;
				var currentNode = node;
				while (currentNode[2] != 'Z')
				{
					var (left, right) = parsed.Nodes[currentNode];
					var currentInstruction = parsed.Instructions[(int)(stepCounter++ % parsed.Instructions.Length)];
					currentNode = currentInstruction == 'L' ? left : right;
				}
				return stepCounter;
			}

			void EnsureLoopSizeWorks(string node, long loopSize)
			{
				var stepCounter = 0L;
				var currentNode = node;
				while (stepCounter < loopSize)
				{
					var (left, right) = parsed.Nodes[currentNode];
					var currentInstruction = parsed.Instructions[(int)(stepCounter++ % parsed.Instructions.Length)];
					currentNode = currentInstruction == 'L' ? left : right;
				}
				if (currentNode[2] != 'Z')
				{
					throw new ArgumentException("Does not adhere to LCM rule");
				}

				var currentSolution = currentNode;
				while (stepCounter < loopSize * 2)
				{
					var (left, right) = parsed.Nodes[currentNode];
					var currentInstruction = parsed.Instructions[(int)(stepCounter++ % parsed.Instructions.Length)];
					currentNode = currentInstruction == 'L' ? left : right;
				}
				if (currentNode != currentSolution)
				{
					throw new ArgumentException("Does not adhere to LCM rule");
				}
				if(loopSize % parsed.Instructions.Length != loopSize * 2 % parsed.Instructions.Length)
				{
					throw new ArgumentException("Does not adhere to LCM rule");
				}
			}
		}

		private static long LeastCommonMultiple(long[] values)
		{
			if (values.Length > 2)
			{
				return LeastCommonMultipleSingle(values[0], LeastCommonMultiple(values[1..]));
			}
			else
			{
				return LeastCommonMultipleSingle(values[0], values[1]);
			}

			static long LeastCommonMultipleSingle(long a, long b)
			{
				return a * b / GreatestCommonDivisor(a, b);
			}

			static long GreatestCommonDivisor(long a, long b)
			{
				while (b != 0)
				{
					long temp = b;
					b = a % b;
					a = temp;
				}
				return a;
			}
		}
	}
}