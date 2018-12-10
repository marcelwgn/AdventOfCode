using System;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions {
  public class Day05 {

    public static String convert(String[] data) {
      return data[0];
    }

    public static Tuple<string, bool> polymer(String data) {
      bool changed = false;
      for (int i = 97; i < 123; i++) {
        char current = (char)i;
        char curUpper = Char.ToUpper(current);
        String act = new string(new char[] { current, curUpper });

        if (data.IndexOf(act) > -1) {
          data = data.Replace(act, "");
          i = 150;
          changed = true;
          break;
        }

        act = new string(new char[] { curUpper, current });

        if (data.IndexOf(act) > -1) {
          data = data.Replace(act, "");
          i = 150;
          changed = true;
          break;
        }
      }
      return new Tuple<String, bool>(data, changed);

    }

    public static int firstProblem(String data) {
      Tuple<String, bool> result = Day05.polymer(data);

      bool changed = result.Item2;

      while (changed) {
        result = Day05.polymer(result.Item1);
        changed = result.Item2;
      }

      return result.Item1.Length;
    }

    public static int secondProblem(string data) {
      int result = data.Length;
      Parallel.For(97, 123, index => {
        char current = (char)index;
        char curUpper = Char.ToUpper(current);

        String newData = data.Replace(new String(new char[] { current }), "");
        newData = newData.Replace(new String(new char[] { curUpper }), "");

        int foldingTry = firstProblem(newData);
        if (result > foldingTry) {
          result = foldingTry;
        }

      });
      return result;

    }

  }
}
