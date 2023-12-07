using AdventOfCode.Runner.Infrastructure;

namespace AdventOfCode.Runner.Tests.Infrastructure
{
	[TestClass]
	public class SolutionResolverTests
	{
		[TestMethod]
		public void VerifyReturnsNullForInvalidDate()
		{
			Assert.IsNull(SolutionResolver.FindSolutionSolver(-1, 2000));
			Assert.IsNull(SolutionResolver.FindSolutionSolver(1, 2000));
		}

		[TestMethod]
		public void VerifyResolvesSolutionSolvers()
		{
			Assert.IsNotNull(SolutionResolver.FindSolutionSolver(1, 2016));
			Assert.IsNotNull(SolutionResolver.FindSolutionSolver(1, 2018));
			Assert.IsNotNull(SolutionResolver.FindSolutionSolver(1, 2019));
			Assert.IsNotNull(SolutionResolver.FindSolutionSolver(1, 2020));
			Assert.IsNotNull(SolutionResolver.FindSolutionSolver(1, 2022));
			Assert.IsNotNull(SolutionResolver.FindSolutionSolver(1, 2023));
		}
	}
}
