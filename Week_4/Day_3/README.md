# Week 4 - Advanced C# & Data - Day 3

[Back](/Week_4)

[Main Menu](/README.md)

---
Date: 7/20

### Alternatives to Typora

[TypeDown](https://apps.microsoft.com/store/detail/typedown-a-wysiwyg-markdown-editor/9P8TCW4H2HB4?hl=en-us&gl=US)

https://marketplace.visualstudio.com/items?itemName=hideoo.typedown

Notepad++

VS Code with Markdown extension

---

## Algorithm Complexity and Big-O Notation


| Array | O(n^2) | O(log2(n)) |
| - | - | - |
| 2 | 4 | 1 |
| 4 | 16 | 2 |
| 8 | 256 | 3 |

		

```csharp
static void Main(string[] args)
{
	int[] arr = { 0, 1, 2, 3 };
	var result = Contains(arr, 3);
	//O(n)
	var resultWorst = Contains(arr, 3);
	var resultBest = Contains(arr, 0);
}
public static bool Contains(int[] arr, int num)
{
	for (int i 0; i < arr.Length; i++)
	{
		return arr[i] == num;
	}
	return false;
}
```

https://www.bigocheatsheet.com/


## Recursion
```csharp
public static int SumLoop(int n)
{
	int sum = 0;
	for (int i 0; i <= n; i++)
		sum += i;
	return sum;
}
public static int SumRecursive(int n)
{
	if (n == 0) return 0;
	int prev = SumRecursive(n - 1); //B
	int sum = n + prev;
	return sum;
}
```


