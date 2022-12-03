using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Solutions
{

    public static class Day02
    {
        public static string FirstProblem(string[] data)
        {
            var lastPos = (1, 1);
            var result = "";
            foreach (var item in data)
            {
                lastPos = NextPosition(item, lastPos, IsValidPosition);
                result += lastPos.Item1 + 1 + lastPos.Item2 * 3;
            }
            return result;

            bool IsValidPosition((int posX, int posY) position)
            {
                return position.posX >= 0 && position.posX <= 2 && position.posY >= 0 && position.posY <= 2;
            }
        }

        public static string SecondProblem(string[] data)
        {
            Dictionary<(int, int), char> keypad = new()
            {
                { (0, 2), '5' },
                { (1, 1), '2' },
                { (1, 2), '6' },
                { (1, 3), 'A' },
                { (2, 0), '1' },
                { (2, 1), '3' },
                { (2, 2), '7' },
                { (2, 3), 'B' },
                { (2, 4), 'D' },
                { (3, 1), '4' },
                { (3, 2), '8' },
                { (3, 3), 'C' },
                { (4, 2), '9' },
            };

            var lastPos = (0, 2);
            var result = "";
            foreach (var item in data)
            {
                lastPos = NextPosition(item, lastPos, IsValidPosition);
                result += keypad[lastPos];
            }
            return result;

            bool IsValidPosition((int posX, int posY) position)
            {
                return keypad.ContainsKey(position);
            }
        }

        private static (int, int) NextPosition(string instructions, (int posX, int posY) lastPos, Func<(int, int), bool> isValidPosition)
        {
            var (newPosX, newPosY) = lastPos;

            foreach (var character in instructions)
            {
                switch (character)
                {
                    case 'U':
                        if (!isValidPosition((newPosX, newPosY - 1)))
                        {
                            break;
                        }
                        newPosY--;
                        break;
                    case 'L':
                        if (!isValidPosition((newPosX - 1, newPosY)))
                        {
                            break;
                        }
                        newPosX--;
                        break;
                    case 'D':
                        if (!isValidPosition((newPosX, newPosY + 1)))
                        {
                            break;
                        }
                        newPosY++;
                        break;
                    case 'R':
                        if (!isValidPosition((newPosX + 1, newPosY)))
                        {
                            break;
                        }
                        newPosX++;
                        break;
                }
            }

            return (newPosX, newPosY);
        }
    }
}
