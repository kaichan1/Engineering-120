using CodeKatas;

namespace TestProject1
{
    public class Tests
    {
        [TestCase("hello")]
        public void GivenWord_DuplicateChar_ReturnsArrayWithDuplicateChar(string word, Array)
        {
            Assert.That(Class1.DuplicateChar(word), Is.EqualTo(Array);
        }

        [TestCase(5, 480)]
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
    }
}