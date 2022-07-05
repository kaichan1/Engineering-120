using NUnit.Framework;
using Op_CtrlFlow;
using System.Collections.Generic;

namespace Op_CtrlFlow_Tests
{
    public class Exercises_Tests
    {     
        // write unit test(s) for MyMethod here


        [Test]
        public void Average_ReturnsCorrectAverage()
        {
            var myList = new List<int>() { 3, 8, 1, 7, 3 };
            Assert.That(Exercises.Average(myList), Is.EqualTo(4.4));
        }

        [Test]
        public void WhenListIsEmpty_Average_ReturnsZero()
        {
            var myList = new List<int>() {};
            Assert.That(Exercises.Average(myList), Is.EqualTo(0));
        }

        [TestCase(100, "OAP")]
        [TestCase(60, "OAP")]
        [TestCase(59, "Standard")]
        [TestCase(18, "Standard")]
        [TestCase(17, "Student")]
        [TestCase(13, "Student")]
        [TestCase(12, "Child")]
        [TestCase(5, "Child")]
        [TestCase(4, "Free")]
        [TestCase(0, "Free")]
        public void TicketTypeTest(int age, string expected)
        {
            var result = Exercises.TicketType(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        #region Grade Tests
        [TestCase(100)]
        [TestCase(75)]
        public void GivenMark75to100_Grade_ReturnsPassWithDistinction(int mark)
        {
            Assert.That(Exercises.Grade(mark), Is.EqualTo("Pass with Distinction"));
        }

        [TestCase(74)]
        [TestCase(60)]
        public void GivenMark60to74_Grade_ReturnsPassWithMerit(int mark)
        {
            Assert.That(Exercises.Grade(mark), Is.EqualTo("Pass with Merit"));
        }

        [TestCase(59)]
        [TestCase(40)]
        public void GivenMark40to59_Grade_ReturnsPass(int mark)
        {
            Assert.That(Exercises.Grade(mark), Is.EqualTo("Pass"));
        }

        [TestCase(39)]
        [TestCase(0)]
        public void GivenMark0to39_Grade_ReturnsFail(int mark)
        {
            Assert.That(Exercises.Grade(mark), Is.EqualTo("Fail"));
        }
        #endregion
        
        #region Wedding Number Tests
        [TestCase(4)]
        public void GivenCovidLevelIs4_GetScottishMaxWeddingNumbers_Returns20(int covidlevel)
        {
            Assert.That(Exercises.GetScottishMaxWeddingNumbers(covidlevel), Is.EqualTo(20));
        }

        [TestCase(3)]
        [TestCase(2)]
        public void GivenCovidLevelIs3or2_GetScottishMaxWeddingNumbers_Returns50(int covidlevel)
        {
            Assert.That(Exercises.GetScottishMaxWeddingNumbers(covidlevel), Is.EqualTo(50));
        }

        [TestCase(1)]
        public void GivenCovidLevelIs1_GetScottishMaxWeddingNumbers_Returns100(int covidlevel)
        {
            Assert.That(Exercises.GetScottishMaxWeddingNumbers(covidlevel), Is.EqualTo(100));
        }

        [TestCase(0)]
        public void GivenCovidLevelIs0_GetScottishMaxWeddingNumbers_Returns200(int covidlevel)
        {
            Assert.That(Exercises.GetScottishMaxWeddingNumbers(covidlevel), Is.EqualTo(200));
        }
        #endregion
    }
}
