using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day18
    {

        public static long CalculateSolution(string[] data, bool plusHasPrecedence)
        {
            var sum = 0L;
            foreach (var item in data)
            {
                sum += long.Parse(ProcessString(item, plusHasPrecedence));
            }
            return sum;
        }

        public static string ProcessString(string expression, bool plusHasPrecedence)
        {
            while (expression.Split('(').Length > 1)
            {
                var closest = expression.Length - 1;
                for (var i = expression.Length - 1; i >= 0; i--)
                {
                    if (expression[i] == ')')
                    {
                        closest = i;
                    }
                    else if (expression[i] == '(')
                    {
                        var group = expression.Substring(i + 1, closest - i - 1);
                        var total = ProcessString(group, plusHasPrecedence);
                        expression = expression.Replace($"({group})", total.ToString());
                        break;
                    }
                }
            }

            if (plusHasPrecedence)
            {
                return CalculateExpressionPlusHasPrecedence(expression).ToString();
            }
            else
            {
                return CalculateExpressionNormal(expression).ToString();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long CalculateExpressionNormal(string expression)
        {
            long total = 0;
            var lastOperand = -1;
            var lastExpressionWasAdd = true;
            for (var i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+')
                {
                    ProcessOperandEnd(i);
                    lastExpressionWasAdd = true;
                }
                else if (expression[i] == '*')
                {
                    ProcessOperandEnd(i);
                    lastExpressionWasAdd = false;
                }
            }

            ProcessOperandEnd(expression.Length);

            return total;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void ProcessOperandEnd(int end)
            {
                if (lastExpressionWasAdd)
                {
                    total += long.Parse(expression[(lastOperand + 1)..end]);
                }
                else
                {
                    total *= long.Parse(expression[(lastOperand + 1)..end]);
                }
                lastOperand = end;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long CalculateExpressionPlusHasPrecedence(string expression)
        {
            var parts = expression.Split(' ');
            var numbers = new Stack<long>(parts.Length);
            numbers.Push(long.Parse(parts[0]));
            for (var i = 0; i < parts.Length - 2; i += 2)
            {
                if (parts[i + 1] == "+")
                {
                    var lastNumber = numbers.Pop();
                    numbers.Push(lastNumber + long.Parse(parts[i + 2]));
                }
                else
                {
                    numbers.Push(long.Parse(parts[i + 2]));
                }
            }
            var result = 1L;
            foreach (var item in numbers)
            {
                result *= item;
            }
            return result;
        }

    }
}
