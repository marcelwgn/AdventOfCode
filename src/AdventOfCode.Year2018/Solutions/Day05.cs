using System;
using System.Threading.Tasks;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day05
    {

        public static string Convert(string[] data)
        {
            return data[0];
        }

        public static Tuple<string, bool> Polymer(string data)
        {
            var changed = false;
            for (var i = 97; i < 123; i++)
            {
                var current = (char)i;
                var curUpper = char.ToUpper(current);
                var act = new string(new char[] { current, curUpper });

                if (data.IndexOf(act) > -1)
                {
                    data = data.Replace(act, "");
                    changed = true;
                    break;
                }

                act = new string(new char[] { curUpper, current });

                if (data.IndexOf(act) > -1)
                {
                    data = data.Replace(act, "");
                    changed = true;
                    break;
                }
            }
            return new Tuple<string, bool>(data, changed);

        }

        public static int FirstProblem(string data)
        {
            var result = Polymer(data);

            var changed = result.Item2;

            while (changed)
            {
                result = Polymer(result.Item1);
                changed = result.Item2;
            }

            return result.Item1.Length;
        }

        public static int SecondProblem(string data)
        {
            var result = data.Length;
            Parallel.For(97, 123, index =>
            {
                var current = (char)index;
                var curUpper = char.ToUpper(current);

                var newData = data.Replace(new string(new char[] { current }), "");
                newData = newData.Replace(new string(new char[] { curUpper }), "");

                var foldingTry = FirstProblem(newData);
                if (result > foldingTry)
                {
                    result = foldingTry;
                }

            });
            return result;

        }

    }
}
