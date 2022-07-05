using OperatorsApp;

namespace TestProject
{
    public class StoneTests
    {
        [TestCase(156, 11)]
        [TestCase(0, 0)]
        [TestCase(13, 0)]
        [TestCase(14, 1)]
        [TestCase(15, 1)]
        [TestCase(27, 1)]
        [TestCase(28, 2)]
        [TestCase(29, 2)]
        public void GivenTotalPounds_GetStones_ReturnsExpectedResult(int totalpounds, int expectedresult)
        {
            Assert.That(Methods.GetStones(totalpounds), Is.EqualTo(expectedresult));
        }

        [TestCase(156, 2)]
        [TestCase(0, 0)]
        [TestCase(13, 13)]
        [TestCase(14, 0)]
        [TestCase(15, 1)]
        [TestCase(27, 13)]
        [TestCase(28, 0)]
        [TestCase(29, 1)]
        public void GivenTotalPounds_GetPounds_ReturnsExpectedResult(int totalpounds, int expectedresult)
        {
            Assert.That(Methods.GetPounds(totalpounds), Is.EqualTo(expectedresult));
        }
    }
}