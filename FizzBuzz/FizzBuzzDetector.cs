using System;
using System.Text;


namespace FizzBuzz {
  public class Result {
    public string OutputString { get; }
    public int FizzBuzzCount { get; }

    public Result(string outputString, int fizzBuzzCount) {
      OutputString = outputString;
      FizzBuzzCount = fizzBuzzCount;
    }

    public override string ToString() {
      return $"Result{{ OutputString = '{OutputString}', FizzBuzzCount = '{FizzBuzzCount}' }}";
    }
  }

  public class FizzBuzzDetector {
    public Result GetOverlappings(string input) {
      if (input == null) {
        throw new ArgumentNullException(nameof(input), "Input string cannot be null");
      }
      if (input.Length < 7 || input.Length > 100) {
        throw new ArgumentException("Input string length must be between 7 and 100 characters");
      }

      StringBuilder outputBuilder = new StringBuilder();
      int wordCount = 0;
      int fizzBuzzCount = 0;
      bool appended = false;
      bool validChar = false;
      bool isFizz = false;
      bool isBuzz = false;
      const char kSeparator = ' ';

      for (int i = 0; i < input.Length; i++) {
        validChar = char.IsLetterOrDigit(input[i]);
        isFizz = (wordCount + 1) % 3 == 0;
        isBuzz = (wordCount + 1) % 5 == 0;
        
        if (!isFizz && !isBuzz && validChar) {
          outputBuilder.Append(input[i]);
        }
        if (input[i] == kSeparator) {
          outputBuilder.Append(kSeparator);
          wordCount++;
          appended = false;
          continue;
        }
        if (char.IsLetterOrDigit(input[i]) && !appended) {
          if (isFizz && isBuzz) {
            outputBuilder.Append("FizzBuzz");
            fizzBuzzCount++;
            appended = true;
          } else if (isFizz) {
            outputBuilder.Append("Fizz");
            fizzBuzzCount++;
            appended = true;
          } else if (isBuzz) {
            outputBuilder.Append("Buzz");
            fizzBuzzCount++;
            appended = true;
          }
        } else if (!appended) {
          outputBuilder.Append(input[i]);
        }
      }
      return new Result(outputBuilder.ToString(), fizzBuzzCount);
    }
  }
}