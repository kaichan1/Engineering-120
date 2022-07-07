namespace ExceptionsDataTypesTests
{
    public class Tests
    {
        #region Mark < 0
        [TestCase(-1)]
        [TestCase(-100)]
        public void WhenMarkIsLessThanZero_Grade_ThrowsAnArgumentOutOfRangeException(int mark)
        {
            Assert.That(() => Program.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain(" Allowed range 0-100"));
            Assert.That(() => Program.Grade(mark), Throws.InstanceOf<Exception>().With.Message.Contain(" Allowed range 0-100"));
        }
        #endregion

        //Create a test, like the above, but for values more than 100

        [TestCase(101)]
        [TestCase(200)]
        public void WhenMarkIsMoreThan100_Grade_ThrowsAnArgumentOutOfRangeException(int mark)
        {
            Assert.That(() => Program.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain(" Allowed range 0-100"));
        }

    }
}