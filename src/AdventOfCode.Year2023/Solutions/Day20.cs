namespace AdventOfCode.Year2023.Solutions
{
	public class PulseModuleMachine
	{
		public Dictionary<string, PulseModule> Modules { get; init; } = [];

		public (int LowPulses, int HighPulses, bool EndModuleReceivedHigh) SendHighPulse(string moduleName = "broadcaster", string endModuleName = "")
		{
			var queueCommands = new Queue<(PulseModule Source, PulseModule Target, bool IsHighMode)>();
			queueCommands.Enqueue(new(new EmptyModule(), Modules[moduleName], false));

			var lowPulses = 0;
			var highPulses = 0;
			var endModuleLastReceivedValue = false;

			while (queueCommands.Count > 0)
			{
				var (Source, Target, IsHighMode) = queueCommands.Dequeue();

				if (IsHighMode)
				{

					if (Target.Name == endModuleName)
					{
						endModuleLastReceivedValue = true;
					}

					highPulses++;
				}
				else
				{
					lowPulses++;
				}
				var pulseResult = Target.ProcessPulse(Source, IsHighMode);

				if (pulseResult.IsHighMode != null)
				{
					foreach (var target in pulseResult.Targets)
					{
						queueCommands.Enqueue(new(Target, target, pulseResult.IsHighMode.Value));
					}
				}
			}

			return new(lowPulses, highPulses, endModuleLastReceivedValue);
		}

		public PulseModuleMachine GetSubGraph(string StartNodeName, string LastNodeName)
		{
			var nodes = new HashSet<PulseModule>();
			var nodesToVisit = new Queue<PulseModule>();
			nodesToVisit.Enqueue(Modules[StartNodeName]);

			while (nodesToVisit.Count > 0)
			{
				var current = nodesToVisit.Dequeue();
				nodes.Add(current);

				if (current.Name == LastNodeName) continue;

				foreach (var target in current.Targets)
				{
					if (!nodes.Contains(target))
					{
						nodesToVisit.Enqueue(target);
					}
				}
			}

			var modules = new Dictionary<string, PulseModule>();

			foreach (var item in nodes)
			{
				modules.TryAdd(item.Name, item);
			}

			return new PulseModuleMachine() { Modules = modules };
		}

		public void EnsureConnectedness()
		{
			var moduleTargets = Modules.Values.SelectMany(x => x.TargetNames).ToArray();

			// Ensuring every node named has a module associated
			foreach (var target in moduleTargets)
			{
				if (!Modules.ContainsKey(target))
				{
					Modules.Add(target, new EmptyModule() { Name = target });
				}
			}

			// Ensuring inputs and targets are properly mapped
			foreach (var module in Modules.Values)
			{
				module.Targets = module.TargetNames.Select(x => Modules[x]).ToArray();
				var inputs = Modules.Values.
					Where(x => x.TargetNames.Contains(module.Name));
				module.SetInputs(inputs);
			}
		}
	}

	public abstract class PulseModule
	{
		public string Name { get; set; } = "";

		public string[] TargetNames { get; set; } = [];
		public PulseModule[] Targets { get; set; } = [];

		public PulseModule[] Inputs { get; internal set; } = [];
		public abstract void SetInputs(IEnumerable<PulseModule> inputs);

		public abstract (PulseModule[] Targets, bool? IsHighMode) ProcessPulse(PulseModule source, bool isHighModePulse);
	}

	public class FlipFlopModule : PulseModule
	{
		private bool isOn;

		public override (PulseModule[], bool?) ProcessPulse(PulseModule source, bool isHighModePulse)
		{
			if (isHighModePulse) return ([], null);

			isOn = !isOn;

			return (Targets, isOn);
		}

		public override void SetInputs(IEnumerable<PulseModule> inputs)
		{
			Inputs = inputs.ToArray();
		}

		public override string ToString()
		{
			return Name + " - " + isOn;
		}
	}

	public class ConjunctionModule : PulseModule
	{
		private readonly Dictionary<string, bool> receivedSignals = [];


		public override void SetInputs(IEnumerable<PulseModule> inputs)
		{
			receivedSignals.Clear();
			Inputs = inputs.ToArray();
			foreach (var input in Inputs)
			{
				receivedSignals.Add(input.Name, false);
			}
		}

		public override (PulseModule[], bool?) ProcessPulse(PulseModule source, bool isHighModePulse)
		{
			receivedSignals[source.Name] = isHighModePulse;

			return (Targets, receivedSignals.Values.Any(x => x == false));
		}
	}

	public class BroadCastModule : PulseModule
	{
		public override (PulseModule[], bool?) ProcessPulse(PulseModule source, bool isHighModePulse)
		{
			return (Targets, isHighModePulse);
		}

		public override void SetInputs(IEnumerable<PulseModule> inputs)
		{
			Inputs = inputs.ToArray();
		}
	}

	public class EmptyModule : PulseModule
	{
		public override (PulseModule[], bool?) ProcessPulse(PulseModule source, bool isHighModePulse)
		{
			return ([], null);
		}

		public override void SetInputs(IEnumerable<PulseModule> inputs)
		{
			Inputs = inputs.ToArray();
		}
	}

	public static class Day20
	{
		public static PulseModuleMachine Convert(string[] data)
		{
			var modules = new Dictionary<string, PulseModule>();
			foreach (var item in data)
			{
				var split = item.Split(" -> ");
				var name = split[0];
				var targets = split[1].Split(", ").ToArray();

				if (name[0] == '%')
				{
					var module = new FlipFlopModule()
					{
						Name = name[1..],
						TargetNames = targets
					};
					modules.Add(name[1..], module);
				}
				else if (name[0] == '&')
				{
					var module = new ConjunctionModule()
					{
						Name = name[1..],
						TargetNames = targets
					};
					modules.Add(name[1..], module);
				}
				else
				{
					var module = new BroadCastModule()
					{
						Name = name,
						TargetNames = targets
					};
					modules.Add(name, module);
				}
			}

			var moduleTargets = modules.Values.SelectMany(x => x.TargetNames).ToArray();

			// Ensuring every node named has a module associated
			foreach (var target in moduleTargets)
			{
				if (!modules.ContainsKey(target))
				{
					modules.Add(target, new EmptyModule() { Name = target });
				}
			}

			// Ensuring inputs and targets are properly mapped
			foreach (var module in modules.Values)
			{
				module.Targets = module.TargetNames.Select(x => modules[x]).ToArray();
				var inputs = modules.Values.
					Where(x => x.TargetNames.Contains(module.Name));
				module.SetInputs(inputs);
			}

			return new PulseModuleMachine() { Modules = modules };
		}

		public static long FirstProblem(PulseModuleMachine pulseModuleMachine)
		{
			var lowCount = 0L;
			var highCount = 0L;

			for (int i = 0; i < 1000; i++)
			{
				var (LowResult, HighResult, _) = pulseModuleMachine.SendHighPulse();
				lowCount += LowResult;
				highCount += HighResult;
			}

			return lowCount * highCount;
		}

		public static long SecondProblem(PulseModuleMachine pulseModuleMachine)
		{
			// Assumption: There is a single conjunction feeding into rx
			// There are multiple circuits feeding into that node
			// They all are indepedent
			// That means, for that conjunction node to send a low pulse, all circuits need to send a high pulse
			// Calculate loop sizes and just use the product of all loop lengths

			// Getting loop starts
			var broadCasterTargets = pulseModuleMachine.Modules["broadcaster"].TargetNames;
			// Final conjunction node
			var endTargetName = pulseModuleMachine.Modules["rx"].Inputs.First().Name;
			// Sub graphs that create the loop
			var subGraphs = broadCasterTargets.Select(x => (x, pulseModuleMachine.GetSubGraph(x, endTargetName)));

			var result = 1L;
			foreach (var workItem in subGraphs)
			{
				result *= GetSmallestNumberToGetHighPulse(workItem.x, endTargetName, workItem.Item2);
			}

			return result;

			static long GetSmallestNumberToGetHighPulse(string startNodeName, string targetNodeName, PulseModuleMachine pulseModuleMachine)
			{
				long iterationCount = 0L;
				bool hasReceivedHigh = false;

				while (!hasReceivedHigh)
				{
					iterationCount++;
					var (LowPulses, HighPulses, EndModuleReceivedHigh) = pulseModuleMachine.SendHighPulse(startNodeName, targetNodeName);
					if (EndModuleReceivedHigh == true)
					{
						return iterationCount;
					}
				}

				return iterationCount;
			}
		}
	}
}
