using StringCalculatorApp;

namespace StringTest;
public class Tests
{
    [TestCase("6,4", 10)]
    [TestCase("16,8", 24)]
    [TestCase("3,4", 7)]
    public void GivenAnyTwoNumbers_Num1PlusNum2_ReturnCorrectValue(string input, int expectedResult)
    {
        Assert.That(Program.Add(input), Is.EqualTo(expectedResult));
    }

    [TestCase("10", 10)]
    [TestCase("24", 24)]
    [TestCase("8", 8)]
    public void GivenASingleNumber_ReturnThatNumber(string input, int expectedResult)
    {
        Assert.That(Program.Add(input), Is.EqualTo(expectedResult));
    }

    [Test]
    public void GivenAnEmptyString_Return0()
    {
        Assert.That(Program.Add(""), Is.EqualTo(0));
    }

    [TestCase("6\n4", 10)]
    [TestCase("16\n8", 24)]
    [TestCase("3\n4", 7)]
    public void GivenNumbersDelimitedByNewLine_Num1PlusNum2_ReturnCorrectValue(string input, int expectedResult)
    {
        Assert.That(Program.Add(input), Is.EqualTo(expectedResult));
    }

    [TestCase("1\n2,3", 6)]
    [TestCase("4\n20,6", 30)]
    public void GivenBothTheCommaAndNewLineDelimiters_Add_ReturnsCorrectValue(string input, int expectedResult)
    {
        Assert.That(Program.Add(input), Is.EqualTo(expectedResult));
    }

    [TestCase("4,\n20,6")]
    public void GivenTwoAdjacentDelimiters_Add_ThrowArgumentException(string input)
    {
        Assert.That(() => Program.Add(input), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("//;\n5;10", 15)]
    [TestCase("//-\n5-50-35", 90)]
    [TestCase("//;\n5-10", 0)]
    public void GivenOurOwnDelimiter_Add_ReturnsCorrectValue(string input, int expectedResult)
    {
        Assert.That(Program.Add(input), Is.EqualTo(expectedResult));
    }

    [Test]
    public void GivenNegativeValues_Throw_ArgumentOutOfRangeException()
    {
        var input = "3, -7, 5";
        var expectedError = "negatives not allowed - -7";
        Assert.That(() => Program.Add(input), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contains(expectedError));
    }

    [Test]
    public void GivenTwoNegativeValues_Throw_ArgumentOutOfRangeException()
    {
        var input = "3, -7, -5";
        var expectedError = "negatives not allowed - -7, -5";
        Assert.That(() => Program.Add(input), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contains(expectedError));
    }
}