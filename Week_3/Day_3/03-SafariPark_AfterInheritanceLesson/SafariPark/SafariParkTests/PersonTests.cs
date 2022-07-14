
using SafariParkApp.Misc;

namespace SafariParkTests
{
    public class PersonTests
    {
        [Test]
        public void Point3dTest()
        {
            //Arrange
            var subject = new Point3d(1,2,3);
            //Act
            var result = subject.SumOfPoints();
            //Assert
            Assert.That(subject.x, Is.EqualTo(1));
            Assert.That(subject.y, Is.EqualTo(2));
            Assert.That(subject.z, Is.EqualTo(3));
            Assert.That(result, Is.EqualTo(6));
        }


        [TestCase("Cathy", "French", "Cathy French")]
        [TestCase("",""," ")]
        public void GetFullNameTest(string firstName, string lastName, string expectedResult)
        {
            Person subject = new Person(firstName, lastName);
            var result = subject.FullName;
            //Classic NUnit model
            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        public void AgeTest()
        {
            var subject = new Person("A", "B") { Age = 33 };
            Assert.That(subject.Age, Is.EqualTo(33));
        }
    }
}