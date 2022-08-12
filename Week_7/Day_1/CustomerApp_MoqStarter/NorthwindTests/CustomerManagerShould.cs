using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;
        //Fakes - In memory database (not covered this lesson)

        #region Moq as Dummy
        [Ignore("Meant to fail")]
        [Test]
        public void BeAbleToBeConstructed()
        {
            //Act
            _sut = new CustomerManager(null);
            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        [Test]
        public void BeAbleToBeConstructed_WithMoq()
        {
            //Use Moq to create a dummy objects which implements ICustomerServiec
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            //Act - retruece the ICustomerservice object associated with that Mock
            //Mock.Object - doesn't do anything!! No functionality
            _sut = new CustomerManager(mockCustomerService.Object);
            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }
        #endregion

        #region Stubs
        // We need to create a test double for implementing the ICustomerService interface
        // AND THEN configure it to return our desired values
        [Test]
        public void ReturnTrue_WhenUpdateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            // Set upt the service so it returns what I want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update("MANDA", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.That(result);
        }

        [Test]
        public void NotChangeTheSelectedCustomer_WhenUpdateIsCalled_WithInvalidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };

            // Set upt the service so it returns what I want
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns((Customer)null);
            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = customer;
            var result = _sut.Update("MANDA", "Nishant Mandal", "UK", "London", null);

            //Assert
            Assert.That(!result);
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.Null);
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }

        [Test]
        public void ReturnTrue_WhenDeleteIsCalledWithValidId()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer()
            {
                CustomerId = "ROCK",
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("ROCK")).Returns(customer);
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Delete("ROCK");

            // Assert
            Assert.That(result);
        }

        [Test]
        public void SetSelectedCustomerToNull_WhenDeleteIsCalledWithValidId()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer()
            {
                CustomerId = "ROCK",
            };
            _sut.SelectedCustomer = customer;
            mockCustomerService.Setup(cs => cs.GetCustomerById("ROCK")).Returns(customer);
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Delete("ROCK");

            // Assert
            Assert.That(_sut.SelectedCustomer, Is.Null);
        }

        [Test]
        public void ReturnFalse_WhenDeleteIsCalled_WithInvalidId()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            mockCustomerService.Setup(cs => cs.GetCustomerById("ROCK")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Delete("ROCK");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void NotChangeTheSelectedCustomer_WhenDeleteIsCalled_WithInvalidId()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            mockCustomerService.Setup(cs => cs.GetCustomerById("ROCK")).Returns((Customer)null);

            var originalCustomer = new Customer()
            {
                CustomerId = "ROCK",
                ContactName = "Rocky Raccoon",
                CompanyName = "Zoo UK",
                City = "Telford"

            };

            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = originalCustomer;
            // Act
            _sut.Delete("ROCK");

            // Assert that SelectedCustomer is unchanged
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Rocky Raccoon"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Zoo UK"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Telford"));
        }

        #endregion
        #region Testing Expcetions
        [Test]
        public void ReturnsFalse_WhenUpdateIsCalled_AndADatabaseExceptionIsThrown()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();
            _sut = new CustomerManager(mockCustomerService.Object);
            //act
            var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            Assert.That(!result);
        }

        [Test]
        public void NotChangeTheSelectedCustomer_WhenUpdateIsCalled_AndADatabaseExceptionIsThrown()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();
            var originalCustomer = new Customer()
            {
                CustomerId = "ROCK",
                ContactName = "Rocky Raccoon",
                CompanyName = "Zoo UK",
                City = "Telford"

            };
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = originalCustomer;
            _sut.Update("ROCK", "Rocky Racoon", "UK", "Chester", null);
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Rocky Raccoon"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Zoo UK"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Telford"));

        }
        #endregion

        #region Behaviour-based testing
        [Test]
        public void CallSaveCustomerChanges_WhenUpdateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Loose);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            //Assert
            //Calling the udpate method in the CustomerManager class, called the SavesCustomer method once
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
            //mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Exactly(1));
            //mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.AtMostOnce);
            //mockCustomerService.Verify(cs => cs.RemoveCustomer(new Customer() { CustomerId = "MANDA" }), Times.Never);
        }
        //Strict - all methods withing the Mehtod Under Test must have behaviour set up
        [Test]
        public void Behaviours_LooseVsStrict()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            Assert.That(result);
        }
        #endregion

    }
}

