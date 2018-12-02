using System;
using AdventOfCode;
using AdventOfCode.Utils;

namespace AdventOfCode.Solutions {
  public class Day2 {

    public static string[] convert(string[] args) {
      return args;
    }

    public static int firstProblem(string[] data) {
      int sumLettersTwice = 0;
      int sumLettersThrice = 0;
      for (int i = 0; i < data.Length; i++) {
        if (data[i].containsLetterExactlyTwice()) {
          sumLettersTwice++;
        }
        if (data[i].containsLetterExactlyThrice()) {
          sumLettersThrice++;
        }
      }

      return sumLettersTwice * sumLettersThrice;
    }

    public static String secondProblem(string[] data) {
      string first = data[0];
      string second = data[1];
      int difference = first.numberOfLettersDifferent(second);
      for (int i = 0; i < data.Length - 1; i++) {
        for (int j = i + 1; j < data.Length; j++) {
          if (data[i].numberOfLettersDifferent(data[j]) < difference) {
            first = data[i];
            second = data[j];

            difference = first.numberOfLettersDifferent(second);

          }
        }
      }

      return first.getCommonLetters(second);
    }

  }


}
