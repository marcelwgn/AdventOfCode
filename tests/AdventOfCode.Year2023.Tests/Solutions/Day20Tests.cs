using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day20Tests
	{
		private static readonly string[] firstExample = [
			"broadcaster -> a, b, c",
			"%a -> b",
			"%b -> c",
			"%c -> inv",
			"&inv -> a",
		];
		
		private static readonly string[] secondExample = [
			"broadcaster -> a",
			"%a -> inv, con",
			"&inv -> b",
			"%b -> con",
			"&con -> output",
		];

		private static int GetCountOfType(PulseModuleMachine pulseModuleMachine, Type type) => pulseModuleMachine.Modules.Values.Where(x => x.GetType() == type).Count();

		[TestMethod]
		public void VerifyConvertFirstExample()
		{
			var parsed = Day20.Convert(firstExample);

			Assert.HasCount(5, parsed.Modules);
			Assert.AreEqual(1, GetCountOfType(parsed, typeof(BroadCastModule)));
			Assert.AreEqual(3, GetCountOfType(parsed, typeof(FlipFlopModule)));
			Assert.AreEqual(1, GetCountOfType(parsed, typeof(ConjunctionModule)));
		}

		[TestMethod]
		public void VerifySendBroadcastFirstExample()
		{
			var parsed = Day20.Convert(firstExample);

			var (LowPulses, HighPulses,_) = parsed.SendHighPulse();

			Assert.AreEqual(8, LowPulses);
			Assert.AreEqual(4, HighPulses);
		}

		[TestMethod]
		public void VerifyConvertSecondExample()
		{
			var parsed = Day20.Convert(secondExample);

			Assert.HasCount(6, parsed.Modules);
			Assert.AreEqual(1, GetCountOfType(parsed, typeof(BroadCastModule)));
			Assert.AreEqual(2, GetCountOfType(parsed, typeof(FlipFlopModule)));
			Assert.AreEqual(2, GetCountOfType(parsed, typeof(ConjunctionModule)));
		}

		[TestMethod]
		public void VerifyFirstProblemFirstExample()
		{
			var parsed = Day20.Convert(firstExample);

			Assert.AreEqual(32000000, Day20.FirstProblem(parsed));
		}

		[TestMethod]
		public void VerifyFirstProblemSecondExample()
		{
			var parsed = Day20.Convert(secondExample);

			Assert.AreEqual(11687500, Day20.FirstProblem(parsed));
		}
	}
}
