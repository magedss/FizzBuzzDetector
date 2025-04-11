using FizzBuzz;

namespace FizBuzzTesting {
  [TestClass]
  public class FizzBuzzDetectorTests {
    private FizzBuzzDetector _detector;

    [TestInitialize]
    public void Setup() {
      _detector = new FizzBuzzDetector();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetOverlappings_NullInput_ThrowsArgumentNullException() {
      _detector.GetOverlappings(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetOverlappings_InputTooShort_ThrowsArgumentException() {
      string input = "Short";
      _detector.GetOverlappings(input);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetOverlappings_InputTooLong_ThrowsArgumentException() {
      string input = @"Lorem ipsum dolor sit amet, sed diam nonumy eirmod tempor invidunt ut +
       labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum.Lorem ipsum dolor sit amet,  no sea takimata sanctus est Lorem ipsum dolor sit amet.  Stet clita kasd gubergren, no sea takimata  +
      sanctus est Lorem ipsum dolor sit amet.no sea takimata sanctus est Lorem ipsum dolor sit amet.  no sea takimata +
       sanctus est Lorem ipsum dolor sit amet.  sed diam voluptua.xx dd yy dd dd ddd d dd d d d dd d dd d  d d d d d d d";
      _detector.GetOverlappings(input);
    }

    [TestMethod]
    public void GetOverlappings_InputWithLowerBounds_ProcessesCorrectly() {
      string minLengthInput = "1234567";
      var minResult = _detector.GetOverlappings(minLengthInput);
      Assert.IsNotNull(minResult);
    }

    [TestMethod]
    public void GetOverlappings_OnlyNonAlphanumericChars_ReturnsOriginalString() {
      string input = "!@ #$ %^ &*( )_+";
      var result = _detector.GetOverlappings(input);
      Assert.AreEqual(input, result.OutputString);
      Assert.AreEqual(0, result.FizzBuzzCount);
    }

    [TestMethod]
    public void GetOverlappings_ValidInput_ReturnsCorrectOutput() {
      string input = "This is a test of the FizzBuzz algorithm.";
      var result = _detector.GetOverlappings(input);
      Assert.AreEqual("This is Fizz test Buzz Fizz FizzBuzz algorithm.", result.OutputString);
      Assert.AreEqual(3, result.FizzBuzzCount);
    }

    [TestMethod]
    public void GetOverlappings_InputWith15Words_ReturnsCorrectOutput() {
      string input = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";
      var result = _detector.GetOverlappings(input);
      Assert.AreEqual("one two Fizz four Buzz Fizz seven eight Fizz Buzz eleven Fizz thirteen fourteen FizzBuzz", result.OutputString);
      Assert.AreEqual(7, result.FizzBuzzCount);
    }

    [TestMethod]
    public void GetOverlappings_InputWithNonalphanumeric_ReturnsCorrectOutput() {
      string input = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";
      var result = _detector.GetOverlappings(input);
      Assert.AreEqual("Mary had Fizz little Buzz Fizz lamb, little Fizz Buzz had Fizz little lamb FizzBuzz fleece was Fizz as Buzz", result.OutputString);
      Assert.AreEqual(9, result.FizzBuzzCount);
    }

    [TestMethod]
    public void GetOverlappings_InputWithNumbersandWords_ReturnsCorrectOutput() {
      string input = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";
      var result = _detector.GetOverlappings(input);
      Assert.AreEqual("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz", result.OutputString);
      Assert.AreEqual(7, result.FizzBuzzCount);
    }
  }
}