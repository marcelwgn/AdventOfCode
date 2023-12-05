using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day19
    {
        public static int CalculateSolution(string[] data, bool part2Modifications)
        {
            var splitIndex = Array.IndexOf(data, "");
            var ruleMap = CreateRuleMap(data[0..splitIndex]);
            var regexMap = new Dictionary<int, string>();
            // Get initial 0 regex
            GetRegex(0, ruleMap, regexMap);

            if (part2Modifications)
            {
                // Modifications specifically for part 2 with theoretical infinite expansion
                regexMap[8] = $"({GetRegex(42, ruleMap, regexMap)}+)";

                var rule42 = GetRegex(42, ruleMap, regexMap);
                var rule31 = GetRegex(31, ruleMap, regexMap);

                var expansionDepth = 10;
                var result = "(";
                for (var i = 1; i < expansionDepth; i++)
                {
                    if (i > 1)
                    {
                        result += '|';
                    }
                    result += '(';
                    for (var j = 0; j < i; j++)
                    {
                        result += rule42;
                    }
                    for (var j = 0; j < i; j++)
                    {
                        result += rule31;
                    }
                    result += ')';
                }
                regexMap[11] = result + ")";

                regexMap.Remove(0);
            }

            var regex = $"^{GetRegex(0, ruleMap, regexMap)}$";
            var count = 0;
            for (var i = splitIndex; i < data.Length; i++)
            {
                if (Regex.IsMatch(data[i], regex))
                {
                    count++;
                }
            }
            return count;
        }

        public static Dictionary<int, string> CreateRuleMap(string[] lines)
        {
            var ruleMap = new Dictionary<int, string>(lines.Length);
            foreach (var line in lines)
            {
                var numRule = line.Split(": ");
                ruleMap[int.Parse(numRule[0])] = numRule[1];
            }
            return ruleMap;
        }

        public static string GetRegex(int rule, Dictionary<int, string> ruleMap, Dictionary<int, string> regexMap)
        {
            if (regexMap.ContainsKey(rule))
            {
                return regexMap[rule];
            }

            var line = ruleMap[rule];
            if (line[0] == '"')
            {
                return line[1].ToString();
            }
            else
            {
                var result = "(";
                foreach (var part in line.Split(' '))
                {
                    if (int.TryParse(part, out var n))
                    {
                        result += GetRegex(n, ruleMap, regexMap);
                    }
                    else if (part[0] == '|')
                    {
                        result += '|';
                    }
                }
                result += ")";
                regexMap[rule] = result;
                return result;
            }
        }
    }
}
