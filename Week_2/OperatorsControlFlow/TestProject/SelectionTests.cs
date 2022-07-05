using ControlFlowApp;

namespace TestProject
{
    public class SelectionTests
    {
        [TestCase(85)]
        [TestCase(86)]
        public void GivenMark85orAbove_Grade_ReturnsDistinction(int mark)
        {
            Assert.That(Program.Grade(mark), Is.EqualTo("Distinction"));
        }

        [TestCase(65)]
        [TestCase(66)]
        [TestCase(84)]
        public void GivenMark65orAboveAndLessThan85_Grade_ReturnsPass(int mark)
        {
            Assert.That(Program.Grade(mark), Is.EqualTo("Pass"));
        }

        [TestCase(20)]
        [TestCase(21)]
        [TestCase(64)]
        public void GivenMark20orAboveAndLessThan65_Grade_ReturnsFailWithRetake(int mark)
        {
            Assert.That(Program.Grade(mark), Is.EqualTo("Fail with retake"));
        }

        [TestCase(19)]
        [TestCase(0)]
        public void GivenMarkBelow20_Grade_ReturnsFailedNoRetake(int mark)
        {
            Assert.That(Program.Grade(mark), Is.EqualTo("Failed no retake"));
        }
    }
}
