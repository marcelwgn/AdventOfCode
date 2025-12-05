namespace AdventOfCode.Year2016.Solutions;

public record struct Day21TextInstruction(string Operation, char? FirstChar, char? SecondChar, int? FirstIndex, int? SecondIndex, bool IndexBased);

public static class Day21
{
    public static Day21TextInstruction[] Convert(string[] data)
    {
        var result = new Day21TextInstruction[data.Length];
        for (var i = 0; i < data.Length; i++)
        {
            var split = data[i].Split(' ');
            if (split[0] == "swap")
            {
                if (split[1] == "position")
                {
                    result[i] = new Day21TextInstruction("SWAP", null, null, int.Parse(split[2]), int.Parse(split[5]), true);
                }
                else
                {
                    result[i] = new Day21TextInstruction("SWAP", split[2][0], split[5][0], null, null, default);
                }
            }
            else if (split[0] == "reverse")
            {
                result[i] = new Day21TextInstruction("REVERSE", null, null, int.Parse(split[2]), int.Parse(split[4]), true);
            }
            else if (split[0] == "rotate")
            {
                if (split[1] == "based")
                {
                    result[i] = new Day21TextInstruction("ROTATE", split[6][0], null, null, null, default);
                }
                else
                {
                    result[i] = new Day21TextInstruction("ROTATE", null, null, split[1] == "left" ? -1 * int.Parse(split[2]) : int.Parse(split[2]), null, true);
                }
            }
            else if (split[0] == "move")
            {
                result[i] = new Day21TextInstruction("MOVE", null, null, int.Parse(split[2]), int.Parse(split[5]), true);
            }
        }

        return result;
    }
    public static string FirstProblem(Day21TextInstruction[] instructions)
    {
        var password = "abcdefgh";
        foreach (var instruction in instructions)
        {
            password = ProcessInstruction(password, instruction);
        }
        return password;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "Its fine here")]
    public static string SecondProblem(Day21TextInstruction[] instructions)
    {
        var randomPassword = "abcdefgh";
        // There are only 8! = 40320 options, we are brute forcing them
        while (processPassword(randomPassword) != "fbgdceah")
        {
            randomPassword = generateRandomPassword();
        }
        return randomPassword;

        string generateRandomPassword()
        {
            var rnd = new Random();
            return string.Join(null, "abcdefgh".OrderBy(x => rnd.Next()).ToArray());
        }

        string processPassword(string password)
        {
            foreach (var instruction in instructions)
            {
                password = ProcessInstruction(password, instruction);
            }
            return password;
        }
    }

    public static string ProcessInstruction(string data, Day21TextInstruction instruction)
    {
        var charArray = data.ToCharArray();
        switch (instruction.Operation)
        {
            case "MOVE":
                var cutIndex = instruction.FirstIndex!.Value;
                var insertIndex = instruction.SecondIndex!.Value;
                var asList = charArray.ToList();
                asList.RemoveAt(cutIndex);
                asList.Insert(insertIndex, charArray[cutIndex]);
                charArray = [.. asList];
                break;
            case "ROTATE":
                var rotateValue = instruction.IndexBased ? instruction.FirstIndex!.Value : data.IndexOf(instruction.FirstChar!.Value) + 1;
                RotateCharArray(charArray, rotateValue);
                if (rotateValue >= 5 && !instruction.IndexBased)
                {
                    RotateCharArray(charArray, 1);
                }
                break;
            case "REVERSE":
                Array.Reverse(charArray, instruction.FirstIndex!.Value, instruction.SecondIndex!.Value - instruction.FirstIndex.Value + 1);
                break;
            case "SWAP":
                if (instruction.IndexBased)
                {
                    var prevFirst = charArray[instruction.FirstIndex!.Value];
                    charArray[instruction.FirstIndex.Value] = charArray[instruction.SecondIndex!.Value];
                    charArray[instruction.SecondIndex.Value] = prevFirst;
                }
                else
                {
                    var firstIndex = data.IndexOf(instruction.FirstChar!.Value);
                    var secondIndex = data.IndexOf(instruction.SecondChar!.Value);
                    charArray[firstIndex] = instruction.SecondChar.Value;
                    charArray[secondIndex] = instruction.FirstChar.Value;
                }
                break;
        }
        return string.Join(null, charArray);

        static void RotateCharArray(char[] charArray, int rotateValue)
        {
            var rightBasedShift = (rotateValue + charArray.Length) % charArray.Length;
            var buffer = new char[rightBasedShift];
            Array.Copy(charArray, charArray.Length - rightBasedShift, buffer, 0, rightBasedShift);
            Array.Copy(charArray, 0, charArray, rightBasedShift, charArray.Length - rightBasedShift);
            Array.Copy(buffer, 0, charArray, 0, rightBasedShift);
        }
    }
}
