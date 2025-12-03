# Get current date for defaults
$currentDay = (Get-Date).Day
$currentYear = (Get-Date).Year

# Prompt user for day and year
$day = Read-Host "Enter day [$currentDay]"
if ([string]::IsNullOrWhiteSpace($day)) {
	$day = $currentDay
}

$year = Read-Host "Enter year [$currentYear]"
if ([string]::IsNullOrWhiteSpace($year)) {
	$year = $currentYear
}

# Pad day with leading zero if needed
$dayPadded = $day.ToString().PadLeft(2, '0')

# Define paths
$solutionDir = "src/AdventOfCode.Year$year/Solutions"
$testDir = "tests/AdventOfCode.Year$year.Tests/Solutions"
$solutionFile = "$solutionDir/Day$dayPadded.cs"
$testFile = "$testDir/Day$dayPadded`Tests.cs"

# Create directories if they don't exist
if (!(Test-Path $solutionDir)) {
	New-Item -ItemType Directory -Path $solutionDir | Out-Null
}
if (!(Test-Path $testDir)) {
	New-Item -ItemType Directory -Path $testDir | Out-Null
}

# Solution file content
$solutionContent = @"
namespace AdventOfCode.Year$year.Solutions;

public static class Day$dayPadded
{
	public static string FirstProblem(string[] input)
	{
		return string.Empty;
	}

	public static string SecondProblem(string[] input)
	{
		return string.Empty;
	}
}
"@

# Test file content
$testContent = @"
namespace AdventOfCode.Year$year.Tests.Solutions;

[TestClass]
public class Day$dayPadded`Tests
{
	string[] sampleInput = [];

	[TestMethod]
	public void VerifyFirstProblem()
	{
		var result = Year$year.Solutions.Day$dayPadded`.FirstProblem(sampleInput);

		Assert.AreEqual("", result);
	}

	[TestMethod]
	public void VerifySecondProblem()
	{
		var result = Year$year.Solutions.Day$dayPadded`.SecondProblem(sampleInput);

		Assert.AreEqual("", result);
	}
}
"@

# Write files
Set-Content -Path $solutionFile -Value $solutionContent
Set-Content -Path $testFile -Value $testContent

Write-Host "Created files:" -ForegroundColor Green
Write-Host "  $solutionFile"
Write-Host "  $testFile"