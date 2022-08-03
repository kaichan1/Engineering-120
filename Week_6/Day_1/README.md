# Week 6 - Advanced C# & API Testing - Day 1

[Back](/Week_6)

[Main Menu](/README.md)

---
Date: 8/1

## Lambda

### IEnumerable 
- allows you to iterate through the object

### Lambdas
- have no name
- is declared at the place it is used
- cannot be reused anywhere else
- the types of parameter/s are inferred from context
- `.Sum`(method that returns a number)
- .`Where`(method that returns a bool)
- `.OrderBy`(method that returns a key)
- `.Count`(method that returns a bool)

### Decorative
- a function that takes another function and extends the behavior of the latter function without explicitly modifying it

### Imperative
```csharp
int countEven = 0;
foreach (var num in nums)
{
	if (IsEven(num))
	{
		countEven++;
	}
}
```
- step by step


### Anonymous method
```csharp
int countDEven = nums.Count(delegate (int n) { return n % 2 == 0; });
```

### Lambda
```csharp
int countLEven = nums.Count(x => x % 2 == 0);
```

### Where
```csharp
var londonPeopleQuery = people.Where(p => p.City == "London");
foreach (var p in londonPeopleQuery)
{
	Console.WriteLine(p);
}
```

### Order by
```csharp
var peopleOrderByAge = people.OrderBy(x => x.Age).OrderByDescending(x => x.Name);
foreach (var p in peopleOrderByAge)
{
	Console.WriteLine(p);
}
```

### Select
```csharp
var londonAges = people.Where(p => p.City == "london").Select(x => x.Age);
foreach (var p in londonAges)
{
	Console.WriteLine(p);
}
```
returns a query of ages


### Anonymous types
```csharp
var anon = people.Select(x => new { FullName = x.Name });
var employee = new { Age = 30, Name = 12 };
```
- for read-only purposes


"At what point query expressions are executed can vary. LINQ queries are always executed when the query variable is iterated over, not when the query variable is created. This is called deferred execution. You can also force a query to execute immediately, which is useful for caching query results. This is described later in this topic."

https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-execution


### Inline method
- a method written in one line


```csharp
public override string ToString()
{
	return $"{Name} - {City} - {Age}";
}
```
```csharp
public override string ToString() => $"{Name} - {City} - {Age}";
```


