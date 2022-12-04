using System;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day04
    {
        private static readonly ColorConverter colorConverter = new();

        public static int FirstProblem(string[] data)
        {
            var entries = string.Join(';', data).Split(";;");
            return entries.Count(e => IsValidFirstProblem(e));
        }
        public static int SecondProblem(string[] data)
        {
            var entries = string.Join(';', data).Split(";;");
            return entries.Count(e => IsValidSecondProblem(e));
        }

        private static bool IsValidFirstProblem(string passport)
        {
            return passport.Contains("byr:")
                && passport.Contains("iyr:")
                && passport.Contains("eyr:")
                && passport.Contains("hgt:")
                && passport.Contains("hcl:")
                && passport.Contains("ecl:")
                && passport.Contains("pid:");
        }
        private static bool IsValidSecondProblem(string passport)
        {
            passport = passport.Replace(';', ' ');
            var fields = passport.Split(' ');
            if (!IsValidFirstProblem(passport))
            {
                return false;
            }
            return fields.All(field =>
            {
                var split = field.Split(':');
                var value = split[1];
                try
                {
                    switch (split[0])
                    {
                        case "byr":
                            var birthYear = int.Parse(value);
                            return value.Length == 4 && birthYear >= 1920 && birthYear <= 2002;
                        case "iyr":
                            var issueYear = int.Parse(value);
                            return value.Length == 4 && issueYear >= 2010 && issueYear <= 2020;
                        case "eyr":
                            var expYear = int.Parse(value);
                            return value.Length == 4 && expYear >= 2020 && expYear <= 2030;
                        case "hgt":
                            var height = int.Parse(value[0..^2]);
                            return value.Contains("cm") ? height >= 150 && height <= 193 : height >= 59 && height <= 76;
                        case "hcl":
                            try
                            {
                                colorConverter.ConvertFromString(value);
                                return true;
                            }
                            catch (NotSupportedException)
                            {
                                return false;
                            }
                        case "ecl":
                            return value == "amb" || value == "blu" || value == "brn" || value == "gry" || value == "grn" || value == "hzl" || value == "oth";
                        case "pid":
                            return value.Length == 9 && int.Parse(value) >= 0;
                        default:
                            return true;
                    }
                }
#pragma warning disable CA1031
                catch (Exception)
                {
                    return false;
                }
#pragma warning restore CA1031
            });


        }

    }
}
