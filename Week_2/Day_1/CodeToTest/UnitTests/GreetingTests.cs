using CodeToTest;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void GivenATimeOf21_Greeting_ReturnsGoodEvening()
        {
            //Arrange
            //var time = 21;
            //var expectedGreeting = "Good evening!";
            //Act
            //var result = Program.Greeting(time);
            //Assert
            //Assert.That(result, Is.EqualTo(expectedGreeting));

            Assert.That(Program.Greeting(21), Is.EqualTo("Good evening!"));
        }

        [Test]
        public void GivenATimeOf15_Greeting_ReturnsGoodAfternoon()
        {
            Assert.That(Program.Greeting(15), Is.EqualTo("Good afternoon!"));
        }

        [Test]
        public void GivenATimeOf2_Greeting_ReturnsGoodEvening()
        {
            Assert.That(Program.Greeting(2), Is.EqualTo("Good evening!"));
        }

        [TestCase(5)]
        [TestCase(8)]
        [TestCase(11)]
        public void GivenATimeOfBetween5and12Inclusive_Greeting_ReturnsGoodMorning(int time)
        {
            Assert.That(Program.Greeting(time), Is.EqualTo("Good morning!"));
        }

        [TestCase(12)]
        [TestCase(18)]
        public void GivenATimeBetween12and18Inclusive_Greeting_ReturnsGoodAfternoon(int time)
        {
            Assert.That(Program.Greeting(time), Is.EqualTo("Good afternoon!"));
        }

        [TestCase(4)]
        [TestCase(19)]
        public void GivenATimeEarlierThan5OrLaterThan18_Greeting_ReturnsGoodEvening(int time)
        {
            Assert.That(Program.Greeting(time), Is.EqualTo("Good evening!"));
        }


        //parameterized test

        [TestCase(4, "Good evening!")]

        public void GivenATime_Greeting_ReturnsString(int time, string str)
        {
            Assert.That(Program.Greeting(time), Is.EqualTo(str));
        }

    }
}