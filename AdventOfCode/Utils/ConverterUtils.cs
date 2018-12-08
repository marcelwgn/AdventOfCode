using System;

namespace AdventOfCode.Utils {
  public static class ConverterUtils {
    public static int[] getNumbers(string[] data)
    {
      int[] numbers = new int[data.Length];
      for (int i = 0; i < data.Length; i++)
      {
        try
        {
          numbers[i] = System.Convert.ToInt32(data[i]);
        }
        catch (Exception)
        {
          numbers[i] = 0;
        }
      }
      return numbers;
    }

    public static int[] getNumbers(string data)
    {
      return getNumbers(data, " ");
    }

    public static int[] getNumbers(string data, string delimeter)
    {
      return getNumbers(data.Split(delimeter));
    }
  }

}