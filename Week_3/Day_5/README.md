# Week 3 - OOP & Adv Unit Testing - Day 5

[Back](/Week_3)

[Main Menu](/README.md)

---

Date: 7/15

One line solution using
- enumerable
- ternary
- linq


## [Queue](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-6.0)
- FIFO
- .Dequeue()
- .TryDequeue()
- .Enqueue()
- .Peek()
- .TryPeek()
- .ToArray()


```csharp
var myQueue = new Queue<Person>();
myQueue.Enqueue(helen);
myQueue.Enqueue(will);
myQueue.Enqueue(new Person("David"));

Console.WriteLine("Queue\n");
foreach(var person in myQueue)
{
	Console.WriteLine(person);
}
var first = myQueue.Peek();
Console.WriteLine(first);

var serve = myQueue.Dequeue();
Console.WriteLine(serve);
```

```csharp
//myQueue[0]
```
- won't work

## [Stack](https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-6.0)
- LIFO
- ex.  undo on Word

.Push()
.Pop()
.Peek()
.ToArray()



```csharp
var stack = new Stack<int>();
int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };
int[] numsReversed = new int[nums.Length];

foreach(var num in nums)
{
	stack.Push(num);
}

for (int i = 0; i < numsReversed.Length; i++)
{
	stackReversed[i] = stack.Pop();
}
```


## [HashSet](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-6.0
)
- no index or key
- elements ordered by their hash code
- optimized for fast searches and operations
- for comparison
- sets cannot have duplicates and have no order

***If two objects have the same hash code, they are not necessarily equal.***

***If two objects are equal, they have the same hash code.***

- .Add()
- .UnionWith
- .IntersectWith
- .IsSubsetOf


```csharp
var peopleSet = new HashSet<Person>
{
	helen, new Person("Dylan"), new Person("Thomas")
};
Console.WriteLine("Hash Set");
foreach (var entry in peopleSet)
{
	Console.WriteLine(entry);
}

var successMartin = peopleSet.Add(new Person() { FirstName = "Martin", LastName = "Beard", Age = 21 });
var successHelen = peopleSet.Add(new Person() { FirstName = "Helen ", LastName = "Troy", Age = 22 });
```

```csharp
peopleSet.IntersectWith(morePeople);

var vehicleSet = new HashSet<Vehicle>
{
	new Vehicle() { NumPassengers = 3, Speed = 2 },
	new Vehicle() { Speed = 100}
};

var success = vehicleSet.Add(new Vehicle() { Speed = 100 });
```



## [Dictionaries](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)

- Keys must be unique
- Collections don't need to have a size

Methods
- .ContainsKey
- .TryAdd
- .Keys
- .Values


```csharp
var personDict = new Dictionary<string, Person>
{
	{ "helen", helen },
	{ "tom", new Person("Thomas") }
};

var p = personDict["tom"];
personDict.Add("bill", will);

string input = "The cat in the hat comes back";
input = input.Trim().ToLower();
var countDict = new Dictionary<char, int>();

foreach (char c in input)
{
	if (countDict.ContainsKey(c))
	{
		countDict[c]++;
	}
	else
	{
		countDict.Add(c, 1);
	}
}
```


## Advanced Unit Testing
xUnit framework
- JUnit (Java)
- NUnit (N for .Net)

Testing static methods
- no need to create an object

> Tools
>> NuGet Package Manager
>>> Manage NuGet Package for Solution…


Testing in Command Prompt
> AdvancedNUnit_Starter folder
>> cmd

dotnet test --list-tests
​dotnet test


https://docs.nunit.org/articles/nunit/writing-tests/constraints/Constraints.html


### [Constraint model](https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertion-models/constraint.html)

```csharp
Assert.That(result, Is.EqualTo(expectedResult), "optional failure message");
```
- being developed actively
- more flexible

### Classical model
```csharp
Assert.AreEqual(expectedResult, result, "Optional failure message");
```
- not being developed any more
- used in NUnit 2.0


```csharp
[TestCase(6, 7)]
public void SomeConstraints(int first, int second)
{
	var _sut = new Calculator() { Num1 = first };     //subject under test
	Assert.That(_sut.DivisibleBy3());
	
	_sut.Num1 = second;
	Assert.That(_sut.DivisibleBy3(), Is.False);
	Assert.That(_sut.ToString, Does.Contain("Calculator"));
}
```
- testing too many things at once


### String constraints
```csharp
[Test]
public void StringConstraints()
{
	var subject = new Calculator { Num1 = 2, Num2 = 4 };
	var strResult = subject.ToString();
	
	Assert.That(strResult, Is.EqualTo("AdvancedNUnit.Calculator"));
	Assert.That(strResult, Does.Contain("Calculator"));
	Assert.That(strResult, Does.Not.Contain("Potato"));
	Assert.That(strResult, Is.EqualTo("advancednunit.calculator").IgnoreCase);
	Assert.That
}
```
```csharp
Assert.That(strResult == "AdvancedNUnit.Potato");
```
- doesn't give you as much information as `Is.EqualTo`


### List constraints
```csharp
public void TestArrayOfStrings()
{
	var fruit = new List<string> { "apple", "pear", "banana", "peach"};
	Assert.That(fruit, Does.Contain("pear"));
	Assert.That(fruit, Has.Count.EqualTo(4));
	Assert.That(fruit, Has.Exactly(2).StartsWith("pea"));
}
```

### Range constraints
```csharp
public void TestRange()
{
Assert.That(8, Is.InRange(1, 10));

List<int> nums = new List<int> { 4, 2, 7, 5, 9 };
Assert.That(nums, Is.All.InRange(1, 10));
Assert.That(nums, Has.Exactly(2).InRange(1, 4));
}
```


### coverlet
> Extensions
>> Manage Extensions
>>> Run Coverlet Report VS2022

> Tools
>> Run Code Coverage

Install ReportGenerator
https://github.com/danielpalme/ReportGenerator


