## Exercises

### Exercise 1

Create step definitions for the follow scenario:

```gherkin
@HappyPath
Scenario: Multiply
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press multiply
	Then the result should be <result>

Examples: 
|input1 |input2  |result  |
| 1     | 1      | 1      |
| 2     | 3      | 6      |
| 9     | 9      | 81     |
| 5     | -17    | -85    |
```



### Exercise 2

Create step definitions for the follow scenarios:

```gherkin
@SadPath
Scenario: Divide By Zero
	Given I have a calculator
	And I enter <input1> and 0 into the calculator
	When I press divide
	Then a DivideByZero Exception should a DivideByZeroException when I press divide
	And the exception should have the message "Cannot Divide By Zero"
	Examples:
	| input1 | 
	| 1      | 
	| 6      | 
```

### Exercise 3

Create step definitions for the follow scenario:

```gherkin
@HappyPath
Scenario: SumOfNumbersDivisibleBy2
	Given I have a calculator
	And I enter the numbers below to a list
	| nums |
	| 1    |
	| 2    |
	| 3    |
	| 4    |
	| 5    |
	When I iterate through the list to add all the even numbers
	Then the result should be 6
```



