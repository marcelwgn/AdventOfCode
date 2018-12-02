using System;

namespace AdventOfCode.Utils {
  public static class StringUtils {
    public static bool containsLetterExactlyTwice(this String str) {
      char[] chars = str.ToCharArray();
      Array.Sort(chars);

      char c = chars[0];
      int curCount = 1;

      bool exactlyTwice = false;
      for (int i = 1; i < chars.Length; i++) {
        if (c == chars[i]) {
          curCount++;
        }
        else {
          if (curCount == 2) {
            exactlyTwice = true;
          }
          curCount = 1;

        }
        c = chars[i];
      }
      if (curCount == 2) {
        curCount = 0;
        exactlyTwice = true;
      }
      return exactlyTwice;
    }


    public static bool containsLetterExactlyThrice(this String str) {
      char[] chars = str.ToCharArray();
      Array.Sort(chars);

      char c = chars[0];
      int curCount = 1;

      bool exactlyThrice = false;
      for (int i = 1; i < chars.Length; i++) {
        if (c == chars[i]) {
          curCount++;
        }
        else {
          if (curCount == 3) {
            exactlyThrice = true;
          }
          curCount = 1;

        }
        c = chars[i];
      }
      if (curCount == 3) {
        curCount = 0;
        exactlyThrice = true;
      }
      return exactlyThrice;
    }

    public static int numberOfLettersDifferent(this String str, String input) {
      int count = 0;
      for (int i = 0; i < str.Length && i < input.Length; i++) {
        if (str[i] != input[i]) {
          count++;
        }
      }
      return count;
    }

    public static string getCommonLetters(this String str, String input) {
      String result = "";
      for (int i = 0; i < str.Length && i < input.Length; i++) {
        if (str[i] == input[i]) {
          result += str[i];
        }
      }
      return result;
    }
  }
}
