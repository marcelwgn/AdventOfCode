using System.Collections.Generic;
using AdventOfCode.Utils;

namespace AdventOfCode.Solutions {
  public class Day1 {
    public static int[] convert(string[] data) {
      return ConverterUtils.getNumbers(data);
    }

    public static int firstProblem(int[] data) {
      int sum = 0;
      foreach (int s in data) {
        sum += s;
      }
      return sum;
    }

    public static int secondProblem(int[] data) {
      List<int> calcedFreqs = new List<int>();
      bool freqDouble = false;

      int index = 0;
      int sum = 0;

      int dataSize = data.Length;
      while (!freqDouble) {
        //Already found
        if (calcedFreqs.Contains(sum)) {
          freqDouble = true;
          break;
        }

        calcedFreqs.Add(sum);
        sum += data[index];
        index = (index + 1) % dataSize;
      }
      return sum;
    }

  }
}
