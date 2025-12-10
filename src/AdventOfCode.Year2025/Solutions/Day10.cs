using System.Collections.Specialized;
using System.Diagnostics;

namespace AdventOfCode.Year2025.Solutions;

file sealed class Machine
{
    public record struct Button(List<int> listLightToggles);

    public List<Button> listbutton;

    public bool[] listfDesiredStatesLight;
    public int[] listcesiredJottages;
    public Machine(string input)
    {
        var parts = input.Split(' ');
        this.listfDesiredStatesLight = parts[0][1..^1].Select(c => c == '#').ToArray();
        this.listcesiredJottages = parts[^1][1..^1].Split(",").Select(st => int.Parse(st)).ToArray();
        var buttonsParts = parts[1..^1];
        listbutton = new List<Button>();
        foreach (var buttonPart in buttonsParts)
        {
            var toggles = buttonPart.Trim('(', ')').Split(',').Select(int.Parse).ToList();
            listbutton.Add(new Button(toggles));
        }
    }

    public bool[] ListFAfterButtonPress(bool[] listFOldState, List<int> buttonPressSequence)
    {
        var listFNewState = new bool[listfDesiredStatesLight.Length];
        listFOldState.CopyTo(listFNewState);
        foreach (var iLight in buttonPressSequence)
        {
            listFNewState[iLight] = !listFOldState[iLight];
        }
        return listFNewState;
    }

    public int[] ListCAfterButtonPressSubtractedUntilZero(int[] listCOldJottages, List<int> buttonPressSequence, out int cIterations, int cMax = int.MaxValue)
    {
        var listCNewJottages = new int[listcesiredJottages.Length];
        listCOldJottages.CopyTo(listCNewJottages);
        // Apply button presses until another application would get below zero
        cIterations = cMax;
        foreach (var iJottage in buttonPressSequence)
        {
            cIterations = Math.Min(cIterations, listCNewJottages[iJottage]);
        }

        for (int i = 0; i < cIterations; i++)
        {
            foreach (var iJottage in buttonPressSequence)
            {
                listCNewJottages[iJottage]--;
            }
        }

        return listCNewJottages;
    }
}

public static class Day10
{
    public static string FirstProblem(string[] input)
    {
        var cTotal = 0;

        foreach (var st in input)
        {
            var machine = new Machine(st);

            // Do a breadth-first search to find the shortest sequence of button presses
            var queue = new Queue<(int cButtonsPressed, bool[] currentState)>();
            queue.Enqueue((0, new bool[machine.listfDesiredStatesLight.Length]));

            HashSet<string> visitedState = new HashSet<string>();

            while (queue.Count > 0)
            {
                var (cButtonsPressed, currentState) = queue.Dequeue();

                // Check if the current state matches the desired state
                if (currentState.SequenceEqual(machine.listfDesiredStatesLight))
                {
                    cTotal += cButtonsPressed;
                    break;
                }

                // Explore the next states by pressing each button
                foreach (var button in machine.listbutton)
                {
                    var newState = machine.ListFAfterButtonPress(currentState, button.listLightToggles);
                    var stateHash = string.Join("", newState.Select(b => b ? 1 : 0));
                    if (visitedState.Add(stateHash))
                    {
                        queue.Enqueue((cButtonsPressed + 1, newState));
                    }
                }
            }
        }

        return cTotal.ToString();
    }

    public static string SecondProblem(string[] input)
    {
        long cTotal = 0;

        foreach (var st in input)
        {
            var machine = new Machine(st);

            //// Do a breadth-first search to find the shortest sequence of button presses
            var queue = new Queue<(int cCurrent, int[] currentState)>();
            var listcInitialState = new int[machine.listcesiredJottages.Length];
            machine.listcesiredJottages.CopyTo(listcInitialState);
            queue.Enqueue((0, listcInitialState));

            HashSet<string> visitedState = new HashSet<string>();
            int cMin = int.MaxValue;
            while (queue.Count > 0)
            {
                var (cButtonsPressed, listcCur) = queue.Dequeue();

                if (cButtonsPressed >= cMin)
                {
                    continue;
                }

                // If none found, we are done
                if (listcCur.All(c => c == 0))
                {
                    cMin = Math.Min(cMin, cButtonsPressed);
                    continue;
                }

                foreach (var button in machine.listbutton)
                {
                    // Enqueue new state after we applied the button to the max
                    var listcNew = machine.ListCAfterButtonPressSubtractedUntilZero(listcCur, button.listLightToggles, out int cIterations, int.MaxValue);
                    int cNew = cButtonsPressed + cIterations;
                    string stHash = cNew + ":" + string.Join(",", listcNew);

                    if (cIterations != 0)
                        queue.Enqueue((cNew, listcNew));
                }
            }

            Debug.Assert(cMin != int.MaxValue, "No solution found");
            cTotal += cMin;
        }

        return cTotal.ToString();
    }

    public static string SecondProblemOptimizedV2(string[] input)
    {
        long cTotal = 0;

        foreach (var st in input)
        {
            var machine = new Machine(st);

            //// Do a breadth-first search to find the shortest sequence of button presses
            var queue = new Queue<(int cCurrent, int[] currentState)>();
            var listcInitialState = new int[machine.listcesiredJottages.Length];
            machine.listcesiredJottages.CopyTo(listcInitialState);
            queue.Enqueue((0, listcInitialState));

            HashSet<string> visitedState = new HashSet<string>();
            int cMin = int.MaxValue;
            while (queue.Count > 0)
            {
                var (cButtonsPressed, listcCur) = queue.Dequeue();

                if (cButtonsPressed >= cMin)
                {
                    continue;
                }

                //Find smallest positive jottage
                List<int> listiSmallest = new List<int>();
                int cSmallest = listcCur.Min();
                for (int i = 0; i < listcCur.Length; i++)
                {
                    if (listcCur[i] == cSmallest)
                    {
                        listiSmallest.Add(i);
                    }
                }

                // If none found, we are done
                if (cSmallest == 0)
                {
                    cMin = Math.Min(cMin, cButtonsPressed);
                    continue;
                }

                var cDeltaToSecondSmallest = int.MaxValue;
                for (int i = 0; i < listcCur.Length; i++)
                {
                    cDeltaToSecondSmallest = Math.Min(cDeltaToSecondSmallest, listcCur[i] - cSmallest);
                }

                foreach (var button in machine.listbutton)
                {
                    if (!button.listLightToggles.Any(ilight => listiSmallest.Contains(ilight)))
                    {
                        continue;
                    }

                    bool fExceeds = false;
                    foreach (var iJottage in button.listLightToggles)
                    {
                        if (listcCur[iJottage] <= 0)
                        {
                            fExceeds = true;
                            break;
                        }
                    }

                    if (fExceeds)
                    {
                        continue;
                    }

                    // Enqueue new state after we applied the button to the max
                    var listcNew = machine.ListCAfterButtonPressSubtractedUntilZero(listcCur, button.listLightToggles, out int cIterations, cMax: cDeltaToSecondSmallest);
                    queue.Enqueue((cButtonsPressed + cIterations, listcNew));
                }
            }

            Debug.Assert(cMin != int.MaxValue, "No solution found");
            cTotal += cMin;
        }

        return cTotal.ToString();
    }

    public static string SecondProblemOptimized(string[] input)
    {
        long cTotal = 0;

        foreach (var st in input)
        {
            var machine = new Machine(st);

            //// Do a breadth-first search to find the shortest sequence of button presses
            var queue = new Queue<(int cCurrent, int[] currentState)>();
            var listcInitialState = new int[machine.listcesiredJottages.Length];
            machine.listcesiredJottages.CopyTo(listcInitialState);
            queue.Enqueue((0, listcInitialState));

            HashSet<string> visitedState = new HashSet<string>();
            int cMin = int.MaxValue;
            while (queue.Count > 0)
            {
                var (cButtonsPressed, listcCur) = queue.Dequeue();

                if (cButtonsPressed >= cMin)
                {
                    continue;
                }

                //Find smallest positive jottage
                int iSmallest = -1;
                for (int i = 0; i < listcCur.Length; i++)
                {
                    if (listcCur[i] > 0 && (iSmallest == -1 || listcCur[i] < listcCur[iSmallest]))
                    {
                        iSmallest = i;
                    }
                }

                // If none found, we are done
                if (iSmallest == -1)
                {
                    cMin = Math.Min(cMin, cButtonsPressed);
                    continue;
                }

                foreach (var button in machine.listbutton)
                {
                    if (!button.listLightToggles.Contains(iSmallest))
                    {
                        continue;
                    }

                    bool fExceeds = false;
                    foreach (var iJottage in button.listLightToggles)
                    {
                        if (listcCur[iJottage] <= 0)
                        {
                            fExceeds = true;
                            break;
                        }
                    }

                    if (fExceeds)
                    {
                        continue;
                    }

                    // Enqueue new state after we applied the button to the max
                    var listcNew = machine.ListCAfterButtonPressSubtractedUntilZero(listcCur, button.listLightToggles, out int cIterations, int.MaxValue);
                    queue.Enqueue((cButtonsPressed + cIterations, listcNew));
                }
            }

            Debug.Assert(cMin != int.MaxValue, "No solution found");
            cTotal += cMin;
        }

        return cTotal.ToString();
    }
}
