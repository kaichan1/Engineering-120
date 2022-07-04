# Week 2 - C# Basics - Day 1

[Back](/Week_2)

[Main Menu](/README.md)

---
Date: 7/4

## Unit Testing & Refractoring

### Before refractoring

```csharp
using System;

namespace CodeToTest;

public class Program
{
    static void Main(string[] args)
    {
        int timeOfDay = 21;
        if (timeOfDay >= 5 && timeOfDay <= 12)
        {
            Console.WriteLine("Good morning!");
        }
        else if (timeOfDay >= 12 && timeOfDay <= 18)
        {
            Console.WriteLine("Good afternoon");
        }
        else
        {
            Console.WriteLine("Good evening!");
        }
    }
}
```

**Refractoring**
- changing structure of code without changing its behavior
- unit tests should still pass after refractoring

What improvements can be done?
- control flow and printing in console can be seperated
- conditions overlap at 12

> Highlight the logic code
>> Quick actions and refractoring
>>> Extract method

What else?
- method not returning anything

```csharp
using System;

namespace CodeToTest;

public class Program
{
    static void Main(string[] args)
    {
        int timeOfDay = 21;
        var greet = Greeting(timeOfDay);
        Console.WriteLine(greet);
    }

    private static string Greeting(int timeOfDay)
    {
        string greeting;
        
        if (timeOfDay >= 5 && timeOfDay <= 12)
        {
            greeting = "Good morning!";
        }
        else if (timeOfDay >= 12 && timeOfDay <= 18)
        {
            greeting = "Good afternoon";
        }
        else
        {
            greeting = "Good evening!";
        }
        return greeting;
    }
}
```
| Command | Description |
| - | - |
| var | if we don't know the data type return |
| static | the same across all instances within a class |

#### Adding an NUnit Test Project
> Right-click Solution
>> Add
>>> New Project
>>>> NUnit Test Project

NUit3TestAdapter
- allows visual studio recognize and run the tests

Usings only affects UnitTests

Rename UnitTests.cs to GreetingTests.cs


```csharp
namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.Fail();
        }
    }
}
```

> Right-click Dependencies
>> Add Project Reference
>>> Check CodeToTest

| Command | Description |
| - | - |
| Assert.That(a, b) | a = returned value, b = constraint |

Exhaustive testing is impossible

At 12?
- create the test first
- what should we expect when the time is 12?

**Boundary value analysis**
- mistakes tend to occur on boundaries
- 80/20 rule

**Parameterized test cases**
- testing methods with parameters

No control flows in tests
Make lots of simple, small tests
Purposefully fail some test to make sure they fail correctly

| Command | Description |
| - | - |
| ctr + k + c | comment highlighted |

Namespace
- a layer to identify classes
- especially when you import libraries

**FIRST**
- Fast
- Independent:  each test is independent
- Repeatable:  not dependent on a network or database
- Self-validating:  using asserts, no need to check results
- Timely

---
### Exercise:  British Board of Film Classification

```csharp
[TestCase(18, "U, PG & 12 films are available.")]
public void GivenAge_AvailableClassifications_ReturnsFilmsAvailable(int age, string films)
{
        Assert.That(Program.FilmsAvailable(ageOfViewer), IsEqualTo(films));
}
```
Lessons
- separate tests for each expected return value
- use words that appear in test functions for parameters respectively


### Test-First Development (TFD)
- write all tests, then functions

### Test-driven development (TDD)
- write one test, then one function, repeat