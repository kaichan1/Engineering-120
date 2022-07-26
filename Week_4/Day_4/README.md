# Week 4 - Advanced C# & Data - Day 4

[Back](/Week_4)

[Main Menu](/README.md)

---
Date: 7/21

## Refactoring

https://docs.microsoft.com/en-gb/visualstudio/ide/refactoring-in-visual-studio?view=vs-2022


### Code Smells
- Inappropriate Names
- Dead Code
    - delete unnecessary codes
    - don't just comment them out
    - git will keep track of the changes
    - fields, methods, classes never used
- Duplicate Code
- Long Methods
- Data Clumps
- Large Classes
- Long Method Parameter Lists
    - use objects or interface instead
- Feature Envy
    - when one class calls another exccessively
- Repeated Switch / If-Else Statements


## Design Pattern

### Singleton
http://benhuang.blogspot.com/2007/07/singleton-pattern-logger-example.html

### Strategy

### Decorator
#### Stream
When the client calls a Stream method such as Open, Close, Read, Write or Flush on the BufferedStream object it is holding:
- the buffered stream object calls the same method on the GzipStream object it holding which unzips it
- which calls the same method on its FileStream object

### Categogies of Pattern
- Creational
- Behavioural
- Structural
