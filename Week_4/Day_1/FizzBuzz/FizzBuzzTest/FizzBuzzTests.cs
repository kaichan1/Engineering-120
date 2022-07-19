using NUnit.Framework;
using FizzBuzzApp;

namespace FizzBuzzTest
{
    public class FizzBuzzTests
    {
        [Test]
        public void GivenOne_Return_OneString()
        {
            Assert.That(Program.FizzBuzz(1), Is.EqualTo("1 "));
        }

        [Test]
        public void GivenTwo_Return_OneTwoString()
        {
            Assert.That(Program.FizzBuzz(2), Is.EqualTo("1 2 "));
        }

        [Test]
        public void GivenThree_Return_OneTwoFizz()
        {
            Assert.That(Program.FizzBuzz(3), Is.EqualTo("1 2 FIZZ "));
        }

        [Test]
        public void GivenFour_Return_OneTwoFizzFour()
        {
            Assert.That(Program.FizzBuzz(4), Is.EqualTo("1 2 FIZZ 4 "));
        }

        [Test]
        public void GivenFive_Return_OneTwoFizzFourBuzz()
        {
            Assert.That(Program.FizzBuzz(5), Is.EqualTo("1 2 FIZZ 4 BUZZ "));
        }

        [Test]
        public void GivenSix_Return_OneTwoFizzFourBuzzFizz()
        {
            Assert.That(Program.FizzBuzz(6), Is.EqualTo("1 2 FIZZ 4 BUZZ FIZZ "));
        }

        [Test]
        public void GivenNine_Return_OneTwoFizzFourBuzzFizzSevenEightFIZZ()
        {
            Assert.That(Program.FizzBuzz(9), Is.EqualTo("1 2 FIZZ 4 BUZZ FIZZ 7 8 FIZZ "));
        }

        [Test]
        public void GivenNine_Return_OneTwoFizzFourBuzzFizzSevenEightFIZZBUZZ()
        {
            Assert.That(Program.FizzBuzz(10), Is.EqualTo("1 2 FIZZ 4 BUZZ FIZZ 7 8 FIZZ BUZZ "));
        }

        [Test]
        public void GivenFifteen_Return_StringContainingFIZZBUZZ()
        {
            Assert.That(Program.FizzBuzz(15), Is.EqualTo("1 2 FIZZ 4 BUZZ FIZZ 7 8 FIZZ BUZZ 11 FIZZ 13 14 FIZZBUZZ "));
        }

        // 1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17
        //Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz

        [Test]
        public void GivenThirty_Return_ExpectedStringShownAbove()
        {
            Assert.That(Program.FizzBuzz(30), Is.EqualTo("1 2 FIZZ 4 BUZZ FIZZ 7 8 FIZZ BUZZ 11 FIZZ 13 14 FIZZBUZZ 16 17 FIZZ 19 BUZZ FIZZ 22 23 FIZZ BUZZ 26 FIZZ 28 29 FIZZBUZZ "));
        }

        [Test]
        public void GivenAValueLowerThanOne_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(() => Program.FizzBuzz(-3), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
