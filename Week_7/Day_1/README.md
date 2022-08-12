# Week 7 - Web Testing - Day 1

[Back](/Week_7)

[Main Menu](/README.md)

---
Date: 8/8


Classes correspond to tables in Northwind database
Properties correspond to columns
When I instantiate an order, I can add it to the Order table

### partial class
- you can write the class in two seperate files
- at compile time, they're treated like one class

> NorthwindBusiness
>> CustomerManager
```csharp
public class CustomerManager
{
	private readonly ICustomerService _service;

	//Take an ICustomerService type
	public CustomerManager(ICustomerService service)
```
- any service that injects into CustomerManager must implement ICustomerService


### Violating FIRST
- not repeatable
- database query is slow
- not timely, not abide by the principle of early testing

CustomerManager depends on an abstraction, not an instance
- dependency injection allows for dependency inversion
- makes our code more testable

### Test Doubles
	- Dummy objects are passed around but never actually used. Usually they are just used to fill parameter lists.
	- Fake objects actually have working implementations, but usually take some shortcut which makes them not suitable for production (an InMemoryTestDatabase is a good example).
	- Stubs provide canned answers to calls made during the test, usually not responding at all to anything outside what's programmed in for the test.
	- Spies are stubs that also record some information based on how they were called. One form of this might be an email service that records how many messages it was sent.
	- Mocks are pre-programmed with expectations which form a specification of the calls they are expected to receive. They can throw an exception if they receive a call they don't expect and are checked during verification to ensure they got all the calls they were expecting.

From <https://www.martinfowler.com/bliki/TestDouble.html> 


> NorthwindTests
>> CustomerManagerShould



## Moq
### Dummy
```csharp
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
```
- Mock<ICustomerService> is like a class(?)
- _sut = system under test


### Stubs
```csharp
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

	// Set up the service so it returns what I want
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
```


### State-based testing
- what the final state of the system is in after a specified action/s


### Testing Exceptions
```csharp
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
```


### Behaviour-based testing
- Spy - used in behaviour based testing

```csharp
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
//Strict - all methods withing the Method Under Test must have behaviour set up
[Test]
public void Behaviours_LooseVsStrict()
{
	//Arrange
	var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
	mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
	mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
	_sut = new CustomerManager(mockCustomerService.Object);
	//Act
	var result = _sut.Update("WOLST", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
	//Assert
	Assert.That(result);
}
```
- default MockBehavior is loose
- Strict more thorough, but makes your tests more brittle


