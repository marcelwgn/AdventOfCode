using System;
using System.Threading.Tasks;

namespace AdventOfCode2018.Solutions
{
    public static class Day05
    {

        public static string Convert(string[] data)
        {
            return data[0];
        }

        public static Tuple<string, bool> Polymer(string data)
        {
            bool changed = false;
            for (int i = 97; i < 123; i++)
            {
                char current = (char)i;
                char curUpper = char.ToUpper(current);
                string act = new string(new char[] { current, curUpper });

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
            Tuple<string, bool> result = Day05.Polymer(data);

            bool changed = result.Item2;

            while (changed)
            {
                result = Day05.Polymer(result.Item1);
                changed = result.Item2;
            }

            return result.Item1.Length;
        }

        public static int SecondProblem(string data)
        {
            int result = data.Length;
            Parallel.For(97, 123, index =>
            {
                char current = (char)index;
                char curUpper = char.ToUpper(current);

                string newData = data.Replace(new string(new char[] { current }), "");
                newData = newData.Replace(new string(new char[] { curUpper }), "");

                int foldingTry = FirstProblem(newData);
                if (result > foldingTry)
                {
                    result = foldingTry;
                }

            });
            return result;

        }

    }
}
