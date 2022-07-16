namespace TestProject1
{
    public class UnitTest1
    {
        [TestCase("Nishant Mandal", new char[] { 'n', 'a' })]
        [TestCase("hello", new char[] { 'l' })]
        [TestCase("a", new char[]{})]
        public void GivenWord_DuplicateChar_ReturnsArrayWithDuplicateChar(string word, char[] expectedResult)
        {
            Assert.That(Class1.DuplicateChar(word), Is.EqualTo(expectedResult));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        public void GivenNumber_Factorial_ReturnsFactorial(int num, int fac)
        {
            Assert.That(Class1.Factorial(num), Is.EqualTo(fac));
        }

        [TestCase("", true)]
        [TestCase("h", true)]
        [TestCase("hah", true)]
        [TestCase("hallo", false)]
        [TestCase("hallah", true)]
        public void GivenWord_Pallindrome_ExpectedResult(string word, bool expectedResult)
        {
            Assert.That(Class1.Pallindrome(word), Is.EqualTo(expectedResult));
        }

        //[TestCase(new List<int> { 1, 2, 3, 4, 5 }, 4)]
        //public void GivenList_SecondHighest_ReturnsSecondHighestNumber(List<int> nums, int expectedResult)
        //{
        //    Assert.That(Class1.SecondHighest(nums), Is.EqualTo(expectedResult));
        //}

        [Test]
        public void GivenBlankList_SecondHighest_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(() => Class1.SecondHighest(new List<int> { }), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GivenList_SecondHighest_ReturnsSecondHighestNumber()
        {
            Assert.That(Class1.SecondHighest(new List<int> { 1,2 }), Is.EqualTo(1));
            Assert.That(Class1.SecondHighest(new List<int> { 2,1 }), Is.EqualTo(1));
            Assert.That(Class1.SecondHighest(new List<int> { 1,1 }), Is.EqualTo(1));
            Assert.That(Class1.SecondHighest(new List<int> { 1,2,3,9,7 }), Is.EqualTo(7));
            Assert.That(Class1.SecondHighest(new List<int> { 7,2,3,9,1 }), Is.EqualTo(7));
        }
    }
}