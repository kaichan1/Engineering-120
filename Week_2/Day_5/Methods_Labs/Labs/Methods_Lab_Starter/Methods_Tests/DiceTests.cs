using NUnit.Framework;
using System;
using Methods_Lib;

namespace Methods_Tests
{
    public class DiceTests
    {
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(200)]
        [TestCase(9999)]
        public void GivenRandomNumberGenerator_RollDice_ReturnsExpectedResult(int seed)
        {
            Assert.That(Methods.RollDice(new Random(seed)), Is.InRange(2, 12));
        }

        [Test]
        public void GivenSeed_RollDice_ReturnsExpectedResult()
        {
            Assert.That(Methods.RollDice(new Random(0)), Is.EqualTo(10));
        }
    }
}
