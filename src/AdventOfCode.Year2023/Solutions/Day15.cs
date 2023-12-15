namespace AdventOfCode.Year2023.Solutions
{
	public static class Day15
	{
		private sealed record Lens(string Label)
		{
			public Lens(string label, int value) : this(label)
			{
				Label = label;
				Value = value;
			}

			public int Value { get; set; }
		};

		public static long FirstProblem(string[] data)
		{
			var currentValue = 0L;
			foreach (var item in data[0].Split(","))
			{
				currentValue += CalculateHash(item);
			}
			return currentValue;
		}

		public static long CalculateHash(string data)
		{
			var currentValue = 0;
			foreach (var item in data)
			{
				currentValue += item;
				currentValue *= 17;
				currentValue %= 256;
			}
			return currentValue;
		}

		public static long SecondProblem(string[] data)
		{
			var boxes = new List<Lens>[256];
			for (int i = 0; i < 256; i++)
			{
				boxes[i] = [];
			}


			foreach (var item in data[0].Split(","))
			{
				var splitIndex = Math.Max(item.IndexOf('-'), item.IndexOf('='));
				var label = item[..splitIndex];
				var hash = CalculateHash(label);

				if (item[splitIndex] == '-')
				{
					boxes[hash].RemoveAll(x => x.Label == label);
				}
				else
				{
					var value = int.Parse(item[(splitIndex + 1)..]);

					if (boxes[hash].Any(x => x.Label == label))
					{
						foreach (var lens in boxes[hash])
						{
							if (lens.Label == label)
							{
								lens.Value = value;
							}
						}
					}
					else
					{
						boxes[hash].Add(new Lens(label, value));
					}
				}
			}

			var totalPower = 0L;
			for (int i = 0; i < 256; i++)
			{
				var box = boxes[i];
				for (int j = 0; j < box.Count; j++)
				{
					var lens = box[j];
					totalPower += lens.Value * (j + 1) * (i + 1);
				}
			}
			return totalPower;
		}
	}
}
