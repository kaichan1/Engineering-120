using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;
using System.Collections.Generic;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;
        private Mock<ICustomerService> mockCustomerService;
        private Customer customer;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            mockCustomerService = new Mock<ICustomerService>();
            customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            _sut = new CustomerManager(mockCustomerService.Object);
        }

        [Test]
        public void CallRetrieveAll_ReturnsListOfCustomers()
        {
            List<Customer> customers = new List<Customer>() { new Customer(), new Customer() };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(customers);

            var result = _sut.RetrieveAll();

            Assert.That(result, Is.EqualTo(customers));
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void CallSetSelectedCustomer_ReturnsCustomer()
        {
            _sut.SetSelectedCustomer(customer);
            Assert.That(_sut.SelectedCustomer, Is.EqualTo(customer));
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
        }

        [Test]
        public void CallCreate_CallExpectedMethods()
        {
            mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.CreateCustomer(It.IsAny<Customer>()));
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            _sut.SetSelectedCustomer(customer);

            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
        }
        [Test]
        public void CallDelete_CallsExpectedMethods()
        {
            mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);
            mockCustomerService.Setup(cs => cs.RemoveCustomer(customer));
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.SelectedCustomer = customer;

            Assert.That(_sut.Delete(customer.CustomerId));
        }
    }
}

