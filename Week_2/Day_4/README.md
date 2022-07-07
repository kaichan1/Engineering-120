# Week 2 - C# Basics - Day 4

[Back](/Week_2)

[Main Menu](/README.md)

---
Date: 7/7

Tools -> Options -> Intellicode (Not intellisense!)
Then disable the following :
- Show completions for whole lines of code
- Show completions on new lines

```csharp
Assert.That(() => Exercises.Average(myList), Throws.TypeOf<System.ArgumentNullException>());
```

---

## Strings

```csharp
string message = "I like donuts";
```
- string is an alias

```csharp
String message = "I like donuts";
```
- String is a class

##3 Immutable
- can be overwritten
- cannot be changed
```csharp
String message = "I like donuts";
message.Insert(message.Length - 1, "Actually, I like pie");
Console.WriteLine(message);
```
- won't work

```csharp
String message = "I like donuts";
message = message.Insert(message.Length - 1, "Actually, I like pie");
Console.WriteLine(message);
```
- works

### Methods
```csharp
.Concat(a, b)
.Trim()
.ToUpper()
.Replace()
.Remove()
.Split()
.ToCharArray()
```

### Method overloading
> Right-click Concat
>>> Peek definition


### [StringBuildrer](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-6.0)
- mutable
- memory-saving

```csharp
StringBuilder sb = new StringBuilder("Hello World");
```
> Right-click StringBuilder
>> Quick Actions and Refractoring
>>> using System.Text;

```csharp
public static string StringBuilderExercise(string myString)
{
	string ucTrimmedString = myString.Trim().ToUpper();
	int nPos = ucTrimmedString.IndexOf('N');

	StringBuilder sb = new StringBuilder(ucTrimmedString);
	sb.Replace('L', '*').Replace('T', '*');
	sb.Remove(nPos + 1, sb.Length - nPos - 1);

	return sb.ToString();
}
```

Compared with string:

```csharp
myString = myString.Trim()
```

- a new string is still created, then myString is referenced to the new string

#### StringBuilder methods
```csharp
.Replace()
.Remove()
.ToString()
```

| Command | Description |
| - | - |
| ctr + d | duplicat this line |


### String interpolation
| Command | Description |
| - | - |
| $" … { … } … " | string interpolation |
| {(num2 - num1):0.###} | 3 decimal places |
| {(num2 - num1):C} | in currency |
| {(num2 - num1):D2} | 2 decimal places |
| {(num2 - num1):P1} | percent, 1 decimal place |

https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

### Parsing strings
```csharp
public static void ParsingStrings()
        {
            Console.WriteLine("How many cars do you own?");
            string input = Console.ReadLine();
            //int numOfCars = Int32.Parse(input);

            var success = Int32.TryParse(input, out int numOfCars);

            Console.WriteLine(numOfCars);
        }
```

```csharp
var success = Int32.TryParse(input, out int numOfCars);
```
| Command | Description |
| - | - |
| success | bool |
| out | when multiple values are returned in a method |
| numOfCars | default = 0 |
| Int32.TryParse(input, out var numOfCars) | var is implied in method |


## Array
Size has to be declared

### 1D Array
```csharp
string[] arrayOfStrings = { "hello", "world" };
char[] arrayOfChars = { 'a', 'b', 'c' };
int[] arrayOfInts = new int[10];
```

### 2D Array
```csharp
int[,] grid = new int[2,4];
grid[0,1] = 6;
grid[1,3] = 8;

foreach(var element in grid)
{
	Console.WriteLine(element);
}
```
#### Get lower/upper bound
```csharp
string[,] chessBoard = {{ "pawn", "king" },{ "blank", "blank" }, { "enemy king", "enemy pawn"}};
int lower1D = chessBoard.GetLowerBound(0);
int lower2D = chessBoard.GetLowerBound(1);
int upper1D = chessBoard.GetUpperBound(0);
int upper2D = chessBoard.GetUpperBound(1);

string theBoard = "";
for (int i = lower1D; i <= upper1D; i++)
{
	for (int j = lower2D; j <= upper2D; j++)
	{
		theBoard += $"{chessBoard[i, j]} is at {i} and {j}\n";
	}
}
Console.WriteLine(theBoard);
```

### Jagged Array
an array that contains arrays

```csharp
int[][] jaggedIntArray = new int[2][];
jaggedIntArray[0] = new int[4];
jaggedIntArray[1] = new int[2];
```
- only needs to specify length of first array

| Command | Description |
| - | - |
| ctr + k + f | pretty format |

## [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)
```csharp
var now = DateTime.Now;
Console.WriteLine(now);
var tomorrow = now.AddDays(1);
Console.WriteLine(tomorrow);

var nishBday = new DateOnly(1989, 11, 2);
Console.WriteLine(nishBday);

var now2 = DateOnly.FromDateTime(now);
Console.WriteLine(now2);
```
- DateOnly is a constructer

https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings

### Stopwatch
```csharp
var stopwatch = new Stopwatch();
stopwatch.Start();
int total = 0;
for (int i = 0; i < int.MaxValue; i++)
{
	total += i;
}
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);
```
