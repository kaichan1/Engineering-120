using CodeKatas;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void GivenWord_DuplicateChar_ReturnsArrayWithDuplicateChar()
        {
            Assert.That(Class1.DuplicateChar("hello"), Is.EqualTo(new char[]{'l'}));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        public void GivenNumber_Factorial_ReturnsFactorial(int num, int fac)
        {
            Assert.That(Class1.Factorial(num), Is.EqualTo(fac));
        }

        [TestCase("hello", false)]
        [TestCase("helleh", true)]
        public void GivenWord_Pallindrome_ReturnsIfPallindrome(string word, bool ifPallindrome)
        {
            Assert.That(Class1.Pallindrome(word), Is.EqualTo(ifPallindrome));
        }

        //[TestCase(new[]{1,2,3}, 1)]
        //public void GivenList_SecondHighest_ReturnsSecondHighestNumber(List<int> nums, int expectedResult)
        //{
        //    Assert.That(Class1.SecondHighest(nums), Is.EqualTo(expectedResult));
        //}

        [Test]
        public void GivenList_SecondHighest_ReturnsSecondHighestNumber()
        {
            Assert.That(Class1.SecondHighest(new List<int> { 1,2,3,4,5}), Is.EqualTo(4));
        }
    }
}