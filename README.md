###### Made by Tomas Pasiecznik

# Advanced Console Calculator (C#)

## Introduction

This calculator offers the following features:  
•	Basic Operations: Addition, Subtraction, Division, Multiplication, Square Root, Square.  
•	The user is able to select what functions they would like to use from the console when the program starts.  
•	The calculator is configurable, you can specify what functions the calculator is capable of and dynamically add functionality to it at run-time based on the user's selection.  
•	The user can select an option that will display what the calculator is capable of doing.  
•	Calculations are stored in a model.  
•	Each calculation is stored in a list of calculations.  
•	A user can iterate over the list of calculations to display the next, previous, first, and last calculation in the list of calculations.    
•	The calculator can handle a divide by zero condition.  
•	The calculator utilizes at least 5 design patterns.  
•	The calculator utilized dependency injection and illustrated how to use the inversion of control principle with the implementation of a logging library.  

## How Each Design Pattern Was Used

### 1: Decorator Design Pattern – Used for the calculator’s operations. When letting the user add functionality to the calculator, decorators are tied to events which are set off by the user.  
**Code Example: (See Decorators Folder For More)**  
```c#
// Concrete Addition Decorator (Decorator Design Pattern)
    class AdditionDecorator : CalculatorDecorator
    {
        public AdditionDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var sum = Calculation.Create(a, b, Operations.Addition, calculator);

            return sum;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[^1].Operation(calculator.CalculationHistory[^1].A, calculator.CalculationHistory[^1].B);
        }
    }
```

### 2: Command Design Pattern – Used to handle user input at run-time.  
**Code Example: (See Commands Folder For More)**  
```c#
namespace CalculatorProject.Commands
{
    // Command Abstract Class
    abstract class Command
    {
        public abstract bool UserInputCheck(Invoker command);
        public abstract bool UserChoiceCheck(Invoker command);
        public abstract void Execute(Invoker command, ICalculatorComponent calculator);
        public abstract void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger);
    }
}
```
	
### 3: Iterator Design Pattern – Used for traversing and displaying the calculation history as well as to retrieve specific indexes throughout the calculator.  
**Code Example: (See Iterator Folder For More)**  
```c#
// Concrete Iterator Class (Iterator Design Pattern)
    class Iterator : ICalculationIterator
    {
        public Collection CalculationHistory;
        public int Index = 0;
        public int NextI = 1;
        public int PreviousI = -1;

        // Iterator Constructor (Iterator Design Pattern)
        public Iterator(Collection history)
        {
            this.CalculationHistory = history;
        }

        public void Next(ICalculatorComponent calculator)
        {
            Index += NextI;
            bool end = EndOfCollection();

            while (!end)
            {
                ShowSingle(Index, calculator);
                end = true;
            }

            end = EndOfCollection();
            while (end)
            {
                Index = CalculationHistory.Count - 1;
                Prompts.Write("\nYou are at the end of the calculation history.");
                Last(calculator);
                end = false;
            }
        }
```

### 4: Façade Design Pattern – Used to hide the calculator’s calculation modification functions to create a more simplified interface for these functions of the calculator.  
**Code Example: (See Facade Folder For More)**  
```c#
namespace CalculatorProject.Facade
{
    // The Facade Class (Facade Design Pattern)
    class CalculationManipulation
    {
        public Edit _edit = new Edit();
        public Remove _remove = new Remove();

        public void RemoveCalculation(ICalculatorComponent calculator, int index)
        {
            _remove.Execute(calculator, index);
        }…
```

### 5: State Design Pattern – Used to track the state of a calculation in order to see if it is “Unmodified” or “Modified”.  
**Code Example: (See State Folder For More)**  
```c#
namespace CalculatorProject.State
{
    // Context Class (State Design Pattern)
    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }
}
``` 
 
## How SOLID Was Applied  
1.	Single Responsibility Principle (SRP)  
  a.	This principal was applied to each file when working with that file’s class. Each class has one responsibility to deal with and is not overloaded with multiple functions that may have otherwise made this calculator more confusing to work with.  
2.	Open Closed Principle (OCP)  
  a.	This principal was applied as every class and function I cleared can easily be extended to add more features. I added several features myself utilizing this principal along with some of the design patters discussed above and everything went smoothly. This principal allowed me to add new features without changing my original code.  
3.	Liskov Substitution Principle (LSP)  
  a.	This principal was applied when implementing the iterator design pattern. A collection had to be made to act as the parent to the iterator. The iterator then had several functions it could then perform to assist with many useful features that are found within the calculator.  
4.	Interface Segregation Principle (ISP)  
  a.	This principal was applied since the beginning of the project because I created the calculated with the idea in mind that the user would implement features as they need them. There are no overwhelming classes in this program, and this really helps the calculator run as light as possible. Only what is needed in the moment gets added to the calculator. The rest of the classes are left on unimplemented until the user needs them. The most noticeable example of this principal’s application would have to be with the calculator’s operations.  
5.	Dependency Inversion Principle (DIP)  
  a.	This principal was applied throughout the calculator program through interfaces and the abstraction of classes. For example, abstract classes were made for both the command design pattern and the state design pattern. This allowed me to get as detailed as I wanted with the classes, before further, more specific, implementations. Interfaces were used in the same way within the calculator in multiple cases.  

## How Dependency Injection Was Used
Dependency Injection was used when setting up the functionality for the calculator to handle the “DivideByZeroException”. A log entry is made when the exception is encountered and the calculation record that is associated with it will be skipped.  

## Program Walkthrough
When the calculator is first activated, the user will need to interact with the console in order to use it. The first thing the user is asked to do is to add operation functionality to the calculator. The program uses events to listen for the user input and subsequently perform the correct actions that the user wants. The user can choose to add addition, subtraction, multiplication, division, square root, or square functionalities. These are entered one at a time and the user is asked to type “DONE” when they are done adding calculations. Then, the user is asked to choose the operation they would like to calculate from a list of functionalities that they just added. When the user chooses an operation, they will be asked to input numbers and will be given the answer to their calculation. If a user chooses division and divides a number by zero, a “DivideByZeroException” will be handled, and the calculation will not be stored. At this point, the user can do more calculations by entering “YES” when they are asked. If a user enters “NO”, they will be shown several options that hold most of the calculator’s interesting features. The first option the user can choose is to view the entire calculation history. The second option the user can choose is to view/modify the calculation history one by one. This option includes the “NEXT”, “PREVIOUS”, “FIRST”, “LAST”,  “CHANGE”, and “REMOVE” features. The third option the user can choose is to go back to creating new calculations. The fourth option the user can choose is to display what the calculator is capable of doing in its current state. The fifth option the user can choose is to check the state of all the calculations. The sixth option the user can choose is to exit the calculator when they are done. When the user decides to exit the program, a “Goodbye!” message will appear.  

## Screenshot of Tests Passing
![Tests Passing](/Tests-Passing.png "Screenshot of Tests Passing")
 
## Articles Referenced
https://www.dotnettricks.com/learn/designpatterns/solid-design-principles-explained-using-csharp  
https://www.c-sharpcorner.com/UploadFile/1c8574/events-in-C-Sharp/  
https://refactoring.guru/design-patterns/decorator  
https://www.dofactory.com/net/decorator-design-pattern  
https://refactoring.guru/design-patterns/facade  
https://www.dofactory.com/net/facade-design-pattern  
https://refactoring.guru/design-patterns/iterator  
https://www.dofactory.com/net/iterator-design-pattern  
https://refactoring.guru/design-patterns/command  
https://www.dofactory.com/net/command-design-pattern  
https://www.intertech.com/c-sharp-tutorial-understanding-c-events/  
https://refactoring.guru/replace-conditional-with-polymorphism  
https://youtu.be/G7ErX_0eCkU  
https://refactoring.guru/design-patterns/observer  
https://www.dofactory.com/net/state-design-pattern  
https://www.blinkingcaret.com/2018/02/14/net-core-console-logging/  
https://www.tutorialspoint.com/dividebyzeroexception-class-in-chash  

