using AdventOfCode.Runner.Infrastructure;

var today = DateTime.Now;
var dayToRun = today.Day;
var yearToRun = today.Year;

Console.Write($"Enter day and year separated by space (currently '{dayToRun} {yearToRun}'):" + Environment.NewLine);
var readInput = Console.ReadLine();

if (!string.IsNullOrEmpty(readInput))
{
	var split = readInput.Split(" ");
	if (split.Length > 2)
	{
		if (int.TryParse(split[0], out int enteredDay))
		{
			dayToRun = enteredDay;
		}
		if (int.TryParse(split[1], out int enteredYear))
		{
			yearToRun = enteredYear;
		}
	}
}

Console.WriteLine($"Running solution for day {dayToRun} and year {yearToRun}...");

var type = SolutionResolver.FindSolutionSolver(dayToRun, yearToRun);
if (type is not null)
{
	SolutionRunner.RunSolution(type);
}
