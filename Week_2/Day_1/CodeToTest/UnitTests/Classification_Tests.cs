using CodeToTest;

namespace UnitTests
{
    public class Classification_Tests
    {
        #region unparameterized tests
        //[TestCase(11, "U, PG & 12 films are available.")]
        //[TestCase(12, "U, PG, 12 & 15 films are available.")]
        //[TestCase(14, "U, PG, 12 & 15 films are available.")]
        //[TestCase(19, "All films are available.")]
        //public void GivenAge_AvailableClassifications_ReturnsExpectedResult(int age, string expectedresult)
        //{
        //    Assert.That(Program.AvailableClassifications(age), Is.EqualTo(expectedresult));
        //}

        //[TestCase(7, "U films are available.")]
        //[TestCase(8, "U & PG films are available.")]
        //[TestCase(11, "U & PG films are available.")]
        //[TestCase(12, "U, PG & 12 films are available.")]
        //[TestCase(14, "U, PG & 12 films are available.")]
        //[TestCase(15, "U, PG, 12 & 15 films are available.")]
        //[TestCase(19, "All films are available.")]
        //public void GivenAge_AvailableClassificationsUpdated_ReturnsExpectedResult(int age, string expectedresult)
        //{
        //    Assert.That(Program.AvailableClassificationsUpdated(age), Is.EqualTo(expectedresult));
        //}
        #endregion

        #region old method and requirements
        //Old Method and Requirements
        [TestCase(11)]
        public void GivenAgeUnder12_AvailableClassifications_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("U, PG & 12 films are available."));
        }

        [TestCase(14)]
        public void GivenAgeUnder15_AvailableClassifications_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("U, PG, 12 & 15 films are available."));
        }

        [TestCase(19)]
        public void GivenAgeOver18_AvailableClassifications_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo("All films are available."));
        }
        #endregion

        //New Method and Requirements
        [TestCase(-1)]
        public void GivenNegativeAge_AvailableClassificationsUpdated_ReturnsArgumentOutOfRangeException(int age)
        {
            Assert.That(() => Program.AvailableClassificationsUpdated(age), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        
        [TestCase(18)]
        [TestCase(19)]
        public void GivenAge18orMore_AvailableClassificationsUpdated_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassificationsUpdated(age), Is.EqualTo("All films are available."));
        }

        [TestCase(15)]
        [TestCase(16)]
        public void GivenAge15orMore_AvailableClassificationsUpdated_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassificationsUpdated(age), Is.EqualTo("U, PG, 12 & 15 films are available."));
        }

        [TestCase(12)]
        [TestCase(13)]
        public void GivenAge12orMore_AvailableClassificationsUpdated_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassificationsUpdated(age), Is.EqualTo("U, PG & 12 films are available."));
        }

        [TestCase(8)]
        [TestCase(9)]
        public void GivenAge8orMore_AvailableClassificationsUpdated_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassificationsUpdated(age), Is.EqualTo("U & PG films are available."));
        }

        [TestCase(7)]
        public void GivenAgeLessThan8_AvailableClassificationsUpdated_ReturnsExpectedResult(int age)
        {
            Assert.That(Program.AvailableClassificationsUpdated(age), Is.EqualTo("U films are available."));
        }
    }
}