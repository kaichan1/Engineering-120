using NUnit.Framework;
using Methods_Lib;
using System;

namespace Methods_Tests
{
    public class TuplesTests
    {
        [TestCase(25, 3, 4)]
        [TestCase(0, 0, 0)]
        [TestCase(33, 4, 5)]
        public void GivenANumber_DaysAndWeeks_ReturnsCorrectTuple(
            int totalDays, int expectedWeeks, int expectedDays)
        {
            var answer = Methods.DaysAndWeeks(totalDays);
            Assert.That(answer.weeks, Is.EqualTo(expectedWeeks), "Weeks");
            Assert.That(answer.days, Is.EqualTo(expectedDays), "Days");
        }
        [Test]
        public void GivenANegativeNumber_DaysAndWeeks_ThrowsAnException()
        {
            Assert.That(() => Methods.DaysAndWeeks(-1), Throws.TypeOf<ArgumentOutOfRangeException>()
        .With.Message.Contain("totalDays must not be negative"));
        }

        [TestCase(-1)]
        public void GivenNegativeNumber_PowersRoot_ThrowsException(int num)
        {
            Assert.That(() => Methods.PowersRoot(num), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contains("Number must be positive"));
        }

        [TestCase(0,0,0,0)]
        [TestCase(1,1,1,1)]
        [TestCase(10, 100, 1000, 3.16)]
        public void GivenNumber_PowersRoot_ReturnsExpectedResult(int num, int square, int cube, double squareRoot)
        {
            Assert.That(Methods.PowersRoot(num), Is.EqualTo((square, cube, squareRoot)));
        }

    }
}