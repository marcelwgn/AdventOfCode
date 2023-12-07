namespace AdventOfCode.Runner.Infrastructure
{
	public static class SolutionResolver
	{
		public static Type? FindSolutionSolver(int day, int year)
		{
			var assemblyName = $"AdventOfCode.Year{year}";
			var namespaceName = $"AdventOfCode.Year{year}.Solutions";
			var dayFormatted = day < 10 ? "0" + day : day.ToString();
			return Type.GetType($"{namespaceName}.Day{dayFormatted}, {assemblyName}");
		}
	}
}
